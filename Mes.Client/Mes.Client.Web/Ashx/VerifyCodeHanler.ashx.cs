using Mes.Client.Utility.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class VerifyCodeHanler : BaseHttpHandler
    {
        private int letterWidth = 32;//单个字体的宽度范围
        private int letterHeight = 38;//单个字体的高度范围
        private int letterCount = 4;//验证码位数
        private string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
        private string[] fonts = { "Arial", "Georgia" };
        /// <summary>
        /// 产生波形滤镜效果
        /// </summary>
        private const double PI = 3.1415926535897932384626433832795;
        private const double PI2 = 6.283185307179586476925286766559;

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            //设置页面不被缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.AppendHeader("Pragma", "No-Cache");

            string checkCode = GetRandomCode(4);
            Session["LoginVerifyCode"] = checkCode;
            Session["LoginVerifyCode_TimeOut"] = DateTime.Now.AddMinutes(10);
            CreateImage(checkCode, Response);
        }

        private string GetRandomCode(int CodeCount)
        {
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < CodeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(33);

                while (temp == t)
                {
                    t = rand.Next(33);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }

            return RandomCode;
        }

        private void CreateImage1(string checkCode, HttpResponse Response)
        {
            int iwidth = (int)(checkCode.Length * 16);
            using (Bitmap image = new Bitmap(iwidth, 25))
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    Font f = new Font("Arial ", 14);//, FontStyle.Bold);
                    Brush b = new SolidBrush(Color.Black);
                    Brush r = new SolidBrush(Color.FromArgb(166, 8, 8));

                    //g.FillRectangle(new SolidBrush(Color.Blue),0,0,image.Width, image.Height);
                    //			g.Clear(Color.AliceBlue);//背景色
                    g.Clear(Color.White);//背景色

                    char[] ch = checkCode.ToCharArray();
                    for (int i = 0; i < ch.Length; i++)
                    {
                        if (ch[i] >= '0' && ch[i] <= '9')
                        {
                            //数字用红色显示
                            g.DrawString(ch[i].ToString(), f, r, 3 + (i * 12), 3);
                        }
                        else
                        {   //字母用黑色显示
                            g.DrawString(ch[i].ToString(), f, b, 3 + (i * 12), 3);
                        }
                    }

                    //for循环用来生成一些随机的水平线
                    //			Pen blackPen = new Pen(Color.Black, 0);
                    //			Random rand = new Random();
                    //			for (int i=0;i<5;i++)
                    //			{
                    //				int y = rand.Next(image.Height);
                    //				g.DrawLine(blackPen,0,y,image.Width,y);
                    //			}

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    //history back 不重复 
                    Response.Cache.SetNoStore();//这一句 		
                    Response.ClearContent();
                    Response.ContentType = "image/Jpeg";
                    Response.BinaryWrite(ms.ToArray());
                    g.Dispose();
                    image.Dispose();
                }
            }
        }

        public void CreateImage(string checkCode, HttpResponse Response)
        {
            int int_ImageWidth = checkCode.Length * letterWidth;
            Random newRandom = new Random();
            Bitmap image = new Bitmap(int_ImageWidth, letterHeight);
            Graphics g = Graphics.FromImage(image);
            //生成随机生成器
            Random random = new Random();
            //白色背景
            g.Clear(Color.White);
            //画图片的背景噪音线
            for (int i = 0; i < 10; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            //画图片的前景噪音点
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //随机字体和颜色的验证码字符
            int findex;
            for (int int_index = 0; int_index < checkCode.Length; int_index++)
            {
                findex = newRandom.Next(fonts.Length - 1);
                string str_char = checkCode.Substring(int_index, 1);
                Brush newBrush = new SolidBrush(GetRandomColor());
                Point thePos = new Point(int_index * letterWidth + 1 + newRandom.Next(3), 1 + newRandom.Next(3));//5+1+a+s+p+x
                g.DrawString(str_char, new Font(fonts[findex], 19, FontStyle.Bold), newBrush, thePos);
            }
            //灰色边框
            g.DrawRectangle(new Pen(Color.White, 0), 0, 0, int_ImageWidth - 1, (letterHeight - 1));
            //图片扭曲
            image = TwistImage(image, true, 2, 1);
            //将生成的图片发回客户端
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            Response.Cache.SetNoStore();//这一句 		
            Response.ClearContent(); //需要输出图象信息 要修改HTTP头
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
        }

        public Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            // 将位图背景填充为白色
            Graphics graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();
            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;
            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);
                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);
                    Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }

        public Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            int int_Red = RandomNum_First.Next(210);
            int int_Green = RandomNum_Sencond.Next(180);
            int int_Blue = (int_Red + int_Green > 300) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;
            return Color.FromArgb(int_Red, int_Green, int_Blue);// 5+1+a+s+p+x
        }
    }
}