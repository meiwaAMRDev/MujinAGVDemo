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
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxServerIP.Text = Setting.ServerIP;
            textBoxWarehouseID.Text = Setting.WarehouseID;
            textBoxLayoutID.Text = Setting.LayoutID;
            textBoxPodID.Text = Setting.PodID;
            textBoxNodeID.Text = Setting.NodeID;
            listBoxPodDirection.SelectedIndex = 0;
            listBoxAGVDirection.SelectedIndex = 0;
        }
        private void btnAddPod_Click(object sender, EventArgs e)
        {
            #region AGVデモエリアの設定

            var serverIP = textBoxServerIP.Text;
            var warehouseID = textBoxWarehouseID.Text;
            var layoutID = textBoxLayoutID.Text;

            #endregion AGVデモエリアの設定

            var podID = textBoxPodID.Text;
            var nodeID = textBoxNodeID.Text;



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
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            #region AGVデモエリアの設定

            var serverIP = textBoxServerIP.Text;
            var warehouseID = textBoxWarehouseID.Text;

            #endregion AGVデモエリアの設定

            var podID = textBoxPodID.Text;


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
        }

        private void btnMovePod_Click(object sender, EventArgs e)
        {
            #region AGVデモエリアの設定

            var serverIP = textBoxServerIP.Text;
            var warehouseID = textBoxWarehouseID.Text;
            //var layoutID = textBoxLayoutID.Text;

            #endregion AGVデモエリアの設定

            var podID = textBoxPodID.Text;
            var nodeID = textBoxNodeID.Text;
            var robotID = Setting.RobotID;
            var podDirection = getDirection(listBoxPodDirection.SelectedIndex);
            var agvDirection = getDirection(listBoxAGVDirection.SelectedIndex);


            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                Setting.Logger.Error(Setting.NotConnectMsg);
                return;
            }

            try
            {
                var movePodResult = (MovePodReturnMessage)factory.Create(new MovePodParam(
                    //robotID
                    robotID,
                    //棚のID
                    podID,
                    //NodeIDで動かす場合はStorageID（副作用あり、下参照）、ZoneIDで動かす場合はZoneID
                    //StorageID＆NodeIDで動かすと、Pエリアに下ろせないらしい、棚を回転させれない。
                    DestinationModes.StorageID,
                    //NodeID or ZoneID（DestinationModesによる）
                    nodeID,
                    //このタスクが終わるまでこの関数を抜けないようにする
                    isEndWait: true,
                    //最終的な棚の姿勢
                    //podFace: Direction.North,
                    podFace:podDirection,
                    //最終的なAGVの姿勢
                    //robotFace: Direction.North
                    robotFace:agvDirection
                    )).DoAction();
                Setting.Logger.Info(movePodResult.ReturnMsg);
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                Setting.Logger.Error(ee.Message);
            }
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
    }
}
