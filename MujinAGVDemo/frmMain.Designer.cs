﻿
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxChargeAreaID = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnCharge = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.listBoxDirection = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSaveSampleCSV = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectCSV = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGetTaskDetail = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxTaskID = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnSetOwner = new System.Windows.Forms.Button();
            this.btnUnSetOwner = new System.Windows.Forms.Button();
            this.btnShowOwner = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnShowAGVPosition = new System.Windows.Forms.Button();
            this.btnShowPodDetail = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnAddPod = new System.Windows.Forms.Button();
            this.btnRemovePod = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnLiftUp = new System.Windows.Forms.Button();
            this.btnLiftDown = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnLoadSetting = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnOpenParamSettings = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenLogDir = new System.Windows.Forms.ToolStripMenuItem();
            this.デバッグToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveRobotDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOldAGVMove = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetPodPos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(152, 45);
            this.textBoxServerIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(196, 22);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "serverIP";
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(152, 76);
            this.textBoxWarehouseID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(196, 22);
            this.textBoxWarehouseID.TabIndex = 3;
            this.textBoxWarehouseID.Text = "warehouseID";
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(152, 108);
            this.textBoxLayoutID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(196, 22);
            this.textBoxLayoutID.TabIndex = 4;
            this.textBoxLayoutID.Text = "layoutID";
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(152, 168);
            this.textBoxNodeID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(196, 22);
            this.textBoxNodeID.TabIndex = 6;
            this.textBoxNodeID.Text = "nodeID";
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(152, 138);
            this.textBoxPodID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(196, 22);
            this.textBoxPodID.TabIndex = 5;
            this.textBoxPodID.Text = "podID";
            // 
            // btnMovePod
            // 
            this.btnMovePod.Location = new System.Drawing.Point(507, 91);
            this.btnMovePod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.label1.Location = new System.Drawing.Point(33, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "serverIP";
            this.toolTip.SetToolTip(this.label1, "HetuサーバーのIPアドレスです。");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "warehouseID";
            this.toolTip.SetToolTip(this.label2, "Hetuのトップ画面の右上に\r\n表示されるWarehouseIDです。");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "layoutID";
            this.toolTip.SetToolTip(this.label3, "マップエディタの「基本データ」→「コンテナタイプ」\r\n→「ID」で確認することができます");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "podID";
            this.toolTip.SetToolTip(this.label4, "棚のQRコード番号です。");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "nodeID";
            this.toolTip.SetToolTip(this.label5, "移動先地点のノードIDです。");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 211);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "robotID";
            this.toolTip.SetToolTip(this.label8, "AGVの番号です。");
            // 
            // textBoxRobotID
            // 
            this.textBoxRobotID.Location = new System.Drawing.Point(152, 198);
            this.textBoxRobotID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRobotID.Name = "textBoxRobotID";
            this.textBoxRobotID.Size = new System.Drawing.Size(196, 22);
            this.textBoxRobotID.TabIndex = 21;
            this.textBoxRobotID.Text = "robotID";
            // 
            // btnRotationMove
            // 
            this.btnRotationMove.Location = new System.Drawing.Point(411, 144);
            this.btnRotationMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRotationMove.Name = "btnRotationMove";
            this.btnRotationMove.Size = new System.Drawing.Size(196, 48);
            this.btnRotationMove.TabIndex = 24;
            this.btnRotationMove.Text = "CSVに従って棚移動";
            this.btnRotationMove.UseVisualStyleBackColor = true;
            this.btnRotationMove.Click += new System.EventHandler(this.btnRotationMove_Click);
            // 
            // checkBoxSynchroTurn
            // 
            this.checkBoxSynchroTurn.AutoSize = true;
            this.checkBoxSynchroTurn.Location = new System.Drawing.Point(8, 14);
            this.checkBoxSynchroTurn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSynchroTurn.Name = "checkBoxSynchroTurn";
            this.checkBoxSynchroTurn.Size = new System.Drawing.Size(106, 19);
            this.checkBoxSynchroTurn.TabIndex = 25;
            this.checkBoxSynchroTurn.Text = "シンクロターン";
            this.checkBoxSynchroTurn.UseVisualStyleBackColor = true;
            // 
            // checkBoxUnload
            // 
            this.checkBoxUnload.AutoSize = true;
            this.checkBoxUnload.Location = new System.Drawing.Point(8, 41);
            this.checkBoxUnload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxUnload.Name = "checkBoxUnload";
            this.checkBoxUnload.Size = new System.Drawing.Size(151, 19);
            this.checkBoxUnload.TabIndex = 26;
            this.checkBoxUnload.Text = "移動先で棚を下ろす";
            this.checkBoxUnload.UseVisualStyleBackColor = true;
            // 
            // textBoxStationListPath
            // 
            this.textBoxStationListPath.Location = new System.Drawing.Point(175, 62);
            this.textBoxStationListPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStationListPath.Name = "textBoxStationListPath";
            this.textBoxStationListPath.Size = new System.Drawing.Size(396, 22);
            this.textBoxStationListPath.TabIndex = 27;
            this.textBoxStationListPath.Text = "stationListPath";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "読み込むCSVのパス";
            // 
            // checkBoxIsStop
            // 
            this.checkBoxIsStop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsStop.AutoSize = true;
            this.checkBoxIsStop.BackColor = System.Drawing.Color.Red;
            this.checkBoxIsStop.Location = new System.Drawing.Point(684, 42);
            this.checkBoxIsStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxIsStop.Name = "checkBoxIsStop";
            this.checkBoxIsStop.Size = new System.Drawing.Size(75, 25);
            this.checkBoxIsStop.TabIndex = 29;
            this.checkBoxIsStop.Text = "AGV停止";
            this.checkBoxIsStop.UseVisualStyleBackColor = false;
            this.checkBoxIsStop.CheckedChanged += new System.EventHandler(this.checkBoxIsStop_CheckedChanged);
            // 
            // btnMoveAGV
            // 
            this.btnMoveAGV.Location = new System.Drawing.Point(507, 128);
            this.btnMoveAGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMoveAGV.Name = "btnMoveAGV";
            this.btnMoveAGV.Size = new System.Drawing.Size(100, 29);
            this.btnMoveAGV.TabIndex = 30;
            this.btnMoveAGV.Text = "AGV移動";
            this.btnMoveAGV.UseVisualStyleBackColor = true;
            this.btnMoveAGV.Click += new System.EventHandler(this.btnMoveAGV_Click);
            // 
            // numRepeatCount
            // 
            this.numRepeatCount.Location = new System.Drawing.Point(412, 16);
            this.numRepeatCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numRepeatCount.Name = "numRepeatCount";
            this.numRepeatCount.Size = new System.Drawing.Size(120, 22);
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
            this.label7.Location = new System.Drawing.Point(11, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 30);
            this.label7.TabIndex = 32;
            this.label7.Text = "CSV内容の繰り返し回数\r\n0回にすると無限に繰り返します。\r\n";
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 20);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProgress,
            this.lblRunLineIndex,
            this.lblCurrentLineProcess,
            this.prgRepeartCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(849, 26);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRunLineIndex
            // 
            this.lblRunLineIndex.Name = "lblRunLineIndex";
            this.lblRunLineIndex.Size = new System.Drawing.Size(0, 20);
            // 
            // lblCurrentLineProcess
            // 
            this.lblCurrentLineProcess.Name = "lblCurrentLineProcess";
            this.lblCurrentLineProcess.Size = new System.Drawing.Size(0, 20);
            // 
            // prgRepeartCount
            // 
            this.prgRepeartCount.Name = "prgRepeartCount";
            this.prgRepeartCount.Size = new System.Drawing.Size(100, 18);
            this.prgRepeartCount.Step = 1;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(684, 92);
            this.btnSaveSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(141, 29);
            this.btnSaveSetting.TabIndex = 35;
            this.btnSaveSetting.Text = "設定保存";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 98);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(460, 15);
            this.label11.TabIndex = 38;
            this.label11.Text = "podIDで指定した棚をnodeIDの地点へrobotIDで指定したAGVが運搬します。";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 134);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(386, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "nodeIDで指定した地点へrobotIDで指定したAGVが移動します。";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(31, 239);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 271);
            this.tabControl1.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxChargeAreaID);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.btnCharge);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.listBoxDirection);
            this.tabPage1.Controls.Add(this.checkBoxUnload);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.checkBoxSynchroTurn);
            this.tabPage1.Controls.Add(this.btnMovePod);
            this.tabPage1.Controls.Add(this.btnMoveAGV);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(636, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "各個";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxChargeAreaID
            // 
            this.textBoxChargeAreaID.Location = new System.Drawing.Point(208, 206);
            this.textBoxChargeAreaID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxChargeAreaID.Name = "textBoxChargeAreaID";
            this.textBoxChargeAreaID.Size = new System.Drawing.Size(196, 22);
            this.textBoxChargeAreaID.TabIndex = 48;
            this.textBoxChargeAreaID.Text = "充電エリアID";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 209);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(174, 15);
            this.label22.TabIndex = 44;
            this.label22.Text = "指定したAGVを充電します。";
            // 
            // btnCharge
            // 
            this.btnCharge.Location = new System.Drawing.Point(507, 195);
            this.btnCharge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size(100, 29);
            this.btnCharge.TabIndex = 43;
            this.btnCharge.Text = "充電";
            this.btnCharge.UseVisualStyleBackColor = true;
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 69);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 15);
            this.label20.TabIndex = 42;
            this.label20.Text = "移動後のAGVの向き";
            // 
            // listBoxDirection
            // 
            this.listBoxDirection.FormattingEnabled = true;
            this.listBoxDirection.ItemHeight = 15;
            this.listBoxDirection.Items.AddRange(new object[] {
            "北",
            "東",
            "南",
            "西",
            "指定しない"});
            this.listBoxDirection.Location = new System.Drawing.Point(181, 64);
            this.listBoxDirection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxDirection.Name = "listBoxDirection";
            this.listBoxDirection.Size = new System.Drawing.Size(131, 19);
            this.listBoxDirection.TabIndex = 41;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.btnSaveSampleCSV);
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.btnSelectCSV);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.btnRotationMove);
            this.tabPage2.Controls.Add(this.textBoxStationListPath);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.numRepeatCount);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(636, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "連続";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 105);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(194, 15);
            this.label18.TabIndex = 48;
            this.label18.Text = "サンプルCSVの場所を開きます。";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 201);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(243, 30);
            this.label17.TabIndex = 47;
            this.label17.Text = "連続動作をキャンセルします。\r\n現在のサイクルを行った後に終了します。";
            // 
            // btnSaveSampleCSV
            // 
            this.btnSaveSampleCSV.Location = new System.Drawing.Point(411, 101);
            this.btnSaveSampleCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveSampleCSV.Name = "btnSaveSampleCSV";
            this.btnSaveSampleCSV.Size = new System.Drawing.Size(196, 24);
            this.btnSaveSampleCSV.TabIndex = 46;
            this.btnSaveSampleCSV.Text = "サンプルCSVの場所を開く";
            this.btnSaveSampleCSV.UseVisualStyleBackColor = true;
            this.btnSaveSampleCSV.Click += new System.EventHandler(this.btnSaveSampleCSV_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(411, 202);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(196, 29);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "連続動作キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectCSV
            // 
            this.btnSelectCSV.Location = new System.Drawing.Point(564, 62);
            this.btnSelectCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectCSV.Name = "btnSelectCSV";
            this.btnSelectCSV.Size = new System.Drawing.Size(43, 24);
            this.btnSelectCSV.TabIndex = 34;
            this.btnSelectCSV.UseVisualStyleBackColor = true;
            this.btnSelectCSV.Click += new System.EventHandler(this.btnSelectCSV_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 144);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(226, 30);
            this.label15.TabIndex = 33;
            this.label15.Text = "CSVの内容に従って棚を運搬します。\r\nヘッダー1行は必ず付与してください。\r\n";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGetTaskDetail);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.textBoxTaskID);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(636, 242);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "タスク";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGetTaskDetail
            // 
            this.btnGetTaskDetail.Location = new System.Drawing.Point(28, 68);
            this.btnGetTaskDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGetTaskDetail.Name = "btnGetTaskDetail";
            this.btnGetTaskDetail.Size = new System.Drawing.Size(312, 22);
            this.btnGetTaskDetail.TabIndex = 12;
            this.btnGetTaskDetail.Text = "情報をログに出力";
            this.toolTip.SetToolTip(this.btnGetTaskDetail, "タスクの情報をログに出力します。");
            this.btnGetTaskDetail.UseVisualStyleBackColor = true;
            this.btnGetTaskDetail.Click += new System.EventHandler(this.btnGetTaskDetail_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 31);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 15);
            this.label19.TabIndex = 11;
            this.label19.Text = "タスクID";
            this.toolTip.SetToolTip(this.label19, "状況を確認したいタスクのIDです。");
            // 
            // textBoxTaskID
            // 
            this.textBoxTaskID.Location = new System.Drawing.Point(144, 28);
            this.textBoxTaskID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTaskID.Name = "textBoxTaskID";
            this.textBoxTaskID.Size = new System.Drawing.Size(196, 22);
            this.textBoxTaskID.TabIndex = 10;
            this.textBoxTaskID.Text = "taskID";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnSetOwner);
            this.tabPage4.Controls.Add(this.btnUnSetOwner);
            this.tabPage4.Controls.Add(this.btnShowOwner);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(636, 242);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "所有者";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnSetOwner
            // 
            this.btnSetOwner.Location = new System.Drawing.Point(7, 186);
            this.btnSetOwner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetOwner.Name = "btnSetOwner";
            this.btnSetOwner.Size = new System.Drawing.Size(312, 22);
            this.btnSetOwner.TabIndex = 15;
            this.btnSetOwner.Text = "SetOwner";
            this.toolTip.SetToolTip(this.btnSetOwner, "AGVのSetOwnerを解除します。");
            this.btnSetOwner.UseVisualStyleBackColor = true;
            this.btnSetOwner.Click += new System.EventHandler(this.btnSetOwner_Click);
            // 
            // btnUnSetOwner
            // 
            this.btnUnSetOwner.Location = new System.Drawing.Point(5, 158);
            this.btnUnSetOwner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUnSetOwner.Name = "btnUnSetOwner";
            this.btnUnSetOwner.Size = new System.Drawing.Size(312, 22);
            this.btnUnSetOwner.TabIndex = 14;
            this.btnUnSetOwner.Text = "UnSetOwner";
            this.toolTip.SetToolTip(this.btnUnSetOwner, "AGVのSetOwnerを解除します。");
            this.btnUnSetOwner.UseVisualStyleBackColor = true;
            this.btnUnSetOwner.Click += new System.EventHandler(this.btnUnSetOwner_Click);
            // 
            // btnShowOwner
            // 
            this.btnShowOwner.Location = new System.Drawing.Point(5, 111);
            this.btnShowOwner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowOwner.Name = "btnShowOwner";
            this.btnShowOwner.Size = new System.Drawing.Size(312, 22);
            this.btnShowOwner.TabIndex = 13;
            this.btnShowOwner.Text = "所有者確認";
            this.toolTip.SetToolTip(this.btnShowOwner, "AGVの所有者を表示します。");
            this.btnShowOwner.UseVisualStyleBackColor = true;
            this.btnShowOwner.Click += new System.EventHandler(this.btnShowOwner_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnShowAGVPosition);
            this.tabPage5.Controls.Add(this.btnShowPodDetail);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage5.Size = new System.Drawing.Size(636, 242);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "棚情報確認";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnShowAGVPosition
            // 
            this.btnShowAGVPosition.Location = new System.Drawing.Point(8, 106);
            this.btnShowAGVPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowAGVPosition.Name = "btnShowAGVPosition";
            this.btnShowAGVPosition.Size = new System.Drawing.Size(100, 29);
            this.btnShowAGVPosition.TabIndex = 1;
            this.btnShowAGVPosition.Text = "AGV位置";
            this.btnShowAGVPosition.UseVisualStyleBackColor = true;
            this.btnShowAGVPosition.Click += new System.EventHandler(this.btnShowAGVPosition_Click);
            // 
            // btnShowPodDetail
            // 
            this.btnShowPodDetail.Location = new System.Drawing.Point(8, 50);
            this.btnShowPodDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowPodDetail.Name = "btnShowPodDetail";
            this.btnShowPodDetail.Size = new System.Drawing.Size(100, 29);
            this.btnShowPodDetail.TabIndex = 0;
            this.btnShowPodDetail.Text = "棚情報確認";
            this.btnShowPodDetail.UseVisualStyleBackColor = true;
            this.btnShowPodDetail.Click += new System.EventHandler(this.btnShowPodDetail_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnSetPodPos);
            this.tabPage6.Controls.Add(this.btnAddPod);
            this.tabPage6.Controls.Add(this.btnRemovePod);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Size = new System.Drawing.Size(636, 242);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "棚の追加と削除";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(508, 22);
            this.btnAddPod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPod.Name = "btnAddPod";
            this.btnAddPod.Size = new System.Drawing.Size(100, 29);
            this.btnAddPod.TabIndex = 38;
            this.btnAddPod.Text = "棚追加";
            this.btnAddPod.UseVisualStyleBackColor = true;
            this.btnAddPod.Click += new System.EventHandler(this.btnAddPod_Click);
            // 
            // btnRemovePod
            // 
            this.btnRemovePod.Location = new System.Drawing.Point(508, 58);
            this.btnRemovePod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(100, 29);
            this.btnRemovePod.TabIndex = 39;
            this.btnRemovePod.Text = "棚削除";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 62);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 15);
            this.label10.TabIndex = 41;
            this.label10.Text = "podIDで指定した棚を削除します。";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(361, 15);
            this.label9.TabIndex = 40;
            this.label9.Text = "nodeIDで指定した地点にpodIDで指定した棚を作成します。\r\n";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.btnLiftUp);
            this.tabPage7.Controls.Add(this.btnLiftDown);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage7.Size = new System.Drawing.Size(636, 242);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "その場動作";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // btnLiftUp
            // 
            this.btnLiftUp.Location = new System.Drawing.Point(8, 90);
            this.btnLiftUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLiftUp.Name = "btnLiftUp";
            this.btnLiftUp.Size = new System.Drawing.Size(175, 29);
            this.btnLiftUp.TabIndex = 50;
            this.btnLiftUp.Text = "その場で棚を持ち上げる";
            this.btnLiftUp.UseVisualStyleBackColor = true;
            this.btnLiftUp.Click += new System.EventHandler(this.btnLiftUp_Click);
            // 
            // btnLiftDown
            // 
            this.btnLiftDown.Location = new System.Drawing.Point(8, 54);
            this.btnLiftDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLiftDown.Name = "btnLiftDown";
            this.btnLiftDown.Size = new System.Drawing.Size(175, 29);
            this.btnLiftDown.TabIndex = 49;
            this.btnLiftDown.Text = "その場で棚を下ろす";
            this.btnLiftDown.UseVisualStyleBackColor = true;
            this.btnLiftDown.Click += new System.EventHandler(this.btnLiftDown_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(395, 49);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(261, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "指定のAGVを一時停止・停止解除します。";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(395, 99);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(219, 15);
            this.label14.TabIndex = 42;
            this.label14.Text = "現在の設定をファイルに保存します。\r\n";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(395, 141);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(178, 30);
            this.label16.TabIndex = 44;
            this.label16.Text = "設定ファイルを読み出します。\r\n\r\n";
            // 
            // btnLoadSetting
            // 
            this.btnLoadSetting.Location = new System.Drawing.Point(684, 146);
            this.btnLoadSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadSetting.Name = "btnLoadSetting";
            this.btnLoadSetting.Size = new System.Drawing.Size(141, 29);
            this.btnLoadSetting.TabIndex = 43;
            this.btnLoadSetting.Text = "設定読出";
            this.btnLoadSetting.UseVisualStyleBackColor = true;
            this.btnLoadSetting.Click += new System.EventHandler(this.btnLoadSetting_Click);
            // 
            // btnOpenParamSettings
            // 
            this.btnOpenParamSettings.Location = new System.Drawing.Point(684, 195);
            this.btnOpenParamSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenParamSettings.Name = "btnOpenParamSettings";
            this.btnOpenParamSettings.Size = new System.Drawing.Size(141, 29);
            this.btnOpenParamSettings.TabIndex = 45;
            this.btnOpenParamSettings.Text = "設定ファイル選択";
            this.btnOpenParamSettings.UseVisualStyleBackColor = true;
            this.btnOpenParamSettings.Click += new System.EventHandler(this.btnOpenParamSettings_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(395, 194);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 30);
            this.label21.TabIndex = 46;
            this.label21.Text = "設定ファイルを選択します。\r\n\r\n";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.デバッグToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(849, 28);
            this.menuStrip1.TabIndex = 47;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenLogDir});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // mnuOpenLogDir
            // 
            this.mnuOpenLogDir.Name = "mnuOpenLogDir";
            this.mnuOpenLogDir.Size = new System.Drawing.Size(192, 26);
            this.mnuOpenLogDir.Text = "ログの場所を開く";
            this.mnuOpenLogDir.Click += new System.EventHandler(this.mnuOpenLogDir_Click);
            // 
            // デバッグToolStripMenuItem
            // 
            this.デバッグToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMoveRobotDefault,
            this.mnuOldAGVMove});
            this.デバッグToolStripMenuItem.Name = "デバッグToolStripMenuItem";
            this.デバッグToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.デバッグToolStripMenuItem.Text = "デバッグ";
            // 
            // mnuMoveRobotDefault
            // 
            this.mnuMoveRobotDefault.Name = "mnuMoveRobotDefault";
            this.mnuMoveRobotDefault.Size = new System.Drawing.Size(191, 26);
            this.mnuMoveRobotDefault.Text = "初期状態に戻す";
            this.mnuMoveRobotDefault.Click += new System.EventHandler(this.mnuMoveRobotDefault_Click);
            // 
            // mnuOldAGVMove
            // 
            this.mnuOldAGVMove.Name = "mnuOldAGVMove";
            this.mnuOldAGVMove.Size = new System.Drawing.Size(191, 26);
            this.mnuOldAGVMove.Text = "旧型AGV連続";
            this.mnuOldAGVMove.Click += new System.EventHandler(this.mnuOldAGVMove_Click);
            // 
            // btnSetPodPos
            // 
            this.btnSetPodPos.Location = new System.Drawing.Point(508, 127);
            this.btnSetPodPos.Name = "btnSetPodPos";
            this.btnSetPodPos.Size = new System.Drawing.Size(99, 23);
            this.btnSetPodPos.TabIndex = 42;
            this.btnSetPodPos.Text = "棚位置セット";
            this.btnSetPodPos.UseVisualStyleBackColor = true;
            this.btnSetPodPos.Click += new System.EventHandler(this.btnSetPodPos_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 542);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnOpenParamSettings);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnLoadSetting);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkBoxIsStop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxRobotID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNodeID);
            this.Controls.Add(this.textBoxPodID);
            this.Controls.Add(this.textBoxLayoutID);
            this.Controls.Add(this.textBoxWarehouseID);
            this.Controls.Add(this.textBoxServerIP);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "AGVデモソフト";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxTaskID;
        private System.Windows.Forms.Button btnGetTaskDetail;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnUnSetOwner;
        private System.Windows.Forms.Button btnShowOwner;
        private System.Windows.Forms.ListBox listBoxDirection;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnOpenParamSettings;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnShowPodDetail;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenLogDir;
        private System.Windows.Forms.Button btnSetOwner;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnCharge;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnAddPod;
        private System.Windows.Forms.Button btnRemovePod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxChargeAreaID;
        private System.Windows.Forms.ToolStripMenuItem デバッグToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveRobotDefault;
        private System.Windows.Forms.ToolStripMenuItem mnuOldAGVMove;
        private System.Windows.Forms.Button btnLiftDown;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button btnLiftUp;
        private System.Windows.Forms.Button btnShowAGVPosition;
        private System.Windows.Forms.Button btnSetPodPos;
    }
}
