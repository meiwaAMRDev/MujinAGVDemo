
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
            this.btnAddPod = new System.Windows.Forms.Button();
            this.btnRemovePod = new System.Windows.Forms.Button();
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
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.btnRemoveAllPods = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSaveSampleCSV = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelectCSV = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnLoadSetting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeatCount)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPod
            // 
            this.btnAddPod.Location = new System.Drawing.Point(6, 50);
            this.btnAddPod.Name = "btnAddPod";
            this.btnAddPod.Size = new System.Drawing.Size(75, 23);
            this.btnAddPod.TabIndex = 0;
            this.btnAddPod.Text = "棚追加";
            this.btnAddPod.UseVisualStyleBackColor = true;
            this.btnAddPod.Click += new System.EventHandler(this.btnAddPod_Click);
            // 
            // btnRemovePod
            // 
            this.btnRemovePod.Location = new System.Drawing.Point(6, 78);
            this.btnRemovePod.Name = "btnRemovePod";
            this.btnRemovePod.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePod.TabIndex = 1;
            this.btnRemovePod.Text = "棚削除";
            this.btnRemovePod.UseVisualStyleBackColor = true;
            this.btnRemovePod.Click += new System.EventHandler(this.btnRemovePod_Click);
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(114, 36);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(148, 19);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "serverIP";
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Location = new System.Drawing.Point(114, 61);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(148, 19);
            this.textBoxWarehouseID.TabIndex = 3;
            this.textBoxWarehouseID.Text = "warehouseID";
            // 
            // textBoxLayoutID
            // 
            this.textBoxLayoutID.Location = new System.Drawing.Point(114, 86);
            this.textBoxLayoutID.Name = "textBoxLayoutID";
            this.textBoxLayoutID.Size = new System.Drawing.Size(148, 19);
            this.textBoxLayoutID.TabIndex = 4;
            this.textBoxLayoutID.Text = "layoutID";
            // 
            // textBoxNodeID
            // 
            this.textBoxNodeID.Location = new System.Drawing.Point(114, 134);
            this.textBoxNodeID.Name = "textBoxNodeID";
            this.textBoxNodeID.Size = new System.Drawing.Size(148, 19);
            this.textBoxNodeID.TabIndex = 6;
            this.textBoxNodeID.Text = "nodeID";
            // 
            // textBoxPodID
            // 
            this.textBoxPodID.Location = new System.Drawing.Point(114, 110);
            this.textBoxPodID.Name = "textBoxPodID";
            this.textBoxPodID.Size = new System.Drawing.Size(148, 19);
            this.textBoxPodID.TabIndex = 5;
            this.textBoxPodID.Text = "podID";
            // 
            // btnMovePod
            // 
            this.btnMovePod.Location = new System.Drawing.Point(6, 133);
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
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "serverIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "warehouseID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "layoutID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "podID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "nodeID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "robotID";
            // 
            // textBoxRobotID
            // 
            this.textBoxRobotID.Location = new System.Drawing.Point(114, 158);
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
            this.textBoxStationListPath.Location = new System.Drawing.Point(309, 50);
            this.textBoxStationListPath.Name = "textBoxStationListPath";
            this.textBoxStationListPath.Size = new System.Drawing.Size(120, 19);
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
            this.checkBoxIsStop.BackColor = System.Drawing.Color.Red;
            this.checkBoxIsStop.Location = new System.Drawing.Point(286, 39);
            this.checkBoxIsStop.Name = "checkBoxIsStop";
            this.checkBoxIsStop.Size = new System.Drawing.Size(63, 22);
            this.checkBoxIsStop.TabIndex = 29;
            this.checkBoxIsStop.Text = "AGV停止";
            this.checkBoxIsStop.UseVisualStyleBackColor = false;
            this.checkBoxIsStop.CheckedChanged += new System.EventHandler(this.checkBoxIsStop_CheckedChanged);
            // 
            // btnMoveAGV
            // 
            this.btnMoveAGV.Location = new System.Drawing.Point(6, 162);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
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
            this.btnSaveSetting.Location = new System.Drawing.Point(286, 72);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSetting.TabIndex = 35;
            this.btnSaveSetting.Text = "設定保存";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(287, 12);
            this.label9.TabIndex = 36;
            this.label9.Text = "nodeIDで指定した地点にpodIDで指定した棚を作成します。\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(102, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "podIDで指定した棚を削除します。";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(102, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(369, 12);
            this.label11.TabIndex = 38;
            this.label11.Text = "podIDで指定した棚をnodeIDの地点へrobotIDで指定したAGVが運搬します。";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(102, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(309, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "nodeIDで指定した地点へrobotIDで指定したAGVが移動します。";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 191);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(483, 217);
            this.tabControl1.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.btnRemoveAllPods);
            this.tabPage1.Controls.Add(this.checkBoxUnload);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btnAddPod);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnRemovePod);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.btnMovePod);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.checkBoxSynchroTurn);
            this.tabPage1.Controls.Add(this.btnMoveAGV);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(475, 191);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "各個操作";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(102, 109);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 12);
            this.label19.TabIndex = 41;
            this.label19.Text = "棚を全て削除します。";
            // 
            // btnRemoveAllPods
            // 
            this.btnRemoveAllPods.Location = new System.Drawing.Point(6, 104);
            this.btnRemoveAllPods.Name = "btnRemoveAllPods";
            this.btnRemoveAllPods.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllPods.TabIndex = 40;
            this.btnRemoveAllPods.Text = "棚全削除";
            this.btnRemoveAllPods.UseVisualStyleBackColor = true;
            this.btnRemoveAllPods.Click += new System.EventHandler(this.btnRemoveAllPods_Click);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(475, 191);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "連続動作";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(373, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(210, 12);
            this.label13.TabIndex = 41;
            this.label13.Text = "指定のAGVを一時停止・停止解除します。";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(373, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(264, 24);
            this.label14.TabIndex = 42;
            this.label14.Text = "現在の設定をファイルに保存します。\r\n実行ファイル直下のParamSetting.xmlに保存されます。";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(373, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(265, 24);
            this.label16.TabIndex = 44;
            this.label16.Text = "設定ファイルを読み出します。\r\n実行ファイル直下のParamSetting.xmlを読み出します。\r\n";
            // 
            // btnLoadSetting
            // 
            this.btnLoadSetting.Location = new System.Drawing.Point(286, 115);
            this.btnLoadSetting.Name = "btnLoadSetting";
            this.btnLoadSetting.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSetting.TabIndex = 43;
            this.btnLoadSetting.Text = "設定読出";
            this.btnLoadSetting.UseVisualStyleBackColor = true;
            this.btnLoadSetting.Click += new System.EventHandler(this.btnLoadSetting_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 434);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnLoadSetting);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.statusStrip1);
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnRemoveAllPods;
    }
}

