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
    /// QuoteShowHandler 的摘要说明
    /// </summary>
    public class QuoteShowHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
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
        #endregion

        public void GetQutoMain()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["QuoteID"]))
                {
                    throw new Exception("报价单:调用参数无效。");
                }
                Guid QuoteID = new Guid(Request["QuoteID"].ToString());
                using (ProxyBE p = new ProxyBE())
                {
                    QuoteMain quoteMain = p.Client.GetQuoteMain(SenderUser, QuoteID);
                    if (quoteMain != null)
                    {
                        Response.Write(JSONHelper.Object2JSON(quoteMain));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void GetQuoteDetail()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["QuoteID"]))
                {
                    throw new Exception("报价单:QuoteID,调用参数无效。");
                }
                Guid QuoteID = new Guid(Request["QuoteID"].ToString());
                using (ProxyBE p = new ProxyBE())
                {
                    SearchQuoteDetailArgs args = new SearchQuoteDetailArgs();
                    args.QuoteID = QuoteID;
                    if (!string.IsNullOrEmpty(Request["ItemGroup"]))
                    {
                        args.ItemGroup = Request["ItemGroup"].ToString();
                    }
                    else
                    {
                        args.ItemGroup = "";
                    }
                    SearchResult sr = p.Client.SearchQuoteDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void ModifyQuoteMainStatus()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["Status"]) && string.IsNullOrEmpty(Request["QuoteID"]))
                {
                    throw new Exception("方案明细:调用参数无效。");
                }
                Guid QuoteID = Guid.Parse(Request["QuoteID"].ToString());
                using (ProxyBE p = new ProxyBE())
                {
                    var quoteMain = p.Client.GetQuoteMain(SenderUser, QuoteID);
                    if (quoteMain != null)
                    {
                        if (quoteMain.Status.Equals(Request["Status"].ToString(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            throw new Exception("方案明细:状态重复,不可修改.");
                        }
                        quoteMain.Status = Convert.ToString(Request["Status"]);
                        SaveQuoteMainArgs args = new SaveQuoteMainArgs();
                        args.QuoteMain = quoteMain;
                        p.Client.SaveQuote(SenderUser, args);
                        WriteSuccess();
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void FindQuoteMainStatus()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["Status"]) && string.IsNullOrEmpty(Request["QuoteID"]))
                {
                    throw new Exception("方案明细:调用参数无效。");
                }
                Guid QuoteID = Guid.Parse(Request["QuoteID"].ToString());
                using (ProxyBE p = new ProxyBE())
                {
                    var quoteMain = p.Client.GetQuoteMain(SenderUser, QuoteID);
                    if (quoteMain != null)
                    {
                        if (!quoteMain.Status.Equals(Request["Status"].ToString(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            throw new Exception("方案明细:状态已经修改.");
                        }
                        WriteSuccess();
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