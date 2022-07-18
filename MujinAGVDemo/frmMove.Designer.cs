
namespace MujinAGVDemo
{
    partial class frmMove
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
            this.btnMoveP1 = new System.Windows.Forms.Button();
            this.btnMoveP2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMoveP1
            // 
            this.btnMoveP1.Location = new System.Drawing.Point(25, 44);
            this.btnMoveP1.Name = "btnMoveP1";
            this.btnMoveP1.Size = new System.Drawing.Size(75, 23);
            this.btnMoveP1.TabIndex = 0;
            this.btnMoveP1.Text = "P1へ移動";
            this.btnMoveP1.UseVisualStyleBackColor = true;
            this.btnMoveP1.Click += new System.EventHandler(this.btnMoveP1_Click);
            // 
            // btnMoveP2
            // 
            this.btnMoveP2.Location = new System.Drawing.Point(125, 44);
            this.btnMoveP2.Name = "btnMoveP2";
            this.btnMoveP2.Size = new System.Drawing.Size(75, 23);
            this.btnMoveP2.TabIndex = 1;
            this.btnMoveP2.Text = "P2へ移動";
            this.btnMoveP2.UseVisualStyleBackColor = true;
            this.btnMoveP2.Click += new System.EventHandler(this.btnMoveP2_Click);
            // 
            // frmMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 134);
            this.Controls.Add(this.btnMoveP2);
            this.Controls.Add(this.btnMoveP1);
            this.Name = "frmMove";
            this.Text = "frmMove";
            this.Load += new System.EventHandler(this.frmMove_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoveP1;
        private System.Windows.Forms.Button btnMoveP2;
    }
}