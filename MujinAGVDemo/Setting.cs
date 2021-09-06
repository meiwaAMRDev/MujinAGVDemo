using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MujinAGVDemo
{
    public static class Setting
    {
        /// <summary>
        /// ロガー
        /// </summary>
        public static Logger Logger = LogManager.GetLogger("ProgramLogger");

        #region メッセージ
        /// <summary>
        /// プログラム開始時のメッセージ
        /// </summary>
        public static string StartMsg = "===== Program start =====";
        /// <summary>
        /// プログラム終了時のメッセージ
        /// </summary>
        public static string EndMsg = "===== Program end   =====";
        /// <summary>
        /// TESサーバー接続失敗時のメッセージ
        /// </summary>
        public static string NotConnectMsg = "TESサーバーに接続失敗";
        #endregion メッセージ

        public static string ServerIP = "192.168.1.202";
        public static string WarehouseID = "345059706261209098";
        public static string LayoutID = "c1610957226027";
        public static string NodeID = "161095107533";
        public static string PodID = "1120";
        public static string RobotID = "50";


        #region 各地点のノードID
        public static string ST1NodeID = "161095107533";
        public static string ST1WaitNodeID = "161095107535";

        public static string ST2NodeID = "161095107548";
        public static string ST2WaitNodeID = "161095107553";

        public static string ST3NodeID = "161095107563";
        public static string ST3WaitNodeID = "161095107565";

        public static string OldChargerNodeID = "1610951075127";
        public static string NewChargerNodeID = "161095107537";
        #endregion 各地点のノードID
    }
}
