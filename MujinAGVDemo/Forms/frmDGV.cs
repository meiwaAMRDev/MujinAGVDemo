using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hetu20dotnet;
using Hetu20dotnet.Controls;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;
using NLog;

namespace MujinAGVDemo
{
    public partial class frmDGV : Form
    {
        /// <summary>
        /// ファクトリ
        /// </summary>
        public CommandFactory Factory;
        public readonly Logger logger = LogManager.GetLogger("ProgramLogger");
        public string PowerLogPath = string.Empty;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="factory">ファクトリ</param>
        public frmDGV(CommandFactory factory)
        {
            InitializeComponent();
            Factory = factory;
        }

        private void frmMove_Load(object sender, EventArgs e)
        {
            PowerLogPath = Path.Combine("Logs", "Power", $"{DateTime.Now:yyyy-MM-dd}_power.csv");
        }
        /// <summary>
        /// デリゲート
        /// </summary>
        delegate void ChangeDgvDelegate();
        /// <summary>
        /// 監視状態切替
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void checkBoxTimerRun_CheckedChanged(object sender, EventArgs e)
        {
            //タイマーOFFの時
            if (!tmrDGV.Enabled)
            {
                checkBoxTimerRun.Text = "監視停止";
                checkBoxTimerRun.BackColor = Color.Red;
                tmrDGV.Start();
                await Task.Run(() =>
                {
                    Invoke(new ChangeDgvDelegate(changeDgv));
                });
            }
            //タイマーONの時
            else
            {
                checkBoxTimerRun.Text = "監視開始";
                checkBoxTimerRun.BackColor = Color.GreenYellow;
                tmrDGV.Stop();
            }
        }
        /// <summary>
        /// AGV情報タブのデータを更新します
        /// </summary>
        private void changeDgv()
        {
            var factory = Factory;
            if (!factory.IsConnectedTESServer())
            {
                checkBoxTimerRun.Checked = false;
                var message = $"Hetuサーバーに接続できないためAGV状態監視を終了します。";
                showErrorMessageBox($"{message}");
                return;
            }
            var getRobotListRet = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();
            var getPodListRet = (GetPodListFromDBReturnMessage)factory.Create(new GetPodListFromDBParam()).DoAction();
            if (getRobotListRet.Data != null)
            {
                agvDataControl.ChangeDgv(getRobotListRet, getPodListRet);
                //dgvAGVDetail.DataSource = table;
                lblUpdateTime.Text = $"更新日時：{DateTime.Now}";

                WriteAGVPowerLog(robotLists: getRobotListRet.Data, savePath: PowerLogPath);
            }
            else
            {
                checkBoxTimerRun.Checked = false;
                showErrorMessageBox("AGV情報の取得に失敗しました。監視を停止します。");
            }
        }
        /// <summary>
        /// 各AGVの時間ごとのバッテリー残量をログに出力します
        /// </summary>
        /// <param name="robotLists">AGVデータ</param>
        /// <param name="savePath">ログ出力先</param>
        private void WriteAGVPowerLog(GetRobotListReturnMessage.GetRobotListData robotLists, string savePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(savePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(savePath));
            }
            //StreamWriterでファイルを作る前に存在するか判定
            var isFileExist = File.Exists(savePath);

            using (var sw = new StreamWriter(path: savePath,
                                             append: true,
                                             encoding: Encoding.GetEncoding("shift-jis")))
            {
                var robots = robotLists.RobotList.ToList();
                if (!isFileExist)
                {
                    var header = new List<string>() { "time" };
                    header.AddRange(robots.Select(i => i.RobotID).ToList());
                    sw.WriteLine(string.Join(",", header));
                }

                var power = new List<string>() { DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") };
                power.AddRange(robots.Select(i => i.UcPower.ToString()).ToList());
                sw.WriteLine(string.Join(",", power));
            }
        }

        private async void tmrDGV_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Invoke(new ChangeDgvDelegate(changeDgv));
            });
        }

        #region メッセージボックス関連

        /// <summary>
        /// Infoのメッセージボックスを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showInfoMessageBox(string message)
        {
            //ログ表示の際に改行文字を空白に置き換える
            logger.Info(message.Replace(Environment.NewLine, string.Empty));
            return MessageBox.Show(message, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Errorのメッセージボックスを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showErrorMessageBox(string message)
        {
            logger.Error(message);
            return MessageBox.Show(message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// メッセージボックスを表示します
        /// </summary>
        /// <param name="isSuccess">Infoの場合true,Errorの場合falseを入れる</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showMessageBox(bool isSuccess, string message)
        {
            return isSuccess
                ? showInfoMessageBox(message)
                : showErrorMessageBox(message);
        }
        /// <summary>
        /// 確認のメッセージボックスを表示します
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showCheckMessage(string message)
        {
            return MessageBox.Show(message, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        #endregion メッセージボックス関連
    }
}
