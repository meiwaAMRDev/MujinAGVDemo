
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
            this.agvDataControl = new Hetu20dotnet.Controls.AGVDataControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.checkBoxTimerRun.Location = new System.Drawing.Point(184, 3);
            this.checkBoxTimerRun.Name = "checkBoxTimerRun";
            this.checkBoxTimerRun.Size = new System.Drawing.Size(63, 22);
            this.checkBoxTimerRun.TabIndex = 8;
            this.checkBoxTimerRun.Text = "監視開始";
            this.checkBoxTimerRun.UseVisualStyleBackColor = false;
            this.checkBoxTimerRun.CheckedChanged += new System.EventHandler(this.checkBoxTimerRun_CheckedChanged);
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Location = new System.Drawing.Point(3, 0);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(175, 12);
            this.lblUpdateTime.TabIndex = 9;
            this.lblUpdateTime.Text = "更新日時：yyyy/mm/dd hh:mm:ss";
            // 
            // agvDataControl
            // 
            this.agvDataControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agvDataControl.Location = new System.Drawing.Point(0, 31);
            this.agvDataControl.Name = "agvDataControl";
            this.agvDataControl.Size = new System.Drawing.Size(804, 311);
            this.agvDataControl.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblUpdateTime);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTimerRun);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(806, 33);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // frmDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 342);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.agvDataControl);
            this.Name = "frmDGV";
            this.Text = "AGV状態監視";
            this.Load += new System.EventHandler(this.frmMove_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrDGV;
        private System.Windows.Forms.CheckBox checkBoxTimerRun;
        private System.Windows.Forms.Label lblUpdateTime;
        private Hetu20dotnet.Controls.AGVDataControl agvDataControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}