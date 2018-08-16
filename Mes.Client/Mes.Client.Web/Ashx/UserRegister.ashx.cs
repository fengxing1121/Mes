using Mes.Client.Service;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// UserRegister 的摘要说明
    /// </summary>
    public class UserRegister : BaseHttpHandler
    {
        #region ===================初始加载=====================

        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";

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
                Response.Write(ex);
            }
        }

        public void ExistsMobile()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["mobile"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":2}");
                    return;
                }

                using (ProxyBE p = new ProxyBE())
                {
                    string Mobile = Request["mobile"];
                    if (p.Client.GetUserByMobile(SenderUser, Mobile) != null)
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":9}");
                    }
                    else
                    {
                        Response.Write("{\"result\":\"success\",\"errorCode\":0}");
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }


        #endregion

        public void send_verify()
        {
            string type = Request["type"];
            string phone = Request["phone"];
            string data = MD5("123456");
            string msg = ("{head:{result:\"success\"},body:{data:\"" + data + "\"}}");
            Response.Write(msg);
        }

        private string MD5(string encryptString)
        {
            byte[] result = Encoding.Default.GetBytes(encryptString);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string encryptResult = BitConverter.ToString(output).Replace("-", "");
            return encryptResult;
        }

        private string getReferralCode()
        {
            string code = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string ReferralCode = "";
            for (int i = 0; i < 8; i++)
            {
                int index = (new Random()).Next(0, code.Length);
                string s = code.Substring(index, 1);
                ReferralCode += s;
                code = code.Remove(index, 1);
                Thread.Sleep(50);
            }

            return ReferralCode;
        }
    }
}