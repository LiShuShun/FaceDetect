namespace frmFaceMain
{
    partial class frmFaceInput
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
            this.vspInput = new AForge.Controls.VideoSourcePlayer();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.labUid = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.labHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vspInput
            // 
            this.vspInput.Location = new System.Drawing.Point(12, 12);
            this.vspInput.Name = "vspInput";
            this.vspInput.Size = new System.Drawing.Size(565, 397);
            this.vspInput.TabIndex = 0;
            this.vspInput.Text = "videoSourcePlayer1";
            this.vspInput.VideoSource = null;
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(682, 138);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(121, 25);
            this.txtUid.TabIndex = 7;
            // 
            // labUid
            // 
            this.labUid.AutoSize = true;
            this.labUid.Location = new System.Drawing.Point(596, 141);
            this.labUid.Name = "labUid";
            this.labUid.Size = new System.Drawing.Size(67, 15);
            this.labUid.TabIndex = 6;
            this.labUid.Text = "用户名：";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(638, 207);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(121, 44);
            this.btnInput.TabIndex = 8;
            this.btnInput.Text = "录入";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // labHint
            // 
            this.labHint.AutoSize = true;
            this.labHint.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labHint.Location = new System.Drawing.Point(630, 170);
            this.labHint.Name = "labHint";
            this.labHint.Size = new System.Drawing.Size(173, 15);
            this.labHint.TabIndex = 9;
            this.labHint.Text = "请输入英文/数字/下划线";
            // 
            // frmFaceInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 416);
            this.Controls.Add(this.labHint);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.labUid);
            this.Controls.Add(this.vspInput);
            this.Name = "frmFaceInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人脸录入";
            this.Load += new System.EventHandler(this.frmFaceInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer vspInput;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label labUid;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Label labHint;
    }
}