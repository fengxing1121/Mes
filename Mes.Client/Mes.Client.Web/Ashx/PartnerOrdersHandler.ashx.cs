//using Eagle.Data;
//using Mes.Client.Model.Parm;
//using Mes.Client.Service;
//using Mes.Client.Service.BE;
//using Mes.Client.Utility.Pages;
//using System;
//using System.Reflection;
//using System.Web;

//namespace Mes.Client.Web.Ashx
//{
//    /// <summary>
//    /// PartnerOrdersHandler 的摘要说明
//    /// </summary>
//    public class PartnerOrdersHandler : BaseHttpHandler
//    {
//        #region ===================初始加载=====================
//        OrderParm parm = null;
//        CustomerTransDetailParm pparm = null;
//        public override void ProcessRequest(HttpContext context)
//        {
//            base.ProcessRequest(context);
//            string method = Request["Method"] ?? "";

//            if (!string.IsNullOrEmpty(method))
//            {
//                parm = new OrderParm(context);
//                pparm = new CustomerTransDetailParm(context);
//                foreach (MethodInfo mi in this.GetType().GetMethods())
//                {
//                    if (mi.Name.ToLower() == method.ToLower())
//                    {
//                        mi.Invoke(this, null);
//                        break;
//                    }
//                }
//            }
//        }
//        #endregion

//        public void SaveOrder()
//        {
//            try
//            {

//                //判断订单状态

//                using (ProxyBE p = new ProxyBE())
//                {
//                    #region Order
//                    Database dbCheck = new Database("BE_PartnerOrder_Proc", "CHECKORDER", 0, 0, parm.OrderID.ToString(), "", "");
//                    int r = dbCheck.ExecuteNoQuery();
//                    //int r = dbCheck.ReturnValue;
//                    if (r == -1)
//                    {
//                        WriteError("该方案订单已到生产线排产，不能重复提交！");
//                        return;
//                    }


//                    Order order = p.Client.GetOrder(SenderUser, parm.OrderID);
//                    if (order == null)
//                    {
//                        order = new Order();
//                        order.OrderID = parm.OrderID;
//                    }
//                    if (parm.CabinetType == "请选择")
//                    {
//                        throw new Exception("请选择产品类型！");
//                    }
//                    if (pparm.QuoteID == Guid.Empty)
//                    {
//                        throw new Exception("参数无效");
//                    }
//                    QuoteMain quoteMain = p.Client.GetQuoteMain(SenderUser, pparm.QuoteID);
//                    if (quoteMain == null)
//                    {
//                        throw new Exception("参数无效");
//                    }
//                    //order.OrderNo = parm.OrderNo; //订单号
//                    order.Discount = quoteMain.DiscountPercent;
//                    order.DiscountAmount = quoteMain.DiscountAmount;
//                    order.QuoteAmount = quoteMain.TotalAmount;
//                    order.PartnerID = parm.PartnerID;//经销商ID
//                    order.CustomerID = parm.CustomerID;
//                    order.BattchNum = "";//生产批次号                  
//                    order.OutOrderNo = parm.OutOrderNo; ;//外部单号     
//                    order.Address = parm.Address;
//                    order.CustomerName = parm.CustomerName;
//                    order.BookingDate = parm.BookingDate;//订货日期
//                    order.ShipDate = parm.ShipDate;//交货日期
//                    order.PurchaseNo = parm.PurchaseNo;//采购单号
//                    order.Mobile = parm.Mobile;
//                    order.OrderType = parm.OrderType;
//                    order.LinkMan = parm.LinkMan;
//                    order.Remark = parm.Remark;
//                    order.IsStandard = Request["IsStandard"] == "是" ? true : false;


//                    order.IsOutsourcing = parm.IsOutsourcing;
//                    order.CabinetType = parm.CabinetType;
//                    //order.Status = "N";//待炸单
//                    //order.Status = "T";//待排产
//                    order.Status = "D";//待财务审核
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;
//                    #endregion

//                    #region OrderLog/OrderTask

