using Hetu20dotnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujinAGVDemo
{
    class ParamSettings
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
            RepeatCount = 3;

            ServerIP ="192.168.1.202";
            WarehouseID ="363402754208563209";
            LayoutID ="c1610957014289";
            NodeID ="161095107533";
            RobotID ="50";
            StationListPath = "StationList.csv";

            DestinationMode = DestinationModes.StorageID;
        }
    }
}
