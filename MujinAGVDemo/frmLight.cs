﻿using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MujinAGVDemo
{
    public partial class frmLight : Form
    {
        public frmLight()
        {
            InitializeComponent();
        }
        #region Const
        /// <summary>
        /// 設定ファイルのデフォルトパス
        /// </summary>
        const string defaultSettingPath = @"Setting/ParamSetting.xml";

        #endregion Const

        #region Private Parameter
        /// <summary>
        /// 設定ファイルのパス
        /// </summary>
        private string settingPath = defaultSettingPath;
        private ParamSettings param;
        private bool isStop = false;
        private readonly FileIO fileIO = new FileIO();
        private readonly Logger logger = LogManager.GetLogger("ProgramLogger");

        #endregion Private Parameter

        #region Public Paramater

        //public CommandFactory Factory = new CommandFactory("10.10.10.4");

        #endregion Public Paramater

        #region Deligate

        delegate void ChangeDgvDelegate();

        #endregion Deligate

        #region Event

        private void frmLight_Load(object sender, EventArgs e)
        {
            this.Text = $"AGVデモソフト {Application.ProductVersion}";
            if (!fileIO.TryLoadSetting(settingPath, out param))
            {
                return;
            }
            try
            {
                updateControl();
                checkBoxIsStop.Checked = isStop;
                agvDataControl.Settings.AddAGVHouseDictionary("111", "162918439249", "原位置", Color.LightGreen);
                agvDataControl.Settings.AddAGVHouseDictionary("112", "162918439248", "原位置", Color.LightGreen);
                agvDataControl.Settings.AddAGVHouseDictionary("113", "1629184392138", "原位置", Color.LightGreen);
                agvDataControl.Settings.AddAGVHouseDictionary("114", "1629184392137", "原位置", Color.LightGreen);
                agvDataControl.Settings.AddAGVHouseDictionary("115", "162918439247", "原位置", Color.LightGreen);
                agvDataControl.Settings.AddAGVHouseDictionary("116", "162918439278", "原位置", Color.LightGreen);
                agvDataControl.Settings.AddAGVHouseDictionary("117", "1629184392169", "原位置", Color.LightGreen);
                agvDataControl.Settings.AddAGVHouseDictionary("118", "1629184392168", "原位置", Color.LightGreen);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }

        private async void tmrAGVInfoUpdate_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Invoke(new ChangeDgvDelegate(changeDgv));
            });
        }

        private void btnAddPod_Click(object sender, EventArgs e)
        {
            addPod();
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            removePod();
        }

        private void btnRemovePodAll_Click(object sender, EventArgs e)
        {
            updateParam();
            var (isSuccess, messages) = Command.MapCommands.RemoveAllShelfs(param.ServerIP, param.WarehouseID);
            var message = new StringBuilder();
            messages.ToList().ForEach(x => message.Append(x));
            showMessageBox(isSuccess, message.ToString());
        }

        private void btnSetPodPos_Click(object sender, EventArgs e)
        {
            updateParam();
            var (isSuccess, message) = Command.MapCommands.SetPodPosition(param.ServerIP, param.WarehouseID, param.PodID, param.NodeID);

            showMessageBox(isSuccess, message);
        }

        private void btnUnSetOwner_Click(object sender, EventArgs e)
        {
            if (showCheckMessage($"AGV[{param.RobotID}]をロック解除しますか？") != DialogResult.OK)
            {
                return;
            }
            unsetOwner();
        }

        private void btnSetOwner_Click(object sender, EventArgs e)
        {
            if (showCheckMessage($"AGV[{param.RobotID}]をロックしますか？") != DialogResult.OK)
            {
                return;
            }
            setOwner();
        }

        private async void checkBoxTimerRun_CheckedChanged(object sender, EventArgs e)
        {
            logger.Info($"AGV状態[{checkBoxTimerRun.Text}]");
            if (!tmrAGVInfoUpdate.Enabled)
            {
                checkBoxTimerRun.Text = "監視停止";
                checkBoxTimerRun.BackColor = Color.Red;
                tmrAGVInfoUpdate.Start();
                await Task.Run(() =>
                {
                    Invoke(new ChangeDgvDelegate(changeDgv));
                });
            }
            else
            {
                checkBoxTimerRun.Text = "監視開始";
                checkBoxTimerRun.BackColor = Color.GreenYellow;
                tmrAGVInfoUpdate.Stop();
            }
        }

        private void checkBoxIsStop_CheckedChanged(object sender, EventArgs e)
        {
            var serverIP =
                param.ServerIP;
            var warehouseID =
                param.WarehouseID;
            var robotID =
                param.RobotID;

            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }

            isStop = !isStop;
            //AGVを停止させる
            if (isStop == false)
            {
                //AGV停止指示
                factory.Create(new PauseRobotParam(robotID)).DoAction();
                //ボタン表示の変更
                checkBoxIsStop.Text = "AGV運行";
                checkBoxIsStop.BackColor = Color.GreenYellow;
            }
            //AGVを運航させる
            else
            {
                //ボタン表示の変更
                checkBoxIsStop.Text = "AGV停止";
                checkBoxIsStop.BackColor = Color.Red;
                //AGV運航指示
                factory.Create(new ResumeRobotParam(robotID)).DoAction();
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            updateParam();
            if (settingPath != defaultSettingPath)
            {
                fileIO.SaveSetting(defaultSettingPath, param);
            }
            fileIO.SaveSetting(settingPath, param);
            showInfoMessageBox($"設定ファイルを保存しました。{Environment.NewLine}保存先:{Path.GetFullPath(settingPath)}");
        }

        private void btnLoadSetting_Click(object sender, EventArgs e)
        {
            if (!fileIO.TryLoadSetting(settingPath, out param))
            {
                btnLoadSetting.BackColor = Color.Red;
                return;
            }
            var message =
                $"設定ファイルの読込に成功しました。{Path.GetFullPath(settingPath)}";
            logger.Info(message);
            btnLoadSetting.BackColor = Color.Green;
            showInfoMessageBox(message);
            updateControl();
        }

        private void btnOpenParamSettings_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "設定ファイルを選択",
                InitialDirectory = Path.GetDirectoryName(settingPath),
                Filter = "XMLファイル|*.xml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                settingPath = openFileDialog.FileName;

                if (fileIO.TryLoadSetting(settingPath, out param))
                {
                    updateControl();
                    updateParam();
                    logger.Info($"設定ファイルを選択しました。[{openFileDialog.FileName}]");
                }
            }
            else
            {
                logger.Info("設定ファイルの選択がキャンセルされました。");
            }
            openFileDialog.Dispose();
        }

        #endregion Event

        #region Method

        /// <summary>
        /// パラメータをコントロールに反映する
        /// </summary>
        private void updateControl()
        {
            textBoxServerIP.Text = param.ServerIP;
            textBoxWarehouseID.Text = param.WarehouseID;
            textBoxLayoutID.Text = param.LayoutID;
            textBoxPodID.Text = param.PodID;
            textBoxNodeID.Text = param.NodeID;
            textBoxRobotID.Text = param.RobotID;
        }
        /// <summary>
        /// コントロールの内容をパラメータに反映する
        /// </summary>
        private void updateParam()
        {
            param.ServerIP = textBoxServerIP.Text;
            param.WarehouseID = textBoxWarehouseID.Text;
            param.LayoutID = textBoxLayoutID.Text;
            param.PodID = textBoxPodID.Text;
            param.NodeID = textBoxNodeID.Text;
            param.RobotID = textBoxRobotID.Text;
        }
        /// <summary>
        /// AGV情報タブのデータを更新します
        /// </summary>
        private void changeDgv()
        {
            //var (isSuccess, table) = Command.MapCommands.GetAgvDetailTable(param.ServerIP, param.WarehouseID);
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            var getRobotListRet = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();
            var getPodListRet = (GetPodListFromDBReturnMessage)factory.Create(new GetPodListFromDBParam()).DoAction();
            if (getRobotListRet.Data != null)
            {
                agvDataControl.ChangeDgv(getRobotListRet, getPodListRet);
                //dgvAGVDetail.DataSource = table;
                lblUpdateTime.Text = $"更新日時：{DateTime.Now}";
            }
            else
            {
                checkBoxTimerRun.Checked = false;
                showErrorMessageBox("AGV情報の取得に失敗しました。監視を停止します。");
            }

        }

        /// <summary>
        /// 棚を追加します
        /// </summary>
        private void addPod()
        {
            updateParam();
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var layoutID = param.LayoutID;
            var podID = param.PodID;
            var nodeID = param.NodeID;

            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                //showAddPodErrorDialog(Messages.NotConnectMsg);
                return;
            }
            try
            {
                var addPodResult = factory.Create(new AddPodParam(podID, nodeID, layoutID)).DoAction();
                var logMessage = $"棚 {podID},作成位置 {nodeID}";
                logger.Info(logMessage);
                logger.Info(addPodResult.ReturnMsg);
                //lblCurrentLineProcess.Text = logMessage;
                var resultMessage =
                    addPodResult.ReturnMsg == "succ" ? "成功" : "失敗";
                showInfoMessageBox($"棚作成に{resultMessage}しました。{Environment.NewLine}棚 {podID},作成位置 {nodeID}");
            }
            catch (EmergencyException ee)
            {
                logger.Error(ee);
                //showAddPodErrorDialog(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                //showAddPodErrorDialog(ex.Message);
            }
        }
        /// <summary>
        /// 棚を削除します
        /// </summary>
        private void removePod()
        {
            updateParam();
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var podID = param.PodID;


            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                //showRemovePodErrorDialog(Messages.NotConnectMsg);
                return;
            }
            logger.Info($"棚[{podID}]を削除します。IP[{serverIP}]warehouseID[{warehouseID}]");
            try
            {
                var removePodResult = factory.Create(new RemovePodParam(podID)).DoAction();
                var logMessage = $"棚 {podID}";
                logger.Info(logMessage);
                logger.Info(removePodResult.ReturnMsg);
                //lblCurrentLineProcess.Text = logMessage;
                var resultMessage =
                    removePodResult.ReturnMsg == "succ" ? "成功" : "失敗";
                showInfoMessageBox($"棚削除に{resultMessage}しました。{Environment.NewLine}棚 {podID}");
            }
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
                //showRemovePodErrorDialog(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                //showRemovePodErrorDialog(ex.Message);
            }
        }
        /// <summary>
        /// AGVの占有状態を解除します
        /// </summary>
        /// <param name="robotID">AGVの号機</param>
        private void unsetOwner(string robotID)
        {
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            var (isSuccess, message) = Command.MapCommands.UnsetOwner(factory, robotID);
            showMessageBox(isSuccess, message);

        }
        /// <summary>
        /// AGVの占有状態を解除します
        /// </summary>
        private void unsetOwner()
        {
            var robotID = param.RobotID;
            unsetOwner(robotID);

        }
        /// <summary>
        /// AGVを占有します
        /// </summary>
        private void setOwner()
        {
            var robotID = param.RobotID;
            setOwner(robotID);
        }
        private void setOwner(string robotID)
        {
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            var (isSuccess, message) = Command.MapCommands.SetOwner(factory, robotID);
            showMessageBox(isSuccess, message);
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

        #endregion Method

        private void mnuOpenMainForm_Click(object sender, EventArgs e)
        {
            using(var frm=new frmMain(param))
            {
                frm.ShowDialog();
            }
        }
    }
}
