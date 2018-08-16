using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Data;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// PartnerUserTransDetailHandler 的摘要说明
    /// </summary>
    public class PartnerUserTransDetailHandler : BaseHttpHandler
    {

        #region ===================初始加载=====================
        CustomerTransDetailParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new CustomerTransDetailParm(context);
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

        public void SearchCustomerTransDetail()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchQuoteMainArgs args = new SearchQuoteMainArgs();
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.OrderBy = "Created desc";

                    if (!string.IsNullOrEmpty(Request["SolutionCode"]))
                    {
                        args.SolutionCode = Request["SolutionCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["SolutionName"]))
                    {
                        args.SolutionName = Request["SolutionName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
                    {
                        args.CustomerName = Request["CustomerName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["QuoteNo"]))
                    {
                        args.QuoteNo = Request["QuoteNo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["Status"]))
                    {
                        args.Status = Request["Status"].ToString();
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }

                    SearchResult sr = p.Client.SearchQuote(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));

                    #region
                    //SearchOrderArgs
                    //SearchCustomerTransDetailArgs args = new SearchCustomerTransDetailArgs();
                    //args.RowNumberFrom = pagingParm.RowNumberFrom;
                    //args.RowNumberTo = pagingParm.RowNumberTo;
                    //args.OrderBy = "Created desc";

                    //if (CurrentUser.PartnerID!=Guid.Empty)
                    //{
                    //   args.PartnerID = CurrentUser.PartnerID;
                    //}
                    //if(!string.IsNullOrEmpty(Request["CustomerName"]))
                    //{
                    //    args.CustomerName = Request["CustomerName"].ToString();
                    //}
                    //if (!string.IsNullOrEmpty(Request["LinkMan"]))
                    //{
                    //    args.LinkMan = Request["LinkMan"].ToString();
                    //}
                    //if (!string.IsNullOrEmpty(Request["Mobile"]))
                    //{
                    //    args.Mobile = Request["Mobile"].ToString();
                    //}
                    //SearchResult sr = p.Client.SearchCustomerTransDetail(SenderUser,args);

                    #endregion
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SearchTransDetail()
        {
            using (ProxyBE p = new ProxyBE())
            {
                SearchCustomerTransDetailArgs args = new SearchCustomerTransDetailArgs();
                args.RowNumberFrom = pagingParm.RowNumberFrom;
                args.RowNumberTo = pagingParm.RowNumberTo;
                args.OrderBy = "Created desc";

                if (!string.IsNullOrEmpty(Request["QuoteID"]))
                {
                    args.QuoteID = Guid.Parse(Request["QuoteID"]);
                }
                if (!string.IsNullOrEmpty(Request["CustomerID"]))
                {
                    args.CustomerID = Guid.Parse(Request["CustomerID"]);
                }
                SearchResult sr = p.Client.SearchCustomerTransDetail(SenderUser, args);
                Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
            }
        }

        public void GetCustomerTransAmount()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["CustomerID"]))
                    {
                        throw new Exception("CustomerID:参数无效");
                    }
                    if (string.IsNullOrEmpty(Request["QuoteID"]))
                    {
                        throw new Exception("QuoteID:参数无效");
                    }
                    SearchCustomerTransDetailArgs args = new SearchCustomerTransDetailArgs();
                    args.CustomerID = Guid.Parse(Request["CustomerID"].ToString());
                    args.QuoteID = Guid.Parse(Request["QuoteID"].ToString());
                    SearchResult sr = p.Client.SearchCustomerTransDetail(SenderUser, args);
                    if (sr.Total != 0)
                    {
                        decimal DisCount = 0.00m;
                        foreach (DataRow dr in sr.DataSet.Tables[0].Rows)
                        {
                            DisCount += decimal.Parse(dr["Amount"].ToString());
                        }
                        WriteMessage(1, DisCount.ToString());
                    }
                    else
                    {
                        WriteMessage(1, "0");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveCustomerTransDetail()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    #region transDetail
                    CustomerTransDetail transDetail = new CustomerTransDetail();
                    transDetail.TransID = Guid.NewGuid();
                    transDetail.QuoteID = parm.QuoteID;
                    transDetail.CustomerID = parm.CustomerID;
                    transDetail.Payee = parm.Payee;
                    transDetail.TransDate = parm.TransDate;
                    transDetail.VoucherNo = parm.VoucherNo;
                    transDetail.Amount = parm.Amount;
                    SaveCustomerTransDetailArgs args = new SaveCustomerTransDetailArgs();
                    args.CustomerTransDetail = transDetail;

                    p.Client.SaveCustomerTransDetail(SenderUser, args);
                    WriteSuccess();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}