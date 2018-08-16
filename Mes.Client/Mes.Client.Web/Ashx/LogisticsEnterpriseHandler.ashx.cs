using Mes.Client.Model.Parm;
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
    /// LogisticsEnterpriseHandler 的摘要说明
    /// </summary>
    public class LogisticsEnterpriseHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        LogisticsEnterpriseParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new LogisticsEnterpriseParm(context);
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
        #endregion

        public void SearchLogistics()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchLogisticsEnterpriseArgs sargs = new SearchLogisticsEnterpriseArgs();
                    sargs.OrderBy = "Created desc";
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    //Where
                    if (!string.IsNullOrEmpty(parm.EnterpriseName))
                    {
                        sargs.EnterpriseName = parm.EnterpriseName;
                    }
                    if (!string.IsNullOrEmpty(parm.LinkMan))
                    {
                        sargs.LinkMan = parm.LinkMan;
                    }
                    if (!string.IsNullOrEmpty(parm.Tel))
                    {
                        sargs.Tel = parm.Tel;
                    }
                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        sargs.Mobile = parm.Mobile;
                    }
                    if (!string.IsNullOrEmpty(parm.Address))
                    {
                        sargs.Address = parm.Address;
                    }
                    SearchResult sr = p.Client.SearchLogisticsEnterprise(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void NewLogistic()
        {
            try
            {
                LogisticsEnterprise le = new LogisticsEnterprise();
                le.EnterpriseName = "";
                le.Address = "";
                le.Mobile = "";
                le.Tel = "";
                le.LinkMan = "";
                Response.Write(JSONHelper.Object2Json(le));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetLogistic()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid eid = new Guid(Request["EnterpriseID"]);
                    LogisticsEnterprise le = p.Client.GetLogisticsEnterprise(SenderUser, eid);
                    if (le == null)
                    {
                        throw new Exception("所查找物流企业不存在。");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(le));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveLogistic()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    LogisticsEnterprise le = p.Client.GetLogisticsEnterprise(null, parm.EnterpriseID);
                    if (le == null)
                    {
                        le = new LogisticsEnterprise();
                        le.EnterpriseID = parm.EnterpriseID;
                    }

                    le.EnterpriseName = parm.EnterpriseName.Trim();
                    le.LinkMan = parm.LinkMan.Trim();
                    le.Mobile = parm.Mobile.Trim();
                    le.Tel = parm.Tel.Trim();
                    le.Address = parm.Address.Trim();
                    SaveLogisticsEnterpriseArgs args = new SaveLogisticsEnterpriseArgs();
                    args.LogisticsEnterprise = le;
                    p.Client.SaveLogisticsEnterprise(SenderUser, args);
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }
    }
}