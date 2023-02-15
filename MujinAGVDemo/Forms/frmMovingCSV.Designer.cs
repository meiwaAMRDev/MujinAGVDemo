
namespace MujinAGVDemo.Forms
{
    partial class frmMovingCSV
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
            this.dgvMovingParam = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLoadPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovingParam)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMovingParam
            // 
            this.dgvMovingParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovingParam.Location = new System.Drawing.Point(12, 120);
            this.dgvMovingParam.Name = "dgvMovingParam";
            this.dgvMovingParam.RowTemplate.Height = 21;
            this.dgvMovingParam.Size = new System.Drawing.Size(776, 318);
            this.dgvMovingParam.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 91);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(104, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(288, 91);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "CSV読込";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(197, 91);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.AllowDrop = true;
            this.textBoxSavePath.Location = new System.Drawing.Point(438, 23);
            this.textBoxSavePath.Multiline = true;
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(350, 36);
            this.textBoxSavePath.TabIndex = 83;
            this.textBoxSavePath.Text = "保存先CSVパス";
            this.textBoxSavePath.TextChanged += new System.EventHandler(this.textBoxSavePath_TextChanged);
            this.textBoxSavePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSavePath_DragDrop);
            this.textBoxSavePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSavePath_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 84;
            this.label1.Text = "保存先CSVパス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 86;
            this.label2.Text = "読取先CSVパス";
            // 
            // textBoxLoadPath
            // 
            this.textBoxLoadPath.AllowDrop = true;
            this.textBoxLoadPath.Location = new System.Drawing.Point(438, 78);
            this.textBoxLoadPath.Multiline = true;
            this.textBoxLoadPath.Name = "textBoxLoadPath";
            this.textBoxLoadPath.Size = new System.Drawing.Size(350, 36);
            this.textBoxLoadPath.TabIndex = 85;
            this.textBoxLoadPath.Text = "読取先CSVパス";
            this.textBoxLoadPath.TextChanged += new System.EventHandler(this.textBoxLoadPath_TextChanged);
            this.textBoxLoadPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxLoadPath_DragDrop);
            this.textBoxLoadPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxLoadPath_DragEnter);
            // 
            // frmMovingCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLoadPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSavePath);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvMovingParam);
            this.Name = "frmMovingCSV";
            this.Text = "frmMovingCSV";
            this.Load += new System.EventHandler(this.frmMovingCSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovingParam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovingParam;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBoxSavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLoadPath;
    }
}