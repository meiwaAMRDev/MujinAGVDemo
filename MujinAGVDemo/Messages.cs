using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace MujinAGVDemo
{
    public static class Messages
    {
        /// <summary>
        /// ロガー
        /// </summary>
        public static Logger Logger = LogManager.GetLogger("ProgramLogger");

        #region メッセージ
        /// <summary>
        /// プログラム開始時のメッセージ
        /// </summary>
        public const string StartMsg = "===== Program start =====";
        /// <summary>
        /// プログラム終了時のメッセージ
        /// </summary>
        public const string EndMsg = "===== Program end   =====";

        #region エラーメッセージ
        /// <summary>
        /// TESサーバー接続失敗時のメッセージ
        /// </summary>
        public const string NotConnectMsg = "TESサーバーに接続失敗";
        /// <summary>
        /// 設定ファイル読込失敗時のメッセージ
        /// </summary>
        public const string LoadError = "設定ファイルの読込が失敗しました。";
        public const string UnsetOwnerError = "UnsetOwnerが失敗しました。";
        public const string SetOwnerError = "SetOwnerが失敗しました。";
        public const string SaveCSVError = "CSVファイルの保存が失敗しました。";
        #endregion エラーメッセージ

        #region 成功メッセージ        
        public const string LoadSucc = "設定ファイルの読込が成功しました。";
        public const string UnsetOwnerSucc = "UnsetOwnerが成功しました。";
        public const string SetOwnerSucc = "SetOwnerが成功しました。";
        public const string SaveCSVSucc = "CSVファイルの保存が成功しました。";
        #endregion 成功メッセージ

        #endregion メッセージ
    }
}
