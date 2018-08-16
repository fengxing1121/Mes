//using Eagle.Data;
//using ICSharpCode.SharpZipLib.Zip;
//using LitJson;
//using Mes.Client.Model;
//using Mes.Client.Model.Parm;
//using Mes.Client.Service;
//using Mes.Client.Service.BE;
//using Mes.Client.Utility;
//using Mes.Client.Utility.Enum;
//using Mes.Client.Utility.Extensions;
//using Mes.Client.Utility.Pages;
//using MES.BE.Objects;
//using MES.Libraries;
//using NPOI.HSSF.UserModel;
//using NPOI.SS.UserModel;
//using SharpCompress.Readers;
//using SharpCompress.Readers.Rar;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Data.OleDb;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Web;
//using System.Xml;

//namespace Mes.Client.Web.Ashx
//{
//    /// <summary>
//    /// OrdersHandler 的摘要说明
//    /// </summary>
//    public class OrdersHandler : BaseHttpHandler
//    {
//        #region ===================初始加载=====================
//        OrderParm parm = null;
//        PartnerTransDetailParm pparm = null;
//        public override void ProcessRequest(HttpContext context)
//        {
//            base.ProcessRequest(context);
//            string method = Request["Method"] ?? "";

//            if (!string.IsNullOrEmpty(method))
//            {
//                parm = new OrderParm(context);
//                pparm = new PartnerTransDetailParm(context);
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
//        public void SearchBatchNumOrders()
//        {
//            Database db = new Database("BE_OrderDetail_Proc", "BatchNumOrders", 0, 0, "", "", "");
//            DataTable dt = db.ExecuteDataTable();
//            Response.Write(JSONHelper.DataTableToJSON(dt));

//        }
//        public void SearchBatchNumOrdersDetail()
//        {
//            if (string.IsNullOrEmpty(Request["BatchNum"]))
//            {
//                throw new Exception("批次BatchNum参数ID无效。");
//            }
//            Database db = new Database("BE_OrderDetail_Proc", "GetDetailsByBatchNum", 0, 0, Request["BatchNum"], "", "");
//            DataTable dt = db.ExecuteDataTable();
//            Response.Write(JSONHelper.DataTableToJSON(dt));

//        }
//        public void SearchOrders()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderArgs args = new SearchOrderArgs();

//                    args.OrderBy = "Created desc";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;

//                    if (!string.IsNullOrEmpty(Request["OrderIDs"]))
//                    {
//                        args.OrderIDs = new List<Guid>();
//                        foreach (string id in Request["OrderIDs"].ToString().Split(',').ToList())
//                        {
//                            args.OrderIDs.Add(new Guid(id));
//                        }
//                    }
//                    if (!string.IsNullOrEmpty(parm.Status) && Request["Status"] != "全部")
//                    {
//                        args.Status = parm.Status.Split(',').ToList();
//                    }
//                    if (!string.IsNullOrEmpty(parm.OrderType) && Request["OrderType"] != "全部")
//                    {
//                        args.OrderTypes = parm.OrderType.Split(',').ToList();
//                    }
//                    if (!string.IsNullOrEmpty(parm.OrderNo))
//                    {
//                        args.OrderNo = parm.OrderNo;
//                    }
//                    if (!string.IsNullOrEmpty(parm.PurchaseNo))
//                    {
//                        args.PurchaseNo = parm.PurchaseNo;
//                    }

//                    if (!string.IsNullOrEmpty(parm.BattchNum))
//                    {
//                        args.BattchNo = parm.BattchNum;
//                    }

//                    if (!string.IsNullOrEmpty(parm.OutOrderNo))
//                    {
//                        args.OutOrderNo = parm.OutOrderNo;
//                    }
//                    if (!string.IsNullOrEmpty(parm.Mobile))
//                    {
//                        args.Mobile = parm.Mobile;
//                    }
//                    if (!string.IsNullOrEmpty(parm.CabinetType) && Request["CabinetType"] != "请选择")
//                    {
//                        args.CabinetType = parm.CabinetType;
//                    }
//                    if (!string.IsNullOrEmpty(parm.BattchNum))
//                    {
//                        args.BattchNo = parm.BattchNum;
//                    }
//                    if (!string.IsNullOrEmpty(parm.Address))
//                    {
//                        args.Address = parm.Address;
//                    }
//                    if (!string.IsNullOrEmpty(parm.CustomerName))
//                    {
//                        args.CustomerName = parm.CustomerName;
//                    }
//                    if (!string.IsNullOrEmpty(Request["BookingDateFrom"]))
//                    {
//                        args.BookingDateFrom = parm.BookingDateFrom;
//                    }
//                    if (!string.IsNullOrEmpty(Request["BookingDateTo"]))
//                    {
//                        args.BookingDateTo = parm.BookingDateTo.AddDays(1);
//                    }
//                    if (!string.IsNullOrEmpty(Request["ShipDateFrom"]))
//                    {
//                        args.ShipDateFrom = parm.ShipDateFrom;
//                    }
//                    if (!string.IsNullOrEmpty(Request["ShipDateTo"]))
//                    {
//                        args.ShipDateTo = parm.ShipDateTo.AddDays(1);
//                    }

//                    if (Request["Review"] != null && Request["Review"].ToString().ToLower() == "true")
//                    {
//                        args.Resource = CurrentUser.UserCode;
//                    }
//                    //经销商订单的过滤条件
//                    if (CurrentUser.UserType == (int)UserType.D)
//                    {
//                        args.PartnerID = CurrentUser.PartnerID;
//                    }

//                    //Where
//                    SearchResult sr = p.Client.SearchOrder(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        public void SearchIsExistOrder()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    if (string.IsNullOrEmpty(parm.OrderNo))
//                    {
//                        throw new Exception("订单编码无效。");
//                    }
//                    var orderInfo = p.Client.GetOrderByOrderNo(SenderUser, parm.OrderNo);
//                    if (orderInfo != null)
//                    {
//                        Response.Write(JSONHelper.Object2Json(new { OrderNo = parm.OrderNo }));
//                    }
//                    else
//                    {
//                        Response.Write(JSONHelper.Object2Json(new { OrderNo = string.Empty }));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 监控面板（订单生产状态）
//        /// </summary>
//        public void GetOrdermonitorByWorkFlow()
//        {
//            try
//            {
//                string OrderID = Request["OrderID"];
//                if (string.IsNullOrEmpty(OrderID))
//                {
//                    throw new Exception("订单ID参数无效。");
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    //List<Order2Cabinet> CabinetList = p.Client.GetOrder2CabinetByOrderID(SenderUser, new Guid(OrderID));//产品
//                    //if (CabinetList == null || CabinetList.Count < 1)
//                    //{
//                    //    throw new Exception("订单下无产品。");
//                    //}
//                    List<WorkFlow> WorkFlowList = p.Client.GetWorkFlowByOrderID(SenderUser, new Guid(OrderID));//工序
//                    if (WorkFlowList == null || WorkFlowList.Count < 1)
//                    {
//                        throw new Exception("订单尚未排产到工序。");
//                    }
//                    List<OrderScheduling> OrderSchedulingList = p.Client.GetOrderSchedulingByOrderID(SenderUser, new Guid(OrderID));//排产时间

//                    List<OrderWorkFlow> OrderWorkFlowList = p.Client.GetOrderWorkFlowByOrderID(SenderUser, new Guid(OrderID));//流程

//                    List<OrderWorkFlow> ResurtList = GetBaseCabinetWorkFlow(OrderWorkFlowList);

//                    int TotalCabinetQty = p.Client.GetOrderDetails(SenderUser, new Guid(OrderID)).Count;

//                    StringBuilder jsonBuilder = new StringBuilder();
//                    jsonBuilder.Append("{ ");
//                    jsonBuilder.Append(" \"rows\": [");
//                    for (int i = 0; i < WorkFlowList.Count; i++)
//                    {
//                        WorkFlow Model = WorkFlowList[i];
//                        List<OrderWorkFlow> List = OrderWorkFlowList.Where(t => t.SourceWorkFlowID == Model.WorkFlowID).ToList();
//                        OrderScheduling OrderScheduling = OrderSchedulingList.Find(x => x.WorkFlowID == Model.WorkFlowID);
//                        int MadeQty = 0;

//                        foreach (OrderWorkFlow Item in ResurtList)
//                        {
//                            if (Item.SourceWorkFlowID == Model.WorkFlowID)
//                                MadeQty++;
//                        }
//                        string MadeStarted = OrderScheduling.MadeStarted.ToString("yyyy-MM-dd");
//                        string MadeEnded = OrderScheduling.MadeEnded.ToString("yyyy-MM-dd");
//                        //List<Guid> CabinetID = OrderWorkFlowList.Where(t => t.MadeQty == 0).OrderBy(t => t.WorkFlowNo);
//                        jsonBuilder.Append("{");
//                        jsonBuilder.AppendFormat("\"WorkFlowID\":\"{0}\",", Model.WorkFlowID);
//                        jsonBuilder.AppendFormat("\"ImageUrl\": \"{0}\",", Model.ImageUrl);
//                        jsonBuilder.AppendFormat("\"WorkFlowName\":\"{0}\",", Model.WorkFlowName);
//                        jsonBuilder.AppendFormat("\"TotalQty\":{0},", List.Count);
//                        jsonBuilder.AppendFormat("\"TotalCabinetQty\":{0},", TotalCabinetQty);
//                        jsonBuilder.AppendFormat("\"Estimated\":\"{0}\",", List.Where(t => t.MadeQty > 0).Count());
//                        jsonBuilder.AppendFormat("\"MadeStarted\":\"{0}\",", MadeQty);
//                        jsonBuilder.AppendFormat("\"Started\":\"{0}\",", MadeStarted);
//                        jsonBuilder.AppendFormat("\"Ended\":\"{0}\" ", MadeEnded);
//                        //jsonBuilder.AppendFormat("\"CabinetName\":\"{0}\" ,", CabinetList.Where(t => t.CabinetID == 0).Count());
//                        jsonBuilder.Append("}");
//                        if (i < WorkFlowList.Count - 1)
//                        {
//                            jsonBuilder.Append(",");
//                        }
//                    }
//                    jsonBuilder.Append(" ]");
//                    jsonBuilder.Append(" }");
//                    Response.Write(jsonBuilder.ToString());
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex);
//            }
//        }
//        /// <summary>
//        /// 获取产品中最近一道工序
//        /// </summary>
//        /// <param name="List"></param>
//        /// <returns></returns>
//        private List<OrderWorkFlow> GetBaseCabinetWorkFlow(List<OrderWorkFlow> List)
//        {
//            List<OrderWorkFlow> ResurtList = new List<OrderWorkFlow>();
//            foreach (OrderWorkFlow Item in List)
//            {
//                List<OrderWorkFlow> CabinetList = List.Where(t => t.ItemID == Item.ItemID).OrderBy(t => t.WorkFlowNo).ToList();//先按产品筛选
//                var model = CabinetList.Where(t => t.MadeQty == 0).FirstOrDefault();//产品下最近的一条工序
//                if (model != null && !ResurtList.Contains(model))
//                {
//                    ResurtList.Add(model);
//                }
//            }
//            return ResurtList;
//        }
//        /// <summary>
//        /// 查询指定工序下产品记录
//        /// </summary>
//        public void GetCabinetsByOrderWorkFlow()
//        {
//            try
//            {
//                string OrderID = Request["OrderID"];
//                string WorkFlowID = Request["WorkFlowID"];
//                string MadeQty = Request["MadeQty"];
//                if (string.IsNullOrEmpty(OrderID) || string.IsNullOrEmpty(WorkFlowID) || string.IsNullOrEmpty(MadeQty))
//                {
//                    Response.Write("{\"total\":0,\"rows\":[]}");
//                }
//                else
//                {
//                    using (ProxyBE p = new ProxyBE())
//                    {
//                        List<OrderDetail> Cabinetlists = new List<OrderDetail>();

//                        //工序下产品
//                        List<OrderDetail> lists = p.Client.GetOrderDetailsByWorkFlowID(new Guid(OrderID), new Guid(WorkFlowID), int.Parse(MadeQty));
//                        //lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));

//                        if (int.Parse(MadeQty) == 0)//待生产
//                        {
//                            List<OrderWorkFlow> OrderWorkFlowList = p.Client.GetOrderWorkFlowByOrderID(SenderUser, new Guid(OrderID));

//                            //当前工序是第几个步骤
//                            int WorkFlowNo = OrderWorkFlowList.Where(t => t.SourceWorkFlowID == new Guid(WorkFlowID)).FirstOrDefault().WorkFlowNo;

//                            //若该产品在上一工序还未完成，则不在当前工序显示
//                            foreach (OrderDetail Item in lists)
//                            {
//                                List<OrderWorkFlow> FlowList = OrderWorkFlowList.Where(t => t.ItemID == Item.ItemID && t.MadeQty == int.Parse(MadeQty) && t.WorkFlowNo < WorkFlowNo).ToList();
//                                if (FlowList == null || FlowList.Count < 1)
//                                {
//                                    Cabinetlists.Add(Item);
//                                }
//                            }
//                        }
//                        else//已生产
//                        {
//                            List<OrderMadeState> MadeStatesList = p.Client.GetOrderMadeStates(SenderUser, new Guid(OrderID));
//                            foreach (OrderDetail Item in lists)
//                            {
//                                OrderMadeState Model = MadeStatesList.Count > 0 ? MadeStatesList.Where(t => t.ItemID == Item.ItemID).FirstOrDefault() : null;
//                                Item.Created = Model == null ? DateTime.Parse("1990-01-01") : Model.Processed;
//                                Item.CreatedBy = Model == null ? "" : Model.ProcessedBy;
//                                Cabinetlists.Add(Item);
//                            }
//                        }

//                        string json = JSONHelper.List2DataSetJson(Cabinetlists);
//                        Response.Write(json);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        public void SearchOrderDetail()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["OrderID"]))
//                {
//                    throw new Exception("订单ID参数无效。");
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderDetailArgs args = new SearchOrderDetailArgs();
//                    args.OrderBy = "[OrderID],[CabinetID],[BarcodeNo]";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    args.OrderIDs = new List<Guid>() { new Guid(Request["OrderID"]) };
//                    if (!string.IsNullOrEmpty(Request["CabinetNum"]))
//                    {
//                        args.CabinetNums = new List<string>();
//                        args.CabinetNums.Add(Request["CabinetNum"]);
//                    }

//                    if (!string.IsNullOrEmpty(parm.OrderNo))
//                    {
//                        args.OrderNo = parm.OrderNo;
//                    }
//                    if (!string.IsNullOrEmpty(parm.OutOrderNo))
//                    {
//                        args.OutOrderNo = parm.OutOrderNo;
//                    }
//                    if (!string.IsNullOrEmpty(parm.BattchNum))
//                    {
//                        args.BattchNum = parm.BattchNum;
//                    }
//                    if (!string.IsNullOrEmpty(Request["BarcodeNo"]))
//                    {
//                        args.Barcode = Request["BarcodeNo"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetCode"]))
//                    {
//                        args.CabinetCode = Request["CabinetCode"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetID"]))
//                    {
//                        args.CabinetIDs = new List<Guid>() { new Guid(Request["CabinetID"]) };
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsOutsourcing"]))
//                    {
//                        args.IsOutsourcing = bool.Parse(Request["IsOutsourcing"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsStandard"]))
//                    {
//                        args.IsStandard = bool.Parse(Request["IsStandard"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["ItemCategory"]))
//                    {
//                        args.ItemCategory = Request["ItemCategory"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["ItemName"]))
//                    {
//                        //args.ItemName = Request["ItemName"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["ItemType"]))
//                    {
//                        args.ItemType = Request["ItemType"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["MaterialType"]))
//                    {
//                        args.MaterialType = Request["MaterialType"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["PackageCategory"]))
//                    {
//                        args.PackageCategory = Request["PackageCategory"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["PackageSizeType"]))
//                    {
//                        args.PackageSizeType = Request["PackageSizeType"];
//                    }

//                    SearchResult sr = p.Client.SearchOrderDetail(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex);
//                //WriteError(ex.Message, ex);
//            }
//        }
//        public void SearchOrderProcessFiles()
//        {
//            try
//            {
//                string FileType = Request["FileType"];
//                using (ProxyBE p = new ProxyBE())
//                {
//                    //List<OrderProcessFile> files = p.Client.GetOrderProcessFilesByOrderID_FileType(SenderUser, parm.OrderID, FileType);
//                    SearchOrderProcessFileArgs args = new SearchOrderProcessFileArgs();
//                    args.OrderBy = "[FileType]";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    args.OrderID = parm.OrderID;
//                    if (!string.IsNullOrEmpty(FileType))
//                    {
//                        args.FileType = FileType.Split(',').ToList();
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetID"]))
//                    {
//                        args.CabinetID = new Guid(Request["CabinetID"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetName"]))
//                    {
//                        args.CabinetName = Request["CabinetName"];
//                    }
//                    SearchResult sr = p.Client.SearchOrderProcessFile(SenderUser, args);
//                    string json = JSONHelper.Dataset2Json(sr.DataSet);

//                    Response.Write(json);
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        public void SearchOrder2Hardwares()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["OrderID"]))
//                {
//                    throw new Exception("订单ID参数无效。");
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrder2HardwareArgs args = new SearchOrder2HardwareArgs();
//                    args.OrderBy = "[OrderID],[BarcodeNo]";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    args.OrderID = new Guid(Request["OrderID"]);
//                    if (!string.IsNullOrEmpty(Request["CabinetName"]))
//                    {
//                        args.CabinetName = Request["CabinetName"];
//                    }
//                    SearchResult sr = p.Client.SearchOrder2Hardware(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        public void SearchSpecialCompanent2WorkFlows()
//        {
//            try
//            {
//                Guid SpecialID = Guid.Empty;
//                if (!string.IsNullOrEmpty(Request["SpecialID"]))
//                {
//                    SpecialID = new Guid(Request["SpecialID"]);
//                }
//                else
//                {
//                    throw new Exception("参数值SpecialID不能为空。");
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchSpecialCompanent2WorkFlowArgs args = new SearchSpecialCompanent2WorkFlowArgs();
//                    args.OrderBy = "[Sequence] ASC";
//                    args.SpecialID = SpecialID;
//                    SearchResult sr = p.Client.SearchSpecialCompanent2WorkFlow(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        public void SaveSpecialCompanent2WorkFlows()
//        {
//            try
//            {
//                Guid SpecialID = new Guid(Request["SpecialID"]);
//                string ItemName = Request["ItemName"].ToString();
//                bool IsDisabled = Request["IsDisabled"] == null ? false : bool.Parse(Request["IsDisabled"]);

//                using (ProxyBE p = new ProxyBE())
//                {
//                    SpecialCompanent scObj = p.Client.GetSpecialCompanent(SenderUser, SpecialID);
//                    if (scObj == null)
//                    {
//                        scObj = new SpecialCompanent();
//                    }
//                    scObj.SpecialID = SpecialID;
//                    scObj.ItemName = ItemName;
//                    scObj.IsDisabled = IsDisabled;

//                    List<SpecialCompanent2WorkFlow> lists_wfs = new List<SpecialCompanent2WorkFlow>();
//                    string wfs = Request["WorkFlows"];
//                    JsonData sj = JsonMapper.ToObject(wfs);
//                    if (sj.Count > 0)
//                    {
//                        //遍历对象元素，保存                        
//                        foreach (JsonData item in sj)
//                        {
//                            SpecialCompanent2WorkFlow swf = new SpecialCompanent2WorkFlow();
//                            swf.SpecialDetailID = Guid.Parse(item["SpecialDetailID"].ToString());
//                            swf.SpecialID = Guid.Parse(item["SpecialID"].ToString());
//                            swf.WorkFlowID = Guid.Parse(item["WorkFlowID"].ToString());
//                            swf.Sequence = int.Parse(item["Sequence"].ToString());
//                            lists_wfs.Add(swf);
//                        }
//                    }
//                    SaveSpecialCompanentArgs args = new SaveSpecialCompanentArgs();
//                    args.SpecialCompanent = scObj;
//                    args.SpecialCompanent2WorkFlows = lists_wfs;
//                    p.Client.SaveSpecialCompanent(SenderUser, args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                WriteError(ex.Message, ex);
//            }
//        }
//        public void SearchOrderMadeState()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderMadeStateArgs args = new SearchOrderMadeStateArgs();
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;

//                    if (!string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        args.OrderID = new Guid(Request["OrderID"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetID"]))
//                    {
//                        args.CabinetID = new Guid(Request["CabinetID"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["WorkFlowID"]))
//                    {
//                        args.WorkFlowID = new Guid(Request["WorkFlowID"]);
//                    }

