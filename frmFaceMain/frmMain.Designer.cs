namespace frmFaceMain
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mns = new System.Windows.Forms.MenuStrip();
            this.mnsIdentify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsInput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mns.SuspendLayout();
            this.SuspendLayout();
            // 
            // mns
            // 
            this.mns.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsIdentify,
            this.mnsInput,
            this.mnsExit});
            this.mns.Location = new System.Drawing.Point(0, 0);
            this.mns.Name = "mns";
            this.mns.Size = new System.Drawing.Size(900, 28);
            this.mns.TabIndex = 1;
            this.mns.Text = "menuStrip1";
            // 
            // mnsIdentify
            // 
            this.mnsIdentify.Name = "mnsIdentify";
            this.mnsIdentify.Size = new System.Drawing.Size(81, 24);
            this.mnsIdentify.Text = "人脸识别";
            this.mnsIdentify.Click += new System.EventHandler(this.mnsIdentify_Click);
            // 
            // mnsInput
            // 
            this.mnsInput.Name = "mnsInput";
            this.mnsInput.Size = new System.Drawing.Size(81, 24);
            this.mnsInput.Text = "人脸录入";
            this.mnsInput.Click += new System.EventHandler(this.mnsInput_Click);
            // 
            // mnsExit
            // 
            this.mnsExit.Name = "mnsExit";
            this.mnsExit.Size = new System.Drawing.Size(51, 24);
            this.mnsExit.Text = "退出";
            this.mnsExit.Click += new System.EventHandler(this.mnsExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 521);
            this.Controls.Add(this.mns);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mns;
            this.Name = "frmMain";
            this.Text = "人脸识别及录入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mns.ResumeLayout(false);
            this.mns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mns;
        private System.Windows.Forms.ToolStripMenuItem mnsIdentify;
        private System.Windows.Forms.ToolStripMenuItem mnsInput;
        private System.Windows.Forms.ToolStripMenuItem mnsExit;
    }
}

