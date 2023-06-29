namespace MujinAGVDemo.Forms
{
    partial class FrmNodeDatas
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
            this.dgvMove = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoveAGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colMovePod = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colAddPod = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadNodeData = new System.Windows.Forms.Button();
            this.txtRobotID = new MujinAGVDemo.Control.LabelAndTextBox();
            this.txtPodID = new MujinAGVDemo.Control.LabelAndTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMove
            // 
            this.dgvMove.AllowUserToAddRows = false;
            this.dgvMove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMove.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colNode,
            this.colMoveAGV,
            this.colMovePod,
            this.colAddPod,
            this.colEdit});
            this.dgvMove.Location = new System.Drawing.Point(3, 61);
            this.dgvMove.Name = "dgvMove";
            this.dgvMove.RowHeadersVisible = false;
            this.dgvMove.RowTemplate.Height = 21;
            this.dgvMove.Size = new System.Drawing.Size(405, 481);
            this.dgvMove.TabIndex = 1;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLoadNodeData);
            this.flowLayoutPanel1.Controls.Add(this.txtRobotID);
            this.flowLayoutPanel1.Controls.Add(this.txtPodID);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(410, 55);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnLoadNodeData
            // 
            this.btnLoadNodeData.Location = new System.Drawing.Point(3, 3);
            this.btnLoadNodeData.Name = "btnLoadNodeData";
            this.btnLoadNodeData.Size = new System.Drawing.Size(103, 23);
            this.btnLoadNodeData.TabIndex = 4;
            this.btnLoadNodeData.Text = "ノード情報取得";
            this.btnLoadNodeData.UseVisualStyleBackColor = true;
            this.btnLoadNodeData.Click += new System.EventHandler(this.btnLoadNodeData_Click);
            // 
            // txtRobotID
            // 
            this.txtRobotID.Location = new System.Drawing.Point(112, 3);
            this.txtRobotID.Name = "txtRobotID";
            this.txtRobotID.Size = new System.Drawing.Size(143, 24);
            this.txtRobotID.TabIndex = 5;
            // 
            // txtPodID
            // 
            this.txtPodID.Location = new System.Drawing.Point(261, 3);
            this.txtPodID.Name = "txtPodID";
            this.txtPodID.Size = new System.Drawing.Size(143, 24);
            this.txtPodID.TabIndex = 6;
            // 
            // FrmNodeDatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 542);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgvMove);
            this.Name = "FrmNodeDatas";
            this.Text = "ノード情報";
            this.Load += new System.EventHandler(this.FrmNodeDatas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMove;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNode;
        private System.Windows.Forms.DataGridViewButtonColumn colMoveAGV;
        private System.Windows.Forms.DataGridViewButtonColumn colMovePod;
        private System.Windows.Forms.DataGridViewButtonColumn colAddPod;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLoadNodeData;
        private Control.LabelAndTextBox txtRobotID;
        private Control.LabelAndTextBox txtPodID;
    }
}