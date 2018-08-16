using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// DefaultHandler 的摘要说明
    /// </summary>
    public class DefaultHandler : BaseHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
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

        public void ModifyPassword()
        {
            string OldPassword = Request["OldPassword"];
            string NewPassword = Request["NewPassword"];

            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUser partnetUser = p.Client.GetPartnerUser(SenderUser, this.CurrentUser.UserID);
                    if (CEncrypt.DecryptString(partnetUser.Password) != OldPassword)
                    {
                        throw new Exception("旧密码错误");
                    }
                    partnetUser.Password = CEncrypt.EncryptString(NewPassword);
                    SavePartnerUserArgs arge = new SavePartnerUserArgs();
                    arge.PartnerUser = partnetUser;
                    p.Client.SavePartnerUser(SenderUser, arge);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void ModifyPasswordByEgui()
        {
            string OldPassword = Request["OldPassword"];
            string NewPassword = Request["NewPassword"];

            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUser partnetUser = p.Client.GetPartnerUser(SenderUser, this.CurrentUser.UserID);
                    if (CEncrypt.DecryptString(partnetUser.Password) != OldPassword)
                    {
                        WriteMessage(-1, "原密码错误，请重新输入");
                        return;
                    }
                    partnetUser.Password = CEncrypt.EncryptString(NewPassword);
                    SavePartnerUserArgs arge = new SavePartnerUserArgs();
                    arge.PartnerUser = partnetUser;
                    p.Client.SavePartnerUser(SenderUser, arge);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}