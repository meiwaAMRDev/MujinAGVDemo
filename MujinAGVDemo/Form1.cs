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
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;

namespace MujinAGVDemo
{
    public partial class Form1 : Form
    {
        #region Property

        ParamSettings param;
        bool isStop = false;
        string settingPath = "ParamSetting.xml";

        #endregion Property

        public Form1()
        {
            InitializeComponent();
        }

        #region Event

        private void Form1_Load(object sender, EventArgs e)
        {
            //param = new ParamSettings();
            if (!TryLoadSetting())
            {
                return;
            }
            btnLoadSetting.BackColor = Color.LightGray;
            updateControl();
        }



        private void btnAddPod_Click(object sender, EventArgs e)
        {
            var serverIP =
                param.ServerIP;
            var warehouseID =
                param.WarehouseID;
            var layoutID =
                param.LayoutID;
            var podID =
                param.PodID;
            var nodeID =
                param.NodeID;

            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                Setting.Logger.Error(Setting.NotConnectMsg);
                MessageBox.Show($"棚作成に失敗しました。" +
                    $"{Environment.NewLine}{Setting.NotConnectMsg}");
                return;
            }
            try
            {
                var addPodResult = factory.Create(new AddPodParam(podID, nodeID, layoutID)).DoAction();
                string logMessage = $"棚 {podID},作成位置 {nodeID}";
                Setting.Logger.Info(logMessage);
                Setting.Logger.Info(addPodResult.ReturnMsg);
                this.Invoke((MethodInvoker)(() =>
                {
                    lblCurrentLineProcess.Text = logMessage;
                }));
                //lblCurrentLineProcess.Text =
                //    $"棚 {podID},作成位置 {nodeID},結果 {addPodResult.ReturnMsg}";
                ////addPodResult.ReturnMsg;
                var resultMessage =
                    addPodResult.ReturnMsg == "succ" ? "成功" : "失敗";
                MessageBox.Show($"棚作成に{resultMessage}しました。" +
                    $"{Environment.NewLine}棚 {podID},作成位置 {nodeID}");
            }
            catch (EmergencyException ee)
            {
                Setting.Logger.Error(ee.Message);
                MessageBox.Show($"棚作成に失敗しました。" +
                    $"{Environment.NewLine}{ee.Message}");
            }
            catch (Exception ex)
            {
                Setting.Logger.Error(ex);
                MessageBox.Show($"棚作成に失敗しました。" +
                    $"{Environment.NewLine}{ex.Message}");
            }
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            var serverIP =
                param.ServerIP;
            var warehouseID =
                param.WarehouseID;
            var podID =
                param.PodID;


            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                Setting.Logger.Error(Setting.NotConnectMsg);
                MessageBox.Show($"棚削除に失敗しました。" +
                    $"{Environment.NewLine}{Setting.NotConnectMsg}");
                return;
            }