//                    if (!args.OrderID.HasValue || !args.CabinetID.HasValue || !args.WorkFlowID.HasValue)
//                    {
//                        Response.Write(JSONHelper.Dataset2Json(null));
//                    }
//                    else
//                    {
//                        SearchResult sr = p.Client.SearchOrderMadeSate(SenderUser, args);
//                        Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        public void SearchOrderWorkFlow()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderWorkFlowArgs args = new SearchOrderWorkFlowArgs();
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    if (!string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        args.OrderID = new Guid(Request["OrderID"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetID"]))
//                    {
//                        args.CabinetID = new Guid(Request["CabinetID"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["WorkFlowID"]))
//                    {
//                        args.WorkFlowID = new Guid(Request["WorkFlowID"]);
//                    }
//                    args.ScanFlag = false;
//                    SearchResult sr = p.Client.SearchAllOrderWorkflow(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 打印条码
//        /// </summary>
//        public void SearchPrintListByOrderWorkFlow()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderWorkFlowArgs args = new SearchOrderWorkFlowArgs();
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    args.CompanyID = CurrentUser.CompanyID;
//                    if (!string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        args.OrderID = new Guid(Request["OrderID"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["PrintCount"]))
//                    {
//                        args.PrintCount = Request["PrintCount"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["OrderNo"]))
//                    {
//                        args.OrderNo = Request["OrderNo"];
//                    }
//                    string RolesTemp = "";
//                    foreach (var item in PageBase.CurrentUser.Roles)
//                        RolesTemp += "|" + item.RoleName;
//                    args.RolesTemp = RolesTemp;
//                    SearchResult sr = p.Client.SearchPrintListByOrderWorkFlow(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 工位扫描
//        /// </summary>
//        public void SearchScanListByOrderWorkFlow()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderWorkFlowArgs args = new SearchOrderWorkFlowArgs();
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    args.CompanyID = CurrentUser.CompanyID;
//                    if (!string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        args.OrderID = new Guid(Request["OrderID"]);
//                    }
//                    else
//                    {
//                        Response.Write(JSONHelper.Dataset2Json(null));
//                        return;
//                    }
//                    if (!string.IsNullOrEmpty(Request["MadeQty"]))
//                    {
//                        args.MadeQty = Request["MadeQty"];
//                    }

//                    string RolesTemp = string.Empty;
//                    foreach (var item in PageBase.CurrentUser.Roles)
//                        RolesTemp += "|" + item.RoleName;
//                    args.RolesTemp = RolesTemp;
//                    SearchResult sr = p.Client.SearchScanListByOrderWorkFlow(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        public void SearchOrdersPackage()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchPackageDetailArgs args = new SearchPackageDetailArgs();

//                    args.OrderBy = "[OrderNo],[BarcodeNo]";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;

//                    if (!string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        args.OrderID = new Guid(Request["OrderID"].ToString());
//                    }
//                    if (!string.IsNullOrEmpty(parm.OrderNo))
//                    {
//                        args.OrderNo = parm.OrderNo;
//                    }
//                    if (!string.IsNullOrEmpty(parm.BattchNum))
//                    {
//                        args.BattchNo = parm.BattchNum;
//                    }
//                    if (!string.IsNullOrEmpty(parm.CustomerName))
//                    {
//                        args.CustomerName = parm.CustomerName;
//                    }
//                    if (!string.IsNullOrEmpty(Request["BarcodeNo"]))
//                    {
//                        args.Barcode = Request["BarcodeNo"].ToString();
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetID"]))
//                    {
//                        args.CabinetID = new Guid(Request["CabinetID"].ToString());
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetName"]))
//                    {
//                        args.CabinetName = Request["CabinetName"].ToString();
//                    }
//                    if (!string.IsNullOrEmpty(Request["CustomerID"]))
//                    {
//                        args.CustomerID = new Guid(Request["CustomerID"].ToString());
//                    }
//                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
//                    {
//                        args.CustomerName = Request["CustomerName"].ToString();
//                    }
//                    if (!string.IsNullOrEmpty(Request["PackageBarcode"]))
//                    {
//                        args.PackageBarcode = Request["PackageBarcode"].ToString();
//                    }
//                    if (!string.IsNullOrEmpty(Request["PackageNum"]))
//                    {
//                        args.PackageNum = int.Parse(Request["PackageNum"].ToString());
//                    }

//                    if (!string.IsNullOrEmpty(Request["OutOrderNo"]))
//                    {
//                        args.OutOrderNo = Request["OutOrderNo"].ToString();
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsOutsourcing"]))
//                    {
//                        args.IsOutsourcing = bool.Parse(Request["IsOutsourcing"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsStandard"]))
//                    {
//                        args.IsStandard = bool.Parse(Request["IsStandard"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsDisabled"]))
//                    {
//                        args.IsDisabled = bool.Parse(Request["IsDisabled"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsPakaged"]))
//                    {
//                        //args.IsPakaged = bool.Parse(Request["IsPakaged"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsPlanning"]))
//                    {
//                        args.IsPlanning = bool.Parse(Request["IsPlanning"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["IsOptimized"]))
//                    {
//                        args.IsOptimized = bool.Parse(Request["IsOptimized"]);
//                    }
//                    if (!string.IsNullOrEmpty(Request["ItemCategory"]))
//                    {
//                        args.ItemCategory = Request["ItemCategory"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetCode"]))
//                    {
//                        args.CabinetCode = Request["CabinetCode"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["ItemName"]))
//                    {
//                        args.ItemName = Request["ItemName"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["ItemType"]))
//                    {
//                        args.ItemType = Request["ItemType"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["PackageCategory"]))
//                    {
//                        args.PackageCategory = Request["PackageCategory"];
//                    }
//                    if (!string.IsNullOrEmpty(Request["PackageSizeType"]))
//                    {
//                        args.PackageSizeType = Request["PackageSizeType"];
//                    }
//                    //Where
//                    SearchResult sr = p.Client.SearchPackageDetail(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        public void SearchOrders2Package()
//        {

//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchPackageArgs args = new SearchPackageArgs();

//                    args.OrderBy = "PackageBarcode";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;

//                    if (!string.IsNullOrEmpty(Request["CustomerName"]))
//                    {
//                        args.CustomerName = Request["CustomerName"].ToString();
//                    }
//                    if (!string.IsNullOrEmpty(Request["PackageBarcode"]))
//                    {
//                        args.PackageBarcode = Request["PackageBarcode"].ToString();
//                    }
//                    if (!string.IsNullOrEmpty(Request["CabinetName"]))
//                    {
//                        args.CabinetName = Request["CabinetName"].ToString();
//                    }
//                    //Where
//                    SearchResult sr = p.Client.SearchPackage(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }

//            }
//            catch (Exception)
//            {

//                throw;
//            }


//        }

//        #region  板件扫描|返工 （优化版,支持按产品备料勾选）（刘胜伟）
//        /// <summary>
//        /// 板件扫描
//        /// </summary>
//        public void AutoScanByBarcode()
//        {
//            Hashtable table = new Hashtable();
//            try
//            {
//                string SearchKey = Request["Barcode"];
//                if (string.IsNullOrEmpty(SearchKey))
//                {
//                    table.Add("isOk", 0);
//                    table.Add("message", "扫描失败，参数错误！");
//                    table.Add("OrderID", string.Empty);
//                    Response.Write(JSONHelper.ToJson(table));
//                    return;
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    //排除不必要的权限
//                    List<WorkFlow> WorkFlows = p.Client.GetAllWorkFlows(SenderUser);
//                    List<string> roles = new List<string>();
//                    foreach (var item in PageBase.CurrentUser.Roles)
//                    {
//                        if (WorkFlows.Where(t => t.WorkFlowName == item.RoleName).ToList().Count > 0)
//                        {
//                            roles.Add(item.RoleName);
//                        }
//                    }

//                    //订单下所有生产数据（支持多条件查询）
//                    List<OrderWorkFlow> OrderWorkFlows = p.Client.GetOrderWorkFlowsBySearchKey(SenderUser, SearchKey);

//                    //有两个或以上产品（针对按订单号搜索时）
//                    var GroupList = OrderWorkFlows.Where(t => t.MadeQty == 0).GroupBy(t => t.ItemID).ToList();
//                    if (GroupList.Count > 1)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "请勾选待扫描产品！");
//                        table.Add("OrderID", OrderWorkFlows.FirstOrDefault().OrderID);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }

//                    //订单下仅有权限查看的生产数据(多权限有多条)
//                    List<OrderWorkFlow> list = OrderWorkFlows.Where(t => roles.Contains(t.Action)).OrderBy(t => t.WorkFlowNo).ToList();
//                    if (list == null || list.Count < 1)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "订单或产品码不存在！");
//                        table.Add("OrderID", string.Empty);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }

//                    //获取最近一道未完成工序
//                    OrderWorkFlow scanModel = list.Where(t => t.MadeQty == 0).FirstOrDefault();
//                    if (scanModel == null)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "产品已扫描不能重复！");
//                        table.Add("OrderID", OrderWorkFlows.FirstOrDefault().OrderID);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }
//                    //前面工位是否有未扫描产品
//                    if (OrderWorkFlows.Where(t => t.WorkFlowNo < scanModel.WorkFlowNo && t.MadeQty == 0 && t.ItemID == scanModel.ItemID).ToList().Count > 0)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "跨工位扫描失败！");
//                        table.Add("OrderID", OrderWorkFlows.FirstOrDefault().OrderID);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }

//                    //开始工位扫描
//                    p.Client.ScanBarcode(SenderUser, SearchKey, new Guid("D02D2890-259B-4869-9520-B65F042AB979"), scanModel.SourceWorkFlowID);

//                    //如果订单下所有产品已完成
//                    string OrderStatus = string.Empty;
//                    List<OrderWorkFlow> statusList = p.Client.GetOrderWorkFlowByOrderID(SenderUser, scanModel.OrderID).Where(t => t.MadeQty == 0).ToList();
//                    if (statusList.Where(t => t.WorkFlowNo <= 9).ToList().Count < 1)
//                    {
//                        OrderStatus = "F";//已发货
//                    }
//                    else if (statusList.Where(t => t.WorkFlowNo <= 8).ToList().Count < 1)
//                    {
//                        OrderStatus = "R";//已入库
//                    }
//                    else if (statusList.Where(t => t.WorkFlowNo <= 7).ToList().Count < 1)
//                    {
//                        OrderStatus = "I";//已包装
//                    }
//                    if (!string.IsNullOrEmpty(OrderStatus))
//                    {
//                        p.Client.UpdateOrderStatusByOrderIDs(SenderUser, new List<Guid>() { scanModel.OrderID }, OrderStatus, scanModel.ItemID);
//                    }

//                    table.Add("isOk", 1);
//                    table.Add("ItemID", scanModel.ItemID);
//                    table.Add("WorkFlowNo", scanModel.WorkFlowNo);
//                    table.Add("OrderID", scanModel.OrderID);
//                    table.Add("message", string.Format("{0}【{1}】扫描成功！", p.Client.GetOrderDetail(SenderUser, scanModel.ItemID).ItemName, scanModel.Action));
//                }
//            }
//            catch (Exception ex)
//            {
//                table.Add("isOk", 0);
//                table.Add("message", ex.ToString());
//            }
//            Response.Write(JSONHelper.ToJson(table));
//        }
//        /// <summary>
//        /// 板件返工
//        /// </summary>
//        public void ReworkScanByBarcode()
//        {
//            Hashtable table = new Hashtable();
//            try
//            {
//                string SearchKey = Request["Barcode"];
//                if (string.IsNullOrEmpty(SearchKey))
//                {
//                    table.Add("isOk", 0);
//                    table.Add("message", "扫描失败，参数错误！");
//                    table.Add("OrderID", string.Empty);
//                    Response.Write(JSONHelper.ToJson(table));
//                    return;
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    //排除不必要的权限
//                    List<WorkFlow> WorkFlows = p.Client.GetAllWorkFlows(SenderUser);
//                    List<string> roles = new List<string>();
//                    foreach (var item in PageBase.CurrentUser.Roles)
//                    {
//                        if (WorkFlows.Where(t => t.WorkFlowName == item.RoleName).ToList().Count > 0)
//                        {
//                            roles.Add(item.RoleName);
//                        }
//                    }

//                    //订单下所有生产数据（支持多条件查询）
//                    List<OrderWorkFlow> OrderWorkFlows = p.Client.GetOrderWorkFlowsBySearchKey(SenderUser, SearchKey);

//                    //有两个或以上产品（针对按订单号搜索时）
//                    var GroupList = OrderWorkFlows.GroupBy(t => t.ItemID).ToList();
//                    if (GroupList.Count > 1)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "请勾选要返工的产品！");
//                        table.Add("OrderID", OrderWorkFlows.FirstOrDefault().OrderID);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }
//                    if (OrderWorkFlows.Count < 1)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "订单或产品码不存在！");
//                        table.Add("OrderID", string.Empty);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }
//                    if (OrderWorkFlows.Where(t => t.MadeQty == 0).ToList().Count >= 9)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "产品尚未扫描，不能返工！");
//                        table.Add("OrderID", OrderWorkFlows.FirstOrDefault().OrderID);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }
//                    //最近一道已完成工序
//                    OrderWorkFlow scanModel = OrderWorkFlows.Where(t => t.MadeQty == 1).OrderByDescending(t => t.WorkFlowNo).FirstOrDefault();
//                    if (scanModel == null)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", "产品已返工不能重复！");
//                        table.Add("OrderID", OrderWorkFlows.FirstOrDefault().OrderID);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }
//                    if (scanModel.WorkFlowNo >= 8)
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", string.Format("产品已【{0}】不能再返工！", scanModel.Action));
//                        table.Add("OrderID", OrderWorkFlows.FirstOrDefault().OrderID);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }
//                    //下一级工序（自己不能给自己返工，因为扫描成功后产品已流入下一工序，需下一工序给上一工序返工）
//                    OrderWorkFlow NextscanModel = OrderWorkFlows.Where(t => t.MadeQty == 0 && t.ItemID == scanModel.ItemID).OrderBy(t => t.WorkFlowNo).FirstOrDefault();
//                    if (!roles.Contains(NextscanModel.Action))
//                    {
//                        table.Add("isOk", 0);
//                        table.Add("message", string.Format("请从【{0}】工序返工！", NextscanModel.Action));
//                        table.Add("OrderID", string.Empty);
//                        Response.Write(JSONHelper.ToJson(table));
//                        return;
//                    }

//                    //开始返工
//                    p.Client.ReworkScanBarcode(SenderUser, SearchKey, new Guid("D02D2890-259B-4869-9520-B65F042AB979"), scanModel.SourceWorkFlowID);

//                    //如果订单下所有产品已完成
//                    string OrderStatus = string.Empty;
//                    List<OrderWorkFlow> statusList = p.Client.GetOrderWorkFlowByOrderID(SenderUser, scanModel.OrderID).Where(t => t.MadeQty == 0).ToList();

//                    if (statusList.Where(t => t.WorkFlowNo <= 6).ToList().Count > 0)
//                    {
//                        OrderStatus = "P";//生产中
//                    }
//                    else if (statusList.Where(t => t.WorkFlowNo == 7).ToList().Count > 0)
//                    {
//                        OrderStatus = "I";//已包装
//                    }
//                    else if (statusList.Where(t => t.WorkFlowNo == 8).ToList().Count > 0)
//                    {
//                        OrderStatus = "R";//已入库
//                    }
//                    if (!string.IsNullOrEmpty(OrderStatus))
//                    {
//                        p.Client.UpdateOrderStatusByOrderIDs(SenderUser, new List<Guid>() { scanModel.OrderID }, OrderStatus, scanModel.ItemID);
//                    }

//                    table.Add("isOk", 1);
//                    table.Add("ItemID", scanModel.ItemID);
//                    table.Add("WorkFlowNo", scanModel.WorkFlowNo - 1);
//                    table.Add("OrderID", scanModel.OrderID);
//                    table.Add("message", string.Format("{0}【{1}】返工成功！", p.Client.GetOrderDetail(SenderUser, scanModel.ItemID).ItemName, scanModel.Action));
//                }
//            }
//            catch (Exception ex)
//            {
//                table.Add("isOk", 0);
//                table.Add("message", ex.ToString());
//            }
//            Response.Write(JSONHelper.ToJson(table));
//        }
//        /// <summary>
//        /// 进度跟踪
//        /// </summary>
//        public void GetOrderWorkFlowsByProcessed()
//        {
//            using (ProxyBE p = new ProxyBE())
//            {
//                string ItemID = Request["ItemID"], json = string.Empty;
//                if (!string.IsNullOrEmpty(ItemID))
//                {
//                    List<OrderWorkFlow> lists = p.Client.GetOrderWorkFlowsByProcessed(SenderUser, new Guid(ItemID));
//                    json = JSONHelper.List2DataSetJson(lists);
//                }
//                else
//                {
//                    List<WorkFlow> lists = p.Client.GetAllWorkFlows(SenderUser).OrderBy(t => t.Sequence).ToList();
//                    json = JSONHelper.List2DataSetJson(lists);
//                }
//                Response.Write(json);
//            }
//        }
//        #endregion

//        // 排产计划       
//        public void SearchOrderScheduling()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderSchedulingArgs args = new SearchOrderSchedulingArgs();
//                    args.OrderBy = "[Sequence] asc";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    args.OrderID = new Guid(Request["orderid"].ToString());

//                    SearchResult sr = p.Client.SearchOrderScheduling(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        //查找确认支付订单
//        public void GetPaymentOrders()
//        {
//            try
//            {

//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex.Message);
//            }
//        }
//        public void GetOrder()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["OrderID"]))
//                {
//                    throw new Exception("订单ID参数无效。");
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    Guid OrderID = new Guid(Request["OrderID"]);
//                    var orderInfo = p.Client.GetOrder(SenderUser, OrderID);
//                    Response.Write(JSONHelper.Object2Json(orderInfo));
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        //获取订单板件明细
//        public void GetCabinets()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["OrderID"]))
//                {
//                    Response.Write("{\"total\":0,\"rows\":[]}");
//                }
//                else
//                {
//                    using (ProxyBE p = new ProxyBE())
//                    {
//                        Guid OrderID = new Guid();
//                        if (!string.IsNullOrEmpty(Request["OrderNo"]))//按OrderNo查询
//                        {
//                            Order model = p.Client.GetOrderByOrderNo(SenderUser, Request["OrderNo"]);
//                            if (model == null)
//                            {
//                                Response.Write("{\"total\":0,\"rows\":[]}");
//                                return;
//                            }
//                            OrderID = model.OrderID;
//                        }
//                        else
//                        {
//                            OrderID = new Guid(Request["OrderID"]);//默认按OrderID查询
//                        }
//                        List<Order2Cabinet> lists = p.Client.GetOrder2CabinetByOrderID(SenderUser, OrderID);
//                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
//                        string json = JSONHelper.List2DataSetJson(lists);

//                        Response.Write(json);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        //产品名称
//        public void GetCabinetName2Doors()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["OrderID"]))
//                {
//                    throw new Exception("无效订单ID");

//                }
//                else
//                {
//                    using (ProxyBE p = new ProxyBE())
//                    {
//                        Guid OrderID = new Guid(Request["OrderID"]);
//                        List<Order2Cabinet> lists = p.Client.GetOrder2CabinetByOrderID(SenderUser, OrderID);
//                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
//                        Response.Write(JSONHelper.Object2JSON(lists));
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        // 新增订单：保存
//        public void SaveOrder()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    #region Order
//                    var flag = "false";
//                    Order order = p.Client.GetOrder(SenderUser, parm.OrderID);
//                    if (parm.OrderType == "")
//                    {
//                        throw new Exception("请选择订单类型");
//                    }
//                    if (order == null)
//                    {
//                        order = new Order();
//                        order.OrderID = parm.OrderID;
//                    }
//                    if (parm.CabinetType == "请选择")
//                    {
//                        throw new Exception("请选择产品类型");
//                    }

//                    //修改订单保存
//                    flag = Request["edit"];
//                    if (flag == "true")
//                    {
//                        order.OrderNo = parm.OrderNo;
//                        order.StepNo++;
//                    }
//                    else
//                    {
//                        order.OrderNo = "";
//                        order.StepNo = 2;
//                    }
//                    order.PartnerID = parm.PartnerID;
//                    order.CustomerID = parm.CustomerID;
//                    order.BattchNum = "";
//                    order.OutOrderNo = parm.OutOrderNo;
//                    order.Address = parm.Address;
//                    order.CustomerName = parm.CustomerName;
//                    order.BookingDate = parm.BookingDate;
//                    order.PurchaseNo = parm.PurchaseNo;
//                    order.Mobile = parm.Mobile;
//                    order.ShipDate = parm.ShipDate;
//                    order.OrderType = parm.OrderType;
//                    order.LinkMan = parm.LinkMan;
//                    order.Remark = parm.Remark;
//                    order.IsStandard = parm.IsStandard;
//                    order.IsOutsourcing = parm.IsOutsourcing;
//                    order.CabinetType = parm.CabinetType;
//                    order.Status = "Z";// 信息待确认
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;
//                    #endregion

//                    #region Order2Cabinet
//                    List<Order2Cabinet> Order2Cabinets = new List<Order2Cabinet>();
//                    string Cabinets = Request["Cabinets"];
//                    JsonData sj = JsonMapper.ToObject(Cabinets);
//                    if (sj.Count > 0)
//                    {
//                        //遍历对象元素，保存                        
//                        foreach (JsonData item in sj)
//                        {
//                            Order2Cabinet cabinet = new Order2Cabinet();
//                            cabinet.OrderID = order.OrderID;
//                            cabinet.CabinetID = Guid.Parse(item["CabinetID"].ToString());
//                            cabinet.CabinetName = item["CabinetName"].ToString();
//                            cabinet.Qty = Decimal.Parse(item["Qty"].ToString());
//                            cabinet.Price = Decimal.Parse(item["Price"].ToString());
//                            cabinet.Size = item["Size"].ToString();
//                            cabinet.MaterialStyle = item["MaterialStyle"].ToString();
//                            cabinet.Color = item["Color"].ToString();
//                            cabinet.MaterialCategory = item["MaterialCategory"].ToString();
//                            cabinet.Unit = item["Unit"].ToString();
//                            cabinet.Remark = item["Remark"].ToString();
//                            cabinet.DealerPrice = 0;
//                            cabinet.CostPrice = 0;
//                            cabinet.TotalAreal = 0;
//                            cabinet.TotalLength = 0;
//                            cabinet.FileUploadFlag = false;
//                            cabinet.CabinetStatus = "N";
//                            cabinet.Sequence = Order2Cabinets.Count + 1;
//                            cabinet.CabinetCode = ((char)(64 + cabinet.Sequence)).ToString();
//                            cabinet.BattchIndex = 0;
//                            if (flag == "true")
//                            {
//                                cabinet.Created = DateTime.Now;
//                                cabinet.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
//                            }
//                            Order2Cabinets.Add(cabinet);
//                        }
//                    }
//                    args.Order2Cabinets = Order2Cabinets;
//                    #endregion

//                    #region  OrderLog /OrderTask
//                    if (flag == "true")
//                    {
//                        OrderLog log = new OrderLog();
//                        log.OrderID = order.OrderID;
//                        log.LogID = Guid.NewGuid();
//                        log.LogType = "订单修改";
//                        log.Remark = "用户修改一条订单";
//                        args.OrderLog = log;

//                        OrderTask ot = new OrderTask();
//                        ot.Action = "订单修改";
//                        ot.CurrentStep = "订单修改";
//                        ot.ActionRemarksType = "订单修改";
//                        ot.ActionRemarks = "订单修改";
//                        ot.Resource = "";
//                        ot.NextResources = "订单确认组";
//                        ot.NextStep = "订单确认";
//                        args.OrderTask = ot;
//                    }
//                    else
//                    {
//                        OrderLog log = new OrderLog();
//                        log.OrderID = order.OrderID;
//                        log.LogID = Guid.NewGuid();
//                        log.LogType = "新增订单";
//                        log.Remark = "用户新增一条订单";
//                        args.OrderLog = log;

//                        OrderTask ot = new OrderTask();
//                        ot.Action = "新增订单";
//                        ot.CurrentStep = "新增订单";
//                        ot.ActionRemarksType = "新增订单";
//                        ot.ActionRemarks = "新增订单";
//                        ot.Resource = "";
//                        ot.NextResources = "订单确认组";
//                        ot.NextStep = "订单确认";
//                        args.OrderTask = ot;
//                    }
//                    #endregion

//                    #region OrderProcessFile
//                    string filePath = Config.StorageFolder;
//                    Partner partner = p.Client.GetPartner(SenderUser, order.PartnerID);
//                    string PartnerCode = partner.PartnerCode;
//                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyyMM"));
//                    filePath = Path.Combine(filePath, PartnerCode);
//                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyyMM"));
//                    filePath = Path.Combine(filePath, PartnerCode + "-" + DateTime.Now.ToString("yyyyMM"));
//                    if (!Directory.Exists(filePath))
//                    {
//                        Directory.CreateDirectory(filePath);
//                    }

//                    List<OrderProcessFile> ProcessFiles = new List<OrderProcessFile>();
//                    IList<HttpPostedFile> SceneFiles = Request.Files.GetMultiple("SceneFile");
//                    foreach (HttpPostedFile file in SceneFiles)
//                    {
//                        if (file.ContentLength == 0) continue;
//                        string savepath = Path.Combine(filePath, "SceneFile");
//                        if (!Directory.Exists(savepath))
//                        {
//                            Directory.CreateDirectory(savepath);
//                        }
//                        savepath = Path.Combine(savepath, file.FileName);
//                        if (File.Exists(savepath))
//                        {
//                            File.Delete(savepath);
//                        }
//                        file.SaveAs(savepath);
//                        OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "SceneFile", Path.GetFileName(savepath));
//                        if (pf == null)
//                        {
//                            pf = new OrderProcessFile();
//                            pf.OrderID = parm.OrderID;
//                            pf.FileID = Guid.NewGuid();
//                            pf.FileName = Path.GetFileName(savepath);
//                            pf.FilePath = savepath;
//                            pf.FileType = "SceneFile";
//                        }
//                        ProcessFiles.Add(pf);
//                    }


//                    if (ProcessFiles.Count > 0)
//                    {
//                        args.OrderProcessFiles = ProcessFiles;
//                    }
//                    #endregion

//                    p.Client.SaveOrder(SenderUser, args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        //补漏件
//        public void SaveOrderDetailsIsLeak()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    if (string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        throw new Exception("参数无效.");
//                    }
//                    if (string.IsNullOrEmpty(Request["CabinetID"]))
//                    {
//                        throw new Exception("参数无效.");
//                    }
//                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(Request["OrderID"].ToString()));
//                    Order2Cabinet cabinet = p.Client.GetOrder2Cabinet(SenderUser, Guid.Parse(Request["CabinetID"].ToString()));
//                    if (order == null)
//                    {
//                        throw new Exception("订单无效.");
//                    }
//                    if (cabinet == null)
//                    {
//                        throw new Exception("柜体无效.");
//                    }
//                    List<OrderDetail> orderDatail = p.Client.GetOrderDetails(SenderUser, order.OrderID);
//                    int Count = orderDatail.Count;
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    #region 板件
//                    List<OrderDetail> OrderDatails = new List<OrderDetail>();
//                    string Details = Server.UrlDecode(Request["OrderDetails"]);
//                    JsonData sj = JsonMapper.ToObject(Details);
//                    if (sj.Count > 0)
//                    {
//                        //遍历对象元素，保存  
//                        int i = 1;
//                        foreach (JsonData item in sj)
//                        {
//                            OrderDetail detail = new OrderDetail();
//                            detail.ItemID = Guid.NewGuid();
//                            detail.ItemName = Convert.ToString(item["ItemName"]);
//                            detail.ItemType = "";
//                            detail.MaterialType = Convert.ToString(item["MaterialType"]);
//                            detail.ItemGroup = Convert.ToString(item["ItemGroup"]);
//                            detail.PackageSizeType = "";
//                            detail.PackageCategory = "";
//                            detail.BarcodeNo = order.OrderNo + cabinet.Sequence + (Count + i).ToString("#000"); //板件条码  GetNumber("YMW")
//                            detail.OrderID = order.OrderID;
//                            detail.CabinetID = new Guid(Convert.ToString(item["CabinetID"]));
//                            detail.ItemIndex = 0;
//                            detail.TextureDirection = "";
//                            detail.HoleDesc = "";
//                            detail.MadeLength = Decimal.Parse(item["MadeLength"].ToString());
//                            detail.MadeWidth = Decimal.Parse(item["MadeWidth"].ToString());
//                            detail.MadeHeight = Decimal.Parse(item["MadeHeight"].ToString());
//                            detail.EndLength = Decimal.Zero;
//                            detail.EndWidth = Decimal.Zero;
//                            detail.Qty = Decimal.Parse(item["Qty"].ToString()); //补漏件                       
//                            detail.FrontLabel = "";
//                            detail.BackLabel = "";
//                            detail.Remarks = Convert.ToString(item["Remarks"]);//备注
//                            detail.Edge1 = "";
//                            detail.Edge2 = "";
//                            detail.Edge3 = "";
//                            detail.Edge4 = "";
//                            detail.EdgeDesc = "";
//                            detail.MadeBattchNum = "";
//                            detail.HasHole = false;
//                            detail.HoleFaceQty = 0;
//                            detail.Hole1Qty = 0;
//                            detail.Hole2Qty = 0;
//                            detail.Hole3Qty = 0;
//                            detail.Hole4Qty = 0;
//                            detail.Hole5Qty = 0;
//                            detail.Hole6Qty = 0;
//                            detail.HasSlot = false;
//                            detail.HasFrontSlot = false;
//                            detail.HasBackSlot = false;
//                            detail.ItemCategory = "";
//                            detail.IsSpecialShap = false;
//                            detail.DamageQty = 0;
//                            //detail.DamageQty =Convert.ToInt32(item["DamageQty"].ToString());//补损件                           
//                            OrderDatails.Add(detail);
//                            i++;
//                        }
//                    }
//                    #endregion
//                    args.Order = order;
//                    args.OrderDetails = OrderDatails;
//                    p.Client.SaveOrder(SenderUser, args);
//                    WriteSuccess();
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        //补损件
//        public void SaveOrderDatailsLsDamage()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    if (string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        throw new Exception("参数无效.");
//                    }
//                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(Request["OrderID"].ToString()));
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    List<OrderDetail> OrderDatails = new List<OrderDetail>();
//                    string Details = Server.UrlDecode(Request["OrderDetails"]);
//                    JsonData sj = JsonMapper.ToObject(Details);
//                    #region 板件
//                    if (sj.Count > 0)
//                    {
//                        //遍历对象元素，保存  
//                        foreach (JsonData item in sj)
//                        {
//                            OrderDetail detail = p.Client.GetOrderDetail(SenderUser, Guid.Parse(item["ItemID"].ToString()));
//                            detail.Qty = Decimal.Parse(item["Qty"].ToString()); //板件数量    
//                            detail.DamageQty = Convert.ToInt32(item["DamageQty"].ToString());//损耗数量                  
//                            detail.Remarks = Convert.ToString(item["Remarks"]);//备注                     
//                            OrderDatails.Add(detail);
//                        }
//                    }
//                    #endregion
//                    args.Order = order;
//                    args.OrderDetails = OrderDatails;
//                    p.Client.SaveOrder(SenderUser, args);
//                    WriteSuccess();
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        // 提交移门数据
//        public void SaveDoors()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    if (string.IsNullOrEmpty(Request["OrderID"].ToString()))
//                    {
//                        throw new Exception("订单无效");
//                    }
//                    Order order = p.Client.GetOrder(SenderUser, new Guid(Request["OrderID"]));

//                    SaveOrderArgs args = new SaveOrderArgs();
//                    List<Cabinet2Door> Cabinet2Door = new List<Cabinet2Door>();
//                    string Doors = Server.UrlDecode(Request["Doors"]);

//                    JsonData sj = JsonMapper.ToObject(Doors);
//                    if (sj.Count > 0)
//                    {
//                        //遍历对象元素，保存                        
//                        foreach (JsonData item in sj)
//                        {
//                            Cabinet2Door door = new Cabinet2Door();
//                            door.DoorID = Guid.Parse(item["DoorID"].ToString());
//                            door.CabinetID = Guid.Parse(item["CabinetID"].ToString());
//                            door.DoorName = item["DoorName"].ToString();
//                            door.Qty = int.Parse(item["Qty"].ToString());
//                            door.DoorSize = item["DoorSize"].ToString();
//                            door.Remark = item["Remark"].ToString();
//                            door.Created = DateTime.Now;
//                            door.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
//                            Cabinet2Door.Add(door);
//                        }
//                    }
//                    args.Order = order;
//                    args.Cabinet2Doors = Cabinet2Door;
//                    p.Client.SaveOrder(SenderUser, args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {

//                WriteError(ex.Message, ex);
//            }
//        }
//        //移门数据
//        public void GetDoors()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    if (string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        Response.Write("{\"total\":0,\"rows\":[]}");
//                    }
//                    else
//                    {
//                        Guid OrderID = new Guid(Request["OrderID"]);
//                        List<Order2Cabinet> lists = p.Client.GetOrder2CabinetByOrderID(SenderUser, OrderID);
//                        List<Cabinet2Door> lists_doors = new List<Cabinet2Door>();
//                        foreach (Order2Cabinet item in lists)
//                        {
//                            List<Cabinet2Door> item_lists = p.Client.GetCabinet2DoorByCabinetID(SenderUser, item.CabinetID);
//                            lists_doors.AddRange(item_lists);
//                        }
//                        string json = JSONHelper.List2DataSetJson(lists_doors);

//                        Response.Write(json);
//                    }

//                    //SearchOrder2CabinetArgs args = new SearchOrder2CabinetArgs();

//                    //args.OrderBy = "Created desc";                   
//                    //args.CompanyID = CurrentUser.CompanyID;

//                    //if (!string.IsNullOrEmpty(Request["OrderID"]))
//                    //{
//                    //    args.OrderIDs = new List<Guid>();
//                    //    foreach (string id in Request["OrderID"].ToString().Split(',').ToList())
//                    //    {
//                    //        args.OrderIDs.Add(new Guid(id));
//                    //    }
//                    //}
//                    //SearchResult sr = p.Client.SearchOrder2Cabinet(SenderUser, args);
//                    //Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception)
//            {

//                throw;
//            }

//        }
//        // 删除移门byDoorID
//        public void DeleteByDoorID()
//        {

//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string DoorID = Request["DoorID"];
//                    if (!string.IsNullOrEmpty(DoorID))
//                        p.Client.DeleteCabinet2Door(SenderUser, new Guid(DoorID));

//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        // 订单确认
//        public void ReviewOrder()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string remark = Request["Remark"];
//                    if (string.IsNullOrEmpty(Request["Remark"]))
//                    {
//                        throw new Exception("Remark:参数无效");
//                    }
//                    string OrderID = Request["OrderID"];
//                    if (string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        throw new Exception("OrderID:参数无效");
//                    }
//                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(OrderID));
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;

//                    if (order.Status.ToUpper() == "Z")
//                    {
//                        order.Status = "D";//状态改为待带财务审核
//                        //订单日志
//                        OrderLog log = new OrderLog();
//                        log.OrderID = order.OrderID;
//                        log.LogID = Guid.NewGuid();
//                        log.LogType = "审核订单";
//                        log.Remark = "用户提交审核";
//                        args.OrderLog = log;

//                        OrderTask ot = new OrderTask();
//                        ot.Action = "待确认订单";
//                        ot.CurrentStep = "订单确认";
//                        ot.ActionRemarksType = "审核意见";
//                        ot.ActionRemarks = remark;
//                        ot.Resource = "订单确认组";
//                        ot.NextResources = "财务审核组";
//                        ot.NextStep = "待财务审核";
//                        args.OrderTask = ot;
//                    }
//                    if (order.Status.ToUpper() == "B")
//                    {
//                        order.Status = "D";//状态改为待带财务审核
//                        //订单日志
//                        OrderLog log = new OrderLog();
//                        log.OrderID = order.OrderID;
//                        log.LogID = Guid.NewGuid();
//                        log.LogType = "审核订单";
//                        log.Remark = "用户提交审核";
//                        args.OrderLog = log;

//                        OrderTask ot = new OrderTask();
//                        ot.Action = "待确认订单";
//                        ot.CurrentStep = "订单确认";
//                        ot.ActionRemarksType = "审核意见";
//                        ot.ActionRemarks = remark;
//                        ot.Resource = "订单确认组";
//                        ot.NextResources = "财务审核组";
//                        ot.NextStep = "待财务审核";
//                        args.OrderTask = ot;
//                    }
//                    p.Client.SaveOrder(SenderUser, args);
//                    WriteSuccess();
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        // 待确认订单审核不通过
//        public void RejectOrder()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string remark = Request["Remark"];
//                    if (string.IsNullOrEmpty(Request["Remark"]))
//                    {
//                        throw new Exception("Remark:参数无效");
//                    }
//                    string OrderID = Request["OrderID"];
//                    if (string.IsNullOrEmpty(Request["OrderID"]))
//                    {
//                        throw new Exception("OrderID:参数无效");
//                    }
//                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(OrderID));
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;

//                    #region
//                    //if (order.Status == "N")
//                    //{
//                    //    order.Status = "U"; //审核不通过，状态改为待上传

//                    //    //把上传状态改为fasle,待重新上传
//                    //    List<Order2Cabinet> Order2Cabinets = new List<Order2Cabinet>();
//                    //    List<Order2Cabinet> listOrder2Cabinet = p.Client.GetOrder2CabinetByOrderID(SenderUser, order.OrderID);
//                    //    foreach (var item in listOrder2Cabinet)
//                    //    {
//                    //        item.FileUploadFlag = false;
//                    //        Order2Cabinets.Add(item);
//                    //        args.Order2Cabinets = Order2Cabinets;
//                    //    }
//                    //    //删除BOM、五金、CNC、DXF、图纸、效果图文件、详细数据
//                    //    p.Client.DeleteOrder2HardwareByOrderID(SenderUser, order.OrderID);
//                    //    p.Client.DeleteOrderProcessFileByOrderID(SenderUser, order.OrderID);
//                    //    p.Client.DeleteOrderDetailByOrderID(SenderUser, order.OrderID);
//                    //}
//                    #endregion

//                    #region
//                    //    //订单日志
//                    //    OrderLog log = new OrderLog();
//                    //    log.OrderID = order.OrderID;
//                    //    log.LogID = Guid.NewGuid();
//                    //    log.LogType = "审核订单";
//                    //    log.Remark = "用户审核不通过";
//                    //    args.OrderLog = log;

//                    //    OrderTask ot = new OrderTask();
//                    //    ot.Action = "待重新确认订单";
//                    //    ot.CurrentStep = "订单确认";
//                    //    ot.ActionRemarksType = "审核意见";
//                    //    ot.ActionRemarks = remark;
//                    //    ot.Resource = "订单确认组";
//                    //    ot.NextResources = "订单拆单组";
//                    //    ot.NextStep = "待重新审核";
//                    //    args.OrderTask = ot;

//                    //}
//                    #endregion

//                    if (order.Status == "Z")
//                    {
//                        order.Status = "B"; //审核不通过，状态改为已退回
//                        //订单日志
//                        OrderLog log = new OrderLog();
//                        log.OrderID = order.OrderID;
//                        log.LogID = Guid.NewGuid();
//                        log.LogType = "审核订单";
//                        log.Remark = "用户审核不通过";
//                        args.OrderLog = log;

//                        OrderTask ot = new OrderTask();
//                        ot.Action = "待订单确认";
//                        ot.CurrentStep = "待确认";
//                        ot.ActionRemarksType = "订单退回";
//                        ot.ActionRemarks = "已退回订单，待重新确认";
//                        ot.Resource = "订单拆单组";
//                        ot.NextResources = "订单确认组";
//                        ot.NextStep = "待重新确认";
//                        args.OrderTask = ot;
//                    }
//                    p.Client.SaveOrder(SenderUser, args);

//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }

//        }
//        // 财务审核
//        public void FinanceReview()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    #region  财务审核

//                    string OrderID = Request["OrderID"];
//                    if (string.IsNullOrEmpty(OrderID))
//                    {
//                        throw new Exception("OrderID:参数无效");
//                    }
//                    string remark = Request["Remark"];
//                    if (string.IsNullOrEmpty(Request["Remark"]))
//                    {
//                        throw new Exception("Remark:参数无效");
//                    }

//                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(OrderID));
//                    order.Status = "T"; //待排产
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;

//                    List<Order2Cabinet> cabinets = p.Client.GetOrder2CabinetByOrderID(SenderUser, order.OrderID);
//                    foreach (Order2Cabinet cabinet in cabinets)
//                    {
//                        cabinet.CabinetStatus = "T";
//                    }

//                    //订单日志
//                    OrderLog log = new OrderLog();
//                    log.OrderID = order.OrderID;
//                    log.LogID = Guid.NewGuid();
//                    log.LogType = "财务审核";
//                    log.Remark = "财务提交审核";
//                    args.OrderLog = log;

//                    OrderTask ot = new OrderTask();
//                    ot.Action = "待排产订单";
//                    ot.CurrentStep = "财务确认";
//                    ot.ActionRemarksType = "财务审核意见";
//                    ot.ActionRemarks = remark;
//                    ot.Resource = "财务审核组";
//                    ot.NextResources = "订单排产组";
//                    ot.NextStep = "待排产";

//                    args.Order2Cabinets = cabinets;

//                    args.OrderTask = ot;
//                    p.Client.SaveOrder(SenderUser, args);
//                    //修改柜体状态



//                    #endregion

//                    #region PartnerTransDetail
//                    if (Request["Payee"].ToString() != String.Empty && Request["Amount"].ToString() != String.Empty && Request["TransDate"].ToString() != String.Empty && Request["VoucherNo"].ToString() != String.Empty)
//                    {
//                        SavePartnerTransDetailArgs agrss = new SavePartnerTransDetailArgs();
//                        PartnerTransDetail transDetail = new PartnerTransDetail();
//                        transDetail.TransID = Guid.NewGuid();
//                        transDetail.OrderID = order.OrderID;
//                        transDetail.PartnerID = pparm.PartnerID;
//                        transDetail.Payee = Request["Payee"].ToString();
//                        transDetail.Amount = decimal.Parse(Request["Amount"].ToString());
//                        transDetail.TransDate = Convert.ToDateTime(Request["TransDate"].ToString());
//                        transDetail.VoucherNo = Request["VoucherNo"].ToString();
//                        agrss.PartnerTransDetail = transDetail;
//                        p.Client.SavePartnerTransDetail(SenderUser, agrss);
//                    }
//                    #endregion
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        // 财务审核不通过
//        public void RejectFinanceOrder()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {

//                    string OrderID = Request["OrderID"];
//                    if (string.IsNullOrEmpty(OrderID))
//                    {
//                        throw new Exception("OrderID:参数无效");
//                    }
//                    string remark = Request["Remark"];
//                    if (string.IsNullOrEmpty(remark))
//                    {
//                        throw new Exception("Remark:参数无效");
//                    }

//                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(OrderID));
//                    order.Status = "Z"; //审核不通过，状态改为信息待确认
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;

//                    List<Order2Cabinet> cabinets = p.Client.GetOrder2CabinetByOrderID(SenderUser, order.OrderID);
//                    foreach (Order2Cabinet cabinet in cabinets)
//                    {
//                        cabinet.CabinetStatus = "Z";
//                    }
//                    args.Order2Cabinets = cabinets;
//                    OrderTask ot = new OrderTask();
//                    ot.Action = "待重新确认订单";
//                    ot.CurrentStep = "订单确认";
//                    ot.ActionRemarksType = "审核意见";
//                    ot.ActionRemarks = remark;
//                    ot.Resource = "财务审核组";
//                    ot.NextResources = "订单确认组";
//                    ot.NextStep = "待重新审核";

//                    //订单日志
//                    OrderLog log = new OrderLog();
//                    log.OrderID = order.OrderID;
//                    log.LogID = Guid.NewGuid();
//                    log.LogType = "审核订单";
//                    log.Remark = "财务审核不通过";
//                    args.OrderLog = log;
//                    args.OrderTask = ot;
//                    p.Client.SaveOrder(SenderUser, args);

//                    WriteSuccess();
//                }

//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        // 订单分拣
//        public void CreatePackage()
//        {
//            try
//            {
//                string IDs = Request["OrderIDs"];
//                string[] OrderIDs;
//                if (!string.IsNullOrEmpty(IDs))
//                {
//                    OrderIDs = IDs.Split(',');
//                }
//                else
//                {
//                    throw new Exception("无效的订单ID参数。");
//                }

//                using (ProxyBE op = new ProxyBE())
//                {
//                    foreach (string sOrderID in OrderIDs)
//                    {
//                        Guid OrderID = Guid.Parse(sOrderID);
//                        Order order = op.Client.GetOrder(SenderUser, OrderID);
//                        //自动分包                    
//                        List<OrderDetail> subOrders = op.Client.GetOrderDetails(SenderUser, OrderID);
//                        if (subOrders.Count == 0)
//                        {
//                            continue;
//                        }

//                        //var gp_subOrders = subOrders.GroupBy(o => o.CabinetID);
//                        //int index = 1;
//                        //foreach (var gp in gp_subOrders)
//                        //{
//                        //    List<OrderDetail> p_suborders = (List<OrderDetail>)gp.ToList();
//                        //    BuildPackage b = new BuildPackage();
//                        //    List<Package_Panel> p = b.newPackage(p_suborders);
//                        //    int pageNum = op.Client.GetMaxPackageNum(SenderUser, OrderID, gp.Key);//获取最大的包号
//                        //    foreach (Package_Panel pp in p)
//                        //    {
//                        //        //新建立一个包
//                        //        Package package = new Package();
//                        //        package.PackageID = Guid.NewGuid();
//                        //        package.PackageBarcode = string.Format("0{0}_{1}{2}", order.OrderNo, index.ToString("00"), pageNum.ToString("00"));
//                        //        package.OrderID = order.OrderID;
//                        //        package.PackageNum = pageNum;
//                        //        package.CabinetID = gp.Key;

//                        //        SavePackageArgs saveArgs = new SavePackageArgs();
//                        //        saveArgs.Package = package;
//                        //        List<OrderDetail2Package> packageItems = new List<OrderDetail2Package>();
//                        //        int Sequence = 1;
//                        //        foreach (Layer l in pp.Layers)
//                        //        {
//                        //            foreach (OrderDetail o in l.OrderDetailIDs)
//                        //            {
//                        //                OrderDetail2Package item = new OrderDetail2Package();
//                        //                item.PackageID = package.PackageID;
//                        //                item.ItemID = o.ItemID;
//                        //                item.LayerID = l.LayerID;
//                        //                item.Sequence = Sequence;
//                        //                packageItems.Add(item);
//                        //                Sequence++;
//                        //                packageItems.Add(item);
//                        //            }
//                        //        }
//                        //        saveArgs.OrderDetail2Packages = packageItems;
//                        //        op.Client.SavePackage(SenderUser, saveArgs);
//                        //        pageNum++;
//                        //    }
//                        //    index++;
//                        //}
//                    }
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                WriteError(ex.Message, ex);
//            }
//        }
//        // 申请拆单
//        public void SplitOrders()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string OrderIDs = Request["OrderIDs"];
//                    string[] arrOrderID = OrderIDs.Split(',');
//                    foreach (string ID in arrOrderID)
//                    {
//                        Guid OrderID = new Guid(ID);
//                        Order order = p.Client.GetOrder(SenderUser, OrderID);
//                        if (order == null) continue;
//                        if (order.Status != "S") continue;

//                        order.Status = "U"; //待上传资料(BOM、工艺)
//                        SaveOrderArgs args = new SaveOrderArgs();
//                        args.Order = order;
//                        order.StepNo++;

//                        //订单日志
//                        OrderLog log = new OrderLog();
//                        log.OrderID = order.OrderID;
//                        log.LogID = Guid.NewGuid();
//                        log.LogType = "拆单申请";
//                        log.Remark = "已申请拆单，待上传资料";
//                        args.OrderLog = log;


//                        OrderTask ot = new OrderTask();
//                        ot.Action = "已申请拆单，待上传资料";
//                        ot.CurrentStep = "待拆单";
//                        ot.ActionRemarksType = "订单拆单";
//                        ot.ActionRemarks = "已申请拆单，待上传资料";
//                        ot.Resource = "订单拆单组";
//                        ot.NextResources = SenderUser.UserCode;
//                        ot.NextStep = "待上传资料";
//                        args.OrderTask = ot;
//                        p.Client.SaveOrder(SenderUser, args);
//                    }
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        public void SplitOrdersAuto()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string OrderIDs = Request["OrderIDs"];
//                    string[] arrOrderID = OrderIDs.Split(',');
//                    foreach (string ID in arrOrderID)
//                    {
//                        Guid OrderID = new Guid(ID);
//                        Order order = p.Client.GetOrder(SenderUser, OrderID);
//                        if (order == null) continue;
//                        if (order.Status != "S") continue;

//                        order.Status = "A"; //等云端拆单
//                        SaveOrderArgs args = new SaveOrderArgs();
//                        args.Order = order;
//                        order.StepNo++;

//                        //订单日志
//                        OrderLog log = new OrderLog();
//                        log.OrderID = order.OrderID;
//                        log.LogID = Guid.NewGuid();
//                        log.LogType = "云拆单申请";
//                        log.Remark = "提交云拆单申请";
//                        args.OrderLog = log;

//                        OrderTask ot = new OrderTask();
//                        ot.Action = "待上传资料";
//                        ot.CurrentStep = "待拆单";
//                        ot.ActionRemarksType = "待上传资料";
//                        ot.ActionRemarks = "待云端自动上传资料BOM资料";
//                        ot.Resource = SenderUser.UserCode;
//                        ot.NextResources = "CPT";
//                        ot.NextStep = "待云拆单";
//                        args.OrderTask = ot;

//                        p.Client.SaveOrder(SenderUser, args);
//                    }
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        // 上传BOM等文件
//        public void FileUpload()
//        {
//            try
//            {
//                string filePath = "";// Config.StorageFolder;
//                string PartnerCode = "";

//                List<OrderProcessFile> ProcessFiles = new List<OrderProcessFile>();
//                List<Order2Cabinet> Order2Cabinets = new List<Order2Cabinet>();
//                List<OrderDetail> OrderDetails = new List<OrderDetail>();
//                List<OrderWorkFlow> OrderWorkFlows = new List<OrderWorkFlow>();
//                List<Order2Hardware> Order2Hardwares = new List<Order2Hardware>();
//                using (ProxyBE p = new ProxyBE())
//                {
//                    Order order = p.Client.GetOrder(SenderUser, parm.OrderID);
//                    SaveOrderArgs args = new SaveOrderArgs();

//                    #region 重新上传文件
//                    //List<Order2Cabinet> Order2Cabinets = new List<Order2Cabinet>();
//                    List<Order2Cabinet> listOrder2Cabinet = p.Client.GetOrder2CabinetByOrderID(SenderUser, order.OrderID);
//                    var flag = Request["ReloadUploadFile"];//判断是否重新上传，是 则删除原先文件
//                    Guid CabinetID = Guid.Parse(Request["CabinetID"]);
//                    if (flag == "True")
//                    {
//                        //删除BOM、五金、CNC、DXF、图纸、效果图文件、详细数据
//                        p.Client.DeleteOrder2HardwareByCabinetID(SenderUser, CabinetID);
//                        p.Client.DeleteOrderProcessFileByCabinetID(SenderUser, CabinetID);
//                        p.Client.DeleteOrderDetailByCabinetID(SenderUser, CabinetID);
//                    }
//                    #endregion

//                    OrderLog log = new OrderLog();
//                    log.LogID = Guid.NewGuid();
//                    log.OrderID = order.OrderID;
//                    log.LogType = "文件上传";

//                    Partner partner = p.Client.GetPartner(SenderUser, order.PartnerID);
//                    PartnerCode = partner.PartnerCode;
//                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyyMM"));
//                    filePath = Path.Combine(filePath, PartnerCode);
//                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyyMM"));
//                    filePath = Path.Combine(filePath, order.OrderNo);

//                    Order2Cabinet order2Cabinet = listOrder2Cabinet.Find(item => item.CabinetID == CabinetID);
//                    #region BOM文件
//                    IList<HttpPostedFile> bomFiles = Request.Files.GetMultiple("bomFile");
//                    foreach (HttpPostedFile bomFile in bomFiles)
//                    {
//                        if (bomFile.FileName == "") continue;
//                        string savepath = Path.Combine(filePath, "BOM");
//                        savepath = Path.Combine(savepath, Path.GetFileName(bomFile.FileName));

//                        UploadSplitFile(savepath, bomFile);
//                        OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "BOM", Path.GetFileName(savepath));
//                        if (pf == null)
//                        {
//                            pf = new OrderProcessFile();
//                            pf.OrderID = parm.OrderID;
//                            pf.FileID = Guid.NewGuid();
//                            pf.Tag = "BOM";
//                            pf.CabinetID = CabinetID;
//                            pf.FileName = Path.GetFileName(savepath);
//                            pf.FilePath = savepath;
//                            pf.FileType = "BOM";
//                        }
//                        ProcessFiles.Add(pf);


//                        //处理BOM
//                        try
//                        {
//                            string tempSavepath = Server.MapPath(@"/temp/") + savepath;
//                            if (!System.IO.Directory.Exists(Path.GetDirectoryName(tempSavepath)))
//                            {
//                                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(tempSavepath));
//                            }
//                            if (File.Exists(tempSavepath))
//                            {
//                                File.Delete(tempSavepath);
//                            }
//                            bomFile.SaveAs(tempSavepath);

//                            List<OrderWorkFlow> ows = new List<OrderWorkFlow>();
//                            List<OrderDetail> suborders = new List<OrderDetail>();
//                            bool IsHandmade = false;
//                            if (!string.IsNullOrEmpty(Request["IsHandmade"]))
//                            {
//                                IsHandmade = bool.Parse(Request["IsHandmade"].ToString());
//                            }
//                            if (IsHandmade)
//                            {
//                                suborders = this.ImportExcelByHandmade(tempSavepath, order.OrderID, ref order2Cabinet, ref ows);
//                            }
//                            else
//                            {
//                                suborders = ImportExcel(tempSavepath, order.OrderID, ref order2Cabinet, ref ows);
//                            }

//                            //处理完成后删除临时文件
//                            File.Delete(tempSavepath);

//                            OrderDetails.AddRange(suborders);
//                            OrderWorkFlows.AddRange(ows);
//                        }
//                        catch (Exception ex)
//                        {
//                            PLogger.LogError(ex);
//                            throw new PException("处理BOM文件:{0}时出错。错误原因：{1}", pf.FileName, ex.Message);
//                        }
//                    }
//                    log.Remark = string.Format("成功上传BOM文件{0}个；", bomFiles.Count);
//                    #endregion

//                    #region 五金文件
//                    HttpPostedFile hardwarefile = Request.Files["hardwarefile"];
//                    if (hardwarefile != null && hardwarefile.FileName != "")
//                    {
//                        string savepath = Path.Combine(filePath, "Hardware");
//                        savepath = Path.Combine(savepath, order2Cabinet.CabinetName + Path.GetExtension(hardwarefile.FileName));
//                        UploadSplitFile(savepath, hardwarefile);
//                        OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "Hardware", Path.GetFileName(savepath));
//                        if (pf == null)
//                        {
//                            pf = new OrderProcessFile();
//                            pf.OrderID = parm.OrderID;
//                            pf.CabinetID = CabinetID;
//                            pf.FileID = Guid.NewGuid();
//                            pf.FileName = Path.GetFileName(savepath);
//                            pf.FilePath = savepath;
//                            pf.FileType = "Hardware";
//                        }
//                        ProcessFiles.Add(pf);
//                        log.Remark += "成功上传五金文件一个；";

//                        //处理五金BOM
//                        try
//                        {
//                            string tempSavepath = Server.MapPath(@"/temp/") + savepath;
//                            if (!System.IO.Directory.Exists(Path.GetDirectoryName(tempSavepath)))
//                            {
//                                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(tempSavepath));
//                            }

//                            if (File.Exists(tempSavepath))
//                            {
//                                File.Delete(tempSavepath);
//                            }
//                            hardwarefile.SaveAs(tempSavepath);

//                            List<Order2Hardware> ows = new List<Order2Hardware>();
//                            List<Order2Hardware> suborder2hardware = ImportHardwareExcel(tempSavepath, order.OrderID, CabinetID);
//                            Order2Hardwares.AddRange(suborder2hardware);

//                            File.Delete(tempSavepath);
//                        }
//                        catch (Exception ex)
//                        {
//                            PLogger.LogError(ex);
//                            throw new PException("处理五金文件:{0}时出错。错误原因：{1}", pf.FileName, ex.Message);
//                        }
//                    }
//                    #endregion

//                    #region CNC文件
//                    IList<HttpPostedFile> fs = Request.Files.GetMultiple("cnc_productfile");
//                    foreach (HttpPostedFile file in fs)
//                    {
//                        if (file.FileName == "") continue;
//                        string savepath = Path.Combine(filePath, "ProcessFile");
//                        savepath = Path.Combine(savepath, Path.GetFileName(file.FileName));
//                        UploadSplitFile(savepath, file);

//                        OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "ProcessFile", Path.GetFileName(savepath));
//                        if (pf == null)
//                        {
//                            pf = new OrderProcessFile();
//                            pf.OrderID = parm.OrderID;
//                            pf.FileID = Guid.NewGuid();
//                            pf.CabinetID = CabinetID;
//                            pf.FileName = Path.GetFileName(savepath);
//                            pf.FilePath = savepath;
//                            pf.FileType = "CNC";
//                        }
//                        ProcessFiles.Add(pf);

//                    }
//                    #endregion

//                    #region DXF文件
//                    IList<HttpPostedFile> dxf = Request.Files.GetMultiple("dxf_productfile");
//                    foreach (HttpPostedFile file in dxf)
//                    {
//                        if (file.FileName == "") continue;
//                        string savepath = Path.Combine(filePath, "ProcessFile");
//                        savepath = Path.Combine(savepath, Path.GetFileName(file.FileName));
//                        UploadSplitFile(savepath, file);
//                        OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "ProcessFile", Path.GetFileName(savepath));
//                        if (pf == null)
//                        {
//                            pf = new OrderProcessFile();
//                            pf.OrderID = parm.OrderID;
//                            pf.FileID = Guid.NewGuid();
//                            pf.CabinetID = CabinetID;
//                            pf.FileName = Path.GetFileName(savepath);
//                            pf.FilePath = savepath;
//                            pf.FileType = "DXF";
//                        }
//                        ProcessFiles.Add(pf);

//                    }
//                    #endregion

//                    #region 图纸文件
//                    IList<HttpPostedFile> drawingfile = Request.Files.GetMultiple("drawingfile");
//                    foreach (HttpPostedFile file in drawingfile)
//                    {
//                        if (file.FileName == "") continue;
//                        string savepath = Path.Combine(filePath, "DrawingFile");
//                        if (!string.IsNullOrEmpty(file.FileName))
//                        {
//                            savepath = Path.Combine(savepath, Path.GetFileName(file.FileName));
//                            UploadSplitFile(savepath, file);
//                            OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "DrawingFile", Path.GetFileName(savepath));
//                            if (pf == null)
//                            {
//                                pf = new OrderProcessFile();
//                                pf.OrderID = parm.OrderID;
//                                pf.FileID = Guid.NewGuid();
//                                pf.CabinetID = CabinetID;
//                                pf.FileName = Path.GetFileName(savepath);
//                                pf.FilePath = savepath;
//                                pf.Tag = "";
//                                pf.FileType = "DrawingFile";
//                            }
//                            ProcessFiles.Add(pf);
//                        }
//                    }
//                    #endregion

//                    #region 效果文件
//                    IList<HttpPostedFile> RenderingFiles = Request.Files.GetMultiple("RenderingFile");
//                    foreach (HttpPostedFile file in RenderingFiles)
//                    {
//                        if (file.FileName == "") continue;
//                        string savepath = Path.Combine(filePath, "RenderingFile");
//                        if (!string.IsNullOrEmpty(file.FileName))
//                        {
//                            savepath = Path.Combine(savepath, Path.GetFileName(file.FileName));
//                            UploadSplitFile(savepath, file);
//                            OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "RenderingFile", Path.GetFileName(savepath));
//                            if (pf == null)
//                            {
//                                pf = new OrderProcessFile();
//                                pf.OrderID = parm.OrderID;
//                                pf.FileID = Guid.NewGuid();
//                                pf.CabinetID = CabinetID;
//                                pf.FileName = Path.GetFileName(savepath);
//                                pf.FilePath = savepath;
//                                pf.FileType = "RenderingFile";
//                            }
//                            ProcessFiles.Add(pf);
//                        }
//                    }
//                    #endregion
//                    log.Remark += string.Format("成功上传工艺文件{0}个；", fs.Count);
//                    order2Cabinet.FileUploadFlag = true;
//                    Order2Cabinets.Add(order2Cabinet);
//                    args.Order2Cabinets = Order2Cabinets;
//                    //如果所有产品的文件都已经上传,下订单转一步骤              
//                    args.Order = order;
//                    if (OrderDetails.Count == 0)
//                        throw new Exception("BOM文件数量为空，请重新上传！");
//                    if (Order2Hardwares.Count == 0)
//                        throw new Exception("五金文件数量为空，请重新上传！");

//                    args.OrderDetails = OrderDetails;
//                    args.Order2Hardwares = Order2Hardwares;
//                    args.OrderWorkFlows = OrderWorkFlows;
//                    args.OrderProcessFiles = ProcessFiles;
//                    args.OrderLog = log;

//                    p.Client.SaveOrder(SenderUser, args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        private void UploadSplitFile(string savepath, HttpPostedFile pf)
//        {
//            //通过SE上传文件
//            //暂无SE服务，暂时注释
//            //using (ProxySE se = new ProxySE())
//            //{
//            //    byte[] buffer = new byte[pf.ContentLength];
//            //    Stream sr = pf.InputStream;
//            //    int scSize = sr.Read(buffer, 0, buffer.Length);
//            //    se.Client.UploadDoumentFile(SenderUser, savepath, buffer);
//            //}
//        }
//        public void GetCabinet()
//        {
//            try
//            {
//                using (ProxyBE op = new ProxyBE())
//                {
//                    Guid cabinetid = Guid.Parse(Request["CabinetID"]);
//                    Order2Cabinet obj = op.Client.GetOrder2Cabinet(SenderUser, cabinetid);
//                    Response.Write(JSONHelper.Object2Json(obj));
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 订单排产
//        /// </summary>
//        public void CreateScheduling_Source()
//        {
//            try
//            {
//                string IDs = Request["CabinetIDs"];
//                string WorkingLineID = Request["WorkingLineID"];
//                if (string.IsNullOrEmpty(IDs))
//                    throw new Exception("请选择待排产的订单。");

//                if (string.IsNullOrEmpty(WorkingLineID))
//                    throw new Exception("请选择需要排产的生产线。");

//                string[] OrderIDs = IDs.Split(',');
//                using (ProxyBE op = new ProxyBE())
//                {
//                    WorkingLine wl = op.Client.GetWorkingLine(SenderUser, new Guid(WorkingLineID));
//                    if (wl == null)
//                    {
//                        throw new PException("所选择的生产线不存在。");
//                    }
//                    //获取排产批次号
//                    string BatchNum = op.Client.GetBattchNum(SenderUser);
//                    //获取特殊部件工序
//                    List<SpecialCompanent> lists_SC = op.Client.GetSpecialCompanents(SenderUser);
//                    foreach (string sOrderID in OrderIDs)
//                    {
//                        Guid OrderID = Guid.Parse(sOrderID);
//                        Order order = op.Client.GetOrder(SenderUser, OrderID);
//                        List<OrderDetail> subOrders = op.Client.GetOrderDetails(SenderUser, OrderID);

//                        //板件生产工序
//                        List<OrderWorkFlow> ows = new List<OrderWorkFlow>();
//                        //订单生产时间计划表
//                        List<OrderScheduling> lists_os = new List<OrderScheduling>();
//                        //包装数据
//                        List<PackageDetail> list_PackageDetails = new List<PackageDetail>();

//                        #region  排除移门数据
//                        List<Category> doors_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "OptimizeType");
//                        foreach (Category item in doors_items)
//                        {
//                            if (item.CategoryName.Contains("Y"))
//                            {
//                                subOrders.RemoveAll(p => p.ItemName.Contains(item.CategoryName));
//                            }
//                        }
//                        #endregion

//                        #region 所有工件都需要包装,除了移门数据
//                        //设置板件生产工序
//                        foreach (OrderDetail subOrder in subOrders)
//                        {
//                            #region 生成包装数据
//                            for (int i = 0; i < subOrder.Qty; i++)
//                            {
//                                PackageDetail packageDetail = new PackageDetail();
//                                packageDetail.DetailID = Guid.NewGuid();
//                                packageDetail.ItemID = subOrder.ItemID;
//                                packageDetail.BattchNo = BatchNum;
//                                packageDetail.Qty = 1;
//                                packageDetail.PakageID = Guid.Empty;
//                                packageDetail.LayerNum = 0;
//                                //packageDetail.IsPakaged = false;
//                                packageDetail.IsOptimized = false;
//                                packageDetail.IsPlanning = true;
//                                packageDetail.IsDisabled = false;
//                                list_PackageDetails.Add(packageDetail);
//                            }
//                            #endregion
//                        }
//                        #endregion

//                        #region 加工工序：排除做库存的部件
//                        List<OrderDetail> packages = new List<OrderDetail>();
//                        List<Category> storage_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "StorageMaterials");
//                        foreach (Category item in storage_items)
//                        {
//                            //把库存件直接加入包装工件清单中
//                            packages.AddRange(subOrders.FindAll(p => p.ItemName.Contains(item.CategoryName)));
//                            subOrders.RemoveAll(p => p.ItemName.Contains(item.CategoryName));
//                        }
//                        #endregion

//                        #region 加工工序：排除发外生产的部件
//                        List<Category> Outsourcing_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "OutSourcingMaterials");
//                        foreach (Category item in Outsourcing_items)
//                        {
//                            //把外购件直接加入包装工件清单中
//                            packages.AddRange(subOrders.FindAll(p => p.ItemName.Contains(item.CategoryName)));
//                            subOrders.RemoveAll(p => p.ItemName.Contains(item.CategoryName));
//                        }
//                        #endregion

//                        if (subOrders.Count == 0)
//                        {
//                            continue;
//                        }
//                        #region 生成所有板件的生产工序
//                        //加入最后完成工序;                
//                        SpecialCompanent2WorkFlow finish_step = new SpecialCompanent2WorkFlow();
//                        finish_step.Sequence = 999;
//                        finish_step.WorkFlowID = Guid.Empty;

//                        //设置板件生产工序
//                        foreach (OrderDetail subOrder in subOrders)
//                        {
//                            OrderWorkFlow ow = new OrderWorkFlow();
//                            if (subOrder.IsSpecialShap)
//                            {
//                                #region 设置异形板工序
//                                SpecialCompanent sc = lists_SC.Find(item => item.ItemName == "异形板");
//                                if (sc != null)
//                                {
//                                    List<SpecialCompanent2WorkFlow> wfs = op.Client.GetSpecialCompanent2WorkFlows(SenderUser, sc.SpecialID);
//                                    if (wfs.FindAll(t => t.WorkFlowID == Guid.Empty) == null)
//                                    {
//                                        wfs.Add(finish_step);
//                                    }
//                                    wfs.OrderBy(item => item.Sequence);
//                                    for (int i = 0; i < wfs.Count - 1; i++)
//                                    {
//                                        SpecialCompanent2WorkFlow subwf = wfs[i];
//                                        ow = new OrderWorkFlow();
//                                        ow.WorkingID = Guid.NewGuid();
//                                        ow.ItemID = subOrder.ItemID;
//                                        ow.OrderID = subOrder.OrderID;
//                                        ow.WorkFlowNo = i + 1;
//                                        ow.Action = "";
//                                        ow.SourceWorkFlowID = wfs[i].WorkFlowID;
//                                        ow.TargetWorkFlowID = wfs[i + 1].WorkFlowID;
//                                        ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                                        ow.MadeQty = 0;
//                                        ows.Add(ow);
//                                        SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, subOrder);
//                                    }
//                                }
//                                #endregion
//                            }
//                            else if (lists_SC.Find(item => item.ItemName == subOrder.ItemName) != null)
//                            {
//                                #region 设置特殊板件工序
//                                SpecialCompanent sc = lists_SC.Find(item => item.ItemName == subOrder.ItemName);
//                                List<SpecialCompanent2WorkFlow> wfs = op.Client.GetSpecialCompanent2WorkFlows(SenderUser, sc.SpecialID);
//                                if (wfs.FindAll(t => t.WorkFlowID == Guid.Empty) == null)
//                                {
//                                    wfs.Add(finish_step);
//                                }
//                                wfs.OrderBy(item => item.Sequence);
//                                for (int i = 0; i < wfs.Count - 1; i++)
//                                {
//                                    SpecialCompanent2WorkFlow subwf = wfs[i];
//                                    ow = new OrderWorkFlow();
//                                    ow.WorkingID = Guid.NewGuid();
//                                    ow.ItemID = subOrder.ItemID;
//                                    ow.OrderID = subOrder.OrderID;
//                                    ow.WorkFlowNo = i + 1;
//                                    ow.Action = "";
//                                    ow.SourceWorkFlowID = wfs[i].WorkFlowID;
//                                    ow.TargetWorkFlowID = wfs[i + 1].WorkFlowID;
//                                    ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                                    ow.MadeQty = 0;
//                                    ows.Add(ow);
//                                    SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, subOrder);
//                                }
//                                #endregion
//                            }
//                            else
//                            {
//                                #region 普通板件工序
//                                string workFlows = "常规开料";
//                                if (!string.IsNullOrEmpty(subOrder.EdgeDesc))
//                                {
//                                    workFlows += ",封边";
//                                }
//                                if (subOrder.HoleDesc.Contains("打孔") || subOrder.BarcodeNo.Substring(0, 2) == "N5")
//                                {
//                                    workFlows += ",常规打孔";
//                                }
//                                workFlows += ",包装,完成";
//                                string[] arrWF = workFlows.Split(',');
//                                //第一步：开料
//                                for (int z = 0; z < arrWF.Length - 1; z++)
//                                {
//                                    ow = new OrderWorkFlow();
//                                    ow.WorkingID = Guid.NewGuid();
//                                    ow.ItemID = subOrder.ItemID;
//                                    ow.OrderID = subOrder.OrderID;
//                                    ow.WorkFlowNo = z + 1;
//                                    ow.Action = arrWF[z];
//                                    ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(arrWF[z]));
//                                    ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(arrWF[z + 1]));
//                                    ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                                    ow.MadeQty = 0;
//                                    ows.Add(ow);

//                                    //计算订单工序总板件及面积
//                                    SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, subOrder);
//                                }
//                                #endregion
//                            }
//                        }

//                        //把外购的工件和做库存的部件加到包装工序当中
//                        #region
//                        string PackageFlows = "包装,完成";
//                        string[] pkWF = PackageFlows.Split(',');
//                        //第一步：包装
//                        foreach (OrderDetail suborder in packages)
//                        {
//                            for (int z = 0; z < pkWF.Length - 1; z++)
//                            {
//                                OrderWorkFlow ow = new OrderWorkFlow();
//                                ow.WorkingID = Guid.NewGuid();
//                                ow.ItemID = suborder.ItemID;
//                                ow.OrderID = suborder.OrderID;
//                                ow.WorkFlowNo = z + 1;
//                                ow.Action = pkWF[z];
//                                ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(pkWF[z]));
//                                ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(pkWF[z + 1]));
//                                ow.TotalQty = Convert.ToInt32(suborder.Qty);
//                                ow.MadeQty = 0;
//                                ows.Add(ow);
//                                //计算订单工序总板件及面积
//                                SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, suborder);
//                            }
//                        }
//                        #endregion
//                        #endregion

//                        //根据订单总的数量和面积，计算在生产设备及工序上的生产时间    
//                        List<WorkCenterScheduling> lists_ws = new List<WorkCenterScheduling>();

//                        //把车间数据、设备数据、班次数据一次性加载出来
//                        foreach (OrderScheduling os in lists_os)
//                        {
//                            #region 获取工序对应的设备产能,每条生产线
//                            Guid WorkFlowID = os.WorkFlowID;//工序ID

//                            WorkFlow wf = op.Client.GetWorkFlow(SenderUser, WorkFlowID);

//                            SearchWorkCenterArgs wc_args = new SearchWorkCenterArgs();
//                            wc_args.WorkFlowID = WorkFlowID;
//                            wc_args.WorkingLineID = new Guid(WorkingLineID);


//                            SearchResult sr_wc = op.Client.SearchWorkCenter(SenderUser, wc_args);

//                            if (sr_wc.Total == 0)
//                            {
//                                throw new PException("【{0}】的【{1}】工序未设置生产设备或生产设备产能为0。", wl.WorkingLineName, wf.WorkFlowName);
//                            }

//                            int MaxCapacity = 0;
//                            string CountCapacityType = "";
//                            //生产设备列表
//                            List<WorkCenter> wclists = new List<WorkCenter>();
//                            //多台设备
//                            Guid WorkShopID = Guid.Empty;
//                            foreach (DataRow wc_row in sr_wc.DataSet.Tables[0].Rows)
//                            {
//                                MaxCapacity += int.Parse(wc_row["MaxCapacity"].ToString()); //最大产能  
//                                CountCapacityType = wc_row["CountCapacityType"].ToString();
//                                WorkShopID = Guid.Parse(wc_row["WorkShopID"].ToString());
//                                WorkCenter wc = op.Client.GetWorkCenter(SenderUser, Guid.Parse(wc_row["WorkCenterID"].ToString()));
//                                if (wc != null)
//                                {
//                                    wclists.Add(wc);
//                                }
//                            }
//                            #endregion
//                            #region 工作班次
//                            //获取生产线(生产车间)对应的班次工作时间（设备的生产时间)
//                            SearchWorkShift2WorkShopArgs sws_args = new SearchWorkShift2WorkShopArgs();
//                            sws_args.WorkShopID = WorkShopID;
//                            SearchResult sws_sr = op.Client.SearchWorkShift2WorkShop(SenderUser, sws_args);
//                            if (sws_sr.Total == 0)
//                            {
//                                throw new PException("【{0}】的【{1}】工序未设置工作时间或班次。", wl.WorkingLineName, wf.WorkFlowName);
//                            }
//                            int hours = 0;
//                            DateTime Started = DateTime.MaxValue;
//                            DateTime Ended = DateTime.MinValue;
//                            foreach (DataRow rw in sws_sr.DataSet.Tables[0].Rows)
//                            {
//                                DateTime started = DateTime.Parse(rw["Started"].ToString());
//                                DateTime ended = DateTime.Parse(rw["Ended"].ToString());
//                                if (ended < started)
//                                {
//                                    ended = ended.AddDays(1);
//                                }
//                                if (Started > started)
//                                {
//                                    Started = started;
//                                }
//                                if (ended > Ended)
//                                {
//                                    Ended = ended;
//                                }
//                                hours += (ended - started).Hours;
//                            }
//                            #endregion
//                            #region 订单生产排产及设备排产

//                            //工序生产时长：生产量除以产能（小时），取整
//                            var a = MaxCapacity * hours * 1.0M;
//                            switch (CountCapacityType)
//                            {
//                                case "L"://按长度计算产能
//                                    os.ProductionPeriod = (os.TotalLength / (MaxCapacity * hours * 1.0M));
//                                    break;
//                                case "A"://按面积计算产能
//                                    os.ProductionPeriod = (os.TotalAreal / (MaxCapacity * hours * 1.0M));
//                                    break;
//                                case "Q"://按板件数量计算产能
//                                    os.ProductionPeriod = (os.TotalQty / (MaxCapacity * hours * 1.0M));
//                                    break;
//                                default:
//                                    os.ProductionPeriod = os.TotalAreal / (MaxCapacity * hours * 1.0M);
//                                    break;
//                            }

//                            //需要提前一天排产                            
//                            WorkCenterScheduling wcs = op.Client.GetLastWorkCenterSchedulingByWorkCenterID(SenderUser, wclists[0].WorkCenterID);
//                            DateTime MadeStarted;
//                            if (wcs == null)
//                            {
//                                MadeStarted = DateTime.Now.Date.AddDays(1).AddHours(8); //开始时间
//                            }
//                            else
//                            {
//                                MadeStarted = wcs.Ended;
//                            }
//                            wcs = new WorkCenterScheduling();
//                            wcs.WorkID = Guid.NewGuid();
//                            wcs.WorkCenterID = wclists[0].WorkCenterID;
//                            wcs.Status = "N";
//                            wcs.BattchNum = BatchNum;
//                            wcs.Started = MadeStarted;


//                            //计算结束时间
//                            int Days = (int)os.ProductionPeriod; //生产天数
//                            double Hours = (double)(os.ProductionPeriod - Days) * hours;
//                            wcs.Ended = wcs.Started.AddDays(Days);

//                            //如果生产时间不在工作时间，则排产时间需要安排到下一工作时间段
//                            if (wcs.Ended.AddHours(Hours) > wcs.Ended.Date.AddHours(Ended.Hour))
//                            {
//                                //计算上一工作日的下班时间与下一工作时间的上班时间差                                
//                                //下一工作日的上班时间
//                                Started = Started.AddDays(1);
//                                int SplitHour = (Started - Ended).Hours;
//                                wcs.Ended = wcs.Ended.AddHours(Hours + SplitHour);
//                            }
//                            else
//                            {
//                                wcs.Ended = wcs.Ended.AddHours(Hours);
//                            }
//                            os.Estimated = wcs.Ended;    //预计生产结束时间                                
//                            #endregion

//                            lists_ws.Add(wcs);
//                        }

//                        order.BattchNum = BatchNum;
//                        order.Status = "M"; //待生产
//                        order.StepNo++;

//                        //订单日志
//                        OrderLog log = new OrderLog();
//                        log.LogID = Guid.NewGuid();
//                        log.OrderID = order.OrderID;
//                        log.LogType = "订单排产";
//                        log.Remark = "完成排产";
//                        SaveOrderArgs so_args = new SaveOrderArgs();

//                        //流程步骤
//                        OrderTask ot = new OrderTask();
//                        ot.Action = "排产完成，待订单优化";
//                        ot.CurrentStep = "订单排产";
//                        ot.ActionRemarksType = "订单系统操作";
//                        ot.ActionRemarks = "排产完成，待订单优化";
//                        ot.Resource = "订单排产组";
//                        ot.NextResources = "订单优化组";
//                        ot.NextStep = "待生产优化";
//                        so_args.OrderTask = ot;

//                        so_args.Order = order;
//                        so_args.OrderLog = log;
//                        so_args.OrderWorkFlows = ows;
//                        so_args.OrderSchedulings = lists_os;
//                        so_args.WorkCenterSchedulings = lists_ws;
//                        so_args.PackageDetails = list_PackageDetails;
//                        op.Client.SaveOrder(SenderUser, so_args);
//                        //排产完成后，生成批次顺序
//                        op.Client.UpdateOrderBattchIndex(SenderUser, BatchNum);
//                    }
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        //Liu20180526
//        public void CreateScheduling()
//        {
//            try
//            {
//                string BJidStr = Request["BJids"];
//                string WorkingLineID = Request["WorkingLineID"];
//                if (string.IsNullOrEmpty(BJidStr))
//                    throw new Exception("请选择待排产的板件。");

//                if (string.IsNullOrEmpty(WorkingLineID))
//                    throw new Exception("请选择需要排产的生产线。");

//                string batchNum = "P" + DateTime.Now.ToString("yyMMddHHmmssfff"); ;//批次号
//                //Liu①
//                //string SchedulingTime = Request["SchedulingTime"].ToString();//排产时间


//                //OrderSchedulingTime OrderSchedulingTime = null;
//                //if (!string.IsNullOrEmpty(SchedulingTime))
//                //{
//                //    OrderSchedulingTime = JSONHelper.FromJson<OrderSchedulingTime>(SchedulingTime);
//                //}



//                ///////////
//                string[] BJIDs = BJidStr.Split(',');
//                using (ProxyBE op = new ProxyBE())
//                {
//                    //Liu①
//                    WorkingLine wl = op.Client.GetWorkingLine(SenderUser, new Guid(WorkingLineID));
//                    if (wl == null)
//                    {
//                        throw new PException("所选择的生产线不存在。 ");
//                    }

//                    Database dbBJ = new Database("BE_OrderDetail_Proc", "GETBJBYIDS", 0, 0, "", "", BJidStr);
//                    DataTable dtBJs = dbBJ.ExecuteDataTable();

//                    //板件生产工序
//                    List<OrderWorkFlow> ows = new List<OrderWorkFlow>();
//                    //订单生产时间计划表
//                    List<OrderScheduling> lists_os = new List<OrderScheduling>();

//                    //string SchedulingTime = Request["SchedulingTime"].ToString();
//                    //OrderSchedulingTime OrderSchedulingTime = null;
//                    //if (!string.IsNullOrEmpty(SchedulingTime))
//                    //{
//                    //    OrderSchedulingTime = JSONHelper.FromJson<OrderSchedulingTime>(SchedulingTime);
//                    //}

//                    #region 生成所有板件的生产工序

//                    //设置板件生产工序
//                    for (int i = 0; i < dtBJs.Rows.Count; i++)
//                    {
//                        OrderWorkFlow ow = new OrderWorkFlow();
//                        Database dbName = new Database("BE_WorkFlow_Proc", "GETALLNAME", 0, 0, "", "", "");
//                        string workFlows = dbName.ExecuteScalar().ToString();
//                        string[] arrWF = workFlows.Split(',');
//                        //第一步：开料
//                        for (int z = 0; z < arrWF.Length - 1; z++)
//                        {
//                            ow = new OrderWorkFlow();
//                            ow.WorkingID = Guid.NewGuid();
//                            ow.ItemID = Guid.Parse(dtBJs.Rows[i]["ItemID"].ToString());
//                            ow.OrderID = Guid.Parse(dtBJs.Rows[i]["OrderID"].ToString());
//                            ow.BatchNum = batchNum;
//                            ow.WorkFlowNo = z + 1;
//                            ow.Action = arrWF[z];
//                            ow.SourceWorkFlowID = new Guid(GetWorkFlowID(arrWF[z]));
//                            ow.TargetWorkFlowID = new Guid(GetWorkFlowID(arrWF[z + 1]));
//                            ow.TotalQty = Convert.ToInt32(dtBJs.Rows[i]["Qty"]);
//                            ow.MadeQty = 0;
//                            ows.Add(ow);

//                            decimal num1 = decimal.Parse(dtBJs.Rows[i]["MadeLength"].ToString()) * decimal.Parse(dtBJs.Rows[i]["MadeWidth"].ToString()) * Convert.ToInt32(dtBJs.Rows[i]["Qty"]);
//                            decimal num2 = (decimal.Parse(dtBJs.Rows[i]["MadeLength"].ToString()) + decimal.Parse(dtBJs.Rows[i]["MadeWidth"].ToString())) * 2 * Convert.ToInt32(dtBJs.Rows[i]["Qty"]);
//                            //计算订单工序总板件及面积
//                            //SetOrderScheduling(lists_os, BatchNum, subOrder.OrderID, ow.SourceWorkFlowID, ow.TotalQty, subOrder.MadeLength * subOrder.MadeWidth * subOrder.Qty, (subOrder.MadeLength + subOrder.MadeWidth) * 2 * subOrder.Qty);
//                            SetOrderScheduling(lists_os, batchNum, new Guid(), new Guid(), ow.SourceWorkFlowID, ow.TotalQty, num1, num2, DateTime.Parse("1900-01-01 00:00:00.000"), DateTime.Parse("1900-01-01 00:00:00.000"));
//                        }
//                    }
//                    //根据订单总的数量和面积，计算在生产设备及工序上的生产时间    
//                    List<WorkCenterScheduling> lists_ws = new List<WorkCenterScheduling>();

//                    //把车间数据、设备数据、班次数据一次性加载出来
//                    foreach (OrderScheduling os in lists_os)
//                    {
//                        #region 获取工序对应的设备产能,每条生产线
//                        Guid WorkFlowID = os.WorkFlowID;//工序ID

//                        WorkFlow wf = op.Client.GetWorkFlow(SenderUser, WorkFlowID);

//                        SearchWorkCenterArgs wc_args = new SearchWorkCenterArgs();
//                        wc_args.WorkFlowID = WorkFlowID;
//                        wc_args.WorkingLineID = new Guid(WorkingLineID);


//                        SearchResult sr_wc = op.Client.SearchWorkCenter(SenderUser, wc_args);

//                        if (sr_wc.Total == 0)
//                        {
//                            throw new PException("【{0}】的【{1}】工序未设置生产设备或生产设备产能为0。", wl.WorkingLineName, wf.WorkFlowName);
//                        }

//                        int MaxCapacity = 0;
//                        string CountCapacityType = "";
//                        //生产设备列表
//                        List<WorkCenter> wclists = new List<WorkCenter>();
//                        //多台设备
//                        Guid WorkShopID = Guid.Empty;
//                        foreach (DataRow wc_row in sr_wc.DataSet.Tables[0].Rows)
//                        {
//                            MaxCapacity += int.Parse(wc_row["MaxCapacity"].ToString()); //最大产能  
//                            CountCapacityType = wc_row["CountCapacityType"].ToString();
//                            WorkShopID = Guid.Parse(wc_row["WorkShopID"].ToString());
//                            WorkCenter wc = op.Client.GetWorkCenter(SenderUser, Guid.Parse(wc_row["WorkCenterID"].ToString()));
//                            if (wc != null)
//                            {
//                                wclists.Add(wc);
//                            }
//                        }
//                        #endregion
//                        #region 工作班次
//                        //获取生产线(生产车间)对应的班次工作时间（设备的生产时间)
//                        SearchWorkShift2WorkShopArgs sws_args = new SearchWorkShift2WorkShopArgs();
//                        sws_args.WorkShopID = WorkShopID;
//                        SearchResult sws_sr = op.Client.SearchWorkShift2WorkShop(SenderUser, sws_args);
//                        if (sws_sr.Total == 0)
//                        {
//                            throw new PException("【{0}】的【{1}】工序未设置工作时间或班次。", wl.WorkingLineName, wf.WorkFlowName);
//                        }
//                        int hours = 0;
//                        DateTime Started = DateTime.MaxValue;
//                        DateTime Ended = DateTime.MinValue;
//                        foreach (DataRow rw in sws_sr.DataSet.Tables[0].Rows)
//                        {
//                            DateTime started = DateTime.Parse(rw["Started"].ToString());
//                            DateTime ended = DateTime.Parse(rw["Ended"].ToString());
//                            if (ended < started)
//                            {
//                                ended = ended.AddDays(1);
//                            }
//                            if (Started > started)
//                            {
//                                Started = started;
//                            }
//                            if (ended > Ended)
//                            {
//                                Ended = ended;
//                            }
//                            hours += (ended - started).Hours;
//                        }
//                        #endregion
//                        #region 订单生产排产及设备排产

//                        //工序生产时长：生产量除以产能（小时），取整
//                        switch (CountCapacityType)
//                        {
//                            case "L"://按长度计算产能
//                                os.ProductionPeriod = (os.TotalLength / (MaxCapacity * hours * 1.0M));
//                                break;
//                            case "A"://按面积计算产能
//                                os.ProductionPeriod = (os.TotalAreal / (MaxCapacity * hours * 1.0M));
//                                break;
//                            case "Q"://按板件数量计算产能
//                                os.ProductionPeriod = (os.TotalQty / (MaxCapacity * hours * 1.0M));
//                                break;
//                            default:
//                                os.ProductionPeriod = os.TotalAreal / (MaxCapacity * hours * 1.0M);
//                                break;
//                        }

//                        //需要提前一天排产                            
//                        WorkCenterScheduling wcs = op.Client.GetLastWorkCenterSchedulingByWorkCenterID(SenderUser, wclists[0].WorkCenterID);
//                        DateTime MadeStarted;
//                        if (wcs == null)
//                        {
//                            MadeStarted = DateTime.Now.Date.AddDays(1).AddHours(8); //开始时间
//                        }
//                        else
//                        {
//                            MadeStarted = wcs.Ended;
//                        }
//                        wcs = new WorkCenterScheduling();
//                        wcs.WorkID = Guid.NewGuid();
//                        wcs.WorkCenterID = wclists[0].WorkCenterID;
//                        wcs.Status = "N";
//                        wcs.BattchNum = "";
//                        wcs.Started = MadeStarted;


//                        //计算结束时间
//                        int Days = (int)os.ProductionPeriod; //生产天数
//                        double Hours = (double)(os.ProductionPeriod - Days) * hours;
//                        wcs.Ended = wcs.Started.AddDays(Days);

//                        //如果生产时间不在工作时间，则排产时间需要安排到下一工作时间段
//                        if (wcs.Ended.AddHours(Hours) > wcs.Ended.Date.AddHours(Ended.Hour))
//                        {
//                            //计算上一工作日的下班时间与下一工作时间的上班时间差                                
//                            //下一工作日的上班时间
//                            Started = Started.AddDays(1);
//                            int SplitHour = (Started - Ended).Hours;
//                            wcs.Ended = wcs.Ended.AddHours(Hours + SplitHour);
//                        }
//                        else
//                        {
//                            wcs.Ended = wcs.Ended.AddHours(Hours);
//                        }
//                        os.Estimated = wcs.Ended;    //预计生产结束时间                                
//                        #endregion

//                        lists_ws.Add(wcs);
//                    }


//                    if (lists_os.Count > 0)
//                    {
//                        string tmp = BJidStr;
//                    }

//                    using (Trans t = new Trans())
//                    {
//                        try
//                        {
//                            D1(t, batchNum, BJidStr);
//                            foreach (var item in ows)
//                            {
//                                D2(t, item);
//                            }
//                            foreach (var item in lists_os)
//                            {
//                                D3(t, item);
//                            }
//                            t.Commit();
//                            WriteMessage(1, "排产成功！");
//                            //Response.Write("{\"isOk\":1,}");
//                            //WriteMessage(1, "排产成功！");
//                        }
//                        catch (Exception ex)
//                        {
//                            PLogger.LogError(ex);
//                            Response.Write(ex.Message);
//                            t.RollBack();
//                        }
//                    }
//                    D4(BJidStr);
//                    #endregion

//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }

//        private void D4(string BJidStr)
//        {
//            Database db = new Database("BE_OrderDetail_Proc", "D4", 0, 0, "", "", BJidStr);
//            int result = db.ExecuteNoQuery();
//        }

//        public void D1(Trans t, string batchNum, string BJidStr)
//        {
//            Database db = new Database();
//            DbCommand cmd = db.GetStoredProcCommond("BE_OrderDetail_Proc");
//            db.AddInParameter(cmd, "@Operate", DbType.String, "UPBATCHNUMBYITEMIDS");
//            db.AddInParameter(cmd, "@I1", DbType.Int32, 0);
//            db.AddInParameter(cmd, "@I2", DbType.Int32, 0);
//            db.AddInParameter(cmd, "@S1", DbType.String, batchNum);
//            db.AddInParameter(cmd, "@S2", DbType.String, "");
//            db.AddInParameter(cmd, "@S3", DbType.String, BJidStr);

//            if (t == null) db.ExecuteNonQuery(cmd);
//            else db.ExecuteNonQuery(cmd, t);
//        }
//        public void D2(Trans t, OrderWorkFlow ow)
//        {
//            string temp =
//                ow.WorkingID.ToString() + "@" +
//                ow.OrderID.ToString() + "@" +
//                ow.ItemID.ToString() + "@" +
//                ow.WorkFlowNo.ToString() + "@" +
//                ow.SourceWorkFlowID.ToString() + "@" +
//                ow.Action.ToString() + "@" +
//                ow.TargetWorkFlowID.ToString() + "@" +
//                ow.TotalQty.ToString() + "@" +
//                ow.BatchNum.ToString();

//            Database db = new Database();
//            DbCommand cmd = db.GetStoredProcCommond("BE_OrderWorkFlow_Proc");
//            db.AddInParameter(cmd, "@Operate", DbType.String, "ADDOW");
//            db.AddInParameter(cmd, "@I1", DbType.Int32, 0);
//            db.AddInParameter(cmd, "@I2", DbType.Int32, 0);
//            db.AddInParameter(cmd, "@S1", DbType.String, "");
//            db.AddInParameter(cmd, "@S2", DbType.String, "");
//            db.AddInParameter(cmd, "@S3", DbType.String, temp.ToUpper());

//            if (t == null) db.ExecuteNonQuery(cmd);
//            else db.ExecuteNonQuery(cmd, t);

//        }
//        public void D3(Trans t, OrderScheduling os)
//        {
//            string temp =
//                os.MadeID.ToString() + "@" +
//                os.OrderID.ToString() + "@" +
//                os.CabinetID.ToString() + "@" +
//                os.BattchNum.ToString() + "@" +
//                os.BatchNum.ToString() + "@" +
//                os.WorkFlowID.ToString() + "@" +
//                os.TotalQty.ToString() + "@" +
//                os.MadeTotalQty.ToString() + "@" +
//                os.TotalAreal.ToString() + "@" +
//                os.MadeTotalAreal.ToString() + "@" +
//                os.TotalLength.ToString() + "@" +
//                os.MadeTotalLength.ToString() + "@" +
//                os.Estimated.ToString() + "@" +
//                os.MadeStarted.ToString() + "@" +
//                os.MadeEnded.ToString() + "@" +
//                os.ProductionPeriod.ToString() + "@" +
//                os.Sequence.ToString() + "@" +
//                os.Created.ToString() + "@" +
//                os.CreatedBy.ToString() + "@" +
//                os.Modified.ToString() + "@" +
//                os.ModifiedBy.ToString();

//            Database db = new Database();
//            DbCommand cmd = db.GetStoredProcCommond("BE_OrderScheduling_Proc");
//            db.AddInParameter(cmd, "@Operate", DbType.String, "ADDOS");
//            db.AddInParameter(cmd, "@I1", DbType.Int32, 0);
//            db.AddInParameter(cmd, "@I2", DbType.Int32, 0);
//            db.AddInParameter(cmd, "@S1", DbType.String, "");
//            db.AddInParameter(cmd, "@S2", DbType.String, "");
//            db.AddInParameter(cmd, "@S3", DbType.String, temp.ToUpper());

//            if (t == null) db.ExecuteNonQuery(cmd);
//            else db.ExecuteNonQuery(cmd, t);

//        }



//        private string GetWorkFlowID(string wName)
//        {
//            string wid = "";
//            try
//            {
//                Database db = new Database("BE_WorkFlow_Proc", "GETWFID", 0, 0, wName, "", "");
//                wid = db.ExecuteScalar().ToString();
//            }
//            catch (Exception ex)
//            {

//                PLogger.LogError("【" + wName + "】工序未配置配置，异常信息为" + ex.Message);
//                Response.Write("【" + wName + "】工序未配置配置");
//            }
//            return wid;
//        }
//        public void CreateScheduling_()
//        {
//            try
//            {

//                string IDs = Request["OrderIDs"];
//                string WorkingLineID = Request["WorkingLineID"];
//                if (string.IsNullOrEmpty(IDs))
//                    throw new Exception("请选择待排产的订单。");

//                if (string.IsNullOrEmpty(WorkingLineID))
//                    throw new Exception("请选择需要排产的生产线。");

//                string orderID = Request["OrderID"].ToString();
//                if (string.IsNullOrEmpty(orderID))
//                {
//                    throw new Exception("订单无效");
//                }
//                //Liu①
//                string SchedulingTime = Request["SchedulingTime"].ToString();
//                OrderSchedulingTime OrderSchedulingTime = null;
//                if (!string.IsNullOrEmpty(SchedulingTime))
//                {
//                    OrderSchedulingTime = JSONHelper.FromJson<OrderSchedulingTime>(SchedulingTime);
//                }

//                string[] OrderIDs = IDs.Split(',');
//                using (ProxyBE op = new ProxyBE())
//                {
//                    //Liu①
//                    WorkingLine wl = op.Client.GetWorkingLine(SenderUser, new Guid(WorkingLineID));
//                    if (wl == null)
//                    {
//                        throw new PException("所选择的生产线不存在。 ");
//                    }
//                    //获取排产批次号Liu①
//                    string BatchNum = op.Client.GetBattchNum(SenderUser);
//                    //获取特殊部件工序
//                    // List<SpecialCompanent> lists_SC = op.Client.GetSpecialCompanents(SenderUser, CurrentUser.CompanyID);
//                    foreach (string sOrderID in OrderIDs)
//                    {
//                        //Liu①
//                        Guid OrderID = Guid.Parse(sOrderID);
//                        //Liu①
//                        Order order = op.Client.GetOrder(SenderUser, OrderID);


//                        //板件信息Liu①
//                        List<OrderDetail> subOrders = op.Client.GetOrderDetails(SenderUser, OrderID);

//                        //板件生产工序
//                        List<OrderWorkFlow> ows = new List<OrderWorkFlow>();
//                        //订单生产时间计划表
//                        List<OrderScheduling> lists_os = new List<OrderScheduling>();
//                        //包装数据
//                        List<PackageDetail> list_PackageDetails = new List<PackageDetail>();

//                        #region  排除移门数据
//                        //List<Category> doors_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "OptimizeType");
//                        //foreach (Category item in doors_items)
//                        //{
//                        //    if (item.CategoryName.Contains("Y"))
//                        //    {
//                        //        subOrders.RemoveAll(p => p.ItemName.Contains(item.CategoryName));
//                        //    }
//                        //}
//                        #endregion

//                        #region 所有工件都需要包装,除了移门数据
//                        //设置板件生产工序
//                        foreach (OrderDetail subOrder in subOrders)
//                        {
//                            #region 生成包装数据
//                            for (int i = 0; i < subOrder.Qty; i++)
//                            {
//                                PackageDetail packageDetail = new PackageDetail();
//                                packageDetail.DetailID = Guid.NewGuid();
//                                packageDetail.ItemID = subOrder.ItemID;
//                                packageDetail.BattchNo = BatchNum;
//                                packageDetail.Qty = 1;
//                                packageDetail.PakageID = Guid.Empty;
//                                packageDetail.LayerNum = 0;
//                                packageDetail.IsPakaged = false;
//                                packageDetail.IsOptimized = false;
//                                packageDetail.IsPlanning = true;
//                                packageDetail.IsDisabled = false;
//                                list_PackageDetails.Add(packageDetail);
//                            }
//                            #endregion
//                        }
//                        #endregion

//                        #region 加工工序：排除做库存的部件
//                        //List<OrderDetail> packages = new List<OrderDetail>();
//                        //List<Category> storage_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "StorageMaterials");
//                        //foreach (Category item in storage_items)
//                        //{
//                        //    //把库存件直接加入包装工件清单中
//                        //    packages.AddRange(subOrders.FindAll(p => p.ItemName.Contains(item.CategoryName)));
//                        //    subOrders.RemoveAll(p => p.ItemName.Contains(item.CategoryName));
//                        //}
//                        #endregion

//                        #region 加工工序：排除发外生产的部件
//                        //List<Category> Outsourcing_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "OutSourcingMaterials");
//                        //foreach (Category item in Outsourcing_items)
//                        //{
//                        //    //把外购件直接加入包装工件清单中
//                        //    packages.AddRange(subOrders.FindAll(p => p.ItemName.Contains(item.CategoryName)));
//                        //    subOrders.RemoveAll(p => p.ItemName.Contains(item.CategoryName));

//                        //    //按材质颜色抓取
//                        //    packages.AddRange(subOrders.FindAll(p => p.MaterialType.Contains(item.CategoryName)));
//                        //    subOrders.RemoveAll(p => p.MaterialType.Contains(item.CategoryName));

//                        //}
//                        #endregion

//                        if (subOrders.Count == 0)
//                        {
//                            continue;
//                        }

//                        #region 生成所有板件的生产工序
//                        //加入最后完成工序;                
//                        SpecialCompanent2WorkFlow finish_step = new SpecialCompanent2WorkFlow();
//                        finish_step.Sequence = 999;
//                        finish_step.WorkFlowID = Guid.Empty;

//                        //设置板件生产工序
//                        foreach (OrderDetail subOrder in subOrders)
//                        {
//                            OrderWorkFlow ow = new OrderWorkFlow();
//                            string workFlows = "开料,封边,铣型,打孔,检验,美容,包装,入库,发货";
//                            string[] arrWF = workFlows.Split(',');
//                            //第一步：开料
//                            for (int z = 0; z < arrWF.Length - 1; z++)
//                            {
//                                ow = new OrderWorkFlow();
//                                ow.WorkingID = Guid.NewGuid();
//                                ow.ItemID = subOrder.ItemID;
//                                ow.OrderID = subOrder.OrderID;
//                                ow.WorkFlowNo = z + 1;
//                                ow.Action = arrWF[z];
//                                ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(arrWF[z]));
//                                ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(arrWF[z + 1]));
//                                ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                                ow.MadeQty = 0;
//                                ows.Add(ow);

//                                //计算订单工序总板件及面积
//                                SetOrderScheduling(lists_os, BatchNum, subOrder.CabinetID, subOrder.OrderID, ow.SourceWorkFlowID, ow.TotalQty, subOrder.MadeLength * subOrder.MadeWidth * subOrder.Qty, (subOrder.MadeLength + subOrder.MadeWidth) * 2 * subOrder.Qty, DateTime.Parse("1900-01-01 00:00:00.000"), DateTime.Parse("1900-01-01 00:00:00.000"));
//                            }
//                        }

//                        //把外购的工件和做库存的部件加到包装工序当中
//                        #region
//                        //string PackageFlows = "包装,完成";
//                        //string[] pkWF = PackageFlows.Split(',');
//                        ////第一步：包装
//                        //foreach (OrderDetail suborder in packages)
//                        //{
//                        //    for (int z = 0; z < pkWF.Length - 1; z++)
//                        //    {
//                        //        OrderWorkFlow ow = new OrderWorkFlow();
//                        //        ow.WorkingID = Guid.NewGuid();
//                        //        ow.ItemID = suborder.ItemID;
//                        //        ow.OrderID = suborder.OrderID;
//                        //        ow.WorkFlowNo = z + 1;
//                        //        ow.Action = pkWF[z];
//                        //        ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(pkWF[z]));
//                        //        ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(pkWF[z + 1]));
//                        //        ow.TotalQty = Convert.ToInt32(suborder.Qty);
//                        //        ow.MadeQty = 0;
//                        //        ows.Add(ow);
//                        //        //计算订单工序总板件及面积
//                        //        SetOrderScheduling(lists_os, BatchNum, suborder.OrderID, ow.SourceWorkFlowID, ow.TotalQty, suborder.MadeLength * suborder.MadeWidth * suborder.Qty, (suborder.MadeLength + suborder.MadeWidth) * 2 * suborder.Qty);
//                        //    }
//                        //}
//                        #endregion
//                        #endregion

//                        //根据订单总的数量和面积，计算在生产设备及工序上的生产时间    
//                        List<WorkCenterScheduling> lists_ws = new List<WorkCenterScheduling>();

//                        //把车间数据、设备数据、班次数据一次性加载出来
//                        foreach (OrderScheduling os in lists_os)
//                        {
//                            #region 获取工序对应的设备产能,每条生产线
//                            Guid WorkFlowID = os.WorkFlowID;//工序ID

//                            WorkFlow wf = op.Client.GetWorkFlow(SenderUser, WorkFlowID);

//                            SearchWorkCenterArgs wc_args = new SearchWorkCenterArgs();
//                            wc_args.WorkFlowID = WorkFlowID;
//                            wc_args.CompanyID = CurrentUser.CompanyID;
//                            wc_args.WorkingLineID = new Guid(WorkingLineID);


//                            SearchResult sr_wc = op.Client.SearchWorkCenter(SenderUser, wc_args);

//                            if (sr_wc.Total == 0)
//                            {
//                                throw new PException("【{0}】的【{1}】工序未设置生产设备或生产设备产能为0。", wl.WorkingLineName, wf.WorkFlowName);
//                            }

//                            int MaxCapacity = 0;
//                            string CountCapacityType = "";
//                            //生产设备列表
//                            List<WorkCenter> wclists = new List<WorkCenter>();
//                            //多台设备
//                            Guid WorkShopID = Guid.Empty;
//                            foreach (DataRow wc_row in sr_wc.DataSet.Tables[0].Rows)
//                            {
//                                MaxCapacity += int.Parse(wc_row["MaxCapacity"].ToString()); //最大产能  
//                                CountCapacityType = wc_row["CountCapacityType"].ToString();
//                                WorkShopID = Guid.Parse(wc_row["WorkShopID"].ToString());
//                                WorkCenter wc = op.Client.GetWorkCenter(SenderUser, Guid.Parse(wc_row["WorkCenterID"].ToString()));
//                                if (wc != null)
//                                {
//                                    wclists.Add(wc);
//                                }
//                            }
//                            #endregion

//                            #region 工作班次
//                            //获取生产线(生产车间)对应的班次工作时间（设备的生产时间)
//                            SearchWorkShift2WorkShopArgs sws_args = new SearchWorkShift2WorkShopArgs();
//                            sws_args.WorkShopID = WorkShopID;
//                            sws_args.CompanyID = CurrentUser.CompanyID;
//                            SearchResult sws_sr = op.Client.SearchWorkShift2WorkShop(SenderUser, sws_args);
//                            if (sws_sr.Total == 0)
//                            {
//                                throw new PException("【{0}】的【{1}】工序未设置工作时间或班次。", wl.WorkingLineName, wf.WorkFlowName);
//                            }
//                            int hours = 0;
//                            DateTime Started = DateTime.MaxValue;
//                            DateTime Ended = DateTime.MinValue;
//                            foreach (DataRow rw in sws_sr.DataSet.Tables[0].Rows)
//                            {
//                                DateTime started = DateTime.Parse(rw["Started"].ToString());
//                                DateTime ended = DateTime.Parse(rw["Ended"].ToString());
//                                if (ended < started)
//                                {
//                                    ended = ended.AddDays(1);
//                                }
//                                if (Started > started)
//                                {
//                                    Started = started;
//                                }
//                                if (ended > Ended)
//                                {
//                                    Ended = ended;
//                                }
//                                hours += (ended - started).Hours;
//                            }
//                            #endregion

//                            #region 订单生产排产及设备排产

//                            //工序生产时长：生产量除以产能（小时），取整
//                            switch (CountCapacityType)
//                            {
//                                case "L"://按长度计算产能
//                                    os.ProductionPeriod = (os.TotalLength / (MaxCapacity * hours * 1.0M));
//                                    break;
//                                case "A"://按面积计算产能
//                                    os.ProductionPeriod = (os.TotalAreal / (MaxCapacity * hours * 1.0M));
//                                    break;
//                                case "Q"://按板件数量计算产能
//                                    os.ProductionPeriod = (os.TotalQty / (MaxCapacity * hours * 1.0M));
//                                    break;
//                                default:
//                                    os.ProductionPeriod = os.TotalAreal / (MaxCapacity * hours * 1.0M);
//                                    break;
//                            }

//                            //需要提前一天排产                            
//                            WorkCenterScheduling wcs = op.Client.GetLastWorkCenterSchedulingByWorkCenterID(SenderUser, wclists[0].WorkCenterID);
//                            DateTime MadeStarted;
//                            if (wcs == null)
//                            {
//                                MadeStarted = DateTime.Now.Date.AddDays(1).AddHours(8); //开始时间
//                            }
//                            else
//                            {
//                                MadeStarted = wcs.Ended;
//                            }
//                            wcs = new WorkCenterScheduling();
//                            wcs.WorkID = Guid.NewGuid();
//                            wcs.WorkCenterID = wclists[0].WorkCenterID;
//                            wcs.Status = "N";
//                            wcs.BattchNum = BatchNum;
//                            wcs.Started = MadeStarted;


//                            //计算结束时间
//                            int Days = (int)os.ProductionPeriod; //生产天数
//                            double Hours = (double)(os.ProductionPeriod - Days) * hours;
//                            wcs.Ended = wcs.Started.AddDays(Days);

//                            //如果生产时间不在工作时间，则排产时间需要安排到下一工作时间段
//                            if (wcs.Ended.AddHours(Hours) > wcs.Ended.Date.AddHours(Ended.Hour))
//                            {
//                                //计算上一工作日的下班时间与下一工作时间的上班时间差                                
//                                //下一工作日的上班时间
//                                Started = Started.AddDays(1);
//                                int SplitHour = (Started - Ended).Hours;
//                                wcs.Ended = wcs.Ended.AddHours(Hours + SplitHour);
//                            }
//                            else
//                            {
//                                wcs.Ended = wcs.Ended.AddHours(Hours);
//                            }
//                            os.Estimated = wcs.Ended;    //预计生产结束时间                                
//                            #endregion
//                            lists_ws.Add(wcs);
//                        }

//                        //排产时间
//                        if (StringExtensions.StringEquals(orderID, OrderID.ToString()))
//                        {
//                            if (lists_os.Count > 0 && OrderSchedulingTime != null)
//                            {
//                                SetOrderScheduling(lists_os, OrderSchedulingTime);
//                            }
//                        }

//                        order.BattchNum = BatchNum;
//                        //order.Status = "M"; //待生产
//                        order.Status = "P"; //生产中
//                        order.StepNo++;

//                        //订单日志
//                        OrderLog log = new OrderLog();
//                        log.LogID = Guid.NewGuid();
//                        log.OrderID = order.OrderID;
//                        log.LogType = "订单排产";
//                        log.Remark = "完成排产";
//                        SaveOrderArgs so_args = new SaveOrderArgs();

//                        //流程步骤
//                        OrderTask ot = new OrderTask();
//                        ot.CurrentStep = "订单排产";
//                        ot.Action = "排产完成,生产中";
//                        ot.ActionRemarksType = "排产组操作";
//                        ot.ActionRemarks = "排产完成,生产中";
//                        ot.Resource = "排产组";
//                        ot.NextResources = "";
//                        ot.NextStep = "生产中";
//                        so_args.OrderTask = ot;

//                        so_args.Order = order;
//                        so_args.OrderLog = log;
//                        so_args.OrderWorkFlows = ows;
//                        so_args.OrderSchedulings = lists_os;
//                        so_args.WorkCenterSchedulings = lists_ws;
//                        so_args.PackageDetails = list_PackageDetails;
//                        op.Client.SaveOrder(SenderUser, so_args);
//                        //排产完成后，生成批次顺序
//                        op.Client.UpdateOrderBattchIndex(SenderUser, BatchNum);
//                    }
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        public void SetOrderScheduling(List<OrderScheduling> list_os, string BatchNum, Guid WorkFlowID, OrderDetail detail)
//        {
//            OrderScheduling os = list_os.Find(item => item.CabinetID == detail.CabinetID && item.WorkFlowID == WorkFlowID);
//            if (os == null)
//            {
//                os = new OrderScheduling();
//                os.MadeID = Guid.NewGuid();
//                os.BattchNum = BatchNum;
//                os.OrderID = detail.OrderID;
//                os.CabinetID = detail.CabinetID;
//                os.WorkFlowID = WorkFlowID;
//                os.MadeTotalAreal = 0;
//                os.MadeTotalLength = 0;
//                os.MadeTotalQty = 0;
//                os.Sequence = list_os.Count;
//                list_os.Add(os);
//            }
//            os.TotalQty += Convert.ToInt32(detail.Qty);
//            os.TotalLength += (detail.MadeLength + detail.MadeWidth) * 2 * detail.Qty * 0.001M; //订单板件总长度
//            os.TotalAreal += detail.MadeLength * detail.MadeWidth * detail.Qty * 0.000001M;   //订单板件总面积
//        }

//        #region 设置工序排产时间
//        public void SetOrderScheduling(List<OrderScheduling> OrderSchedulings, OrderSchedulingTime OrderSchedulingTime)
//        {
//            using (ProxyBE p = new ProxyBE())
//            {
//                #region 八大工序
//                foreach (OrderScheduling item in OrderSchedulings)
//                {
//                    WorkFlow workFlow = p.Client.GetWorkFlow(SenderUser, item.WorkFlowID);
//                    ///备料
//                    if (StringExtensions.StringEquals(workFlow.WorkFlowName, OrderSchedulingTime.MaterialMadeName))
//                    {
//                        item.MadeStarted = DateTime.Parse(OrderSchedulingTime.MaterialMadeStarted);
//                        item.MadeEnded = DateTime.Parse(OrderSchedulingTime.MaterialMadeEnded);
//                        continue;
//                    }
//                    ///木工                            
//                    if (StringExtensions.StringEquals(workFlow.WorkFlowName, OrderSchedulingTime.WoodMadeName))
//                    {
//                        item.MadeStarted = DateTime.Parse(OrderSchedulingTime.WoodMadeStarted);
//                        item.MadeEnded = DateTime.Parse(OrderSchedulingTime.WoodMadeEnded);
//                        continue;
//                    }
//                    ///木检
//                    if (StringExtensions.StringEquals(workFlow.WorkFlowName, OrderSchedulingTime.DetectMadeName))
//                    {
//                        item.MadeStarted = DateTime.Parse(OrderSchedulingTime.DetectMadeStarted);
//                        item.MadeEnded = DateTime.Parse(OrderSchedulingTime.DetectMadeEnded);
//                        continue;
//                    }
//                    ///油漆
//                    if (StringExtensions.StringEquals(workFlow.WorkFlowName, OrderSchedulingTime.PackagMadeName))
//                    {
//                        item.MadeStarted = DateTime.Parse(OrderSchedulingTime.PackagMadeStarted);
//                        item.MadeEnded = DateTime.Parse(OrderSchedulingTime.PackagMadeEnded);
//                        continue;
//                    }
//                    ///品管
//                    if (StringExtensions.StringEquals(workFlow.WorkFlowName, OrderSchedulingTime.PrisonMadeName))
//                    {
//                        item.MadeStarted = DateTime.Parse(OrderSchedulingTime.PrisonMadeStarted);
//                        item.MadeEnded = DateTime.Parse(OrderSchedulingTime.PrisonMadeEnded);
//                        continue;
//                    }
//                    ///包装
//                    if (StringExtensions.StringEquals(workFlow.WorkFlowName, OrderSchedulingTime.PaintMadeName))
//                    {
//                        item.MadeStarted = DateTime.Parse(OrderSchedulingTime.PaintMadeStarted);
//                        item.MadeEnded = DateTime.Parse(OrderSchedulingTime.PackagMadeEnded);
//                        continue;
//                    }
//                    ///入库
//                    if (StringExtensions.StringEquals(workFlow.WorkFlowName, OrderSchedulingTime.WarehousMadeName))
//                    {
//                        item.MadeStarted = DateTime.Parse(OrderSchedulingTime.WarehousMadeStarted);
//                        item.MadeEnded = DateTime.Parse(OrderSchedulingTime.WarehousMadeEnded);
//                        continue;
//                    }
//                }
//                #endregion
//            }
//        }
//        #endregion
//        #region 设置工序
//        public void SetOrderScheduling(List<OrderScheduling> list_os, string BatchNum, Guid CabinetID, Guid OrderID, Guid WorkFlowID, int Qty, decimal Areal, decimal Length, DateTime MadeStarted, DateTime MadeEnded)
//        {
//            //OrderScheduling os = list_os.Find(item => item.OrderID == OrderID && item.WorkFlowID == WorkFlowID);
//            OrderScheduling os = list_os.Find(item => item.BatchNum == BatchNum && item.WorkFlowID == WorkFlowID);
//            if (os == null)
//            {
//                os = new OrderScheduling();
//                os.MadeID = Guid.NewGuid();
//                os.BattchNum = BatchNum;
//                os.BatchNum = BatchNum;
//                os.OrderID = OrderID;
//                os.CabinetID = CabinetID;
//                os.WorkFlowID = WorkFlowID;
//                os.MadeTotalAreal = 0;
//                os.MadeTotalLength = 0;
//                os.MadeTotalQty = 0;
//                os.Sequence = list_os.Count;

//                os.MadeStarted = MadeStarted;
//                os.MadeEnded = MadeEnded;
//                os.Created = DateTime.Now;
//                os.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
//                os.Modified = DateTime.Now;
//                os.ModifiedBy = SenderUser.UserCode + "." + SenderUser.UserName;
//                list_os.Add(os);
//            }
//            os.TotalQty += Qty;
//            os.TotalLength += Length * 0.001M; //订单板件总长度
//            os.TotalAreal += Areal * 0.000001M;   //订单板件总面积
//        }
//        #endregion
//        /// <summary>
//        /// 导入五金BOM
//        /// </summary>
//        /// <param name="savepath"></param>
//        /// <param name="OrderID"></param>
//        /// <param name="CabinetID"></param>
//        /// <returns></returns>
//        private List<Order2Hardware> ImportHardwareExcel(string savepath, Guid OrderID, Guid CabinetID)
//        {
//            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + savepath + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=2'";
//            DataSet ImportDataSet;

//            List<Order2Hardware> subOrders = new List<Order2Hardware>();
//            using (OleDbConnection conn = new OleDbConnection(strConn))
//            {
//                conn.Open();
//                DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
//                string tableName = schemaTable.Rows[0][2].ToString().Trim();
//                string strExcel = string.Format("select * from [{0}]", tableName);
//                OleDbDataAdapter myCommand = null;
//                myCommand = new OleDbDataAdapter(strExcel, strConn);
//                ImportDataSet = new DataSet();
//                myCommand.Fill(ImportDataSet, "tb");
//            }
//            DataRow row = ImportDataSet.Tables[0].Rows[0];
//            int index = 1;
//            List<Material> materials = new List<Material>();
//            using (ProxyBE p = new ProxyBE())
//            {
//                materials = p.Client.GetAllMaterials(SenderUser);
//            }

//            #region 表头处理
//            ExcelColumName Columns = new ExcelColumName();
//            foreach (DataColumn name in ImportDataSet.Tables[0].Columns)
//            {
//                //产品编号
//                if ("物料编码,产品编号,产品编码".Contains(name.ColumnName))
//                {
//                    Columns.MaterialCode = name.ColumnName;
//                }
//                else if ("物料名称,产品名称".Contains(name.ColumnName))
//                {
//                    Columns.MaterialName = name.ColumnName;
//                }
//                else if ("长度".Contains(name.ColumnName))
//                {
//                    Columns.MaterialType = name.ColumnName;
//                }
//                else if ("类型".Contains(name.ColumnName))
//                {
//                    Columns.MaterialCategory = name.ColumnName;
//                }
//                //备注
//                else if ("备注".Contains(name.ColumnName))
//                {
//                    Columns.Remarks = name.ColumnName;
//                }
//                //备注
//                else if ("单位".Contains(name.ColumnName))
//                {
//                    Columns.Unit = name.ColumnName;
//                }
//                //数量
//                else if ("数量,配件用量".Contains(name.ColumnName))
//                {
//                    Columns.Qty = name.ColumnName;
//                }
//            }
//            #endregion
//            //产品名称
//            string CabinetName = Path.GetFileNameWithoutExtension(savepath).Replace("五金BOM-", "");
//            foreach (DataRow rw in ImportDataSet.Tables[0].Rows)
//            {
//                string qty = GetStringByDataRow(rw, Columns.Qty);
//                if (qty == "")
//                    break;
//                Order2Hardware subOrderHardware = new Order2Hardware();
//                subOrderHardware.ItemID = Guid.NewGuid();
//                subOrderHardware.OrderID = OrderID;
//                subOrderHardware.CabinetID = CabinetID;
//                subOrderHardware.BarcodeNo = GetStringByDataRow(rw, Columns.BarcodeNo);
//                subOrderHardware.HardwareName = GetStringByDataRow(rw, Columns.MaterialName);
//                subOrderHardware.HardwareCategory = GetStringByDataRow(rw, Columns.MaterialCategory);
//                subOrderHardware.Style = GetStringByDataRow(rw, Columns.MaterialType);
//                subOrderHardware.Unit = GetStringByDataRow(rw, Columns.Unit);
//                subOrderHardware.Qty = int.Parse(qty);
//                //subOrderHardware.CabinetNum = CabinetName;
//                subOrderHardware.Remarks = GetStringByDataRow(rw, Columns.Remarks);
//                subOrders.Add(subOrderHardware);
//                index++;
//            }
//            return subOrders;
//        }
//        /// <summary>
//        /// 导入板件BOM
//        /// </summary>
//        /// <param name="FileName"></param>
//        /// <param name="OrderID"></param>
//        /// <param name="ows"></param>
//        /// <returns></returns>
//        private List<OrderDetail> ImportExcel(string FileName, Guid OrderID, ref Order2Cabinet order2Cabinet, ref List<OrderWorkFlow> ows)
//        {
//            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + FileName + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=2'";
//            DataSet ImportDataSet;

//            List<OrderDetail> subOrders = new List<OrderDetail>();
//            using (OleDbConnection conn = new OleDbConnection(strConn))
//            {
//                conn.Open();
//                DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
//                string tableName = schemaTable.Rows[0][2].ToString().Trim();

//                string strExcel = string.Format("select * from [{0}]", tableName);
//                OleDbDataAdapter myCommand = null;
//                myCommand = new OleDbDataAdapter(strExcel, strConn);
//                ImportDataSet = new DataSet();
//                myCommand.Fill(ImportDataSet, "tb");
//            }
//            DataRow row = ImportDataSet.Tables[0].Rows[0];
//            int index = 1;
//            List<Material> materials = new List<Material>();

//            using (ProxyBE p = new ProxyBE())
//            {
//                materials = p.Client.GetAllMaterials(SenderUser);

//                #region 表头处理
//                ExcelColumName Columns = new ExcelColumName();
//                foreach (DataColumn name in ImportDataSet.Tables[0].Columns)
//                {
//                    //板件编号
//                    if ("板件编号,板件ID,条码编号,条码,条形码，条形码1".Contains(name.ColumnName))
//                    {
//                        Columns.BarcodeNo = name.ColumnName;
//                    }
//                    //部件名称
//                    else if ("部件名称,名称,板件名称".Contains(name.ColumnName))
//                    {
//                        Columns.ItemName = name.ColumnName;
//                        Columns.FrontLabel = name.ColumnName;
//                    }
//                    //部件编号
//                    else if ("部件编号,部件编码,板件编码".Contains(name.ColumnName))
//                    {
//                        Columns.MaterialCode = name.ColumnName;
//                    }
//                    //材质颜色
//                    else if ("材质,材料,材质颜色".Contains(name.ColumnName))
//                    {
//                        Columns.MaterialName = name.ColumnName;
//                    }
//                    //颜色
//                    else if ("颜色".Contains(name.ColumnName))
//                    {
//                        Columns.Color = name.ColumnName;
//                    }
//                    //开料长度
//                    else if ("开料长度,长度,开料长".Contains(name.ColumnName))
//                    {
//                        Columns.MadeLength = name.ColumnName;
//                    }
//                    //开料宽度
//                    else if ("开料宽度,宽度,开料宽".Contains(name.ColumnName))
//                    {
//                        Columns.MadeWidth = name.ColumnName;
//                    }
//                    //开料厚度
//                    else if ("开料厚度,厚度".Contains(name.ColumnName))
//                    {
//                        Columns.MadeHeight = name.ColumnName;
//                    }
//                    //成品长度
//                    else if ("成品长度,成型长度,成型长".Contains(name.ColumnName))
//                    {
//                        Columns.EndLength = name.ColumnName;
//                    }
//                    //成品宽度
//                    else if ("成品宽度,成型宽度,成品宽".Contains(name.ColumnName))
//                    {
//                        Columns.EndWidth = name.ColumnName;
//                    }
//                    //纹理方向
//                    else if ("纹理方向,纹理,修改纹理".Contains(name.ColumnName))
//                    {
//                        Columns.TextureDirection = name.ColumnName;
//                    }
//                    //生产批次
//                    else if ("代号,生产批次".Contains(name.ColumnName))
//                    {
//                        Columns.MadeBattchNum = name.ColumnName;
//                    }
//                    //产品名称
//                    else if ("柜,柜号，产品名称".Contains(name.ColumnName))
//                    {
//                        Columns.CabinetNum = name.ColumnName;
//                    }
//                    //排孔
//                    else if ("孔,排孔,打孔,排孔信息,打孔信息".Contains(name.ColumnName))
//                    {
//                        Columns.HoleDesc = name.ColumnName;
//                    }
//                    //封边
//                    else if ("封边,封边信息,封边方式,封边描述".Contains(name.ColumnName))
//                    {
//                        Columns.EdgeDesc = name.ColumnName;
//                    }
//                    //正面标签
//                    else if ("正面标签,正面条码".Contains(name.ColumnName))
//                    {
//                        Columns.FrontLabel = name.ColumnName;
//                    }
//                    //反面标签
//                    else if ("反面标签,反面条码,条码2,条形码2".Contains(name.ColumnName))
//                    {
//                        Columns.BackLabel = name.ColumnName;
//                    }
//                    //备注
//                    else if ("工艺备注,备注".Contains(name.ColumnName))
//                    {
//                        Columns.Remarks = name.ColumnName;
//                    }
//                    //数量
//                    else if ("数量,配件用量".Contains(name.ColumnName))
//                    {
//                        Columns.Qty = name.ColumnName;
//                    }
//                    //是否异形
//                    else if ("是否异形".Contains(name.ColumnName))
//                    {
//                        Columns.IsSpesial = name.ColumnName;
//                    }
//                    else if ("条码3,条形码3".Contains(name.ColumnName))
//                    {
//                        Columns.ItemType = name.ColumnName;
//                    }
//                }
//                #endregion


//                decimal totalAreal = 0;
//                decimal totalLength = 0;
//                foreach (DataRow rw in ImportDataSet.Tables[0].Rows)
//                {
//                    string qty = GetStringByDataRow(rw, Columns.Qty);
//                    if (qty == "")
//                        break;

//                    OrderDetail subOrder = new OrderDetail();
//                    subOrder.ItemID = Guid.NewGuid();
//                    subOrder.OrderID = OrderID;
//                    subOrder.CabinetID = order2Cabinet.CabinetID;
//                    string barcode = GetStringByDataRow(rw, Columns.BarcodeNo);
//                    if (string.IsNullOrEmpty(barcode))
//                    {
//                        throw new PException("BOM表中的第{0}行的板件条码为空或无效", index);
//                    }
//                    subOrder.BarcodeNo = barcode; //板件条码

//                    OrderDetail temp = p.Client.GetOrderDetailByBarcode(SenderUser, barcode);
//                    if (temp != null && temp.ItemID != subOrder.ItemID)
//                    {
//                        throw new PException("BOM表中的第{0}行的板件条码【{1}】已经存在。", index, barcode);
//                    }

//                    subOrder.ItemName = GetStringByDataRow(rw, Columns.ItemName);   //板件名称
//                    subOrder.ItemIndex = 0;
//                    subOrder.MadeLength = decimal.Parse(GetStringByDataRow(rw, Columns.MadeLength));
//                    subOrder.MadeWidth = decimal.Parse(GetStringByDataRow(rw, Columns.MadeWidth));
//                    subOrder.EndLength = decimal.Parse(GetStringByDataRow(rw, Columns.EndLength));
//                    subOrder.EndWidth = decimal.Parse(GetStringByDataRow(rw, Columns.EndWidth));
//                    string sHeight = GetStringByDataRow(rw, Columns.MadeHeight);
//                    if (sHeight == "")
//                    {
//                        sHeight = GetStringByDataRow(rw, Columns.Color).ToString().Split(' ')[2].Trim();
//                    }
//                    subOrder.MadeHeight = decimal.Parse(sHeight);
//                    if (subOrder.MadeLength >= 200 && subOrder.MadeWidth >= 200 && subOrder.MadeHeight > 9)
//                    {
//                        subOrder.MadeLength += 1;
//                        subOrder.MadeWidth += 1;
//                    }
//                    subOrder.Qty = int.Parse(qty);
//                    subOrder.TextureDirection = GetStringByDataRow(rw, Columns.TextureDirection);
//                    subOrder.MadeBattchNum = GetStringByDataRow(rw, Columns.MadeBattchNum);
//                    subOrder.HoleDesc = GetStringByDataRow(rw, Columns.HoleDesc);
//                    subOrder.Remarks = GetStringByDataRow(rw, Columns.Remarks);
//                    subOrder.EdgeDesc = GetStringByDataRow(rw, Columns.EdgeDesc);
//                    if (GetStringByDataRow(rw, "正面操作") == "是")
//                    {
//                        subOrder.FrontLabel = GetStringByDataRow(rw, Columns.FrontLabel);
//                    }
//                    if (GetStringByDataRow(rw, "背面操作") == "是")
//                    {
//                        subOrder.BackLabel = GetStringByDataRow(rw, Columns.BackLabel);
//                    }

//                    string IsSpecialShap = GetStringByDataRow(rw, Columns.IsSpesial);   //板件是否异形
//                    if (IsSpecialShap == "是" || IsSpecialShap.ToLower() == "true")
//                    {
//                        subOrder.IsSpecialShap = true;
//                    }

//                    #region 材料资料
//                    /*
//                Material m;
//                string MaterialCode = GetStringByDataRow(rw, Columns.MaterialCode);//部件编码
//                string MaterialName = GetStringByDataRow(rw, Columns.MaterialName);//部件编码
//                if (!string.IsNullOrEmpty(MaterialCode))
//                {
//                    m = materials.Find(p => p.MaterialCode == MaterialCode);
//                }
//                else
//                {
//                    m = materials.Find(p => p.MaterialName == MaterialName);
//                }
//                if (m != null)
//                {
//                    subOrder.MaterialID = m.MaterialID;//物料编码
//                }
//                else
//                {
//                    //添加一条新的物料

//                    m = new Material();
//                    m.MaterialID = Guid.NewGuid();
//                    m.CompanyID = CurrentUser.CompanyID;
//                    m.MaterialCode = MaterialCode == "" ? m.MaterialID.ToString().Substring(0, 8) : MaterialCode;
//                    m.MaterialName = GetStringByDataRow(rw, Columns.MaterialName);
//                    m.Category = GetStringByDataRow(rw, Columns.MaterialCategory);
//                    m.SubCategory = "";
//                    string color = GetStringByDataRow(rw, Columns.Color);
//                    m.Color = color;
//                    m.Deepth = (int)subOrder.MadeHeight;
//                    m.ImageUrl = "";
//                    m.Remark = "";
//                    m.SafetyStock_Qty = 0;
//                    m.Style = GetStringByDataRow(rw, Columns.MaterialType);
//                    m.Withholding_Qty = 0;
//                    m.Unit = GetStringByDataRow(rw, Columns.Unit);
//                    SaveMaterialArgs args = new SaveMaterialArgs();
//                    args.Material = m;
//                    using (ProxyBE p = new ProxyBE())
//                    {
//                        p.Client.SaveMaterial(SenderUser, args);
//                    }
//                    subOrder.MaterialID = m.MaterialID;//物料编码
//                }
//                 * 
//                 */
//                    #endregion
//                    subOrder.MaterialType = GetStringByDataRow(rw, Columns.MaterialName);
//                    subOrder.Created = DateTime.Now;
//                    subOrder.ItemType = GetStringByDataRow(rw, Columns.ItemType);
//                    subOrder.PackageCategory = "";
//                    if (subOrder.MadeLength < 500)
//                    {
//                        subOrder.PackageSizeType = "S";
//                    }
//                    else if (subOrder.MadeLength < 1500)
//                    {
//                        subOrder.PackageSizeType = "M";
//                    }
//                    else
//                    {
//                        subOrder.PackageSizeType = "L";
//                    }
//                    //算算面积和周长
//                    totalAreal += subOrder.MadeLength * subOrder.MadeWidth / 1000000 * int.Parse(qty);
//                    totalLength += (subOrder.MadeLength + subOrder.MadeWidth) * 2 / 1000 * int.Parse(qty);
//                    subOrders.Add(subOrder);
//                    index++;

//                    order2Cabinet.TotalAreal = totalAreal;
//                    order2Cabinet.TotalLength = totalLength;
//                }
//            }
//            return subOrders;
//        }
//        /// <summary>
//        /// 导入手工单
//        /// </summary>
//        /// <param name="FileName"></param>
//        /// <param name="OrderID"></param>
//        /// <param name="order2Cabinet"></param>
//        /// <param name="ows"></param>
//        /// <returns></returns>
//        private List<OrderDetail> ImportExcelByHandmade(string FileName, Guid OrderID, ref Order2Cabinet order2Cabinet, ref List<OrderWorkFlow> ows)
//        {
//            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + FileName + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=2'";
//            DataSet ImportDataSet;

//            List<OrderDetail> subOrders = new List<OrderDetail>();
//            using (OleDbConnection conn = new OleDbConnection(strConn))
//            {
//                conn.Open();
//                DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
//                string tableName = schemaTable.Rows[0][2].ToString().Trim();

//                string strExcel = string.Format("select * from [{0}]", tableName);
//                OleDbDataAdapter myCommand = null;
//                myCommand = new OleDbDataAdapter(strExcel, strConn);
//                ImportDataSet = new DataSet();
//                myCommand.Fill(ImportDataSet, "tb");
//            }
//            DataRow row = ImportDataSet.Tables[0].Rows[0];
//            int index = 1;
//            List<Material> materials = new List<Material>();

//            Order order;

//            using (ProxyBE p = new ProxyBE())
//            {
//                materials = p.Client.GetAllMaterials(SenderUser);
//                order = p.Client.GetOrder(SenderUser, OrderID);
//            }


//            #region 表头处理
//            ExcelColumName Columns = new ExcelColumName();
//            foreach (DataColumn name in ImportDataSet.Tables[0].Columns)
//            {
//                //板件编号
//                if ("板件编号,板件ID,条码编号,条码,条形码，条形码1".Contains(name.ColumnName))
//                {
//                    Columns.BarcodeNo = name.ColumnName;
//                }
//                //部件名称
//                else if ("部件名称,名称,板件名称".Contains(name.ColumnName))
//                {
//                    Columns.ItemName = name.ColumnName;

//                }
//                //部件编号
//                else if ("部件编号,部件编码,板件编码".Contains(name.ColumnName))
//                {
//                    Columns.MaterialCode = name.ColumnName;
//                }
//                //材质颜色
//                else if ("材质,材料,材质颜色".Contains(name.ColumnName))
//                {
//                    Columns.MaterialName = name.ColumnName;
//                }
//                //颜色
//                else if ("颜色".Contains(name.ColumnName))
//                {
//                    Columns.Color = name.ColumnName;
//                }
//                //开料长度
//                else if ("开料长度,长度,开料长".Contains(name.ColumnName))
//                {
//                    Columns.MadeLength = name.ColumnName;
//                }
//                //开料宽度
//                else if ("开料宽度,宽度,开料宽".Contains(name.ColumnName))
//                {
//                    Columns.MadeWidth = name.ColumnName;
//                }
//                //开料厚度
//                else if ("开料厚度,厚度".Contains(name.ColumnName))
//                {
//                    Columns.MadeHeight = name.ColumnName;
//                }
//                //成品长度
//                else if ("成品长度,成型长度,成型长".Contains(name.ColumnName))
//                {
//                    Columns.EndLength = name.ColumnName;
//                }
//                //成品宽度
//                else if ("成品宽度,成型宽度,成品宽".Contains(name.ColumnName))
//                {
//                    Columns.EndWidth = name.ColumnName;
//                }
//                //纹理方向
//                else if ("纹理方向,纹理,修改纹理".Contains(name.ColumnName))
//                {
//                    Columns.TextureDirection = name.ColumnName;
//                }
//                //生产批次
//                else if ("代号,生产批次".Contains(name.ColumnName))
//                {
//                    Columns.MadeBattchNum = name.ColumnName;
//                }
//                //产品名称
//                else if ("柜,柜号，产品名称".Contains(name.ColumnName))
//                {
//                    Columns.CabinetNum = name.ColumnName;
//                }
//                //排孔
//                else if ("孔,排孔,打孔,排孔信息,打孔信息".Contains(name.ColumnName))
//                {
//                    Columns.HoleDesc = name.ColumnName;
//                }
//                //封边
//                else if ("封边,封边信息,封边方式,封边描述".Contains(name.ColumnName))
//                {
//                    Columns.EdgeDesc = name.ColumnName;
//                }
//                //正面标签
//                else if ("正面标签,正面条码".Contains(name.ColumnName))
//                {
//                    Columns.FrontLabel = name.ColumnName;
//                }
//                //反面标签
//                else if ("反面标签,反面条码".Contains(name.ColumnName))
//                {
//                    Columns.BackLabel = name.ColumnName;
//                }
//                //备注
//                else if ("工艺备注,备注".Contains(name.ColumnName))
//                {
//                    Columns.Remarks = name.ColumnName;
//                }
//                //数量
//                else if ("数量,配件用量".Contains(name.ColumnName))
//                {
//                    Columns.Qty = name.ColumnName;
//                }
//                //是否异形
//                else if ("是否异形".Contains(name.ColumnName))
//                {
//                    Columns.IsSpesial = name.ColumnName;
//                }
//            }
//            #endregion

//            decimal totalAreal = 0;
//            decimal totalLength = 0;
//            int BarcodeIndex = 1;
//            foreach (DataRow rw in ImportDataSet.Tables[0].Rows)
//            {
//                string qty = GetStringByDataRow(rw, Columns.Qty);
//                if (qty == "")
//                    break;

//                for (int i = 1; i <= int.Parse(qty); i++)
//                {
//                    OrderDetail subOrder = new OrderDetail();
//                    subOrder.ItemID = Guid.NewGuid();
//                    subOrder.OrderID = OrderID;
//                    subOrder.CabinetID = order2Cabinet.CabinetID;
//                    subOrder.BarcodeNo = order.OrderNo + (char)(64 + order2Cabinet.Sequence) + BarcodeIndex.ToString("000");  //板件条码GetStringByDataRow(rw, Columns.BarcodeNo);
//                    BarcodeIndex++;
//                    subOrder.ItemName = GetStringByDataRow(rw, Columns.ItemName);   //板件名称
//                    subOrder.ItemIndex = 0;
//                    subOrder.MadeLength = decimal.Parse(GetStringByDataRow(rw, Columns.MadeLength));
//                    subOrder.MadeWidth = decimal.Parse(GetStringByDataRow(rw, Columns.MadeWidth));
//                    subOrder.EndLength = subOrder.MadeLength + 2;
//                    subOrder.EndWidth = subOrder.MadeWidth + 2;
//                    string sHeight = GetStringByDataRow(rw, Columns.MadeHeight);
//                    if (sHeight == "")
//                    {
//                        sHeight = GetStringByDataRow(rw, Columns.Color).ToString().Split(' ')[2].Trim();
//                    }
//                    subOrder.MadeHeight = decimal.Parse(sHeight);
//                    if (subOrder.MadeLength >= 200 && subOrder.MadeWidth >= 200 && subOrder.MadeHeight > 9)
//                    {
//                        subOrder.MadeLength += 1;
//                        subOrder.MadeWidth += 1;
//                    }
//                    subOrder.Qty = 1;
//                    subOrder.TextureDirection = "";
//                    subOrder.MadeBattchNum = "";
//                    subOrder.HoleDesc = "";
//                    subOrder.Remarks = GetStringByDataRow(rw, Columns.Remarks);
//                    subOrder.EdgeDesc = GetStringByDataRow(rw, Columns.EdgeDesc);
//                    if (GetStringByDataRow(rw, "正面操作") == "是")
//                    {
//                        subOrder.FrontLabel = GetStringByDataRow(rw, Columns.FrontLabel);
//                    }
//                    if (GetStringByDataRow(rw, "背面操作") == "是")
//                    {
//                        subOrder.BackLabel = GetStringByDataRow(rw, Columns.BackLabel);
//                    }

//                    string IsSpecialShap = GetStringByDataRow(rw, Columns.IsSpesial);   //板件名称
//                    if (IsSpecialShap == "是" || IsSpecialShap.ToLower() == "true")
//                    {
//                        subOrder.IsSpecialShap = true;
//                    }
//                    subOrder.MaterialType = GetStringByDataRow(rw, Columns.MaterialName);
//                    subOrder.Created = DateTime.Now;
//                    subOrder.ItemType = "B";//默认为板件
//                    subOrder.PackageCategory = "";
//                    if (subOrder.MadeLength < 500)
//                    {
//                        subOrder.PackageSizeType = "S";
//                    }
//                    else if (subOrder.MadeLength < 1500)
//                    {
//                        subOrder.PackageSizeType = "M";
//                    }
//                    else
//                    {
//                        subOrder.PackageSizeType = "L";
//                    }
//                    //算算面积和周长
//                    totalAreal += subOrder.MadeLength * subOrder.MadeWidth / 1000000 * int.Parse(qty);
//                    totalLength += (subOrder.MadeLength + subOrder.MadeWidth) * 2 / 1000 * int.Parse(qty);
//                    subOrders.Add(subOrder);
//                    index++;

//                    order2Cabinet.TotalAreal = totalAreal;
//                    order2Cabinet.TotalLength = totalLength;
//                }
//            }
//            return subOrders;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="WorkFlowName"></param>
//        /// <returns></returns>
//        private string GetWorkFlowCode(string WorkFlowName)
//        {
//            switch (WorkFlowName)
//            {
//                case "完成":
//                    return Guid.Empty.ToString();
//                case "清洗":
//                    return base.WorkFlow_CleanCode;
//                case "封边":
//                    return base.WorkFlow_EdgedescCode;
//                case "打孔":
//                case "常规打孔":
//                    return base.WorkFlow_NormalDrillingHoleCode;
//                case "常规开槽":
//                    return base.WorkFlow_NormalGroovingCode;
//                case "开料":
//                case "常规开料":
//                    return base.WorkFlow_NormalMadeCode;
//                case "包装":
//                    return base.WorkFlow_PagageCode;
//                case "异形打孔":
//                    return base.WorkFlow_SpecialDrillingHoleCode;
//                case "异形开槽":
//                    return base.WorkFlow_SpecialGroovingCode;
//                case "异形开料":
//                    return base.WorkFlow_SpecialMadeCode;
//                default:
//                    return Guid.Empty.ToString();
//            }
//        }
//        private string GetStringByDataRow(DataRow rw, string columnname)
//        {
//            string str = "";
//            try
//            {
//                if (!string.IsNullOrEmpty(columnname))
//                    str = rw[columnname].ToString().Trim();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return str;
//        }
//        public void GetSpecialCompanents()
//        {
//            try
//            {
//                using (ProxyBE op = new ProxyBE())
//                {
//                    List<SpecialCompanent> lists_sc = op.Client.GetSpecialCompanents(SenderUser);
//                    StringBuilder jsonBuilder = new StringBuilder();
//                    jsonBuilder.Append("[{");
//                    jsonBuilder.Append("\"id\":\"" + Guid.Empty.ToString() + "\"");
//                    jsonBuilder.Append(",\"text\":\"特殊部件列表\"");
//                    jsonBuilder.Append(",\"attributes\":{\"ParentID\":\"" + Guid.Empty.ToString() + "\"}");
//                    if (lists_sc.Count > 0)
//                    {
//                        jsonBuilder.AppendFormat(",\"children\":");
//                        jsonBuilder.Append("[");
//                        foreach (SpecialCompanent item in lists_sc)
//                        {
//                            jsonBuilder.Append("{");
//                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.SpecialID);
//                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.ItemName);
//                            jsonBuilder.Append(",\"attributes\":{\"IsDisabled\":\"" + item.IsDisabled + "\"}");
//                            jsonBuilder.Append("}");
//                            jsonBuilder.Append(",");
//                        }
//                        jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
//                        jsonBuilder.Append("]");
//                    }
//                    jsonBuilder.Append("}]");
//                    Response.Write(jsonBuilder.ToString());
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                throw ex;
//            }
//        }
//        /// <summary>
//        /// 板件扫描
//        /// </summary>
//        public void ScanBarcode()
//        {
//            try
//            {
//                string Barcode = Request["Barcode"].ToString();
//                string WorkShiftID = Request["WorkShiftID"].ToString();
//                string WorkFlowID = Request["WorkFlowID"].ToString();
//                using (ProxyBE p = new ProxyBE())
//                {
//                    OrderDetail orderDetail = p.Client.GetOrderDetailByBarcode(SenderUser, Barcode);
//                    p.Client.ScanBarcode(SenderUser, Barcode, new Guid(WorkShiftID), new Guid(WorkFlowID));
//                    Database db = new Database("BE_Order_Proc", "UPSTATUS", 0, 0, orderDetail.OrderID.ToString(), "P", "");
//                    int result = db.ExecuteNoQuery();
//                    Hashtable ht = new Hashtable();
//                    if (result >= 1)
//                    {
//                        ht.Add("isOk", 1);
//                        ht.Add("OrderID", orderDetail.OrderID);
//                        ht.Add("CabinetID", orderDetail.CabinetID);
//                    }
//                    Response.Write(JSONHelper.ToJson(ht));
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 优化开料
//        /// </summary>
//        public void CreateOptimize()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["BattchNum"]))
//                {
//                    throw new Exception("非法数据请求。提示：批次号无效。");
//                }

//                string pid = Request["pid"];
//                Session[pid] = "0";

//                try
//                {
//                    string sourceFileName = Server.MapPath("/template/mes_out.xls");
//                    string targetFileName = "";
//                    using (ProxyBE p = new ProxyBE())
//                    {
//                        SearchOrderDetailArgs args = new SearchOrderDetailArgs();
//                        args.OrderBy = "[OrderID]";
//                        //按批次导出
//                        string BattchNo = Request["BattchNum"].ToString();
//                        args.BattchCode = BattchNo;
//                        args.OrderStatus = "M";
//                        //排除库存件及外购件
//                        args.RemoveItems = GetRemoveItems();
//                        SearchResult sr = p.Client.SearchOrderDetail(SenderUser, args);
//                        //批次总柜数
//                        int TotalBattchQty = p.Client.GetTotalOrderBattchQty(SenderUser, BattchNo);

//                        targetFileName = Path.Combine(Config.StorageFolder, "temp");
//                        if (!Directory.Exists(targetFileName))
//                        {
//                            Directory.CreateDirectory(targetFileName);
//                        }
//                        targetFileName = Path.Combine(targetFileName, sr.DataSet.Tables[0].Rows[0]["BattchNum"].ToString() + "_排产优化.xls");

//                        if (File.Exists(targetFileName))
//                        {
//                            File.Delete(targetFileName);
//                        }
//                        File.Copy(sourceFileName, targetFileName, true);

//                        //加工文件
//                        SearchOrderProcessFileArgs pfArgs = new SearchOrderProcessFileArgs();
//                        pfArgs.BattchNum = BattchNo;
//                        pfArgs.FileType = new List<string>() { "DXF", "CNC", "ProcessFile" };
//                        SearchResult pfResult = p.Client.SearchOrderProcessFile(SenderUser, pfArgs);

//                        //订单列表
//                        List<Guid> list_OrderIDs = new List<Guid>();
//                        List<Category> category_lists = new List<Category>();
//                        Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, "OptimizeType");
//                        if (category != null)
//                        {
//                            category_lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
//                        }
//                        Dictionary<string, string> conditions = new Dictionary<string, string>();

//                        if (category_lists.Count == 0)
//                        {
//                            conditions.Add("开料", "IsSpecialShap=0");
//                        }
//                        else
//                        {
//                            conditions.Add("异形板", "IsSpecialShap=1"); //先抽异型
//                            var list = category_lists.OrderByDescending(o => o.Sequence); //排序：先挑Y的数据
//                            foreach (Category c in list)
//                            {
//                                if (c.IsDisabled) continue;
//                                string[] CategoryNames = c.CategoryName.Split(',');
//                                string where = " 1=1 and (1>2 ";

//                                if (CategoryNames.Contains("Y"))
//                                {
//                                    where += string.Format(" or ItemName like '{0}%')", c.CategoryName);
//                                }
//                                else if (CategoryNames.Length == 1)
//                                {
//                                    where += string.Format(" or ItemName like '%{0}%') and MadeWidth>=78 and MadeLength>=78", c.CategoryName);
//                                }
//                                else
//                                {
//                                    foreach (string s in CategoryNames)
//                                    {
//                                        if (s.Trim() != "")
//                                        {
//                                            where += string.Format(" or ItemName like '%{0}%'", s);
//                                        }
//                                    }
//                                    where += ") and MadeWidth>=78 and MadeLength>=78";
//                                }
//                                conditions.Add(c.CategoryName, where);
//                            }
//                        }

//                        conditions.Add("小板", "IsSpecialShap=0 and (MadeWidth<78 or MadeLength<78)");
//                        //异形
//                        //conditions.Add("异形板", "IsSpecialShap=1");
//                        conditions.Add("其它", "1=1");
//                        using (FileStream fs = new FileStream(targetFileName, FileMode.Open, FileAccess.Read))
//                        {
//                            #region 导出数据
//                            IWorkbook workbook = new HSSFWorkbook(fs);
//                            ISheet worksheet = workbook.GetSheetAt(0);
//                            int sheet_index = 0;
//                            foreach (string key in conditions.Keys)
//                            {
//                                DataRow[] rows = sr.DataSet.Tables[0].Select(conditions[key]);
//                                if (rows.Length == 0) continue;

//                                #region 填充数据
//                                if (sheet_index >= 1)
//                                {
//                                    worksheet.CopySheet(key + "_优化数据表", true);
//                                }
//                                else
//                                {
//                                    workbook.SetSheetName(sheet_index, key + "_优化数据表");
//                                }

//                                worksheet = workbook.GetSheetAt(sheet_index);
//                                sheet_index++;
//                                #region 清空sheet页数据
//                                int TotalRows = worksheet.LastRowNum;
//                                for (int rownum = 1; rownum <= TotalRows; rownum++)
//                                {
//                                    IRow datarow = worksheet.GetRow(rownum);
//                                    worksheet.RemoveRow(datarow);
//                                }
//                                #endregion

//                                int rows_index = 1;//从第2行开始导入
//                                foreach (DataRow row in rows)
//                                {
//                                    Guid OrderID = new Guid(row["OrderID"].ToString());
//                                    if (!list_OrderIDs.Contains(OrderID))
//                                    {
//                                        list_OrderIDs.Add(OrderID);
//                                    }

//                                    //加工文件
//                                    string dxfFile = "";
//                                    DataRow[] pfrow = pfResult.DataSet.Tables[0].Select(string.Format("FileName like '%{0}%' and OrderID='{1}'", row["BarcodeNo"].ToString(), OrderID));
//                                    if (pfrow.Length > 0)
//                                    {
//                                        dxfFile = pfrow[0]["FilePath"].ToString();
//                                    }

//                                    IRow _row = worksheet.CreateRow(rows_index);                        //表示每循环一次，在Excel中创建一行，并给这一行
//                                    _row.Height = 25 * 20;
//                                    _row.CreateCell(0).SetCellValue(rows_index);                        //序号
//                                    _row.CreateCell(1).SetCellValue(row["ItemName"].ToString());        //板件名称
//                                    _row.CreateCell(2).SetCellValue(row["MaterialType"].ToString());    //材质颜色
//                                    _row.CreateCell(3).SetCellValue(decimal.Parse(row["MadeLength"].ToString()).ToString("#"));      //开料长度
//                                    _row.CreateCell(4).SetCellValue(decimal.Parse(row["MadeWidth"].ToString()).ToString("#"));       //开料宽度
//                                    _row.CreateCell(5).SetCellValue(decimal.Parse(row["MadeHeight"].ToString()).ToString("#"));      //厚度
//                                    _row.CreateCell(6).SetCellValue(decimal.Parse(row["EndLength"].ToString()).ToString("#"));       //成品长度                                    
//                                    _row.CreateCell(7).SetCellValue(decimal.Parse(row["EndWidth"].ToString()).ToString("#"));        //成品宽度
//                                    _row.CreateCell(8).SetCellValue(row["IsSpecialShap"].ToString().ToLower() == "true" ? "是" : "否");//是否异形
//                                    _row.CreateCell(9).SetCellValue(decimal.Parse(row["Qty"].ToString()).ToString("#"));             //数量
//                                    _row.CreateCell(10).SetCellValue(row["TextureDirection"].ToString()); //修改纹理
//                                    _row.CreateCell(11).SetCellValue(row["EdgeDesc"].ToString());        //封边描述
//                                    _row.CreateCell(12).SetCellValue(row["BarcodeNo"].ToString());       //条形码1
//                                    _row.CreateCell(13).SetCellValue("");                                //条形码2
//                                    _row.CreateCell(14).SetCellValue("");                                //条形码3
//                                    _row.CreateCell(15).SetCellValue(row["Remarks"].ToString());        //工艺备注
//                                    _row.CreateCell(16).SetCellValue(dxfFile);                          //保存路径
//                                    _row.CreateCell(17).SetCellValue(row["OrderNo"].ToString());        //订单号
//                                    _row.CreateCell(18).SetCellValue(row["CustomerName"].ToString());   //客户名称
//                                    _row.CreateCell(19).SetCellValue(row["Address"].ToString());        //客户地址 
//                                    _row.CreateCell(20).SetCellValue(row["ShipDate"].ToString());       //交货日期
//                                    _row.CreateCell(21).SetCellValue(row["CabinetName"].ToString());    //产品名称
//                                    _row.CreateCell(22).SetCellValue(row["MaterialStyle"].ToString());  //风格                                    
//                                    _row.CreateCell(23).SetCellValue(row["MaterialCategory"].ToString()); //材质
//                                    _row.CreateCell(24).SetCellValue(row["Color"].ToString());      //颜色
//                                    _row.CreateCell(25).SetCellValue(row["BattchNum"].ToString());      //批次号
//                                    _row.CreateCell(26).SetCellValue(TotalBattchQty);      //批次总柜数
//                                    _row.CreateCell(27).SetCellValue(row["BattchIndex"].ToString());      //批次柜号
//                                    int TotalOrderQty = p.Client.GetTotalOrderCabinetQty(SenderUser, new Guid(row["OrderID"].ToString()));
//                                    _row.CreateCell(28).SetCellValue(TotalOrderQty);      //订单总柜数
//                                    _row.CreateCell(29).SetCellValue(row["Sequence"].ToString());      //当前柜号                                    				
//                                    rows_index++;
//                                }

//                                foreach (DataRow r in rows)
//                                {
//                                    sr.DataSet.Tables[0].Rows.Remove(r);
//                                }
//                                #endregion
//                            }
//                            #endregion
//                            Response.Clear();
//                            HttpContext.Current.Response.Buffer = true;
//                            Response.ContentType = "application/ms-excel";
//                            Response.Charset = "GB2312";
//                            Response.ContentEncoding = Encoding.UTF8;
//                            Response.AppendHeader("content-disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(Path.GetFileName(targetFileName)));
//                            using (MemoryStream ms = new MemoryStream())
//                            {
//                                //将工作簿的内容放到内存流中
//                                workbook.Write(ms);
//                                //将内存流转换成字节数组发送到客户端
//                                Response.BinaryWrite(ms.GetBuffer());
//                                //Response.End();
//                            }

//                            using (MemoryStream ms = new MemoryStream())
//                            {
//                                workbook.Write(ms);
//                                FileStream file = new FileStream(targetFileName, FileMode.Create);
//                                workbook.Write(file);
//                                file.Close();
//                                workbook = null;
//                                ms.Close();
//                                ms.Dispose();
//                            }

//                            //排产完成
//                            foreach (Guid orderid in list_OrderIDs)
//                            {
//                                Order order = p.Client.GetOrder(SenderUser, orderid);
//                                if (order != null)
//                                {
//                                    order.Status = "P";
//                                    order.StepNo++;

//                                    SaveOrderArgs orderArgs = new SaveOrderArgs();
//                                    orderArgs.Order = order;

//                                    //流程步骤
//                                    /*
//                                    OrderTask ot = new OrderTask();
//                                    ot.Action = "订单优化完成，待生产";
//                                    ot.CurrentStep = "订单优化";
//                                    ot.ActionRemarksType = "订单系统操作";
//                                    ot.ActionRemarks = "订单优化完成，待生产";
//                                    ot.Resource = "订单排产组";
//                                    ot.NextResources = "";
//                                    ot.NextStep = "待生产";
//                                    orderArgs.OrderTask = ot;
//                                    */
//                                    p.Client.SaveOrder(SenderUser, orderArgs);
//                                }
//                            }
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//                finally
//                {
//                    Session[pid] = "1";
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }

//        }
//        public void GetDownloadStatus()
//        {
//            try
//            {
//                string pid = Request["pid"];
//                while (true)
//                {
//                    if (Session[pid] != null)
//                    {
//                        if (Session[pid].ToString() == "1")
//                        {
//                            Response.Write("{\"isOk\":1}");
//                            break;
//                        }
//                    }
//                    else
//                    {
//                        Response.Write("未知无效！");
//                        break;
//                    }
//                    Thread.Sleep(1000);
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 拆单确认支付
//        /// </summary>
//        public void PaySplitmentOrders()
//        {

//        }
//        /// <summary>
//        /// List<string>转List<guid>
//        /// </summary>
//        /// <param name="ids"></param>
//        /// <returns></returns>
//        private List<Guid> ConvertString2Guid(List<string> ids)
//        {
//            List<Guid> lists = new List<Guid>();
//            foreach (string s in ids)
//            {
//                lists.Add(new Guid(s));
//            }
//            return lists;
//        }

//        /// <summary>
//        /// 获取步骤明细
//        /// </summary>
//        public void GetStepsByOrder()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["OrderID"]))
//                {
//                    Response.Write("{\"total\":0,\"rows\":[]}");
//                }
//                else
//                {
//                    using (ProxyBE p = new ProxyBE())
//                    {
//                        var oid = Request["OrderID"].ToString();
//                        List<OrderStep> lists = p.Client.GetOrderStep(SenderUser, new Guid(oid));
//                        lists.Sort((x, y) => x.StepNo.CompareTo(y.StepNo));
//                        string json = JSONHelper.List2DataSetJson(lists);
//                        Response.Write(json);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }

//        /// <summary>
//        /// 拆单、订单上传：退回订单
//        /// </summary>
//        public void ReturnSplitOrder()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    Guid OrderID = new Guid(Request["OrderID"]);
//                    Order order = p.Client.GetOrder(SenderUser, OrderID);

//                    order.Status = "B"; // 退回订单
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;
//                    order.StepNo++;


//                    //把上传状态改为fasle,待重新上传
//                    List<Order2Cabinet> Order2Cabinets = new List<Order2Cabinet>();
//                    List<Order2Cabinet> listOrder2Cabinet = p.Client.GetOrder2CabinetByOrderID(SenderUser, order.OrderID);
//                    foreach (var item in listOrder2Cabinet)
//                    {
//                        item.FileUploadFlag = false;
//                        Order2Cabinets.Add(item);
//                        args.Order2Cabinets = Order2Cabinets;
//                    }
//                    //删除BOM、五金、CNC、DXF、图纸、效果图文件、详细数据
//                    p.Client.DeleteOrder2HardwareByOrderID(SenderUser, order.OrderID);
//                    p.Client.DeleteOrderProcessFileByOrderID(SenderUser, order.OrderID);
//                    p.Client.DeleteOrderDetailByOrderID(SenderUser, order.OrderID);

//                    //订单日志
//                    OrderLog log = new OrderLog();
//                    log.OrderID = order.OrderID;
//                    log.LogID = Guid.NewGuid();
//                    log.LogType = "退回订单申请";
//                    log.Remark = "提交退回订单申请";
//                    args.OrderLog = log;

//                    OrderTask ot = new OrderTask();
//                    ot.Action = "待订单确认";
//                    ot.CurrentStep = "待确认";
//                    ot.ActionRemarksType = "订单退回";
//                    ot.ActionRemarks = "已退回订单，待重新确认";
//                    ot.Resource = "订单拆单组";
//                    ot.NextResources = "订单确认组";
//                    ot.NextStep = "待重新确认";
//                    args.OrderTask = ot;

//                    p.Client.SaveOrder(SenderUser, args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 取消订单
//        /// </summary>
//        public void CancelOrder()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    Guid OrderID = new Guid(Request["OrderID"]);
//                    Order order = p.Client.GetOrder(SenderUser, OrderID);



//                    order.Status = "C"; // 订单取消
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;
//                    order.StepNo++;


//                    List<Order2Cabinet> cabinets = p.Client.GetOrder2CabinetByOrderID(SenderUser, order.OrderID);
//                    foreach (Order2Cabinet cabinet in cabinets)
//                    {
//                        cabinet.CabinetStatus = "C";
//                    }
//                    args.Order2Cabinets = cabinets;

//                    //订单日志
//                    OrderLog log = new OrderLog();
//                    log.OrderID = order.OrderID;
//                    log.LogID = Guid.NewGuid();
//                    log.LogType = "取消订单申请";
//                    log.Remark = "提交订单取消申请";
//                    args.OrderLog = log;

//                    OrderTask ot = new OrderTask();
//                    ot.Action = "已取消";
//                    ot.CurrentStep = "已取消";
//                    ot.ActionRemarksType = "订单取消";
//                    ot.ActionRemarks = "已取消订单";
//                    ot.Resource = "收单组";
//                    ot.NextResources = SenderUser.UserCode;
//                    ot.NextStep = "已取消";
//                    args.OrderTask = ot;

//                    p.Client.SaveOrder(SenderUser, args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 订单修改：移除产品明细
//        /// </summary>
//        public void DeleteByCabinetID()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string CabinetID = Request["CabinetID"];
//                    if (!string.IsNullOrEmpty(CabinetID))
//                        p.Client.DeleteOrder2CabinetByCabinetID(SenderUser, new Guid(CabinetID));
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 订单上传：提交完成
//        /// </summary>
//        public void UploadFinish()
//        {
//            using (ProxyBE p = new ProxyBE())
//            {
//                try
//                {
//                    Guid OrderID = new Guid(Request["OrderID"]);
//                    Order order = p.Client.GetOrder(SenderUser, OrderID);
//                    List<Order2Cabinet> listOrder2Cabinet = p.Client.GetOrder2CabinetByOrderID(SenderUser, order.OrderID);

//                    #region 订单步骤
//                    if (listOrder2Cabinet.FindAll(item => item.FileUploadFlag == false).Count == 0)
//                    {
//                        SaveOrderArgs args = new SaveOrderArgs();

//                        OrderLog log = new OrderLog();
//                        log.LogID = Guid.NewGuid();
//                        log.OrderID = order.OrderID;
//                        log.LogType = "文件上传";
//                        log.Remark += "文件已全部上传，订单等待确认。";

//                        OrderTask ot = new OrderTask();

//                        //判断是否正标,正标直接到财务审核，非标要给订单部确认图纸，确认后再给财务审核
//                        if (order.IsStandard == true)
//                        {
//                            order.Status = "D";
//                            ot.Action = "待上传订单";
//                            ot.CurrentStep = "订单确认";
//                            ot.ActionRemarksType = "审核意见";
//                            ot.ActionRemarks = "上传文件后系统自动转至待待财务审核步骤";
//                            ot.Resource = SenderUser.UserCode;
//                            ot.NextResources = "财务审核组";
//                            ot.NextStep = "待财务审核";
//                        }
//                        else
//                        {
//                            order.Status = "N";
//                            ot.Action = "资料上传完成，待订单确认";
//                            ot.CurrentStep = "拆单资料上传";
//                            ot.ActionRemarksType = "订单系统操作";
//                            ot.ActionRemarks = "上传文件后系统自动转至待确认步骤";
//                            ot.Resource = SenderUser.UserCode;
//                            ot.NextResources = "订单确认组";
//                            ot.NextStep = "待确认";
//                        }
//                        order.StepNo++;
//                        args.OrderTask = ot;
//                        args.OrderLog = log;
//                        args.Order = order;
//                        p.Client.SaveOrder(SenderUser, args);
//                        WriteSuccess();
//                    }
//                    else
//                    {
//                        throw new Exception("请上传完文件再提交");
//                    }
//                    #endregion
//                }
//                catch (Exception ex)
//                {
//                    WriteError(ex.Message, ex);
//                }
//            }
//        }

//        /// <summary>
//        /// 下载图纸文件
//        /// </summary>
//        public void DownloadDrawingFile()
//        {

//        }

//        /// <summary>
//        /// 订单对应的包号
//        /// </summary>
//        public void PackageNumTree()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string OrderID = Request["OrderID"];
//                    if (string.IsNullOrEmpty(OrderID))
//                    {
//                        throw new Exception("无效参数调用。");
//                    }
//                    SearchPackageArgs pargs = new SearchPackageArgs();
//                    pargs.OrderBy = "[CabinetName],[PackageNum]";
//                    pargs.OrderID = new Guid(OrderID);
//                    SearchResult psr = p.Client.SearchPackage(SenderUser, pargs);
//                    Response.Write(JSONHelper.Dataset2Json(psr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 下载订单料单文件
//        /// </summary>
//        public void DownloadOutFile()
//        {
//            try
//            {
//                string OrderID = Request["OrderID"];
//                if (string.IsNullOrEmpty(OrderID))
//                {
//                    throw new Exception("无效参数调用。");
//                }
//                string zipFileName = "";
//                using (ProxyBE pb = new ProxyBE())
//                {
//                    List<OrderProcessFile> bf = pb.Client.GetOrderProcessFilesByOrderID_FileType(SenderUser, new Guid(OrderID), "BOM");

//                    if (bf.Count == 0)
//                        throw new Exception("料单文件未上传！");

//                    MemoryStream ms = new MemoryStream();
//                    byte[] buffer = null;
//                    using (ZipFile file = ZipFile.Create(ms))
//                    {
//                        file.BeginUpdate();
//                        for (var i = 0; i < bf.Count; i++)
//                        {
//                            if (File.Exists(bf[i].FilePath))
//                            {
//                                string str = bf[i].FilePath.Substring(bf[i].FilePath.IndexOf("BOM") - 12);
//                                string[] arr = str.Split('\\');
//                                zipFileName = arr[0] + ".zip";
//                                file.Add(bf[i].FilePath);
//                            }
//                        }
//                        file.CommitUpdate();
//                        buffer = new byte[ms.Length];
//                        ms.Position = 0;
//                        ms.Read(buffer, 0, buffer.Length); //读取文件内容(1次读ms.Length/1024M)
//                        ms.Flush();
//                        ms.Close();
//                    }
//                    Response.Clear();
//                    Response.Buffer = true;
//                    Response.ContentType = "application/x-zip-compressed";
//                    Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(zipFileName));
//                    Response.BinaryWrite(buffer);
//                    Response.Flush();
//                    Response.End();
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 订单备货:把订单状态改为待出库：R
//        /// </summary>
//        public void Inventory()
//        {
//            try
//            {
//                string OrderID = Request["OrderID"];
//                if (string.IsNullOrEmpty(OrderID))
//                {
//                    throw new Exception("无效参数调用。");
//                }
//                using (ProxyBE p = new ProxyBE())
//                {
//                    Order order = p.Client.GetOrder(SenderUser, new Guid(OrderID));
//                    order.Status = "R";
//                    SaveOrderArgs args = new SaveOrderArgs();
//                    args.Order = order;
//                    p.Client.SaveOrder(SenderUser, args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {

//                WriteError(ex.Message, ex);
//            }
//        }

//        /// <summary>
//        /// 改单|消单处理
//        /// </summary>
//        public void UpdateCabinetStatus()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string OrderID = Request["OrderID"];
//                    string CabinetID = Request["CabinetID"];
//                    OprationType oprationtype = (OprationType)Enum.Parse(typeof(OprationType), Request["OprationType"], false);

//                    #region 改单
//                    if (oprationtype == OprationType.applyUpdate)//申请改单
//                    {
//                        #region 修改产品
//                        string OrderNo = Request["OrderNo"];
//                        Order model = p.Client.GetOrderByOrderNo(SenderUser, OrderNo);
//                        if (model == null)
//                        {
//                            return;
//                        }
//                        string jsondata = Request["Cabinets"];
//                        JsonData sj = JsonMapper.ToObject(jsondata);
//                        string strMsg = string.Empty;
//                        if (sj.Count > 0)
//                        {
//                            foreach (JsonData item in sj)
//                            {
//                                Order2Cabinet cabinet = new Order2Cabinet();
//                                cabinet.OrderID = model.OrderID;
//                                cabinet.CabinetName = item["CabinetName"].ToString();
//                                cabinet.CabinetID = Guid.Parse(item["CabinetID"].ToString());
//                                cabinet.Size = item["Size"].ToString();
//                                cabinet.MaterialStyle = item["MaterialStyle"].ToString();
//                                cabinet.Color = item["Color"].ToString();
//                                cabinet.CreatedBy = SenderUser.UserName;

//                                Order2Cabinet Model = p.Client.GetOrder2Cabinet(SenderUser, cabinet.CabinetID);

//                                if (cabinet.Size != Model.Size || cabinet.MaterialStyle != Model.MaterialStyle || cabinet.Color != Model.Color)
//                                {
//                                    if (p.Client.CountOrderWorkFlows(cabinet.CabinetID) > 0)
//                                    {
//                                        strMsg += string.Format("产品{0}已油漆，不能申请改单。请更改", cabinet.CabinetName);
//                                        WriteMessage(1, strMsg);
//                                        return;
//                                    }
//                                    p.Client.UpdateCabinetStatus(cabinet, oprationtype, SenderUser);
//                                }
//                            }
//                        }
//                        WriteMessage(1, strMsg);
//                        #endregion
//                    }
//                    else if (oprationtype == OprationType.allowUpdate)//允许改单
//                    {
//                        int resurt = p.Client.UpdateCabinetStatus(new Order2Cabinet() { CabinetID = new Guid(CabinetID), OrderID = new Guid(OrderID) }, oprationtype, SenderUser);
//                        WriteMessage(resurt, resurt > 0 ? "审核成功" : "审核失败");
//                    }
//                    else if (oprationtype == OprationType.cancelUpdate)//撤销改单
//                    {
//                        int resurt = p.Client.UpdateCabinetStatus(new Order2Cabinet() { CabinetID = new Guid(CabinetID), OrderID = new Guid(OrderID) }, oprationtype, SenderUser);
//                        WriteMessage(resurt, resurt > 0 ? "撤销改单成功" : "撤销改单失败");
//                    }
//                    #endregion

//                    #region 消单
//                    else if (oprationtype == OprationType.applyDelete)//申请消单
//                    {
//                        Order2Cabinet Cabinet = p.Client.GetOrder2Cabinet(SenderUser, new Guid(CabinetID));
//                        Order2Cabinet Model = new Order2Cabinet()
//                        {
//                            CabinetID = Cabinet.CabinetID,
//                            OrderID = Cabinet.OrderID,
//                            CreatedBy = SenderUser.UserName,
//                        };
//                        if (p.Client.CountOrderWorkFlows(Model.CabinetID) > 0)
//                        {
//                            WriteMessage(-101, "产品已油漆，不能申请消单。请更改");
//                            return;
//                        }
//                        int resurt = p.Client.UpdateCabinetStatus(Model, oprationtype, SenderUser);
//                        WriteMessage(resurt, resurt > 0 ? "申请消单成功" : "申请消单失败");
//                    }
//                    else if (oprationtype == OprationType.allowDelete)//允许消单
//                    {
//                        Order2Cabinet Model = new Order2Cabinet()
//                        {
//                            CabinetID = new Guid(CabinetID),
//                            OrderID = new Guid(OrderID),
//                        };
//                        if (p.Client.CountOrderWorkFlows(Model.CabinetID) > 0)
//                        {
//                            WriteMessage(-101, "产品已油漆，不能同意消单");
//                            return;
//                        }
//                        int resurt = p.Client.UpdateCabinetStatus(Model, OprationType.allowDelete, SenderUser);

//                        WriteMessage(resurt, resurt > 0 ? "审核成功" : "审核失败");
//                    }
//                    else if (oprationtype == OprationType.cancelDelete)//撤销消单
//                    {
//                        int resurt = p.Client.UpdateCabinetStatus(new Order2Cabinet() { CabinetID = new Guid(CabinetID), OrderID = new Guid(OrderID) }, oprationtype, SenderUser);
//                        WriteMessage(resurt, resurt > 0 ? "撤销消单成功" : "撤销消单失败");
//                    }
//                    #endregion
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        public void GetOrder2CabinetLog()
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(Request["CabinetID"]))
//                {
//                    Response.Write("{\"total\":0,\"rows\":[]}");
//                }
//                else
//                {
//                    using (ProxyBE p = new ProxyBE())
//                    {
//                        var oid = Request["CabinetID"].ToString();
//                        List<Order2CabinetLog> lists = p.Client.GetOrder2CabinetLog(SenderUser, new Guid(oid));
//                        string json = JSONHelper.List2DataSetJson(lists);
//                        Response.Write(json);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        /// <summary>
//        /// 改单审核列表
//        /// </summary>
//        public void GetOrder2CabinetLogs()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    string OrderNo = Request.Form["OrderNo"];
//                    SearchOrder2CabinetArgs SearchOrder = new SearchOrder2CabinetArgs()
//                    {
//                        OrderNo = OrderNo,
//                        RowNumberFrom = pagingParm.RowNumberFrom,
//                        RowNumberTo = pagingParm.RowNumberTo,
//                    };
//                    SearchResult resurt = p.Client.SearchOrder2CabinetLogs(SenderUser, SearchOrder);
//                    string json = JSONHelper.Dataset2Json(resurt.DataSet);

//                    Response.Write(json);
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        #region 订单排产
//        //待排产订单列表
//        public void GetOrderSchedulingTree()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchOrderArgs args = new SearchOrderArgs();
//                    args.OrderBy = "[OrderNo] asc";
//                    if (!string.IsNullOrEmpty(Request["OrderIDs"]))
//                    {
//                        args.OrderIDs = new List<Guid>();
//                        foreach (string id in Request["OrderIDs"].ToString().Split(',').ToList())
//                        {
//                            args.OrderIDs.Add(new Guid(id));
//                        }
//                    }
//                    if (!string.IsNullOrEmpty(parm.Status) && Request["Status"] != "全部")
//                    {
//                        args.Status = parm.Status.Split(',').ToList();
//                    }
//                    if (!string.IsNullOrEmpty(parm.OrderType) && Request["OrderType"] != "全部")
//                    {
//                        args.OrderTypes = parm.OrderType.Split(',').ToList();
//                    }
//                    if (!string.IsNullOrEmpty(parm.OrderNo))
//                    {
//                        args.OrderNo = parm.OrderNo;
//                    }
//                    if (!string.IsNullOrEmpty(parm.PurchaseNo))
//                    {
//                        args.PurchaseNo = parm.PurchaseNo;
//                    }

//                    if (!string.IsNullOrEmpty(parm.BattchNum))
//                    {
//                        args.BattchNo = parm.BattchNum;
//                    }

//                    if (!string.IsNullOrEmpty(parm.OutOrderNo))
//                    {
//                        args.OutOrderNo = parm.OutOrderNo;
//                    }
//                    if (!string.IsNullOrEmpty(parm.Mobile))
//                    {
//                        args.Mobile = parm.Mobile;
//                    }
//                    if (!string.IsNullOrEmpty(parm.CabinetType) && Request["CabinetType"] != "请选择")
//                    {
//                        args.CabinetType = parm.CabinetType;
//                    }
//                    if (!string.IsNullOrEmpty(parm.BattchNum))
//                    {
//                        args.BattchNo = parm.BattchNum;
//                    }
//                    if (!string.IsNullOrEmpty(parm.Address))
//                    {
//                        args.Address = parm.Address;
//                    }
//                    if (!string.IsNullOrEmpty(parm.CustomerName))
//                    {
//                        args.CustomerName = parm.CustomerName;
//                    }
//                    if (!string.IsNullOrEmpty(Request["BookingDateFrom"]))
//                    {
//                        args.BookingDateFrom = parm.BookingDateFrom;
//                    }
//                    if (!string.IsNullOrEmpty(Request["BookingDateTo"]))
//                    {
//                        args.BookingDateTo = parm.BookingDateTo.AddDays(1);
//                    }
//                    if (!string.IsNullOrEmpty(Request["ShipDateFrom"]))
//                    {
//                        args.ShipDateFrom = parm.ShipDateFrom;
//                    }
//                    if (!string.IsNullOrEmpty(Request["ShipDateTo"]))
//                    {
//                        args.ShipDateTo = parm.ShipDateTo.AddDays(1);
//                    }
//                    //Where
//                    SearchResult sr = p.Client.SearchOrder(SenderUser, args);

//                    StringBuilder jsonBuilder = new StringBuilder();
//                    jsonBuilder.Append("[{");
//                    jsonBuilder.Append("\"id\":\"" + Guid.Empty.ToString() + "\"");
//                    jsonBuilder.Append(",\"text\":\"待排产订单\"");
//                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
//                    jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "application_view_tile");
//                    jsonBuilder.AppendFormat(",\"children\":");
//                    jsonBuilder.Append("[");
//                    #region 订单列表
//                    foreach (DataRow row in sr.DataSet.Tables[0].Rows)
//                    {
//                        Guid orderid = new Guid(row["OrderID"].ToString());
//                        List<Order2Cabinet> lists = p.Client.GetOrder2CabinetByOrderID(SenderUser, orderid).Where(li => li.CabinetStatus == "T").ToList();
//                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
//                        if (lists.Count == 0)
//                        {
//                            continue;
//                        }

//                        jsonBuilder.Append("{");
//                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", row["OrderID"].ToString());
//                        //jsonBuilder.AppendFormat(",\"text\":\"{0}({1})\"", row["OrderNo"].ToString(), row["CustomerName"].ToString());
//                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", row["OrderNo"].ToString());
//                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\",\"ParentID\":\"" + row["OrderID"] + "\"}");
//                        jsonBuilder.AppendFormat(",\"state\":\"open\"");
//                        jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "table");
//                        jsonBuilder.AppendFormat(",\"children\":");
//                        jsonBuilder.Append("[");
//                        #region 柜体数据

//                        foreach (Order2Cabinet item in lists)
//                        {
//                            if (item.CabinetStatus != "T") continue;

//                            jsonBuilder.Append("{");
//                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.CabinetID);
//                            jsonBuilder.AppendFormat(",\"text\":\"{0}({1},{2},{3})\"", item.CabinetName, item.Size, item.Color, item.MaterialStyle);
//                            jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "door");
//                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"3\",\"ParentID\":\"" + item.CabinetID + "\"}");
//                            jsonBuilder.Append("}");
//                            jsonBuilder.Append(",");
//                        }
//                        #endregion
//                        //移除最后一个"，"
//                        if (jsonBuilder.ToString().Substring(jsonBuilder.Length - 1, 1) == ",")
//                        {
//                            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
//                        }
//                        jsonBuilder.Append("]");
//                        jsonBuilder.Append("}");
//                        jsonBuilder.Append(",");
//                    }
//                    if (sr.Total > 0)
//                    {
//                        if (jsonBuilder.ToString().Substring(jsonBuilder.Length - 1, 1) == ",")
//                        {
//                            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
//                        }
//                    }
//                    #endregion
//                    jsonBuilder.Append("]");
//                    jsonBuilder.Append("}]");

//                    Response.Write(jsonBuilder.ToString());
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }

