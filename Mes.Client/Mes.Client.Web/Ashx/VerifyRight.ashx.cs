using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Enum;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// VerifyRight 的摘要说明
    /// </summary>
    public class VerifyRight : BaseHttpHandler
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

        public void GetRight()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string pid = Request["pid"];
                    if (!string.IsNullOrEmpty(pid))
                    {
                        List<PrivilegeItem> list = new List<PrivilegeItem>();
                        //经销商权限
                        if (CurrentUser.UserType == (int)UserType.D)
                        {
                            list = p.Client.GetPrivilegeItemByPrivilegeID_PartnerUserID(SenderUser, new Guid(pid), CurrentUser.UserID);
                        }
                        //用户权限
                        if (CurrentUser.UserType == (int)UserType.U)
                        {
                            list = p.Client.GetPrivilegeItemByPrivilegeID_UserID(SenderUser, new Guid(pid), CurrentUser.UserID);
                        }
                        Response.Write(JSONHelper.Object2JSON(list));
                    }
                    else
                    {
                        throw new Exception("菜单权限无效");
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void GetPartnerRight()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string pid = Request["pid"];
                    if (!string.IsNullOrEmpty(pid))
                    {
                        List<PrivilegeItem> list = p.Client.GetPrivilegeItemByPrivilegeID_PartnerUserID(SenderUser, new Guid(pid), CurrentUser.UserID);
                        Response.Write(JSONHelper.Object2JSON(list));
                    }
                    else
                    {
                        throw new Exception("菜单权限无效");
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }

        }
    }
}