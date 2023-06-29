using CsvHelper;
using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;
using MujinAGVDemo.Command;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MujinAGVDemo.Control;

namespace MujinAGVDemo.Forms
{
    public partial class FrmNodeDatas : Form
    {
        public FrmNodeDatas()
        {
            InitializeComponent();
        }
        public FrmNodeDatas(ParamSettings param, string settingPath)
        {
            InitializeComponent();
            this.param = param;
            this.settingPath = settingPath;
        }

        private void FrmNodeDatas_Load(object sender, EventArgs e)
        {
            updateDgvMove(param.NodeDatas);

            txtPodID.SetLabel("棚ID");
            txtPodID.SetText(param.PodID);
            txtRobotID.SetLabel("ロボットID");
            txtRobotID.SetText(param.RobotID);
        }

        #region Parametor

        /// <summary>
        /// 設定ファイルのデフォルトパス
        /// </summary>
        const string defaultSettingPath = @"Setting/ParamSetting.xml";
        public readonly Logger logger = LogManager.GetLogger("ProgramLogger");
        private ParamSettings param;
        public CommandFactory Factory;
        private readonly FileIO fileIO = new FileIO();
        private CancellationTokenSource source = new CancellationTokenSource();
        private string settingPath = defaultSettingPath;

        #region Enum

        /// <summary>
        /// ノードデータ設定の列番号
        /// </summary>
        enum NColumn : int
        {
            /// <summary>
            /// 名前列
            /// </summary>
            Name = 0,
            /// <summary>
            /// ノードID列
            /// </summary>
            Node = 1,
            /// <summary>
            /// AGV移動列
            /// </summary>
            MoveAGV = 2,
            /// <summary>
            /// 棚移動列
            /// </summary>
            MovePod = 3,
            /// <summary>
            /// 棚作成列
            /// </summary>
            AddPod = 4,
            /// <summary>
            /// 編集列
            /// </summary>
            Edit = 5,
        }
        /// <summary>
        /// マップ上方向を北とした場合の方角
        /// </summary>
        enum DirectionIndex : int
        {
            /// <summary>
            /// 北
            /// </summary>
            North = 0,
            /// <summary>
            /// 東
            /// </summary>
            East = 1,
            /// <summary>
            /// 南
            /// </summary>
            South = 2,
            /// <summary>
            /// 西
            /// </summary>
            West = 3,
            /// <summary>
            /// 指定しない
            /// </summary>
            NoDefine = 4,
        }

        #endregion Enum

        private int robotFaceIndex = (int)DirectionIndex.NoDefine;
        private int podFaceIndex = (int)DirectionIndex.NoDefine;

        #endregion Parametor


