using System.Drawing;
using System.Web;
using ThoughtWorks.QRCode.Codec;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// QRcodeHandler 的摘要说明
    /// </summary>
    public class QRcodeHandler : IHttpHandler
    {
        /// <summary>
        /// GET: 生成一个纯净的二维码
        /// </summary>
        /// <param name="code">url编码后要生成的二维码值</param>
        /// <param name="w">二维码的宽</param>
        /// <param name="h">二维码的高</param>
        /// <returns>对应的二维码图片</returns>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string code = HttpContext.Current.Request["code"].ToString();
            int w = string.IsNullOrEmpty(HttpContext.Current.Request["w"]) ? 100 : int.Parse(HttpContext.Current.Request["w"].ToString());
            int h = string.IsNullOrEmpty(HttpContext.Current.Request["h"]) ? 100 : int.Parse(HttpContext.Current.Request["h"].ToString());

            Bitmap bmp = QRCodeAux.Create(UrlDecode(code), w, h);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(ms.GetBuffer());
        }
        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }
        /// <summary>
        /// 二维码辅助类
        /// </summary>
        public class QRCodeAux
        {
            /// <summary>
            /// 生成二维码
            /// </summary>
            /// <param name="data">二维码内容</param>
            public static Bitmap Create(string data, int width = 0, int height = 0)
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

                qrCodeEncoder.QRCodeScale = 6;

                qrCodeEncoder.QRCodeVersion = 0;

                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                Bitmap image = qrCodeEncoder.Encode(data, System.Text.Encoding.UTF8);

                int wInt = width == 0 ? image.Width : width;
                int hInt = height == 0 ? image.Height : height;

                //新建一个bmp图片
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(wInt, hInt);

                //新建一个画板
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

                //设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //清空画布并以透明背景色填充
                g.Clear(System.Drawing.Color.Transparent);

                //在指定位置并且按指定大小绘制原图片的指定部分
                g.DrawImage(image, new System.Drawing.Rectangle(0, 0, wInt, hInt),
                    new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                    System.Drawing.GraphicsUnit.Pixel);

                return bitmap;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}