using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmFaceMain
{
    class Components
    {
        /// <summary>
        /// 位图转换为字节数组
        /// </summary>
        /// <param name="map">外界需要自己dispose</param>
        /// <returns></returns>
        public static byte[] convertBitmapToBytes(Bitmap map)
        {
            MemoryStream ms = new MemoryStream();
            map.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释
            ms.Close();
            return bytes;
        }
    }
}
