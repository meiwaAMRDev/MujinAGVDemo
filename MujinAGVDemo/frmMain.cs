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
using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;
using NLog;

namespace MujinAGVDemo
{
    public partial class frmMain : Form
    {
        #region Const
        /// <summary>
        /// 設定ファイルのパス
        /// </summary>
        string settingPath = "ParamSetting.xml";
        /// <summary>
        /// CSVファイルの中のnodeIDのインデックス
        /// </summary>
        const int nodeIDIndex = 0;
        /// <summary>
        /// CSVファイルの中のturnModeのインデックス
        /// </summary>
        const int turnModeIndex = 1;
        /// <summary>
        /// CSVファイルの中のunloadのインデックス
        /// </summary>
        const int unloadModeIndex = 2;
        const int ON = 1;
        const int OFF = 0;
        
        #endregion Const

        #region Property

        ParamSettings param;
        bool isStop = false;
        FileIO fileIO = new FileIO();
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        Logger logger = LogManager.GetLogger("ProgramLogger");
        #endregion Property

        public frmMain()
        {
            InitializeComponent();
        }

        #region Event

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!tryLoadSetting())
            {
                return;
            }
            btnLoadSetting.BackColor = Color.LightGray;
            updateControl();
            listBoxDirection.SelectedIndex = 4;
            checkBoxIsStop.Checked = isStop;
            textBoxTaskID.Text = string.Empty;
        }



        private void btnAddPod_Click(object sender, EventArgs e)
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
                showAddPodErrorDialog(Messages.NotConnectMsg);
                return;
            }
            try
            {
                var addPodResult = factory.Create(new AddPodParam(podID, nodeID, layoutID)).DoAction();
                string logMessage = $"棚 {podID},作成位置 {nodeID}";
                logger.Info(logMessage);
                logger.Info(addPodResult.ReturnMsg);
                lblCurrentLineProcess.Text = logMessage;
                var resultMessage =
                    addPodResult.ReturnMsg == "succ" ? "成功" : "失敗";
                showInfoMessageBox($"棚作成に{resultMessage}しました。{Environment.NewLine}棚 {podID},作成位置 {nodeID}");
            }
            catch (EmergencyException ee)
            {
                logger.Error(ee);
                showAddPodErrorDialog(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                showAddPodErrorDialog(ex.Message);
            }
        }



        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            updateParam();
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var podID = param.PodID;


            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                showRemovePodErrorDialog(Messages.NotConnectMsg);
                return;
            }

            try
            {
                var removePodResult = factory.Create(new RemovePodParam(podID)).DoAction();
                string logMessage = $"棚 {podID}";
                logger.Info(logMessage);
                logger.Info(removePodResult.ReturnMsg);
                lblCurrentLineProcess.Text = logMessage;
                var resultMessage =
                    removePodResult.ReturnMsg == "succ" ? "成功" : "失敗";
                showInfoMessageBox($"棚削除に{resultMessage}しました。{Environment.NewLine}棚 {podID}");
            }
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
                showRemovePodErrorDialog(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                showRemovePodErrorDialog(ex.Message);
            }
        }

        private async void btnMovePod_Click(object sender, EventArgs e)
        {
            updateParam();
            if (isHetuUsed())
            {
                return;
            }
            var token = cancelTokenSource.Token;
            showInfoMessageBox($"棚搬送指示を作成しました。" +
                $"{Environment.NewLine}AGV:{param.RobotID},移動先:{param.NodeID},棚:{param.NodeID}");

            await movePod(param.ServerIP, param.WarehouseID, param.PodID
                , param.NodeID, param.RobotID, param.TurnMode, param.Unload, token);
        }

        private async void btnRotationMove_Click(object sender, EventArgs e)
        {
            updateParam();
            if (isHetuUsed())
            {
                return;
            }
            cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            var stationListPath = param.StationListPath;

            if (!fileIO.TryGetAllLines(stationListPath, out var nodeList))
            {
                showErrorMessageBox("CSVファイルの読込に失敗しました。");
                return;
            }
            // ヘッダー行を取り除く処理
            nodeList.RemoveAt(0);
            await movePodRotate(param, nodeList, token);

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
                checkBoxIsStop.Text = "AGV再開";
                checkBoxIsStop.BackColor = Color.Green;
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

        private async void btnMoveAGV_Click(object sender, EventArgs e)
        {
            updateParam();
            if (isHetuUsed())
            {
                return;
            }
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var nodeID = param.NodeID;
            var robotID = param.RobotID;

            showInfoMessageBox($"AGV移動指示を作成しました。{Environment.NewLine}AGV:{robotID},移動先:{nodeID}");
            await moveRobot(serverIP, warehouseID, robotID, nodeID);
        }

        private void numRepeatCount_ValueChanged(object sender, EventArgs e)
        {
            param.RepeatCount = (int)numRepeatCount.Value;
        }


        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            updateParam();
            fileIO.SaveSetting(settingPath, param);
            showInfoMessageBox($"設定ファイルを保存しました。{Environment.NewLine}保存先:{Path.GetFullPath(settingPath)}");
        }

        #endregion Event

        #region Task

        private async Task movePod(string serverIP, string warehouseID, string podID
            , string nodeID, string robotID, int turnMode, int unload, CancellationToken cancelToken)
        {
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }
            try
            {
                var moveTask = new Task(() =>
                   {
                       var movePodParam = new MovePodParam(
                               robotID,
                               podID,
                               DestinationModes.StorageID,
                               nodeID,
                               isEndWait: true,
                               turnMode: turnMode,
                               unload: unload
                               );

                       switch (listBoxDirection.SelectedIndex)
                       {
                           case 0:
                               movePodParam.RobotFace = Direction.North;
                               break;
                           case 1:
                               movePodParam.RobotFace = Direction.East;
                               break;
                           case 2:
                               movePodParam.RobotFace = Direction.South;
                               break;
                           case 3:
                               movePodParam.RobotFace = Direction.West;
                               break;
                           case 4:
                               movePodParam.RobotFace = Direction.NoSelect;
                               break;
                       }

                       var movePodResult = (MovePodReturnMessage)factory.Create(movePodParam).DoAction();


                       string logMessage = $"ロボットID {robotID},棚 {podID},移動先 {nodeID}";
                       logger.Info(logMessage);
                       logger.Info(movePodResult.ReturnMsg);
                       this.Invoke((MethodInvoker)(() =>
                       {
                           lblCurrentLineProcess.Text = logMessage;
                       }));
                   }, cancelToken);
                moveTask.Start();
                await moveTask.ConfigureAwait(true);
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private async Task movePodRotate(ParamSettings param, List<string> allLines
            , CancellationToken cancelToken)
        {

            int nowCount = 1;

            do
            {
                bool isInfinityLoop = param.RepeatCount == 0;

                if (!isInfinityLoop)
                    prgRepeartCount.Value = (int)((double)nowCount / (double)param.RepeatCount * 100);


                lblProgress.Text = $"繰り返し回数 {nowCount}/{param.RepeatCount}";
                logger.Info(string.Format("{0}回目開始", nowCount));
                for (var rowCount = 0; rowCount < allLines.Count; rowCount++)
                {
                    lblRunLineIndex.Text = $"実行行数 {rowCount + 1}/{allLines.Count}";
                    var splitLine = allLines[rowCount].Split(',').ToList();

                    if (!int.TryParse(splitLine[turnModeIndex], out var turnMode))
                    {
                        logger.Error("turnModeが読み込めません：{0}", splitLine[turnModeIndex]);
                        continue;
                    }
                    if (!int.TryParse(splitLine[unloadModeIndex], out var unload))
                    {
                        logger.Error("unloadが読み込めません：{0}", splitLine[unloadModeIndex]);
                        continue;
                    }

                    var nodeID = splitLine[nodeIDIndex];

                    await movePod(param.ServerIP, param.WarehouseID, param.PodID
                        , nodeID, param.RobotID, turnMode, unload, cancelToken);
                }


                if (!isInfinityLoop)
                    nowCount++;
            }
            while (nowCount != param.RepeatCount && !cancelToken.IsCancellationRequested);


            lblCurrentLineProcess.Text = "連続動作完了";
            showInfoMessageBox("連続動作完了");

        }
        private async Task moveRobot(string serverIP, string warehouseID, string robotID, string nodeID)
        {
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }

            try
            {
                var moveTask = new Task(() =>
                {
                    var moveRobotResult = new MoveRobotReturnMessage();

                    var unsetOwnerResult = factory.Create(new UnsetOwnerParam(robotID)).DoAction();

                    if (unsetOwnerResult.ReturnMsg != "succ")
                    {
                        showUnsetOwnerErrorDialog(unsetOwnerResult.ReturnMsg);
                        logger.Error($"{Messages.UnsetOwnerError}:AGV{param.RobotID}{unsetOwnerResult.ReturnMsg}");
                        //return;
                    }
                    logger.Info($"AGV{robotID}に対してUnsetOwnerが成功しました。");

                    var setOwnerResult = factory.Create(new SetOwnerParam(robotID)).DoAction();

                    if (setOwnerResult.ReturnMsg != "succ")
                    {
                        showUnsetOwnerErrorDialog(unsetOwnerResult.ReturnMsg);
                        logger.Error($"{Messages.SetOwnerError}:AGV{param.RobotID}{setOwnerResult.ReturnMsg}");
                        return;
                    }
                    logger.Info($"AGV{robotID}に対してSetOwnerが成功しました。");

                    var moveRobotParam = new MoveRobotParam(
                            robotID,
                            DestinationModes.NodeID,
                            nodeID,
                            isEndWait: false,
                            ownerRegist: false
                            );

                    switch (listBoxDirection.SelectedIndex)
                    {
                        case 0:
                            moveRobotParam.RobotFace = Direction.North;
                            break;
                        case 1:
                            moveRobotParam.RobotFace = Direction.East;
                            break;
                        case 2:
                            moveRobotParam.RobotFace = Direction.South;
                            break;
                        case 3:
                            moveRobotParam.RobotFace = Direction.West;
                            break;
                        case 4:
                            moveRobotParam.RobotFace = Direction.NoSelect;
                            break;
                    }
                    moveRobotResult = (MoveRobotReturnMessage)factory.Create(moveRobotParam).DoAction();

                    string logMessage = $"ロボットID {robotID},移動先 {nodeID}";
                    logger.Info(logMessage);
                    logger.Info(moveRobotResult.ReturnMsg);

                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblCurrentLineProcess.Text = logMessage;
                    }));
                });
                moveTask.Start();
                await moveTask.ConfigureAwait(true);
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
                showMoveRobotErrorDialog(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                showMoveRobotErrorDialog(ex.Message);
            }
        }

        #endregion Task

        #region Method
        private void showAddPodErrorDialog(string errorMessage)
        {
            showErrorMessageBox($"棚作成に失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showRemovePodErrorDialog(string errorMessage)
        {
            showErrorMessageBox($"棚削除に失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showMoveRobotErrorDialog(string errorMessage)
        {
            showErrorMessageBox($"AGVの移動に失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showSetOwnerErrorDialog(string errorMessage)
        {
            showErrorMessageBox($"SetOwnerに失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showUnsetOwnerErrorDialog(string errorMessage)
        {
            showErrorMessageBox($"UnsetOwnerに失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private bool tryLoadSetting()
        {
            var result = fileIO.TryLoadSetting(settingPath, out param);
            var message = string.Empty;
            if (!result)
            {
                message =
                    $"設定ファイルの読込に失敗しました。{Path.GetFullPath(settingPath)}";
                logger.Error(message);
                showErrorMessageBox(message);
                return result;
            }
            return result;
        }
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
            textBoxStationListPath.Text = param.StationListPath;
            numRepeatCount.Value = param.RepeatCount;
            checkBoxSynchroTurn.Checked = param.TurnMode == ON;
            checkBoxUnload.Checked = param.Unload == ON;
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
            param.StationListPath = textBoxStationListPath.Text;
            param.RepeatCount = (int)numRepeatCount.Value;
            param.TurnMode = checkBoxSynchroTurn.Checked ? ON : OFF;
            param.Unload = checkBoxUnload.Checked ? ON : OFF;
        }
        #endregion Method

        private void btnLoadSetting_Click(object sender, EventArgs e)
        {
            if (!tryLoadSetting())
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

        private void btnSelectCSV_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "CSVファイルを選択",
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "CSVファイル|*.csv"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxStationListPath.Text = openFileDialog.FileName;
                logger.Info(openFileDialog.FileName);
            }
            else
            {
                logger.Info("CSVファイルの選択がキャンセルされました。");
            }
            openFileDialog.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
            logger.Info("連続動作キャンセルをクリックしました。");
        }
        /// <summary>
        /// Hetuで占有されていないかを調べる
        /// </summary>
        /// <returns>Hetuで占有している場合はtrue,Hetu以外の場合はfalse</returns>
        private bool isHetuUsed()
        {
            var clientCode = "biz_test";

            var factory = new CommandFactory(param.ServerIP, param.WarehouseID, clientCode);
            if (!factory.IsConnectedTESServer())
                logger.Error(Messages.NotConnectMsg);

            var getRobotRetMsg = (GetRobotListFromDBReturnMessage)factory.Create(new GetRobotListFromDBParam()).DoAction();
            
            var rb=getRobotRetMsg.Data.RobotList.Where(x => x.RobotID == param.RobotID).FirstOrDefault();
            if (rb == null)
            {
                var message = $"AGV[{param.RobotID}]が存在しません。";
                logger.Error(message);
                showErrorMessageBox(message);
                return true;
            }
            
            if (rb.Owner == "SUPER")
            {
                var message = $"AGV[{rb.RobotID}]がHetuで使用されています。占有をキャンセルしてください。状態【{rb.TaskType}】";
                logger.Error(message);
                showErrorMessageBox(message);
                return true;
            }

            return false;
        }
        /// <summary>
        /// エラーメッセージを表示する
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        private void showErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// エラーではないメッセージを表示する
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        private void showInfoMessageBox(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// サンプルCSVファイルの場所を開く
        /// </summary>
        private void openSampleCSVDir()
        {
            /// <summary>
            /// サンプルCSVファイルのパス
            /// </summary>
            const string sampleCSVPath = @"CSVSample\サンプル.csv";
            
            System.Diagnostics.Process.Start("EXPLORER.EXE", $"/select,{sampleCSVPath}");
            textBoxStationListPath.Text = sampleCSVPath;
            param.StationListPath = sampleCSVPath;
        }

        private void btnSaveSampleCSV_Click(object sender, EventArgs e)
        {
            openSampleCSVDir();            
        }
        private void getTaskDetailParam(string taskID)
        {
            var clientCode = "biz_test";
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID, clientCode);
            if (!factory.IsConnectedTESServer())
                logger.Error(Messages.NotConnectMsg);

            var task = (GetTaskDetailReturnMessage)factory.Create(new GetTaskDetailParam(taskID)).DoAction();
            logger.Info($"{task.ToString()}");

            var detail = task.Data.Detail;
            var message = string.Empty;
            message = $"タスクID：{detail.TaskID}　状態：{detail.Status}　失敗理由：{detail.ErrorReason}";
            showInfoMessageBox(message);
        }

        private void btnGetTaskDetail_Click(object sender, EventArgs e)
        {
            var taskID = textBoxTaskID.Text;
            getTaskDetailParam(taskID);
        }

        private void unsetOwner()
        {
            var robotID = param.RobotID;
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);

            var unsetOwnerResult = factory.Create(new UnsetOwnerParam(robotID)).DoAction();

            if (unsetOwnerResult.ReturnMsg != "succ")
            {
                showUnsetOwnerErrorDialog(unsetOwnerResult.ReturnMsg);
                logger.Error($"{Messages.UnsetOwnerError}:AGV{param.RobotID}{unsetOwnerResult.ReturnMsg}");
                //return;
            }
            logger.Info($"AGV{robotID}に対してUnsetOwnerが成功しました。");
        }

        private void btnUnSetOwner_Click(object sender, EventArgs e)
        {
            unsetOwner();
        }

        private void btnShowOwner_Click(object sender, EventArgs e)
        {
            updateParam();

            var clientCode = "biz_test";
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID, clientCode);
            if (!factory.IsConnectedTESServer())
                logger.Error(Messages.NotConnectMsg);

            var getRobotRetMsg = (GetRobotListFromDBReturnMessage)factory.Create(new GetRobotListFromDBParam()).DoAction();

            var rb = getRobotRetMsg.Data.RobotList.Where(x => x.RobotID == param.RobotID).FirstOrDefault();
            var message = string.Empty;
            if (rb == null)
            {
                message = $"AGV[{param.RobotID}]が存在しません。";
                logger.Error(message);
                showErrorMessageBox(message);
                return;
            }
            message = $"AGV{param.RobotID}の所有者は{rb.Owner}です。";
            logger.Info(message);
            showInfoMessageBox(message);
        }

        private double getDirection()
        {
            var direction = Direction.NoSelect;
            switch (listBoxDirection.SelectedIndex)
            {
                case 0:
                    direction = Direction.North;
                    break;
                case 1:
                    direction = Direction.East;
                    break;
                case 2:
                    direction = Direction.South;
                    break;
                case 3:
                    direction = Direction.West;
                    break;
                case 4:
                    direction = Direction.NoSelect;
                    break;
            }

            return direction;
        }

        private void btnOpenParamSettings_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settingPath);

            var openFileDialog = new OpenFileDialog
            {
                Title = "設定ファイルを選択",
                InitialDirectory =Path.GetDirectoryName(settingPath),
                Filter = "XMLファイル|*.xml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                settingPath = openFileDialog.FileName;
                logger.Info(openFileDialog.FileName);
            }
            else
            {
                logger.Info("設定ファイルの選択がキャンセルされました。");
            }
            openFileDialog.Dispose();
        }
    }
}
