
namespace MujinAGVDemo
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.textBoxWarehouseID = new System.Windows.Forms.TextBox();
            this.textBoxLayoutID = new System.Windows.Forms.TextBox();
            this.textBoxNodeID = new System.Windows.Forms.TextBox();
            this.textBoxPodID = new System.Windows.Forms.TextBox();
            this.btnMovePod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRunLineIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentLineProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgRepeartCount = new System.Windows.Forms.ToolStripProgressBar();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAGVData = new System.Windows.Forms.TabPage();
            this.agvDataControl = new Hetu20dotnet.Controls.AGVDataControl();
            this.checkBoxTimerRun = new System.Windows.Forms.CheckBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.tabManual = new System.Windows.Forms.TabPage();
            this.btnMovePodAuto = new System.Windows.Forms.Button();
            this.textBoxGroupID = new System.Windows.Forms.TextBox();
            this.textBoxChargeAreaID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnCharge = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.listBoxDirection = new System.Windows.Forms.ListBox();
            this.tabAuto = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSaveSampleCSV = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectCSV = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.btnGetTaskDetail = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxTaskID = new System.Windows.Forms.TextBox();
            this.tabOwner = new System.Windows.Forms.TabPage();
            this.btnUnsetOwnerAll = new System.Windows.Forms.Button();
            this.btnSetOwner = new System.Windows.Forms.Button();
            this.btnUnSetOwner = new System.Windows.Forms.Button();
            this.btnShowOwner = new System.Windows.Forms.Button();
            this.tabPodData = new System.Windows.Forms.TabPage();
            this.btnShowAGVPosition = new System.Windows.Forms.Button();
            this.btnShowPodDetail = new System.Windows.Forms.Button();
            this.tabPodControl = new System.Windows.Forms.TabPage();
            this.btnRemovePodAll = new System.Windows.Forms.Button();
            this.btnSetPodPos = new System.Windows.Forms.Button();
            this.btnAddPod = new System.Windows.Forms.Button();
            this.btnRemovePod = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabLift = new System.Windows.Forms.TabPage();
            this.btnLiftDownAll = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.listBoxPodDirection = new System.Windows.Forms.ListBox();
            this.btnLiftUp = new System.Windows.Forms.Button();
            this.btnLiftDown = new System.Windows.Forms.Button();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.btnOpenParamSettings = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnLoadSetting = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenLogDir = new System.Windows.Forms.ToolStripMenuItem();
            this.デバッグToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMove = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrAGVInfoUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAGVData.SuspendLayout();
            this.tabManual.SuspendLayout();
            this.tabAuto.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.tabOwner.SuspendLayout();
            this.tabPodData.SuspendLayout();
            this.tabPodControl.SuspendLayout();
            this.tabLift.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(100, 16);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(148, 19);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "serverIP";
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(100, 41);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(148, 19);
            this.textBoxWarehouseID.TabIndex = 3;
            this.textBoxWarehouseID.Text = "warehouseID";
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(100, 66);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(148, 19);
            this.textBoxLayoutID.TabIndex = 4;
            this.textBoxLayoutID.Text = "layoutID";
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(100, 114);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(148, 19);
            this.textBoxNodeID.TabIndex = 6;
            this.textBoxNodeID.Text = "nodeID";
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(100, 90);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(148, 19);
            this.textBoxPodID.TabIndex = 5;
            this.textBoxPodID.Text = "podID";
            // 
            // btnMovePod
            // 
            this.btnMovePod.Location = new System.Drawing.Point(380, 73);
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
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "serverIP";
            this.toolTip.SetToolTip(this.label1, "HetuサーバーのIPアドレスです。");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "warehouseID";
            this.toolTip.SetToolTip(this.label2, "Hetuのトップ画面の右上に\r\n表示されるWarehouseIDです。");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "layoutID";
            this.toolTip.SetToolTip(this.label3, "マップエディタの「基本データ」→「コンテナタイプ」\r\n→「ID」で確認することができます");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "podID";
            this.toolTip.SetToolTip(this.label4, "棚のQRコード番号です。\r\n連続動作の際に空白にすると、AGVのみで移動します。");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "nodeID";
            this.toolTip.SetToolTip(this.label5, "移動先地点のノードIDです。");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "robotID";
            this.toolTip.SetToolTip(this.label8, "AGVの番号です。");
            // 
            // textBoxRobotID
            // 
            this.textBoxRobotID.Location = new System.Drawing.Point(100, 138);
            this.textBoxRobotID.Name = "textBoxRobotID";
            this.textBoxRobotID.Size = new System.Drawing.Size(148, 19);
            this.textBoxRobotID.TabIndex = 21;
            this.textBoxRobotID.Text = "robotID";
            // 
            // btnRotationMove
            // 
            this.btnRotationMove.Location = new System.Drawing.Point(308, 115);
            this.btnRotationMove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRotationMove.Name = "btnRotationMove";
            this.btnRotationMove.Size = new System.Drawing.Size(147, 38);
            this.btnRotationMove.TabIndex = 24;
            this.btnRotationMove.Text = "CSVに従って棚移動";
            this.btnRotationMove.UseVisualStyleBackColor = true;
            this.btnRotationMove.Click += new System.EventHandler(this.btnRotationMove_Click);
            // 
            // checkBoxSynchroTurn
            // 
            this.checkBoxSynchroTurn.AutoSize = true;
            this.checkBoxSynchroTurn.Location = new System.Drawing.Point(6, 11);
            this.checkBoxSynchroTurn.Name = "checkBoxSynchroTurn";
            this.checkBoxSynchroTurn.Size = new System.Drawing.Size(87, 16);
            this.checkBoxSynchroTurn.TabIndex = 25;
            this.checkBoxSynchroTurn.Text = "シンクロターン";
            this.checkBoxSynchroTurn.UseVisualStyleBackColor = true;
            // 
            // checkBoxUnload
            // 
            this.checkBoxUnload.AutoSize = true;
            this.checkBoxUnload.Location = new System.Drawing.Point(6, 33);
            this.checkBoxUnload.Name = "checkBoxUnload";
            this.checkBoxUnload.Size = new System.Drawing.Size(122, 16);
            this.checkBoxUnload.TabIndex = 26;
            this.checkBoxUnload.Text = "移動先で棚を下ろす";
            this.checkBoxUnload.UseVisualStyleBackColor = true;
            // 
            // textBoxStationListPath
            // 
            this.textBoxStationListPath.Location = new System.Drawing.Point(131, 50);
            this.textBoxStationListPath.Name = "textBoxStationListPath";
            this.textBoxStationListPath.Size = new System.Drawing.Size(298, 19);
            this.textBoxStationListPath.TabIndex = 27;
            this.textBoxStationListPath.Text = "stationListPath";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "読み込むCSVのパス";
            // 
            // checkBoxIsStop
            // 
            this.checkBoxIsStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsStop.AutoSize = true;
            this.checkBoxIsStop.BackColor = System.Drawing.Color.GreenYellow;
            this.checkBoxIsStop.Location = new System.Drawing.Point(500, 14);
            this.checkBoxIsStop.Name = "checkBoxIsStop";
            this.checkBoxIsStop.Size = new System.Drawing.Size(63, 22);
            this.checkBoxIsStop.TabIndex = 29;
            this.checkBoxIsStop.Text = "AGV運行";
            this.checkBoxIsStop.UseVisualStyleBackColor = false;
            this.checkBoxIsStop.CheckedChanged += new System.EventHandler(this.checkBoxIsStop_CheckedChanged);
            // 
            // btnMoveAGV
            // 
            this.btnMoveAGV.Location = new System.Drawing.Point(380, 102);
            this.btnMoveAGV.Name = "btnMoveAGV";
            this.btnMoveAGV.Size = new System.Drawing.Size(75, 23);
            this.btnMoveAGV.TabIndex = 30;
            this.btnMoveAGV.Text = "AGV移動";
            this.btnMoveAGV.UseVisualStyleBackColor = true;
            this.btnMoveAGV.Click += new System.EventHandler(this.btnMoveAGV_Click);
            // 
            // numRepeatCount
            // 
            this.numRepeatCount.Location = new System.Drawing.Point(309, 13);
            this.numRepeatCount.Margin = new System.Windows.Forms.Padding(2);
            this.numRepeatCount.Name = "numRepeatCount";
            this.numRepeatCount.Size = new System.Drawing.Size(90, 19);
            this.numRepeatCount.TabIndex = 31;
            this.numRepeatCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 24);
            this.label7.TabIndex = 32;
            this.label7.Text = "CSV内容の繰り返し回数\r\n0回にすると無限に繰り返します。\r\n";
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgress,
            this.lblRunLineIndex,
            this.lblCurrentLineProcess,
            this.prgRepeartCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(807, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRunLineIndex
            // 
            this.lblRunLineIndex.Name = "lblRunLineIndex";
            this.lblRunLineIndex.Size = new System.Drawing.Size(0, 17);
            // 
            // lblCurrentLineProcess
            // 
            this.lblCurrentLineProcess.Name = "lblCurrentLineProcess";
            this.lblCurrentLineProcess.Size = new System.Drawing.Size(0, 17);
            // 
            // prgRepeartCount
            // 
            this.prgRepeartCount.Name = "prgRepeartCount";
            this.prgRepeartCount.Size = new System.Drawing.Size(75, 16);
            this.prgRepeartCount.Step = 1;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(500, 54);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(106, 23);
            this.btnSaveSetting.TabIndex = 35;
            this.btnSaveSetting.Text = "設定保存";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(369, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "podIDで指定した棚をnodeIDの地点へrobotIDで指定したAGVが運搬します。";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(309, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "nodeIDで指定した地点へrobotIDで指定したAGVが移動します。";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAGVData);
            this.tabControl1.Controls.Add(this.tabManual);
            this.tabControl1.Controls.Add(this.tabAuto);
            this.tabControl1.Controls.Add(this.tabTask);
            this.tabControl1.Controls.Add(this.tabOwner);
            this.tabControl1.Controls.Add(this.tabPodData);
            this.tabControl1.Controls.Add(this.tabPodControl);
            this.tabControl1.Controls.Add(this.tabLift);
            this.tabControl1.Controls.Add(this.tabSetting);
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(807, 298);
            this.tabControl1.TabIndex = 40;
            // 
            // tabAGVData
            // 
            this.tabAGVData.Controls.Add(this.agvDataControl);
            this.tabAGVData.Controls.Add(this.checkBoxTimerRun);
            this.tabAGVData.Controls.Add(this.lblUpdateTime);
            this.tabAGVData.Location = new System.Drawing.Point(4, 22);
            this.tabAGVData.Margin = new System.Windows.Forms.Padding(2);
            this.tabAGVData.Name = "tabAGVData";
            this.tabAGVData.Padding = new System.Windows.Forms.Padding(2);
            this.tabAGVData.Size = new System.Drawing.Size(799, 272);
            this.tabAGVData.TabIndex = 7;
            this.tabAGVData.Text = "AGV情報";
            this.tabAGVData.UseVisualStyleBackColor = true;
            // 
            // agvDataControl
            // 
            this.agvDataControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agvDataControl.Location = new System.Drawing.Point(0, 26);
            this.agvDataControl.Name = "agvDataControl";
            this.agvDataControl.Size = new System.Drawing.Size(796, 245);
            this.agvDataControl.TabIndex = 4;
            // 
            // checkBoxTimerRun
            // 
            this.checkBoxTimerRun.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxTimerRun.AutoSize = true;
            this.checkBoxTimerRun.BackColor = System.Drawing.Color.GreenYellow;
            this.checkBoxTimerRun.Location = new System.Drawing.Point(544, 0);
            this.checkBoxTimerRun.Name = "checkBoxTimerRun";
            this.checkBoxTimerRun.Size = new System.Drawing.Size(63, 22);
            this.checkBoxTimerRun.TabIndex = 3;
            this.checkBoxTimerRun.Text = "監視開始";
            this.checkBoxTimerRun.UseVisualStyleBackColor = false;
            this.checkBoxTimerRun.CheckedChanged += new System.EventHandler(this.checkBoxTimerRun_CheckedChanged);
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Location = new System.Drawing.Point(5, 2);
            this.lblUpdateTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(53, 12);
            this.lblUpdateTime.TabIndex = 2;
            this.lblUpdateTime.Text = "更新日時";
            // 
            // tabManual
            // 
            this.tabManual.Controls.Add(this.btnMovePodAuto);
            this.tabManual.Controls.Add(this.textBoxGroupID);
            this.tabManual.Controls.Add(this.textBoxChargeAreaID);
            this.tabManual.Controls.Add(this.label22);
            this.tabManual.Controls.Add(this.btnCharge);
            this.tabManual.Controls.Add(this.label20);
            this.tabManual.Controls.Add(this.listBoxDirection);
            this.tabManual.Controls.Add(this.checkBoxUnload);
            this.tabManual.Controls.Add(this.label12);
            this.tabManual.Controls.Add(this.label11);
            this.tabManual.Controls.Add(this.checkBoxSynchroTurn);
            this.tabManual.Controls.Add(this.btnMovePod);
            this.tabManual.Controls.Add(this.btnMoveAGV);
            this.tabManual.Location = new System.Drawing.Point(4, 22);
            this.tabManual.Name = "tabManual";
            this.tabManual.Padding = new System.Windows.Forms.Padding(3);
            this.tabManual.Size = new System.Drawing.Size(799, 272);
            this.tabManual.TabIndex = 0;
            this.tabManual.Text = "各個";
            this.tabManual.UseVisualStyleBackColor = true;
            // 
            // btnMovePodAuto
            // 
            this.btnMovePodAuto.Location = new System.Drawing.Point(380, 196);
            this.btnMovePodAuto.Name = "btnMovePodAuto";
            this.btnMovePodAuto.Size = new System.Drawing.Size(75, 45);
            this.btnMovePodAuto.TabIndex = 50;
            this.btnMovePodAuto.Text = "自動割当\r\n棚移動";
            this.btnMovePodAuto.UseVisualStyleBackColor = true;
            this.btnMovePodAuto.Click += new System.EventHandler(this.btnMovePodAuto_Click);
            // 
            // textBoxGroupID
            // 
            this.textBoxGroupID.Location = new System.Drawing.Point(156, 209);
            this.textBoxGroupID.Name = "textBoxGroupID";
            this.textBoxGroupID.Size = new System.Drawing.Size(148, 19);
            this.textBoxGroupID.TabIndex = 49;
            // 
            // textBoxChargeAreaID
            // 
            this.textBoxChargeAreaID.Location = new System.Drawing.Point(156, 165);
            this.textBoxChargeAreaID.Name = "textBoxChargeAreaID";
            this.textBoxChargeAreaID.Size = new System.Drawing.Size(148, 19);
            this.textBoxChargeAreaID.TabIndex = 48;
            this.textBoxChargeAreaID.Text = "充電エリアID";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 167);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(140, 12);
            this.label22.TabIndex = 44;
            this.label22.Text = "指定したAGVを充電します。";
            // 
            // btnCharge
            // 
            this.btnCharge.Location = new System.Drawing.Point(380, 156);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size(75, 23);
            this.btnCharge.TabIndex = 43;
            this.btnCharge.Text = "充電";
            this.btnCharge.UseVisualStyleBackColor = true;
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 55);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 12);
            this.label20.TabIndex = 42;
            this.label20.Text = "移動後のAGVの向き";
            // 
            // listBoxDirection
            // 
            this.listBoxDirection.FormattingEnabled = true;
            this.listBoxDirection.ItemHeight = 12;
            this.listBoxDirection.Items.AddRange(new object[] {
            "北",
            "東",
            "南",
            "西",
            "指定しない"});
            this.listBoxDirection.Location = new System.Drawing.Point(136, 51);
            this.listBoxDirection.Name = "listBoxDirection";
            this.listBoxDirection.Size = new System.Drawing.Size(99, 16);
            this.listBoxDirection.TabIndex = 41;
            // 
            // tabAuto
            // 
            this.tabAuto.Controls.Add(this.label18);
            this.tabAuto.Controls.Add(this.label17);
            this.tabAuto.Controls.Add(this.btnSaveSampleCSV);
            this.tabAuto.Controls.Add(this.btnCancel);
            this.tabAuto.Controls.Add(this.btnSelectCSV);
            this.tabAuto.Controls.Add(this.label15);
            this.tabAuto.Controls.Add(this.btnRotationMove);
            this.tabAuto.Controls.Add(this.textBoxStationListPath);
            this.tabAuto.Controls.Add(this.label6);
            this.tabAuto.Controls.Add(this.label7);
            this.tabAuto.Controls.Add(this.numRepeatCount);
            this.tabAuto.Location = new System.Drawing.Point(4, 22);
            this.tabAuto.Name = "tabAuto";
            this.tabAuto.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuto.Size = new System.Drawing.Size(799, 272);
            this.tabAuto.TabIndex = 1;
            this.tabAuto.Text = "連続";
            this.tabAuto.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 84);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(157, 12);
            this.label18.TabIndex = 48;
            this.label18.Text = "サンプルCSVの場所を開きます。";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 161);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(195, 24);
            this.label17.TabIndex = 47;
            this.label17.Text = "連続動作をキャンセルします。\r\n現在のサイクルを行った後に終了します。";
            // 
            // btnSaveSampleCSV
            // 
            this.btnSaveSampleCSV.Location = new System.Drawing.Point(308, 81);
            this.btnSaveSampleCSV.Name = "btnSaveSampleCSV";
            this.btnSaveSampleCSV.Size = new System.Drawing.Size(147, 19);
            this.btnSaveSampleCSV.TabIndex = 46;
            this.btnSaveSampleCSV.Text = "サンプルCSVの場所を開く";
            this.btnSaveSampleCSV.UseVisualStyleBackColor = true;
            this.btnSaveSampleCSV.Click += new System.EventHandler(this.btnSaveSampleCSV_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(308, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 23);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "連続動作キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectCSV
            // 
            this.btnSelectCSV.Location = new System.Drawing.Point(423, 50);
            this.btnSelectCSV.Name = "btnSelectCSV";
            this.btnSelectCSV.Size = new System.Drawing.Size(32, 19);
            this.btnSelectCSV.TabIndex = 34;
            this.btnSelectCSV.UseVisualStyleBackColor = true;
            this.btnSelectCSV.Click += new System.EventHandler(this.btnSelectCSV_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(181, 24);
            this.label15.TabIndex = 33;
            this.label15.Text = "CSVの内容に従って棚を運搬します。\r\nヘッダー1行は必ず付与してください。\r\n";
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.btnGetTaskDetail);
            this.tabTask.Controls.Add(this.label19);
            this.tabTask.Controls.Add(this.textBoxTaskID);
            this.tabTask.Location = new System.Drawing.Point(4, 22);
            this.tabTask.Margin = new System.Windows.Forms.Padding(2);
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Windows.Forms.Padding(2);
            this.tabTask.Size = new System.Drawing.Size(799, 272);
            this.tabTask.TabIndex = 2;
            this.tabTask.Text = "タスク";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // btnGetTaskDetail
            // 
            this.btnGetTaskDetail.Location = new System.Drawing.Point(21, 54);
            this.btnGetTaskDetail.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetTaskDetail.Name = "btnGetTaskDetail";
            this.btnGetTaskDetail.Size = new System.Drawing.Size(234, 18);
            this.btnGetTaskDetail.TabIndex = 12;
            this.btnGetTaskDetail.Text = "情報をログに出力";
            this.toolTip.SetToolTip(this.btnGetTaskDetail, "タスクの情報をログに出力します。");
            this.btnGetTaskDetail.UseVisualStyleBackColor = true;
            this.btnGetTaskDetail.Click += new System.EventHandler(this.btnGetTaskDetail_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 11;
            this.label19.Text = "タスクID";
            this.toolTip.SetToolTip(this.label19, "状況を確認したいタスクのIDです。");
            // 
            // textBoxTaskID
            // 
            this.textBoxTaskID.Location = new System.Drawing.Point(108, 22);
            this.textBoxTaskID.Name = "textBoxTaskID";
            this.textBoxTaskID.Size = new System.Drawing.Size(148, 19);
            this.textBoxTaskID.TabIndex = 10;
            this.textBoxTaskID.Text = "taskID";
            // 
            // tabOwner
            // 
            this.tabOwner.Controls.Add(this.btnUnsetOwnerAll);
            this.tabOwner.Controls.Add(this.btnSetOwner);
            this.tabOwner.Controls.Add(this.btnUnSetOwner);
            this.tabOwner.Controls.Add(this.btnShowOwner);
            this.tabOwner.Location = new System.Drawing.Point(4, 22);
            this.tabOwner.Margin = new System.Windows.Forms.Padding(2);
            this.tabOwner.Name = "tabOwner";
            this.tabOwner.Padding = new System.Windows.Forms.Padding(2);
            this.tabOwner.Size = new System.Drawing.Size(799, 272);
            this.tabOwner.TabIndex = 3;
            this.tabOwner.Text = "所有者";
            this.tabOwner.UseVisualStyleBackColor = true;
            // 
            // btnUnsetOwnerAll
            // 
            this.btnUnsetOwnerAll.Location = new System.Drawing.Point(252, 127);
            this.btnUnsetOwnerAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnsetOwnerAll.Name = "btnUnsetOwnerAll";
            this.btnUnsetOwnerAll.Size = new System.Drawing.Size(234, 18);
            this.btnUnsetOwnerAll.TabIndex = 16;
            this.btnUnsetOwnerAll.Text = "UnSetOwnerAll";
            this.toolTip.SetToolTip(this.btnUnsetOwnerAll, "全AGVのSetOwnerを解除します。");
            this.btnUnsetOwnerAll.UseVisualStyleBackColor = true;
            this.btnUnsetOwnerAll.Click += new System.EventHandler(this.btnUnsetOwnerAll_Click);
            // 
            // btnSetOwner
            // 
            this.btnSetOwner.Location = new System.Drawing.Point(5, 149);
            this.btnSetOwner.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetOwner.Name = "btnSetOwner";
            this.btnSetOwner.Size = new System.Drawing.Size(234, 18);
            this.btnSetOwner.TabIndex = 15;
            this.btnSetOwner.Text = "SetOwner";
            this.toolTip.SetToolTip(this.btnSetOwner, "AGVのSetOwnerを実行します。");
            this.btnSetOwner.UseVisualStyleBackColor = true;
            this.btnSetOwner.Click += new System.EventHandler(this.btnSetOwner_Click);
            // 
            // btnUnSetOwner
            // 
            this.btnUnSetOwner.Location = new System.Drawing.Point(4, 126);
            this.btnUnSetOwner.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnSetOwner.Name = "btnUnSetOwner";
            this.btnUnSetOwner.Size = new System.Drawing.Size(234, 18);
            this.btnUnSetOwner.TabIndex = 14;
            this.btnUnSetOwner.Text = "UnSetOwner";
            this.toolTip.SetToolTip(this.btnUnSetOwner, "AGVのSetOwnerを解除します。");
            this.btnUnSetOwner.UseVisualStyleBackColor = true;
            this.btnUnSetOwner.Click += new System.EventHandler(this.btnUnSetOwner_Click);
            // 
            // btnShowOwner
            // 
            this.btnShowOwner.Location = new System.Drawing.Point(4, 89);
            this.btnShowOwner.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowOwner.Name = "btnShowOwner";
            this.btnShowOwner.Size = new System.Drawing.Size(234, 18);
            this.btnShowOwner.TabIndex = 13;
            this.btnShowOwner.Text = "所有者確認";
            this.toolTip.SetToolTip(this.btnShowOwner, "AGVの所有者を表示します。");
            this.btnShowOwner.UseVisualStyleBackColor = true;
            this.btnShowOwner.Click += new System.EventHandler(this.btnShowOwner_Click);
            // 
            // tabPodData
            // 
            this.tabPodData.Controls.Add(this.btnShowAGVPosition);
            this.tabPodData.Controls.Add(this.btnShowPodDetail);
            this.tabPodData.Location = new System.Drawing.Point(4, 22);
            this.tabPodData.Name = "tabPodData";
            this.tabPodData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPodData.Size = new System.Drawing.Size(799, 272);
            this.tabPodData.TabIndex = 4;
            this.tabPodData.Text = "棚情報確認";
            this.tabPodData.UseVisualStyleBackColor = true;
            // 
            // btnShowAGVPosition
            // 
            this.btnShowAGVPosition.Location = new System.Drawing.Point(6, 85);
            this.btnShowAGVPosition.Name = "btnShowAGVPosition";
            this.btnShowAGVPosition.Size = new System.Drawing.Size(75, 23);
            this.btnShowAGVPosition.TabIndex = 1;
            this.btnShowAGVPosition.Text = "AGV位置";
            this.btnShowAGVPosition.UseVisualStyleBackColor = true;
            this.btnShowAGVPosition.Click += new System.EventHandler(this.btnShowAGVPosition_Click);
            // 
            // btnShowPodDetail
            // 
            this.btnShowPodDetail.Location = new System.Drawing.Point(6, 40);
            this.btnShowPodDetail.Name = "btnShowPodDetail";
            this.btnShowPodDetail.Size = new System.Drawing.Size(75, 23);
            this.btnShowPodDetail.TabIndex = 0;
            this.btnShowPodDetail.Text = "棚情報確認";
            this.btnShowPodDetail.UseVisualStyleBackColor = true;
            this.btnShowPodDetail.Click += new System.EventHandler(this.btnShowPodDetail_Click);
            // 
            // tabPodControl
            // 
            this.tabPodControl.Controls.Add(this.btnRemovePodAll);
            this.tabPodControl.Controls.Add(this.btnSetPodPos);
            this.tabPodControl.Controls.Add(this.btnAddPod);
            this.tabPodControl.Controls.Add(this.btnRemovePod);
            this.tabPodControl.Controls.Add(this.label10);
            this.tabPodControl.Controls.Add(this.label9);
            this.tabPodControl.Location = new System.Drawing.Point(4, 22);
            this.tabPodControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabPodControl.Name = "tabPodControl";
            this.tabPodControl.Padding = new System.Windows.Forms.Padding(2);
            this.tabPodControl.Size = new System.Drawing.Size(799, 272);
            this.tabPodControl.TabIndex = 5;
            this.tabPodControl.Text = "棚の追加と削除";
            this.tabPodControl.UseVisualStyleBackColor = true;
            // 
            // btnRemovePodAll
            // 
            this.btnRemovePodAll.Location = new System.Drawing.Point(381, 74);
            this.btnRemovePodAll.Name = "btnRemovePodAll";
            this.btnRemovePodAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePodAll.TabIndex = 43;
            this.btnRemovePodAll.Text = "全棚削除";
            this.btnRemovePodAll.UseVisualStyleBackColor = true;
            this.btnRemovePodAll.Click += new System.EventHandler(this.btnRemovePodAll_Click);
            // 
            // btnSetPodPos
            // 
            this.btnSetPodPos.Location = new System.Drawing.Point(381, 102);
            this.btnSetPodPos.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetPodPos.Name = "btnSetPodPos";
            this.btnSetPodPos.Size = new System.Drawing.Size(74, 35);
            this.btnSetPodPos.TabIndex = 42;
            this.btnSetPodPos.Text = "棚位置セット";
            this.btnSetPodPos.UseVisualStyleBackColor = true;
            this.btnSetPodPos.Click += new System.EventHandler(this.btnSetPodPos_Click);
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(381, 18);
            this.btnAddPod.Name = "btnAddPod";
            this.btnAddPod.Size = new System.Drawing.Size(75, 23);
            this.btnAddPod.TabIndex = 38;
            this.btnAddPod.Text = "棚追加";
            this.btnAddPod.UseVisualStyleBackColor = true;
            this.btnAddPod.Click += new System.EventHandler(this.btnAddPod_Click);
            // 
            // btnRemovePod
            // 
            this.btnRemovePod.Location = new System.Drawing.Point(381, 46);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePod.TabIndex = 39;
            this.btnRemovePod.Text = "棚削除";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 12);
            this.label10.TabIndex = 41;
            this.label10.Text = "podIDで指定した棚を削除します。";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(287, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "nodeIDで指定した地点にpodIDで指定した棚を作成します。\r\n";
            // 
            // tabLift
            // 
            this.tabLift.Controls.Add(this.btnLiftDownAll);
            this.tabLift.Controls.Add(this.label23);
            this.tabLift.Controls.Add(this.listBoxPodDirection);
            this.tabLift.Controls.Add(this.btnLiftUp);
            this.tabLift.Controls.Add(this.btnLiftDown);
            this.tabLift.Location = new System.Drawing.Point(4, 22);
            this.tabLift.Name = "tabLift";
            this.tabLift.Padding = new System.Windows.Forms.Padding(3);
            this.tabLift.Size = new System.Drawing.Size(799, 272);
            this.tabLift.TabIndex = 6;
            this.tabLift.Text = "その場動作";
            this.tabLift.UseVisualStyleBackColor = true;
            // 
            // btnLiftDownAll
            // 
            this.btnLiftDownAll.Location = new System.Drawing.Point(6, 117);
            this.btnLiftDownAll.Name = "btnLiftDownAll";
            this.btnLiftDownAll.Size = new System.Drawing.Size(131, 23);
            this.btnLiftDownAll.TabIndex = 53;
            this.btnLiftDownAll.Text = "全AGVの棚を下ろす";
            this.btnLiftDownAll.UseVisualStyleBackColor = true;
            this.btnLiftDownAll.Click += new System.EventHandler(this.btnLiftDownAll_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(94, 12);
            this.label23.TabIndex = 52;
            this.label23.Text = "移動後の棚の向き";
            // 
            // listBoxPodDirection
            // 
            this.listBoxPodDirection.FormattingEnabled = true;
            this.listBoxPodDirection.ItemHeight = 12;
            this.listBoxPodDirection.Items.AddRange(new object[] {
            "北",
            "東",
            "南",
            "西",
            "指定しない"});
            this.listBoxPodDirection.Location = new System.Drawing.Point(10, 34);
            this.listBoxPodDirection.Name = "listBoxPodDirection";
            this.listBoxPodDirection.Size = new System.Drawing.Size(99, 16);
            this.listBoxPodDirection.TabIndex = 51;
            // 
            // btnLiftUp
            // 
            this.btnLiftUp.Location = new System.Drawing.Point(6, 88);
            this.btnLiftUp.Name = "btnLiftUp";
            this.btnLiftUp.Size = new System.Drawing.Size(131, 23);
            this.btnLiftUp.TabIndex = 50;
            this.btnLiftUp.Text = "その場で棚を持ち上げる";
            this.btnLiftUp.UseVisualStyleBackColor = true;
            this.btnLiftUp.Click += new System.EventHandler(this.btnLiftUp_Click);
            // 
            // btnLiftDown
            // 
            this.btnLiftDown.Location = new System.Drawing.Point(6, 59);
            this.btnLiftDown.Name = "btnLiftDown";
            this.btnLiftDown.Size = new System.Drawing.Size(131, 23);
            this.btnLiftDown.TabIndex = 49;
            this.btnLiftDown.Text = "その場で棚を下ろす";
            this.btnLiftDown.UseVisualStyleBackColor = true;
            this.btnLiftDown.Click += new System.EventHandler(this.btnLiftDown_Click);
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.label21);
            this.tabSetting.Controls.Add(this.textBoxServerIP);
            this.tabSetting.Controls.Add(this.btnOpenParamSettings);
            this.tabSetting.Controls.Add(this.textBoxWarehouseID);
            this.tabSetting.Controls.Add(this.label16);
            this.tabSetting.Controls.Add(this.textBoxLayoutID);
            this.tabSetting.Controls.Add(this.btnLoadSetting);
            this.tabSetting.Controls.Add(this.textBoxPodID);
            this.tabSetting.Controls.Add(this.label14);
            this.tabSetting.Controls.Add(this.textBoxNodeID);
            this.tabSetting.Controls.Add(this.label13);
            this.tabSetting.Controls.Add(this.label1);
            this.tabSetting.Controls.Add(this.label2);
            this.tabSetting.Controls.Add(this.btnSaveSetting);
            this.tabSetting.Controls.Add(this.label3);
            this.tabSetting.Controls.Add(this.label4);
            this.tabSetting.Controls.Add(this.label5);
            this.tabSetting.Controls.Add(this.checkBoxIsStop);
            this.tabSetting.Controls.Add(this.textBoxRobotID);
            this.tabSetting.Controls.Add(this.label8);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Margin = new System.Windows.Forms.Padding(2);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(2);
            this.tabSetting.Size = new System.Drawing.Size(799, 272);
            this.tabSetting.TabIndex = 8;
            this.tabSetting.Text = "設定";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(283, 135);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(132, 24);
            this.label21.TabIndex = 46;
            this.label21.Text = "設定ファイルを選択します。\r\n\r\n";
            // 
            // btnOpenParamSettings
            // 
            this.btnOpenParamSettings.Location = new System.Drawing.Point(500, 136);
            this.btnOpenParamSettings.Name = "btnOpenParamSettings";
            this.btnOpenParamSettings.Size = new System.Drawing.Size(106, 23);
            this.btnOpenParamSettings.TabIndex = 45;
            this.btnOpenParamSettings.Text = "設定ファイル選択";
            this.btnOpenParamSettings.UseVisualStyleBackColor = true;
            this.btnOpenParamSettings.Click += new System.EventHandler(this.btnOpenParamSettings_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(283, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 24);
            this.label16.TabIndex = 44;
            this.label16.Text = "設定ファイルを読み出します。\r\n\r\n";
            // 
            // btnLoadSetting
            // 
            this.btnLoadSetting.Location = new System.Drawing.Point(500, 97);
            this.btnLoadSetting.Name = "btnLoadSetting";
            this.btnLoadSetting.Size = new System.Drawing.Size(106, 23);
            this.btnLoadSetting.TabIndex = 43;
            this.btnLoadSetting.Text = "設定読出";
            this.btnLoadSetting.UseVisualStyleBackColor = true;
            this.btnLoadSetting.Click += new System.EventHandler(this.btnLoadSetting_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(283, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(175, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "現在の設定をファイルに保存します。\r\n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(283, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(210, 12);
            this.label13.TabIndex = 41;
            this.label13.Text = "指定のAGVを一時停止・停止解除します。";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.デバッグToolStripMenuItem,
            this.mnuMove});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(807, 24);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenLogDir});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // mnuOpenLogDir
            // 
            this.mnuOpenLogDir.Name = "mnuOpenLogDir";
            this.mnuOpenLogDir.Size = new System.Drawing.Size(154, 22);
            this.mnuOpenLogDir.Text = "ログの場所を開く";
            this.mnuOpenLogDir.Click += new System.EventHandler(this.mnuOpenLogDir_Click);
            // 
            // デバッグToolStripMenuItem
            // 
            this.デバッグToolStripMenuItem.Name = "デバッグToolStripMenuItem";
            this.デバッグToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.デバッグToolStripMenuItem.Text = "デバッグ";
            // 
            // mnuMove
            // 
            this.mnuMove.Name = "mnuMove";
            this.mnuMove.Size = new System.Drawing.Size(66, 20);
            this.mnuMove.Text = "AGV移動";
            this.mnuMove.Click += new System.EventHandler(this.mnuMove_Click);
            // 
            // tmrAGVInfoUpdate
            // 
            this.tmrAGVInfoUpdate.Interval = 5000;
            this.tmrAGVInfoUpdate.Tick += new System.EventHandler(this.tmrAGVInfoUpdate_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 348);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "AGVデモソフト";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAGVData.ResumeLayout(false);
            this.tabAGVData.PerformLayout();
            this.tabManual.ResumeLayout(false);
            this.tabManual.PerformLayout();
            this.tabAuto.ResumeLayout(false);
            this.tabAuto.PerformLayout();
            this.tabTask.ResumeLayout(false);
            this.tabTask.PerformLayout();
            this.tabOwner.ResumeLayout(false);
            this.tabPodData.ResumeLayout(false);
            this.tabPodControl.ResumeLayout(false);
            this.tabPodControl.PerformLayout();
            this.tabLift.ResumeLayout(false);
            this.tabLift.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.TextBox textBoxWarehouseID;
        private System.Windows.Forms.TextBox textBoxLayoutID;
        private System.Windows.Forms.TextBox textBoxNodeID;
        private System.Windows.Forms.TextBox textBoxPodID;
        private System.Windows.Forms.Button btnMovePod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.ToolStripStatusLabel lblProgress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblRunLineIndex;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentLineProcess;
        private System.Windows.Forms.ToolStripProgressBar prgRepeartCount;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabManual;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnLoadSetting;
        private System.Windows.Forms.Button btnSelectCSV;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveSampleCSV;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxTaskID;
        private System.Windows.Forms.Button btnGetTaskDetail;
        private System.Windows.Forms.TabPage tabOwner;
        private System.Windows.Forms.Button btnUnSetOwner;
        private System.Windows.Forms.Button btnShowOwner;
        private System.Windows.Forms.ListBox listBoxDirection;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnOpenParamSettings;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPodData;
        private System.Windows.Forms.Button btnShowPodDetail;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenLogDir;
        private System.Windows.Forms.Button btnSetOwner;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnCharge;
        private System.Windows.Forms.TabPage tabPodControl;
        private System.Windows.Forms.Button btnAddPod;
        private System.Windows.Forms.Button btnRemovePod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxChargeAreaID;
        private System.Windows.Forms.ToolStripMenuItem デバッグToolStripMenuItem;
        private System.Windows.Forms.Button btnLiftDown;
        private System.Windows.Forms.TabPage tabLift;
        private System.Windows.Forms.Button btnLiftUp;
        private System.Windows.Forms.Button btnShowAGVPosition;
        private System.Windows.Forms.Button btnSetPodPos;
        private System.Windows.Forms.TabPage tabAGVData;
        private System.Windows.Forms.Timer tmrAGVInfoUpdate;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.CheckBox checkBoxTimerRun;
        private System.Windows.Forms.ListBox listBoxPodDirection;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.Button btnRemovePodAll;
        private System.Windows.Forms.Button btnLiftDownAll;
        private System.Windows.Forms.Button btnUnsetOwnerAll;
        private System.Windows.Forms.Button btnMovePodAuto;
        private System.Windows.Forms.TextBox textBoxGroupID;
        private Hetu20dotnet.Controls.AGVDataControl agvDataControl;
        private System.Windows.Forms.TabPage tabAuto;
        private System.Windows.Forms.ToolStripMenuItem mnuMove;
    }
}

