using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MujinAGVDemo.Command
{
    /// <summary>
    /// 非同期でAGVを動かすコマンドのクラス
    /// </summary>
    public static class AsyncCommands
    {
        private const int OFF = 0;
        private const int ON = 1;
        private const double Nan = -255;
        public static Logger logger = LogManager.GetLogger("ProgramLogger");

        /// <summary>
        /// AGV単体で移動します。
        /// </summary>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="robotID">号機</param>
        /// <param name="nodeID">行先ノードID</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns>タスク結果（成功か、メッセージ）</returns>
        public static async Task<(bool, string)> MoveRobot(CancellationToken token,
                                                    CommandFactory factory,
                                                    string robotID,
                                                    string nodeID,
                                                    double robotFace = Nan)
        {
            var robotParam = new MoveRobotParam(
                robotID: robotID,
                desMode: DestinationModes.NodeID,
                desID: nodeID,
                robotFace: robotFace
                )
            {
                //CachingCallがnullだと例外が発生するため何もしないイベントを追加
                CachingCall = (obj, e) =>
                {
                }
            };
            return await MoveRobot(token, factory, robotParam);
        }
        /// <summary>
        /// AGV単体で移動します。
        /// </summary>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="param">移動指示用パラメータ</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns>タスク結果（成功か、メッセージ）</returns>
        public static async Task<(bool, string)> MoveRobot(CancellationToken token,
                                                    CommandFactory factory,
                                                    MoveRobotParam param)
        {
            if (token.IsCancellationRequested)
            {
                return (false, $"AGV移動がキャンセルされました。");
            }
            var moveTask = new Task<(bool, string)>(() =>
            {
                var result = factory.Create(param).DoAction() as MoveRobotReturnMessage;
                var logMessage = $"AGV移動結果:[{result.ReturnMsg}] リターンコード:[{result.ReturnCode}] robotID:[{param.RobotID}] 移動先:[{param.DesID}]";
                return (result.ReturnMsg == "succ", logMessage);
            });
            moveTask.Start();
            await moveTask.ConfigureAwait(true);
            return moveTask.Result;
        }

        /// <summary>
        /// AGVが棚を持って移動します。
        /// </summary>
        /// <param name="token">キャンセルトークン</param>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="robotID">AGV号機</param>
        /// <param name="nodeID">行先ノードID</param>
        /// <param name="podID">棚ID</param>
        /// <param name="turnMode">AGVと棚の向きを同期させるか（0:同期、1:同期しない）</param>
        /// <param name="unload">行先で棚を下ろすか（0:下ろす、1:下ろさない）</param>
        /// <param name="robotFace">行先でのAGVの向き(北を0としてrad表記、指定なしは-255)</param>
        /// <param name="podFace">行先での棚の向き(北を0としてrad表記、指定なしは-255)</param>
        /// <returns>タスク結果（成功か、メッセージ）</returns>
        public static async Task<(bool result, string message)> MovePod(CancellationToken token,
                                                  CommandFactory factory,
                                                  string robotID,
                                                  string nodeID,
                                                  string podID,
                                                  int turnMode = OFF,
                                                  int unload = ON,
                                                  double robotFace = Nan,
                                                  double podFace = Nan)
        {
            var param = new MovePodParam(
                robotID: robotID,
                podID: podID,
                desMode: DestinationModes.StorageID,
                desID: nodeID,
                turnMode: turnMode,
                unload: unload,
                robotFace: robotFace,
                podFace: podFace
                )
            {
            };
            return await MovePod(token, factory, param);
        }
        /// <summary>
        /// AGVが棚を持って移動します。
        /// </summary>
        /// <param name="token">キャンセルトークン</param>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="param">移動指示用パラメータ</param>
        /// <returns>タスク結果（成功か、メッセージ）</returns>
        public static async Task<(bool, string)> MovePod(CancellationToken token,
                                                  CommandFactory factory,
                                                  MovePodParam param)
        {
            if (token.IsCancellationRequested)
            {
                return (false, $"AGV移動がキャンセルされました。");
            }
            var moveTask = new Task<(bool, string)>(() =>
            {
                var result = factory.Create(param).DoAction() as MovePodReturnMessage;

                var logMessage = $"棚移動結果:[{result.ReturnMsg}] リターンコード:[{result.ReturnCode}] robotID:[{param.RobotID}] podID:[{param.PodID}] 移動先:[{param.DesID}]";

                return (result.ReturnMsg == "succ", logMessage);
            });
            moveTask.Start();
            await moveTask.ConfigureAwait(true);
            return moveTask.Result;
        }

        /// <summary>
        /// 指定したグループのAGVが棚を持って移動します。
        /// </summary>
        /// <param name="token">キャンセルトークン</param>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="robotGroupID">AGVグループID</param>
        /// <param name="nodeID">行先ノードID</param>
        /// <param name="podID">棚ID</param>
        /// <param name="turnMode">AGVと棚の向きを同期させるか（0:同期、1:同期しない）</param>
        /// <param name="unload">行先で棚を下ろすか（0:下ろす、1:下ろさない）</param>
        /// <param name="robotFace">行先でのAGVの向き(北を0としてrad表記、指定なしは-255)</param>
        /// <param name="podFace">行先での棚の向き(北を0としてrad表記、指定なしは-255)</param>
        /// <returns>タスク結果（成功か、メッセージ）</returns>
        public static async Task<(bool, string)> MovePodAuto(CancellationToken token,
                                                  CommandFactory factory,
                                                  string robotGroupID,
                                                  string nodeID,
                                                  string podID,
                                                  int turnMode = OFF,
                                                  int unload = ON,
                                                  double robotFace = Nan,
                                                  double podFace = Nan)
        {
            var param = new MovePodAutoSelectAGVParam(
                robotGroupID: robotGroupID,
                podID: podID,
                desMode: DestinationModes.StorageID,
                desID: nodeID,
                turnMode: turnMode,
                unload: unload,
                robotFace: robotFace,
                podFace: podFace
                )
            {
            };
            return await MovePodAuto(token, factory, param);
        }
        /// <summary>
        /// 指定したグループのAGVが棚を持って移動します。
        /// </summary>
        /// <param name="token">キャンセルトークン</param>
        /// <param name="factory">コマンドファクトリー</param>
        /// <param name="param">移動指示用パラメータ</param>
        /// <returns>タスク結果（成功か、メッセージ）</returns>
        public static async Task<(bool, string)> MovePodAuto(CancellationToken token,
                                                      CommandFactory factory,
                                                      MovePodAutoSelectAGVParam param)
        {
            if (token.IsCancellationRequested)
            {
                return (false, $"AGV移動がキャンセルされました。");
            }
            var moveTask = new Task<(bool, string)>(() =>
            {
                var result = factory.Create(param).DoAction() as MovePodReturnMessage;
                var logMessage = $"棚移動結果:[{result.ReturnMsg}] リターンコード:[{result.ReturnCode}] robotGroupID:[{param.RobotGroupID}] podID:[{param.PodID}] 移動先:[{param.DesID}]";
                return (result.ReturnMsg == "succ", result.ReturnMsg);
            });
            moveTask.Start();
            await moveTask.ConfigureAwait(true);
            return moveTask.Result;
        }

        /// <summary>
        /// AGVを指定してその場で棚を持ち上げます。
        /// </summary>
        /// <param name="token">キャンセルトークン</param>
        /// <param name="factory">ファクトリ</param>
        /// <param name="robotID">AGVの番号</param>
        /// <param name="podDirectionIndex">棚の向き（0:北　1:東　2:南　3:西　4:指定しない）</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=Hetuの応答メッセージ</returns>
        public static async Task<(bool, string)> LiftUpRobot(CancellationToken token,
                                                      CommandFactory factory,
                                                      string robotID,
                                                      int podDirectionIndex = 4)
        {
            var getRobotListReturnMessage = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();
            var rb = getRobotListReturnMessage.Data.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
            var returnMessage = string.Empty;
            //指定したAGVが見つからない場合はここで終了
            if (rb == null)
            {
                returnMessage = $"AGV[{robotID}]が見つかりません。";
                return (false, returnMessage);
            }

            var nodeID = rb.CurNodeID;
            var unload = OFF;

            var getPodResult = MapCommands.GetPodID(factory, nodeID);
            //AGVと同じ場所に棚がない場合はここで終了
            if (!getPodResult.isSuccess)
            {
                returnMessage = $"AGV[{robotID}]と同じ場所に棚がありません。[{getPodResult.messages}]";
                return (false, returnMessage);
            }

            var podID = getPodResult.podID;
            var param = new MovePodParam(
                robotID,
                podID,
                DestinationModes.StorageID,
                nodeID,
                isEndWait: true,
                unload: unload
                );
            switch (podDirectionIndex)
            {
                case 0:
                    param.PodFace = Direction.North;
                    break;
                case 1:
                    param.PodFace = Direction.East;
                    break;
                case 2:
                    param.PodFace = Direction.South;
                    break;
                case 3:
                    param.PodFace = Direction.West;
                    break;
                case 4:
                    param.PodFace = Direction.NoSelect;
                    break;
            }
            return await MovePod(token, factory, param);
        }

        /// <summary>
        /// AGVを指定してその場で棚を下ろします。
        /// </summary>
        /// <param name="factory">ファクトリ</param>
        /// <param name="robotID">AGVの番号</param>
        /// <param name="podDirectionIndex">棚の向き（0:北　1:東　2:南　3:西　4:指定しない）</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=Hetuの応答メッセージ</returns>
        public static async Task<(bool, string)> LiftDownRobot(CancellationToken token,
                                                        CommandFactory factory,
                                                        string robotID,
                                                        int podDirectionIndex = 4)
        {
            var getRobotListReturnMessage = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();
            var rb = getRobotListReturnMessage.Data.RobotList
                .Where(x => x.RobotID == robotID)
                .FirstOrDefault();
            //指定したAGVが見つからない場合はここで終了
            if (rb == null)
            {
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
                return (true, $"AGV[{robotID}]が持っている棚はありません。");
            }
            var param = new MovePodParam(
                robotID,
                podID,
                DestinationModes.StorageID,
                nodeID,
                isEndWait: true,
                unload: unload
                );

            switch (podDirectionIndex)
            {
                case 0:
                    param.PodFace = Direction.North;
                    break;
                case 1:
                    param.PodFace = Direction.East;
                    break;
                case 2:
                    param.PodFace = Direction.South;
                    break;
                case 3:
                    param.PodFace = Direction.West;
                    break;
                case 4:
                    param.PodFace = Direction.NoSelect;
                    break;
            }
            return await MovePod(token, factory, param);
        }

        /// <summary>
        /// AGVの占有状態を解除します
        /// </summary>
        /// <param name="factory">ファクトリ</param>
        /// <param name="robotID">AGVの号機</param>
        /// <returns>isSuccess=成功=true 失敗=false,　messages=応答メッセージ</returns>
        public static async Task<(bool, string)> UnsetOwner(CommandFactory factory, string robotID)
        {
            var task = new Task<(bool, string)>(() =>
            {
                var robotList = (GetRobotListReturnMessage)factory.Create(new GetRobotListParam()).DoAction();
                var rb = robotList.Data.RobotList.Where(x => x.RobotID == robotID).FirstOrDefault();
                if (rb == null)
                {
                    return (true, $"AGV[{robotID}]が見つからないためunsetOwnerは行いません。");
                }
                if (rb.Owner == "TES")
                {
                    return (true, $"AGV[{robotID}]の所有者はTESのためunsetOwnerは行いません。");
                }

                var unsetOwnerResult = factory.Create(new UnsetOwnerParam(robotID)).DoAction();

                return unsetOwnerResult.ReturnMsg != "succ"
                    ? (false, $"AGV[{robotID}]に対してUnsetOwnerが失敗しました。[{unsetOwnerResult.ReturnCode}]{unsetOwnerResult.ReturnMsg}")
                    : (true, $"AGV[{robotID}]に対してUnsetOwnerが成功しました。");
            });
            task.Start();
            await task.ConfigureAwait(true);
            return task.Result;
        }

        public static async Task MoveRobotWithoutMessage(string serverIP, string warehouseID, string robotID, string nodeID, int robotFaceIndex, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                return;
            }


            var moveTask = new Task(() =>
            {
                var isSuccess = false;

                var moveRobotParam = GetMoveRobotParam(robotID, nodeID, robotFaceIndex: robotFaceIndex);
                do
                {
                    var moveRobotResult = (MoveRobotReturnMessage)factory.Create(moveRobotParam).DoAction();

                    if (moveRobotResult == null
                    || moveRobotResult?.Data == null
                    || moveRobotResult?.Data?.TaskID == null
                    || moveRobotResult?.Data?.TaskID == string.Empty)
                    {

                    }
                    else
                    {
                        var taskID = moveRobotResult?.Data?.TaskID;

                        do
                        {
                            var ret = (GetTaskDetailReturnMessage)factory.Create(new GetTaskDetailParam(taskID)).DoAction();
                            var detail = ret?.Data?.Detail;
                            if (detail != null)
                            {
                                if (detail.Status == TaskStatuses.Success
                                    || detail.Status == TaskStatuses.Canceled)
                                {
                                    isSuccess = true;
                                }
                                else if (detail.Status == TaskStatuses.Running)
                                {

                                }
                            }
                            else
                            {
                                Console.WriteLine($"{DateTime.Now}[detail is null]");
                            }
                        } while (!isSuccess && !token.IsCancellationRequested);
                    }
                } while (!isSuccess && !token.IsCancellationRequested);
            }, token);
            if (token.IsCancellationRequested)
            {
                return;
            }
            moveTask.Start();
            await moveTask.ConfigureAwait(true);

        }

        public static async Task MovePodWithoutMessage(string serverIP, string warehouseID, string podID
            , string nodeID, string robotID, int turnMode, int unload, int robotFaceIndex, int podFaceIndex, CancellationToken cancelToken)
        {
            var movePodParam = GetMovePodParam(robotID, nodeID, podID, turnMode, unload, robotFaceIndex, podFaceIndex);

            if (cancelToken.IsCancellationRequested)
                return;
            var factory = new CommandFactory(serverIP, warehouseID);
            if (!factory.IsConnectedTESServer())
            {
                return;
            }
            //棚を下ろす際はシンクロターンできないようにする
            if (unload == ON)
            {
                turnMode = OFF;
            }
            var moveTask = new Task(() =>
            {
                var movePodResult = (MovePodReturnMessage)factory.Create(movePodParam).DoAction();
            }, cancelToken);
            if (cancelToken.IsCancellationRequested)
                return;

            moveTask.Start();
            await moveTask.ConfigureAwait(true);
        }


        public static MoveRobotParam GetMoveRobotParam(string robotID,
                                                       string nodeID,
                                                       //bool isEndWait = true,
                                                       //bool ownerRegist = false,
                                                       int robotFaceIndex = 4)
        {
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

            var moveRobotParam = new MoveRobotParam(
                            robotID,
                            DestinationModes.NodeID,
                            nodeID,
                            //isEndWait: isEndWait,
                            //ownerRegist: ownerRegist,
                            robotFace: robotFace
                            )
            {
                //CachingCallがnullだと例外が発生するため何もしないイベントを追加
                CachingCall = (obj, e) =>
                {
                }
            };
            return moveRobotParam;
        }

        public static MovePodParam GetMovePodParam(
                                                  string robotID,
                                                  string nodeID,
                                                  string podID,
                                                  int turnMode = OFF,
                                                  int unload = ON,
                                                  int robotFaceIndex = 4,
                                                  int podFaceIndex = 4)
        {
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
            var param = new MovePodParam(
                robotID: robotID,
                podID: podID,
                desMode: DestinationModes.StorageID,
                desID: nodeID,
                turnMode: turnMode,
                unload: unload,
                robotFace: robotFace,
                podFace: podFace
                )
            {
            };
            return param;
        }

        public static async Task RotationCheck(CommandFactory factory, string nodeID, string podID, string robotID, bool isClockwise, CancellationToken token)
        {
            if (factory == null)
            {
                return;
            }

            //移動指示

            //リフトアップ＋北
            await MovePod(token, factory, GetMovePodParam(robotID, nodeID, podID, unload: 0, podFaceIndex: 0));
            //東（西）
            await MovePod(token, factory, GetMovePodParam(robotID, nodeID, podID, unload: 0, podFaceIndex: isClockwise ? 1 : 3));
            //南
            await MovePod(token, factory, GetMovePodParam(robotID, nodeID, podID, unload: 0, podFaceIndex: 2));
            //西（東）
            await MovePod(token, factory, GetMovePodParam(robotID, nodeID, podID, unload: 0, podFaceIndex: isClockwise ? 3 : 1));
            //北＋リフトダウン
            await MovePod(token, factory, GetMovePodParam(robotID, nodeID, podID, unload: 1, podFaceIndex: 0));
        }
    }
}
