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
        [DisplayName("ノードID")]
        public string NodeID { get; set; } = string.Empty;
        [DisplayName("棚ID")]
        public string PodID { get; set; } = string.Empty;
        [DisplayName("AGVID")]
        public string RobotID{ get; set; } = string.Empty;
        [DisplayName("シンクロターン")]
        public bool IsSyncro{ get; set; } = false;
        [DisplayName("棚を下ろす")]
        public bool IsUnload { get; set; } = true;
        [DisplayName("棚搬送する")]
        public bool WithPod { get; set; } = false;
        [DisplayName("タスクペアの終端")]
        public bool IsPairEnd { get; set; } = true;
        [DisplayName("タスク後待機時間")]
        public int WaitMilliSecond { get; set; } = 0;
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
            WithPod = false;
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
    }
}
