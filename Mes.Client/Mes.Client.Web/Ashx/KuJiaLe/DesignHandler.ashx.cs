using Eagle.Data;
using Mes.Client.Model.Parm;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx.KuJiaLe
{
    /// <summary>
    /// DesignHandler 的摘要说明
    /// </summary>
    public class DesignHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        KuJiaLeDesignParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                Request = context.Request;
                Response = context.Response;

                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";
                parm = new KuJiaLeDesignParm(context);
                if (!string.IsNullOrEmpty(method))
                {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 全局变量

        private string APPKEY = "w1GdMiGXrx";
        private string APPSECRET = "zm2CfQd5SyZ40JIW9sBaUWEqGpSEV37u";

        #endregion

        #region 酷家乐接口方法

        /// <summary>
        /// 酷家乐单点登录
        /// </summary>
        public string KJL_SSO()
        {
            string appuid = !string.IsNullOrEmpty(Request["username"]) ? Request["username"] : CurrentUser.UserCode;//工厂端审核需动态传入username

            long timestamp = CreateTimeStamp();
            string sign = MD5Encrypt(APPSECRET + APPKEY + appuid + timestamp);

            StringBuilder url = new StringBuilder();
            url.Append("https://openapi.kujiale.com/v2/login/")
               .AppendFormat("?appuid={0}", appuid)
               .AppendFormat("&appkey={0}", APPKEY)
               .AppendFormat("&timestamp={0}", timestamp)
               .AppendFormat("&sign={0}", sign);

            StringBuilder datastr = new StringBuilder();
            datastr.Append('{');
            datastr.Append(string.Format("\"name\":\"{0}\",\"email\":\"\",\"telephone\":\"\",\"avatar\":\"\",\"type\":0", appuid));
            datastr.Append('}');
            string postData = datastr.ToString();

            byte[] postdatabyte = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = postData.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(postdatabyte, 0, postData.Length);
            stream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = string.Empty;
            result = sr.ReadToEnd();
            sr.Close();
            response.Close();
            stream.Close();

            if (!string.IsNullOrEmpty(Request["username"]))
                this.Response.Write(result);

            return result;
        }

        /// <summary>
        /// 酷家乐打开页面
        /// </summary>
        /// <param name="accesstoken">单点登录流程之后获取的access token</param>
        /// <param name="dest">根据dest取值的不同,打开不同页面</param>
        /// <param name="designid">酷家乐方案ID</param>
        /// <param name="planid">酷家乐户型ID</param>
        public void KJL_OpenDesignPage()
        {
            string dest = Request["dest"];
            if (string.IsNullOrEmpty(dest))
            {
                throw new Exception("dest参数无效。");
            }
            string result = KJL_SSO(); //单点登录后获取到的access token
            JObject jsonResponse = JObject.Parse(result);
            if (jsonResponse == null || jsonResponse["d"] == null)
                this.Response.Write("酷家乐接口返回数据异常");
            string accesstoken = jsonResponse["d"].ToString();
            string apiurl = string.Format("https://www.kujiale.com/v/auth?accesstoken={0}&dest={1}", accesstoken, dest);
            string designid = Request["designid"];
            if (!string.IsNullOrEmpty(designid))
            {
                apiurl += string.Format("&designid={0}", designid);
            }
            string planid = Request["planid"];
            if (!string.IsNullOrEmpty(planid))
            {
                apiurl += string.Format("&planid={0}", planid);
            }
            this.Response.Write(apiurl);
        }

        /// <summary>
        /// 获取酷家乐用户方案数据，包括户型阶段以及装修阶段的方案
        /// </summary>
        public void KJL_GetDesignList()
        {
            string appuid = CurrentUser.UserCode;
            string keyword = string.Empty; //关键字
            int start = 0; //拉取位置
            int num = 10; //拉取数量
            if (!string.IsNullOrEmpty(Request["KeyWord"]))
            {
                keyword = Request["KeyWord"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["PageSize"]))
            {
                num = Convert.ToInt32(Request["PageSize"]);
            }
            if (!string.IsNullOrEmpty(Request["PageIndex"]))
            {
                int pageIndex = Convert.ToInt32(Request["PageIndex"]);
                start = (pageIndex - 1) * num;
            }

            long timestamp = CreateTimeStamp();
            string sign = MD5Encrypt(APPSECRET + APPKEY + appuid + timestamp);

            StringBuilder url = new StringBuilder();
            url.Append("https://openapi.kujiale.com/v2/design/list")
               .AppendFormat("?start={0}", start)
               .AppendFormat("&num={0}", num)
               .AppendFormat("&status={0}", 1)
               .AppendFormat("&keyword={0}", keyword)
               .AppendFormat("&appuid={0}", appuid)
               .AppendFormat("&appkey={0}", APPKEY)
               .AppendFormat("&timestamp={0}", timestamp)
               .AppendFormat("&sign={0}", sign);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            string result = string.Empty;
            result = sr.ReadToEnd();

            //JObject obj = JObject.Parse(result);
            //string 
            //Database db = new Database("BE_Customer_Proc", "GETCUSNAME", 0, 0, "", "", "");
            //string cusName = db.ExecuteScalar().ToString();

            this.Response.Write(result);
        }

        /// <summary>
        /// 删除酷家乐方案
        /// </summary>
        public void KJL_DeleteDesign()
        {
            string planId = Request["PlanID"];
            if (string.IsNullOrEmpty(planId))
            {
                throw new Exception("planId参数无效。");
            }
            long timestamp = CreateTimeStamp();
            string sign = MD5Encrypt(APPSECRET + APPKEY + timestamp);

            StringBuilder url = new StringBuilder();
            url.Append("https://openapi.kujiale.com/v2/design/deletion/")
               .AppendFormat("?appkey={0}", APPKEY)
               .AppendFormat("&timestamp={0}", timestamp)
               .AppendFormat("&sign={0}", sign)
               .AppendFormat("&plan_id={0}", planId);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "POST";
            request.ContentType = "text/plain;charset=utf-8";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            string result = string.Empty;
            result = sr.ReadToEnd();

            this.Response.Write(result);
        }

        /// <summary>
        /// 修改酷家乐方案名称
        /// </summary>
        public void KJL_UpdateDesignName()
        {
            string designId = Request["DesignID"];
            string designName = Request["DesignName"];
            if (string.IsNullOrEmpty(designId))
            {
                throw new Exception("DesignID参数无效。");
            }
            if (string.IsNullOrEmpty(designName))
            {
                throw new Exception("DesignName参数无效。");
            }
            long timestamp = CreateTimeStamp();
            string sign = MD5Encrypt(APPSECRET + APPKEY + timestamp);

            StringBuilder url = new StringBuilder();
            url.AppendFormat("https://openapi.kujiale.com/v2/design/{0}/basic/", designId)
               .AppendFormat("?appkey={0}", APPKEY)
               .AppendFormat("&timestamp={0}", timestamp)
               .AppendFormat("&sign={0}", sign);

            string postData = "{\"name\":\"" + designName + "\"}";
            byte[] postdatabyte = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = postdatabyte.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(postdatabyte, 0, postdatabyte.Length);
            stream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = string.Empty;
            result = sr.ReadToEnd();
            sr.Close();
            response.Close();

            this.Response.Write(result);
        }

        /// <summary>
        /// 复制酷家乐方案
        /// </summary>
        public void KJL_CopyDesign()
        {
            try
            {
                string designId = Request["DesignID"];
                if (string.IsNullOrEmpty(designId))
                {
                    throw new Exception("DesignID参数无效。");
                }
                string appuid = CurrentUser.UserCode;
                long timestamp = CreateTimeStamp();
                string sign = MD5Encrypt(APPSECRET + APPKEY + appuid + timestamp);

                StringBuilder url = new StringBuilder();
                url.AppendFormat("https://openapi.kujiale.com/v2/design/{0}/copy/", designId)
                   .AppendFormat("?appkey={0}", APPKEY)
                   .AppendFormat("&timestamp={0}", timestamp)
                   .AppendFormat("&sign={0}", sign)
                   .AppendFormat("&appuid={0}", appuid) //复制的目标用户的第三方ID
                   .AppendFormat("&copy_render_pics={0}", false); //true表示复制方案的时候也要复制渲染图，false表示只复制方案，不复制渲染图

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
                request.Method = "POST";
                request.ContentType = "text/plain;charset=utf-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = string.Empty;
                result = sr.ReadToEnd();
                sr.Close();
                response.Close();

                this.Response.Write(result);
            }
            catch (Exception ex)
            {
                WriteMessage(0, ex.Message);
            }
        }

        /// <summary>
        /// 获取酷家乐该方案可生成的施工图列表
        /// </summary>
        public void KJL_GetConstructionSetList()
        {
            try
            {
                string designId = Request["designId"];
                if (string.IsNullOrEmpty(designId))
                {
                    throw new Exception("方案ID参数无效。");
                }
                long timestamp = CreateTimeStamp();
                string sign = MD5Encrypt(APPSECRET + APPKEY + timestamp);

                StringBuilder url = new StringBuilder();
                url.AppendFormat("https://www.kujiale.com/api/cloud/construction/set/{0}", designId)
                   .AppendFormat("?appkey={0}", APPKEY)
                   .AppendFormat("&timestamp={0}", timestamp)
                   .AppendFormat("&sign={0}", sign);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                string result = string.Empty;
                result = sr.ReadToEnd();
                this.Response.Write(result);
            }
            catch (Exception ex)
            {
                WriteMessage(0, ex.Message);
            }
        }

        /// <summary>
        /// [异步]生成CAD户型图/施工图
        /// </summary>
        public void KJL_CreateConstruction()
        {
            try
            {
                string designId = Request["DesignID"];
                string cadType = Request["CADType"];
                if (string.IsNullOrEmpty(designId))
                {
                    throw new Exception("方案ID参数无效。");
                }
                if (string.IsNullOrEmpty(cadType))
                {
                    throw new Exception("施工图种类参数无效。");
                }
                long timestamp = CreateTimeStamp();
                string sign = MD5Encrypt(APPSECRET + APPKEY + timestamp);

                StringBuilder url = new StringBuilder();
                url.AppendFormat("https://openapi.kujiale.com/v2/design/{0}/cd", designId)
                   .AppendFormat("?appkey={0}", APPKEY)
                   .AppendFormat("&timestamp={0}", timestamp)
                   .AppendFormat("&sign={0}", sign);

                string postData = JSONHelper.SerializeObject(cadType.Split(',').ToArray());
                byte[] postdatabyte = Encoding.UTF8.GetBytes(postData);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                request.ContentLength = postdatabyte.Length;

                Stream stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string result = string.Empty;
                result = sr.ReadToEnd();
                this.Response.Write(result);
            }
            catch (Exception ex)
            {
                WriteMessage(0, ex.Message);
            }
        }

        /// <summary>
        /// 获取CAD户型图/施工图
        /// </summary>
        public void KJL_GetConstruction()
        {
            try
            {
                string designId = Request["designId"];
                if (string.IsNullOrEmpty(designId))
                {
                    throw new Exception("方案ID参数无效。");
                }
                long timestamp = CreateTimeStamp();
                string sign = MD5Encrypt(APPSECRET + APPKEY + timestamp);

                StringBuilder url = new StringBuilder();
                url.AppendFormat("https://openapi.kujiale.com/v2/design/{0}/cd", designId)
                   .AppendFormat("?appkey={0}", APPKEY)
                   .AppendFormat("&timestamp={0}", timestamp)
                   .AppendFormat("&sign={0}", sign);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                string result = string.Empty;
                result = sr.ReadToEnd();
                this.Response.Write(result);
            }
            catch (Exception ex)
            {
                WriteMessage(0, ex.Message);
            }
        }

        /// <summary>
        /// 获取指定方案下的渲染图列表
        /// </summary>
        public void KJL_GetRenderPic()
        {
            int start = 0; //拉取位置
            int num = 10; //拉取数量
            string designId = Request["designId"];
            if (string.IsNullOrEmpty(designId))
            {
                throw new Exception("方案ID参数无效。");
            }
            if (!string.IsNullOrEmpty(Request["PageSize"]))
            {
                num = Convert.ToInt32(Request["PageSize"]);
            }
            if (!string.IsNullOrEmpty(Request["PageIndex"]))
            {
                int pageIndex = Convert.ToInt32(Request["PageIndex"]);
                start = (pageIndex - 1) * num;
            }

            long timestamp = CreateTimeStamp();
            string sign = MD5Encrypt(APPSECRET + APPKEY + timestamp);

            StringBuilder url = new StringBuilder();
            url.Append("https://openapi.kujiale.com/v2/renderpic/list")
               .AppendFormat("?design_id={0}", designId)
               .AppendFormat("&start_time={0}", "")
               .AppendFormat("&start={0}", start)
               .AppendFormat("&num={0}", num)
               .AppendFormat("&appkey={0}", APPKEY)
               .AppendFormat("&timestamp={0}", timestamp)
               .AppendFormat("&sign={0}", sign);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            string result = string.Empty;
            result = sr.ReadToEnd();

            //JObject obj = JObject.Parse(result);
            //string 
            //Database db = new Database("BE_Customer_Proc", "GETCUSNAME", 0, 0, "", "", "");
            //string cusName = db.ExecuteScalar().ToString();

            this.Response.Write(result);
        }

        public void GetCusName()
        {

            string designId = Request["designId"];
            Database db = new Database("BE_Customer_Proc", "GETCUSNAME", 0, 0, designId, "", "");
            using (SqlDataReader dr = db.ExecuteReader())
            {
                DataTable dt = StaticFunction.ConvertDataReaderToDataTable(dr);
                string json = JSONHelper.SerializeObject(dt);
                this.Response.Write(json);
            }
        }

        /// <summary>
        /// 设置子账户禁用|启用
        /// </summary>
        public void KJL_SetDisabled()
        {
            string appuid = Request["appuid"];
            string disabled = Request["disabled"];
            this.Response.Write(setdisabled(appuid, disabled));
        }

        public string setdisabled(string appuid, string disabled)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(disabled))
            {
                long timestamp = CreateTimeStamp();
                string sign = MD5Encrypt(APPSECRET + APPKEY + appuid + timestamp);

                StringBuilder url = new StringBuilder();
                url.Append("https://openapi.kujiale.com/v2/user")
                   .AppendFormat("?appuid={0}", appuid)
                   .AppendFormat("&appkey={0}", APPKEY)
                   .AppendFormat("&timestamp={0}", timestamp)
                   .AppendFormat("&sign={0}", sign);

                //true表示启用，false表示禁用
                string postData = "{\"enabled\":\"" + disabled + "\"}";
                byte[] postdatabyte = Encoding.UTF8.GetBytes(postData);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                request.ContentLength = postdatabyte.Length;

                Stream stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                result = sr.ReadToEnd();
                sr.Close();
                response.Close();
            }
            return result;
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 生成一个时间戳
        /// </summary>
        /// <returns></returns>
        private long CreateTimeStamp()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (DateTime.Now.Ticks - startTime.Ticks) / 10000; //除10000调整为13位
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="targetValue">目标值</param>
        /// <returns></returns>
        private string MD5Encrypt(string targetValue)
        {
            byte[] data = Encoding.UTF8.GetBytes(targetValue);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string returnValue = string.Empty;
            for (int j = 0; j < result.Length; j++)
            {
                returnValue += result[j].ToString("x").PadLeft(2, '0');
            }
            return returnValue;
        }

        #endregion
    }
}