//        // 待排产订单明细
//        public void SearchScheduleDetail()
//        {
//            try
//            {

//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchAPSDetailsArgs args = new SearchAPSDetailsArgs();
//                    args.OrderBy = "ItemName";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    //排除异形板件
//                    //args.IsSpecialShap = true;
//                    ////排除小板
//                    //args.MadeLengthFrom = 200;
//                    //args.MadeWidthFrom = 200;

//                    //选择的柜体
//                    string CabinetIDs = Request["CabinetIDs"];
//                    string MaterialType = Request["MaterialType"];
//                    string ShipDate = Request["ShipDate"];
//                    if (!string.IsNullOrEmpty(MaterialType))
//                    {
//                        args.MaterialType = MaterialType;
//                    }
//                    if (!string.IsNullOrEmpty(ShipDate))
//                    {
//                        args.ShipDate = ShipDate.Replace("/", "-");
//                    }
//                    if (MaterialType == "全 部")
//                    {
//                        args.MaterialType = "";
//                    }
//                    if (!string.IsNullOrEmpty(CabinetIDs))
//                    {
//                        args.CabinetIDs = new List<Guid>();
//                        List<string> ids = CabinetIDs.Split(',').ToList();
//                        foreach (string id in ids)
//                        {
//                            args.CabinetIDs.Add(new Guid(id));
//                        }
//                    }
//                    else
//                    {
//                        Response.Write(JSONHelper.Dataset2Json(null));
//                        return;
//                    }
//                    //排除的板件:库存部件及外购部件
//                    //args.RemoveItems = GetRemoveItems();
//                    //排除异形板件
//                    //args.IsSpecialShap = false;
//                    SearchResult sr = p.Client.SearchAPSByOrderDetails(args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex);
//                //WriteError(ex.Message, ex);
//            }
//        }
//        // 用料统计
//        public void SearchAPSTotal()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchAPSDetailsArgs args = new SearchAPSDetailsArgs();
//                    args.OrderBy = "MaterialType,MadeHeight";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    //选择的柜体
//                    string CabinetIDs = Request["CabinetIDs"];
//                    if (!string.IsNullOrEmpty(CabinetIDs))
//                    {
//                        args.CabinetIDs = new List<Guid>();
//                        List<string> ids = CabinetIDs.Split(',').ToList();
//                        foreach (string id in ids)
//                        {
//                            args.CabinetIDs.Add(new Guid(id));
//                        }
//                    }
//                    else
//                    {
//                        Response.Write(JSONHelper.Dataset2Json(null));
//                        return;
//                    }
//                    //排除的板件:库存部件及外购部件                  
//                    args.RemoveItems = GetRemoveItems();
//                    //排除异形板件
//                    args.IsSpecialShap = false;
//                    //排除异形板件
//                    //args.IsSpecialShap = true;
//                    //排除小板
//                    args.MadeLengthFrom = 200;
//                    args.MadeWidthFrom = 200;
//                    SearchResult sr = p.Client.SearchAPSByTotal(args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex);
//                //WriteError(ex.Message, ex);
//            }
//        }
//        // 排除板件明细
//        public void SearchRemoveDetails()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchAPSDetailsArgs args = new SearchAPSDetailsArgs();
//                    args.OrderBy = "ItemName";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    //排除异形板件
//                    //args.IsSpecialShap = true;
//                    //排除小板
//                    args.MadeLengthTo = 200;
//                    args.MadeWidthTo = 200;
//                    //选择的柜体
//                    string CabinetIDs = Request["CabinetIDs"];
//                    if (!string.IsNullOrEmpty(CabinetIDs))
//                    {
//                        args.CabinetIDs = new List<Guid>();
//                        List<string> ids = CabinetIDs.Split(',').ToList();
//                        foreach (string id in ids)
//                        {
//                            args.CabinetIDs.Add(new Guid(id));
//                        }
//                    }
//                    else
//                    {
//                        Response.Write(JSONHelper.Dataset2Json(null));
//                        return;
//                    }
//                    //排除的板件:库存部件及外购部件                  
//                    args.RemoveItems = GetRemoveItems();
//                    //排除异形板件
//                    args.IsSpecialShap = false;
//                    SearchResult sr = p.Client.SearchAPSByRemoveDetails(args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex);
//                //WriteError(ex.Message, ex);
//            }
//        }
//        // 异形板件明细
//        public void SearchShapeDetails()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    SearchAPSDetailsArgs args = new SearchAPSDetailsArgs();
//                    args.OrderBy = "ItemName";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    //选择的柜体数据
//                    string CabinetIDs = Request["CabinetIDs"];
//                    if (!string.IsNullOrEmpty(CabinetIDs))
//                    {
//                        args.CabinetIDs = new List<Guid>();
//                        List<string> ids = CabinetIDs.Split(',').ToList();
//                        foreach (string id in ids)
//                        {
//                            args.CabinetIDs.Add(new Guid(id));
//                        }
//                    }
//                    else
//                    {
//                        Response.Write(JSONHelper.Dataset2Json(null));
//                        return;
//                    }
//                    //排除的板件:库存部件及外购部件
//                    args.RemoveItems = GetRemoveItems();
//                    //排除异形板件
//                    args.IsSpecialShap = true;

