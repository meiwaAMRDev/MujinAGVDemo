using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujinAGVDemo
{
    public class MovingParam
    {
        const int ON = 1;
        const int OFF = 0;

        [DisplayName("ノードID")]
        public string NodeID { get; set; } = string.Empty;
        [DisplayName("シンクロターン")]
        public bool IsSyncro { get; set; } = false;
        [DisplayName("棚を下ろす")]
        public bool IsUnload { get; set; } = true;
        [DisplayName("棚搬送する")]
        public bool WithPod { get; set; } = true;
        [DisplayName("棚ID")]
        public string PodID { get; set; } = string.Empty;
        [DisplayName("タスクペアの終端")]
        public bool IsPairEnd { get; set; } = true;
        [DisplayName("タスク後待機時間")]
        public int WaitMilliSecond { get; set; } = 0;
        [DisplayName("AGVIDまたはグループID")]
        public string RobotID { get; set; } = string.Empty;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MovingParam()
        {
            NodeID = string.Empty;
            PodID = string.Empty;
            RobotID = string.Empty;
            IsSyncro = false;
            IsUnload = true;
            WithPod = true;
            IsPairEnd = true;
            WaitMilliSecond = 0;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="nodeID">行先ノードID</param>
        /// <param name="podID">棚ID</param>
        /// <param name="robotID">AGVの号機　または　グループID</param>
        /// <param name="isSyncro">シンクロターンするか</param>
        /// <param name="isUnload">目的地で棚を下ろすか</param>
        /// <param name="withPod">棚搬送するか</param>
        /// <param name="isPairEnd">タスクペアの終端か</param>
        /// <param name="waitMilliSecond">タスク後の待機時間[ms]</param>
        public MovingParam(string nodeID,
                           string podID,
                           string robotID,
                           bool isSyncro,
                           bool isUnload,
                           bool withPod,
                           bool isPairEnd,
                           int waitMilliSecond)
        {
            NodeID = nodeID;
            PodID = podID;
            RobotID = robotID;
            IsSyncro = isSyncro;
            IsUnload = isUnload;
            WithPod = withPod;
            IsPairEnd = isPairEnd;
            WaitMilliSecond = waitMilliSecond;
        }
        /// <summary>
        /// 移動指示CSV用のテキスト
        /// </summary>
        /// <returns>カンマ区切りテキスト</returns>
        public string CSVText()
        {
            //return $"{NodeID},{IsSyncro},{IsUnload},{WithPod},{PodID},{IsPairEnd},{WaitMilliSecond},{RobotID}";
            return $"{NodeID},{(IsSyncro ? ON : OFF)},{(IsUnload ? ON : OFF)},{(WithPod ? ON : OFF)},{PodID},{(IsPairEnd ? ON : OFF)},{WaitMilliSecond},{RobotID}";
        }
        public string CSVHeader()
        {
            //return "NodeID,IsSyncro,IsUnload,WithPod,PodID,IsPairEnd,WaitMilliSecond,RobotID";
            return "移動先ノードID,シンクロターン,棚を下ろす,棚搬送,棚ID,タスクペアの終端,タスク後待機時間,AGVIDまたはグループID";
        }
        /// <summary>
        /// カンマ区切り文字列を使ってMovingParamをセットします。
        /// </summary>
        /// <param name="csvText">カンマ区切り文字列</param>
        /// <returns>変換結果：true=成功　false=失敗</returns>
        public bool TryParseToCSV(string csvText)
        {
            var result = false;
            try
            {
                var split = csvText.Split(',');
                var length = split.Length;

                NodeID = split[0].Trim();

                var isSyncro = split[1].Trim();
                switch (isSyncro)
                {
                    case "0":
                        IsSyncro = false;
                        break;
                    case "1":
                        IsSyncro = true;
                        break;
                    default:
                        IsSyncro = bool.Parse(isSyncro);
                        break;
                }

                var isUnload = split[2].Trim();
                switch (isUnload)
                {
                    case "0":
                        IsUnload = false;
                        break;
                    case "1":
                        IsUnload = true;
                        break;
                    default:
                        IsUnload = bool.Parse(isUnload);
                        break;
                }

                var withPod = split[3].Trim();
                switch (withPod)
                {
                    case "0":
                        WithPod = false;
                        break;
                    case "1":
                        WithPod = true;
                        break;
                    default:
                        WithPod = bool.Parse(withPod);
                        break;
                }

                PodID = split[4].Trim();

                var isPairEnd = split[5].Trim();
                switch (isPairEnd)
                {
                    case "0":
                        IsPairEnd = false;
                        break;
                    case "1":
                        IsPairEnd = true;
                        break;
                    default:
                        IsPairEnd = bool.Parse(isPairEnd);
                        break;
                }

                WaitMilliSecond = int.Parse(split[6].Trim());

                RobotID = split[7].Trim();

                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
