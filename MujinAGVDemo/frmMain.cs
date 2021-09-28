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
        const string settingPath = "ParamSetting.xml";
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
                MessageBox.Show($"棚作成に{resultMessage}しました。{Environment.NewLine}棚 {podID},作成位置 {nodeID}");
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
                MessageBox.Show($"棚削除に{resultMessage}しました。{Environment.NewLine}棚 {podID}");
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
            if (ownerUserDetection())
            {
                return;
            }
            var token = cancelTokenSource.Token;
            MessageBox.Show($"棚搬送指示を作成しました。" +
                $"{Environment.NewLine}AGV:{param.RobotID},移動先:{param.NodeID},棚:{param.NodeID}");

            await movePod(param.ServerIP, param.WarehouseID, param.PodID
                , param.NodeID, param.RobotID, param.TurnMode, param.Unload, token);
        }

        private async void btnRotationMove_Click(object sender, EventArgs e)
        {
            updateParam();
            if (ownerUserDetection())
            {
                return;
            }
            cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            var stationListPath = param.StationListPath;

            if (!fileIO.TryGetAllLines(stationListPath, out var nodeList))
            {
                MessageBox.Show("CSVファイルの読込に失敗しました。");
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
            if (isStop == false)
            {
                factory.Create(new PauseRobotParam(robotID)).DoAction();
                checkBoxIsStop.Text = "AGV再開";
                checkBoxIsStop.BackColor = Color.Green;
            }
            else
            {
                checkBoxIsStop.Text = "AGV停止";
                checkBoxIsStop.BackColor = Color.Red;
                factory.Create(new ResumeRobotParam(robotID)).DoAction();
            }
        }

        private async void btnMoveAGV_Click(object sender, EventArgs e)
        {
            updateParam();
            if (ownerUserDetection())
            {
                return;
            }
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var nodeID = param.NodeID;
            var robotID = param.RobotID;

            MessageBox.Show($"AGV移動指示を作成しました。" +
                $"{Environment.NewLine}AGV:{robotID},移動先:{nodeID}");
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
            MessageBox.Show($"設定ファイルを保存しました。" +
                $"{Environment.NewLine}保存先:{Path.GetFullPath(settingPath)}");
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
                       var movePodResult = (MovePodReturnMessage)factory.Create(new MovePodParam(
                               robotID,
                               podID,
                               DestinationModes.StorageID,
                               nodeID,
                               isEndWait: true,
                               turnMode: turnMode,
                               unload: unload
                               )).DoAction();


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
            MessageBox.Show("連続動作完了");

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
                                        
                    if (ownerUserDetection())
                    {
                        return;
                    }

                    //var unsetOwnerResult = factory.Create(new UnsetOwnerParam(robotID)).DoAction();
                    
                    //if (unsetOwnerResult.ReturnMsg != "succ")
                    //{
                    //    showUnsetOwnerErrorDialog(unsetOwnerResult.ReturnMsg);
                    //    logger.Error($"AGV{robotID}に対してUnsetOwnerが失敗しました。{unsetOwnerResult.ReturnMsg}");
                    //    //return;
                    //}
                    //logger.Info($"AGV{robotID}に対してUnsetOwnerが成功しました。");

                    //var setOwnerResult = factory.Create(new SetOwnerParam(robotID)).DoAction();
                    
                    //if (setOwnerResult.ReturnMsg != "succ")
                    //{
                    //    showUnsetOwnerErrorDialog(unsetOwnerResult.ReturnMsg);
                    //    logger.Error($"AGV{robotID}に対してSetOwnerが失敗しました。{setOwnerResult.ReturnMsg}");
                    //    return;
                    //}
                    //logger.Info($"AGV{robotID}に対してSetOwnerが成功しました。");

                    moveRobotResult = (MoveRobotReturnMessage)(factory.Create(new MoveRobotParam(
                        robotID,
                        DestinationModes.NodeID,
                        nodeID,
                        isEndWait: false,
                        ownerRegist: false
                        // robotFace: Direction.North
                        )).DoAction());
                    var waitResult = factory.Create(new WaitEndTaskParam(moveRobotResult.Data.TaskID, watchRobotID: robotID)).DoAction();
                    if (waitResult.ReturnCode != 0)
                    {
                        logger.Info("タスクキャンセル＆ぬける。");
                        factory.Create(new CancelTaskParam(moveRobotResult.Data.TaskID)).DoAction();
                    }

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
            MessageBox.Show($"棚作成に失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showRemovePodErrorDialog(string errorMessage)
        {
            MessageBox.Show($"棚削除に失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showMoveRobotErrorDialog(string errorMessage)
        {
            MessageBox.Show($"AGVの移動に失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showSetOwnerErrorDialog(string errorMessage)
        {
            MessageBox.Show($"SetOwnerに失敗しました。{Environment.NewLine}{errorMessage}");
        }
        private void showUnsetOwnerErrorDialog(string errorMessage)
        {
            MessageBox.Show($"UnsetOwnerに失敗しました。{Environment.NewLine}{errorMessage}");
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
                btnLoadSetting.BackColor = Color.Red;
                MessageBox.Show(message);
                return result;
            }

            message =
                $"設定ファイルの読込に成功しました。{Path.GetFullPath(settingPath)}";
            logger.Info(message);
            btnLoadSetting.BackColor = Color.Green;
            MessageBox.Show(message);
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
                return;
            }
            updateControl();
        }

        private void btnSelectCSV_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "CSVファイルを選択",
                InitialDirectory = Environment.CurrentDirectory
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
        /// AGVのオーナーを調べる
        /// </summary>
        /// <returns>Hetuで占有している場合はtrue,Hetu以外の場合はfalse</returns>
        private bool ownerUserDetection()
        {
            var clientCode = "biz_test";

            var factory = new CommandFactory(param.ServerIP, param.WarehouseID, clientCode);
            if (!factory.IsConnectedTESServer())
                logger.Error(Messages.NotConnectMsg);

            var getRobotRetMsg = (GetRobotListFromDBReturnMessage)(factory.Create(new GetRobotListFromDBParam()).DoAction());
            var anyUsed = false;
            getRobotRetMsg.Data.RobotList.ForEach(rb =>
            {
                if (rb.Owner == "SUPER")
                {
                    var message = $"AGV[{rb.RobotID}]がHetuで使用されています。占有をキャンセルしてください。状態【{rb.TaskType}】";
                    logger.Error(message);
                    MessageBox.Show(message);
                    anyUsed = true;
                }
            });
            return anyUsed;
        }
    }
}
