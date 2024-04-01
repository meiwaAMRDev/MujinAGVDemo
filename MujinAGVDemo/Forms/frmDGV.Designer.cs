
namespace MujinAGVDemo
{
    partial class frmDGV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrDGV = new System.Windows.Forms.Timer(this.components);
            this.checkBoxTimerRun = new System.Windows.Forms.CheckBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxPowerLog = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrDGV
            // 
            this.tmrDGV.Interval = 5000;
            this.tmrDGV.Tick += new System.EventHandler(this.tmrDGV_Tick);
            // 
            // checkBoxTimerRun
            // 
            this.checkBoxTimerRun.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxTimerRun.AutoSize = true;
            this.checkBoxTimerRun.BackColor = System.Drawing.Color.GreenYellow;
            this.checkBoxTimerRun.Location = new System.Drawing.Point(230, 4);
            this.checkBoxTimerRun.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTimerRun.Name = "checkBoxTimerRun";
            this.checkBoxTimerRun.Size = new System.Drawing.Size(77, 25);
            this.checkBoxTimerRun.TabIndex = 8;
            this.checkBoxTimerRun.Text = "監視開始";
            this.checkBoxTimerRun.UseVisualStyleBackColor = false;
            this.checkBoxTimerRun.CheckedChanged += new System.EventHandler(this.checkBoxTimerRun_CheckedChanged);
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Location = new System.Drawing.Point(4, 0);
            this.lblUpdateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(218, 15);
            this.lblUpdateTime.TabIndex = 9;
            this.lblUpdateTime.Text = "更新日時：yyyy/mm/dd hh:mm:ss";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblUpdateTime);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTimerRun);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxPowerLog);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(499, 41);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // checkBoxPowerLog
            // 
            this.checkBoxPowerLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPowerLog.AutoSize = true;
            this.checkBoxPowerLog.BackColor = System.Drawing.Color.GreenYellow;
            this.checkBoxPowerLog.Location = new System.Drawing.Point(315, 4);
            this.checkBoxPowerLog.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPowerLog.Name = "checkBoxPowerLog";
            this.checkBoxPowerLog.Size = new System.Drawing.Size(70, 25);
            this.checkBoxPowerLog.TabIndex = 10;
            this.checkBoxPowerLog.Text = "ログ開始";
            this.checkBoxPowerLog.UseVisualStyleBackColor = false;
            this.checkBoxPowerLog.CheckedChanged += new System.EventHandler(this.checkBoxPowerLog_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(499, 659);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // frmDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 700);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDGV";
            this.Text = "AGV状態監視";
            this.Load += new System.EventHandler(this.frmMove_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrDGV;
        private System.Windows.Forms.CheckBox checkBoxTimerRun;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxPowerLog;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}