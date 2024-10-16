using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;
using MujinAGVDemo.Command;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MujinAGVDemo
{
    public partial class frmLight : Form
    {
        public frmLight()
        {
            InitializeComponent();
        }
        #region Const
        /// <summary>
        /// 設定ファイルのデフォルトパス
        /// </summary>
        const string defaultSettingPath = @"Setting/ParamSetting.xml";
        /// <summary>
        /// ロボットグループ設定のパス
        /// </summary>
        const string robotGroupSettingPath = @"Setting/RobotGroupSetting.csv";

        /// <summary>
        /// ノード情報DGVの列番号
        /// </summary>
        enum NodeDgvColumn : int
        {
            /// <summary>
            /// 名称
            /// </summary>
            Name = 0,
            /// <summary>
            /// ノードID
            /// </summary>
            Node = 1,
            /// <summary>
            /// AGV移動
            /// </summary>
            MoveAGV = 2,
            /// <summary>
            /// 棚搬送
            /// </summary>
            MovePod = 3,
            /// <summary>
            /// 棚追加
            /// </summary>
            AddPod = 4,
            /// <summary>
            /// データ編集
            /// </summary>
            Edit = 5,
        }
        /// <summary>
        /// 移動指示CSVの列番号
        /// </summary>
        enum MovingCSVColumn : int
        {
            /// <summary>
            /// ノードIDのインデックス
            /// </summary>
            Node = 0,
            /// <summary>
            /// ターンモードのインデックス
            /// </summary>
            TurnMode = 1,
            /// <summary>
            /// アンロードモードのインデックス
            /// </summary>
            UnloadMode = 2,
            /// <summary>
            /// 棚を使用するかのインデックス
            /// </summary>
            WithPod = 3,
            /// <summary>
            /// 棚IDのインデックス
            /// </summary>
            PodID = 4,
            /// <summary>
            /// タスクペアの終端かのインデックス
            /// </summary>
            IsEnd = 5,
            /// <summary>
            /// タスク後待機時間のインデックス
            /// </summary>
            WaitTime = 6,
            /// <summary>
            /// ロボットグループのインデックス
            /// </summary>
            RobotGroup = 7,
        }
        enum GroupCSVColumn : int
        {
            ID=0,
            Name=1,
        }
        enum AGVcommands : int
        {
            棚追加 = 0,
            棚削除 = 1,
            棚位置セット = 2,
            全棚削除 = 3,
            占有解除 = 4,
            占有 = 5,
            充電 = 6,
            タスクキャンセル = 7,
            リフトアップ = 8,
            リフトダウン = 9,
            AGV情報 = 10,
            全占有切替 = 11,
            天板回転 = 12,
            AGV移動 = 13,
            棚搬送 = 14,
            棚アップダウン = 15,
            一時停止 = 16,
            運行 = 17,
            AGV旋回 = 18,
        };
        private const int ON = 1;
        private const int OFF = 0;

        /// <summary>
        /// ログディレクトリのパス
        /// </summary>
        private const string logDirPath = @"logs";
        #endregion Const

        #region Private Parameter
        /// <summary>
        /// 設定ファイルのパス
        /// </summary>
        private string settingPath = defaultSettingPath;
        private ParamSettings param;
        private bool isStop = false;
        private readonly FileIO fileIO = new FileIO();
        public readonly Logger logger = LogManager.GetLogger("ProgramLogger");
        private CancellationTokenSource source = new CancellationTokenSource();
        private List<string> nodeNames = new List<string>();
        List<RobotGroup> RobotGroups = new List<RobotGroup>();
        Stopwatch stopwatch = new Stopwatch();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        /// <summary>
        /// グループ指定か（false:AGV指定　true:ロボットグループ指定）
        /// </summary>
        bool isAuto = false;

        #endregion Private Parameter

        #region Public Paramater

        public CommandFactory Factory;

        private int robotFaceIndex = 4;

        #endregion Public Paramater

        #region Deligate

        delegate void ChangeDgvDelegate();

        #endregion Deligate

        #region Event

        private void frmLight_Load(object sender, EventArgs e)
        {
            this.Text = $"AGVデモソフト {Application.ProductVersion}";
            if (!fileIO.TryLoadSetting(settingPath, out param))
            {
                param = new ParamSettings();
                fileIO.SaveSetting(defaultSettingPath, param);

                return;
            }
            try
            {
                tabControl1.SelectedIndex = 2;
                updateControl();
                checkBoxIsStop.Checked = isStop;

                txtPod1.Text = param.Pod1Param.PodID;
                txtTempNode1.Text = param.Pod1Param.TempNodeID;
                changeCmbItem(txtTempNode1, cmbTempNode);
                txtNode1.Text = param.Pod1Param.NodeID;
                changeCmbItem(txtNode1, cmbNode1);

                txtPod2.Text = param.Pod2Param.PodID;
                changeCmbItem(txtNode2, cmbNode2);
                txtTempNode2.Text = param.Pod2Param.TempNodeID;
                txtNode2.Text = param.Pod2Param.NodeID;

                cmbPodFace.SelectedItem = "指定しない";
                cmbRobotFace.SelectedItem = "指定しない";

                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                dispatcherTimer.Tick += DispatcherTimer_Tick;

                cmbCommand.Items.AddRange(Enum.GetNames(typeof(AGVcommands)));
                cmbCommand.SelectedIndex = (int)AGVcommands.棚位置セット;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }

            RobotGroups.Clear();
            if (File.Exists(robotGroupSettingPath))
            {
                var lines= File.ReadAllLines(robotGroupSettingPath,Encoding.GetEncoding("Shift-Jis"));
                for (var i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                        continue;
                    var s = lines[i].Split(',').ToList();
                    RobotGroups.Add(new RobotGroup(s[(int)GroupCSVColumn.ID].Trim(), s[(int)GroupCSVColumn.Name].Trim()));
                }
            }
            System.Diagnostics.Debug.WriteLine("");
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            var result = stopwatch.Elapsed;
            lblRunningTime.Text = $"動作時間[{result.TotalSeconds:N1}]sec";
        }


        private void btnAddPod_Click(object sender, EventArgs e)
        {
            addPod();
        }

        private void btnRemovePod_Click(object sender, EventArgs e)
        {
            removePod();
        }

        private void btnRemovePodAll_Click(object sender, EventArgs e)
        {
            updateParam();
            var (isSuccess, messages) = Command.MapCommands.RemoveAllShelfs(param.ServerIP, param.WarehouseID);
            var message = new StringBuilder();
            messages.ToList().ForEach(x => message.Append(x));
            showMessageBox(isSuccess, message.ToString());
        }

        private void btnSetPodPos_Click(object sender, EventArgs e)
        {
            updateParam();
            var (isSuccess, message) = Command.MapCommands.SetPodPosition(param.ServerIP, param.WarehouseID, param.PodID, param.NodeID);

            showMessageBox(isSuccess, message);
        }

        private void btnUnSetOwner_Click(object sender, EventArgs e)
        {
            if (showCheckMessage($"AGV[{param.RobotID}]をロック解除しますか？") != DialogResult.OK)
            {
                return;
            }
            unsetOwner();
        }

        private void btnSetOwner_Click(object sender, EventArgs e)
        {
            if (showCheckMessage($"AGV[{param.RobotID}]をロックしますか？") != DialogResult.OK)
            {
                return;
            }
            setOwner();
        }


        private void checkBoxIsStop_CheckedChanged(object sender, EventArgs e)
        {
            var serverIP =
                param.ServerIP;
            var warehouseID =
                param.WarehouseID;
            var robotID =
                param.RobotID;

            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }

            isStop = !isStop;
            //AGVを停止させる
            if (isStop == false)
            {
                //AGV停止指示
                factory.Create(new PauseRobotParam(robotID, isAll: true)).DoAction();
                //ボタン表示の変更
                checkBoxIsStop.Text = "AGV運行";
                checkBoxIsStop.BackColor = Color.GreenYellow;
            }
            //AGVを運航させる
            else
            {
                //ボタン表示の変更
                checkBoxIsStop.Text = "AGV停止";
                checkBoxIsStop.BackColor = Color.Red;
                //AGV運航指示
                factory.Create(new ResumeRobotParam(robotID, isAll: true)).DoAction();
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            saveSetting();
        }

        private void saveSetting()
        {
            updateParam();
            if (settingPath != defaultSettingPath)
            {
                fileIO.SaveSetting(defaultSettingPath, param);
            }
            fileIO.SaveSetting(settingPath, param);
            showInfoMessageBox($"設定ファイルを保存しました。{Environment.NewLine}保存先:{Path.GetFullPath(settingPath)}");
        }

        private void btnLoadSetting_Click(object sender, EventArgs e)
        {
            if (!fileIO.TryLoadSetting(settingPath, out param))
            {
                btnLoadSetting.BackColor = Color.Red;
                return;
            }
            var message =
                $"設定ファイルの読込に成功しました。{Path.GetFullPath(settingPath)}";
            logger.Info(message);
            btnLoadSetting.BackColor = Color.Green;
            showInfoMessageBox(message);
            updateControl();
        }

        private void btnOpenParamSettings_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "設定ファイルを選択",
                InitialDirectory = Path.GetDirectoryName(settingPath),
                Filter = "XMLファイル|*.xml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                settingPath = openFileDialog.FileName;

                if (fileIO.TryLoadSetting(settingPath, out param))
                {
                    updateControl();
                    updateParam();
                    logger.Info($"設定ファイルを選択しました。[{openFileDialog.FileName}]");
                }
            }
            else
            {
                logger.Info("設定ファイルの選択がキャンセルされました。");
            }
            openFileDialog.Dispose();
        }


        /// <summary>
        /// 通常版フォームを開きます
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpenMainForm_Click(object sender, EventArgs e)
        {
            var frmMain = new frmMain(param);
            frmMain.Show();
        }
        /// <summary>
        /// ノード指定移動DGVのセルをクリックした際のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void dgvMove_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //行の範囲外の時は終了
            if (e.RowIndex < 0 || param.NodeDatas.Count <= e.RowIndex)
            {
                return;
            }
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            try
            {
                //AGV移動をクリック
                if (e.ColumnIndex == (int)NodeDgvColumn.MoveAGV)
                {
                    source = new CancellationTokenSource();

                    var robotFace = Direction.NoSelect;
                    switch (cmbRobotFace.SelectedIndex)
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
                                          nodeID: dgvMove[(int)NodeDgvColumn.Node, e.RowIndex].Value.ToString(),
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
                else if (e.ColumnIndex == (int)NodeDgvColumn.MovePod)
                {
                    source = new CancellationTokenSource();
                    var robotFace = Direction.NoSelect;
                    switch (cmbRobotFace.SelectedIndex)
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
                    switch (cmbPodFace.SelectedIndex)
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
                                                     nodeID: dgvMove[(int)NodeDgvColumn.Node, e.RowIndex].Value.ToString(),
                                                     podID: param.PodID,
                                                     robotFace: robotFace,
                                                     podFace: podFace,
                                                     unload: param.Unload);
                    await task;

                    showMessageBox(isSuccess: task.Result.result,
                                   message: task.Result.message);
                }
                //編集をクリック
                else if (e.ColumnIndex == (int)NodeDgvColumn.Edit)
                {
                    var name = dgvMove[(int)NodeDgvColumn.Name, e.RowIndex].Value.ToString();
                    var nodeID = dgvMove[(int)NodeDgvColumn.Node, e.RowIndex].Value.ToString();

                    var target = param.NodeDatas[e.RowIndex];
                    target.Name = name;
                    target.NodeID = nodeID;

                    fileIO.SaveSetting(settingPath, param);
                }
                //棚作成をクリック
                else if (e.ColumnIndex == (int)NodeDgvColumn.AddPod)
                {
                    var nodeID = dgvMove[(int)NodeDgvColumn.Node, e.RowIndex].Value.ToString();
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
        /// 「連続AGV移動」クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCycleMoveRobot_Click(object sender, EventArgs e)
        {
            source.Cancel();
            source = new CancellationTokenSource();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }

            try
            {
                param.NodeDatas.ForEach(x =>
                {
                    if (source.IsCancellationRequested)
                        return;
                    moveRobot(Factory, param.RobotID, x.NodeID);
                });
                showInfoMessageBox("移動終了しました。");
            }
            catch (Exception ex)
            {
                showErrorMessageBox($"エラーが発生しました。{ex.ToString()}");
            }
        }
        /// <summary>
        /// 「連続棚移動」クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCycleMovePod_Click(object sender, EventArgs e)
        {
            source.Cancel();
            source = new CancellationTokenSource();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            param.NodeDatas.ForEach(x =>
            {
                if (source.IsCancellationRequested)
                    return;
                movePod(factory: Factory,
                        robotID: param.RobotID,
                        nodeID: x.NodeID,
                        podID: param.PodID);
            });
        }

        private void chkTurn_CheckedChanged(object sender, EventArgs e)
        {
            param.TurnMode = chkTurn.Checked ? ON : OFF;
        }

        private void chkUnload_CheckedChanged(object sender, EventArgs e)
        {
            param.Unload = chkUnload.Checked ? ON : OFF;
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            var chargeResult = (ChargeRobotReturnMessage)Factory.Create(new ChargeRobotParam(param.RobotID, param.ChargeZoneID)).DoAction();

            var result = chargeResult.ReturnCode == 0;
            var messages = $"AGV[{param.RobotID}]への充電指示が[{(result ? "成功" : "失敗")}]しました。[{chargeResult.ReturnMsg}]";

            if (chkIsShowMessage.Checked)
            {
                showMessageBox(result, messages);
            }
            else
            {
                logger.Info(messages);
            }

        }

        private void btnTaskCancel_Click(object sender, EventArgs e)
        {
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            var taskStatusList = new List<TaskStatuses>()
            {
                TaskStatuses.Init,
                TaskStatuses.Ready,
                TaskStatuses.Running,
                TaskStatuses.Canceling,
                //TaskStatuses.Success,
                TaskStatuses.Fail,
                //TaskStatuses.Canceled,
                TaskStatuses.NoDefine,
            };
            var getTaskResult = (GetAllTaskSelectStatusFromDBReturnMessage)Factory.Create(new GetAllTaskSelectStatusFromDBParam(taskStatusList)).DoAction();
            var taskList = getTaskResult.GetAllTaskSelectStatusList
                .Where(x => x.RobotID == param.RobotID)
                .ToList();

            taskList.ForEach(x =>
            {
                var cancelTaskResult = (CancelTaskReturnMessage)Factory.Create(new CancelTaskParam(x.TaskID)).DoAction();
            });

        }

        private void btnLiftUp_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            var (isSuccess, messages) = Command.MapCommands.LiftUpRobot(factory: Factory, robotID: param.RobotID);

            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, messages);
            }
            else
            {
                logger.Info(messages);
            }
        }

        private void btnLiftDown_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            var (isSuccess, messages) = Command.MapCommands.LiftDownRobot(factory: Factory, robotID: param.RobotID);
            //if (!isSuccess)
            //{
            //    showErrorMessageBox(messages);
            //}
            //else
            //{
            //    showInfoMessageBox(messages);
            //}
            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, messages);
            }
            else
            {
                logger.Info(messages);
            }
        }

        private void mnuOpenLog_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(logDirPath))
            {
                showErrorMessageBox($"{Path.GetFullPath(logDirPath)}が見つかりません。");
                return;
            }
            System.Diagnostics.Process.Start("EXPLORER.EXE", logDirPath);
        }

        private void btnGetAGVData_Click(object sender, EventArgs e)
        {
            try
            {
                if (Factory == null)
                {
                    Factory = new CommandFactory(rcsIP: param.ServerIP, warehouseID: param.WarehouseID);
                }

                var getRobotListRet = (GetRobotListFromDBReturnMessage)Factory.Create(new GetRobotListFromDBParam(isOnlineRobotOnly: true)).DoAction();

                var rbList = getRobotListRet.Data?.RobotList;
                var message = new StringBuilder();
                rbList.ForEach(x =>
                {
                    message.AppendLine($"AGV[{x.RobotID}] TaskID[{x.TaskID}] TaskType[{x.TaskType}] TaskStatus[{x.TaskStatus}]");
                });
                showInfoMessageBox(message.ToString());

            }
            catch (Exception ex)
            {
                showErrorMessageBox(ex.ToString());
            }
        }

        private void chkAllSet_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Factory == null)
                {
                    Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
                }
                if (!chkAllSet.Checked)
                {
                    chkAllSet.Text = "全占有解除";
                    chkAllSet.BackColor = Color.Red;

                    var (isSuccess, message) = Command.MapCommands.SetOwnerAll(Factory);
                }
                else
                {
                    chkAllSet.Text = "全占有";
                    chkAllSet.BackColor = Color.GreenYellow;
                    var (isSuccess, message) = Command.MapCommands.UnsetOwnerAll(Factory);
                }
            }
            catch (Exception ex)
            {
                showErrorMessageBox(ex.ToString());
            }
        }

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

        private async void btnExchangePod_ClickAsync(object sender, EventArgs e)
        {
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }

            try
            {
                param.Pod1Param.PodID = txtPod1.Text;
                param.Pod1Param.NodeID = txtNode1.Text;
                param.Pod1Param.TempNodeID = txtTempNode1.Text;

                param.Pod2Param.PodID = txtPod2.Text;
                param.Pod2Param.NodeID = txtNode2.Text;
                param.Pod2Param.TempNodeID = string.Empty;

                var groupID = textBoxGroupID.Text;

                var startTime = DateTime.Now;

                await ExchangePod(
                    factory: Factory,
                    groupID: groupID,
                    pod1Param: param.Pod1Param,
                    pod2Param: param.Pod2Param
                    );
                var endTime = DateTime.Now;
                var movingTime = endTime - startTime;

                showInfoMessageBox($"棚交換が完了しました。経過時間[{movingTime.ToString(@"hh\時\間mm\分ss\秒ff")}]");
            }
            catch (Exception ex)
            {
                showErrorMessageBox($"棚交換でエラーが発生しました。{ex.ToString()}");
            }
        }

        private void btnChangePodID_Click(object sender, EventArgs e)
        {
            (txtPod2.Text, txtPod1.Text) = (txtPod1.Text, txtPod2.Text);
        }

        private void cmbTempNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var node = param.NodeDatas.Where(x => x.Name == cmbTempNode.SelectedItem.ToString()).FirstOrDefault();
            if (node != null)
            {
                txtTempNode1.Text = node.NodeID;
            }
        }

        private void cmbNode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var node = param.NodeDatas.Where(x => x.Name == cmbNode1.SelectedItem.ToString()).FirstOrDefault();
            if (node != null)
            {
                txtNode1.Text = node.NodeID;
            }
        }

        private void cmbNode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var node = param.NodeDatas.Where(x => x.Name == cmbNode2.SelectedItem.ToString()).FirstOrDefault();
            if (node != null)
            {
                txtNode2.Text = node.NodeID;
            }
        }

        private void mnuMoveCT_Click(object sender, EventArgs e)
        {
            MoveCT();
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
                CachingCall = (obj, ev) =>
                {
                }
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

        private void btnMoveCancel_Click(object sender, EventArgs e)
        {
            source.Cancel();
            logger.Info("連続動作キャンセルをクリックしました。");
        }

        #endregion Event

        #region Method

        /// <summary>
        /// パラメータをコントロールに反映する
        /// </summary>
        private void updateControl()
        {
            cmbServerIP.Text = param.ServerIP;
            cmbWarehouseID.Text = param.WarehouseID;
            cmbLayoutID.Text = param.LayoutID;
            cmbPodID.Text = param.PodID;
            cmbNodeID.Text = param.NodeID;
            cmbRobotID.Text = param.RobotID;
            textBoxStationListPath.Text = param.StationListPath;
            numRepeatCount.Value = param.RepeatCount;
            cmbChargeZoneID.Text = param.ChargeZoneID;
            chkTurn.Checked = param.TurnMode == ON;
            chkUnload.Checked = param.Unload == ON;
            textBoxGroupID.Text = param.RobotGroupID;
            AddHistoryAll();

            updateDgvMove(param.NodeDatas);
        }
        /// <summary>
        /// コントロールの内容をパラメータに反映する
        /// </summary>
        private void updateParam()
        {
            AddHistoryAll();

            param.ServerIP = cmbServerIP.Text;
            param.WarehouseID = cmbWarehouseID.Text;
            param.LayoutID = cmbLayoutID.Text;
            param.PodID = cmbPodID.Text;
            param.NodeID = cmbNodeID.Text;
            param.RobotID = cmbRobotID.Text;
            param.StationListPath = textBoxStationListPath.Text;
            param.RepeatCount = (int)numRepeatCount.Value;
            param.ChargeZoneID = cmbChargeZoneID.Text;
            param.RobotGroupID = textBoxGroupID.Text;
            param.Pod1Param.PodID = txtPod1.Text;
            param.Pod1Param.NodeID = txtNode1.Text;
            param.Pod1Param.TempNodeID = txtTempNode1.Text;

            param.Pod2Param.PodID = txtPod2.Text;
            param.Pod2Param.NodeID = txtNode2.Text;
            param.Pod2Param.TempNodeID = string.Empty;
        }
        private void AddHistory(System.Windows.Forms.ComboBox comboBox)
        {
            if (!comboBox.Items.Contains(comboBox.Text))
            {
                comboBox.Items.Add(comboBox.Text);
            }
        }
        private void AddHistoryAll()
        {
            AddHistory(cmbServerIP);
            AddHistory(cmbWarehouseID);
            AddHistory(cmbLayoutID);
            AddHistory(cmbPodID);
            AddHistory(cmbNodeID);
            AddHistory(cmbRobotID);
            AddHistory(cmbChargeZoneID);
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
        /// <summary>
        /// 棚を削除します
        /// </summary>
        private void removePod()
        {
            updateParam();
            var serverIP = param.ServerIP;
            var warehouseID = param.WarehouseID;
            var podID = param.PodID;


            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }
            try
            {
                var removePodResult = factory.Create(new RemovePodParam(podID)).DoAction();
                var logMessage = $"棚削除結果:[{removePodResult.ReturnMsg}] リターンコード:[{removePodResult.ReturnCode}] 棚ID:[{podID}]";
                showInfoMessageBox($"{logMessage}");
            }
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        /// <summary>
        /// AGVの占有状態を解除します
        /// </summary>
        /// <param name="robotID">AGVの号機</param>
        private async void unsetOwner(string robotID, int repeat = 5)
        {
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            source = new CancellationTokenSource();

            bool isSuccess;
            var count = 0;
            string message;
            do
            {
                count++;
                var task = AsyncCommands.UnsetOwner(factory, robotID);
                var result = await task;
                isSuccess = result.Item1;
                message = result.Item2;
                if (!isSuccess)
                {
                    logger.Info($"[{count}回目]{message}");
                    await Task.Delay(1000);
                }

            } while (!isSuccess
            && !source.Token.IsCancellationRequested
            && count < repeat);

            showMessageBox(isSuccess, message);

        }
        /// <summary>
        /// AGVの占有状態を解除します
        /// </summary>
        private void unsetOwner()
        {
            var robotID = param.RobotID;
            unsetOwner(robotID);

        }
        /// <summary>
        /// AGVを占有します
        /// </summary>
        private void setOwner()
        {
            var robotID = param.RobotID;
            setOwner(robotID);
        }
        private void setOwner(string robotID)
        {
            var factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            var (isSuccess, message) = Command.MapCommands.SetOwner(factory, robotID);
            showMessageBox(isSuccess, message);
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
        /// <summary>
        /// AGV移動を行います
        /// </summary>
        /// <param name="factory">ファクトリ</param>
        /// <param name="param">AGV移動のパラメータ</param>
        /// <returns>成功か、メッセージ</returns>
        private (bool isSuccess, string message) moveRobot(CommandFactory factory, MoveRobotParam param)
        {
            var result = (MoveRobotReturnMessage)factory.Create(param).DoAction();
            var logMessage = $"AGV移動結果:[{result.ReturnMsg}] リターンコード:[{result.ReturnCode}] robotID:[{param.RobotID}] 移動先:[{param.DesID}]";
            showInfoMessageBox($"{logMessage}");
            return (result.ReturnMsg == "succ", result.ReturnMsg);
        }
        /// <summary>
        /// AGV移動を行います
        /// </summary>
        /// <param name="factory">ファクトリ</param>
        /// <param name="robotID">ロボットID</param>
        /// <param name="nodeID">ノードID</param>
        /// <returns>成功か、メッセージ</returns>
        private (bool isSuccess, string message) moveRobot(CommandFactory factory, string robotID, string nodeID)
        {
            var moveRobotParam = new MoveRobotParam(robotID: robotID,
                                           desMode: DestinationModes.NodeID,
                                           desID: nodeID)
            {
                //CachingCallがnullだと例外が発生するため何もしないイベントを追加
                CachingCall = (obj, e) =>
                {
                }
            };
            return moveRobot(factory, moveRobotParam);
        }
        /// <summary>
        /// 棚移動を行います。
        /// </summary>
        /// <param name="factory">ファクトリ</param>
        /// <param name="param">棚移動パラメータ</param>
        /// <returns>成功か、メッセージ</returns>
        private (bool isSuccess, string message) movePod(CommandFactory factory, MovePodParam param)
        {
            var result = (MovePodReturnMessage)factory.Create(param).DoAction();
            var logMessage = $"棚移動結果:[{result.ReturnMsg}] リターンコード:[{result.ReturnCode}] robotID:[{param.RobotID}] 移動先:[{param.DesID}] 棚ID:[{param.PodID}]";
            showInfoMessageBox($"{logMessage}");
            return (result.ReturnMsg == "succ", result.ReturnMsg);
        }
        /// <summary>
        /// 棚移動を行います。
        /// </summary>
        /// <param name="factory">ファクトリ</param>
        /// <param name="robotID">ロボットID</param>
        /// <param name="nodeID">ノードID</param>
        /// <param name="podID">棚ID</param>
        /// <param name="podFace">棚の向き -255:指定なし　0:北,1.57:東,3.14:南,4.71:西</param>
        /// <returns>成功か、メッセージ</returns>
        private (bool isSuccess, string message) movePod(CommandFactory factory, string robotID, string nodeID, string podID, double podFace = -255)
        {
            var movePodParam = new MovePodParam(robotID: robotID,
                                       podID: podID,
                                       desMode: DestinationModes.StorageID,
                                       desID: nodeID,
                                       turnMode: param.TurnMode,
                                       unload: param.Unload,
                                       podFace: podFace);
            return movePod(factory, movePodParam);
        }
        /// <summary>
        /// ノード情報DGVに追加する
        /// </summary>
        /// <param name="nodeData">ノード情報</param>
        private void addDgvMove(NodeData nodeData)
        {
            dgvMove.Rows.Add(nodeData.Name, nodeData.NodeID, "移動", "移動", "作成", "編集");
        }
        /// <summary>
        /// ノード情報DGVを一旦クリアしてから更新します。
        /// </summary>
        /// <param name="nodeDatas">ノード情報リスト</param>
        private void updateDgvMove(List<NodeData> nodeDatas)
        {
            dgvMove.Rows.Clear();
            nodeNames.Clear();
            cmbNode1.Items.Clear();
            cmbNode2.Items.Clear();
            cmbTempNode.Items.Clear();
            nodeDatas.ForEach(x =>
            {
                addDgvMove(x);

                nodeNames.Add(x.Name);
                cmbNode1.Items.Add(x.Name);
                cmbNode2.Items.Add(x.Name);
                cmbTempNode.Items.Add(x.Name);
            });
            dgvMove.AutoResizeColumns();
        }

        /// <summary>
        /// 棚交換タスク
        /// 棚1を退避させた後に、棚1と棚2の移動タスクを同時に実行する。
        /// 棚1の退避先が空白なら退避動作なしで実行する
        /// </summary>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="groupID">AGVのグループID</param>
        /// <param name="pod1Param">棚1(空)のパラメータ</param>
        /// <param name="pod2Param">棚2(充)のパラメータ</param>
        /// <returns>棚交換タスク</returns>
        private async Task ExchangePod(CommandFactory factory, string groupID, ExchangePodParam pod1Param, ExchangePodParam pod2Param)
        {
            if (pod1Param.TempNodeID != string.Empty)
            {
                var tempParam1 = new MovePodAutoSelectAGVParam(robotGroupID: groupID,
                                                             podID: pod1Param.PodID,
                                                             desMode: DestinationModes.StorageID,
                                                             unload: 0,
                                                             desID: pod1Param.TempNodeID
                                                             );
                await MovePodAuto(factory, tempParam1);
            }

            var moveParam2 = new MovePodAutoSelectAGVParam(robotGroupID: groupID,
                                                                 podID: pod2Param.PodID,
                                                                 desMode: DestinationModes.StorageID,
                                                                 desID: pod2Param.NodeID);

            var moveParam1 = new MovePodAutoSelectAGVParam(robotGroupID: groupID,
                                                             podID: pod1Param.PodID,
                                                             desMode: DestinationModes.StorageID,
                                                             desID: pod1Param.NodeID
                                                             );

            await Task.WhenAll(new Task[] { MovePodAuto(factory, moveParam1), MovePodAuto(factory, moveParam2) });
        }
        /// <summary>
        /// グループ指定のAGV移動タスク
        /// </summary>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="param">移動用パラメータ</param>
        /// <returns>グループ指定のAGV移動タスク</returns>
        private async Task MovePodAuto(CommandFactory factory, MovePodAutoSelectAGVParam param)
        {
            var moveTask = new Task(() =>
            {
                var returnMessage = factory.Create(param).DoAction() as MovePodAutoSelectAGVReturnMessage;
            });
            moveTask.Start();
            await moveTask.ConfigureAwait(true);
            return;
        }

        private void MoveCT()
        {
            source.Cancel();
            source = new CancellationTokenSource();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            if (source.IsCancellationRequested)
                return;
            //空パレ位置
            var node1 = "166598818737";
            //回転位置
            var node2 = "166598818752";
            //退避先
            var node3 = "166598818782";
            //充パレ位置
            var node4 = "166598818766";
            //空パレ回収位置
            var node5 = "166598818781";
            try
            {
                var preStartTime = DateTime.Now;
                logger.Info($"準備開始");
                //0
                Factory.Create(new MoveRobotParam(param.RobotID, DestinationModes.NodeID, node1, robotFace: Direction.East)
                {
                    CachingCall = (obj, e) =>
                    {
                    }
                }).DoAction();
                logger.Info($"準備終了");
                var startTime = DateTime.Now;
                logger.Info($"本番動作開始");
                //1
                Factory.Create(new MovePodParam(param.RobotID, txtPod1.Text, DestinationModes.StorageID, node1, unload: 0)).DoAction();
                //2,3
                Factory.Create(new MovePodParam(param.RobotID, txtPod1.Text, DestinationModes.StorageID, node2, podFace: Direction.East, unload: 0)).DoAction();
                //4,5
                Factory.Create(new MovePodParam(param.RobotID, txtPod1.Text, DestinationModes.StorageID, node3, unload: 1)).DoAction();
                //6
                Factory.Create(new MovePodParam(param.RobotID, txtPod2.Text, DestinationModes.StorageID, node4, unload: 0)).DoAction();
                //7,8
                Factory.Create(new MovePodParam(param.RobotID, txtPod2.Text, DestinationModes.StorageID, node2, podFace: Direction.East, unload: 0)).DoAction();
                //9,10
                Factory.Create(new MovePodParam(param.RobotID, txtPod2.Text, DestinationModes.StorageID, node1, unload: 1)).DoAction();
                logger.Info($"本番動作終了");
                var endTime = DateTime.Now;
                logger.Info($"回収開始");
                //11,12,13
                Factory.Create(new MovePodParam(param.RobotID, txtPod1.Text, DestinationModes.StorageID, node5, unload: 1)).DoAction();
                logger.Info($"回収終了");
                var afterEndTime = DateTime.Now;

                var span = endTime - startTime;
                showInfoMessageBox($"動作が完了しました。" +
                    $"\n準備動作[{(startTime - preStartTime).ToString(@"hh\時\間mm\分ss\秒ff")}]" +
                    $"\n本番動作[{span.ToString(@"hh\時\間mm\分ss\秒ff")}]" +
                    $"\n回収動作[{(afterEndTime - endTime).ToString(@"hh\時\間mm\分ss\秒ff")}]");
            }
            catch (Exception ex)
            {
                showErrorMessageBox($"動作でエラーが発生しました。{ex.ToString()}");
            }
        }

        private static void dragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            var sFileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (sFileName.Length <= 0)
            {
                return;
            }

            // ドロップ先がTextBoxであるかチェック
            var TargetTextBox = sender as TextBox;

            if (TargetTextBox == null)
            {
                // TextBox以外のためイベントを何もせずイベントを抜ける。
                return;
            }

            // 現状のTextBox内のデータを削除
            TargetTextBox.Text = "";

            // TextBoxドラックされた文字列を設定
            TargetTextBox.Text = sFileName[0]; // 配列の先頭文字列を設定
        }


        private static void dragEnter(DragEventArgs e)
        {
            // ドラッグ中のファイルやディレクトリの取得
            var sFileName = (string[])e.Data.GetData(DataFormats.FileDrop);

            //ファイルがドラッグされている場合、
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 配列分ループ
                foreach (var sTemp in sFileName)
                {
                    // ファイルパスかチェック
                    if (File.Exists(sTemp) == false)
                    {
                        // ファイルパス以外なので何もしない
                        return;
                    }
                    else
                    {
                        break;
                    }
                }

                // カーソルを[+]へ変更する
                // ここでEffectを変更しないと、以降のイベント（Drop）は発生しない
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void changeCmbItem(TextBox textBox, ComboBox comboBox)
        {
            var node = param.NodeDatas.Where(x => x.NodeID == textBox.Text).FirstOrDefault();
            if (node != null)
            {
                comboBox.SelectedItem = node.Name;
            }
        }
        #endregion Method

        #region Class

        #endregion Class

        private async void btnMoveCSV_Click(object sender, EventArgs e)
        {
            logger.Info("連続動作開始");
            stopwatch.Restart();
            dispatcherTimer.Start();
            updateParam();
            var stationListPath = param.StationListPath;
            var paramSetting = this.param;
            var robotID = param.RobotID;
            var podID = param.PodID;

            await movePodRotate(stationListPath, paramSetting, robotID, podID);
            unsetOwner(robotID);

            if (dispatcherTimer.IsEnabled)
                dispatcherTimer.Stop();
            if (stopwatch.IsRunning)
                stopwatch.Stop();
        }

        private async Task movePodRotate(string stationListPath, ParamSettings param, string robotID, string podID)
        {
            source = new CancellationTokenSource();
            var cancelToken = source.Token;

            if (!fileIO.TryGetAllLines(stationListPath, out var allLines))
            {
                showErrorMessageBox("CSVファイルの読込に失敗しました。");
                return;
            }

            //事前に占有する処理
            if (podID == string.Empty)
            {
                if (Factory == null)
                {
                    Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
                }

                var rbReturn = (GetRobotListReturnMessage)Factory.Create(new GetRobotListParam()).DoAction();
                var rb = rbReturn.Data?.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
                if (rb == null)
                {
                    return;
                }

                switch (rb.Owner)
                {
                    case "TES":
                        var setOwnerResult = Factory.Create(new SetOwnerParam(robotID)).DoAction();
                        break;
                    case "SUPER":
                        logger.Error($"AGV{robotID}がHetuで占有されているため実行しません。");
                        return;
                    default:
                        break;
                }

            }

            var nowCount = 1;
            var isInfinityLoop = param.RepeatCount == 0;
            var isRunning =
                //無限ループモードまたは実行回数が繰り返し回数未満
                (isInfinityLoop || nowCount < param.RepeatCount)
                //かつキャンセルされていない
                && !cancelToken.IsCancellationRequested;
            do
            {
                if (cancelToken.IsCancellationRequested)
                {
                    showInfoMessageBox($"連続動作完了:{lblRunningTime.Text}");
                    return;
                }
                logger.Info(string.Format("{0}回目開始", nowCount));
                //同時に実行するタスクのリスト
                var taskList = new List<Task>();
                for (var rowCount = 0; rowCount < allLines.Count; rowCount++)
                {
                    var splitLine = allLines[rowCount].Split(',').ToList();
                    var nodeID = splitLine[(int)MovingCSVColumn.Node].Trim();
                    if (!nodeID.All(char.IsDigit))
                    {
                        //logger.Info($"nodeID=[{nodeID}]:数値ではないため行を飛ばします。");
                        continue;
                    }
                    //logger.Debug($"[{rowCount}]CSV:{allLines[rowCount]}");
                    //シンクロターン設定読込（0:旋回時にAGVだけ回転、1:旋回時に棚とAGVが同じ向きに回転）
                    if (!int.TryParse(splitLine[(int)MovingCSVColumn.TurnMode].Trim(), out var turnMode))
                    {
                        logger.Error("turnModeが読み込めません：{0}", splitLine[(int)MovingCSVColumn.TurnMode]);
                        continue;
                    }
                    //アンロード設定（0:目的地で棚を下ろさない、1:目的地で棚を下ろす）
                    if (!int.TryParse(splitLine[(int)MovingCSVColumn.UnloadMode].Trim(), out var unload))
                    {
                        logger.Error("unloadが読み込めません：{0}", splitLine[(int)MovingCSVColumn.UnloadMode]);
                        continue;
                    }
                    //CSVに書かれている棚IDを読込（0または数字に変換できない場合はCSVの棚IDを反映しない）
                    if ((int)MovingCSVColumn.PodID < splitLine.Count)
                    {
                        if (int.TryParse(splitLine[(int)MovingCSVColumn.PodID].Trim(), out var csvPodID))
                        {
                            podID = csvPodID == 0 ? podID : csvPodID.ToString();
                        }
                    }
                    //CSVに書かれているタスクペアの終端かを読込
                    if (!bool.TryParse(splitLine[(int)MovingCSVColumn.IsEnd].Trim(), out var isEnd))
                    {
                        //読み込めない場合は終端として扱う
                        isEnd = true;
                    }
                    //CSVに書かれているタスク後待機時間を読込
                    if (!int.TryParse(splitLine[(int)MovingCSVColumn.WaitTime].Trim(), out var waitTime))
                    {
                        //読み込めない場合は待機時間無しとして扱う
                        waitTime = 0;
                    }


                    //棚搬送するかAGV単体かを読込
                    if ((int)MovingCSVColumn.WithPod < splitLine.Count)
                    {
                        if (!int.TryParse(splitLine[(int)MovingCSVColumn.WithPod].Trim(), out var withPod))
                        {
                            logger.Error("withPodが読み込めません：{0}", splitLine[(int)MovingCSVColumn.WithPod]);
                            continue;
                        }

                        if (withPod == 0)
                        {
                            //事前に占有する処理
                            if (Factory == null)
                            {
                                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
                            }

                            var rbReturn = (GetRobotListReturnMessage)Factory.Create(new GetRobotListParam()).DoAction();
                            var rb = rbReturn.Data?.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
                            if (rb == null)
                            {
                                return;
                            }

                            switch (rb.Owner)
                            {
                                case "TES":
                                    var setOwnerResult = Factory.Create(new SetOwnerParam(robotID)).DoAction();
                                    break;
                                case "SUPER":
                                    logger.Error($"AGV{robotID}がHetuで占有されているため実行しません。");
                                    return;
                                default:
                                    break;
                            }
                            logger.Debug($"[{rowCount}]MoveRobot:AGV[{robotID}] nodeID[{nodeID}]");
                            taskList.Add(moveRobotAsync(param.ServerIP,
                                             param.WarehouseID,
                                             robotID,
                                             nodeID,
                                             cancelToken,
                                             waitTime));
                            if (isEnd)
                            {
                                await Task.WhenAll(taskList);
                                taskList.Clear();
                            }
                        }
                        else
                        {
                            if (!isAuto)
                            {
                                logger.Debug($"[{rowCount}]MovePod:AGV[{robotID}] nodeID[{nodeID}] podID[{podID}]");
                                taskList.Add(movePodAsync(param.ServerIP,
                                               param.WarehouseID,
                                               podID,
                                               nodeID,
                                               robotID,
                                               turnMode,
                                               unload,
                                               cancelToken,
                                               waitTime));
                                if (isEnd)
                                {
                                    await Task.WhenAll(taskList);
                                    taskList.Clear();
                                }
                            }
                            else
                            {
                                var robotGroupID = param.RobotGroupID;
                                if ((int)MovingCSVColumn.RobotGroup < splitLine.Count)
                                {
                                    robotGroupID = splitLine[(int)MovingCSVColumn.RobotGroup] == string.Empty
                                        ? param.RobotGroupID
                                        : splitLine[(int)MovingCSVColumn.RobotGroup]
                                        .Trim();
                                }

                                logger.Debug($"[{rowCount}]MovePodAuto:AGVGroup[{robotGroupID}] nodeID[{nodeID}] podID[{podID}]");
                                taskList.Add(movePodAsync(param.ServerIP,
                                               param.WarehouseID,
                                               podID,
                                               nodeID,
                                               robotID: robotGroupID,
                                               turnMode,
                                               unload,
                                               cancelToken,
                                               isAuto,
                                               waitTime));
                                if (isEnd)
                                {
                                    await Task.WhenAll(taskList);
                                    taskList.Clear();
                                }
                            }
                        }
                    }
                    else
                    {
                        //棚IDが空白の場合、棚なしAGVのみで移動する
                        if (podID == string.Empty)
                        {
                            //事前に占有する処理
                            if (Factory == null)
                            {
                                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
                            }

                            var rbReturn = (GetRobotListReturnMessage)Factory.Create(new GetRobotListParam()).DoAction();
                            var rb = rbReturn.Data?.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
                            if (rb == null)
                            {
                                return;
                            }

                            switch (rb.Owner)
                            {
                                case "TES":
                                    var setOwnerResult = Factory.Create(new SetOwnerParam(robotID)).DoAction();
                                    break;
                                case "SUPER":
                                    logger.Error($"AGV{robotID}がHetuで占有されているため実行しません。");
                                    return;
                                default:
                                    break;
                            }

                            await moveRobotAsync(param.ServerIP,
                                                 param.WarehouseID,
                                                 robotID,
                                                 nodeID,
                                                 cancelToken);
                        }
                        else
                        {
                            if (!isAuto)
                            {
                                await movePodAsync(param.ServerIP,
                                                   param.WarehouseID,
                                                   podID,
                                                   nodeID,
                                                   robotID,
                                                   turnMode,
                                                   unload,
                                                   cancelToken);
                            }
                            else
                            {
                                await movePodAsync(param.ServerIP,
                                                   param.WarehouseID,
                                                   podID,
                                                   nodeID,
                                                   param.RobotGroupID,
                                                   turnMode,
                                                   unload,
                                                   cancelToken,
                                                   isAuto);
                            }
                        }
                    }
                }

                if (!isInfinityLoop)
                {
                    nowCount++;
                    if (nowCount > param.RepeatCount)
                        isRunning = false;
                }
            }
            //while (nowCount != param.RepeatCount && !cancelToken.IsCancellationRequested);
            while (isRunning);
            dispatcherTimer.Stop();
            stopwatch.Stop();

            //lblCurrentLineProcess.Text = "連続動作完了";
            showInfoMessageBox($"連続動作完了:{lblRunningTime.Text}");

        }

        private async Task moveRobotAsync(string serverIP,
                                          string warehouseID,
                                          string robotID,
                                          string nodeID,
                                          CancellationToken token,
                                          int waitMillisecond = 0)
        {
            if (token.IsCancellationRequested)
            {
                logger.Info("AGV移動がキャンセルされました。");
                return;
            }

            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }

            try
            {
                var moveTask = new Task(() =>
                {
                    var moveRobotParam = new MoveRobotParam(
                            robotID,
                            DestinationModes.NodeID,
                            nodeID,
                            isEndWait: true,
                            ownerRegist: false
                            )
                    {
                        //CachingCallがnullだと例外が発生するため何もしないイベントを追加
                        CachingCall = (obj, e) =>
                        {
                        }
                    };
                    switch (robotFaceIndex)
                    {
                        case 0:
                            moveRobotParam.RobotFace = Direction.North;
                            break;
                        case 1:
                            moveRobotParam.RobotFace = Direction.East;
                            break;
                        case 2:
                            moveRobotParam.RobotFace = Direction.South;
                            break;
                        case 3:
                            moveRobotParam.RobotFace = Direction.West;
                            break;
                        case 4:
                            moveRobotParam.RobotFace = Direction.NoSelect;
                            break;
                    }
                    var moveRobotResult = (MoveRobotReturnMessage)factory.Create(moveRobotParam).DoAction();

                    logger.Info($"MoveRobot終了 AGV[{robotID}] 移動先[{nodeID}] 移動結果[{moveRobotResult.ReturnMsg}]");

                    this.Invoke((MethodInvoker)(() =>
                    {
                        //lblCurrentLineProcess.Text = logMessage;
                    }));
                }, token);
                if (token.IsCancellationRequested)
                {
                    return;
                }
                moveTask.Start();
                await moveTask.ConfigureAwait(true);
                if (waitMillisecond > 0)
                {
                    logger.Debug($"待機開始:{waitMillisecond}[ms]");
                    await Task.Delay(waitMillisecond);
                    logger.Debug("待機終了");
                }
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
                //showMoveRobotErrorDialog(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                //showMoveRobotErrorDialog(ex.Message);
            }
        }
        private async Task movePodAsync(string serverIP,
                                        string warehouseID,
                                        string podID,
                                        string nodeID,
                                        string robotID,
                                        int turnMode,
                                        int unload,
                                        CancellationToken cancelToken,
                                        int waitMillisecond = 0)
        {
            if (cancelToken.IsCancellationRequested)
                return;
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }
            try
            {
                //棚を下ろす際はシンクロターンできないようにする
                if (unload == ON)
                {
                    turnMode = OFF;
                }
                var moveTask = new Task(() =>
                {
                    var movePodParam = new MovePodParam(
                            robotID,
                            podID,
                            DestinationModes.StorageID,
                            nodeID,
                            isEndWait: true,
                            turnMode: turnMode,
                            unload: unload
                            );

                    //switch (listBoxDirection.SelectedIndex)
                    switch (robotFaceIndex)
                    //switch(cmbRobotFace.SelectedIndex)
                    {
                        case 0:
                            movePodParam.RobotFace = Direction.North;
                            break;
                        case 1:
                            movePodParam.RobotFace = Direction.East;
                            break;
                        case 2:
                            movePodParam.RobotFace = Direction.South;
                            break;
                        case 3:
                            movePodParam.RobotFace = Direction.West;
                            break;
                        case 4:
                            movePodParam.RobotFace = Direction.NoSelect;
                            break;
                    }

                    var movePodResult = (MovePodReturnMessage)factory.Create(movePodParam).DoAction();

                    logger.Info($"MovePod終了 AGV[{robotID}] 移動先[{nodeID}] 棚[{podID}] 移動結果[{movePodResult.ReturnMsg}]");
                    //logger.Info(movePodResult.ReturnMsg);
                    this.Invoke((MethodInvoker)(() =>
                    {
                        //lblCurrentLineProcess.Text = logMessage;
                    }));
                }, cancelToken);
                if (cancelToken.IsCancellationRequested)
                    return;

                moveTask.Start();
                await moveTask.ConfigureAwait(true);
                if (waitMillisecond > 0)
                {
                    logger.Debug($"待機開始:{waitMillisecond}[ms]");
                    await Task.Delay(waitMillisecond);
                    logger.Debug("待機終了");
                }
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private async Task movePodAsync(string serverIP,
                                        string warehouseID,
                                        string podID,
                                        string nodeID,
                                        string robotID,
                                        int turnMode,
                                        int unload,
                                        CancellationToken cancelToken,
                                        bool isAuto,
                                        int waitMillisecond = 0)
        {
            if (cancelToken.IsCancellationRequested)
                return;
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                logger.Error(Messages.NotConnectMsg);
                return;
            }
            try
            {
                //棚を下ろす際はシンクロターンできないようにする
                if (unload == ON)
                {
                    turnMode = OFF;
                }
                var moveTask = new Task(() =>
                {

                    if (!isAuto)
                    {
                        var movePodParam = new MovePodParam(
                            robotID,
                            podID,
                            DestinationModes.StorageID,
                            nodeID,
                            isEndWait: true,
                            turnMode: turnMode,
                            unload: unload
                            );
                        switch (robotFaceIndex)
                        {
                            case 0:
                                movePodParam.RobotFace = Direction.North;
                                break;
                            case 1:
                                movePodParam.RobotFace = Direction.East;
                                break;
                            case 2:
                                movePodParam.RobotFace = Direction.South;
                                break;
                            case 3:
                                movePodParam.RobotFace = Direction.West;
                                break;
                            case 4:
                                movePodParam.RobotFace = Direction.NoSelect;
                                break;
                        }

                        var movePodResult = (MovePodReturnMessage)factory.Create(movePodParam).DoAction();

                        logger.Info($"MovePod終了 AGV[{robotID}] 移動先[{nodeID}] 棚[{podID}] 移動結果[{movePodResult.ReturnMsg}]");
                    }
                    else
                    {
                        var movePodAutoParam = new MovePodAutoSelectAGVParam(
                            robotGroupID: robotID,
                            podID: podID,
                            desMode: DestinationModes.StorageID,
                            desID: nodeID,
                            isEndWait: true,
                            turnMode: turnMode,
                            unload: unload
                            );
                        switch (robotFaceIndex)
                        {
                            case 0:
                                movePodAutoParam.RobotFace = Direction.North;
                                break;
                            case 1:
                                movePodAutoParam.RobotFace = Direction.East;
                                break;
                            case 2:
                                movePodAutoParam.RobotFace = Direction.South;
                                break;
                            case 3:
                                movePodAutoParam.RobotFace = Direction.West;
                                break;
                            case 4:
                                movePodAutoParam.RobotFace = Direction.NoSelect;
                                break;
                        }

                        var movePodResult = (MovePodAutoSelectAGVReturnMessage)factory.Create(movePodAutoParam).DoAction();

                        logger.Info($"MovePodAuto終了 AGVGroup[{robotID}] 移動先[{nodeID}] 棚[{podID}] 移動結果[{movePodResult.ReturnMsg}]");
                    }
                }, cancelToken);
                if (cancelToken.IsCancellationRequested)
                    return;

                moveTask.Start();
                await moveTask.ConfigureAwait(true);
                if (waitMillisecond > 0)
                {
                    logger.Debug($"待機開始:{waitMillisecond}[ms]");
                    await Task.Delay(waitMillisecond);
                    logger.Debug("待機終了");
                }
            }
            //AGVに異常が発生したら例外を出す
            catch (EmergencyException ee)
            {
                logger.Error(ee.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void cmbRobotFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            robotFaceIndex = cmbRobotFace.SelectedIndex;
        }

        private void textBoxStationListPath_DragDrop(object sender, DragEventArgs e)
        {
            dragDrop(sender, e);
        }

        private void textBoxStationListPath_DragEnter(object sender, DragEventArgs e)
        {
            dragEnter(e);
        }

        private void btnSelectCSV_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "CSVファイルを選択",
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "CSVファイル|*.csv"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxStationListPath.Text = openFileDialog.FileName;
                logger.Info($"CSVファイルを選択しました。[{openFileDialog.FileName}]");
                param.StationListPath = openFileDialog.FileName;
            }
            else
            {
                logger.Info("CSVファイルの選択がキャンセルされました。");
            }
            openFileDialog.Dispose();
        }

        private void btnSaveSampleCSV_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// サンプルCSVファイルのパス
            /// </summary>
            const string sampleCSVPath = @"CSVSample\サンプル.csv";

            System.Diagnostics.Process.Start("EXPLORER.EXE", $"/select,{sampleCSVPath}");
        }

        private void radMoveRobot_CheckedChanged(object sender, EventArgs e)
        {
            isAuto = radMoveAuto.Checked;
            Console.WriteLine($"isAuto:{isAuto}");
        }

        private void frmLight_FormClosing(object sender, FormClosingEventArgs e)
        {
            source.Cancel();
            if (showCheckMessage($"設定を保存しますか？") == DialogResult.OK)
            {
                saveSetting();
            }
        }

        private void txtTempNode1_TextChanged(object sender, EventArgs e)
        {
            changeCmbItem(txtTempNode1, cmbTempNode);
        }

        private void txtNode1_TextChanged(object sender, EventArgs e)
        {
            changeCmbItem(txtNode1, cmbNode1);
        }

        private void txtNode2_TextChanged(object sender, EventArgs e)
        {
            changeCmbItem(txtNode2, cmbNode2);
        }

        private void mnuEditMovingCSV_Click(object sender, EventArgs e)
        {
            var frmMovingCSV = new Forms.frmMovingCSV(param.StationListPath);
            frmMovingCSV.Show();
        }

        private async void btnRotationCheck_Click(object sender, EventArgs e)
        {
            try
            {
                source = new CancellationTokenSource();
                var token = source.Token;
                updateParam();
                await AsyncCommands.RotationCheck(Factory, param.NodeID, param.PodID, param.RobotID, true, token);
                unsetOwner(param.RobotID);
                showInfoMessageBox($"天板回転チェック動作が完了しました。");
            }
            catch (Exception ex)
            {
                showErrorMessageBox($"エラーが発生しました。{ex.ToString()}");
            }
        }

        private void mnuOpenNodeData_Click(object sender, EventArgs e)
        {
            var frmNodeData = new Forms.FrmNodeDatas(param: param,
                                                      settingPath: settingPath);
            frmNodeData.Show();
        }

        private void mnuOpenAGVData_Click(object sender, EventArgs e)
        {
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            var frm = new frmDGV(Factory,RobotGroups);
            frm.Show();
        }

        private async void btnMoveRobot_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            source = new CancellationTokenSource();

            var robotFace = Direction.NoSelect;
            switch (cmbRobotFace.SelectedIndex)
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
                                  nodeID: param.NodeID,
                                  token: source.Token,
                                  robotFace: robotFace,
                                  isShowMessageBox: chkIsShowMessage.Checked);
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

        private async void btnMovePod_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            source = new CancellationTokenSource();
            var robotFace = Direction.NoSelect;
            switch (cmbRobotFace.SelectedIndex)
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
            switch (cmbPodFace.SelectedIndex)
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
                                             nodeID: param.NodeID,
                                             podID: param.PodID,
                                             robotFace: robotFace,
                                             podFace: podFace,
                                             unload: param.Unload);
            await task;

            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess: task.Result.result,
                           message: task.Result.message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiftUpAndDown_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }

            var (isSuccess, messages) = MapCommands.LiftUpAndDown(factory: Factory, robotID: param.RobotID);

            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, messages);
            }
            else
            {
                logger.Info(messages);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                var command = (AGVcommands)cmbCommand.SelectedIndex;
                switch (command)
                {
                    case AGVcommands.棚追加:
                        btnAddPod_Click(sender, e); break;
                    case AGVcommands.棚削除:
                        btnRemovePod_Click(sender, e); break;
                    case AGVcommands.棚位置セット:
                        btnSetPodPos_Click(sender, e); break;
                    case AGVcommands.全棚削除:
                        btnRemovePodAll_Click(sender, e); break;
                    case AGVcommands.占有解除:
                        btnUnSetOwner_Click(sender, e); break;
                    case AGVcommands.占有:
                        btnSetOwner_Click(sender, e); break;
                    case AGVcommands.充電:
                        btnCharge_Click(sender, e); break;
                    case AGVcommands.タスクキャンセル:
                        btnTaskCancel_Click(sender, e); break;
                    case AGVcommands.リフトアップ:
                        btnLiftUp_Click(sender, e); break;
                    case AGVcommands.リフトダウン:
                        btnLiftDown_Click(sender, e); break;
                    case AGVcommands.AGV情報:
                        btnGetAGVData_Click(sender, e); break;
                    case AGVcommands.全占有切替:
                        chkAllSet_CheckedChanged(sender, e); break;
                    case AGVcommands.天板回転:
                        btnRotationCheck_Click(sender, e); break;
                    case AGVcommands.AGV移動:
                        btnMoveRobot_Click(sender, e); break;
                    case AGVcommands.棚搬送:
                        btnMovePod_Click(sender, e); break;
                    case AGVcommands.棚アップダウン:
                        btnLiftUpAndDown_Click(sender, e); break;
                    case AGVcommands.一時停止:
                        btnPause_Click(sender, e); break;
                    case AGVcommands.運行:
                        btnResume_Click(sender, e); break;
                    case AGVcommands.AGV旋回:
                        btnTurnAGV_Click(sender, e); break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                var message = $"コマンド実行でエラー発生[{ex.ToString()}]";
                if (chkIsShowMessage.Checked)
                {
                    showMessageBox(false, message);
                }
                else
                {
                    logger.Info(message);
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }

            var (isSuccess, message) = Command.MapCommands.PauseRobot(Factory, param.RobotID);
            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, message);
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }

            var (isSuccess, message) = Command.MapCommands.ResumeRobot(Factory, param.RobotID);
            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, message);
            }
        }

        private void btnTurnAGV_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            var robotFace = Direction.NoSelect;
            switch (cmbRobotFace.SelectedIndex)
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
            var (isSuccess, message) = Command.MapCommands.TurnRobot(Factory, param.RobotID, robotFace);
            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, message);
            }
        }

        private void btnResumeAll_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }

            var (isSuccess, message) = Command.MapCommands.ResumeRobot(Factory, param.RobotID, isAll: true);
            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, message);
            }
        }

        private void btnPauseAll_Click(object sender, EventArgs e)
        {
            updateParam();
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }

            var (isSuccess, message) = Command.MapCommands.PauseRobot(Factory, param.RobotID, isAll: true);
            if (chkIsShowMessage.Checked)
            {
                showMessageBox(isSuccess, message);
            }
        }
        public List<string> GetPodList(CommandFactory factory)
        {
            var result = new List<string>();
            var getPodListReturnMessage = (GetPodListReturnMessage)factory.Create(new GetPodListParam()).DoAction();
            var podList = getPodListReturnMessage.Data.PodList.ToList();
            podList.ForEach(pod =>
            {
                result.Add($"{pod.PodID},{pod.StorageID},{pod.RobotID},{pod.PodType},{pod.PositionType}");
            });
            return result;
        }

        private void mnuGetPodList_Click(object sender, EventArgs e)
        {
            if (Factory == null)
            {
                Factory = new CommandFactory(param.ServerIP, param.WarehouseID);
            }
            var podListPath = Path.Combine(logDirPath, "PodList.csv");

            using (var sw = new StreamWriter(podListPath))
            {
                sw.WriteLine($"PodID,StrageID,RobotID,PodType,PositionType");
                var list = GetPodList(Factory);
                list.ForEach(pod =>
                {
                    sw.WriteLine(pod);
                });
            }

            if (showCheckMessage($"棚情報を[{podListPath}]に保存しました。場所を開きますか？") == DialogResult.OK)
            {
                if (!Directory.Exists(logDirPath))
                {
                    showErrorMessageBox($"{Path.GetFullPath(logDirPath)}が見つかりません。");
                    return;
                }
                System.Diagnostics.Process.Start("EXPLORER.EXE", logDirPath);
            }
        }
    }
    public class RobotGroup
    {
        public string RobotGroupID { get; set; } = string.Empty;
        public string GroupName { get; set;} = string.Empty;

        public RobotGroup(string robotGroupID,string groupName)
        {
            RobotGroupID = robotGroupID;
            GroupName = groupName;
        }
    }
}
