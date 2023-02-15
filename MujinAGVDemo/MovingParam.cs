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
        /// <summary>
        /// 移動指示CSVの中の列番号
        /// </summary>
        enum Col : int
        {
            NodeID = 0,
            IsSyncro = 1,
            IsUnload = 2,
            WithPod = 3,
            PodID = 4,
            IsPairEnd = 5,
            WaitMilliSecond = 6,
            RobotID = 7
        }
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
        /// コンストラクタ
        /// </summary>
        /// <param name="csvText">カンマ区切り文字列</param>
        public MovingParam(string csvText)
        {
            var split = csvText.Split(',');
            var lastIndex = split.Length - 1;
            NodeID = split[(int)Col.NodeID].Trim();
            //ノードIDが全部数字でない場合はNG
            if (!NodeID.All(char.IsDigit))
            {
                return;
            }
            var isSyncro = split[(int)Col.IsSyncro].Trim();
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

            var isUnload = split[(int)Col.IsUnload].Trim();
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
            if (lastIndex < (int)Col.WithPod)
            {
                WithPod = true;
            }
            else
            {
                var withPod = split[(int)Col.WithPod].Trim();
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
            }

            PodID = lastIndex < (int)Col.PodID ? string.Empty : split[(int)Col.PodID].Trim();

            if (lastIndex < (int)Col.IsPairEnd)
            {
                IsPairEnd = true;
            }
            else
            {
                var isPairEnd = split[(int)Col.IsPairEnd].Trim();
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
            }

            WaitMilliSecond = lastIndex < (int)Col.WaitMilliSecond ? 0 : int.Parse(split[(int)Col.WaitMilliSecond].Trim());

            RobotID = lastIndex < (int)Col.RobotID ? string.Empty : split[(int)Col.RobotID].Trim();
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
        /// <summary>
        /// 移動指示CSV用のヘッダーテキスト
        /// </summary>
        /// <returns>カンマ区切りヘッダーテキスト</returns>
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
                var lastIndex = split.Length - 1;
                NodeID = split[(int)Col.NodeID].Trim();
                //ノードIDが全部数字でない場合はNG
                if (!NodeID.All(char.IsDigit))
                {
                    return result;
                }
                var isSyncro = split[(int)Col.IsSyncro].Trim();
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
                var isUnload = split[(int)Col.IsUnload].Trim();
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
                if (lastIndex < (int)Col.WithPod)
                {
                    WithPod = true;
                }
                else
                {
                    var withPod = split[(int)Col.WithPod].Trim();
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
                }
                PodID = lastIndex < (int)Col.PodID ? string.Empty : split[(int)Col.PodID].Trim();
                if (lastIndex < (int)Col.IsPairEnd)
                {
                    IsPairEnd = true;
                }
                else
                {
                    var isPairEnd = split[(int)Col.IsPairEnd].Trim();
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
                }
                WaitMilliSecond = lastIndex < (int)Col.WaitMilliSecond ? 0 : int.Parse(split[(int)Col.WaitMilliSecond].Trim());
                RobotID = lastIndex < (int)Col.RobotID ? string.Empty : split[(int)Col.RobotID].Trim();

                result = true;
            }
            catch (Exception ex)
            {
                do
                {
                    Console.WriteLine($"{ex.Message},{ex.TargetSite}");
                    ex = ex.InnerException;
                } while (ex != null);


                result = false;
            }
            return result;
        }
    }
}
