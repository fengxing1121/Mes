using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;

namespace Mes.Client.Utility
{
    /// <summary>
    ///ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode
    {
        public ValidateCode()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static string GetRandomCode(int CodeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
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
        public static void CreateImage(string checkCode, HttpResponse Response)
        {
            int iwidth = (int)(checkCode.Length * 16);
            Bitmap image = new Bitmap(iwidth, 20);
            Graphics g = Graphics.FromImage(image);
            Font f = new Font("Arial ", 10);//, System.Drawing.FontStyle.Bold);
            Brush b = new SolidBrush(Color.Black);
            Brush r = new SolidBrush(Color.FromArgb(166, 8, 8));

            //g.FillRectangle(new System.Drawing.SolidBrush(Color.Blue),0,0,image.Width, image.Height);
            //			g.Clear(Color.AliceBlue);//背景色
            g.Clear(ColorTranslator.FromHtml("#99C1CB"));//背景色

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
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
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
