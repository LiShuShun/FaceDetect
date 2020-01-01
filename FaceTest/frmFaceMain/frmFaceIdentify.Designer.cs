namespace frmFaceMain
{
    partial class frmFaceIdentify
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
            this.vspIdentify = new AForge.Controls.VideoSourcePlayer();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.labUid = new System.Windows.Forms.Label();
            this.txtMatchingScore = new System.Windows.Forms.TextBox();
            this.labMatchingScore = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.labGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // vspIdentify
            // 
            this.vspIdentify.Location = new System.Drawing.Point(13, 13);
            this.vspIdentify.Name = "vspIdentify";
            this.vspIdentify.Size = new System.Drawing.Size(571, 408);
            this.vspIdentify.TabIndex = 0;
            this.vspIdentify.Text = "videoSourcePlayer1";
            this.vspIdentify.VideoSource = null;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(686, 308);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(121, 44);
            this.btnIdentify.TabIndex = 1;
            this.btnIdentify.Text = "识别";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.BtnIdentify_Click);
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(736, 168);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(121, 25);
            this.txtUid.TabIndex = 5;
            // 
            // labUid
            // 
            this.labUid.AutoSize = true;
            this.labUid.Location = new System.Drawing.Point(650, 171);
            this.labUid.Name = "labUid";
            this.labUid.Size = new System.Drawing.Size(67, 15);
            this.labUid.TabIndex = 4;
            this.labUid.Text = "用户名：";
            // 
            // txtMatchingScore
            // 
            this.txtMatchingScore.Location = new System.Drawing.Point(736, 244);
            this.txtMatchingScore.Name = "txtMatchingScore";
            this.txtMatchingScore.Size = new System.Drawing.Size(121, 25);
            this.txtMatchingScore.TabIndex = 7;
            // 
            // labMatchingScore
            // 
            this.labMatchingScore.AutoSize = true;
            this.labMatchingScore.Location = new System.Drawing.Point(650, 247);
            this.labMatchingScore.Name = "labMatchingScore";
            this.labMatchingScore.Size = new System.Drawing.Size(67, 15);
            this.labMatchingScore.TabIndex = 6;
            this.labMatchingScore.Text = "匹配度：";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(736, 97);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(121, 25);
            this.txtGroup.TabIndex = 9;
            // 
            // labGroup
            // 
            this.labGroup.AutoSize = true;
            this.labGroup.Location = new System.Drawing.Point(650, 100);
            this.labGroup.Name = "labGroup";
            this.labGroup.Size = new System.Drawing.Size(67, 15);
            this.labGroup.TabIndex = 8;
            this.labGroup.Text = "用户组：";
            // 
            // frmFaceIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 434);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.labGroup);
            this.Controls.Add(this.txtMatchingScore);
            this.Controls.Add(this.labMatchingScore);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.labUid);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.vspIdentify);
            this.Name = "frmFaceIdentify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人脸识别";
            this.Load += new System.EventHandler(this.frmFaceIdentify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer vspIdentify;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label labUid;
        private System.Windows.Forms.TextBox txtMatchingScore;
        private System.Windows.Forms.Label labMatchingScore;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label labGroup;
    }
}