//                    SearchResult sr = p.Client.SearchAPSByOrderDetails(args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                Response.Write(ex);
//                //WriteError(ex.Message, ex);
//            }
//        }
//        //排除板件
//        public List<string> GetRemoveItems()
//        {
//            List<string> items = new List<string>();
//            using (ProxyBE op = new ProxyBE())
//            {
//                #region 加工工序：排除做库存的部件
//                List<OrderDetail> packages = new List<OrderDetail>();
//                List<Category> storage_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "StorageMaterials");
//                foreach (Category item in storage_items)
//                {
//                    //把库存件直接加入包装工件清单中
//                    items.Add(item.CategoryName);
//                }
//                #endregion

//                #region 加工工序：排除发外生产的部件
//                List<Category> Outsourcing_items = op.Client.GetCategoryChildrensByCategoryCode(SenderUser, "OutSourcingMaterials");
//                foreach (Category item in Outsourcing_items)
//                {
//                    //把外购件直接加入包装工件清单中
//                    items.Add(item.CategoryName);
//                }
//            }
//            return items;
//            #endregion
//        }

//        //订单排产
//        public void CreateOrderScheduling()
//        {
//            try
//            {
//                string IDs = Request["CabinetIDs"];
//                string WorkingLineID = Request["WorkingLineID"];
//                if (string.IsNullOrEmpty(IDs))
//                    throw new Exception("请选择待排产的订单。");

