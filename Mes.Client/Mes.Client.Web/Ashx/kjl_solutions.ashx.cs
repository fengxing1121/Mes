using Mes.Client.Utility.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// kjl_solutions 的摘要说明
    /// </summary>
    public class kjl_solutions : BaseHttpHandler
    {
        //private string UserID = "312447268@qq.com";//"zhaifeifan@163.com";//
        //private string password = "102103";//"123456";//
        private string appKey = "VMPCyz3JxT";//"o8QQEsQDJa";//
        private string appSecret = "nL8qbOjDejyiBD2FVJHudV1XRexjqWUa";//"MoZ6qPSk1u9czid6wWgsO24grOKASk6s";//
        private string API_URL = "http://www.kujiale.com/";

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                //parm = new PrivilegeParm(context);
                foreach (MethodInfo mi in this.GetType().GetMethods())
                {
                    if (mi.Name.ToLower() == method.ToLower())
                    {
                        mi.Invoke(this, null);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 酷家乐--单点登录
        /// </summary>
        public void API_Login()
        {
            try
            {
                string url = "p/openapi/login?appuid={0}&appuname={1}&appuemail={2}&appuphone={3}&appussn={4}&appuaddr={5}&appuavatar={6}&apputype=1&dest=4";
                string appuid = CurrentUser.UserCode;
                string appuname = CurrentUser.UserName;
                string appuemail = "";
                string appuphone = CurrentUser.Mobile;
                string appussn = "";
                string appuaddr = "广东广州";
                string appuavatar = "http://qhyxpic.oss.kujiale.com/avatars/72.jpg";

                //MD5(appSecret + appKey + userId + timestamp)

                long timestamp = getTimeStamp();
                StringBuilder api = new StringBuilder();

                string sign = MD5Encrypt(appSecret + appKey + appuid + timestamp);

                api.AppendFormat(API_URL + url, appuid, appuname, appuemail, appuphone, appussn, appuaddr, appuavatar)
                    .AppendFormat("&appkey={0}", appKey)
                    .AppendFormat("&timestamp={0}", timestamp)
                    .AppendFormat("&sign={0}", sign)
                    .AppendFormat("&appuid={0}", appuid);

                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = WebRequest.Create(api.ToString()) as HttpWebRequest;
                request.Method = "Post";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, encoding);
                string result = sr.ReadToEnd();
                this.Response.Write(result);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appuid"></param>
        public void GetSolutionTyUserID()
        {
            try
            {
                string appuid = CurrentUser.UserCode;
                int start = 0;
                int num = 9999;

                long timestamp = getTimeStamp();
                string sign = MD5Encrypt(appSecret + appKey + appuid + timestamp);

                StringBuilder api = new StringBuilder();
                api.AppendFormat(API_URL + "/p/openapi/user/design?start={0}&num={1}&appuid={2}", start, num, appuid)
                    .AppendFormat("&appkey={0}", appKey)
                    .AppendFormat("&timestamp={0}", timestamp)
                    .AppendFormat("&sign={0}", sign);

                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = WebRequest.Create(api.ToString()) as HttpWebRequest;
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, encoding);
                string result = sr.ReadToEnd();
                Response.Write(result);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        /// <summary>
        /// 获取柜体数据
        /// </summary>
        public void DownloadSolution()
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

                string filename = "D:\\kujiale-" + obsDesignId + ".json";

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                FileStream fs1 = new FileStream(filename, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.Write(result);//开始写入值
                sw.Close();
                fs1.Close();

            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
                //Response.Write(ex.Message);
            }
        }

        public void OpenSolution()
        {
            try
            {
                string url = "p/openapi/login?appuid={0}&appuname={1}&appuemail={2}&appuphone={3}&appussn={4}&appuaddr={5}&appuavatar={6}&apputype=1&dest=1&designid={7}";
                string appuid = CurrentUser.UserCode;
                string appuname = CurrentUser.UserName;
                string appuemail = "";
                string appuphone = CurrentUser.Mobile;
                string appussn = "";
                string appuaddr = "广东广州";
                string appuavatar = "http://qhyxpic.oss.kujiale.com/avatars/72.jpg";
                long timestamp = getTimeStamp();
                StringBuilder api = new StringBuilder();

                string sign = MD5Encrypt(appSecret + appKey + appuid + timestamp);
                string designid = Request["designid"];
                if (string.IsNullOrEmpty(designid))
                {
                    throw new Exception("数据请求非法,未提供方案ID参数。");
                }
                api.AppendFormat(API_URL + url, appuid, appuname, appuemail, appuphone, appussn, appuaddr, appuavatar, designid)
                    .AppendFormat("&appkey={0}", appKey)
                    .AppendFormat("&timestamp={0}", timestamp)
                    .AppendFormat("&sign={0}", sign)
                    .AppendFormat("&appuid={0}", appuid);

                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = WebRequest.Create(api.ToString()) as HttpWebRequest;
                request.Method = "Post";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, encoding);
                string result = sr.ReadToEnd();
                this.Response.Write(result);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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