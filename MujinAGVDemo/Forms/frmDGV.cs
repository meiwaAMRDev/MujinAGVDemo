using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;

namespace MujinAGVDemo
{
    public partial class frmDGV : Form
    {
        /// <summary>
        /// ファクトリ
        /// </summary>
        public CommandFactory Factory;
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
            var (isSuccess, table) = Command.MapCommands.GetAgvTaskInfoTable(Factory);
            if (!isSuccess)
                return;
            dgvInfo.DataSource = table;
            lblUpdateTime.Text = $"更新日時：{DateTime.Now}";
        }

        private async void tmrDGV_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Invoke(new ChangeDgvDelegate(changeDgv));
            });
        }
    }
}
