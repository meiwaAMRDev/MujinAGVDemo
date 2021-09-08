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

        #region AGVデモエリア用設定

        public static string ServerIP =
            "192.168.1.202";
        public static string WarehouseID =
            "363402754208563209";
        public static string LayoutID =
            "c1610957014289";
        public static string NodeID =
            "161095107533";
        public static string PodID =
            "1120";
        public static string RobotID =
            "50";

        #endregion AGVデモエリア用設定

        #region エミュレータ用設定

        //public static string ServerIP =
        //    "39.106.65.245";
        //public static string WarehouseID =
        //    "361868188280946696";
        //public static string LayoutID =
        //    "c1627004204034";
        //public static string NodeID =
        //    "162700358718998";
        //public static string PodID =
        //    "1120";
        //public static string RobotID =
        //    "1";

        #endregion エミュレータ用設定

        #region 各地点のID

        public static string ST1NodeID = "161095107533";
        public static string ST1WaitNodeID = "161095107535";
        public static string ST1ZoneID = "16309775071";

        public static string ST2NodeID = "161095107548";
        public static string ST2WaitNodeID = "161095107553";
        public static string ST2ZoneID = "16309775342";

        public static string ST3NodeID = "161095107563";
        public static string ST3WaitNodeID = "161095107565";
        public static string ST3ZoneID = "16309775633";

        public static string ST4NodeID = "161095107537";
        public static string ST4WaitNodeID = "161095107536";
        public static string ST4ZoneID = "16310594702";

        public static string ChargerNodeID = "1610951075127";
        public static string ChargerZoneID = "16111867461";

        #endregion 各地点のID
    }
}
