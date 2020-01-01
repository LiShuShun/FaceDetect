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
using AForge.Video;
using System.Threading;

namespace frmFaceMain
{
    public partial class frmFaceIdentify : Form
    {
       
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
        private bool isDetecting = true;
        private int tryToDetectCount = 0; // 每检测5次尝试提示一次
        private string[] parseResult;
        System.Timers.Timer timer;


        /// <summary>
        /// 关闭form时清理摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handleFormClosingEvent(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            stopDetecting();
        }

        public frmFaceIdentify()
        {
            InitializeComponent();
            btnIdentify.Click += BtnIdentify_Click;
            CheckForIllegalCrossThreadCalls = true;
            FormClosing += handleFormClosingEvent;
        }

        /// <summary>
        /// 窗体加载连接摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFaceIdentify_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                selectedDeviceIndex = 0;
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头
                videoSource.NewFrame += handleCameraFrameChanged;
                videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
                vspIdentify.VideoSource = videoSource;
                vspIdentify.Start();

                timer = new System.Timers.Timer();
                timer.Enabled = true;
                timer.Interval = 3000; //执行间隔时间,单位为毫秒;
                timer.Start();
                timer.Elapsed += delegate
                {
                    if (isDetecting && tryToDetectCount == 0)
                    {
                        isDetecting = false;
                    }

                    if (parseResult != null)
                    {
                        timer.Stop();
                        // 从timer线程切换到主线程刷新UI
                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            stopDetecting();
                        }));
                    }

                    tryToDetectCount++;
                    if (tryToDetectCount != 0 && tryToDetectCount % 5 == 0)
                    {
                        MessageBox.Show("请正对摄像头");
                    }
                };
            }
            else
            {
                MessageBox.Show("没有找到可用的摄像头");
            }
        }

        /// <summary>
        /// 相机采集到图片后回调，注意此方法在相机线程中回调的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void handleCameraFrameChanged(object sender, NewFrameEventArgs eventArgs)
        {
            if (isDetecting) return;
            handleImageDetecting();
        }

        /// <summary>
        /// 人脸识别按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIdentify_Click(object sender, EventArgs e)
        {
            if (isDetecting) return;
            isDetecting = false;
        }

        /// <summary>
        /// 在收到相机通知可以读取图像时进行图像处理
        /// </summary>
        private void handleImageDetecting()
        {
            Bitmap  bitmap = vspIdentify.GetCurrentVideoFrame();//识别
            if (bitmap == null) return;

            // 控制一次只能处理一张图片
            isDetecting = true;

            // 图像识别耗时且走网络，应该考虑放到子线程执行
            new Thread(new ParameterizedThreadStart(t =>
            {
                string fileName = DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss-ff") + ".jpg";
                bitmap.Save(@"..\faceImage\face" + fileName, ImageFormat.Jpeg);
                bitmap.Dispose();
                string[] result = FaceSearch.search(fileName);
                //图片路径
                string path = "../faceImage/face" + fileName;
                //删除本地文件
                File.Delete(path);

                double score = Convert.ToDouble(result[2]);
                if (score > 80)
                {
                    parseResult = result;
                }
                else
                {
                    isDetecting = false;
                }
            })).Start("tryToDetectFace");
        }

        /// <summary>
        /// zhu
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        private byte[] convertBitmapToBytes(Bitmap map)
        {
            MemoryStream ms = new MemoryStream();
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释
            ms.Close();
            return bytes;
        }

        private void stopDetecting()
        {
            if (videoSource.IsRunning)
            {
                if (parseResult != null)
                {
                    txtGroup.Text = parseResult[0];
                    txtUid.Text = parseResult[1];
                    txtMatchingScore.Text = parseResult[2];
                    MessageBox.Show("人脸识别成功");

                }

                videoSource.SignalToStop();
                videoSource.WaitForStop();

                // 释放摄像头
                vspIdentify.SignalToStop();
                vspIdentify.WaitForStop();
            }
        }
        #region UI控件
        private void vspIdentify_Click(object sender, EventArgs e)
        {

        }

        private void txtUid_TextChanged(object sender, EventArgs e)
        {

        }

        private void labUid_Click(object sender, EventArgs e)
        {

        }

        private void txtMatchingScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void labMatchingScore_Click(object sender, EventArgs e)
        {

        }

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void labGroup_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
        public static class AccessToken
        {
            // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
            // 返回token
            public static String TOKEN = "24.adda70c11b9786206253ddb70affdc46.2592000.1493524354.282335-1234567";

            // API Key 
            private static String clientId = "HtSzIhdj2UqfEu1XewhGWPXL";
            // Secret Key
            private static String clientSecret = "4pNesBWNYBkWzmzzQG13BTFni40TTe3W";

            public static String getAccessToken()
            {
                String authHost = "https://aip.baidubce.com/oauth/2.0/token";
                HttpClient client = new HttpClient();
                List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
                paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
                paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
                String result = "";
                try
                {
                    HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                    Console.WriteLine(result);
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("网络连接失败！请检查你的网络！");
                    Console.Write("异常：{0}", ex.Message);
                }
                return result;
            }
        }

    public class FaceSearch
    {
        /// <summary>
        /// 人脸搜索
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static string[] search(string ch)
        {
            string[] strArr = new string[3];
            //网络连接失败为获取到AccessToken
            if (AccessToken.getAccessToken() == "")
            {
                return strArr;
            }
            var jsonstring = AccessToken.getAccessToken();
            var jObject = JObject.Parse(jsonstring);
            string token = jObject["access_token"].ToString();
            string host = "https://aip.baidubce.com/rest/2.0/face/v3/search?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            var value = File.ReadAllBytes("../faceImage/face" + ch);
            string imgData64 = Convert.ToBase64String(value);
            String str = "{\"image\":\"" + imgData64 + "\",\"image_type\":\"BASE64\",\"group_id_list\":\"fylm\"}";
            byte[] buffer = encoding.GetBytes(str); 
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            JObject jo = (JObject)JsonConvert.DeserializeObject(result);
            string val = "";
            try
            {
                val = jo["result"]["user_list"].ToString();
            }
            catch (Exception ex)
            {
                return strArr;
            }
            JArray ja = (JArray)JsonConvert.DeserializeObject(val);
            Double Score = Convert.ToDouble(ja[0]["score"].ToString());//匹配度
            
            string Uid = ja[0]["user_id"].ToString();//用户名
            string GroupId = ja[0]["group_id"].ToString();//组名
            strArr[0] = GroupId.ToString();
            strArr[1] = Uid.ToString();
            strArr[2] = Score.ToString();
            return strArr;
        }
    }
}
