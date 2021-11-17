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
        /// NodeID=1（MovePodでは棚置けない。棚置きたい場合はStorageIDを使うこと）
        /// StorageID = 2 （NodeID指定で棚を置きたいとき）
        /// ZoneID = 3(ZoneID指定の場合に使う)
        /// </summary>
        public DestinationModes DestinationMode { get; set; }
        /// <summary>
        /// 読み込むCSVファイルのパス
        /// </summary>
        public string StationListPath { get; set; }


        public ParamSettings()
        {
            TurnMode = 0;
            Unload = 1;
            RepeatCount = 1;
                        
            ServerIP = "39.106.65.245";
            WarehouseID = "361868188280946696";
            LayoutID = "c1625463844245";
            NodeID = "162634055515651";
            PodID = "1942";
            RobotID = "105";
            StationListPath = @"CSVSample/エミュレータ用移動テスト.csv";
            

            DestinationMode = DestinationModes.StorageID;
        }
    }
}