        private async void dgvMove_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateParam();
            //行の範囲外の時は終了
            if (e.RowIndex < 0 || param.NodeDatas.Count <= e.RowIndex)
            {
                return;
            }

            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            try
            {
                //AGV移動をクリック
                if (e.ColumnIndex == (int)NColumn.MoveAGV)
                {
                    source = new CancellationTokenSource();

                    var robotFace = Direction.NoSelect;
                    switch (robotFaceIndex)
                    {
                        case 0:
                            robotFace = Direction.North;
                            break;
                        case 1:
                            robotFace = Direction.East;
                            break;
                        case 2:
                            robotFace = Direction.South;
                            break;
                        case 3:
                            robotFace = Direction.West;
                            break;
                        case 4:
                            robotFace = Direction.NoSelect;
                            break;
                    }

                    try
                    {
                        await MoveRobotV2(robotID: param.RobotID,
                                          nodeID: dgvMove[(int)NColumn.Node, e.RowIndex].Value.ToString(),
                                          token: source.Token,
                                          robotFace: robotFace,
                                          isShowMessageBox: true);
                    }
                    catch (Exception ex)
                    {
                        do
                        {
                            logger.Error($"エラー：{ex.Message}:{ex.TargetSite}");
                            ex = ex.InnerException;
                        }
                        while (ex != null);
                    }

                }
                //棚移動をクリック
                else if (e.ColumnIndex == (int)NColumn.MovePod)
                {
                    source = new CancellationTokenSource();
                    var robotFace = Direction.NoSelect;
                    switch (robotFaceIndex)
                    {
                        case 0:
                            robotFace = Direction.North;
                            break;
                        case 1:
                            robotFace = Direction.East;
                            break;
                        case 2:
                            robotFace = Direction.South;
                            break;
                        case 3:
                            robotFace = Direction.West;
                            break;
                        case 4:
                            robotFace = Direction.NoSelect;
                            break;
                    }
                    var podFace = Direction.NoSelect;
                    switch (podFaceIndex)
                    {
                        case 0:
                            podFace = Direction.North;
                            break;
                        case 1:
                            podFace = Direction.East;
                            break;
                        case 2:
                            podFace = Direction.South;
                            break;
                        case 3:
                            podFace = Direction.West;
                            break;
                        case 4:
                            podFace = Direction.NoSelect;
                            break;
                    }

                    var task = AsyncCommands.MovePod(token: source.Token,
                                                     factory: Factory,
                                                     robotID: param.RobotID,
                                                     nodeID: dgvMove[(int)NColumn.Node, e.RowIndex].Value.ToString(),
                                                     podID: param.PodID,
                                                     robotFace: robotFace,
                                                     podFace: podFace,
                                                     unload: param.Unload);
                    await task;

                    showMessageBox(task.Result.Item1, task.Result.Item2);
                }
                //編集をクリック
                else if (e.ColumnIndex == (int)NColumn.Edit)
                {
                    var name = dgvMove[(int)NColumn.Name, e.RowIndex].Value.ToString();
                    var nodeID = dgvMove[(int)NColumn.Node, e.RowIndex].Value.ToString();

                    var target = param.NodeDatas[e.RowIndex];
                    target.Name = name;
                    target.NodeID = nodeID;

                    fileIO.SaveSetting(settingPath, param);
                }
                //棚作成をクリック
                else if (e.ColumnIndex == (int)NColumn.AddPod)
                {
                    var nodeID = dgvMove[(int)NColumn.Node, e.RowIndex].Value.ToString();
                    if (showCheckMessage($"[{nodeID}]に棚[{param.PodID}]を作成しますか？") != DialogResult.OK)
                    {
                        return;
                    }
                    addPod(nodeID: nodeID);
                }
            }
            catch (Exception ex)
            {
                showErrorMessageBox($"エラーが発生しました。{ex.ToString()}");
            }
        }

