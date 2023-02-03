
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLight));
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
            this.mnuOpenLog = new System.Windows.Forms.ToolStripMenuItem();
            this.デバッグToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenTaskInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveCT = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMove = new System.Windows.Forms.TabPage();
            this.btnMoveCSV = new System.Windows.Forms.Button();
            this.btnMoveCancel = new System.Windows.Forms.Button();
            this.btnLoadNodeData = new System.Windows.Forms.Button();
            this.btnCycleMovePod = new System.Windows.Forms.Button();
            this.btnCycleMoveRobot = new System.Windows.Forms.Button();
            this.dgvMove = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoveAGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colMovePod = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colAddPod = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.cmbRobotFace = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbPodFace = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxChargeZoneID = new System.Windows.Forms.TextBox();
            this.chkUnload = new System.Windows.Forms.CheckBox();
            this.chkTurn = new System.Windows.Forms.CheckBox();
            this.tabExchange = new System.Windows.Forms.TabPage();
            this.cmbNode2 = new System.Windows.Forms.ComboBox();
            this.cmbNode1 = new System.Windows.Forms.ComboBox();
            this.cmbTempNode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxGroupID = new System.Windows.Forms.TextBox();
            this.txtTempNode2 = new System.Windows.Forms.TextBox();
            this.btnChangePodID = new System.Windows.Forms.Button();
            this.txtNode2 = new System.Windows.Forms.TextBox();
            this.txtNode1 = new System.Windows.Forms.TextBox();
            this.txtPod2 = new System.Windows.Forms.TextBox();
            this.txtTempNode1 = new System.Windows.Forms.TextBox();
            this.txtPod1 = new System.Windows.Forms.TextBox();
            this.btnExchangePod = new System.Windows.Forms.Button();
            this.btnCharge = new System.Windows.Forms.Button();
            this.btnTaskCancel = new System.Windows.Forms.Button();
            this.btnLiftUp = new System.Windows.Forms.Button();
            this.btnLiftDown = new System.Windows.Forms.Button();
            this.btnGetAGVData = new System.Windows.Forms.Button();
            this.chkAllSet = new System.Windows.Forms.CheckBox();
            this.tabAuto = new System.Windows.Forms.TabPage();
            this.textBoxStationListPath = new System.Windows.Forms.TextBox();
            this.numRepeatCount = new System.Windows.Forms.NumericUpDown();
            this.btnSelectCSV = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSaveSampleCSV = new System.Windows.Forms.Button();
            this.lblRunningTime = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).BeginInit();
            this.tabSetting.SuspendLayout();
            this.tabExchange.SuspendLayout();
            this.tabAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).BeginInit();
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
            this.textBoxServerIP.Location = new System.Drawing.Point(91, 6);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(148, 19);
            this.textBoxServerIP.TabIndex = 47;
            this.textBoxServerIP.Text = "serverIP";
            // 
            // btnOpenParamSettings
            // 
            this.btnOpenParamSettings.Location = new System.Drawing.Point(409, 116);
            this.btnOpenParamSettings.Name = "btnOpenParamSettings";
            this.btnOpenParamSettings.Size = new System.Drawing.Size(63, 23);
            this.btnOpenParamSettings.TabIndex = 65;
            this.btnOpenParamSettings.Text = "設定選択";
            this.btnOpenParamSettings.UseVisualStyleBackColor = true;
            this.btnOpenParamSettings.Click += new System.EventHandler(this.btnOpenParamSettings_Click);
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(91, 29);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(148, 19);
            this.textBoxWarehouseID.TabIndex = 48;
            this.textBoxWarehouseID.Text = "warehouseID";
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(91, 52);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(148, 19);
            this.textBoxLayoutID.TabIndex = 49;
            this.textBoxLayoutID.Text = "layoutID";
            // 
            // btnLoadSetting
            // 
            this.btnLoadSetting.Location = new System.Drawing.Point(409, 96);
            this.btnLoadSetting.Name = "btnLoadSetting";
            this.btnLoadSetting.Size = new System.Drawing.Size(63, 23);
            this.btnLoadSetting.TabIndex = 63;
            this.btnLoadSetting.Text = "設定読出";
            this.btnLoadSetting.UseVisualStyleBackColor = true;
            this.btnLoadSetting.Click += new System.EventHandler(this.btnLoadSetting_Click);
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(91, 75);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(148, 19);
            this.textBoxPodID.TabIndex = 50;
            this.textBoxPodID.Text = "podID";
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(91, 98);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(148, 19);
            this.textBoxNodeID.TabIndex = 51;
            this.textBoxNodeID.Text = "nodeID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "serverIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 53;
            this.label2.Text = "warehouseID";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(409, 73);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(63, 23);
            this.btnSaveSetting.TabIndex = 60;
            this.btnSaveSetting.Text = "設定保存";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 54;
            this.label3.Text = "layoutID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "podID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 101);
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
            this.checkBoxIsStop.Location = new System.Drawing.Point(409, 52);
            this.checkBoxIsStop.Name = "checkBoxIsStop";
            this.checkBoxIsStop.Size = new System.Drawing.Size(63, 22);
            this.checkBoxIsStop.TabIndex = 59;
            this.checkBoxIsStop.Text = "AGV運行";
            this.checkBoxIsStop.UseVisualStyleBackColor = false;
            this.checkBoxIsStop.CheckedChanged += new System.EventHandler(this.checkBoxIsStop_CheckedChanged);
            // 
            // textBoxRobotID
            // 
            this.textBoxRobotID.Location = new System.Drawing.Point(91, 121);
            this.textBoxRobotID.Name = "textBoxRobotID";
            this.textBoxRobotID.Size = new System.Drawing.Size(148, 19);
            this.textBoxRobotID.TabIndex = 57;
            this.textBoxRobotID.Text = "robotID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "robotID";
            // 
            // btnRemovePodAll
            // 
            this.btnRemovePodAll.Location = new System.Drawing.Point(537, 99);
            this.btnRemovePodAll.Name = "btnRemovePodAll";
            this.btnRemovePodAll.Size = new System.Drawing.Size(83, 23);
            this.btnRemovePodAll.TabIndex = 70;
            this.btnRemovePodAll.Text = "全棚削除";
            this.btnRemovePodAll.UseVisualStyleBackColor = true;
            this.btnRemovePodAll.Click += new System.EventHandler(this.btnRemovePodAll_Click);
            // 
            // btnSetPodPos
            // 
            this.btnSetPodPos.Location = new System.Drawing.Point(537, 127);
            this.btnSetPodPos.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetPodPos.Name = "btnSetPodPos";
            this.btnSetPodPos.Size = new System.Drawing.Size(82, 23);
            this.btnSetPodPos.TabIndex = 69;
            this.btnSetPodPos.Text = "棚位置セット";
            this.btnSetPodPos.UseVisualStyleBackColor = true;
            this.btnSetPodPos.Click += new System.EventHandler(this.btnSetPodPos_Click);
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(537, 43);
            this.btnAddPod.Name = "btnAddPod";
            this.btnAddPod.Size = new System.Drawing.Size(83, 23);
            this.btnAddPod.TabIndex = 67;
            this.btnAddPod.Text = "棚追加";
            this.btnAddPod.UseVisualStyleBackColor = true;
            this.btnAddPod.Click += new System.EventHandler(this.btnAddPod_Click);
            // 
            // btnRemovePod
            // 
            this.btnRemovePod.Location = new System.Drawing.Point(537, 71);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(83, 23);
            this.btnRemovePod.TabIndex = 68;
            this.btnRemovePod.Text = "棚削除";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // btnSetOwner
            // 
            this.btnSetOwner.Location = new System.Drawing.Point(628, 71);
            this.btnSetOwner.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetOwner.Name = "btnSetOwner";
            this.btnSetOwner.Size = new System.Drawing.Size(87, 23);
            this.btnSetOwner.TabIndex = 72;
            this.btnSetOwner.Text = "SetOwner";
            this.btnSetOwner.UseVisualStyleBackColor = true;
            this.btnSetOwner.Click += new System.EventHandler(this.btnSetOwner_Click);
            // 
            // btnUnSetOwner
            // 
            this.btnUnSetOwner.Location = new System.Drawing.Point(628, 43);
            this.btnUnSetOwner.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnSetOwner.Name = "btnUnSetOwner";
            this.btnUnSetOwner.Size = new System.Drawing.Size(87, 23);
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
            this.mnuOpenMainForm,
            this.mnuOpenLog,
            this.デバッグToolStripMenuItem});
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
            // mnuOpenLog
            // 
            this.mnuOpenLog.Name = "mnuOpenLog";
            this.mnuOpenLog.Size = new System.Drawing.Size(37, 20);
            this.mnuOpenLog.Text = "ログ";
            this.mnuOpenLog.Click += new System.EventHandler(this.mnuOpenLog_Click);
            // 
            // デバッグToolStripMenuItem
            // 
            this.デバッグToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenTaskInfo,
            this.mnuMoveCT});
            this.デバッグToolStripMenuItem.Name = "デバッグToolStripMenuItem";
            this.デバッグToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.デバッグToolStripMenuItem.Text = "デバッグ";
            // 
            // mnuOpenTaskInfo
            // 
            this.mnuOpenTaskInfo.Name = "mnuOpenTaskInfo";
            this.mnuOpenTaskInfo.Size = new System.Drawing.Size(148, 22);
            this.mnuOpenTaskInfo.Text = "AGVタスク情報";
            this.mnuOpenTaskInfo.Click += new System.EventHandler(this.mnuOpenTaskInfo_Click);
            // 
            // mnuMoveCT
            // 
            this.mnuMoveCT.Name = "mnuMoveCT";
            this.mnuMoveCT.Size = new System.Drawing.Size(148, 22);
            this.mnuMoveCT.Text = "CT検証";
            this.mnuMoveCT.Click += new System.EventHandler(this.mnuMoveCT_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMove);
            this.tabControl1.Controls.Add(this.tabAuto);
            this.tabControl1.Controls.Add(this.tabSetting);
            this.tabControl1.Controls.Add(this.tabExchange);
            this.tabControl1.Location = new System.Drawing.Point(2, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(529, 170);
            this.tabControl1.TabIndex = 74;
            // 
            // tabMove
            // 
            this.tabMove.Controls.Add(this.btnLoadNodeData);
            this.tabMove.Controls.Add(this.btnCycleMovePod);
            this.tabMove.Controls.Add(this.btnCycleMoveRobot);
            this.tabMove.Controls.Add(this.dgvMove);
            this.tabMove.Location = new System.Drawing.Point(4, 22);
            this.tabMove.Name = "tabMove";
            this.tabMove.Padding = new System.Windows.Forms.Padding(3);
            this.tabMove.Size = new System.Drawing.Size(521, 144);
            this.tabMove.TabIndex = 1;
            this.tabMove.Text = "移動指示";
            this.tabMove.UseVisualStyleBackColor = true;
            // 
            // btnMoveCSV
            // 
            this.btnMoveCSV.Location = new System.Drawing.Point(359, 67);
            this.btnMoveCSV.Name = "btnMoveCSV";
            this.btnMoveCSV.Size = new System.Drawing.Size(143, 23);
            this.btnMoveCSV.TabIndex = 81;
            this.btnMoveCSV.Text = "連続動作開始";
            this.btnMoveCSV.UseVisualStyleBackColor = true;
            this.btnMoveCSV.Click += new System.EventHandler(this.btnMoveCSV_Click);
            // 
            // btnMoveCancel
            // 
            this.btnMoveCancel.Location = new System.Drawing.Point(359, 118);
            this.btnMoveCancel.Name = "btnMoveCancel";
            this.btnMoveCancel.Size = new System.Drawing.Size(143, 23);
            this.btnMoveCancel.TabIndex = 81;
            this.btnMoveCancel.Text = "連続動作キャンセル";
            this.btnMoveCancel.UseVisualStyleBackColor = true;
            this.btnMoveCancel.Click += new System.EventHandler(this.btnMoveCancel_Click);
            // 
            // btnLoadNodeData
            // 
            this.btnLoadNodeData.Location = new System.Drawing.Point(195, 118);
            this.btnLoadNodeData.Name = "btnLoadNodeData";
            this.btnLoadNodeData.Size = new System.Drawing.Size(103, 23);
            this.btnLoadNodeData.TabIndex = 3;
            this.btnLoadNodeData.Text = "ノード情報取得";
            this.btnLoadNodeData.UseVisualStyleBackColor = true;
            this.btnLoadNodeData.Click += new System.EventHandler(this.btnLoadNodeData_Click);
            // 
            // btnCycleMovePod
            // 
            this.btnCycleMovePod.Location = new System.Drawing.Point(99, 118);
            this.btnCycleMovePod.Name = "btnCycleMovePod";
            this.btnCycleMovePod.Size = new System.Drawing.Size(90, 23);
            this.btnCycleMovePod.TabIndex = 2;
            this.btnCycleMovePod.Text = "連続棚移動";
            this.btnCycleMovePod.UseVisualStyleBackColor = true;
            this.btnCycleMovePod.Click += new System.EventHandler(this.btnCycleMovePod_Click);
            // 
            // btnCycleMoveRobot
            // 
            this.btnCycleMoveRobot.Location = new System.Drawing.Point(3, 118);
            this.btnCycleMoveRobot.Name = "btnCycleMoveRobot";
            this.btnCycleMoveRobot.Size = new System.Drawing.Size(90, 23);
            this.btnCycleMoveRobot.TabIndex = 1;
            this.btnCycleMoveRobot.Text = "連続AGV移動";
            this.btnCycleMoveRobot.UseVisualStyleBackColor = true;
            this.btnCycleMoveRobot.Click += new System.EventHandler(this.btnCycleMoveRobot_Click);
            // 
            // dgvMove
            // 
            this.dgvMove.AllowUserToAddRows = false;
            this.dgvMove.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colNode,
            this.colMoveAGV,
            this.colMovePod,
            this.colAddPod,
            this.colEdit});
            this.dgvMove.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMove.Location = new System.Drawing.Point(3, 3);
            this.dgvMove.Name = "dgvMove";
            this.dgvMove.RowHeadersVisible = false;
            this.dgvMove.RowTemplate.Height = 21;
            this.dgvMove.Size = new System.Drawing.Size(515, 114);
            this.dgvMove.TabIndex = 0;
            this.dgvMove.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMove_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "名前";
            this.colName.Name = "colName";
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colName.Width = 54;
            // 
            // colNode
            // 
            this.colNode.HeaderText = "ノードID";
            this.colNode.Name = "colNode";
            this.colNode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colNode.Width = 68;
            // 
            // colMoveAGV
            // 
            this.colMoveAGV.HeaderText = "AGV";
            this.colMoveAGV.Name = "colMoveAGV";
            this.colMoveAGV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMoveAGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colMoveAGV.Width = 54;
            // 
            // colMovePod
            // 
            this.colMovePod.HeaderText = "棚";
            this.colMovePod.Name = "colMovePod";
            this.colMovePod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMovePod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colMovePod.Width = 42;
            // 
            // colAddPod
            // 
            this.colAddPod.HeaderText = "棚";
            this.colAddPod.Name = "colAddPod";
            this.colAddPod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAddPod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colAddPod.Width = 42;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "編集";
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colEdit.Width = 54;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.cmbRobotFace);
            this.tabSetting.Controls.Add(this.label15);
            this.tabSetting.Controls.Add(this.cmbPodFace);
            this.tabSetting.Controls.Add(this.label7);
            this.tabSetting.Controls.Add(this.label6);
            this.tabSetting.Controls.Add(this.textBoxChargeZoneID);
            this.tabSetting.Controls.Add(this.chkUnload);
            this.tabSetting.Controls.Add(this.chkTurn);
            this.tabSetting.Controls.Add(this.textBoxServerIP);
            this.tabSetting.Controls.Add(this.label8);
            this.tabSetting.Controls.Add(this.textBoxRobotID);
            this.tabSetting.Controls.Add(this.label5);
            this.tabSetting.Controls.Add(this.label4);
            this.tabSetting.Controls.Add(this.label3);
            this.tabSetting.Controls.Add(this.label2);
            this.tabSetting.Controls.Add(this.btnOpenParamSettings);
            this.tabSetting.Controls.Add(this.label1);
            this.tabSetting.Controls.Add(this.btnLoadSetting);
            this.tabSetting.Controls.Add(this.textBoxNodeID);
            this.tabSetting.Controls.Add(this.btnSaveSetting);
            this.tabSetting.Controls.Add(this.textBoxWarehouseID);
            this.tabSetting.Controls.Add(this.checkBoxIsStop);
            this.tabSetting.Controls.Add(this.textBoxPodID);
            this.tabSetting.Controls.Add(this.textBoxLayoutID);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetting.Size = new System.Drawing.Size(521, 144);
            this.tabSetting.TabIndex = 0;
            this.tabSetting.Text = "基本設定";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // cmbRobotFace
            // 
            this.cmbRobotFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRobotFace.FormattingEnabled = true;
            this.cmbRobotFace.Items.AddRange(new object[] {
            "北",
            "東",
            "南",
            "西",
            "指定しない"});
            this.cmbRobotFace.Location = new System.Drawing.Point(312, 112);
            this.cmbRobotFace.Name = "cmbRobotFace";
            this.cmbRobotFace.Size = new System.Drawing.Size(90, 20);
            this.cmbRobotFace.TabIndex = 74;
            this.cmbRobotFace.SelectedIndexChanged += new System.EventHandler(this.cmbRobotFace_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(245, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 12);
            this.label15.TabIndex = 73;
            this.label15.Text = "AGVの向き";
            // 
            // cmbPodFace
            // 
            this.cmbPodFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPodFace.FormattingEnabled = true;
            this.cmbPodFace.Items.AddRange(new object[] {
            "北",
            "東",
            "南",
            "西",
            "指定しない"});
            this.cmbPodFace.Location = new System.Drawing.Point(312, 86);
            this.cmbPodFace.Name = "cmbPodFace";
            this.cmbPodFace.Size = new System.Drawing.Size(90, 20);
            this.cmbPodFace.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 12);
            this.label7.TabIndex = 71;
            this.label7.Text = "棚の向き";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 12);
            this.label6.TabIndex = 69;
            this.label6.Text = "chargeZoneID";
            // 
            // textBoxChargeZoneID
            // 
            this.textBoxChargeZoneID.Location = new System.Drawing.Point(324, 6);
            this.textBoxChargeZoneID.Name = "textBoxChargeZoneID";
            this.textBoxChargeZoneID.Size = new System.Drawing.Size(148, 19);
            this.textBoxChargeZoneID.TabIndex = 68;
            this.textBoxChargeZoneID.Text = "chargeZoneID";
            // 
            // chkUnload
            // 
            this.chkUnload.AutoSize = true;
            this.chkUnload.Location = new System.Drawing.Point(245, 52);
            this.chkUnload.Name = "chkUnload";
            this.chkUnload.Size = new System.Drawing.Size(130, 28);
            this.chkUnload.TabIndex = 67;
            this.chkUnload.Text = "アンロード\r\n(移動先で棚を下ろす)";
            this.chkUnload.UseVisualStyleBackColor = true;
            this.chkUnload.CheckedChanged += new System.EventHandler(this.chkUnload_CheckedChanged);
            // 
            // chkTurn
            // 
            this.chkTurn.AutoSize = true;
            this.chkTurn.Location = new System.Drawing.Point(245, 25);
            this.chkTurn.Name = "chkTurn";
            this.chkTurn.Size = new System.Drawing.Size(157, 28);
            this.chkTurn.TabIndex = 66;
            this.chkTurn.Text = "シンクロターン\r\n(AGVと棚の向きを合わせる)";
            this.chkTurn.UseVisualStyleBackColor = true;
            this.chkTurn.CheckedChanged += new System.EventHandler(this.chkTurn_CheckedChanged);
            // 
            // tabExchange
            // 
            this.tabExchange.Controls.Add(this.cmbNode2);
            this.tabExchange.Controls.Add(this.cmbNode1);
            this.tabExchange.Controls.Add(this.cmbTempNode);
            this.tabExchange.Controls.Add(this.label14);
            this.tabExchange.Controls.Add(this.label13);
            this.tabExchange.Controls.Add(this.label12);
            this.tabExchange.Controls.Add(this.label11);
            this.tabExchange.Controls.Add(this.label10);
            this.tabExchange.Controls.Add(this.label9);
            this.tabExchange.Controls.Add(this.textBoxGroupID);
            this.tabExchange.Controls.Add(this.txtTempNode2);
            this.tabExchange.Controls.Add(this.btnChangePodID);
            this.tabExchange.Controls.Add(this.txtNode2);
            this.tabExchange.Controls.Add(this.txtNode1);
            this.tabExchange.Controls.Add(this.txtPod2);
            this.tabExchange.Controls.Add(this.txtTempNode1);
            this.tabExchange.Controls.Add(this.txtPod1);
            this.tabExchange.Controls.Add(this.btnExchangePod);
            this.tabExchange.Location = new System.Drawing.Point(4, 22);
            this.tabExchange.Name = "tabExchange";
            this.tabExchange.Size = new System.Drawing.Size(521, 144);
            this.tabExchange.TabIndex = 2;
            this.tabExchange.Text = "棚交換";
            this.tabExchange.UseVisualStyleBackColor = true;
            // 
            // cmbNode2
            // 
            this.cmbNode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNode2.FormattingEnabled = true;
            this.cmbNode2.Location = new System.Drawing.Point(256, 102);
            this.cmbNode2.Name = "cmbNode2";
            this.cmbNode2.Size = new System.Drawing.Size(133, 20);
            this.cmbNode2.TabIndex = 59;
            this.cmbNode2.SelectedIndexChanged += new System.EventHandler(this.cmbNode2_SelectedIndexChanged);
            // 
            // cmbNode1
            // 
            this.cmbNode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNode1.FormattingEnabled = true;
            this.cmbNode1.Location = new System.Drawing.Point(60, 102);
            this.cmbNode1.Name = "cmbNode1";
            this.cmbNode1.Size = new System.Drawing.Size(133, 20);
            this.cmbNode1.TabIndex = 58;
            this.cmbNode1.SelectedIndexChanged += new System.EventHandler(this.cmbNode1_SelectedIndexChanged);
            // 
            // cmbTempNode
            // 
            this.cmbTempNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTempNode.FormattingEnabled = true;
            this.cmbTempNode.Location = new System.Drawing.Point(60, 57);
            this.cmbTempNode.Name = "cmbTempNode";
            this.cmbTempNode.Size = new System.Drawing.Size(133, 20);
            this.cmbTempNode.TabIndex = 57;
            this.cmbTempNode.SelectedIndexChanged += new System.EventHandler(this.cmbTempNode_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(393, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 12);
            this.label14.TabIndex = 56;
            this.label14.Text = "グループID";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(254, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 55;
            this.label13.Text = "棚2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(58, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 54;
            this.label12.Text = "棚1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 24);
            this.label11.TabIndex = 53;
            this.label11.Text = "目的P点\r\nノードID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 24);
            this.label10.TabIndex = 52;
            this.label10.Text = "退避先\r\nノードID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 12);
            this.label9.TabIndex = 51;
            this.label9.Text = "棚ID";
            // 
            // textBoxGroupID
            // 
            this.textBoxGroupID.Location = new System.Drawing.Point(395, 69);
            this.textBoxGroupID.Name = "textBoxGroupID";
            this.textBoxGroupID.Size = new System.Drawing.Size(123, 19);
            this.textBoxGroupID.TabIndex = 50;
            this.textBoxGroupID.Text = "c1665124782852";
            // 
            // txtTempNode2
            // 
            this.txtTempNode2.Location = new System.Drawing.Point(256, 77);
            this.txtTempNode2.Name = "txtTempNode2";
            this.txtTempNode2.Size = new System.Drawing.Size(133, 19);
            this.txtTempNode2.TabIndex = 7;
            this.txtTempNode2.Visible = false;
            // 
            // btnChangePodID
            // 
            this.btnChangePodID.Location = new System.Drawing.Point(200, 22);
            this.btnChangePodID.Name = "btnChangePodID";
            this.btnChangePodID.Size = new System.Drawing.Size(50, 119);
            this.btnChangePodID.TabIndex = 6;
            this.btnChangePodID.Text = "←→\r\n棚ID\r\n入替";
            this.btnChangePodID.UseVisualStyleBackColor = true;
            this.btnChangePodID.Click += new System.EventHandler(this.btnChangePodID_Click);
            // 
            // txtNode2
            // 
            this.txtNode2.Location = new System.Drawing.Point(256, 122);
            this.txtNode2.Name = "txtNode2";
            this.txtNode2.Size = new System.Drawing.Size(133, 19);
            this.txtNode2.TabIndex = 5;
            this.txtNode2.Text = "166512197650";
            // 
            // txtNode1
            // 
            this.txtNode1.Location = new System.Drawing.Point(60, 122);
            this.txtNode1.Name = "txtNode1";
            this.txtNode1.Size = new System.Drawing.Size(133, 19);
            this.txtNode1.TabIndex = 4;
            this.txtNode1.Text = "166512197651";
            // 
            // txtPod2
            // 
            this.txtPod2.Location = new System.Drawing.Point(256, 22);
            this.txtPod2.Name = "txtPod2";
            this.txtPod2.Size = new System.Drawing.Size(133, 19);
            this.txtPod2.TabIndex = 3;
            this.txtPod2.Text = "2";
            // 
            // txtTempNode1
            // 
            this.txtTempNode1.Location = new System.Drawing.Point(60, 77);
            this.txtTempNode1.Name = "txtTempNode1";
            this.txtTempNode1.Size = new System.Drawing.Size(133, 19);
            this.txtTempNode1.TabIndex = 2;
            this.txtTempNode1.Text = "166512197665";
            // 
            // txtPod1
            // 
            this.txtPod1.Location = new System.Drawing.Point(60, 22);
            this.txtPod1.Name = "txtPod1";
            this.txtPod1.Size = new System.Drawing.Size(133, 19);
            this.txtPod1.TabIndex = 1;
            this.txtPod1.Text = "1";
            // 
            // btnExchangePod
            // 
            this.btnExchangePod.Location = new System.Drawing.Point(395, 98);
            this.btnExchangePod.Name = "btnExchangePod";
            this.btnExchangePod.Size = new System.Drawing.Size(123, 46);
            this.btnExchangePod.TabIndex = 0;
            this.btnExchangePod.Text = "棚交換実行";
            this.btnExchangePod.UseVisualStyleBackColor = true;
            this.btnExchangePod.Click += new System.EventHandler(this.btnExchangePod_ClickAsync);
            // 
            // btnCharge
            // 
            this.btnCharge.Location = new System.Drawing.Point(628, 99);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size(87, 23);
            this.btnCharge.TabIndex = 75;
            this.btnCharge.Text = "充電";
            this.btnCharge.UseVisualStyleBackColor = true;
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // btnTaskCancel
            // 
            this.btnTaskCancel.Location = new System.Drawing.Point(628, 127);
            this.btnTaskCancel.Name = "btnTaskCancel";
            this.btnTaskCancel.Size = new System.Drawing.Size(87, 23);
            this.btnTaskCancel.TabIndex = 76;
            this.btnTaskCancel.Text = "タスクキャンセル";
            this.btnTaskCancel.UseVisualStyleBackColor = true;
            this.btnTaskCancel.Click += new System.EventHandler(this.btnTaskCancel_Click);
            // 
            // btnLiftUp
            // 
            this.btnLiftUp.Location = new System.Drawing.Point(720, 43);
            this.btnLiftUp.Name = "btnLiftUp";
            this.btnLiftUp.Size = new System.Drawing.Size(75, 23);
            this.btnLiftUp.TabIndex = 77;
            this.btnLiftUp.Text = "リフトアップ";
            this.btnLiftUp.UseVisualStyleBackColor = true;
            this.btnLiftUp.Click += new System.EventHandler(this.btnLiftUp_Click);
            // 
            // btnLiftDown
            // 
            this.btnLiftDown.Location = new System.Drawing.Point(720, 71);
            this.btnLiftDown.Name = "btnLiftDown";
            this.btnLiftDown.Size = new System.Drawing.Size(75, 23);
            this.btnLiftDown.TabIndex = 78;
            this.btnLiftDown.Text = "リフトダウン";
            this.btnLiftDown.UseVisualStyleBackColor = true;
            this.btnLiftDown.Click += new System.EventHandler(this.btnLiftDown_Click);
            // 
            // btnGetAGVData
            // 
            this.btnGetAGVData.Location = new System.Drawing.Point(538, 154);
            this.btnGetAGVData.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetAGVData.Name = "btnGetAGVData";
            this.btnGetAGVData.Size = new System.Drawing.Size(82, 23);
            this.btnGetAGVData.TabIndex = 79;
            this.btnGetAGVData.Text = "AGV情報";
            this.btnGetAGVData.UseVisualStyleBackColor = true;
            this.btnGetAGVData.Click += new System.EventHandler(this.btnGetAGVData_Click);
            // 
            // chkAllSet
            // 
            this.chkAllSet.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAllSet.AutoSize = true;
            this.chkAllSet.BackColor = System.Drawing.Color.GreenYellow;
            this.chkAllSet.Location = new System.Drawing.Point(628, 154);
            this.chkAllSet.Name = "chkAllSet";
            this.chkAllSet.Size = new System.Drawing.Size(51, 22);
            this.chkAllSet.TabIndex = 80;
            this.chkAllSet.Text = "全占有";
            this.chkAllSet.UseVisualStyleBackColor = false;
            this.chkAllSet.CheckedChanged += new System.EventHandler(this.chkAllSet_CheckedChanged);
            // 
            // tabAuto
            // 
            this.tabAuto.Controls.Add(this.lblRunningTime);
            this.tabAuto.Controls.Add(this.btnSaveSampleCSV);
            this.tabAuto.Controls.Add(this.label17);
            this.tabAuto.Controls.Add(this.label16);
            this.tabAuto.Controls.Add(this.btnSelectCSV);
            this.tabAuto.Controls.Add(this.textBoxStationListPath);
            this.tabAuto.Controls.Add(this.numRepeatCount);
            this.tabAuto.Controls.Add(this.btnMoveCancel);
            this.tabAuto.Controls.Add(this.btnMoveCSV);
            this.tabAuto.Location = new System.Drawing.Point(4, 22);
            this.tabAuto.Name = "tabAuto";
            this.tabAuto.Size = new System.Drawing.Size(521, 144);
            this.tabAuto.TabIndex = 3;
            this.tabAuto.Text = "連続";
            this.tabAuto.UseVisualStyleBackColor = true;
            // 
            // textBoxStationListPath
            // 
            this.textBoxStationListPath.AllowDrop = true;
            this.textBoxStationListPath.Location = new System.Drawing.Point(6, 69);
            this.textBoxStationListPath.Multiline = true;
            this.textBoxStationListPath.Name = "textBoxStationListPath";
            this.textBoxStationListPath.Size = new System.Drawing.Size(298, 47);
            this.textBoxStationListPath.TabIndex = 82;
            this.textBoxStationListPath.Text = "stationListPath";
            this.textBoxStationListPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxStationListPath_DragDrop);
            this.textBoxStationListPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxStationListPath_DragEnter);
            // 
            // numRepeatCount
            // 
            this.numRepeatCount.Location = new System.Drawing.Point(6, 22);
            this.numRepeatCount.Margin = new System.Windows.Forms.Padding(2);
            this.numRepeatCount.Name = "numRepeatCount";
            this.numRepeatCount.Size = new System.Drawing.Size(60, 19);
            this.numRepeatCount.TabIndex = 83;
            this.numRepeatCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnSelectCSV
            // 
            this.btnSelectCSV.Location = new System.Drawing.Point(5, 118);
            this.btnSelectCSV.Name = "btnSelectCSV";
            this.btnSelectCSV.Size = new System.Drawing.Size(147, 23);
            this.btnSelectCSV.TabIndex = 84;
            this.btnSelectCSV.Text = "CSV選択";
            this.btnSelectCSV.UseVisualStyleBackColor = true;
            this.btnSelectCSV.Click += new System.EventHandler(this.btnSelectCSV_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(189, 12);
            this.label16.TabIndex = 85;
            this.label16.Text = "繰り返し回数　※0なら無限に繰り返す";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 86;
            this.label17.Text = "CSVパス";
            // 
            // btnSaveSampleCSV
            // 
            this.btnSaveSampleCSV.Location = new System.Drawing.Point(157, 118);
            this.btnSaveSampleCSV.Name = "btnSaveSampleCSV";
            this.btnSaveSampleCSV.Size = new System.Drawing.Size(147, 23);
            this.btnSaveSampleCSV.TabIndex = 87;
            this.btnSaveSampleCSV.Text = "サンプルの場所を開く";
            this.btnSaveSampleCSV.UseVisualStyleBackColor = true;
            this.btnSaveSampleCSV.Click += new System.EventHandler(this.btnSaveSampleCSV_Click);
            // 
            // lblRunningTime
            // 
            this.lblRunningTime.AutoSize = true;
            this.lblRunningTime.Location = new System.Drawing.Point(357, 93);
            this.lblRunningTime.Name = "lblRunningTime";
            this.lblRunningTime.Size = new System.Drawing.Size(93, 12);
            this.lblRunningTime.TabIndex = 88;
            this.lblRunningTime.Text = "動作時間[0.0]sec";
            // 
            // frmLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.chkAllSet);
            this.Controls.Add(this.btnGetAGVData);
            this.Controls.Add(this.btnLiftDown);
            this.Controls.Add(this.btnLiftUp);
            this.Controls.Add(this.btnTaskCancel);
            this.Controls.Add(this.btnCharge);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSetOwner);
            this.Controls.Add(this.btnUnSetOwner);
            this.Controls.Add(this.btnRemovePodAll);
            this.Controls.Add(this.btnSetPodPos);
            this.Controls.Add(this.btnAddPod);
            this.Controls.Add(this.btnRemovePod);
            this.Controls.Add(this.checkBoxTimerRun);
            this.Controls.Add(this.lblUpdateTime);
            this.Controls.Add(this.agvDataControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmLight";
            this.Text = "AGVデモソフト（軽量版）";
            this.Load += new System.EventHandler(this.frmLight_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).EndInit();
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
            this.tabExchange.ResumeLayout(false);
            this.tabExchange.PerformLayout();
            this.tabAuto.ResumeLayout(false);
            this.tabAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.TabPage tabMove;
        private System.Windows.Forms.DataGridView dgvMove;
        private System.Windows.Forms.Button btnCycleMoveRobot;
        private System.Windows.Forms.Button btnCycleMovePod;
        private System.Windows.Forms.CheckBox chkTurn;
        private System.Windows.Forms.CheckBox chkUnload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxChargeZoneID;
        private System.Windows.Forms.Button btnCharge;
        private System.Windows.Forms.Button btnTaskCancel;
        private System.Windows.Forms.Button btnLiftUp;
        private System.Windows.Forms.Button btnLiftDown;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenLog;
        private System.Windows.Forms.Label label7;        
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNode;
        private System.Windows.Forms.DataGridViewButtonColumn colMoveAGV;
        private System.Windows.Forms.DataGridViewButtonColumn colMovePod;
        private System.Windows.Forms.DataGridViewButtonColumn colAddPod;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.Button btnGetAGVData;
        private System.Windows.Forms.CheckBox chkAllSet;
        private System.Windows.Forms.Button btnLoadNodeData;
        private System.Windows.Forms.TabPage tabExchange;
        private System.Windows.Forms.Button btnExchangePod;
        private System.Windows.Forms.TextBox txtTempNode1;
        private System.Windows.Forms.TextBox txtPod1;
        private System.Windows.Forms.TextBox txtNode2;
        private System.Windows.Forms.TextBox txtNode1;
        private System.Windows.Forms.TextBox txtPod2;
        private System.Windows.Forms.Button btnChangePodID;
        private System.Windows.Forms.TextBox txtTempNode2;
        private System.Windows.Forms.TextBox textBoxGroupID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbTempNode;
        private System.Windows.Forms.ComboBox cmbNode2;
        private System.Windows.Forms.ComboBox cmbNode1;
        private System.Windows.Forms.ToolStripMenuItem デバッグToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenTaskInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveCT;
        private System.Windows.Forms.ComboBox cmbPodFace;
        private System.Windows.Forms.ComboBox cmbRobotFace;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnMoveCancel;
        private System.Windows.Forms.Button btnMoveCSV;
        private System.Windows.Forms.TabPage tabAuto;
        private System.Windows.Forms.TextBox textBoxStationListPath;
        private System.Windows.Forms.NumericUpDown numRepeatCount;
        private System.Windows.Forms.Button btnSelectCSV;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSaveSampleCSV;
        private System.Windows.Forms.Label lblRunningTime;
    }
}