//                if (string.IsNullOrEmpty(WorkingLineID))
//                    throw new Exception("请选择需要排产的生产线。");


//                List<string> ids = IDs.Split(',').ToList();
//                List<Guid> CabinetIDs = new List<Guid>();
//                foreach (string id in ids)
//                {
//                    CabinetIDs.Add(new Guid(id));
//                }

//                using (ProxyBE op = new ProxyBE())
//                {
//                    WorkingLine wl = op.Client.GetWorkingLine(SenderUser, new Guid(WorkingLineID));
//                    if (wl == null)
//                    {
//                        throw new PException("所选择的生产线不存在。");
//                    }
//                    //获取排产批次号
//                    string BatchNum = op.Client.GetBattchNum(SenderUser);


//                    //获取待排产的板件明细
//                    #region 获取待排产的正常板件明细
//                    SearchOrderDetailArgs args = new SearchOrderDetailArgs();
//                    args.OrderBy = "ItemName";
//                    //选择的柜体                    
//                    args.CabinetIDs = CabinetIDs;
//                    //排除的板件:库存部件及外购部件
//                    args.RemoveItems = GetRemoveItems();
//                    //排除异形板件
//                    args.IsSpecialShap = false;
//                    //排除小板                    
//                    //args.MadeMinSize = 200;
//                    args.MadeLengthFrom = 200;
//                    args.MadeWidthFrom = 200;
//                    SearchResult sr = op.Client.SearchOrderDetail(SenderUser, args);
//                    #endregion

