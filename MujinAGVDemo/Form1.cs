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
        ParamSettings param;
        public Form1()
        {
            InitializeComponent();
        }

        #region Event

        private void Form1_Load(object sender, EventArgs e)
        {
            param = new ParamSettings();

            textBoxServerIP.Text = param.ServerIP;
            textBoxWarehouseID.Text = param.WarehouseID;
            textBoxLayoutID.Text = param.LayoutID;
            textBoxPodID.Text = param.PodID;
            textBoxNodeID.Text = param.NodeID;
            textBoxRobotID.Text = param.RobotID;


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
                return;
            }
            try
            {
                factory.Create(new AddPodParam(podID, nodeID, layoutID)).DoAction();
            }
            catch (EmergencyException ee)
            {
                Setting.Logger.Error(ee.Message);
            }
            catch (Exception ex)
            {
                Setting.Logger.Error(ex);
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
                return;
            }

            try
            {
                factory.Create(new RemovePodParam(podID)).DoAction();
            }
            catch (EmergencyException ee)
            {
                Setting.Logger.Error(ee.Message);
            }
            catch (Exception ex)
            {
                Setting.Logger.Error(ex);
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

            movePodToST1(serverIP, warehouseID, podID, robotID);
        }

        private void btnRotationMove_Click(object sender, EventArgs e)
        {
            var stationListPath = "StationList.csv";

            if (!FileIO.TryGetAllLines(stationListPath, out var nodeList))
            {
                return;
            }
            nodeList.RemoveAt(0);
            //var nodeList = new List<string>
            //{
            //    "161095107535",
            //    "161095107537",
            //    "161095107567",
            //    "161095107565",
            //    Setting.ST1NodeID
            //};
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
        #endregion Event

        #region Method
        private static void movePod(ParamSettings param)
        {
            movePod(param.ServerIP, param.WarehouseID, param.PodID
                , param.NodeID, param.RobotID, param.TurnMode, param.Unload);
        }
        private static void movePod(string serverIP, string warehouseID, string podID
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

                var movePodResult = (MovePodReturnMessage)factory.Create(new MovePodParam(
                        robotID,
                        podID,
                        DestinationModes.StorageID,
                        nodeID,
                        isEndWait: false,
                        turnMode: turnMode,
                        unload: unload
                        )).DoAction();
                factory.Create(new WaitEndTaskParam(movePodResult.Data.TaskID
                    , watchRobotID: robotID)).DoAction();

                Setting.Logger.Info(movePodResult.ReturnMsg);
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
        private static void movePodRotate(ParamSettings param, List<string> nodeList)
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
            var nodeID =
                //textBoxNodeID.Text;
                param.NodeID;
            var robotID = param.RobotID;
            var turnMode = param.TurnMode;
            var unload = param.Unload;

            for (var i = 0; i < param.RepeatCount; i++)
            {
                if (i == param.RepeatCount)
                {
                    movePod(serverIP, warehouseID, podID, nodeList[i], robotID, turnMode, 1);
                }
                else
                {
                    movePod(serverIP, warehouseID, podID, nodeList[i], robotID, turnMode, unload);
                }
            }
        }
        private static void movePodToST1(string serverIP, string warehouseID, string podID
            , string robotID)
        {
            movePod(serverIP, warehouseID, podID, Setting.ST1NodeID, robotID, 1, 1);
        }
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

        #endregion Method


    }
}
