
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(13, 280);
            this.btnAddPod.Name = "btnAddPod";
            this.btnAddPod.Size = new System.Drawing.Size(75, 23);
            this.btnAddPod.TabIndex = 0;
            this.btnAddPod.Text = "棚追加";
            this.btnAddPod.UseVisualStyleBackColor = true;
            this.btnAddPod.Click += new System.EventHandler(this.btnAddPod_Click);
            // 
            // btnRemovePod
            // 
            this.btnRemovePod.Location = new System.Drawing.Point(108, 280);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePod.TabIndex = 1;
            this.btnRemovePod.Text = "棚削除";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(93, 39);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(100, 19);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "serverIP";
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(93, 64);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(100, 19);
            this.textBoxWarehouseID.TabIndex = 3;
            this.textBoxWarehouseID.Text = "warehouseID";
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(93, 89);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(100, 19);
            this.textBoxLayoutID.TabIndex = 4;
            this.textBoxLayoutID.Text = "layoutID";
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(93, 138);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(100, 19);
            this.textBoxNodeID.TabIndex = 6;
            this.textBoxNodeID.Text = "nodeID";
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(93, 113);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(100, 19);
            this.textBoxPodID.TabIndex = 5;
            this.textBoxPodID.Text = "podID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(372, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(433, 374);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnMovePod
            // 
            this.btnMovePod.Location = new System.Drawing.Point(13, 321);
            this.btnMovePod.Name = "btnMovePod";
            this.btnMovePod.Size = new System.Drawing.Size(75, 23);
            this.btnMovePod.TabIndex = 8;
            this.btnMovePod.Text = "棚移動";
            this.btnMovePod.UseVisualStyleBackColor = true;
            this.btnMovePod.Click += new System.EventHandler(this.btnMovePod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "serverIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "warehouseID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "layoutID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "podID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "nodeID";
            // 
            // listBoxPodDirection
            // 
            this.listBoxPodDirection.FormattingEnabled = true;
            this.listBoxPodDirection.ItemHeight = 12;
            this.listBoxPodDirection.Items.AddRange(new object[] {
            "北",
            "東",
            "西",
            "南"});
            this.listBoxPodDirection.Location = new System.Drawing.Point(23, 202);
            this.listBoxPodDirection.Name = "listBoxPodDirection";
            this.listBoxPodDirection.Size = new System.Drawing.Size(45, 52);
            this.listBoxPodDirection.TabIndex = 14;
            // 
            // listBoxAGVDirection
            // 
            this.listBoxAGVDirection.FormattingEnabled = true;
            this.listBoxAGVDirection.ItemHeight = 12;
            this.listBoxAGVDirection.Items.AddRange(new object[] {
            "北",
            "東",
            "西",
            "南"});
            this.listBoxAGVDirection.Location = new System.Drawing.Point(108, 202);
            this.listBoxAGVDirection.Name = "listBoxAGVDirection";
            this.listBoxAGVDirection.Size = new System.Drawing.Size(45, 52);
            this.listBoxAGVDirection.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "棚の向き";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "AGVの向き";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 391);
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
    }
}

