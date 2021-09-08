
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
            this.listBoxPodDirection = new System.Windows.Forms.ListBox();
            this.listBoxAGVDirection = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMoveST1 = new System.Windows.Forms.Button();
            this.checkBoxStraightMove = new System.Windows.Forms.CheckBox();
            this.checkBoxRotationMove = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRobotID = new System.Windows.Forms.TextBox();
            this.btnStraightMove = new System.Windows.Forms.Button();
            this.btnRotationMove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(17, 350);
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
            this.btnRemovePod.Location = new System.Drawing.Point(144, 350);
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
            this.textBoxServerIP.Location = new System.Drawing.Point(124, 25);
            this.textBoxServerIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(196, 22);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "serverIP";
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(124, 56);
            this.textBoxWarehouseID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(196, 22);
            this.textBoxWarehouseID.TabIndex = 3;
            this.textBoxWarehouseID.Text = "warehouseID";
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(124, 87);
            this.textBoxLayoutID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(196, 22);
            this.textBoxLayoutID.TabIndex = 4;
            this.textBoxLayoutID.Text = "layoutID";
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(124, 148);
            this.textBoxNodeID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(196, 22);
            this.textBoxNodeID.TabIndex = 6;
            this.textBoxNodeID.Text = "nodeID";
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(124, 117);
            this.textBoxPodID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(196, 22);
            this.textBoxPodID.TabIndex = 5;
            this.textBoxPodID.Text = "podID";
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
            this.btnMovePod.Location = new System.Drawing.Point(17, 401);
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
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "serverIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "warehouseID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "layoutID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "podID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "nodeID";
            // 
            // listBoxPodDirection
            // 
            this.listBoxPodDirection.FormattingEnabled = true;
            this.listBoxPodDirection.ItemHeight = 15;
            this.listBoxPodDirection.Items.AddRange(new object[] {
            "北",
            "東",
            "西",
            "南"});
            this.listBoxPodDirection.Location = new System.Drawing.Point(31, 252);
            this.listBoxPodDirection.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxPodDirection.Name = "listBoxPodDirection";
            this.listBoxPodDirection.Size = new System.Drawing.Size(59, 64);
            this.listBoxPodDirection.TabIndex = 14;
            // 
            // listBoxAGVDirection
            // 
            this.listBoxAGVDirection.FormattingEnabled = true;
            this.listBoxAGVDirection.ItemHeight = 15;
            this.listBoxAGVDirection.Items.AddRange(new object[] {
            "北",
            "東",
            "西",
            "南"});
            this.listBoxAGVDirection.Location = new System.Drawing.Point(144, 252);
            this.listBoxAGVDirection.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxAGVDirection.Name = "listBoxAGVDirection";
            this.listBoxAGVDirection.Size = new System.Drawing.Size(59, 64);
            this.listBoxAGVDirection.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 220);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "棚の向き";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 220);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "AGVの向き";
            // 
            // btnMoveST1
            // 
            this.btnMoveST1.Location = new System.Drawing.Point(17, 445);
            this.btnMoveST1.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveST1.Name = "btnMoveST1";
            this.btnMoveST1.Size = new System.Drawing.Size(100, 29);
            this.btnMoveST1.TabIndex = 18;
            this.btnMoveST1.Text = "ST1へ移動";
            this.btnMoveST1.UseVisualStyleBackColor = true;
            this.btnMoveST1.Click += new System.EventHandler(this.btnMoveST1_Click);
            // 
            // checkBoxStraightMove
            // 
            this.checkBoxStraightMove.AutoSize = true;
            this.checkBoxStraightMove.Location = new System.Drawing.Point(297, 350);
            this.checkBoxStraightMove.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxStraightMove.Name = "checkBoxStraightMove";
            this.checkBoxStraightMove.Size = new System.Drawing.Size(89, 19);
            this.checkBoxStraightMove.TabIndex = 19;
            this.checkBoxStraightMove.Text = "直線連続";
            this.checkBoxStraightMove.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotationMove
            // 
            this.checkBoxRotationMove.AutoSize = true;
            this.checkBoxRotationMove.Location = new System.Drawing.Point(297, 400);
            this.checkBoxRotationMove.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRotationMove.Name = "checkBoxRotationMove";
            this.checkBoxRotationMove.Size = new System.Drawing.Size(89, 19);
            this.checkBoxRotationMove.TabIndex = 20;
            this.checkBoxRotationMove.Text = "旋回連続";
            this.checkBoxRotationMove.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 187);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "robotID";
            // 
            // textBoxRobotID
            // 
            this.textBoxRobotID.Location = new System.Drawing.Point(124, 178);
            this.textBoxRobotID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRobotID.Name = "textBoxRobotID";
            this.textBoxRobotID.Size = new System.Drawing.Size(196, 22);
            this.textBoxRobotID.TabIndex = 21;
            this.textBoxRobotID.Text = "robotID";
            // 
            // btnStraightMove
            // 
            this.btnStraightMove.Location = new System.Drawing.Point(402, 347);
            this.btnStraightMove.Name = "btnStraightMove";
            this.btnStraightMove.Size = new System.Drawing.Size(87, 47);
            this.btnStraightMove.TabIndex = 23;
            this.btnStraightMove.Text = "直線移動";
            this.btnStraightMove.UseVisualStyleBackColor = true;
            this.btnStraightMove.Click += new System.EventHandler(this.btnStraightMove_Click);
            // 
            // btnRotationMove
            // 
            this.btnRotationMove.Location = new System.Drawing.Point(402, 397);
            this.btnRotationMove.Name = "btnRotationMove";
            this.btnRotationMove.Size = new System.Drawing.Size(87, 47);
            this.btnRotationMove.TabIndex = 24;
            this.btnRotationMove.Text = "旋回移動";
            this.btnRotationMove.UseVisualStyleBackColor = true;
            this.btnRotationMove.Click += new System.EventHandler(this.btnRotationMove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 489);
            this.Controls.Add(this.btnRotationMove);
            this.Controls.Add(this.btnStraightMove);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxRobotID);
            this.Controls.Add(this.checkBoxRotationMove);
            this.Controls.Add(this.checkBoxStraightMove);
            this.Controls.Add(this.btnMoveST1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxAGVDirection);
            this.Controls.Add(this.listBoxPodDirection);
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
        private System.Windows.Forms.ListBox listBoxPodDirection;
        private System.Windows.Forms.ListBox listBoxAGVDirection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMoveST1;
        private System.Windows.Forms.CheckBox checkBoxStraightMove;
        private System.Windows.Forms.CheckBox checkBoxRotationMove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRobotID;
        private System.Windows.Forms.Button btnStraightMove;
        private System.Windows.Forms.Button btnRotationMove;
    }
}

