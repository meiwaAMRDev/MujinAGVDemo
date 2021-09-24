
namespace MujinAGVDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAddPod = new System.Windows.Forms.Button();
            this.btnRemovePod = new System.Windows.Forms.Button();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.textBoxWarehouseID = new System.Windows.Forms.TextBox();
            this.textBoxLayoutID = new System.Windows.Forms.TextBox();
            this.textBoxNodeID = new System.Windows.Forms.TextBox();
            this.textBoxPodID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMovePod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMoveST1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRobotID = new System.Windows.Forms.TextBox();
            this.btnRotationMove = new System.Windows.Forms.Button();
            this.checkBoxSynchroTurn = new System.Windows.Forms.CheckBox();
            this.checkBoxUnload = new System.Windows.Forms.CheckBox();
            this.textBoxStationListPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxIsStop = new System.Windows.Forms.CheckBox();
            this.btnMoveAGV = new System.Windows.Forms.Button();
            this.numRepeatCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxIsError = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(19, 362);
            this.btnAddPod.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPod.Name = "btnAddPod";
            this.btnAddPod.Size = new System.Drawing.Size(100, 29);
            this.btnAddPod.TabIndex = 0;
            this.btnAddPod.Text = "棚追加";
            this.btnAddPod.UseVisualStyleBackColor = true;
            this.btnAddPod.Click += new System.EventHandler(this.btnAddPod_Click);
            // 
            // btnRemovePod
            // 
            this.btnRemovePod.Location = new System.Drawing.Point(18, 398);
            this.btnRemovePod.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(100, 29);
            this.btnRemovePod.TabIndex = 1;
            this.btnRemovePod.Text = "棚削除";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(31, 25);
            this.textBoxServerIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(196, 22);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "serverIP";
            this.textBoxServerIP.TextChanged += new System.EventHandler(this.textBoxServerIP_TextChanged);
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(31, 56);
            this.textBoxWarehouseID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(196, 22);
            this.textBoxWarehouseID.TabIndex = 3;
            this.textBoxWarehouseID.Text = "warehouseID";
            this.textBoxWarehouseID.TextChanged += new System.EventHandler(this.textBoxWarehouseID_TextChanged);
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(31, 88);
            this.textBoxLayoutID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(196, 22);
            this.textBoxLayoutID.TabIndex = 4;
            this.textBoxLayoutID.Text = "layoutID";
            this.textBoxLayoutID.TextChanged += new System.EventHandler(this.textBoxLayoutID_TextChanged);
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(31, 148);
            this.textBoxNodeID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(196, 22);
            this.textBoxNodeID.TabIndex = 6;
            this.textBoxNodeID.Text = "nodeID";
            this.textBoxNodeID.TextChanged += new System.EventHandler(this.textBoxNodeID_TextChanged);
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(31, 118);
            this.textBoxPodID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(196, 22);
            this.textBoxPodID.TabIndex = 5;
            this.textBoxPodID.Text = "podID";
            this.textBoxPodID.TextChanged += new System.EventHandler(this.textBoxPodID_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(496, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(577, 468);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnMovePod
            // 
            this.btnMovePod.Location = new System.Drawing.Point(19, 434);
            this.btnMovePod.Margin = new System.Windows.Forms.Padding(4);
            this.btnMovePod.Name = "btnMovePod";
            this.btnMovePod.Size = new System.Drawing.Size(100, 29);
            this.btnMovePod.TabIndex = 8;
            this.btnMovePod.Text = "棚移動";
            this.btnMovePod.UseVisualStyleBackColor = true;
            this.btnMovePod.Click += new System.EventHandler(this.btnMovePod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "serverIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "warehouseID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "layoutID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "podID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "nodeID";
            // 
            // btnMoveST1
            // 
            this.btnMoveST1.Location = new System.Drawing.Point(127, 398);
            this.btnMoveST1.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveST1.Name = "btnMoveST1";
            this.btnMoveST1.Size = new System.Drawing.Size(100, 29);
            this.btnMoveST1.TabIndex = 18;
            this.btnMoveST1.Text = "ST1へ移動";
            this.btnMoveST1.UseVisualStyleBackColor = true;
            this.btnMoveST1.Click += new System.EventHandler(this.btnMoveST1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 188);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "robotID";
            // 
            // textBoxRobotID
            // 
            this.textBoxRobotID.Location = new System.Drawing.Point(31, 178);
            this.textBoxRobotID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotID.Name = "textBoxRobotID";
            this.textBoxRobotID.Size = new System.Drawing.Size(196, 22);
            this.textBoxRobotID.TabIndex = 21;
            this.textBoxRobotID.Text = "robotID";
            this.textBoxRobotID.TextChanged += new System.EventHandler(this.textBoxRobotID_TextChanged);
            // 
            // btnRotationMove
            // 
            this.btnRotationMove.Location = new System.Drawing.Point(255, 428);
            this.btnRotationMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotationMove.Name = "btnRotationMove";
            this.btnRotationMove.Size = new System.Drawing.Size(196, 48);
            this.btnRotationMove.TabIndex = 24;
            this.btnRotationMove.Text = "ステーション間を移動";
            this.btnRotationMove.UseVisualStyleBackColor = true;
            this.btnRotationMove.Click += new System.EventHandler(this.btnRotationMove_Click);
            // 
            // checkBoxSynchroTurn
            // 
            this.checkBoxSynchroTurn.AutoSize = true;
            this.checkBoxSynchroTurn.Location = new System.Drawing.Point(31, 228);
            this.checkBoxSynchroTurn.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSynchroTurn.Name = "checkBoxSynchroTurn";
            this.checkBoxSynchroTurn.Size = new System.Drawing.Size(106, 19);
            this.checkBoxSynchroTurn.TabIndex = 25;
            this.checkBoxSynchroTurn.Text = "シンクロターン";
            this.checkBoxSynchroTurn.UseVisualStyleBackColor = true;
            this.checkBoxSynchroTurn.CheckedChanged += new System.EventHandler(this.checkBoxSynchroTurn_CheckedChanged);
            // 
            // checkBoxUnload
            // 
            this.checkBoxUnload.AutoSize = true;
            this.checkBoxUnload.Location = new System.Drawing.Point(31, 255);
            this.checkBoxUnload.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUnload.Name = "checkBoxUnload";
            this.checkBoxUnload.Size = new System.Drawing.Size(151, 19);
            this.checkBoxUnload.TabIndex = 26;
            this.checkBoxUnload.Text = "移動先で棚を下ろす";
            this.checkBoxUnload.UseVisualStyleBackColor = true;
            this.checkBoxUnload.CheckedChanged += new System.EventHandler(this.checkBoxUnload_CheckedChanged);
            // 
            // textBoxStationListPath
            // 
            this.textBoxStationListPath.Location = new System.Drawing.Point(255, 398);
            this.textBoxStationListPath.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStationListPath.Name = "textBoxStationListPath";
            this.textBoxStationListPath.Size = new System.Drawing.Size(196, 22);
            this.textBoxStationListPath.TabIndex = 27;
            this.textBoxStationListPath.Text = "stationListPath";
            this.textBoxStationListPath.TextChanged += new System.EventHandler(this.textBoxStationListPath_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 372);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "ステーションリストのパス";
            // 
            // checkBoxIsStop
            // 
            this.checkBoxIsStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsStop.AutoSize = true;
            this.checkBoxIsStop.Location = new System.Drawing.Point(127, 438);
            this.checkBoxIsStop.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxIsStop.Name = "checkBoxIsStop";
            this.checkBoxIsStop.Size = new System.Drawing.Size(75, 25);
            this.checkBoxIsStop.TabIndex = 29;
            this.checkBoxIsStop.Text = "AGV停止";
            this.checkBoxIsStop.UseVisualStyleBackColor = true;
            this.checkBoxIsStop.CheckedChanged += new System.EventHandler(this.checkBoxIsStop_CheckedChanged);
            // 
            // btnMoveAGV
            // 
            this.btnMoveAGV.Location = new System.Drawing.Point(127, 362);
            this.btnMoveAGV.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveAGV.Name = "btnMoveAGV";
            this.btnMoveAGV.Size = new System.Drawing.Size(100, 29);
            this.btnMoveAGV.TabIndex = 30;
            this.btnMoveAGV.Text = "AGV移動";
            this.btnMoveAGV.UseVisualStyleBackColor = true;
            this.btnMoveAGV.Click += new System.EventHandler(this.btnMoveAGV_Click);
            // 
            // numRepeatCount
            // 
            this.numRepeatCount.Location = new System.Drawing.Point(31, 307);
            this.numRepeatCount.Name = "numRepeatCount";
            this.numRepeatCount.Size = new System.Drawing.Size(120, 22);
            this.numRepeatCount.TabIndex = 31;
            this.numRepeatCount.ValueChanged += new System.EventHandler(this.numRepeatCount_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 309);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "繰り返し回数";
            // 
            // checkBoxIsError
            // 
            this.checkBoxIsError.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsError.AutoSize = true;
            this.checkBoxIsError.Location = new System.Drawing.Point(363, 27);
            this.checkBoxIsError.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxIsError.Name = "checkBoxIsError";
            this.checkBoxIsError.Size = new System.Drawing.Size(91, 25);
            this.checkBoxIsError.TabIndex = 33;
            this.checkBoxIsError.Text = "エラーリセット";
            this.checkBoxIsError.UseVisualStyleBackColor = true;
            this.checkBoxIsError.CheckedChanged += new System.EventHandler(this.checkBoxIsError_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 489);
            this.Controls.Add(this.checkBoxIsError);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numRepeatCount);
            this.Controls.Add(this.btnMoveAGV);
            this.Controls.Add(this.checkBoxIsStop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxStationListPath);
            this.Controls.Add(this.checkBoxUnload);
            this.Controls.Add(this.checkBoxSynchroTurn);
            this.Controls.Add(this.btnRotationMove);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxRobotID);
            this.Controls.Add(this.btnMoveST1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMovePod);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxNodeID);
            this.Controls.Add(this.textBoxPodID);
            this.Controls.Add(this.textBoxLayoutID);
            this.Controls.Add(this.textBoxWarehouseID);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.btnRemovePod);
            this.Controls.Add(this.btnAddPod);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPod;
        private System.Windows.Forms.Button btnRemovePod;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.TextBox textBoxWarehouseID;
        private System.Windows.Forms.TextBox textBoxLayoutID;
        private System.Windows.Forms.TextBox textBoxNodeID;
        private System.Windows.Forms.TextBox textBoxPodID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMovePod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMoveST1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRobotID;
        private System.Windows.Forms.Button btnRotationMove;
        private System.Windows.Forms.CheckBox checkBoxSynchroTurn;
        private System.Windows.Forms.CheckBox checkBoxUnload;
        private System.Windows.Forms.TextBox textBoxStationListPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxIsStop;
        private System.Windows.Forms.Button btnMoveAGV;
        private System.Windows.Forms.NumericUpDown numRepeatCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxIsError;
    }
}

