//using AMRControlLib.Controls;
//using AMRScheduleLib.Setting;
using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MujinAGVDemo.Command
{
    ///<summary>マップに関するコマンド</summary>
    public static class MapCommands
    {
        #region Const

        private const string faultConnectoToHetuServer = "Hetuサーバーに接続できません";
        private const string faultFindToMap = "マップ上に棚が存在しません";
        private const string result = "結果";
        private const int successCode = 0;
        private const int ON = 1;
        private const int OFF = 0;

        #endregion

        #region Public Methods

        /// <summary> すべての棚を削除します </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <returns>isSuccess=一つでも失敗した場合はfalse　messages=棚ごとの削除メッセージ</returns>
        public static (bool isSuccess, string[] messages) RemoveAllShelfs(string hetuIP, string warehouseID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, new string[] { faultConnectoToHetuServer });

            var messages = new List<string>();

            try
            {
                var getPodsMessage = (GetPodListReturnMessage)factory.Create(new GetPodListParam()).DoAction();

                if (getPodsMessage.Data == null)
                    return (true, new string[] { faultFindToMap });

                {
                    if (!getPodsMessage.Data.PodList.Any())
                        return (true, new string[] { faultFindToMap });

                    if (getPodsMessage.ReturnMsg.IndexOf("succ") > 0)
                        return (false, new string[] { $"{result}: { getPodsMessage.ReturnMsg} コード: { getPodsMessage.ReturnCode}" });

                    getPodsMessage.Data.PodList.ForEach(pd =>
                    {
                        var messaage = (RemovePodReturnMessage)factory.Create(new RemovePodParam() { PodID = pd.PodID }).DoAction();
                        messages.Add($"棚ID:{pd.PodID} {result}: { messaage.ReturnMsg} コード: { messaage.ReturnCode}");
                    });
                }
            }
            catch (Exception ex)
            {
                return (false, new string[] { $"棚削除中にエラーが発生しました。{ex.Message} " });
            }
            finally
            {
            }

            return (true, messages.ToArray());
        }

        /// <summary> マップ上に存在するタスクを全て削除します </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <returns>isSuccess=一つでも失敗した場合はfalse　messages=棚ごとの削除メッセージ</returns>
        public static (bool isSuccess, string[] messages) RemoveAllTasks(string hetuIP, string warehouseID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, new string[] { faultConnectoToHetuServer });

            var success = true;
            var messages = new List<string>();

            var taskStatusList = new List<TaskStatuses>() { TaskStatuses.Ready, TaskStatuses.Init, TaskStatuses.Running };
            ((GetAllTaskSelectStatusFromDBReturnMessage)factory.Create(new GetAllTaskSelectStatusFromDBParam(taskStatusList)).DoAction()).GetAllTaskSelectStatusList.ForEach(ts =>
            {
                ReturnMessageBase cancelTaskResult = factory.Create(new CancelTaskParam(ts.TaskID, $"{ts.TaskStatus}")).DoAction();

                if (cancelTaskResult.ReturnCode != 0)
                    success = false;

                messages.Add($"タスクID:{ts.TaskID} {result}: { cancelTaskResult.ReturnMsg} コード: { cancelTaskResult.ReturnCode}");
            });

            return (success, messages.ToArray());
        }

        /// <summary>>指定されたロボットを原位置に移動するコマンドを実行する。</summary>
        /// <param name="hetuIP">接続するHetuサーバーのIPアドレス</param>
        /// <param name="warehouseID">倉庫ID</param>
        /// <param name="robotID">原位置に移動するロボットのID</param>
        /// <param name="defaultNodeID"></param>
        /// <returns>動作結果のメッセージ</returns>
        public static (bool isSuccess, string messages) MoveRobotToStandbyPosition(string hetuIP, string warehouseID, string robotID, string defaultNodeID)
        {
            return MoveRobot(hetuIP, warehouseID, robotID, defaultNodeID);
        }

        /// <summary>指定されたロボットを指定された位置に移動するコマンドを実行する。</summary>
        /// <param name="hetuIP">接続するHetuサーバーのIPアドレス</param>
        /// <param name="warehouseID">倉庫ID</param>
        /// <param name="robotID">移動するAGV_ID</param>
        /// <param name="destinationPoint">移動先</param>
        /// <returns>ロボット移動動作の結果メッセージ</returns>
        public static (bool isSuccess, string messages) MoveRobot(string hetuIP, string warehouseID, string robotID, string destinationPoint)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, faultConnectoToHetuServer);

            factory.Create(new UnsetOwnerParam(robotID)).DoAction();

            var moveRobotResult = (MoveRobotReturnMessage)(factory.Create(new MoveRobotParam(
                     robotID,
                     DestinationModes.NodeID,
                     destinationPoint,
                     isEndWait: true,
                     ownerRegist: true
                 )).DoAction());

            if (string.IsNullOrWhiteSpace(moveRobotResult.Data.TaskID))
                return (false, getTaskFaultResultMessage(TaskTypes.MoveRobot, robotID, moveRobotResult.ReturnMsg, moveRobotResult.ReturnCode));

            var taskDetail = (GetTaskDetailReturnMessage)(factory.Create(new GetTaskDetailParam(moveRobotResult.Data.TaskID))).DoAction();

            factory.Create(new UnsetOwnerParam(robotID)).DoAction();

            return (taskDetail.Data.Detail.Status == TaskStatuses.Success,
                getTaskResultMessage(moveRobotResult.Data.TaskID,
                taskDetail.Data.Detail.TaskType,
                robotID, taskDetail.Data.Detail.Status,
                taskDetail.Data.Detail.ErrorCode));
        }

        /// <summary>指定されたロボットを一時停止コマンドを実行する。</summary>
        /// <param name="hetuIP">接続するHetuサーバーのIPアドレス</param>
        /// <param name="warehouseID">倉庫ID</param>
        /// <param name="robotID">一時停止するAGV_ID</param>
        /// <returns>一時停止動作のの結果メッセージ</returns>
        public static (bool isSuccess, string messages) PauseRobot(string hetuIP, string warehouseID, string robotID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, faultConnectoToHetuServer);

            var pauseRobotResult = (PauseRobotReturnMessage)factory.Create(new PauseRobotParam(robotID)).DoAction();

            return (pauseRobotResult.ReturnCode == successCode, $"コマンド：AGV一時停止、対象AGV_ID：{robotID}、{result}: {pauseRobotResult.ReturnMsg}、コード: { pauseRobotResult.ReturnCode}");
        }

        /// <summary>指定されたロボットに再開コマンドを実行する。</summary>
        /// <param name="hetuIP">接続するHetuサーバーのIPアドレス</param>
        /// <param name="warehouseID">倉庫ID</param>
        /// <param name="robotID">再開するAGV_ID</param>
        /// <returns>再開動作の結果メッセージ</returns>
        public static (bool isSuccess, string messages) ResumeRobot(string hetuIP, string warhouseID, string robotID)
        {
            var factory = new CommandFactory(hetuIP, warhouseID);
            if (!factory.IsConnectedTESServer())
                return (false, faultConnectoToHetuServer);

            var resumeRobotResult = (ResumeRobotReturnMessage)factory.Create(new ResumeRobotParam(robotID)).DoAction();

            return (resumeRobotResult.ReturnCode == successCode, $"コマンド：AGV再開、対象AGV_ID：{robotID}、{result}: {resumeRobotResult.ReturnMsg}、コード: {resumeRobotResult.ReturnCode}");
        }

        /// <summary>指定されたロボットに充電するコマンドを実行する。</summary>
        /// <param name="hetuIP">接続するHetuサーバーのIPアドレス</param>
        /// <param name="warehouseID">倉庫ID</param>
        /// <param name="robotID">充電するAGV_ID</param>
        /// <param name="chargingZone">充電ゾーン</param>
        /// <returns>充電動作結果のメッセージ</returns>
        public static (bool isSuccess, string messages) ChargeRobot(string hetuIP, string warehouseID, string robotID, string chargingZone)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, faultConnectoToHetuServer);

            factory.Create(new UnsetOwnerParam(robotID)).DoAction();

            var chargeRobotResult = (ChargeRobotReturnMessage)(factory.Create(new ChargeRobotParam(robotID, chargingZone)).DoAction());
            var taskID = chargeRobotResult.Data?.TaskID;

            if (string.IsNullOrWhiteSpace(taskID))
                return (false, getTaskFaultResultMessage(TaskTypes.Charge, robotID, chargeRobotResult.ReturnMsg, chargeRobotResult.ReturnCode));

            var taskDetail = (GetTaskDetailReturnMessage)(factory.Create(new GetTaskDetailParam(taskID))).DoAction();

            return (chargeRobotResult.ReturnCode == successCode,//充電コマンドを実行する　taskDetail.Data.Detail.StatusがReadyになります。
                getTaskResultMessage(taskID,
                taskDetail.Data.Detail.TaskType,
                robotID, taskDetail.Data.Detail.Status,
                taskDetail.Data.Detail.ErrorCode));

            // 160921846262
            // 16177855491
        }

        /// <summary> すべてのAGVを停止します </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=Hetuの応答メッセージ</returns>
        public static (bool isSuccess, string messages) PauseAllRobots(string hetuIP, string warehouseID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, faultConnectoToHetuServer);

            //isAll指定で全てのAGVを指定する
            var result = (PauseRobotReturnMessage)factory.Create(new PauseRobotParam(robotID: string.Empty, isAll: true)).DoAction();

            return (result.ReturnCode == successCode, result.ReturnMsg);
        }

        /// <summary> すべてのAGVを停止します </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=Hetuの応答メッセージ</returns>
        public static (bool isSuccess, string messages) ResumeAllRobots(string hetuIP, string warehouseID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, faultConnectoToHetuServer);

            var result = (ResumeRobotReturnMessage)factory.Create(new ResumeRobotParam(robotID: string.Empty, isAll: true)).DoAction();

            return (result.ReturnCode == successCode, result.ReturnMsg);
        }
        /// <summary>
        /// 指定のノードにある棚のIDを取得する
        /// </summary>
        /// <param name="nodeID">棚が存在するか確認するノードID</param>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=結果の応答メッセージ, podID=棚ID（棚が無い時は空白）</returns>
        public static (bool isSuccess, string messages, string podID) GetPodID(string hetuIP, string warehouseID, string nodeID)
        {
            var podID = string.Empty;
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                return (false, faultConnectoToHetuServer, podID);
            }

            var getPodListReturnMessage = (GetPodListFromDBReturnMessage)factory.Create(new GetPodListFromDBParam()).DoAction();
            if (getPodListReturnMessage.ReturnCode != successCode)
            {
                return (false, $"棚のリスト取得に失敗しました。[{getPodListReturnMessage.ReturnMsg}][{getPodListReturnMessage.ReturnCode}]", podID);
            }
            //「StorageID」はAGVに持ち上げられていない場合のみ持っているパラメータ
            //AGVに持ち上げられている場合はかわりに「RobotID」に号機が入る
            var pod = getPodListReturnMessage.Data.PodList.Where(x => x.StorageID == nodeID).FirstOrDefault();
            if (pod == null)
            {
                return (false, $"nodeID[{nodeID}]に棚は存在しません。", podID);
            }
            else
            {
                podID = pod.PodID;
                return (true, $"nodeID[{nodeID}]に棚[{pod.PodID}]が存在します。", podID);
            }
        }
        /// <summary>
        /// AGVを指定してその場で棚を下ろす
        /// </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <param name="robotID">AGVの番号</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=Hetuの応答メッセージ</returns>
        public static (bool isSuccess, string messages) LiftDownRobot(string hetuIP, string warehouseID, string robotID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            var getRobotListFromDBReturnMessage = (GetRobotListFromDBReturnMessage)factory.Create(new GetRobotListFromDBParam()).DoAction();
            var rb = getRobotListFromDBReturnMessage.Data.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
            //指定したAGVが見つからない場合はここで終了
            if (rb == null)
            {
                //logger.Info();
                return (false, $"AGV[{robotID}]が見つかりません。");
            }
            var getPodListFromDBReturnMessage = (GetPodListFromDBReturnMessage)factory.Create(new GetPodListFromDBParam()).DoAction();
            var podList = getPodListFromDBReturnMessage.Data.PodList;
            //サーバーに棚が残っているのでFirstOrDefaultだとマップ上に無い棚が選択されることがある。
            var pod = podList.Where(x => x.RobotID == robotID).LastOrDefault();

            var podID = pod.PodID;
            var nodeID = rb.CurNodeID;
            var unload = ON;
            //持っている棚がない場合はここで終了
            if (podID == string.Empty)
            {
                //logger.Info();
                return (true, $"AGV[{robotID}]が持っている棚はありません。");
            }

            var movePodResult = (MovePodReturnMessage)factory.Create(new MovePodParam(
                robotID,
                podID,
                DestinationModes.StorageID,
                nodeID,
                isEndWait: true,
                unload: unload
                )).DoAction();

            if (movePodResult.ReturnMsg == null)
            {
                return (false, $"リフトダウン結果が取得できませんでした。AGV[{robotID}] ノード[{rb.CurNodeID}] 棚[{podID}]");
            }
            var returnMessage = $"AGV[{robotID}]と同じ場所[{rb.CurNodeID}]の棚[{podID}]を下ろします。結果[{movePodResult.ReturnMsg}]リターンコード[{movePodResult.ReturnCode}]";

            return (movePodResult.ReturnCode == successCode, returnMessage);
        }
        /// <summary>
        /// AGVを指定してその場で棚を持ち上げる
        /// </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <param name="robotID">AGVの番号</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=Hetuの応答メッセージ</returns>
        public static (bool isSuccess, string messages) LiftUpRobot(string hetuIP, string warehouseID, string robotID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            var getRobotListFromDBReturnMessage = (GetRobotListFromDBReturnMessage)factory.Create(new GetRobotListFromDBParam()).DoAction();
            var rb = getRobotListFromDBReturnMessage.Data.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
            var returnMessage = string.Empty;
            //指定したAGVが見つからない場合はここで終了
            if (rb == null)
            {
                returnMessage = $"AGV[{robotID}]が見つかりません。";
                return (false, returnMessage);
            }

            var nodeID = rb.CurNodeID;
            var unload = OFF;

            var getPodResult = GetPodID(hetuIP, warehouseID, nodeID);
            //AGVと同じ場所に棚がない場合はここで終了
            if (!getPodResult.isSuccess)
            {
                returnMessage = $"AGV[{robotID}]と同じ場所に棚がありません。[{getPodResult.messages}]";
                return (false, returnMessage);
            }

            var podID = getPodResult.podID;
            var movePodResult = (MovePodReturnMessage)factory.Create(new MovePodParam(
                robotID,
                podID,
                DestinationModes.StorageID,
                nodeID,
                isEndWait: true,
                unload: unload
                )).DoAction();
            if (movePodResult.ReturnMsg == null)
            {
                return (false, $"リフトアップ結果が取得できませんでした。AGV[{robotID}] ノード[{rb.CurNodeID}] 棚[{podID}]");
            }
            returnMessage = $"AGV[{robotID}]と同じ場所[{rb.CurNodeID}]の棚[{podID}]を持ち上げます。結果[{movePodResult.ReturnMsg}]リターンコード[{movePodResult.ReturnCode}]";

            return (movePodResult.ReturnCode == successCode, returnMessage);
        }
        /// <summary>
        /// 棚の位置をシステム的に変更する
        /// </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <param name="podID">棚ID</param>
        /// <param name="nodeID">ノードID</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=応答メッセージ</returns>
        public static (bool isSuccess, string message) SetPodPosition(string hetuIP, string warehouseID, string podID, string nodeID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                return (false, faultConnectoToHetuServer);
            }
            var retMessage = (SetPodPosReturnMessage)factory.Create(new SetPodPosParam(podID, nodeID)).DoAction();
            var message = $"棚位置セット 結果[{retMessage.ReturnMsg}]棚[{podID}] ノード[{nodeID}]";
            return (retMessage.ReturnCode == successCode, message);
        }
        /// <summary>
        /// AGV情報テーブルを取得します
        /// </summary>
        /// <param name="hetuIP">HetuサーバーのIP</param>
        /// <param name="warehouseID">マップのID</param>
        /// <returns>AGV情報が入ったデータテーブル</returns>
        public static DataTable GetAgvDetailTable(string hetuIP, string warehouseID)
        {
            var table = new DataTable();
            
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return table;

            var getRobotListAns = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();
            table.Columns.Add("号機");
            table.Columns.Add("状態");
            table.Columns.Add("所有者");
            table.Columns.Add("エラー");
            table.Columns.Add("電池");
            table.Columns.Add("タスク");
            table.Columns.Add("ノード");
            table.Columns.Add("X");
            table.Columns.Add("Y");
            getRobotListAns.Data.RobotList.ForEach(rb =>
            {
                table.Rows.Add(rb.RobotID, rb.WorkStatus, rb.Owner, rb.ErrorState, $"{rb.UcPower}", rb.CurNodeID, rb.CurX, rb.CurY, rb.TaskID);
            });
            return table;
        }
            #region TaskCancel

            /// <summary>指定されたAGV_IDの充電タスクをキャンセルするコマンドを実行する。</summary>
            /// <param name="hetuIP">接続するHetuサーバーのIPアドレス</param>
            /// <param name="warehouseID">倉庫ID</param>
            /// <param name="robotID">充電タスクをキャンセルするAGV_ID</param>
            /// <returns>（タスクキャンセル動作kの結果（True：キャンセル成功、False：キャンセル失敗）、タスクキャンセル動作の結果メッセージ）</returns>
            public static (bool isSuccess, string message) CancelRobotChargingTask(string hetuIP, string warehouseID, string robotID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return (false, faultConnectoToHetuServer);

            var taskStatusList = new List<TaskStatuses>() { TaskStatuses.Ready, TaskStatuses.Init, TaskStatuses.Running };

            var tasksToBeCancelled = ((GetAllTaskSelectStatusFromDBReturnMessage)factory.Create(new GetAllTaskSelectStatusFromDBParam(taskStatusList)).DoAction())
                .GetAllTaskSelectStatusList.Where(task => task.RobotID == robotID && task.TaskType == TaskTypes.Charge).ToList();

            if (tasksToBeCancelled.Count == 0)
                return (true, $"このロボットにはキャンセルする充電タスクが存在しません。対象AGV_ID：{robotID}");

            return CancelTask(factory, tasksToBeCancelled.FirstOrDefault());//充電タスクはひとつしｋ
        }

        /// <summary>指定されたAGV_IDの全タスクをキャンセルするコマンドを実行する。</summary>
        /// <param name="hetuIP">接続するHetuサーバーのIPアドレス</param>
        /// <param name="warehouseID">倉庫ID</param>
        /// <param name="robotID">タスクをキャンセルするAGV_ID</param>
        /// <returns>（タスクキャンセル動作kの結果（True：キャンセル成功、False：キャンセル失敗）、タスクキャンセル動作の結果メッセージ）</returns>
        public static List<(bool isSuccess, string message)> CancelAllRobotTask(string hetuIP, string warehouseID, string robotID)
        {
            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return new List<(bool, string)> { (false, faultConnectoToHetuServer) };

            var taskStatusList = new List<TaskStatuses>() { TaskStatuses.Ready, TaskStatuses.Init, TaskStatuses.Running };

            var taskToBeCancelled = ((GetAllTaskSelectStatusFromDBReturnMessage)factory.Create(new GetAllTaskSelectStatusFromDBParam(taskStatusList)).DoAction())
                .GetAllTaskSelectStatusList.Where(task => task.RobotID == robotID).ToList();

            if (taskToBeCancelled.Count == 0)
                return new List<(bool, string)> { (true, $"このロボットにはキャンセルするタスクが存在しません。対象AGV_ID：{robotID}") };

            return CancelTasks(factory, taskToBeCancelled);
        }

        /// <summary>渡されたタスクをキャンセルするコマンドを実行する。</summary>
        /// <param name="commandFactory">キャンセルコマンドで実行するオブジェクト</param>
        /// <param name="tasksToBeCancelled">キャンセルするタスクのリスト</param>
        /// <returns>（タスクキャンセル動作kの結果（True：成功、False：失敗）、タスクキャンセル動作の結果メッセージ）</returns>
        public static List<(bool isSuccess, string message)> CancelTasks(CommandFactory commandFactory, List<GetAllTaskSelectStatusLists> tasksToBeCancelled)
        {
            var cancelTaskMessages = new List<(bool, string)>();

            foreach (GetAllTaskSelectStatusLists task in tasksToBeCancelled)
                cancelTaskMessages.Add(CancelTask(commandFactory, task));

            return cancelTaskMessages;
        }

        /// <summary>渡されたタスクをキャンセルするコマンドを実行する。</summary>
        /// <param name="commandFactory">キャンセルコマンドで実行するオブジェクト</param>
        /// <param name="taskToBeCancelled">キャンセルするタスク</param>
        /// <returns>（タスクキャンセル動作kの結果（True：成功、False：失敗）、タスクキャンセル動作の結果メッセージ）</returns>
        public static (bool isSuccess, string message) CancelTask(CommandFactory commandFactory, GetAllTaskSelectStatusLists taskToBeCancelled)
        {
            var taskCancelResult = (CancelTaskReturnMessage)commandFactory.Create(new CancelTaskParam(taskToBeCancelled.TaskID)).DoAction();

            var isSuccess = taskCancelResult.ReturnCode == successCode;

            var message = $"コマンド：タスクキャンセル、対象AGV_ID：{taskToBeCancelled.RobotID}、タスク型：{taskToBeCancelled.TaskType}、{result}：{taskCancelResult.ReturnUserMsg}、コード：{taskCancelResult.ReturnCode}";

            return (isSuccess, message);
        }

        /// <summary>全AGVの電池量を取得する。</summary>
        /// <param name="hetuIP">HetuサーバーのIPアドレス</param>
        /// <param name="warehouseID">倉庫のID</param>
        /// <returns>各AGVの電池量（String：キーはロボットID、Int：電池量）</returns>
        public static Dictionary<string, int> GetAgvBattery(string hetuIP, string warehouseID)
        {
            var returnBattery = new Dictionary<string, int>();

            var factory = new CommandFactory(hetuIP, warehouseID);
            if (!factory.IsConnectedTESServer())
                return returnBattery;

            var getRobotListAns = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();

            getRobotListAns.Data.RobotList.ForEach(robot => returnBattery.Add(robot.RobotID, robot.UcPower));

            return returnBattery;
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// タスク結果の文字列を取得します
        /// </summary>
        /// <param name="taskID">タスクID</param>
        /// <param name="taskType">タスクタイプ</param>
        /// <param name="robotID">AGV</param>
        /// <param name="status">タスク結果ステータス</param>
        /// <param name="errorCode">エラーコード</param>
        /// <returns>作成された文字列</returns>
        private static string getTaskResultMessage(string taskID, TaskTypes taskType, string robotID, TaskStatuses status, int errorCode) =>
            $"タスクID:{taskID}、タスク型：{taskType}、対象AGV_ID：{robotID}、結果: { status}、コード: { errorCode.ToString()}";

        /// <summary>
        /// タスク失敗時の文字列を取得します
        /// </summary
        /// <param name="taskType">タスクタイプ</param>
        /// <param name="robotID">AGV</param>
        /// <param name="status">タスク結果ステータス</param>
        /// <param name="errorCode">エラーコード</param>
        /// <returns>作成された文字列</returns>
        private static string getTaskFaultResultMessage(TaskTypes taskType, string robotID, string returnMessage, int errorCode) =>
            $"タスク実行失敗しました。タスク型：{taskType}、対象AGV_ID：{robotID}、{result}: { returnMessage}、コード: { errorCode.ToString()}";

        #endregion
    }
}