//                    //包装明细数据
//                    List<PackageDetail> list_PackageDetails = new List<PackageDetail>();
//                    //获取特殊部件工序
//                    List<SpecialCompanent> lists_SC = op.Client.GetSpecialCompanents(SenderUser);
//                    //订单生产时间计划表
//                    List<OrderScheduling> lists_os = new List<OrderScheduling>();

//                    //板件生产工序
//                    List<OrderWorkFlow> ows = new List<OrderWorkFlow>();

//                    #region 正常板件排产
//                    foreach (DataRow row in sr.DataSet.Tables[0].Rows)
//                    {
//                        Guid OrderID = Guid.Parse(row["OrderID"].ToString());
//                        Guid ItemID = Guid.Parse(row["ItemID"].ToString());
//                        Order order = op.Client.GetOrder(SenderUser, OrderID);
//                        OrderDetail subOrder = op.Client.GetOrderDetail(SenderUser, ItemID);

//                        #region 生成包装数据
//                        for (int i = 0; i < subOrder.Qty; i++)
//                        {
//                            PackageDetail packageDetail = new PackageDetail();
//                            packageDetail.DetailID = Guid.NewGuid();
//                            packageDetail.ItemID = subOrder.ItemID;
//                            packageDetail.BattchNo = BatchNum;
//                            packageDetail.Qty = 1;
//                            packageDetail.PakageID = Guid.Empty;
//                            packageDetail.LayerNum = 0;
//                            packageDetail.IsPackaged = false;
//                            packageDetail.IsOptimized = false;
//                            packageDetail.IsPlanning = true;
//                            packageDetail.IsDisabled = false;
//                            list_PackageDetails.Add(packageDetail);
//                        }
//                        #endregion

