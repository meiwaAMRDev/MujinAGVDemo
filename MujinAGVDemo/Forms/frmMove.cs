using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hetu20dotnet;
using Hetu20dotnet.Parameters;
using Hetu20dotnet.ReturnMsgs;

namespace MujinAGVDemo
{
    public partial class frmMove : Form
    {
        public CommandFactory Factory;
        private string p1Node = "1629184392960";
        private string p2Node = "1629184392994";

        private string robotID = "115";

        public frmMove(CommandFactory factory)
        {
            InitializeComponent();
            Factory = factory;
        }

        private void frmMove_Load(object sender, EventArgs e)
        {

        }

        private void btnMoveP1_Click(object sender, EventArgs e)
        {
            moveRobot(robotID, p1Node);
        }

        private void btnMoveP2_Click(object sender, EventArgs e)
        {
            moveRobot(robotID, p2Node);
        }

        private bool moveRobot(string robotID,string nodeID)
        {
            var moveRobotParam = new MoveRobotParam(
                            robotID,
                            DestinationModes.NodeID,
                            nodeID,
                            isEndWait: true,
                            ownerRegist: false
                            );

            var moveRobotResult = (MoveRobotReturnMessage)Factory.Create(moveRobotParam).DoAction();
            MessageBox.Show($"移動処理が終了しました。結果:{moveRobotResult.ReturnMsg}");
            return moveRobotResult.ReturnMsg == "succ";
        }
    }
}
