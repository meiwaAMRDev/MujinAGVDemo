
namespace MujinAGVDemo
{
    partial class frmLight
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
            this.agvDataControl = new Hetu20dotnet.Controls.AGVDataControl();
            this.checkBoxTimerRun = new System.Windows.Forms.CheckBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.btnOpenParamSettings = new System.Windows.Forms.Button();
            this.textBoxWarehouseID = new System.Windows.Forms.TextBox();
            this.textBoxLayoutID = new System.Windows.Forms.TextBox();
            this.btnLoadSetting = new System.Windows.Forms.Button();
            this.textBoxPodID = new System.Windows.Forms.TextBox();
            this.textBoxNodeID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxIsStop = new System.Windows.Forms.CheckBox();
            this.textBoxRobotID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemovePodAll = new System.Windows.Forms.Button();
            this.btnSetPodPos = new System.Windows.Forms.Button();
            this.btnAddPod = new System.Windows.Forms.Button();
            this.btnRemovePod = new System.Windows.Forms.Button();
            this.btnSetOwner = new System.Windows.Forms.Button();
            this.btnUnSetOwner = new System.Windows.Forms.Button();
            this.tmrAGVInfoUpdate = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuOpenMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // agvDataControl
            // 
            this.agvDataControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agvDataControl.Location = new System.Drawing.Point(2, 226);
            this.agvDataControl.Name = "agvDataControl";
            this.agvDataControl.Size = new System.Drawing.Size(796, 259);
            this.agvDataControl.TabIndex = 5;
            // 
            // checkBoxTimerRun
            // 
            this.checkBoxTimerRun.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxTimerRun.AutoSize = true;
            this.checkBoxTimerRun.BackColor = System.Drawing.Color.GreenYellow;
            this.checkBoxTimerRun.Location = new System.Drawing.Point(550, 203);
            this.checkBoxTimerRun.Name = "checkBoxTimerRun";
            this.checkBoxTimerRun.Size = new System.Drawing.Size(63, 22);
            this.checkBoxTimerRun.TabIndex = 7;
            this.checkBoxTimerRun.Text = "監視開始";
            this.checkBoxTimerRun.UseVisualStyleBackColor = false;
            this.checkBoxTimerRun.CheckedChanged += new System.EventHandler(this.checkBoxTimerRun_CheckedChanged);
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Location = new System.Drawing.Point(11, 205);
            this.lblUpdateTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(53, 12);
            this.lblUpdateTime.TabIndex = 6;
            this.lblUpdateTime.Text = "更新日時";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(103, 42);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(148, 19);
            this.textBoxServerIP.TabIndex = 47;
            this.textBoxServerIP.Text = "serverIP";
            // 
            // btnOpenParamSettings
            // 
            this.btnOpenParamSettings.Location = new System.Drawing.Point(266, 162);
            this.btnOpenParamSettings.Name = "btnOpenParamSettings";
            this.btnOpenParamSettings.Size = new System.Drawing.Size(106, 23);
            this.btnOpenParamSettings.TabIndex = 65;
            this.btnOpenParamSettings.Text = "設定ファイル選択";
            this.btnOpenParamSettings.UseVisualStyleBackColor = true;
            this.btnOpenParamSettings.Click += new System.EventHandler(this.btnOpenParamSettings_Click);
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(103, 67);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(148, 19);
            this.textBoxWarehouseID.TabIndex = 48;
            this.textBoxWarehouseID.Text = "warehouseID";
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(103, 92);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(148, 19);
            this.textBoxLayoutID.TabIndex = 49;
            this.textBoxLayoutID.Text = "layoutID";
            // 
            // btnLoadSetting
            // 
            this.btnLoadSetting.Location = new System.Drawing.Point(266, 123);
            this.btnLoadSetting.Name = "btnLoadSetting";
            this.btnLoadSetting.Size = new System.Drawing.Size(106, 23);
            this.btnLoadSetting.TabIndex = 63;
            this.btnLoadSetting.Text = "設定読出";
            this.btnLoadSetting.UseVisualStyleBackColor = true;
            this.btnLoadSetting.Click += new System.EventHandler(this.btnLoadSetting_Click);
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(103, 116);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(148, 19);
            this.textBoxPodID.TabIndex = 50;
            this.textBoxPodID.Text = "podID";
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(103, 140);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(148, 19);
            this.textBoxNodeID.TabIndex = 51;
            this.textBoxNodeID.Text = "nodeID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "serverIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 53;
            this.label2.Text = "warehouseID";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(266, 80);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(106, 23);
            this.btnSaveSetting.TabIndex = 60;
            this.btnSaveSetting.Text = "設定保存";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "layoutID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "podID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 56;
            this.label5.Text = "nodeID";
            // 
            // checkBoxIsStop
            // 
            this.checkBoxIsStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsStop.AutoSize = true;
            this.checkBoxIsStop.BackColor = System.Drawing.Color.GreenYellow;
            this.checkBoxIsStop.Location = new System.Drawing.Point(266, 40);
            this.checkBoxIsStop.Name = "checkBoxIsStop";
            this.checkBoxIsStop.Size = new System.Drawing.Size(63, 22);
            this.checkBoxIsStop.TabIndex = 59;
            this.checkBoxIsStop.Text = "AGV運行";
            this.checkBoxIsStop.UseVisualStyleBackColor = false;
            this.checkBoxIsStop.CheckedChanged += new System.EventHandler(this.checkBoxIsStop_CheckedChanged);
            // 
            // textBoxRobotID
            // 
            this.textBoxRobotID.Location = new System.Drawing.Point(103, 164);
            this.textBoxRobotID.Name = "textBoxRobotID";
            this.textBoxRobotID.Size = new System.Drawing.Size(148, 19);
            this.textBoxRobotID.TabIndex = 57;
            this.textBoxRobotID.Text = "robotID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "robotID";
            // 
            // btnRemovePodAll
            // 
            this.btnRemovePodAll.Location = new System.Drawing.Point(393, 101);
            this.btnRemovePodAll.Name = "btnRemovePodAll";
            this.btnRemovePodAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePodAll.TabIndex = 70;
            this.btnRemovePodAll.Text = "全棚削除";
            this.btnRemovePodAll.UseVisualStyleBackColor = true;
            this.btnRemovePodAll.Click += new System.EventHandler(this.btnRemovePodAll_Click);
            // 
            // btnSetPodPos
            // 
            this.btnSetPodPos.Location = new System.Drawing.Point(393, 129);
            this.btnSetPodPos.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetPodPos.Name = "btnSetPodPos";
            this.btnSetPodPos.Size = new System.Drawing.Size(74, 35);
            this.btnSetPodPos.TabIndex = 69;
            this.btnSetPodPos.Text = "棚位置セット";
            this.btnSetPodPos.UseVisualStyleBackColor = true;
            this.btnSetPodPos.Click += new System.EventHandler(this.btnSetPodPos_Click);
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(393, 45);
            this.btnAddPod.Name = "btnAddPod";
            this.btnAddPod.Size = new System.Drawing.Size(75, 23);
            this.btnAddPod.TabIndex = 67;
            this.btnAddPod.Text = "棚追加";
            this.btnAddPod.UseVisualStyleBackColor = true;
            this.btnAddPod.Click += new System.EventHandler(this.btnAddPod_Click);
            // 
            // btnRemovePod
            // 
            this.btnRemovePod.Location = new System.Drawing.Point(393, 73);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePod.TabIndex = 68;
            this.btnRemovePod.Text = "棚削除";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // btnSetOwner
            // 
            this.btnSetOwner.Location = new System.Drawing.Point(485, 70);
            this.btnSetOwner.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetOwner.Name = "btnSetOwner";
            this.btnSetOwner.Size = new System.Drawing.Size(87, 18);
            this.btnSetOwner.TabIndex = 72;
            this.btnSetOwner.Text = "SetOwner";
            this.btnSetOwner.UseVisualStyleBackColor = true;
            this.btnSetOwner.Click += new System.EventHandler(this.btnSetOwner_Click);
            // 
            // btnUnSetOwner
            // 
            this.btnUnSetOwner.Location = new System.Drawing.Point(484, 47);
            this.btnUnSetOwner.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnSetOwner.Name = "btnUnSetOwner";
            this.btnUnSetOwner.Size = new System.Drawing.Size(87, 18);
            this.btnUnSetOwner.TabIndex = 71;
            this.btnUnSetOwner.Text = "UnSetOwner";
            this.btnUnSetOwner.UseVisualStyleBackColor = true;
            this.btnUnSetOwner.Click += new System.EventHandler(this.btnUnSetOwner_Click);
            // 
            // tmrAGVInfoUpdate
            // 
            this.tmrAGVInfoUpdate.Interval = 5000;
            this.tmrAGVInfoUpdate.Tick += new System.EventHandler(this.tmrAGVInfoUpdate_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenMainForm});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 73;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuOpenMainForm
            // 
            this.mnuOpenMainForm.Name = "mnuOpenMainForm";
            this.mnuOpenMainForm.Size = new System.Drawing.Size(83, 20);
            this.mnuOpenMainForm.Text = "通常版を開く";
            this.mnuOpenMainForm.Click += new System.EventHandler(this.mnuOpenMainForm_Click);
            // 
            // frmLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.btnSetOwner);
            this.Controls.Add(this.btnUnSetOwner);
            this.Controls.Add(this.btnRemovePodAll);
            this.Controls.Add(this.btnSetPodPos);
            this.Controls.Add(this.btnAddPod);
            this.Controls.Add(this.btnRemovePod);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.btnOpenParamSettings);
            this.Controls.Add(this.textBoxWarehouseID);
            this.Controls.Add(this.textBoxLayoutID);
            this.Controls.Add(this.btnLoadSetting);
            this.Controls.Add(this.textBoxPodID);
            this.Controls.Add(this.textBoxNodeID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxIsStop);
            this.Controls.Add(this.textBoxRobotID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBoxTimerRun);
            this.Controls.Add(this.lblUpdateTime);
            this.Controls.Add(this.agvDataControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmLight";
            this.Text = "AGVデモソフト（軽量版）";
            this.Load += new System.EventHandler(this.frmLight_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hetu20dotnet.Controls.AGVDataControl agvDataControl;
        private System.Windows.Forms.CheckBox checkBoxTimerRun;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Button btnOpenParamSettings;
        private System.Windows.Forms.TextBox textBoxWarehouseID;
        private System.Windows.Forms.TextBox textBoxLayoutID;
        private System.Windows.Forms.Button btnLoadSetting;
        private System.Windows.Forms.TextBox textBoxPodID;
        private System.Windows.Forms.TextBox textBoxNodeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxIsStop;
        private System.Windows.Forms.TextBox textBoxRobotID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemovePodAll;
        private System.Windows.Forms.Button btnSetPodPos;
        private System.Windows.Forms.Button btnAddPod;
        private System.Windows.Forms.Button btnRemovePod;
        private System.Windows.Forms.Button btnSetOwner;
        private System.Windows.Forms.Button btnUnSetOwner;
        private System.Windows.Forms.Timer tmrAGVInfoUpdate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenMainForm;
    }
}