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
        #region Property

        /// <summary>
        /// 棚搬送時のシンクロターン設定
        /// 0:シンクロターンしない
        /// 1:シンクロターンする
        /// </summary>
        public int TurnMode { get; set; }
        /// <summary>
        /// 棚搬送時に終点で棚を下ろすか
        /// 0:棚を下ろさない
        /// 1:棚を下ろす
        /// </summary>
        public int Unload { get; set; }
        /// <summary>
        /// 連続動作の繰り返し回数
        /// 0の場合は無限に繰り返す
        /// </summary>
        public int RepeatCount { get; set; }
        /// <summary>
        /// サーバーのIPアドレス
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// ウェアハウスID
        /// Hetu上から確認することができる
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// コンテナID
        /// マップエディタの「基本データ」→「コンテナタイプ」→「ID」で確認することができる
        /// </summary>
        public string LayoutID { get; set; }
        /// <summary>
        /// ノードID
        /// Hetu上の「工程図」→「QRコード」→「NodeID」で確認することができる
        /// </summary>
        public string NodeID { get; set; }
        /// <summary>
        /// 棚ID
        /// Hetu上の「工程図」→「コンテナ」→「コンテナID」で確認することができる
        /// </summary>
        public string PodID { get; set; }
        /// <summary>
        /// AGVのID
        /// Hetu上の「工程図」→「搬送装置」→「ロボットID」で確認することができる
        /// </summary>
        public string RobotID { get; set; }
        /// <summary>
        /// AGVの行先指定方法
        /// NodeID=1（MovePodでは棚置けない。棚置きたい場合はStorageIDを使うこと）※MoveRobotで使用
        /// StorageID = 2 （NodeID指定で棚を置きたいとき）※MovePodで使用
        /// ZoneID = 3(ZoneID指定の場合に使う)
        /// </summary>
        public DestinationModes DestinationMode { get; set; }
        /// <summary>
        /// 読み込むCSVファイルのパス
        /// </summary>
        public string StationListPath { get; set; }
        /// <summary>
        /// 充電ゾーンID
        /// </summary>
        public string ChargeZoneID { get; set; }
        /// <summary>
        /// ノード情報のリスト
        /// </summary>
        public List<NodeData> NodeDatas { get; set; }
        /// <summary>
        /// グループID　マップエディタの「基本データ」→「能力グループ」→「ID」で確認することができる
        /// </summary>
        public string RobotGroupID { get; set; }
        #endregion Property

        public ParamSettings()
        {
            TurnMode = 0;
            Unload = 1;
            RepeatCount = 1;

            ServerIP = "60.205.92.182";
            WarehouseID = "417071259357020162";
            LayoutID = "c1658124614457";
            NodeID = "164982914836";
            PodID = "1111";
            RobotID = "1";
            ChargeZoneID = "164982914897";

            StationListPath = @"CSVSample/エミュレータ用移動テスト.csv";

            DestinationMode = DestinationModes.StorageID;

            NodeDatas = new List<NodeData>()
            {
                //new NodeData("N1", "164982914836"),
                //new NodeData("N2", "1649829148141"),
                //new NodeData("N3", "1649829148140"),
                //new NodeData("N4", "164982914835"),
            };
            Pod1Param = new ExchangePodParam(PodID, string.Empty, NodeID);
            Pod2Param = new ExchangePodParam(PodID, string.Empty, NodeID);
        }

        public ExchangePodParam Pod1Param { get; set; }
        public ExchangePodParam Pod2Param { get; set; }
    }
    /// <summary>
    /// ノード情報クラス
    /// </summary>
    public class NodeData
    {
        /// <summary>
        /// ノード名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ノードID
        /// </summary>
        public string NodeID { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ノード名称</param>
        /// <param name="nodeID">ノードID</param>
        public NodeData(string name, string nodeID)
        {
            this.Name = name;
            this.NodeID = nodeID;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NodeData()
        {
            this.Name = string.Empty;
            this.NodeID = string.Empty;
        }
    }

    /// <summary>
    /// 棚毎の棚交換タスク用パラメータ
    /// </summary>
    public class ExchangePodParam
    {
        /// <summary>
        /// 棚ID
        /// </summary>
        public string PodID { get; set; }
        /// <summary>
        /// 退避先ノードID
        /// </summary>
        public string TempNodeID { get; set; }
        /// <summary>
        /// 目的地ノードID　※P点を指定する
        /// </summary>
        public string NodeID { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="podID">棚ID</param>
        /// <param name="tempNodeID">退避先ノードID</param>
        /// <param name="nodeID">目的地ノードID</param>
        public ExchangePodParam(string podID, string tempNodeID, string nodeID)
        {
            PodID = podID;
            TempNodeID = tempNodeID;
            NodeID = nodeID;
        }
        public ExchangePodParam()
        {
            PodID = string.Empty;
            TempNodeID = string.Empty;
            NodeID = string.Empty;
        }
    }
}
