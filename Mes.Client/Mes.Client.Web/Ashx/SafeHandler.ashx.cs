using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// SafeHandler 的摘要说明
    /// </summary>
    public class SafeHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================

        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";
                if (string.IsNullOrEmpty(method))
                {
                    throw new Exception("无效的参数。");
                }
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
        #endregion

        /// <summary>
        /// 验证用户
        /// </summary>
        public void CheckUserCode()
        {
            try
            {
                string code = Request["UserCode"];
                if (!string.IsNullOrEmpty(code))
                {
                    if (string.IsNullOrEmpty(Session["LoginVerifyCode"].ToString()))
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":22}");
                        return;
                    }
                    if (code != Session["LoginVerifyCode"].ToString())
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                        return;
                    }

                    string timeout = Session["LoginVerifyCode_TimeOut"].ToString();
                    if (!string.IsNullOrEmpty(timeout))
                    {
                        if (DateTime.Now > DateTime.Parse(timeout))
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":24}");
                            return;
                        }
                    }

                    Response.Write("{\"result\":\"success\",\"errorCode\":0}");
                    return;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }

        public void CheckVerifyCode()
        {
            try
            {
                string code = Request["VerifyCode"];
                if (!string.IsNullOrEmpty(code))
                {
                    if (string.IsNullOrEmpty(Session["LoginVerifyCode"].ToString()))
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":22}");
                        return;
                    }
                    if (code != Session["LoginVerifyCode"].ToString())
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                        return;
                    }

                    string timeout = Session["LoginVerifyCode_TimeOut"].ToString();
                    if (!string.IsNullOrEmpty(timeout))
                    {
                        if (DateTime.Now > DateTime.Parse(timeout))
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":24}");
                            return;
                        }
                    }

                    Response.Write("{\"result\":\"success\",\"errorCode\":0}");
                    return;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }

        /// <summary>
        /// 提交申请
        /// </summary>
        public void safeverify()
        {
            try
            {
                #region 验证码
                string code = Request["ImgVerifyCode"];
                if (!string.IsNullOrEmpty(code))
                {
                    if (string.IsNullOrEmpty(Session["LoginVerifyCode"].ToString()))
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":22}");
                        return;
                    }
                    if (code.ToString().ToUpper() != Session["LoginVerifyCode"].ToString().ToUpper())
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                        return;
                    }

                    string timeout = Session["LoginVerifyCode_TimeOut"].ToString();
                    if (!string.IsNullOrEmpty(timeout))
                    {
                        if (DateTime.Now > DateTime.Parse(timeout))
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":24}");
                            return;
                        }
                    }
                }
                else
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                    return;
                }
                #endregion

                #region 验证用户
                string usercode = Request["UserCode"];
                if (string.IsNullOrEmpty(usercode))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":30}");
                    return;
                }
                using (ProxyBE be = new ProxyBE())
                {
                    User u = be.Client.GetUserByUserCode(base.SenderUser, usercode);
                    if (u == null)
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":30}");
                        return;
                    }
                    if (string.IsNullOrEmpty(u.Mobile))
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":33}");
                        return;
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.AppendFormat("\"result\":\"{0}\",", "success");
                    sb.Append("\"data\":");
                    sb.Append("{");
                    sb.AppendFormat("\"UserID\":\"{0}\",", u.UserID);
                    sb.AppendFormat("\"UserCode\":\"{0}\",", u.UserCode);
                    sb.AppendFormat("\"Mobile\":\"{0}\",", u.Mobile.Replace(u.Mobile.Substring(4, 4), "****"));
                    if (!string.IsNullOrEmpty(u.Email))
                    {
                        string email = u.Email;
                        email = email.Replace(email.Substring(2, email.IndexOf('@') - 1), "****");
                        sb.AppendFormat("\"Email\":\"{0}\",", email);
                    }
                    sb.AppendFormat("\"Token\":\"{0}\"", Guid.NewGuid().ToString());
                    sb.Append("}");
                    sb.Append("}");

                    Response.Write(sb.ToString());
                }
                #endregion
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }

        /// <summary>
        /// 经销商提出申请
        /// </summary>
        public void PartnerSafeVerify()
        {
            try
            {
                #region 验证码
                string code = Request["ImgVerifyCode"];
                if (!string.IsNullOrEmpty(code))
                {
                    if (string.IsNullOrEmpty(Session["LoginVerifyCode"].ToString()))
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":22}");
                        return;
                    }
                    if (code.ToString().ToUpper() != Session["LoginVerifyCode"].ToString().ToUpper())
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                        return;
                    }

                    string timeout = Session["LoginVerifyCode_TimeOut"].ToString();
                    if (!string.IsNullOrEmpty(timeout))
                    {
                        if (DateTime.Now > DateTime.Parse(timeout))
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":24}");
                            return;
                        }
                    }
                }
                else
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                    return;
                }
                #endregion

                #region 验证用户
                string usercode = Request["UserCode"];
                if (string.IsNullOrEmpty(usercode))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":30}");
                    return;
                }
                using (ProxyBE be = new ProxyBE())
                {
                    PartnerUser u = be.Client.GetPartnerUserByUserCode(SenderUser, usercode);
                    if (u == null)
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":30}");
                        return;
                    }
                    if (string.IsNullOrEmpty(u.Mobile))
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":33}");
                        return;
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.AppendFormat("\"result\":\"{0}\",", "success");
                    sb.Append("\"data\":");
                    sb.Append("{");
                    sb.AppendFormat("\"UserID\":\"{0}\",", u.UserID);
                    sb.AppendFormat("\"UserCode\":\"{0}\",", u.UserCode);
                    sb.AppendFormat("\"Mobile\":\"{0}\",", u.Mobile.Replace(u.Mobile.Substring(4, 4), "****"));
                    if (!string.IsNullOrEmpty(u.Email))
                    {
                        string email = u.Email;
                        email = email.Replace(email.Substring(2, email.IndexOf('@') - 1), "****");
                        sb.AppendFormat("\"Email\":\"{0}\",", email);
                    }
                    sb.AppendFormat("\"Token\":\"{0}\"", Guid.NewGuid().ToString());
                    sb.Append("}");
                    sb.Append("}");

                    Response.Write(sb.ToString());
                }
                #endregion
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        public void SendSMS()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["UserID"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                if (string.IsNullOrEmpty(Request["Token"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                using (ProxyBE p = new ProxyBE())
                {
                    User user = p.Client.GetUser(SenderUser, new Guid(Request["UserID"]));
                    if (user == null)
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                        return;
                    }

                    //Random rd = new Random();
                    string verifycode = "";// rd.Next(1000, 9999).ToString();

                    #region 发送短信
                    //using (ProxyEE pe = new ProxyEE())
                    //{
                    //    verifycode = pe.Client.GetAuthorizationCode(user.Mobile, 10, 4);
                    //    pe.Client.SendMessage(new string[] { user.Mobile }, "MES密码重置验证码：" + verifycode + "，打死也不能告诉别人。验证码10分钟内有效。");
                    //}
                    #endregion

                    //发短信
                    Session["SMSVerify_" + user.Mobile] = verifycode;
                    Session["SMSVerify_TimeOut_" + user.Mobile] = DateTime.Now.AddMinutes(10);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.AppendFormat("\"result\":\"{0}\",", "success");
                    sb.Append("\"data\":");
                    sb.Append("{");
                    sb.AppendFormat("\"UserID\":\"{0}\",", user.UserID);
                    sb.AppendFormat("\"UserCode\":\"{0}\",", user.UserCode);
                    sb.AppendFormat("\"Token\":\"{0}\"", Guid.NewGuid().ToString());
                    sb.Append("}");
                    sb.Append("}");
                    Response.Write(sb.ToString());
                }
            }
            catch
            {
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        public void PartnerSendSMS()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["UserID"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                if (string.IsNullOrEmpty(Request["Token"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUser user = p.Client.GetPartnerUser(SenderUser, new Guid(Request["UserID"]));
                    if (user == null)
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                        return;
                    }

                    //Random rd = new Random();
                    string verifycode = "";// rd.Next(1000, 9999).ToString();

                    #region 发送短信
                    //using (ProxyEE pe = new ProxyEE())
                    //{
                    //    verifycode = pe.Client.GetAuthorizationCode(user.Mobile, 10, 4);
                    //    pe.Client.SendMessage(new string[] { user.Mobile }, "MES密码重置验证码：" + verifycode + "，打死也不能告诉别人。验证码10分钟内有效。");
                    //}
                    #endregion

                    //发短信
                    Session["SMSVerify_" + user.Mobile] = verifycode;
                    Session["SMSVerify_TimeOut_" + user.Mobile] = DateTime.Now.AddMinutes(10);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.AppendFormat("\"result\":\"{0}\",", "success");
                    sb.Append("\"data\":");
                    sb.Append("{");
                    sb.AppendFormat("\"UserID\":\"{0}\",", user.UserID);
                    sb.AppendFormat("\"UserCode\":\"{0}\",", user.UserCode);
                    sb.AppendFormat("\"Token\":\"{0}\"", Guid.NewGuid().ToString());
                    sb.Append("}");
                    sb.Append("}");
                    Response.Write(sb.ToString());
                }
            }
            catch
            {
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }

        public void ResetPasswordByMobile()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["UserID"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                if (string.IsNullOrEmpty(Request["Token"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                using (ProxyBE p = new ProxyBE())
                {
                    User user = p.Client.GetUser(SenderUser, new Guid(Request["UserID"]));
                    if (user == null)
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                        return;
                    }

                    #region 验证码
                    string code = Request["SMSVerifyCode"];
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (string.IsNullOrEmpty(Session["SMSVerify_" + user.Mobile].ToString()))
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":25}");
                            return;
                        }
                        if (code.ToString().ToUpper() != Session["SMSVerify_" + user.Mobile].ToString().ToUpper())
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":26}");
                            return;
                        }

                        string timeout = Session["SMSVerify_TimeOut_" + user.Mobile].ToString();
                        if (!string.IsNullOrEmpty(timeout))
                        {
                            if (DateTime.Now > DateTime.Parse(timeout))
                            {
                                Response.Write("{\"result\":\"error\",\"errorCode\":27}");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                        return;
                    }
                    #endregion

                    user.Password = CEncrypt.EncryptString(Request["confirmPassword"].ToString());

                    SaveUserArgs args = new SaveUserArgs();
                    args.User = user;
                    p.Client.SaveUser(SenderUser, args);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.AppendFormat("\"result\":\"{0}\",", "success");
                    sb.AppendFormat("\"errorCode\":{0}", 0);
                    sb.Append("}");
                    Response.Write(sb.ToString());
                }
            }
            catch
            {
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }

        public void PartnerResetPwdByMobile()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["UserID"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                if (string.IsNullOrEmpty(Request["Token"]))
                {
                    Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                    return;
                }
                using (ProxyBE p = new ProxyBE())
                {
                    //User user = p.Client.GetUser(SenderUser, new Guid(Request["UserID"]));
                    PartnerUser user = p.Client.GetPartnerUser(SenderUser, new Guid(Request["UserID"]));
                    if (user == null)
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":31}");
                        return;
                    }

                    #region 验证码
                    string code = Request["SMSVerifyCode"];
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (string.IsNullOrEmpty(Session["SMSVerify_" + user.Mobile].ToString()))
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":25}");
                            return;
                        }
                        if (code.ToString().ToUpper() != Session["SMSVerify_" + user.Mobile].ToString().ToUpper())
                        {
                            Response.Write("{\"result\":\"error\",\"errorCode\":26}");
                            return;
                        }

                        string timeout = Session["SMSVerify_TimeOut_" + user.Mobile].ToString();
                        if (!string.IsNullOrEmpty(timeout))
                        {
                            if (DateTime.Now > DateTime.Parse(timeout))
                            {
                                Response.Write("{\"result\":\"error\",\"errorCode\":27}");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Response.Write("{\"result\":\"error\",\"errorCode\":23}");
                        return;
                    }
                    #endregion

                    user.Password = CEncrypt.EncryptString(Request["confirmPassword"].ToString());

                    //SaveUserArgs args = new SaveUserArgs();
                    SavePartnerUserArgs args = new SavePartnerUserArgs();
                    args.PartnerUser = user;
                    p.Client.SavePartnerUser(SenderUser, args);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.AppendFormat("\"result\":\"{0}\",", "success");
                    sb.AppendFormat("\"errorCode\":{0}", 0);
                    sb.Append("}");
                    Response.Write(sb.ToString());
                }
            }
            catch
            {
                Response.Write("{\"result\":\"error\",\"errorCode\":10}");
            }
        }
    }
}