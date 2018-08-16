using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Mes.Client.Web.View.Download
{
    public partial class Download_kjlsolution : System.Web.UI.Page
    {
        //private string UserID = "312447268@qq.com";//"zhaifeifan@163.com";//
        //private string password = "102103";//"123456";//
        private string appKey = "VMPCyz3JxT";//"o8QQEsQDJa";//
        private string appSecret = "nL8qbOjDejyiBD2FVJHudV1XRexjqWUa";//"MoZ6qPSk1u9czid6wWgsO24grOKASk6s";//
        private string API_URL = "http://www.kujiale.com/";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string obsDesignId = Request["obsDesignId"].ToString();
                if (string.IsNullOrEmpty(obsDesignId))
                {
                    throw new Exception("obsDesignId参数无效。");
                }
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                long timestamp = (DateTime.Now.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位 
                string sign = MD5Encrypt(appSecret + appKey + timestamp);
                StringBuilder api = new StringBuilder();
                api.Append(API_URL + "p/openapi/custom/production/" + obsDesignId)
                .AppendFormat("?appkey={0}", appKey)
                .AppendFormat("&timestamp={0}", timestamp)
                .AppendFormat("&sign={0}", sign)
                .AppendFormat("&requestType={0}", 1);

                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = WebRequest.Create(api.ToString()) as HttpWebRequest;
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, encoding);
                string result = sr.ReadToEnd();

                string filePath = Server.MapPath("\\temp");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string filename = Path.Combine(filePath, "kujiale-" + obsDesignId + ".json");
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                using (FileStream fs1 = new FileStream(filename, FileMode.Create, FileAccess.Write))//创建写入文件
                {
                    using (StreamWriter sw = new StreamWriter(fs1))
                    {
                        sw.Write(result);//开始写入值
                    }
                }

                Response.ClearHeaders();
                Response.ClearContent();
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlPathEncode(Path.GetFileName(filename)));
                System.IO.FileInfo file = new System.IO.FileInfo(filename);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                byte[] buffer = File.ReadAllBytes(filename);
                Response.BinaryWrite(buffer);
                Response.Flush();
                file.Delete();
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 数据签名
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private string getSign(long timestamp)
        {
            return MD5Encrypt(appSecret + appKey + timestamp);
        }

        /// <summary>
        /// 数据签名
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="appuid"></param>
        /// <returns></returns>
        private string getSignByUserID(long timestamp, string appuid)
        {
            return MD5Encrypt(appSecret + appKey + appuid + timestamp);
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns></returns>
        private long getTimeStamp()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (DateTime.Now.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位 
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string original)
        {
            byte[] data = Encoding.UTF8.GetBytes(original);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string strReturn = "";
            for (int j = 0; j < result.Length; j++)
            {
                strReturn += result[j].ToString("x").PadLeft(2, '0');
            }
            return strReturn;
        }
    }
}