//                        #region 生成板件的生产工序
//                        //加入最后完成工序;                
//                        SpecialCompanent2WorkFlow finish_step = new SpecialCompanent2WorkFlow();
//                        finish_step.Sequence = 999;
//                        finish_step.WorkFlowID = Guid.Empty;

//                        //设置板件生产工序
//                        OrderWorkFlow ow = new OrderWorkFlow();

//                        //string workFlows = "常规开料";
//                        //if (!string.IsNullOrEmpty(subOrder.EdgeDesc))
//                        //{
//                        //    workFlows += ",封边";
//                        //}
//                        //if (subOrder.HasHole)
//                        //{
//                        //    workFlows += ",常规打孔";
//                        //}
//                        //workFlows += ",包装,完成";

//                        //此处应根据生产线查询所有工序

//                        List<WorkFlow> workFlows = op.Client.GetAllWorkFlows(SenderUser).OrderBy(t => t.Sequence).ToList();
//                        for (int z = 0; z < workFlows.Count; z++)
//                        {
//                            ow = new OrderWorkFlow();
//                            ow.WorkingID = Guid.NewGuid();
//                            ow.ItemID = subOrder.ItemID;
//                            ow.OrderID = subOrder.OrderID;
//                            ow.WorkFlowNo = z + 1;
//                            ow.Action = workFlows[z].WorkFlowName;
//                            // ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(arrWF[z]));
//                            //ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(arrWF[z + 1]));
//                            ow.SourceWorkFlowID = workFlows[z].WorkFlowID;
//                            ow.TargetWorkFlowID = (z == workFlows.Count - 1 ? Guid.Empty : workFlows[z + 1].WorkFlowID);
//                            ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                            ow.MadeQty = 0;
//                            ows.Add(ow);
//                            //计算订单工序总板件及面积
//                            SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, subOrder);
//                        }
//                        #endregion
//                    }
//                    #endregion

//                    #region 小板件排产
//                    SearchOrderDetailArgs SmallArgs = new SearchOrderDetailArgs();
//                    SmallArgs.OrderBy = "ItemName";
//                    SmallArgs.CabinetIDs = CabinetIDs;
//                    //排除的板件:库存部件及外购部件
//                    SmallArgs.RemoveItems = GetRemoveItems();
//                    //排除异形板件
//                    SmallArgs.IsSpecialShap = false;
//                    //小板件
//                    //SmallArgs.MadeMaxSize = 200;

//                    SmallArgs.MadeWidthTo = 200;
//                    SmallArgs.MadeLengthTo = 200;
//                    SearchResult small_sr = op.Client.SearchOrderDetail(SenderUser, SmallArgs);

//                    foreach (DataRow row in small_sr.DataSet.Tables[0].Rows)
//                    {
//                        Guid OrderID = Guid.Parse(row["OrderID"].ToString());
//                        Guid ItemID = Guid.Parse(row["ItemID"].ToString());
//                        Order order = op.Client.GetOrder(SenderUser, OrderID);
//                        OrderDetail subOrder = op.Client.GetOrderDetail(SenderUser, ItemID);

//                        #region 生成包装数据
//                        for (int i = 0; i < subOrder.Qty; i++)
//                        {
//                            PackageDetail packageDetail = new PackageDetail();
//                            packageDetail.DetailID = Guid.NewGuid();
//                            packageDetail.ItemID = Guid.Parse(row["ItemID"].ToString());
//                            packageDetail.BattchNo = BatchNum;
//                            packageDetail.Qty = 1;
//                            packageDetail.PakageID = Guid.Empty;
//                            packageDetail.LayerNum = 0;
//                            packageDetail.IsPackaged = false;
//                            packageDetail.IsOptimized = false;
//                            packageDetail.IsPlanning = true;
//                            packageDetail.IsDisabled = false;
//                            list_PackageDetails.Add(packageDetail);
//                        }
//                        #endregion

//                        string workFlows = "异形开料";
//                        if (!string.IsNullOrEmpty(subOrder.EdgeDesc))
//                        {
//                            workFlows += ",异形封边";
//                        }
//                        if (subOrder.HasHole)
//                        {
//                            workFlows += ",异形打孔";
//                        }
//                        workFlows += ",包装,完成";
//                        string[] arrWF = workFlows.Split(',');
//                        for (int i = 0; i < arrWF.Length - 1; i++)
//                        {
//                            OrderWorkFlow ow = new OrderWorkFlow();
//                            ow.WorkingID = Guid.NewGuid();
//                            ow.ItemID = subOrder.ItemID;
//                            ow.OrderID = subOrder.OrderID;
//                            ow.WorkFlowNo = i + 1;
//                            ow.Action = arrWF[i];
//                            ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(arrWF[i]));
//                            ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(arrWF[i + 1]));
//                            ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                            ow.MadeQty = 0;
//                            ows.Add(ow);
//                            SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, subOrder);
//                        }
//                    }
//                    #endregion

//                    #region 异形板件排产
//                    SearchOrderDetailArgs OtherArgs = new SearchOrderDetailArgs();
//                    OtherArgs.OrderBy = "ItemName";
//                    OtherArgs.CabinetIDs = CabinetIDs;
//                    //排除的板件:库存部件及外购部件
//                    OtherArgs.RemoveItems = GetRemoveItems();
//                    //异形板件
//                    OtherArgs.IsSpecialShap = true;
//                    SearchResult Other_sr = op.Client.SearchOrderDetail(SenderUser, OtherArgs);

//                    foreach (DataRow row in Other_sr.DataSet.Tables[0].Rows)
//                    {
//                        Guid OrderID = Guid.Parse(row["OrderID"].ToString());
//                        Guid ItemID = Guid.Parse(row["ItemID"].ToString());
//                        Order order = op.Client.GetOrder(SenderUser, OrderID);
//                        OrderDetail subOrder = op.Client.GetOrderDetail(SenderUser, ItemID);

//                        #region 生成包装数据
//                        for (int i = 0; i < subOrder.Qty; i++)
//                        {
//                            PackageDetail packageDetail = new PackageDetail();
//                            packageDetail.DetailID = Guid.NewGuid();
//                            packageDetail.ItemID = Guid.Parse(row["ItemID"].ToString());
//                            packageDetail.BattchNo = BatchNum;
//                            packageDetail.Qty = 1;
//                            packageDetail.PakageID = Guid.Empty;
//                            packageDetail.LayerNum = 0;
//                            packageDetail.IsPackaged = false;
//                            packageDetail.IsOptimized = false;
//                            packageDetail.IsPlanning = true;
//                            packageDetail.IsDisabled = false;
//                            list_PackageDetails.Add(packageDetail);
//                        }
//                        #endregion

//                        string workFlows = "异形开料";
//                        if (!string.IsNullOrEmpty(subOrder.EdgeDesc))
//                        {
//                            workFlows += ",异形封边";
//                        }
//                        if (subOrder.HasHole)
//                        {
//                            workFlows += ",异形打孔";
//                        }
//                        workFlows += ",包装,完成";
//                        string[] arrWF = workFlows.Split(',');
//                        for (int i = 0; i < arrWF.Length - 1; i++)
//                        {
//                            OrderWorkFlow ow = new OrderWorkFlow();
//                            ow.WorkingID = Guid.NewGuid();
//                            ow.ItemID = subOrder.ItemID;
//                            ow.OrderID = subOrder.OrderID;
//                            ow.WorkFlowNo = i + 1;
//                            ow.Action = arrWF[i];
//                            ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(arrWF[i]));
//                            ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(arrWF[i + 1]));
//                            ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                            ow.MadeQty = 0;
//                            ows.Add(ow);
//                            SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, subOrder);
//                        }
//                    }
//                    #endregion

//                    #region 外购的工件、库存件排产
//                    SearchOrderDetailArgs BuyItems_Args = new SearchOrderDetailArgs();
//                    BuyItems_Args.OrderBy = "ItemName";
//                    BuyItems_Args.CabinetIDs = CabinetIDs;
//                    //库存部件及外购部件
//                    BuyItems_Args.ItemNames = GetRemoveItems();
//                    SearchResult BuyItems_sr = op.Client.SearchOrderDetail(SenderUser, BuyItems_Args);
//                    string PackageFlows = "包装,完成";
//                    string[] pkWF = PackageFlows.Split(',');

//                    foreach (DataRow row in BuyItems_sr.DataSet.Tables[0].Rows)
//                    {
//                        Guid OrderID = Guid.Parse(row["OrderID"].ToString());
//                        Guid ItemID = Guid.Parse(row["ItemID"].ToString());
//                        Order order = op.Client.GetOrder(SenderUser, OrderID);
//                        OrderDetail subOrder = op.Client.GetOrderDetail(SenderUser, ItemID);
//                        for (int z = 0; z < pkWF.Length - 1; z++)
//                        {
//                            OrderWorkFlow ow = new OrderWorkFlow();
//                            ow.WorkingID = Guid.NewGuid();
//                            ow.ItemID = subOrder.ItemID;
//                            ow.OrderID = subOrder.OrderID;
//                            ow.WorkFlowNo = z + 1;
//                            ow.Action = pkWF[z];
//                            ow.SourceWorkFlowID = new Guid(GetWorkFlowCode(pkWF[z]));
//                            ow.TargetWorkFlowID = new Guid(GetWorkFlowCode(pkWF[z + 1]));
//                            ow.TotalQty = Convert.ToInt32(subOrder.Qty);
//                            ow.MadeQty = 0;
//                            ows.Add(ow);
//                            //计算订单工序总板件及面积
//                            SetOrderScheduling(lists_os, BatchNum, ow.SourceWorkFlowID, subOrder);
//                        }
//                    }
//                    #endregion

//                    #region 计算生产时间
//                    //根据订单总的数量和面积，计算在生产设备及工序上的生产时间    
//                    List<WorkCenterScheduling> lists_ws = new List<WorkCenterScheduling>();


//                    //把车间数据、设备数据、班次数据一次性加载出来
//                    foreach (OrderScheduling os in lists_os)
//                    {
//                        #region 获取工序对应的设备产能,每条生产线
//                        Guid WorkFlowID = os.WorkFlowID;//工序ID
//                        WorkFlow wf = op.Client.GetWorkFlow(SenderUser, WorkFlowID);

//                        SearchWorkCenterArgs wc_args = new SearchWorkCenterArgs();
//                        wc_args.WorkFlowID = WorkFlowID;
//                        wc_args.WorkingLineID = new Guid(WorkingLineID);
//                        SearchResult sr_wc = op.Client.SearchWorkCenter(SenderUser, wc_args);
//                        if (sr_wc.Total == 0)
//                        {
//                            throw new PException("【{0}】的【{1}】工序未设置生产设备或生产设备产能为0。", wl.WorkingLineName, wf.WorkFlowName);
//                        }

//                        int MaxCapacity = 0;
//                        string CountCapacityType = "";
//                        //生产设备列表
//                        List<WorkCenter> wclists = new List<WorkCenter>();
//                        //多台设备
//                        Guid WorkShopID = Guid.Empty;
//                        foreach (DataRow wc_row in sr_wc.DataSet.Tables[0].Rows)
//                        {
//                            MaxCapacity += int.Parse(wc_row["MaxCapacity"].ToString()); //最大产能  
//                            CountCapacityType = wc_row["CountCapacityType"].ToString();
//                            WorkShopID = Guid.Parse(wc_row["WorkShopID"].ToString());
//                            WorkCenter wc = op.Client.GetWorkCenter(SenderUser, Guid.Parse(wc_row["WorkCenterID"].ToString()));
//                            if (wc != null)
//                            {
//                                wclists.Add(wc);
//                            }
//                        }
//                        #endregion
//                        #region 工作班次
//                        //获取生产线(生产车间)对应的班次工作时间（设备的生产时间)
//                        SearchWorkShift2WorkShopArgs sws_args = new SearchWorkShift2WorkShopArgs();
//                        sws_args.WorkShopID = WorkShopID;
//                        SearchResult sws_sr = op.Client.SearchWorkShift2WorkShop(SenderUser, sws_args);
//                        if (sws_sr.Total == 0)
//                        {
//                            throw new PException("【{0}】的【{1}】工序未设置工作时间或班次。", wl.WorkingLineName, wf.WorkFlowName);
//                        }
//                        int hours = 0;
//                        DateTime Started = DateTime.MaxValue;
//                        DateTime Ended = DateTime.MinValue;
//                        foreach (DataRow rw in sws_sr.DataSet.Tables[0].Rows)
//                        {
//                            DateTime started = DateTime.Parse(rw["Started"].ToString());//08：00
//                            DateTime ended = DateTime.Parse(rw["Ended"].ToString());//18：00
//                            if (ended < started)
//                            {
//                                ended = ended.AddDays(1);
//                            }
//                            if (Started > started)
//                            {
//                                Started = started;
//                            }
//                            if (ended > Ended)
//                            {
//                                Ended = ended;
//                            }
//                            hours += (ended - started).Hours;
//                        }
//                        #endregion
//                        #region 订单生产排产及设备排产

//                        //工序生产时长：生产量除以产能（小时），取整
//                        switch (CountCapacityType)
//                        {
//                            case "L"://按长度计算产能
//                                os.ProductionPeriod = (os.TotalLength / (MaxCapacity * hours * 1.0M));
//                                break;
//                            case "A"://按面积计算产能
//                                os.ProductionPeriod = (os.TotalAreal / (MaxCapacity * hours * 1.0M));
//                                break;
//                            case "Q"://按板件数量计算产能
//                                os.ProductionPeriod = (os.TotalQty / (MaxCapacity * hours * 1.0M));
//                                break;
//                            default:
//                                os.ProductionPeriod = os.TotalAreal / (MaxCapacity * hours * 1.0M);
//                                break;
//                        }

//                        //需要提前一天排产                            
//                        WorkCenterScheduling wcs = op.Client.GetLastWorkCenterSchedulingByWorkCenterID(SenderUser, wclists[0].WorkCenterID);
//                        DateTime MadeStarted;
//                        if (wcs == null)
//                        {
//                            MadeStarted = DateTime.Now.Date.AddDays(1).AddHours(8); //开始时间
//                        }
//                        else
//                        {
//                            MadeStarted = wcs.Ended;
//                        }
//                        wcs = new WorkCenterScheduling();
//                        wcs.WorkID = Guid.NewGuid();
//                        wcs.WorkCenterID = wclists[0].WorkCenterID;
//                        wcs.Status = "N";
//                        wcs.BattchNum = BatchNum;
//                        wcs.Started = MadeStarted;