            try
            {
                var removePodResult = factory.Create(new RemovePodParam(podID)).DoAction();
                string logMessage = $"棚 {podID}";
                Setting.Logger.Info(logMessage);
                Setting.Logger.Info(removePodResult.ReturnMsg);
                this.Invoke((MethodInvoker)(() =>
                {
                    lblCurrentLineProcess.Text = logMessage;
                }));
                //lblCurrentLineProcess.Text =
                //    $"棚 {podID},結果 {removePodResult.ReturnMsg}";
                //lblCurrentLineProcess.BackColor =
                //    removePodResult.ReturnMsg == "succ" ? Color.Green : Color.Red;
                var resultMessage =
                    removePodResult.ReturnMsg == "succ" ? "成功" : "失敗";
                MessageBox.Show($"棚削除に{resultMessage}しました。" +
                    $"{Environment.NewLine}棚 {podID}");
            }
            catch (EmergencyException ee)
            {
                Setting.Logger.Error(ee.Message);
                MessageBox.Show($"棚削除に失敗しました。" +
                    $"{Environment.NewLine}{ee.Message}");
            }
            catch (Exception ex)
            {
                Setting.Logger.Error(ex);
                MessageBox.Show($"棚削除に失敗しました。" +
                    $"{Environment.NewLine}{ex.Message}");
            }
        }

        private async void btnMovePod_Click(object sender, EventArgs e)
        {
            //movePod(param);
            MessageBox.Show($"棚搬送指示を作成しました。" +
                $"{Environment.NewLine}AGV:{param.RobotID},移動先:{param.NodeID},棚:{param.NodeID}");

            await movePod(param.ServerIP, param.WarehouseID, param.PodID
                , param.NodeID, param.RobotID, param.TurnMode, param.Unload);
        }

        private async void btnRotationMove_Click(object sender, EventArgs e)
        {
            prgRepeartCount.Value = 0;

            var stationListPath =
                param.StationListPath;

            if (!FileIO.TryGetAllLines(stationListPath, out var nodeList))
            {
                return;
            }
            nodeList.RemoveAt(0);
            await movePodRotate(param, nodeList);
        }
        private void textBoxServerIP_TextChanged(object sender, EventArgs e)
        {
            param.ServerIP = textBoxServerIP.Text;
        }

        private void textBoxWarehouseID_TextChanged(object sender, EventArgs e)
        {
            param.WarehouseID = textBoxWarehouseID.Text;
        }

        private void textBoxLayoutID_TextChanged(object sender, EventArgs e)
        {
            param.LayoutID = textBoxLayoutID.Text;
        }

        private void textBoxPodID_TextChanged(object sender, EventArgs e)
        {
            param.PodID = textBoxPodID.Text;
        }

        private void textBoxNodeID_TextChanged(object sender, EventArgs e)
        {
            param.NodeID = textBoxNodeID.Text;
        }

        private void textBoxRobotID_TextChanged(object sender, EventArgs e)
        {
            param.RobotID = textBoxRobotID.Text;
        }
        private void textBoxStationListPath_TextChanged(object sender, EventArgs e)
        {
            param.StationListPath = textBoxStationListPath.Text;
        }

        private void checkBoxSynchroTurn_CheckedChanged(object sender, EventArgs e)
        {
            param.TurnMode = checkBoxSynchroTurn.Checked ? 1 : 0;
        }
        private void checkBoxUnload_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUnload.Checked)
            {
                param.Unload = 1;
                param.DestinationMode = DestinationModes.StorageID;
            }
            else
            {
                param.Unload = 0;
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
                Setting.Logger.Error(Setting.NotConnectMsg);
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

        private void btnMoveAGV_Click(object sender, EventArgs e)
        {
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var nodeID = param.NodeID;
            //var podID = textBoxPodID.Text;

            var robotID = param.RobotID;
            MessageBox.Show($"AGV移動指示を作成しました。" +
                $"{Environment.NewLine}AGV:{robotID},移動先:{nodeID}");
            moveRobot(serverIP, warehouseID, robotID, nodeID);
        }

        private void numRepeatCount_ValueChanged(object sender, EventArgs e)
        {
            param.RepeatCount = (int)numRepeatCount.Value;
        }


        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            FileIO.SaveSetting(settingPath, param);
        }

        #endregion Event

        #region Task

        private async Task movePod(string serverIP, string warehouseID, string podID
            , string nodeID, string robotID, int turnMode, int unload)
        {
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                Setting.Logger.Error(Setting.NotConnectMsg);
                return;
            }
            try
            {
                //Task.Run(() =>
                //{
                #region
                //var movePodResult = (MovePodReturnMessage)factory.Create(new MovePodParam(
                //    //robotID
                //    robotID,
                //    //棚のID
                //    podID,
                //    //NodeIDで動かす場合はStorageID（副作用あり、下参照）、ZoneIDで動かす場合はZoneID
                //    //StorageID＆NodeIDで動かすと、Pエリアに下ろせないらしい、棚を回転させれない。
                //    DestinationModes.StorageID,
                //    //NodeID or ZoneID（DestinationModesによる）
                //    nodeID,
                //    //このタスクが終わるまでこの関数を抜けないようにする
                //    isEndWait: true,
                //    //ロボットと棚をシンクロさせる
                //    turnMode: turnMode,
                //    //最終的な棚の姿勢
                //    robotFace: Direction.North,
                //    //robotFace: agvDirection,
                //    podFace: Direction.North,
                //    //podFace: podDirection,
                //    //最終的なAGVの姿勢


                //    //ゴール地点で棚を下ろすか
                //    unload: unload
                //    )).DoAction();
                #endregion

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
                       Setting.Logger.Info(logMessage);
                       Setting.Logger.Info(movePodResult.ReturnMsg);
                       //lblCurrentLineProcess.Text = logMessage;
                       this.Invoke((MethodInvoker)(() =>
                       {
                           lblCurrentLineProcess.Text = logMessage;
                       }));
                       //lblCurrentLineProcess.Text = movePodResult.ReturnMsg;
                       //lblCurrentLineProcess.BackColor =
                       // movePodResult.ReturnMsg == "succ" ? Color.Green : Color.Red;
                   });
                moveTask.Start();
                await moveTask.ConfigureAwait(true);
                //lblCurrentLineProcess.Text =
                //    $"ロボットID {robotID},棚 {podID},移動先 {nodeID} 棚搬送完了";
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                Setting.Logger.Error(ee.Message);
            }
            catch (Exception ex)
            {
                Setting.Logger.Error(ex);
            }
        }
        private async Task movePodRotate(ParamSettings param, List<string> allLines)
        {
            var serverIP =
                //textBoxServerIP.Text;
                param.ServerIP;
            var warehouseID =
                //textBoxWarehouseID.Text;
                param.WarehouseID;
            var layoutID =
                //textBoxLayoutID.Text;
                param.LayoutID;
            var podID =
                //textBoxPodID.Text;
                param.PodID;

            var robotID = param.RobotID;
            //var turnMode = param.TurnMode;
            //var unload = param.Unload;

            int nowCount = 1;
            if (param.RepeatCount == 0)
            {
                while (true)
                {
                    lblProgress.Text = $"繰り返し回数 {nowCount}/制限なし";
                    Setting.Logger.Info(string.Format("{0}回目開始", nowCount + 1));
                    for (var j = 0; j < allLines.Count; j++)
                    {
                        lblRunLineIndex.Text = $"実行行数 {j + 1}/{allLines.Count}";
                        var splitLine = allLines[j].Split(',').ToList();

                        if (!int.TryParse(splitLine[1], out var turnMode))
                        {
                            Setting.Logger.Error("turnModeが読み込めません：{0}", splitLine[1]);
                            continue;
                        }
                        if (!int.TryParse(splitLine[2], out var unload))
                        {
                            Setting.Logger.Error("unloadが読み込めません：{0}", splitLine[2]);
                            continue;
                        }

                        var nodeID = splitLine[0];

                        await movePod(serverIP, warehouseID, podID, nodeID, robotID, turnMode, unload);
                    }
                    nowCount++;
                }
            }
            else
            {
                for (var i = 0; i < param.RepeatCount; i++)
                {
                    prgRepeartCount.Value = (int)((double)nowCount / (double)param.RepeatCount * 100);


                    lblProgress.Text = $"繰り返し回数 {nowCount}/{param.RepeatCount}";
                    Setting.Logger.Info(string.Format("{0}回目開始", i + 1));
                    for (var j = 0; j < allLines.Count; j++)
                    {
                        lblRunLineIndex.Text = $"実行行数 {j + 1}/{allLines.Count}";
                        var splitLine = allLines[j].Split(',').ToList();

                        if (!int.TryParse(splitLine[1], out var turnMode))
                        {
                            Setting.Logger.Error("turnModeが読み込めません：{0}", splitLine[1]);
                            continue;
                        }
                        if (!int.TryParse(splitLine[2], out var unload))
                        {
                            Setting.Logger.Error("unloadが読み込めません：{0}", splitLine[2]);
                            continue;
                        }

                        var nodeID = splitLine[0];

                        await movePod(serverIP, warehouseID, podID, nodeID, robotID, turnMode, unload);
                    }

                    nowCount++;
                }
            }

            

        }
        private async Task moveRobot(string serverIP, string warehouseID, string robotID, string nodeID)
        {
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                Setting.Logger.Error(Setting.NotConnectMsg);
                //MessageBox.Show($"AGVの移動に失敗しました。" +
                //    $"{Environment.NewLine}{Setting.NotConnectMsg}");
                return;
            }

            try
            {
                var moveTask = new Task(() =>
                //Task.Run(() =>
                {
                    var moveRobotResult = new MoveRobotReturnMessage();
                    var ret = factory.Create(new UnsetOwnerParam(robotID)).DoAction();
                    Setting.Logger.Info($"AGV{robotID}に対してUnsetOwnerを行いました。");
                    var rett = factory.Create(new SetOwnerParam(robotID)).DoAction();
                    Setting.Logger.Info($"AGV{robotID}に対してSetOwnerを行いました。");
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
                        Setting.Logger.Info("タスクキャンセル＆ぬける。");
                        factory.Create(new CancelTaskParam(moveRobotResult.Data.TaskID)).DoAction();
                    }

                    string logMessage = $"ロボットID {robotID},移動先 {nodeID}";
                    Setting.Logger.Info(logMessage);
                    Setting.Logger.Info(moveRobotResult.ReturnMsg);

                    this.Invoke((MethodInvoker)(() =>
                    {
                        lblCurrentLineProcess.Text = logMessage;
                    }));
                    //lblCurrentLineProcess.Text = $"ロボットID {robotID},移動先 {nodeID}　AGV移動完了";
                    //lblCurrentLineProcess.BackColor =
                    //    moveRobotResult.ReturnMsg == "succ" ? Color.Green : Color.Red;
                });
                moveTask.Start();
                await moveTask.ConfigureAwait(true);
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                Setting.Logger.Error(ee.Message);
                MessageBox.Show($"AGVの移動に失敗しました。" +
                    $"{Environment.NewLine}{ee.Message}");
            }
            catch (Exception ex)
            {
                Setting.Logger.Error(ex);
                MessageBox.Show($"AGVの移動に失敗しました。" +
                    $"{Environment.NewLine}{ex.Message}");
            }
        }

        #endregion Task

        #region Method
        private double getDirection(int direction)
        {
            var result = Direction.North;
            switch (direction)
            {
                case 0:
                    result = Direction.North;
                    break;
                case 1:
                    result = Direction.East;
                    break;
                case 2:
                    result = Direction.South;
                    break;
                case 3:
                    result = Direction.West;
                    break;
            }
            return result;
        }

        private bool TryLoadSetting()
        {
            var result = FileIO.TryLoadSetting(settingPath, out param);
            var message = string.Empty;
            if (!result)
            {
                message =
                    $"設定ファイルの読込に失敗しました。{Path.GetFullPath(settingPath)}";
                Setting.Logger.Error(message);
                btnLoadSetting.BackColor = Color.Red;
                return result;
            }

            message =
                $"設定ファイルの読込に成功しました。{Path.GetFullPath(settingPath)}";
            Setting.Logger.Info(message);
            btnLoadSetting.BackColor = Color.Green;
            return result;
        }
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

            checkBoxSynchroTurn.Checked = param.TurnMode == 1 ? true : false;
            checkBoxUnload.Checked = param.Unload == 1 ? true : false;
        }
        #endregion Method

        private void btnLoadSetting_Click(object sender, EventArgs e)
        {
            if (!TryLoadSetting())
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
                Setting.Logger.Info(openFileDialog.FileName);
            }
            else
            {
                Setting.Logger.Info("キャンセルされました。");
            }
            openFileDialog.Dispose();
        }
    }
}