        /// <summary>
        /// 棚を追加します
        /// </summary>
        /// <param name="nodeID">棚作成位置（指定しなければ「基本設定」を参照します）</param>
        private void addPod(string nodeID = "")
        {
            updateParam();

            var layoutID = param.LayoutID;
            var podID = param.PodID;
            if (nodeID == "")
                nodeID = param.NodeID;

            var addPodParam = new AddPodParam(podID, nodeID, layoutID);

            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }
            try
            {
                var addPodResult = factory.Create(addPodParam).DoAction();
                var logMessage = $"棚作成結果:[{addPodResult.ReturnMsg}] リターンコード:[{addPodResult.ReturnCode}] 棚ID:[{podID}] 作成位置:[{nodeID}] コンテナID:[{layoutID}]";
                showInfoMessageBox($"{logMessage}");
            }
            catch (EmergencyException ee)
            {
                logger.Error(ee);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private async Task MoveRobotV2(string robotID,
                                       string nodeID,
                                       CancellationToken token,
                                       double robotFace = Direction.NoSelect,
                                       bool isShowMessageBox = true)
        {
            var moveRobotParam = new MoveRobotParam(robotID: robotID,
                                                    desMode: DestinationModes.NodeID,
                                                    desID: nodeID,
                                                    robotFace: robotFace
                                                    )
            {
                CachingCall = (obj, ev) => { }
            };

            if (Factory == null)
            {
                Factory = new CommandFactory(rcsIP: param.ServerIP, warehouseID: param.WarehouseID);
            }

            await Task.Factory.StartNew(async () =>
            {
                logger.Info($"AGV移動を開始します。AGV[{robotID}]行先[{nodeID}]");
                var result = (MoveRobotReturnMessage)Factory.Create(moveRobotParam).DoAction();

                if (result == null)
                    return;
                if (result.Data == null)
                    return;
                if (result.Data.TaskID == null)
                    return;

                var taskID = result.Data.TaskID;

                var isTaskEnd = false;
                var message = string.Empty;
                do
                {
                    if (token.IsCancellationRequested)
                    {
                        isTaskEnd = true;
                        message = $"トークンがキャンセルされました。";
                    }

                    var taskDetail = (GetTaskDetailReturnMessage)Factory
                    .Create(new GetTaskDetailParam(taskID)).DoAction();

                    if (taskDetail == null)
                    {
                        await Task.Delay(5000);
                    }

                    var taskStatus = taskDetail.Data.Detail.Status;
                    logger.Info($"TaskID[{taskID}]TaskStatus[{taskStatus}]");

                    switch (taskStatus)
                    {
                        case TaskStatuses.Success:
                            isTaskEnd = true;
                            message = $"AGV移動が完了しました。AGV[{robotID}]行先[{nodeID}]";
                            break;
                        case TaskStatuses.Running:
                            await Task.Delay(5000);
                            break;
                        case TaskStatuses.Fail:
                            isTaskEnd = true;
                            message = $"AGV移動が失敗しました。AGV[{robotID}]行先[{nodeID}]理由[{taskDetail.Data.Detail.ErrorReason}]";
                            break;
                        default:
                            isTaskEnd = true;
                            message = $"AGV移動が失敗しました。AGV[{robotID}]行先[{nodeID}]理由[{taskDetail.Data.Detail.ErrorReason}]";
                            break;
                    }

                } while (!isTaskEnd);

                if (isShowMessageBox)
                    showInfoMessageBox($"{message}");
                else
                    logger.Info($"{message}");
            });
        }

        #region メッセージボックス関連

        /// <summary>
        /// Infoのメッセージボックスを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showInfoMessageBox(string message)
        {
            //ログ表示の際に改行文字を空白に置き換える
            logger.Info(message.Replace(Environment.NewLine, string.Empty));
            return MessageBox.Show(message, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Errorのメッセージボックスを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showErrorMessageBox(string message)
        {
            logger.Error(message);
            return MessageBox.Show(message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// メッセージボックスを表示します
        /// </summary>
        /// <param name="isSuccess">Infoの場合true,Errorの場合falseを入れる</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showMessageBox(bool isSuccess, string message)
        {
            return isSuccess
                ? showInfoMessageBox(message)
                : showErrorMessageBox(message);
        }
        /// <summary>
        /// 確認のメッセージボックスを表示します
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        private DialogResult showCheckMessage(string message)
        {
            return MessageBox.Show(message, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        #endregion メッセージボックス関連

        private void btnLoadNodeData_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            var openFileDialog = new OpenFileDialog
            {
                Title = "ノード設定ファイルを選択",
                InitialDirectory = Path.GetDirectoryName($"NodeDataSample/設備とノード.csv"),
                Filter = "CSVファイル|*.csv|すべてのファイル|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                try
                {
                    var nodeDatas = new List<NodeData>();
                    var enc = MapCommands.GetEncoding(filePath);
                    var allLines = File.ReadAllLines(filePath, enc).ToList();
                    allLines.ForEach(x =>
                    {
                        var splitX = x.Split(',').ToList();
                        var nodeID = splitX[1].Trim();
                        if (nodeID.All(char.IsDigit))
                        {
                            nodeDatas.Add(new NodeData(name: splitX[0], nodeID: nodeID));
                        }
                    });
                    param.NodeDatas = nodeDatas;
                    updateDgvMove(param.NodeDatas);
                    showInfoMessageBox($"ノードデータを更新しました。[{filePath}]");
                }
                catch (Exception ex)
                {
                    showErrorMessageBox($"ノードデータ読込時にエラーが発生しました。{ex.ToString()}");
                }
            }
            else
            {
                logger.Info("設定ファイルの選択がキャンセルされました。");
            }
            openFileDialog.Dispose();
        }

        /// <summary>
        /// ノード情報DGVを一旦クリアしてから更新します。
        /// </summary>
        /// <param name="nodeDatas">ノード情報リスト</param>
        private void updateDgvMove(List<NodeData> nodeDatas)
        {
            dgvMove.Rows.Clear();
            nodeDatas.ForEach(x =>
            {
                addDgvMove(x);
            });
            dgvMove.AutoResizeColumns();
        }
        /// <summary>
        /// ノード情報DGVに追加する
        /// </summary>
        /// <param name="nodeData">ノード情報</param>
        private void addDgvMove(NodeData nodeData)
        {
            dgvMove.Rows.Add(nodeData.Name, nodeData.NodeID, "移動", "移動", "作成", "編集");
        }

        private void updateParam()
        {            
            param.PodID = txtPodID.GetText();
            param.RobotID = txtRobotID.GetText();
        }
    }
}
