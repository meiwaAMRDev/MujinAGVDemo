using Hetu20dotnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujinAGVDemo
{
    public class ParamSettings
    {
        public int TurnMode { get; set; }
        public int Unload { get; set; }
        public int RepeatCount { get; set; }

        public string ServerIP { get; set; }
        public string WarehouseID { get; set; }
        public string LayoutID { get; set; }
        public string NodeID { get; set; }
        public string PodID { get; set; }
        public string RobotID { get; set; }
        public DestinationModes DestinationMode { get; set; }
        public string StationListPath { get; set; }


        public ParamSettings()
        {
            TurnMode = 0;
            Unload = 1;
            RepeatCount = 1;

            #region 社内デモ用
            //ServerIP = "192.168.1.202";
            //WarehouseID ="363402754208563209";
            //LayoutID ="c1610957014289";
            //NodeID ="161095107533";
            //RobotID ="104";
            //StationListPath = "RotateMoveLeftS.csv";
            //PodID =
            ////"1120";
            //"1120";
            #endregion 社内デモ用

            #region エミュレータ用
            ServerIP = "39.106.65.245";
            WarehouseID = "361868188280946696";
            LayoutID = "c1625463844245";
            NodeID = "162634055515651";
            RobotID = "105";
            //StationListPath = "RotateMoveLeftS.csv";
            StationListPath = "エミュレータ用移動テスト.csv";
            PodID =
            //"1120";
            "1942";
            #endregion エミュレータ用

            DestinationMode = DestinationModes.StorageID;
        }
    }
}
