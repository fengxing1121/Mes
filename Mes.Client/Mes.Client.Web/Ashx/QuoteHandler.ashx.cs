using Eagle.Data;
using LitJson;
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
    /// QuoteHandler 的摘要说明
    /// </summary>
    public class QuoteHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        QuoteMainParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new QuoteMainParm(context);
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

        public void SearchQuotes()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchQuoteMainArgs args = new SearchQuoteMainArgs();
                    args.OrderBy = "Created Desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(Request["SolutionID"]))
                    {
                        args.SolutionID = Guid.Parse(Request["SolutionID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(Request["SolutionName"]))
                    {
                        args.SolutionName = Request["SolutionName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["SolutionCode"]))
                    {
                        args.SolutionCode = Request["SolutionCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["CustomerID"]))
                    {
                        args.CustomerID = Guid.Parse(Request["CustomerID"].ToString());
                    }
                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
                    {
                        args.CustomerName = Request["CustomerName"].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(Request["Status"]))
                    {
                        args.Status = Request["Status"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["QuoteNo"]))
                    {
                        args.QuoteNo = Request["QuoteNo"].ToString().Trim();
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }
                    SearchResult sr = p.Client.SearchQuote(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write(ex.Message);
            }
        }

        //方案报价明细
        public void SearchSolutionQuoteDetail()
        {
            try
            {
                using (ProxyBE op = new ProxyBE())
                {

                    if (string.IsNullOrEmpty(Request["ReferenceID"]))
                    {
                        throw new Exception("ReferenceID:调用参数无效。");
                    }
                    Solution solution = op.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    if (solution != null)
                    {
                        SearchResult sr = op.Client.SearchSolutionQuoteDetail(SenderUser, solution.SolutionID);
                        Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write(ex.Message);
            }
        }

        //方案报价五金明细
        public void SearchSolutionQuoteHardwareDetail()
        {
            try
            {
                using (ProxyBE op = new ProxyBE())
                {
                    if (string.IsNullOrEmpty(Request["ReferenceID"]))
                    {
                        throw new Exception("ReferenceID:调用参数无效。");
                    }
                    Solution solution = op.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    if (solution != null)
                    {
                        SearchResult sr = op.Client.SearchSolutionQuoteHardwareDetail(SenderUser, solution.SolutionID);
                        Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex.Message);
                Response.Write(ex.Message);
            }
        }

        //客户信息
        public void GetCustomer()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("ReferenceID:调用参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    Solution solution = op.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"].ToString()));
                    if (solution != null)
                    {
                        Customer customer = op.Client.GetCustomer(SenderUser, solution.CustomerID);
                        Response.Write(JSONHelper.Object2JSON(customer));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        //客户信息
        public void initCustomer()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["ReferenceID"]))
                {
                    throw new Exception("ReferenceID:调用参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    RoomDesigner roomDesigner = op.Client.GetRoomDesigner(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    if (roomDesigner != null)
                    {
                        Customer customer = op.Client.GetCustomer(SenderUser, roomDesigner.CustomerID);
                        Response.Write(JSONHelper.Object2JSON(customer));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }



        /// <summary>
        /// 通过SolutionID获取客户信息
        /// </summary>
        public void GetCustomerBySolutionID()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("SolutionID:调用参数无效。");
                }
                using (ProxyBE op = new ProxyBE())
                {
                    Solution solution = op.Client.GetSolution(SenderUser, Guid.Parse(Request["SolutionID"]));
                    if (solution != null)
                    {
                        Customer customer = op.Client.GetCustomer(SenderUser, solution.CustomerID);
                        Response.Write(JSONHelper.Object2JSON(customer));
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message);
            }
        }

        public void SaveQuote()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    #region  报价单

                    if (string.IsNullOrEmpty(Request["ReferenceID"]))
                    {
                        throw new Exception("ReferenceID:参数无效!");
                    }
                    Solution solution = p.Client.GetSolutionByDesignerID(SenderUser, Guid.Parse(Request["ReferenceID"]));
                    if (solution == null)
                    {
                        throw new Exception("对象无效!");
                    }
                    if (string.IsNullOrEmpty(Request["TaskID"]))
                    {
                        throw new Exception("TaskID:参数无效!");
                    }
                    QuoteMain quotemain = p.Client.GetQuoteMain(SenderUser, parm.QuoteID);
                    if (quotemain == null)
                    {
                        quotemain = new QuoteMain();
                        quotemain.QuoteID = Guid.NewGuid();
                        quotemain.SolutionID = solution.SolutionID;
                        quotemain.Status = "N"; //报价单状态，N:确认中,F:已确认,C:已取消                    
                    }
                    quotemain.PartnerID = CurrentUser.PartnerID;
                    quotemain.CustomerID = solution.CustomerID;
                    quotemain.QuoteNo = GetNumber("YS");
                    quotemain.DiscountPercent = parm.DiscountPercent;
                    quotemain.ExpiryDate = parm.ExpiryDate;
                    quotemain.Status = "N";
                    quotemain.Remark = parm.Remark;
                    SaveQuoteMainArgs args = new SaveQuoteMainArgs();

                    #endregion

                    #region 报价单详情
                    List<QuoteDetail> QuoteDetails = new List<QuoteDetail>();
                    string details = Request["QuoteDetails"];
                    decimal DiscountPercent = 1;
                    JsonData sj = JsonMapper.ToObject(details);
                    decimal totalamount = 0;
                    if (sj.Count > 0)
                    {
                        //遍历对象元素，保存
                        int i = 1;
                        foreach (JsonData item in sj)
                        {
                            try
                            {
                                QuoteDetail detail = new QuoteDetail();
                                detail.DetailID = Guid.NewGuid();
                                detail.QuoteID = quotemain.QuoteID;

                                detail.ItemGroup = item["ItemGroup"].ToString();
                                detail.ItemName = item["ItemName"].ToString();
                                detail.ItemStyle = item["ItemStyle"].ToString();
                                try
                                {
                                    detail.Qty = Decimal.Parse(item["Qty"].ToString());
                                }
                                catch
                                {
                                    throw new PException("第{0}行的数量有误。", i);
                                }
                                try
                                {
                                    detail.Price = Decimal.Parse(item["Price"].ToString());
                                }
                                catch
                                {
                                    throw new PException("第{0}行的价格有误。", i);
                                }
                                detail.ItemRemark = item["ItemRemark"].ToString();
                                QuoteDetails.Add(detail);
                                totalamount += detail.Price * detail.Qty;
                                i++;
                            }
                            catch
                            {
                                throw new PException("第{0}行的数据有误。", i);
                            }
                        }
                    }
                    quotemain.TotalAmount = totalamount;
                    quotemain.DiscountAmount = (DiscountPercent - quotemain.DiscountPercent) * quotemain.TotalAmount;
                    args.QuoteMain = quotemain;
                    args.QuoteDetails = QuoteDetails;
                    p.Client.SaveQuote(SenderUser, args);
                    #endregion

                    #region 修改方案状态
                    solution.Status = "F";//方案状态：N,待上传方案文件；P,待生成报价明细；Q,已报价；F,方案成交；C,已取消；

                    SaveSolutionArgs arg = new SaveSolutionArgs();
                    arg.Solution = solution;

                    p.Client.SaveSolution(SenderUser, arg);
                    #endregion

                    #region 任务流程
                    Database dbCheck = new Database("BE_PartnerTask_Proc", "UPSTEPNO4", 5, 0, Request["TaskID"], "待提交订单", "P");
                    int rst = dbCheck.ExecuteNoQuery();
                    if (rst == 0)
                    {
                        WriteError("失败！");
                    }

                    //PartnerTask task = p.Client.GetPartnerTask(SenderUser, Guid.Parse(Request["TaskID"]));
                    //if (task != null)
                    //{
                    //    SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
                    //    taskArgs.PartnerTask = task;
                    //    taskArgs.NextStep = "待提交订单";
                    //    taskArgs.Resource = "报价确认组";//当前处理组
                    //    taskArgs.NextResource = "报价确认组";//下一个组
                    //    taskArgs.ActionRemarksType = "";
                    //    taskArgs.ActionRemarks = "";
                    //    taskArgs.Action = "已出报价合同，待确认";
                    //    p.Client.SavePartnerTask(SenderUser, taskArgs);
                    //}
                    #endregion
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetQuoteMainBySolutionID()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["SolutionID"]))
                {
                    throw new Exception("无效的参数");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    QuoteMain quote = p.Client.GetQuoteMainBySolutionID(SenderUser, Guid.Parse(Request["SolutionID"]));
                    Response.Write(JSONHelper.Object2Json(quote));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }
    }
}