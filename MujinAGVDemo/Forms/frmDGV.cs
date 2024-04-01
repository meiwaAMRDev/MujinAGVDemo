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
        public AGVDataDisplaySetting AGVDataDisplaySetting = new AGVDataDisplaySetting();
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

        private void checkBoxPowerLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPowerLog.Checked)
            {
                checkBoxPowerLog.Text = "ログ停止";
                checkBoxPowerLog.BackColor = Color.Red;
            }
            else
            {
                checkBoxPowerLog.Text = "ログ開始";
                checkBoxPowerLog.BackColor = Color.GreenYellow;
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
            //var getPodListRet = (GetPodListFromDBReturnMessage)factory.Create(new GetPodListFromDBParam()).DoAction();
            if (getRobotListRet.Data != null)
            {
                dataGridView1.DataSource = getAGVDataTable(getRobotListRet).table;

                dataGridView1.AutoResizeColumns();
                lblUpdateTime.Text = $"更新日時：{DateTime.Now}";
                if (checkBoxPowerLog.Checked)
                    WriteAGVPowerLog(robotLists: getRobotListRet.Data, savePath: PowerLogPath);
            }
            else
            {
                checkBoxTimerRun.Checked = false;
                showErrorMessageBox("AGV情報の取得に失敗しました。監視を停止します。");
            }
        }

        /// <summary>
        /// AGVのデータをDataTableとして取得します
        /// </summary>
        /// <param name="getRobotListReturnMessage"></param>
        /// <param name="getPodListFromDBReturnMessage">GetPodListFromDBのリターンメッセージ</param>
        /// <returns>isSuccess:AGV情報があればtrue,table:AGV情報のデータテーブル</returns>
        private (bool isSuccess, DataTable table) getAGVDataTable(GetRobotListReturnMessage getRobotListReturnMessage)
        {
            var table = new DataTable();

            if (getRobotListReturnMessage.Data == null)
            {
                //NoticeErrorEvent?.Invoke(this, "AGV情報がありません。");
                return (false, table);
            }

            table.Columns.Add("グループ");
            table.Columns.Add("号機");
            table.Columns.Add("状態");
            table.Columns.Add("所有者");
            table.Columns.Add("コード");
            table.Columns.Add("エラー");
            table.Columns.Add("電池");
            table.Columns.Add("棚ID");
            table.Columns.Add("タスクタイプ");
            table.Columns.Add("タスクID");
            table.Columns.Add("ノードID");
            table.Columns.Add("X座標");
            table.Columns.Add("Y座標");

            getRobotListReturnMessage.Data?.RobotList
                //AGVの所属グループ・ロボットIDでソート
                .OrderBy(rb => rb.RobotID)
                .OrderBy(rb => rb.RobotGroupID)
                .ToList()
                .ForEach(rb =>
                {
                    var pod = rb.Pods
                    .ToList()
                    .FirstOrDefault(p => p.PositionType == (int)PodPositionTypes.Robot);

                    var podID = pod == null ? string.Empty : pod.PodID;
                    var errorCode = string.Empty;
                    var errorMessage = string.Empty;
                    if (rb.ErrorCodes.Count > 0)
                    {
                        errorCode = rb.ErrorCodes.FirstOrDefault().ToString();
                        errorMessage = $"{rb.ErrorMessage}";
                    }
                    else
                    {
                        errorCode = "0";
                        errorMessage = $"{rb.ErrorState}";
                    }
                    table.Rows.Add(rb.RobotGroupID,
                               rb.RobotID,
                               rb.WorkStatus,
                               rb.Owner,
                               //rb.ErrorState,
                               errorCode,
                               errorMessage,
                               $"{rb.UcPower}",
                               $"{podID}",
                               rb.TaskType,
                               rb.TaskID,
                               rb.CurNodeID,
                               rb.CurX,
                               rb.CurY);
                });

            return (true, table);
        }
        /// <summary>
        /// 列のインデックス
        /// </summary>
        private enum agvDataColumn : int
        {
            RobotGroup,
            RobotID,
            WorkStatus,
            Owner,
            ErrorCode,
            ErrorState,
            UcPower,
            PodID,
            TaskType,
            TaskID,
            NodeID,
            X,
            Y,
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
                    //header.AddRange(robots.Select(i => i.RobotID).ToList());                    
                    foreach (var robot in robots)
                    {
                        header.Add($"AGV{robot.RobotID}");
                    }
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            var text = e.Value.ToString();
            //稼働状態
            if (e.ColumnIndex == (int)agvDataColumn.WorkStatus)
            {
                var a = AGVDataDisplaySetting.WorkStatus
                    .Where(x => x.Name == text).FirstOrDefault();
                changeDGVDisplay(e, a);
            }
            if (e.ColumnIndex == (int)agvDataColumn.TaskType)
            {
                var a = AGVDataDisplaySetting.TaskType
                    .Where(x => x.Name == text).FirstOrDefault();
                changeDGVDisplay(e, a);
            }
            if (e.ColumnIndex == (int)agvDataColumn.Owner)
            {
                var a = AGVDataDisplaySetting.Owner
                    .Where(x => x.Name == text).FirstOrDefault();
                changeDGVDisplay(e, a);
            }
            if (e.ColumnIndex == (int)agvDataColumn.ErrorState)
            {
                var a = AGVDataDisplaySetting.Error
                    .Where(x => x.Name == text).FirstOrDefault();
                changeDGVDisplay(e, a);
            }
            if(e.ColumnIndex == (int)agvDataColumn.UcPower)
            {
                if(!int.TryParse(text,out var power))
                {
                    return;
                }
                e.CellStyle.BackColor = power > AGVDataDisplaySetting.PowerLineYellow
                    ? Color.LightGreen
                    : power > AGVDataDisplaySetting.PowerLineRed ? Color.Yellow : Color.Red;
            }
            if (e.ColumnIndex == (int)agvDataColumn.PodID)
            {
                if (text != string.Empty)
                {
                    e.CellStyle.BackColor = Color.AliceBlue;
                }
            }
        }

        private static void changeDGVDisplay(DataGridViewCellFormattingEventArgs e, DGVDisplayData a)
        {
            if (a == null)
            {
                e.CellStyle.BackColor = Color.White;
            }
            else
            {
                e.CellStyle.BackColor = a.Color;
                e.Value = a.DisplayName;
            }
        }
    }
    public class AGVDataDisplaySetting
    {
        public List<DGVDisplayData> TaskType { get; set; }
        public List<DGVDisplayData> Error { get; set; }
        public List<DGVDisplayData> Owner { get; set; }
        public List<DGVDisplayData> WorkStatus { get; set; }

        public int PowerLineYellow { get; set; } = 50;
        public int PowerLineRed { get; set; } = 30;


        public AGVDataDisplaySetting()
        {
            TaskType = new List<DGVDisplayData>()
            {
                new DGVDisplayData("None","待機状態",Color.White),
                new DGVDisplayData("MoveRobot","AGV移動",Color.White),
                new DGVDisplayData("MovePod","棚搬送",Color.White),
                new DGVDisplayData("Charge","充電",Color.White),
                new DGVDisplayData("ChangeMap","マップ変更",Color.White),
                new DGVDisplayData("Custom","カスタムタスク",Color.White),
                new DGVDisplayData("InsulateZone","絶縁ゾーン（謎)",Color.White),
            };
            Error = new List<DGVDisplayData>()
            {
                new DGVDisplayData("NoError","正常",Color.White),
                new DGVDisplayData("CanNotReadQRFloor","床のQRコードが読めないとき",Color.Red),
                new DGVDisplayData("CanNotReadQRPod","棚のQRコードが読めないとき",Color.Red),
                new DGVDisplayData("EmergencyButtonPushed","非常停止ボタンが押された",Color.Red),
                new DGVDisplayData("BumperTouched","バンパーになにか当たった",Color.Red),
                new DGVDisplayData("ChargerAbnormal","充電器に異常が発生しました",Color.Red),
                new DGVDisplayData("AGVPowerCardAbnormal","AGV電源基盤の異常が発生しました",Color.Red),
                new DGVDisplayData("EmergencyButtonPushedDB","非常停止ボタンが押されました。(DB版)",Color.Red),
                new DGVDisplayData("BumperTouchedDB","バンパーに何か衝突しました。(DB版)",Color.Red),
                new DGVDisplayData("CanNotReadQRPodDB","棚のQRの読み取りに失敗しました。",Color.Red),
                new DGVDisplayData("CanNotReadQRFloorDB","地面のQRコードの読み取りに失敗しました。",Color.Red),
                new DGVDisplayData("ObstacleDetected","センサーが障害物を検出しました。",Color.Red),
                new DGVDisplayData("LowBatery","電池残量が残り少ないです。",Color.Red),
                new DGVDisplayData("AGVMotorModuleCommunicationError","足回りのモジュールとの通信異常が発生しました。",Color.Red),
                new DGVDisplayData("AGVLidarModuleErro","LiDARモジュールに異常が発生しました。",Color.Red),
                new DGVDisplayData("FailedCharge","充電に失敗しました。",Color.Red),
                new DGVDisplayData("WheelAbnormal","ホイールに異常が発生しました。",Color.Red),
                new DGVDisplayData("LifterAbnormal","リフターに異常が発生しました。",Color.Red),
            };
            Owner = new List<DGVDisplayData>
            {
                new DGVDisplayData("TES","なし",Color.White),
                new DGVDisplayData("SUPER","HETU",Color.Orange),
                new DGVDisplayData("biz_test","明和",Color.Yellow),
            };
            WorkStatus = new List<DGVDisplayData>
            {
                new DGVDisplayData("BUSY","作業中",Color.LightBlue),
                new DGVDisplayData("IDLE","アイドリング",Color.White),
                new DGVDisplayData("CHARGE","充電",Color.Orange),
                new DGVDisplayData("PAUSED","一時停止",Color.Yellow),
                new DGVDisplayData("ERROR","異常",Color.Red),
                new DGVDisplayData("OFFLINE","オフライン",Color.Gray),
                new DGVDisplayData("Exception","例外",Color.Red),
            };
        }
    }
    public class DGVDisplayData
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Color Color { get; set; }
        public DGVDisplayData()
        {
            Name = string.Empty;
            DisplayName = string.Empty;
            Color = Color.White;
        }
        public DGVDisplayData(string name, string displayName, Color color)
        {
            Name = name;
            DisplayName = displayName;
            Color = color;
        }
    }
}