//                    OrderLog log = new OrderLog();
//                    log.OrderID = order.OrderID;
//                    log.LogID = Guid.NewGuid();
//                    log.LogType = "新增订单";
//                    log.Remark = "用户新增一条订单";
//                    args.OrderLog = log;

//                    OrderTask ot = new OrderTask();
//                    ot.Action = "新增订单";
//                    ot.CurrentStep = "新增订单";
//                    ot.ActionRemarksType = "新增订单";
//                    ot.ActionRemarks = "新增订单";
//                    ot.Resource = "";
//                    ot.NextResources = "订单确认组";
//                    ot.NextStep = "订单确认";
//                    args.OrderTask = ot;

//                    #endregion


//                    p.Client.SaveOrder(SenderUser, args);

//                    //Liu20180412
//                    //商品

//                    //板件

//                    //五金
//                    Database db = new Database("BE_Solution2Order_Proc", "CLONE", 0, 0, parm.OrderID.ToString(), "", "");
//                    int result = db.ExecuteNoQuery();






//                    Database dbUPSTEP = new Database("BE_PartnerTask_Proc", "UPSTEPNO5", 6, 0, Request["TaskID"], "完成", "P");
//                    int rst = dbUPSTEP.ExecuteNoQuery();
//                    if (rst == 0)
//                    {
//                        WriteError("失败！");
//                    }









//                    //#region CustomerTransDetail
//                    //if (Request["Payee"].ToString() != String.Empty && Request["Amount"].ToString() != String.Empty && Request["TransDate"].ToString() != String.Empty && Request["VoucherNo"].ToString() != String.Empty)
//                    //{
//                    //    SaveCustomerTransDetailArgs argss = new SaveCustomerTransDetailArgs();
//                    //    CustomerTransDetail transDetail = new CustomerTransDetail();
//                    //    transDetail.TransID = Guid.NewGuid();
//                    //    transDetail.Payee = Request["Payee"].ToString();
//                    //    transDetail.Amount = decimal.Parse(Request["Amount"].ToString());
//                    //    transDetail.CustomerID = pparm.CustomerID;
//                    //    transDetail.QuoteID = pparm.QuoteID;
//                    //    transDetail.TransDate = Convert.ToDateTime(Request["TransDate"].ToString());
//                    //    transDetail.VoucherNo = Request["VoucherNo"].ToString();
//                    //    argss.CustomerTransDetail = transDetail;
//                    //    p.Client.SaveCustomerTransDetail(SenderUser, argss);
//                    //}
//                    //#endregion

//                    //#region 经销商任务
//                    //Guid taskid = new Guid(Request["TaskID"]);
//                    //PartnerTask task = p.Client.GetPartnerTask(SenderUser, taskid);
//                    //SavePartnerTaskArgs taskArgs = new SavePartnerTaskArgs();
//                    //taskArgs.Action = "提交订单完成";
//                    //taskArgs.ActionRemarks = "";
//                    //taskArgs.ActionRemarksType = "";
//                    //taskArgs.CurrentStep = "待提交订单";
//                    //taskArgs.NextStep = "完成";
//                    //taskArgs.Resource = "报价确认组";
//                    //taskArgs.NextResource = "";
//                    //taskArgs.PartnerTask = task;

//                    //Guid SolutionID = new Guid(Request["SolutionID"]);
//                    //Solution solution = p.Client.GetSolution(SenderUser, SolutionID);
//                    //if (solution != null)
//                    //{
//                    //    solution.Status = "F";
//                    //    taskArgs.Solution = solution;
//                    //}
//                    //quoteMain.Status = "F";
//                    //taskArgs.QuoteMain = quoteMain;

//                    //Guid DesignerID = new Guid(Request["SolutionID"]);
//                    //RoomDesigner roomDesigner = p.Client.GetRoomDesigner(SenderUser, DesignerID);
//                    //if (roomDesigner != null)
//                    //{
//                    //    roomDesigner.Status = "F";
//                    //    taskArgs.RoomDesigner = roomDesigner;
//                    //}
//                    //p.Client.SavePartnerTask(SenderUser, taskArgs);
//                    //#endregion
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//    }
//}