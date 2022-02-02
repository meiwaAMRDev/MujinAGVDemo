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
        #region Constructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Const

        /// <summary>
        /// ログディレクトリのパス
        /// </summary>
        private const string logDirPath = @"logs";

        /// <summary>
        /// CSVファイルの中のnodeIDのインデックス
        /// </summary>
        private const int nodeIDIndex = 0;
        /// <summary>
        /// CSVファイルの中のturnModeのインデックス
        /// </summary>
        private const int turnModeIndex = 1;
        /// <summary>
        /// CSVファイルの中のunloadのインデックス
        /// </summary>
        private const int unloadModeIndex = 2;
        private const int ON = 1;
        private const int OFF = 0;
        /// <summary>
        /// 設定ファイルのデフォルトパス
        /// </summary>
        const string defaultSettingPath = @"Setting/ParamSetting.xml";

        #endregion Const

        #region Private Parameter

        /// <summary>
        /// AGVの方向を表すインデックス
        /// </summary>
        private int directionIndex = 4;
        /// <summary>
        /// 設定ファイルのパス
        /// </summary>
        private string settingPath = defaultSettingPath;
        private ParamSettings param;
        private bool isStop = false;
        private FileIO fileIO = new FileIO();
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private Logger logger = LogManager.GetLogger("ProgramLogger");
        /// <summary>AGV名と電池残量を持つラベル</summary>
        private List<ToolStripLabel> agvIdBatteryLevelList = new List<ToolStripLabel>();

        #endregion Private Parameter

        #region Deligate

        delegate void ChangeDgvDelegate();

        #endregion Deligate

        #region Event

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"AGVデモソフト {Application.ProductVersion}";
            if (!tryLoadSetting())
            {
                return;
            }
            try
            {
                btnLoadSetting.BackColor = Color.LightGray;
                updateControl();
                //AGVの向きを指定しない
                listBoxDirection.SelectedIndex = 4;
                //棚の向きを指定しない
                listBoxPodDirection.SelectedIndex = 4;
                directionIndex = listBoxDirection.SelectedIndex;
                checkBoxIsStop.Checked = isStop;
                textBoxTaskID.Text = string.Empty;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
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
            unsetOwner();
        }

        private async void btnRotationMove_Click(object sender, EventArgs e)
        {
            var stationListPath = param.StationListPath;
            var paramSetting = this.param;
            var robotID = param.RobotID;
            var podID = param.PodID;
            updateParam();
            await movePodRotate(stationListPath, paramSetting, robotID, podID);
            unsetOwner(robotID);
        }

        private async Task movePodRotate(string stationListPath, ParamSettings paramSetting, string robotID, string podID)
        {
            if (isHetuUsed())
            {
                return;
            }
            cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            if (!fileIO.TryGetAllLines(stationListPath, out var orderList))
            {
                showErrorMessageBox("CSVファイルの読込に失敗しました。");
                return;
            }
            // ヘッダー行を取り除く処理
            orderList.RemoveAt(0);
            await movePodRotate(paramSetting, orderList, token, robotID, podID);
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

            var token = cancelTokenSource.Token;
            showInfoMessageBox($"AGV移動指示を作成しました。{Environment.NewLine}AGV:{robotID},移動先:{nodeID}");
            await moveRobot(serverIP, warehouseID, robotID, nodeID, token);
            unsetOwner();
        }

        private void numRepeatCount_ValueChanged(object sender, EventArgs e)
        {
            param.RepeatCount = (int)numRepeatCount.Value;
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
            var robotList = getRobotRetMsg.Data.RobotList.ToList();
            var messageList = new List<string>();

            var rb = getRobotRetMsg.Data.RobotList.Where(x => x.RobotID == param.RobotID).FirstOrDefault();
            //foreach(var rb in robotList)
            //{
            var message = string.Empty;
            if (rb == null)
            {
                message = $"AGV[{param.RobotID}]が存在しません。";
                logger.Error(message);
                showErrorMessageBox(message);
                return;
            }
            message = $"AGV{rb.RobotID}の所有者は{rb.Owner}です。";
            logger.Info(message);
            messageList.Add(message);
            showInfoMessageBox(message);
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

                if (tryLoadSetting())
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

        private void btnShowPodDetail_Click(object sender, EventArgs e)
        {
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            try
            {
                var getPodListAns = (GetPodListReturnMessage)factory.Create(new GetPodListParam()).DoAction();

                var podList = getPodListAns.Data.PodList.Where(x => x.RobotID == param.RobotID).ToList();
                logger.Info($"棚の位置を表示します");
                foreach (var pod in podList)
                {
                    var podMessage = $"podID[{pod.PodID}]positionType[{pod.PositionType}]strageID[{pod.StorageID}]robotID[{pod.RobotID}]";
                    logger.Info(podMessage);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void mnuOpenLogDir_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(logDirPath))
            {
                showErrorMessageBox(($"{Path.GetFullPath(logDirPath)}が見つかりません。"));
                return;
            }
            System.Diagnostics.Process.Start("EXPLORER.EXE", logDirPath);
        }

        private void btnSetOwner_Click(object sender, EventArgs e)
        {
            setOwner();
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            var zoneID = textBoxChargeAreaID.Text;
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            var chargeReturnMessage = (ChargeRobotReturnMessage)factory.Create(new ChargeRobotParam(param.RobotID, zoneID)).DoAction();
            logger.Info(chargeReturnMessage.ReturnMsg);
        }

        private void btnLiftDown_Click(object sender, EventArgs e)
        {
            updateParam();
            var podDir = listBoxPodDirection.SelectedIndex;
            var (isSuccess, messages) = Command.MapCommands.LiftDownRobot(param.ServerIP, param.WarehouseID, param.RobotID, podDir);

            if (!isSuccess)
            {
                showErrorMessageBox(messages);
            }
            else
            {
                showInfoMessageBox(messages);
            }
        }

        private void btnLiftUp_Click(object sender, EventArgs e)
        {
            updateParam();
            var (isSuccess, messages) = Command.MapCommands.LiftUpRobot(param.ServerIP, param.WarehouseID, param.RobotID);

            if (!isSuccess)
            {
                showErrorMessageBox(messages);
            }
            else
            {
                showInfoMessageBox(messages);
            }
        }

        private void btnAddPod_Click(object sender, EventArgs e)
        {
            addPod();
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            removePod();
        }

        private void btnShowAGVPosition_Click(object sender, EventArgs e)
        {
            try
            {
                var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
                var getRobotListAns = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();
                var robotList = getRobotListAns.Data.RobotList;

                var textList = new List<string>();
                //tableReset();
                robotList.ForEach(rb =>
                {
                    var text = $"AGV[{rb.RobotID}] Node[{rb.CurNodeID}] X[{rb.CurX}] Y[{rb.CurY}] Owner[{rb.Owner}] Status[{rb.WorkStatus}] TaskID[{rb.TaskID}]";
                    logger.Info(text);
                    textList.Add(text);

                    //table.Rows.Add(rb.RobotID, rb.WorkStatus, rb.Owner, rb.ErrorState, $"{rb.UcPower}", rb.CurNodeID, rb.CurX, rb.CurY, rb.TaskID);
                });
                var (isSuccess, table) = Command.MapCommands.GetAgvDetailTable(param.ServerIP, param.WarehouseID);
                if (isSuccess)
                    dgvAGVDetail.DataSource = table;
                else
                {
                    showErrorMessageBox("テーブルの取得に失敗しました。");
                }
                    
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                showErrorMessageBox(ex.Message);
            }
        }

        private void btnSetPodPos_Click(object sender, EventArgs e)
        {
            updateParam();
            var (isSuccess, message) = Command.MapCommands.SetPodPosition(param.ServerIP, param.WarehouseID, param.PodID, param.NodeID);

            showMessageBox(isSuccess, message);
        }

        private async void tmrAGVInfoUpdate_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Invoke(new ChangeDgvDelegate(changeDgv));
            });
        }

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
                param.StationListPath = openFileDialog.FileName;
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
        private void btnSaveSampleCSV_Click(object sender, EventArgs e)
        {
            openSampleCSVDir();
        }
        private void btnGetTaskDetail_Click(object sender, EventArgs e)
        {
            var taskID = textBoxTaskID.Text;
            showTaskDetailParam(taskID);
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrAGVInfoUpdate.Stop();
        }

        private void dgvAGVDetail_DataSourceChanged(object sender, EventArgs e)
        {
            lblUpdateTime.Text = $"更新日時:[{DateTime.Now}]";
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
        private void btnRemovePodAll_Click(object sender, EventArgs e)
        {
            updateParam();
            var (isSuccess, messages) = Command.MapCommands.RemoveAllShelfs(param.ServerIP, param.WarehouseID);
            var message = new StringBuilder();
            messages.ToList().ForEach(x => message.Append(x));
            showMessageBox(isSuccess, message.ToString());
        }

        private void btnLiftDownAll_Click(object sender, EventArgs e)
        {
            updateParam();
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            var getRobotListAns = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();

            getRobotListAns.Data.RobotList.ForEach(robot =>
            {
                var (isSuccess, messages) = Command.MapCommands.LiftDownRobot(factory, robot.RobotID);
                showMessageBox(isSuccess, messages);
            });
            //showMessageBox(true, "棚を全て下ろしました。");
        }

        private void btnUnsetOwnerAll_Click(object sender, EventArgs e)
        {
            updateParam();
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            var getRobotListAns = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();

            getRobotListAns.Data.RobotList.ForEach(robot =>
            {
                var (isSuccess, messages) = Command.MapCommands.UnsetOwner(factory, robot.RobotID);
                showMessageBox(isSuccess, messages);
            });
            //showMessageBox(true, "全てのAGVの所有者を解除しました。");
        }
        #endregion Event

        #region Task

        private async Task movePod(string serverIP, string warehouseID, string podID
            , string nodeID, string robotID, int turnMode, int unload, CancellationToken cancelToken)
        {
            if (cancelToken.IsCancellationRequested)
                return;
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }
            try
            {
                //棚を下ろす際はシンクロターンできないようにする
                if (unload == ON)
                {
                    turnMode = OFF;
                }
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

                    //switch (listBoxDirection.SelectedIndex)
                    switch (directionIndex)
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


                    var logMessage = $"ロボットID {robotID},棚 {podID},移動先 {nodeID}";
                    logger.Info(logMessage);
                    logger.Info($"msg[{movePodResult.ReturnMsg}]returnCode[{movePodResult.ReturnCode}]");

                    //logger.Info(movePodResult.ReturnMsg);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblCurrentLineProcess.Text = logMessage;
                    }));
                }, cancelToken);
                if (cancelToken.IsCancellationRequested)
                    return;

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
            var robotID = param.RobotID;
            var podID = param.PodID;
            await movePodRotate(param, allLines, cancelToken, robotID, podID);
        }

        private async Task movePodRotate(ParamSettings param, List<string> allLines
            , CancellationToken cancelToken, string robotID, string podID)
        {
            int nowCount = 1;
            bool isInfinityLoop = param.RepeatCount == 0;
            bool isRunning =
                //無限ループモードまたは実行回数が繰り返し回数未満
                (isInfinityLoop || nowCount < param.RepeatCount)
                //かつキャンセルされていない
                && !cancelToken.IsCancellationRequested;
            do
            {
                if (cancelToken.IsCancellationRequested)
                {
                    lblCurrentLineProcess.Text = "連続動作完了";
                    showInfoMessageBox("連続動作完了");
                    return;
                }
                if (!isInfinityLoop)
                {

                    var percent = (int)((double)nowCount / (double)param.RepeatCount * 100);
                    prgRepeartCount.Value = percent > 100 ? 100 : percent;
                }

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
                    //棚IDが空白の場合、棚なしAGVのみで移動する
                    if (podID == string.Empty)
                    {
                        await moveRobot(param.ServerIP, param.WarehouseID, robotID, nodeID, cancelToken);
                    }
                    else
                    {
                        await movePod(param.ServerIP, param.WarehouseID, podID
                        , nodeID, robotID, turnMode, unload, cancelToken);
                    }

                }


                if (!isInfinityLoop)
                {
                    nowCount++;
                    if (nowCount > param.RepeatCount)
                        isRunning = false;
                }
            }
            //while (nowCount != param.RepeatCount && !cancelToken.IsCancellationRequested);
            while (isRunning);

            lblCurrentLineProcess.Text = "連続動作完了";
            showInfoMessageBox("連続動作完了");

        }
        private async Task moveRobot(string serverIP, string warehouseID, string robotID, string nodeID, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                logger.Info("AGV移動がキャンセルされました。");
                return;
            }

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

                    unsetOwner(robotID);

                    var setOwnerResult = factory.Create(new SetOwnerParam(robotID)).DoAction();

                    if (setOwnerResult.ReturnMsg != "succ")
                    {
                        showSetOwnerErrorDialog(setOwnerResult.ReturnMsg);
                        logger.Error($"{Messages.SetOwnerError}:AGV[{param.RobotID}][{setOwnerResult.ReturnMsg}]");
                        return;
                    }
                    logger.Info($"AGV[{robotID}]に対してSetOwnerが成功しました。");

                    var moveRobotParam = new MoveRobotParam(
                            robotID,
                            DestinationModes.NodeID,
                            nodeID,
                            isEndWait: true,
                            ownerRegist: false
                            );

                    //switch (listBoxDirection.SelectedIndex)
                    switch (directionIndex)
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
                    var moveRobotResult = (MoveRobotReturnMessage)factory.Create(moveRobotParam).DoAction();

                    string logMessage = $"ロボットID {robotID},移動先 {nodeID}";
                    logger.Info(logMessage);
                    logger.Info(moveRobotResult.ReturnMsg);

                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblCurrentLineProcess.Text = logMessage;
                    }));
                }, token);
                if (token.IsCancellationRequested)
                {
                    return;
                }
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
                showRemovePodErrorDialog(Messages.NotConnectMsg);
                return;
            }
            logger.Info($"棚[{podID}]を削除します。IP[{serverIP}]warehouseID[{warehouseID}]");
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
        /// <summary>
        /// 設定ファイルを読み込みます
        /// </summary>
        /// <returns>読込に成功したらtrue</returns>
        private bool tryLoadSetting()
        {
            var result = fileIO.TryLoadSetting(settingPath, out param);
            if (!result)
            {
                var message =
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

            checkBoxUnload.Checked = param.Unload == ON;
            checkBoxSynchroTurn.Checked = param.TurnMode == ON;
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
        /// <summary>
        /// Hetuで占有されていないかを調べる
        /// </summary>
        /// <returns>Hetuで占有している場合はtrue,Hetu以外の場合はfalse</returns>
        private bool isHetuUsed()
        {
            var clientCode = "biz_test";

            var factory = new CommandFactory(param.ServerIP, param.WarehouseID, clientCode);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error($"{Messages.NotConnectMsg}[{param.ServerIP}][{param.WarehouseID}]");
            }


            var getRobotRetMsg = (GetRobotListFromDBReturnMessage)factory.Create(new GetRobotListFromDBParam()).DoAction();

            var rb = getRobotRetMsg.Data.RobotList.Where(x => x.RobotID == param.RobotID).FirstOrDefault();
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
            logger.Error(message);
        }
        /// <summary>
        /// エラーではないメッセージを表示する
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        private void showInfoMessageBox(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //ログ表示の際に改行文字を空白に置き換える
            logger.Info(message.Replace(Environment.NewLine, string.Empty));
        }
        private void showMessageBox(bool isSuccess, string message)
        {
            if (!isSuccess)
            {
                showErrorMessageBox(message);
            }
            else
            {
                showInfoMessageBox(message);
            }
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

        /// <summary>
        /// タスク詳細を表示します
        /// </summary>
        /// <param name="taskID">タスクID</param>
        private void showTaskDetailParam(string taskID)
        {
            var clientCode = "biz_test";
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID, clientCode);
            if (!factory.IsConnectedTESServer())
                logger.Error(Messages.NotConnectMsg);

            var task = (GetTaskDetailReturnMessage)factory.Create(new GetTaskDetailParam(taskID)).DoAction();
            logger.Info($"{task.ToString()}");

            var detail = task.Data.Detail;
            var message = $"タスクID：{detail.TaskID}　状態：{detail.Status}　失敗理由：{detail.ErrorReason} エラーコード：{detail.ErrorCode}";
            showInfoMessageBox(message);
        }
        /// <summary>
        /// AGVの占有状態を解除します
        /// </summary>
        /// <param name="robotID">AGVの号機</param>
        private void unsetOwner(string robotID)
        {
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);

            var robotList = (GetRobotListFromDBReturnMessage)factory.Create(new GetRobotListFromDBParam()).DoAction();
            var rb = robotList.Data.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
            if (rb == null)
            {
                logger.Info($"AGV[{robotID}]が見つからないためunsetOwnerは行いません。");
                return;
            }
            if (rb.Owner == "TES")
            {
                logger.Info($"AGV[{robotID}]の所有者はTESのためunsetOwnerは行いません。");
                return;
            }

            var unsetOwnerResult = factory.Create(new UnsetOwnerParam(robotID)).DoAction();

            if (unsetOwnerResult.ReturnMsg != "succ")
            {
                showUnsetOwnerErrorDialog(unsetOwnerResult.ReturnMsg);
                logger.Error($"{Messages.UnsetOwnerError}:AGV{param.RobotID}{unsetOwnerResult.ReturnMsg}");
                //return;
            }
            logger.Info($"AGV[{robotID}]に対してUnsetOwnerが成功しました。");
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
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);

            var setOwnerResult = factory.Create(new SetOwnerParam(robotID)).DoAction();

            if (setOwnerResult.ReturnMsg != "succ")
            {
                showUnsetOwnerErrorDialog(setOwnerResult.ReturnMsg);
                logger.Error($"{Messages.SetOwnerError}:AGV{param.RobotID}{setOwnerResult.ReturnMsg}");
                //return;
            }
            logger.Info($"AGV[{robotID}]に対してsetOwnerが成功しました。");
        }

        /// <summary>
        /// AGV情報タブのデータを更新します
        /// </summary>
        private void changeDgv()
        {
            var (isSuccess, table) = Command.MapCommands.GetAgvDetailTable(param.ServerIP, param.WarehouseID);
            if (isSuccess)
                dgvAGVDetail.DataSource = table;
            else
            {
                checkBoxTimerRun.Checked = false;
                showErrorMessageBox("AGV情報の取得に失敗しました。監視を停止します。");
            }
                
        }
        #endregion Method

        
    }
}