//                        //计算结束时间
//                        int Days = (int)os.ProductionPeriod; //生产天数
//                        double Hours = (double)(os.ProductionPeriod - Days) * hours;
//                        wcs.Ended = wcs.Started.AddDays(Days);

//                        //如果生产时间不在工作时间，则排产时间需要安排到下一工作时间段
//                        if (wcs.Ended.AddHours(Hours) > wcs.Ended.Date.AddHours(Ended.Hour))
//                        {
//                            //计算上一工作日的下班时间与下一工作时间的上班时间差                                
//                            //下一工作日的上班时间
//                            Started = Started.AddDays(1);
//                            int SplitHour = (Started - Ended).Hours;
//                            wcs.Ended = wcs.Ended.AddHours(Hours + SplitHour);
//                        }
//                        else
//                        {
//                            wcs.Ended = wcs.Ended.AddHours(Hours);
//                        }
//                        os.Estimated = wcs.Ended;    //预计生产结束时间                                
//                        #endregion

//                        lists_ws.Add(wcs);
//                    }
//                    #endregion               

//                    //保存
//                    SaveCreatedSchedulingArgs save_sch_args = new SaveCreatedSchedulingArgs();
//                    save_sch_args.CabinetIDs = CabinetIDs;
//                    save_sch_args.OrderSchedulings = lists_os;
//                    save_sch_args.WorkCenterSchedulings = lists_ws;
//                    save_sch_args.PackageDetails = list_PackageDetails;
//                    save_sch_args.BattchCode = BatchNum;
//                    save_sch_args.OrderWorkFlows = ows;
//                    op.Client.CreatedScheduling(SenderUser, save_sch_args);
//                }
//                WriteSuccess();
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        #endregion

//        #region 订单优化
//        //待优化批次列表
//        public void GetBattchsTree()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {

//                    SearchOrder2CabinetArgs args = new SearchOrder2CabinetArgs();
//                    args.CabinetStatus = "M";
//                    //Where
//                    SearchResult sr = p.Client.SearchOrder2Cabinet(SenderUser, args);

//                    DataTable tb_battch = sr.DataSet.Tables[0].DefaultView.ToTable(true, "BattchCode");

//                    StringBuilder jsonBuilder = new StringBuilder();
//                    jsonBuilder.Append("[{");
//                    jsonBuilder.Append("\"id\":\"" + Guid.Empty.ToString() + "\"");
//                    jsonBuilder.Append(",\"text\":\"待优化批次\"");
//                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
//                    jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "application_view_tile");
//                    jsonBuilder.AppendFormat(",\"children\":");
//                    jsonBuilder.Append("[");
//                    #region 订单列表
//                    foreach (DataRow row in tb_battch.Rows)
//                    {
//                        jsonBuilder.Append("{");
//                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", row["BattchCode"].ToString());
//                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", row["BattchCode"].ToString());
//                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\"}");
//                        jsonBuilder.AppendFormat(",\"state\":\"open\"");
//                        jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "table");
//                        jsonBuilder.Append("}");
//                        jsonBuilder.Append(",");
//                    }
//                    if (sr.Total > 0)
//                    {
//                        if (jsonBuilder.ToString().Substring(jsonBuilder.Length - 1, 1) == ",")
//                        {
//                            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
//                        }
//                    }
//                    #endregion
//                    jsonBuilder.Append("]");
//                    jsonBuilder.Append("}]");

//                    Response.Write(jsonBuilder.ToString());
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }

//        public void SearchOrder2Cabinets()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {

//                    SearchOrder2CabinetArgs args = new SearchOrder2CabinetArgs();
//                    args.OrderBy = "Created desc";
//                    args.RowNumberFrom = pagingParm.RowNumberFrom;
//                    args.RowNumberTo = pagingParm.RowNumberTo;
//                    args.CabinetStatus = "M";
//                    if (!string.IsNullOrEmpty(Request["BattchNo"]))
//                    {
//                        args.BattchCode = Request["BattchNo"].ToString();
//                    }
//                    //Where
//                    SearchResult sr = p.Client.SearchOrder2Cabinet(SenderUser, args);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                PLogger.LogError(ex);
//                Response.Write(ex.Message);
//            }
//        }
//        #endregion

//        #region 导入订单
//        /// <summary>
//        /// 导入订单（新版，支持批量上传）
//        /// </summary>
//        public void ConversionOrderNew()
//        {
//            string errorInfo = string.Empty; int ArrayCount = 0;
//            Dictionary<string, object> dic = new Dictionary<string, object>();
//            IList<filemodel> list = new List<filemodel>();
//            try
//            {
//                if (string.IsNullOrEmpty(Request["DesignID"]))
//                {
//                    throw new Exception("设计方案ID参数无效");
//                }
//                Guid designID = new Guid(Request["DesignID"]);
//                Solution solution;
//                using (ProxyBE p = new ProxyBE())
//                {
//                    solution = p.Client.GetSolutionByDesignerID(SenderUser, designID);
//                    if (solution == null)
//                    {
//                        throw new Exception("设计方案不存在");
//                    }
//                }

//                if (!string.IsNullOrEmpty(Request["OrderFileUrl"]))
//                {
//                    IList<filemodel> ArrayPath = JSONHelper.JSONToObject<IList<filemodel>>(Request["OrderFileUrl"]);
//                    ArrayCount = ArrayPath.Count;
//                    //取第一个压缩包
//                    string path = HttpUtility.UrlDecode(ArrayPath[0].filePath, Encoding.UTF8);
//                    //解压压缩包
//                    CreateOrderByRarFile(path, designID, solution.SolutionID);
//                    list.Add(ArrayPath[0]);
//                    WriteSuccess();
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message);
//            }
//        }

//        /// <summary>
//        /// 解压rar、并解析其中的cxb文件入库
//        /// </summary>
//        /// <param name="fileUrl"></param>
//        public void CreateOrderByRarFile(string fileUrl, Guid designID, Guid solutionID)
//        {
//            using (ProxyBE p = new ProxyBE())
//            {
//                #region 获取拆单文件压缩包路径

//                string orderFileName = string.Empty;
//                string archiveUrl = HttpContext.Current.Server.MapPath(fileUrl); //压缩包完整路径
//                if (!string.IsNullOrEmpty(archiveUrl))
//                {
//                    orderFileName = Path.GetFileName(archiveUrl);
//                    if (!File.Exists(archiveUrl)) throw new Exception(string.Format("{0}:拆单文件压缩包不存在", orderFileName));
//                }

//                #endregion

//                #region 解压rar压缩包文件

//                string cxbUploadDirPath = AppDomain.CurrentDomain.BaseDirectory + "Upload\\" + DateTime.Now.ToString("yyyyMMdd") + "\\RoomDesignerFile\\"; //压缩包上传目录
//                using (var reader = RarReader.Open(File.OpenRead(archiveUrl)))
//                {
//                    while (reader.MoveToNextEntry())
//                    {
//                        reader.WriteEntryToDirectory(cxbUploadDirPath, new ExtractionOptions()
//                        {
//                            ExtractFullPath = true,
//                            Overwrite = true
//                        });
//                    }
//                    reader.Cancel();
//                    reader.Dispose();
//                }

//                #endregion

//                #region 获取压缩包中所有xcb文件列表

//                string orderNo = Path.GetFileName(archiveUrl).Substring(0, 14);
//                string[] cxbFiles = Directory.GetFiles(cxbUploadDirPath + orderNo, "*.cxb");

//                #endregion

//                #region 循环解析xcb文件

//                XmlDocument xml = new XmlDocument();
//                try
//                {
//                    if (cxbFiles.Length == 0)
//                    {
//                        throw new Exception(string.Format("导入失败,{0}:拆单文件压缩包中不存在cxb文件.", orderFileName));
//                    }

//                    for (int i = 0; i < cxbFiles.Length; i++)
//                    {
//                        string cxbFile = cxbFiles[i];
//                        xml.Load(cxbFile);
//                        XmlNode root = xml.SelectSingleNode("//SceneBOM");
//                        XmlAttributeCollection xac = root.Attributes;
//                        XmlNodeList lstComposeGroup = root.SelectNodes("//ComposeGroup");
//                        string orderCode = xac["OrderCode"].Value;

//                        #region 初始化柜体Solution2Cabinet

//                        Solution2Cabinet cabinet = new Solution2Cabinet()
//                        {
//                            CabinetID = Guid.NewGuid(),
//                            SolutionID = solutionID, //方案ID
//                            CabinetGroup = xac["rooms"].Value, //柜体分组
//                            CabinetName = xac["rooms"].Value, //柜体名称
//                            Size = string.Empty, //柜体尺寸
//                            MaterialStyle = lstComposeGroup[0].Attributes["BaseName"].Value + lstComposeGroup[0].Attributes["ColorName"].Value,
//                            MaterialCategory = lstComposeGroup[0].Attributes["BaseName"].Value + lstComposeGroup[0].Attributes["ColorName"].Value,
//                            Color = lstComposeGroup[0].Attributes["ColorName"].Value, //柜体颜色
//                            Unit = "件", //单位
//                            Qty = 1, //数量
//                            FileUploadFlag = true,
//                            Sequence = 0, //排序
//                            Remark = xac["PartsBrands"].Value, //备注
//                            Created = DateTime.Now,
//                            CreatedBy = "DLS.System",
//                            Modified = DateTime.Now,
//                            ModifiedBy = "DLS.System"
//                        };

//                        #endregion

//                        #region Insert Solution2Cabinet

//                        p.Client.SaveSolution2Cabinet(SenderUser, cabinet);

//                        #endregion

//                        #region 初始化柜体所有的板件、五金集合

//                        List<SolutionDetail> lstSolutionDetail = new List<SolutionDetail>(); //所有板件的集合
//                        List<Solution2Hardware> lstSolution2Hardware = new List<Solution2Hardware>(); //所有五金的集合

//                        #endregion

//                        #region 添加五金（第1种情况）

//                        XmlNodeList lstSelParts = root.SelectNodes("//SelParts");
//                        foreach (XmlNode selParts in lstSelParts)
//                        {
//                            XmlNodeList lstParts = selParts.ChildNodes;
//                            foreach (XmlNode parts in lstParts)
//                            {
//                                XmlAttributeCollection partsAttribute = parts.Attributes;
//                                //判断五金集合中是否已经包含该五金,有则数量+1，无则添加
//                                string hardwareName = partsAttribute["Name"].Value;
//                                if (lstSolution2Hardware.Select(x => x.HardwareName).Contains(hardwareName))
//                                {
//                                    var existHardware = lstSolution2Hardware.FirstOrDefault(x => x.HardwareName.Equals(hardwareName));
//                                    existHardware.Qty += (string.IsNullOrEmpty(partsAttribute["Count"].Value)) ? 1 : Convert.ToDecimal(partsAttribute["Count"].Value);
//                                }
//                                else
//                                {
//                                    //将五金配件添加到集合中
//                                    lstSolution2Hardware.Add(new Solution2Hardware()
//                                    {
//                                        ItemID = Guid.NewGuid(),
//                                        BarcodeNo = partsAttribute["Number"].Value,
//                                        SolutionID = cabinet.SolutionID,
//                                        CabinetID = cabinet.CabinetID,
//                                        HardwareCode = partsAttribute["Number"].Value,
//                                        HardwareName = partsAttribute["Name"].Value,
//                                        HardwareCategory = partsAttribute["GoodsType"].Value,
//                                        Style = partsAttribute["Specs"].Value,
//                                        Qty = Convert.ToDecimal(partsAttribute["Count"].Value),
//                                        Unit = partsAttribute["Unit"].Value,
//                                        Remarks = partsAttribute["Brand"].Value,
//                                        Created = DateTime.Now,
//                                        CreatedBy = "DLS.System",
//                                        Modified = DateTime.Now,
//                                        ModifiedBy = "DLS.System"
//                                    });
//                                }
//                            }
//                        }

//                        #endregion

//                        #region 循环ComposeGroup大组件，添加板件、五金

//                        foreach (XmlNode composeGroup in lstComposeGroup)
//                        {
//                            //循环SingleGroup小组件
//                            XmlNodeList lstSingleGroup = composeGroup.ChildNodes;
//                            foreach (XmlNode singleGroup in lstSingleGroup)
//                            {
//                                if (!singleGroup.Name.Equals("SingleGroup"))
//                                    continue;

//                                //循环SingleGroup下的所有子元素（Object板件、Handle五金、Track五金）
//                                XmlNodeList lstSgChildNodes = singleGroup.ChildNodes;
//                                foreach (XmlNode childNode in lstSgChildNodes)
//                                {
//                                    switch (childNode.Name)
//                                    {
//                                        case "Object":
//                                            XmlAttributeCollection objAttribute = childNode.Attributes;
//                                            switch (objAttribute["class"].Value)
//                                            {
//                                                case "model":
//                                                    #region 添加五金（第6种情况）

//                                                    //判断五金集合中是否已经包含该五金,有则数量+1，无则添加
//                                                    string hardwareName = objAttribute["Name"].Value;
//                                                    if (lstSolution2Hardware.Select(x => x.HardwareName).Contains(hardwareName))
//                                                    {
//                                                        var existHardware = lstSolution2Hardware.FirstOrDefault(x => x.HardwareName.Equals(hardwareName));
//                                                        existHardware.Qty += 1;
//                                                    }
//                                                    else
//                                                    {
//                                                        //将五金配件添加到集合中
//                                                        lstSolution2Hardware.Add(new Solution2Hardware()
//                                                        {
//                                                            ItemID = Guid.NewGuid(),
//                                                            BarcodeNo = objAttribute["NodeID"].Value,
//                                                            SolutionID = cabinet.SolutionID,
//                                                            CabinetID = cabinet.CabinetID,
//                                                            HardwareCode = objAttribute["NodeID"].Value,
//                                                            HardwareName = objAttribute["Name"].Value,
//                                                            HardwareCategory = objAttribute["ObjType"].Value,
//                                                            Style = string.Empty,
//                                                            Qty = 1,
//                                                            Unit = objAttribute["UnitName"].Value,
//                                                            Remarks = string.Empty,
//                                                            Created = DateTime.Now,
//                                                            CreatedBy = "DLS.System",
//                                                            Modified = DateTime.Now,
//                                                            ModifiedBy = "DLS.System"
//                                                        });
//                                                    }
//                                                    #endregion
//                                                    break;
//                                                default:
//                                                    #region 板件初始化
//                                                    SolutionDetail plate = new SolutionDetail()
//                                                    {
//                                                        ItemID = Guid.NewGuid(),
//                                                        BarcodeNo = objAttribute["NodeID"].Value + "-" + new Random().Next(1000, 10000), //板件条码，为保证唯一性（NodeID+随机4位数）
//                                                        ItemName = objAttribute["Name"].Value, //板材名称
//                                                        ItemType = objAttribute["ObjType"].Value, //板材类型
//                                                        SolutionID = cabinet.SolutionID,
//                                                        CabinetID = cabinet.CabinetID,
//                                                        IsSpecialShap = false,
//                                                        Qty = 1,
//                                                        TextureDirection = string.Empty,
//                                                        HoleDesc = string.Empty,
//                                                        MadeWidth = 0,
//                                                        MadeHeight = 0,
//                                                        MadeLength = 0,
//                                                        EndWidth = 0,
//                                                        EndLength = 0,
//                                                    };
//                                                    #endregion

//                                                    #region 板件属性赋值（成品长宽厚、开料长宽、封边设置）、五金
//                                                    XmlNodeList lstPlateCut = childNode.ChildNodes;
//                                                    foreach (XmlNode cut in lstPlateCut)
//                                                    {
//                                                        switch (cut.Name)
//                                                        {
//                                                            case "Material":
//                                                                XmlAttributeCollection materialAttribute = cut.Attributes;
//                                                                plate.MaterialType = materialAttribute["BaseName"].Value + "/" + materialAttribute["ColorName"].Value; //材质
//                                                                break;
//                                                            case "Var":
//                                                                XmlAttributeCollection varAttribute = cut.Attributes;
//                                                                string cutName = varAttribute["Name"].Value;
//                                                                switch (cutName)
//                                                                {
//                                                                    case "开料长度":
//                                                                        plate.MadeLength = Convert.ToDecimal(varAttribute["Value"].Value);
//                                                                        break;
//                                                                    case "开料宽度":
//                                                                        plate.MadeWidth = Convert.ToDecimal(varAttribute["Value"].Value);
//                                                                        break;
//                                                                    case "成品长度":
//                                                                        plate.EndLength = Convert.ToDecimal(varAttribute["Value"].Value);
//                                                                        break;
//                                                                    case "成品宽度":
//                                                                        plate.EndWidth = Convert.ToDecimal(varAttribute["Value"].Value);
//                                                                        break;
//                                                                    case "成品厚度":
//                                                                        plate.MadeHeight = Convert.ToDecimal(varAttribute["Value"].Value);
//                                                                        break;
//                                                                    case "封边设置":
//                                                                        plate.Edge1 = varAttribute["Edge1"].Value;
//                                                                        plate.Edge2 = varAttribute["Edge2"].Value;
//                                                                        plate.Edge3 = varAttribute["Edge3"].Value;
//                                                                        plate.Edge4 = varAttribute["Edge4"].Value;
//                                                                        plate.EdgeDesc = varAttribute["Value"].Value;
//                                                                        break;
//                                                                    default:
//                                                                        break;
//                                                                }
//                                                                break;
//                                                            case "CncCode":
//                                                                XmlAttributeCollection cncCodeAttribute = cut.Attributes;
//                                                                string cncCode = cncCodeAttribute["Code"].Value;
//                                                                if (cncCodeAttribute["Code1"] == null && cncCodeAttribute["Code2"] == null)
//                                                                {
//                                                                    break;
//                                                                }
//                                                                plate.FilePathUrl = cxbUploadDirPath + orderNo + "\\" + orderCode + "ban\\" + orderCode + cncCode + ".ban";
//                                                                break;
//                                                            case "LinkParts":
//                                                                #region 添加五金（第2种情况）
//                                                                XmlAttributeCollection linkPartsAttribute = cut.Attributes;
//                                                                string linkPartsName = linkPartsAttribute["Name"].Value;
//                                                                XmlNodeList lstLink = cut.ChildNodes;
//                                                                foreach (XmlNode link in lstLink)
//                                                                {
//                                                                    XmlAttributeCollection linkAttribute = link.Attributes;
//                                                                    //排除LinkParts下又不是五金的情况
//                                                                    if (linkAttribute["Number"] == null || linkAttribute["Specs"] == null || linkAttribute["Brand"] == null)
//                                                                    {
//                                                                        break;
//                                                                    }
//                                                                    //判断五金集合中是否已经包含该五金,有则数量+1，无则添加
//                                                                    string linkName = linkAttribute["Name"].Value;
//                                                                    if (lstSolution2Hardware.Select(x => x.HardwareName).Contains(linkName))
//                                                                    {
//                                                                        var existHardware = lstSolution2Hardware.FirstOrDefault(x => x.HardwareName.Equals(linkName));
//                                                                        existHardware.Qty += 1;
//                                                                    }
//                                                                    else
//                                                                    {

//                                                                        //将五金配件添加到集合中
//                                                                        lstSolution2Hardware.Add(new Solution2Hardware()
//                                                                        {
//                                                                            ItemID = Guid.NewGuid(),
//                                                                            BarcodeNo = linkAttribute["Number"].Value,
//                                                                            SolutionID = cabinet.SolutionID,
//                                                                            CabinetID = cabinet.CabinetID,
//                                                                            HardwareCode = linkAttribute["Number"].Value,
//                                                                            HardwareName = linkName,
//                                                                            HardwareCategory = linkPartsName,
//                                                                            Style = linkAttribute["Specs"].Value,
//                                                                            Qty = 1,
//                                                                            Unit = linkAttribute["UnitName"].Value,
//                                                                            Remarks = linkAttribute["Brand"].Value,
//                                                                            Created = DateTime.Now,
//                                                                            CreatedBy = "DLS.System",
//                                                                            Modified = DateTime.Now,
//                                                                            ModifiedBy = "DLS.System"
//                                                                        });
//                                                                    }
//                                                                }
//                                                                #endregion
//                                                                break;
//                                                            default:
//                                                                break;
//                                                        }
//                                                    }
//                                                    #endregion

//                                                    lstSolutionDetail.Add(plate); //将板件添加到集合
//                                                    break;
//                                            }
//                                            break;
//                                        case "Handle":
//                                            #region 添加五金（第3种情况）

//                                            XmlAttributeCollection handleAttribute = childNode.Attributes;
//                                            //判断五金集合中是否已经包含该五金,有则数量+1，无则添加
//                                            string handleName = handleAttribute["Name"].Value;
//                                            if (lstSolution2Hardware.Select(x => x.HardwareName).Contains(handleName))
//                                            {
//                                                var existHardware = lstSolution2Hardware.FirstOrDefault(x => x.HardwareName.Equals(handleName));
//                                                existHardware.Qty += (string.IsNullOrEmpty(handleAttribute["Count"].Value)) ? 1 : Convert.ToDecimal(handleAttribute["Count"].Value);
//                                            }
//                                            else
//                                            {
//                                                //将五金配件添加到集合中
//                                                lstSolution2Hardware.Add(new Solution2Hardware()
//                                                {
//                                                    ItemID = Guid.NewGuid(),
//                                                    BarcodeNo = handleAttribute["LinkCode"].Value,
//                                                    SolutionID = cabinet.SolutionID,
//                                                    CabinetID = cabinet.CabinetID,
//                                                    HardwareCode = handleAttribute["LinkCode"].Value,
//                                                    HardwareName = handleName,
//                                                    HardwareCategory = handleName,
//                                                    Style = string.Empty,
//                                                    Qty = Convert.ToDecimal(handleAttribute["Count"].Value),
//                                                    Unit = handleAttribute["UnitName"].Value,
//                                                    Remarks = string.Empty,
//                                                    Created = DateTime.Now,
//                                                    CreatedBy = "DLS.System",
//                                                    Modified = DateTime.Now,
//                                                    ModifiedBy = "DLS.System"
//                                                });
//                                            }
//                                            #endregion
//                                            break;
//                                        case "Track":
//                                            #region 添加五金（第4种情况）

//                                            XmlAttributeCollection trackAttribute = childNode.Attributes;
//                                            //判断五金集合中是否已经包含该五金,有则数量+1，无则添加
//                                            string trackName = trackAttribute["Name"].Value;
//                                            if (lstSolution2Hardware.Select(x => x.HardwareName).Contains(trackName))
//                                            {
//                                                var existHardware = lstSolution2Hardware.FirstOrDefault(x => x.HardwareName.Equals(trackName));
//                                                existHardware.Qty += (string.IsNullOrEmpty(trackAttribute["Count"].Value)) ? 1 : Convert.ToDecimal(trackAttribute["Count"].Value);
//                                            }
//                                            else
//                                            {
//                                                //将五金配件添加到集合中
//                                                lstSolution2Hardware.Add(new Solution2Hardware()
//                                                {
//                                                    ItemID = Guid.NewGuid(),
//                                                    BarcodeNo = trackAttribute["LinkCode"].Value,
//                                                    SolutionID = cabinet.SolutionID,
//                                                    CabinetID = cabinet.CabinetID,
//                                                    HardwareCode = trackAttribute["LinkCode"].Value,
//                                                    HardwareName = trackName,
//                                                    HardwareCategory = trackName,
//                                                    Style = string.Empty,
//                                                    Qty = Convert.ToDecimal(trackAttribute["Count"].Value),
//                                                    Unit = trackAttribute["UnitName"].Value,
//                                                    Remarks = string.Empty,
//                                                    Created = DateTime.Now,
//                                                    CreatedBy = "DLS.System",
//                                                    Modified = DateTime.Now,
//                                                    ModifiedBy = "DLS.System"
//                                                });
//                                            }
//                                            #endregion
//                                            break;
//                                        case "PartsList":
//                                            #region 添加五金（第5种情况）

//                                            XmlNodeList lstParts = childNode.ChildNodes;
//                                            foreach (XmlNode parts in lstParts)
//                                            {
//                                                XmlAttributeCollection partsAttribute = parts.Attributes;
//                                                //判断五金集合中是否已经包含该五金,有则数量+1，无则添加
//                                                string partsName = partsAttribute["Name"].Value;
//                                                if (lstSolution2Hardware.Select(x => x.HardwareName).Contains(partsName))
//                                                {
//                                                    var existHardware = lstSolution2Hardware.FirstOrDefault(x => x.HardwareName.Equals(partsName));
//                                                    existHardware.Qty += (string.IsNullOrEmpty(partsAttribute["Count"].Value)) ? 1 : Convert.ToDecimal(partsAttribute["Count"].Value);
//                                                }
//                                                else
//                                                {
//                                                    //将五金配件添加到集合中
//                                                    lstSolution2Hardware.Add(new Solution2Hardware()
//                                                    {
//                                                        ItemID = Guid.NewGuid(),
//                                                        BarcodeNo = partsAttribute["Number"].Value,
//                                                        SolutionID = cabinet.SolutionID,
//                                                        CabinetID = cabinet.CabinetID,
//                                                        HardwareCode = partsAttribute["Number"].Value,
//                                                        HardwareName = partsName,
//                                                        HardwareCategory = partsName,
//                                                        Style = partsAttribute["Specs"].Value,
//                                                        Qty = Convert.ToDecimal(partsAttribute["Count"].Value),
//                                                        Unit = partsAttribute["Unit"].Value,
//                                                        Remarks = partsAttribute["Brand"].Value,
//                                                        Created = DateTime.Now,
//                                                        CreatedBy = "DLS.System",
//                                                        Modified = DateTime.Now,
//                                                        ModifiedBy = "DLS.System"
//                                                    });
//                                                }
//                                            }
//                                            #endregion
//                                            break;
//                                        default:
//                                            break;
//                                    }
//                                }
//                            }
//                        }

//                        #endregion

//                        #region Insert BE_SolutionDetail
//                        foreach (var solutionDetail in lstSolutionDetail)
//                        {
//                            p.Client.SaveSolutionDetail(SenderUser, solutionDetail);
//                        }
//                        #endregion

//                        #region Insert BE_Solution2Hardware
//                        foreach (var solution2Hardware in lstSolution2Hardware)
//                        {
//                            p.Client.SaveSolution2Hardware(SenderUser, solution2Hardware);
//                        }
//                        #endregion
//                    }

//                    #region 更新任务流程
//                    Database dbCheck = new Database("BE_PartnerTask_Proc", "UPSTEPNO3", 4, 0, designID.ToString(), "生成报价明细", "P");
//                    int rst = dbCheck.ExecuteNoQuery();
//                    if (rst == 0)
//                    {
//                        WriteError("更新任务流程失败！");
//                    }
//                    #endregion
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }

//                #endregion
//            }
//        }

//        /// <summary>
//        /// 解析xml入库
//        /// </summary>
//        /// <param name="FileUrl"></param>
//        public void CreateOrderByFileUrl(string FileUrl)
//        {
//            using (ProxyBE p = new ProxyBE())
//            {
//                #region 参数
//                string OrderFileName = string.Empty;
//                string directoryPath = FileUrl.Substring(0, FileUrl.LastIndexOf('/') + 1);
//                string archiveUrl = HttpContext.Current.Server.MapPath(FileUrl); //压缩包完整路径
//                if (!string.IsNullOrEmpty(archiveUrl))
//                {
//                    OrderFileName = Path.GetFileName(archiveUrl);
//                    if (!File.Exists(archiveUrl)) throw new Exception(string.Format("{0}:xml订单文件不存在", OrderFileName));
//                }

//                #region 解压rar文件
//                using (var reader = RarReader.Open(File.OpenRead(archiveUrl)))
//                {
//                    while (reader.MoveToNextEntry())
//                    {
//                        reader.WriteEntryToDirectory(AppDomain.CurrentDomain.BaseDirectory, new ExtractionOptions()
//                        {
//                            ExtractFullPath = true,
//                            Overwrite = true
//                        });
//                    }
//                }
//                #endregion

//                XmlDocument doc = new XmlDocument();
//                try
//                {
//                    doc.Load(archiveUrl);
//                }
//                catch
//                {
//                    throw new Exception(string.Format("{0}:文件有误,请手工录入订单", OrderFileName));
//                }
//                if (string.IsNullOrEmpty(doc.OuterXml))
//                {
//                    throw new Exception(string.Format("{0}:文件有误", OrderFileName));
//                }

//                XmlNode root = doc.DocumentElement;
//                XmlNode OrderNode = root.SelectSingleNode("/NewDataSet/ERP_Order");
//                if (OrderNode == null)
//                {
//                    throw new Exception(string.Format("{0}:OrderNode节点不存在", OrderFileName));
//                }
//                XmlNodeList OrderList = root.SelectNodes("/NewDataSet/ERP_OrderList");
//                if (OrderList.Count == 0)
//                {
//                    throw new Exception(string.Format("{0}:没有产品,请选择手工录入", OrderFileName));
//                }

//                var OutOrderNo = SelectSingleNode(root, "/NewDataSet/ERP_Order/OrderOddNumber");//订单号
//                var OrderType = SelectSingleNode(root, "/NewDataSet/ERP_Order/OrderType");//订单类型
//                var BookingDate = SelectSingleNode(root, "/NewDataSet/ERP_Order/OrderDate"); //下单日期
//                var ShipDate = SelectSingleNode(root, "/NewDataSet/ERP_Order/DeliverMemo"); //发货日期
//                var Remark = SelectSingleNode(root, "/NewDataSet/ERP_Order/OrderMemo");//备注

//                var PartnerOutCode = SelectSingleNode(root, "/NewDataSet/ERP_Order/ClientCode");//经销商代号
//                var PartnerName = SelectSingleNode(root, "/NewDataSet/ERP_Order/ClientName"); //经销商名称
//                var CustomerName = SelectSingleNode(root, "/NewDataSet/ERP_Order/ReceiveAddress");//客户名称
//                var Address = SelectSingleNode(root, "/NewDataSet/ERP_Order/ReceiveCorp");//客户地址  
//                var Mobile = SelectSingleNode(root, "/NewDataSet/ERP_Order/ReceivePhone"); //客户电话
//                #endregion

//            }
//        }
//        /// <summary>
//        /// 获取产品规格,请对异常进行处理
//        /// </summary>
//        /// <param name="Size"></param>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        private int GetCabinetSize(string Size, int index)
//        {
//            int resurt = 0;
//            try
//            {
//                if (!string.IsNullOrEmpty(Size))
//                {
//                    string[] array = Size.Split('*');
//                    if ((array.Length - 1) >= index) return int.Parse(array[index]);
//                    else return resurt;
//                }
//            }
//            catch (Exception)
//            {

//            }
//            return resurt;
//        }
//        /// <summary>
//        /// 获取XML属性值,请对异常进行处理
//        /// </summary>
//        /// <param name="item"></param>
//        /// <param name="xpath"></param>
//        /// <returns></returns>
//        private string SelectSingleNode(XmlNode item, string xpath)
//        {
//            string str = string.Empty;
//            try
//            {
//                if (item.SelectSingleNode(xpath) != null)
//                {
//                    str = item.SelectSingleNode(xpath).InnerText;
//                }
//            }
//            catch (Exception)
//            {

//            }
//            return str;
//        }
//        #endregion

//        #region 打印订单条码
//        public void PrintOrderNoBarcode()
//        {
//            try
//            {
//                using (ProxyBE p = new ProxyBE())
//                {
//                    if (string.IsNullOrEmpty(Request["WaitPrintBarcodeNo"]))
//                    {
//                        throw new Exception("无效参数调用。");
//                    }
//                    List<string> orderNoList = Request["WaitPrintBarcodeNo"].Split('|').ToList();
//                    //List<Order> orderList = p.Client.GetOrderByOrderNoList(SenderUser, orderNoList);
//                    //string json = JSONHelper.List2DataSetJson(orderList);
//                    //Response.Write(json);

//                    SearchResult sr = p.Client.SearchOrdersByOrderNoList(SenderUser, orderNoList);
//                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
//                }
//            }
//            catch (Exception ex)
//            {
//                WriteError(ex.Message, ex);
//            }
//        }
//        #endregion
//    }
//}