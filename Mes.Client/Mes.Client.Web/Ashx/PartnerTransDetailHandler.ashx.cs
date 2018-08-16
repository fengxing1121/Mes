using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// PartnerTransDetailHandler 的摘要说明
    /// </summary>
    public class PartnerTransDetailHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================  
        PartnerTransDetailParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new PartnerTransDetailParm(context);
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

        public void SearchPartnerTransDetail()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchOrderArgs args = new SearchOrderArgs();
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.OrderBy = "created desc";

                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
                    {
                        args.CustomerName = Request["CustomerName"];
                    }
                    if (!string.IsNullOrEmpty(Request["Status"]))
                    {
                        args.Status = new List<string>();
                        args.Status.Add(Request["Status"].ToString());
                    }
                    if (!string.IsNullOrEmpty(Request["OrderNo"]))
                    {
                        args.OrderNo = Request["OrderNo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["PurchaseNo"]))
                    {
                        args.PurchaseNo = Request["PurchaseNo"].ToString();
                    }
                    SearchResult sr = p.Client.SearchOrder(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveTransDetail()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SavePartnerTransDetailArgs args = new SavePartnerTransDetailArgs();

                    PartnerTransDetail transDetail = new PartnerTransDetail();
                    transDetail.TransID = Guid.NewGuid();
                    transDetail.OrderID = parm.OrderID;
                    transDetail.PartnerID = parm.PartnerID;
                    transDetail.VoucherNo = parm.VoucherNo;
                    transDetail.Payee = parm.Payee;
                    transDetail.TransDate = parm.TransDate;
                    transDetail.Amount = parm.Amount;

                    args.PartnerTransDetail = transDetail;
                    p.Client.SavePartnerTransDetail(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SearchTransDetail()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPartnerTransDetailArgs args = new SearchPartnerTransDetailArgs();
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.OrderBy = "Created desc";

                    if (!string.IsNullOrEmpty(Request["OrderID"]))
                    {
                        args.OrderID = Guid.Parse(Request["OrderID"]);
                    }

                    SearchResult sr = p.Client.SearchPartnerTransDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}