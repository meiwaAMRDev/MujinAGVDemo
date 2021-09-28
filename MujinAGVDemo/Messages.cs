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
        /// <summary>
        /// TESサーバー接続失敗時のメッセージ
        /// </summary>
        public const string NotConnectMsg = "TESサーバーに接続失敗";
        /// <summary>
        /// 設定ファイル読込失敗時のメッセージ
        /// </summary>
        public const string CannotLoad = "設定ファイルの読込失敗";
        public const string UnsetOwnerError = "UnsetOwnerが失敗しました。";
        public const string SetOwnerError = "SetOwnerが失敗しました。";
        #endregion メッセージ
    }
}
