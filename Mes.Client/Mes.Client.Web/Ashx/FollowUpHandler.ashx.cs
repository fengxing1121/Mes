using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
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
    /// FollowUpHandler 的摘要说明
    /// </summary>
    public class FollowUpHandler : BaseHttpHandler
    {
        CustomerFollowUpParm parm;
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            parm = new CustomerFollowUpParm(context);
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
        #endregion

        public void SearchFollowUps()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchCustomerFollowUpArgs args = new SearchCustomerFollowUpArgs();
                    args.OrderBy = "[Created] Desc";
                    if (!string.IsNullOrEmpty(Request["FollowType"]))
                    {
                        args.FollowType = Request["FollowType"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
                    {
                        args.CustomerName = Request["CustomerName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(parm.Title))
                    {
                        args.Title = parm.Title;
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    SearchResult sr = p.Client.SearchCustomerFollowUp(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                //WriteError(ex.Message, ex);
                Response.Write(ex);
            }
        }

        public void SaveFollowUp()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    if (parm.CustomerID == Guid.Empty)
                    {
                        throw new Exception("请选择客户。");
                    }

                    if (parm.FollowType == "")
                    {
                        throw new Exception("请选择跟进方式");
                    }

                    CustomerFollowUp followup = p.Client.GetCustomerFollowUp(null, parm.FollowID);
                    if (followup == null)
                    {
                        followup = new CustomerFollowUp();
                        followup.FollowID = parm.FollowID;
                    }

                    followup.CustomerID = parm.CustomerID;
                    followup.FollowType = parm.FollowType;
                    followup.Title = parm.Title;
                    followup.Remark = parm.Remark;
                    //followup.CreatedBy = parm.CreatedBy;
                    followup.ImportantResult = parm.ImportantResult;
                    followup.Suggest = parm.Suggest;

                    SaveCustomerFollowUpArgs args = new SaveCustomerFollowUpArgs();
                    args.CustomerFollowUp = followup;
                    p.Client.SaveCustomerFollowUp(SenderUser, args);
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void UpdateFollowUp()
        {

            try
            {
                Guid FollowID = new Guid(Request["FollowID"]);
                using (ProxyBE p = new ProxyBE())
                {
                    CustomerFollowUp rd = p.Client.GetCustomerFollowUp(SenderUser, FollowID);
                    if (rd != null)
                    {
                        Response.Write(JSONHelper.Object2Json(rd));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(null));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}