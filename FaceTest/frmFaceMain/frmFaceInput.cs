using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Drawing;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace frmFaceMain
{
    public partial class frmFaceInput : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;

        public int selectedDeviceIndex = 0;

        public frmFaceInput()
        {
            InitializeComponent();
            FormClosing += handleFormClosingEvent;
        }

        /// <summary>
        /// 关闭form时清理摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handleFormClosingEvent(object sender, FormClosingEventArgs e)
        {
            stopDetecting();
        }

        /// <summary>
        /// 窗体加载连接摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFaceInput_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDeviceIndex = 0;
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            vspInput.VideoSource = videoSource;
            vspInput.Start();
        }
        /// <summary>
        /// 录入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInput_Click(object sender, EventArgs e)
        {
            if (txtUid.Text == "")
            {
                MessageBox.Show("请输入用户名！");
                return;
            }
            if (Check.IsChinese(txtUid.Text))
            {
                MessageBox.Show("请输入数字/字母/下划线");
                return;
            }
            if (videoSource == null)
            {
                MessageBox.Show("请先连接摄像头 ！");
                return;
            }
            Bitmap bitmap = vspInput.GetCurrentVideoFrame();//录入
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
            string name = txtUid.Text;
            bitmap.Save(@"..\faceImage\face" + fileName, ImageFormat.Jpeg); //保存于本地bin/faceImage文件夹
            bitmap.Dispose();
            if (FaceAdd.add(fileName, name) > 0)
            {
                MessageBox.Show("录入失败！");
                return;
            }
            MessageBox.Show("录入成功！");
            //图片路径
            string path = "../faceImage/face" + fileName;
            //删除本地文件
            File.Delete(path);

            vspInput.Stop();
        }
//
        private void stopDetecting()
        {
            if (videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                // 释放摄像头
                vspInput.SignalToStop();
                vspInput.WaitForStop();
            }
        }

        private void vspInput_Click(object sender, EventArgs e)
        {
        }
    }

    public class FaceAdd
    {
        // 人脸注册
        public static int add(string imgName, string name)
        {
            if (AccessToken.getAccessToken() == "")
            {
                return 1;
            }
            var jsonstring = AccessToken.getAccessToken();
            var jObject = JObject.Parse(jsonstring);
            string token = jObject["access_token"].ToString();
            string host = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/add?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";

            request.KeepAlive = true;
            var value = File.ReadAllBytes("../faceImage/face" + imgName);
            string imgData64 = Convert.ToBase64String(value);
            String str = "{\"image\":\"" + imgData64 + "\",\"image_type\":\"BASE64\",\"group_id\":\"fylm\",\"user_id\":\"" + name + "\"}";

            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            MessageBox.Show("人脸注册:");
            MessageBox.Show(result);
            JObject jo = (JObject)JsonConvert.DeserializeObject(result);
            int error_code = Convert.ToInt32(jo["error_code"]);//返回error_code
            MessageBox.Show(error_code + "");
            return error_code;
        }
    }

    public class Check
    {
        /// <summary>
        /// 给定一个字符串，判断其是否只包含有汉字
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public static bool IsChinese(string str)
        {
            //中文字符
            Regex rx = new Regex("^[\u4e00-\u9fa5]$");
            for (int i = 0; i < str.Length; i++)
            {
                if (rx.IsMatch(str.Substring(i, 1)))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}

