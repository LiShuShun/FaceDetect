using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmFaceMain
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsIdentify_Click(object sender, EventArgs e)
        {
            frmFaceIdentify fi = new frmFaceIdentify();
            fi.MdiParent = this;
            fi.Show();

            fi.FaceDetectCallback += faceDetectCallback;
        }

        private void faceDetectCallback(object sender, string result)
        {
            MessageBox.Show((result == "" ? "人脸检测失败" : "人脸检测成功:") +result);
        }

        /// <summary>
        /// 人脸录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsInput_Click(object sender, EventArgs e)
        {
            frmFaceInput ffi = new frmFaceInput();
            ffi.MdiParent = this;
            ffi.Show();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            System.Environment.Exit(0);//彻底退出包括线程
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
