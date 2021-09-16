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
    public partial class Form1 : Form
    {
        #region delegate
        #endregion delegate

        #region Const
        #endregion Const

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            param = new ParamSettings();

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
            checkBoxIsError.Checked = isError;
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
                logError(Setting.NotConnectMsg);
                return;
            }
            try
            {
                factory.Create(new AddPodParam(podID, nodeID, layoutID)).DoAction();
            }
            catch (EmergencyException ee)
            {
                logError(ee.Message);
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
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
                logError(Setting.NotConnectMsg);
                return;
            }

            try
            {
                factory.Create(new RemovePodParam(podID)).DoAction();
            }
            catch (EmergencyException ee)
            {
                logError(ee.Message);
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
        }

        private void btnMovePod_Click(object sender, EventArgs e)
        {
            movePod(param);
        }

        private void btnMoveST1_Click(object sender, EventArgs e)
        {
            var serverIP = textBoxServerIP.Text;
            var warehouseID = textBoxWarehouseID.Text;

            var podID = textBoxPodID.Text;
            var robotID = param.RobotID;

            var nodeID = Setting.ST1NodeID;
            moveRobot(serverIP, warehouseID, robotID, nodeID);
        }

        private void btnRotationMove_Click(object sender, EventArgs e)
        {
            var stationListPath =
                param.StationListPath;

            if (!FileIO.TryGetAllLines(stationListPath, out var nodeList))
            {
                return;
            }
            nodeList.RemoveAt(0);
            movePodRotate(param, nodeList);
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
                logError(Setting.NotConnectMsg);
                return;
            }

            isStop = !isStop;
            if (isStop == false)
            {
                factory.Create(new PauseRobotParam(robotID)).DoAction();
            }
            else
            {
                factory.Create(new ResumeRobotParam(robotID)).DoAction();
            }
        }

        private void btnMoveAGV_Click(object sender, EventArgs e)
        {
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var nodeID = param.NodeID;
            var robotID = param.RobotID;
            var direction = param.Direction;

            moveRobot(serverIP, warehouseID, robotID, nodeID, direction);
        }

        private void numRepeatCount_ValueChanged(object sender, EventArgs e)
        {
            param.RepeatCount = (int)numRepeatCount.Value;
        }

        private void checkBoxIsError_CheckedChanged(object sender, EventArgs e)
        {
            isError = !isError;
            checkBoxIsError.Checked = isError;
        }

        private void btnMovePodFromST3_Click(object sender, EventArgs e)
        {
            var serverIP =
                param.ServerIP;
            var warehouseID =
                param.WarehouseID;
            var layoutID =
                param.LayoutID;
            var podID =
                param.PodID;

            var direction = param.Direction;

            var robotID = param.RobotID;


            moveRobot(serverIP, warehouseID, robotID, "161095107563", direction);
            movePod(serverIP, warehouseID, podID, "161095107565", robotID, 0, 1);
            movePod(serverIP, warehouseID, podID, "161095107563", robotID, 0, 1);
            moveRobot(serverIP, warehouseID, robotID, "161095107567", direction);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            Setting.Logger.Info(index);
            switch (index)
            {
                case 0:
                    param.Direction = Direction.North;
                    break;
                case 1:
                    param.Direction = Direction.East;
                    break;
                case 2:
                    param.Direction = Direction.South;
                    break;
                case 3:
                    param.Direction = Direction.West;
                    break;
                default:
                    param.Direction = Direction.NoSelect;
                    break;
            }
            Setting.Logger.Info(param.Direction);
        }
        #endregion Events

        #region Property(Public Paramater)
        #endregion Property(Public Paramater)

        #region Private Parameter
        ParamSettings param;
        bool isStop = false;
        bool isError = false;
        #endregion Private Parameter

        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Public Method
        #endregion Public Method

        #region Private Method
        private void movePod(ParamSettings param)
        {
            movePod(param.ServerIP, param.WarehouseID, param.PodID
                , param.NodeID, param.RobotID, param.TurnMode, param.Unload);
        }
        private void movePod(string serverIP, string warehouseID, string podID
            , string nodeID, string robotID, int turnMode, int unload)
        {
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logError(Setting.NotConnectMsg);
                return;
            }
            try
            {
                Task.Run(() =>
                {
                    
                    var movePodResult = (MovePodReturnMessage)factory.Create(new MovePodParam(
                        robotID,
                        podID,
                        DestinationModes.StorageID,
                        nodeID,
                        //isEndWait: false,
                        isEndWait: true,
                        turnMode: turnMode,
                        unload: unload
                        )).DoAction();
                    //factory.Create(new WaitEndTaskParam(movePodResult.Data.TaskID
                    //    , watchRobotID: robotID)).DoAction();

                    Setting.Logger.Info(movePodResult.ReturnMsg);
                });
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                logError(ee.Message);
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
        }
        private void movePodRotate(ParamSettings param, List<string> allLines)
        {
            var serverIP =
                param.ServerIP;
            var warehouseID =
                param.WarehouseID;
            var layoutID =
                param.LayoutID;
            var podID =
                param.PodID;

            var robotID = param.RobotID;

            for (var i = 0; i < param.RepeatCount; i++)
            {
                Setting.Logger.Info(string.Format("{0}回目開始", i + 1));
                for (var j = 0; j < allLines.Count; j++)
                {

                    var splitLine = allLines[j].Split(',').ToList();

                    if (!int.TryParse(splitLine[1], out var turnMode))
                    {
                        logError(string.Format("turnModeが読み込めません：{0}", splitLine[1]));

                        continue;
                    }
                    if (!int.TryParse(splitLine[2], out var unload))
                    {
                        logError(string.Format("unloadが読み込めません：{0}", splitLine[2]));
                        continue;
                    }

                    var nodeID =
                    splitLine[0];

                    movePod(serverIP, warehouseID, podID, nodeID, robotID, turnMode, unload);
                }
            }

        }
        private void moveRobot(string serverIP, string warehouseID, string robotID, string nodeID)
        {
            moveRobot(serverIP, warehouseID, robotID, nodeID, Direction.NoSelect);

        }

        private void moveRobot(string serverIP, string warehouseID, string robotID, string nodeID, double direction)
        {
            Setting.Logger.Info(direction);

            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logError(Setting.NotConnectMsg);
                return;
            }

            try
            {
                Task.Run(() =>
                {
                    var mvrtA = new MoveRobotReturnMessage();
                    var ret = factory.Create(new UnsetOwnerParam(robotID)).DoAction();
                    var rett = factory.Create(new SetOwnerParam(robotID)).DoAction();
                    mvrtA = (MoveRobotReturnMessage)(factory.Create(new MoveRobotParam(
                        robotID,
                        DestinationModes.NodeID,
                        nodeID,
                        //isEndWait: false,
                        isEndWait: true,
                        ownerRegist: false,
                         robotFace: direction
                        )).DoAction());
                    var waitResult = factory.Create(new WaitEndTaskParam(mvrtA.Data.TaskID, watchRobotID: robotID)).DoAction();
                    if (waitResult.ReturnCode != 0)
                    {
                        Setting.Logger.Info("タスクキャンセル＆ぬける。");
                        factory.Create(new CancelTaskParam(mvrtA.Data.TaskID)).DoAction();
                    }
                });
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                logError(ee.Message);
            }
            catch (Exception ex)
            {
                logError(ex.ToString());
            }
        }
        private void logError(string message)
        {
            Setting.Logger.Error(message);
            isError = true;
            checkBoxIsError.Checked = isError;
        }
        #endregion Private Method
    }
}
