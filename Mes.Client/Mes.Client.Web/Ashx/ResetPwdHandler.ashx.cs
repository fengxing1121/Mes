using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// ResetPwdHandler 的摘要说明
    /// </summary>
    public class ResetPwdHandler : BaseHttpHandler
    {
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

        public void CheckAuthority()
        {
            try
            {
                string message = "无权访问";
                string step = Request["step"];
                if (string.IsNullOrEmpty(step))
                {
                    throw new Exception(message);
                }

                switch (step)
                {
                    case "1":
                        Session["Step1"] = null;
                        Session["Step2"] = null;
                        Session["Step3"] = null;
                        Session["ResetPwdSMSCode"] = null;
                        WriteSuccess();
                        break;
                    case "2":
                        if (Session["Step1"] == null)
                        {
                            WriteMessage(0, message);
                        }
                        break;
                    case "3":
                        if (Session["Step1"] == null || Session["Step2"] == null)
                        {
                            WriteMessage(0, message);
                        }
                        break;
                    case "4":
                        if (Session["Step1"] == null || Session["Step2"] == null || Session["Step3"] == null)
                        {
                            WriteMessage(0, message);
                        }
                        else
                        {
                            Session["Step1"] = null;
                            Session["Step2"] = null;
                            Session["Step3"] = null;
                            Session["ResetPwdSMSCode"] = null;
                        }
                        break;
                    default:
                        WriteMessage(0, message);
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }

        }

        public void CheckInputAccount()
        {
            try
            {
                string UserCode = Request["username"];
                string VerifyCode = Request["verifycode"];
                if (string.IsNullOrEmpty(UserCode))
                {
                    throw new Exception("账号不能为空");
                }
                if (VerifyCode.ToLower() != Session["LoginVerifyCode"].ToString().ToLower())
                {
                    throw new Exception("验证码错误");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUser partner = p.Client.GetPartnerUserByUserCode(null, UserCode);
                    if (partner == null)
                    {
                        throw new Exception("用户不存在");
                    }

                    Session["Step1"] = true;
                    WriteMessage(1, "accountVerify.html");
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }

        public void AccountVerify()
        {
            try
            {
                string phone = Request["egui-phone"];
                string smsCode = Request["egui-smscode"];
                if (string.IsNullOrEmpty(phone))
                {
                    throw new Exception("手机号不能为空");
                }
                if (Session["ResetPwdSMSCode"] == null)
                {
                    throw new Exception("请先获取手机验证码");
                }
                if (string.IsNullOrEmpty(smsCode) || (!string.IsNullOrEmpty(smsCode) && smsCode.ToLower() != Session["ResetPwdSMSCode"].ToString().ToLower()))
                {
                    throw new Exception("验证码错误");
                }
                Session["Step2"] = phone;
                WriteMessage(1, "resetPwd.html");
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }

        public void ResetPwd()
        {
            try
            {
                string password = Request["password"];
                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception("密码不能为空");
                }
                if (Session["Step2"] == null)
                {
                    throw new Exception("账号为空，非法请求");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUser partner = p.Client.GetPartnerUserByUserCode(null, Session["Step2"].ToString());
                    if (partner == null)
                    {
                        throw new PException("用户不存在");
                    }
                    partner.Password = CEncrypt.EncryptString(password);

                    SavePartnerUserArgs pargs = new SavePartnerUserArgs();
                    pargs.PartnerUser = partner;
                    p.Client.SavePartnerUser(SenderUser, pargs);
                    Session["Step3"] = true;
                    WriteMessage(1, "resetComplete.html");
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }

        /// <summary>
        /// 获取手机验证码
        /// </summary>
        public void GetSMSCode()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    string phone = Request["phone"];
                    if (string.IsNullOrEmpty(phone))
                    {
                        throw new Exception("手机号不能为空");
                    }

                    string smsCode = SMSHelper.GetRandom(6);
                    bool isComplete = false;
                    //短信验证码限制:小于等于 1天/5次 5条/小时 累计10条/天
                    string message = SMSHelper.SendMessage(phone, smsCode, out isComplete, "SMS_134320239");
                    if (isComplete)
                    {
                        // 将手机验证码存入session
                        SetCacheSMSCode(smsCode);
                    }
                    else
                    {
                        throw new Exception("发送失败," + message);
                    }
                    WriteMessage(1, "发送成功");
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// 将手机验证码存入session
        /// </summary>
        private void SetCacheSMSCode(string smsCode)
        {
            //设置页面不被缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.AppendHeader("Pragma", "No-Cache");

            Session["ResetPwdSMSCode"] = smsCode;
            Session["ResetPwdSMSCode_TimeOut"] = DateTime.Now.AddMinutes(10);
        }
    }
}