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
            this.vspInput.Location = new System.Drawing.Point(9, 10);
            this.vspInput.Margin = new System.Windows.Forms.Padding(2);
            this.vspInput.Name = "vspInput";
            this.vspInput.Size = new System.Drawing.Size(424, 318);
            this.vspInput.TabIndex = 0;
            this.vspInput.Text = "videoSourcePlayer1";
            this.vspInput.VideoSource = null;
            this.vspInput.Click += new System.EventHandler(this.vspInput_Click);
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(512, 110);
            this.txtUid.Margin = new System.Windows.Forms.Padding(2);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(92, 21);
            this.txtUid.TabIndex = 7;
            // 
            // labUid
            // 
            this.labUid.AutoSize = true;
            this.labUid.Location = new System.Drawing.Point(447, 113);
            this.labUid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUid.Name = "labUid";
            this.labUid.Size = new System.Drawing.Size(53, 12);
            this.labUid.TabIndex = 6;
            this.labUid.Text = "用户名：";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(478, 166);
            this.btnInput.Margin = new System.Windows.Forms.Padding(2);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(91, 35);
            this.btnInput.TabIndex = 8;
            this.btnInput.Text = "录入";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // labHint
            // 
            this.labHint.AutoSize = true;
            this.labHint.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labHint.Location = new System.Drawing.Point(472, 136);
            this.labHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labHint.Name = "labHint";
            this.labHint.Size = new System.Drawing.Size(137, 12);
            this.labHint.TabIndex = 9;
            this.labHint.Text = "请输入英文/数字/下划线";
            // 
            // frmFaceInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 333);
            this.Controls.Add(this.labHint);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.labUid);
            this.Controls.Add(this.vspInput);
            this.Margin = new System.Windows.Forms.Padding(2);
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