using ICSharpCode.SharpZipLib.Zip;
using LitJson;
using Mes.Client.Model;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Enum;
using Mes.Client.Utility.Extensions;
using Mes.Client.Utility.Pages;
using MES.BE.Objects;
using MES.Libraries;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SharpCompress.Readers;
using SharpCompress.Readers.Rar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;

namespace Mes.Client.UI.Ashx
{

    public class OrdersHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        OrderParm parm = null;
        PartnerTransDetailParm pparm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new OrderParm(context);
                pparm = new PartnerTransDetailParm(context);
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

        #region 查询订单
        public void SearchOrders()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchOrderArgs args = new SearchOrderArgs();

                    args.OrderBy = "Created desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(Request["OrderIDs"]))
                    {
                        args.OrderIDs = new List<Guid>();
                        foreach (string id in Request["OrderIDs"].ToString().Split(',').ToList())
                        {
                            args.OrderIDs.Add(new Guid(id));
                        }
                    }
                    if (!string.IsNullOrEmpty(parm.Status) && Request["Status"] != "全部")
                    {
                        args.Status = parm.Status.Split(',').ToList();
                    }
                    if (!string.IsNullOrEmpty(parm.OrderType) && Request["OrderType"] != "全部")
                    {
                        args.OrderTypes = parm.OrderType.Split(',').ToList();
                    }
                    if (!string.IsNullOrEmpty(parm.OrderNo))
                    {
                        args.OrderNo = parm.OrderNo;
                    }
                    if (!string.IsNullOrEmpty(parm.PurchaseNo))
                    {
                        args.PurchaseNo = parm.PurchaseNo;
                    }

                    if (!string.IsNullOrEmpty(parm.BattchNum))
                    {
                        args.BattchNo = parm.BattchNum;
                    }

                    if (!string.IsNullOrEmpty(parm.OutOrderNo))
                    {
                        args.OutOrderNo = parm.OutOrderNo;
                    }
                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        args.Mobile = parm.Mobile;
                    }
                    if (!string.IsNullOrEmpty(parm.BattchNum))
                    {
                        args.BattchNo = parm.BattchNum;
                    }
                    if (!string.IsNullOrEmpty(parm.Address))
                    {
                        args.Address = parm.Address;
                    }
                    if (!string.IsNullOrEmpty(parm.CustomerName))
                    {
                        args.CustomerName = parm.CustomerName;
                    }
                    if (!string.IsNullOrEmpty(Request["BookingDateFrom"]))
                    {
                        args.BookingDateFrom = parm.BookingDateFrom;
                    }
                    if (!string.IsNullOrEmpty(Request["BookingDateTo"]))
                    {
                        args.BookingDateTo = parm.BookingDateTo.AddDays(1);
                    }
                    if (!string.IsNullOrEmpty(Request["ShipDateFrom"]))
                    {
                        args.ShipDateFrom = parm.ShipDateFrom;
                    }
                    if (!string.IsNullOrEmpty(Request["ShipDateTo"]))
                    {
                        args.ShipDateTo = parm.ShipDateTo.AddDays(1);
                    }
                    if (!string.IsNullOrEmpty(Request["StepNo"]))
                    {
                        args.StepNo = parm.StepNo.ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["Review"]) && !string.IsNullOrEmpty(Request["pid"]))
                    {
                        OrderStep model = p.Client.GetOrderStepByPrivilegeID(SenderUser, new Guid(Request["pid"]));
                        args.StepNo = (model == null ? "-1" : (model.StepNo - 1).ToString());
                    }

                    if (CurrentUser.UserType == (int)UserType.D)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }

                    SearchResult sr = p.Client.SearchOrder(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void GetOrder()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["OrderID"]))
                {
                    throw new Exception("订单ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Guid OrderID = new Guid(Request["OrderID"]);
                    var orderInfo = p.Client.GetOrder(SenderUser, OrderID);
                    Response.Write(JSONHelper.Object2Json(orderInfo));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetOrderProducts()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["OrderID"]))
                {
                    Response.Write("{\"total\":0,\"rows\":[]}");
                }
                else
                {
                    using (ProxyBE p = new ProxyBE())
                    {
                        List<OrderProduct> lists = p.Client.GetOrderProductByOrderID(SenderUser, new Guid(Request["OrderID"]));
                        string json = JSONHelper.List2DataSetJson(lists);

                        Response.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetStepsByOrder()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["OrderID"]))
                {
                    Response.Write("{\"total\":0,\"rows\":[]}");
                }
                else
                {
                    using (ProxyBE p = new ProxyBE())
                    {
                        var oid = Request["OrderID"].ToString();
                        List<OrderStepLog> lists = p.Client.GetOrderStepLogByOrderID(SenderUser, new Guid(oid));
                        lists.Sort((x, y) => x.Started.CompareTo(y.Started));
                        string json = JSONHelper.List2DataSetJson(lists);
                        Response.Write(json);
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
        #endregion

        #region 操作订单
        public void SaveOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    #region Order
                    var flag = "false";
                    Order order = p.Client.GetOrder(SenderUser, parm.OrderID);
                    if (parm.OrderType == "")
                    {
                        throw new Exception("请选择订单类型");
                    }
                    if (order == null)
                    {
                        order = new Order();
                        order.OrderID = parm.OrderID;
                    }

                    //修改订单保存
                    flag = Request["edit"];
                    if (flag == "true")
                    {
                        order.OrderNo = parm.OrderNo;
                    }
                    else
                    {
                        order.OrderNo = "";
                    }
                    order.PartnerID = parm.PartnerID;
                    order.CustomerID = parm.CustomerID;
                    order.OutOrderNo = parm.OutOrderNo;
                    order.Address = parm.Address;
                    order.CustomerName = parm.CustomerName;
                    order.AttachmentFile = HttpUtility.UrlDecode(parm.AttachmentFile, Encoding.UTF8);
                    order.PartnerName = parm.PartnerName;
                    order.SalesMan = parm.SalesMan;
                    order.BookingDate = parm.BookingDate;
                    order.Mobile = parm.Mobile;
                    order.ShipDate = parm.ShipDate;
                    order.OrderType = parm.OrderType;
                    order.Remark = parm.Remark;
                    order.Status = OrderStatus.C.ToString();
                    order.StepNo = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.addorder.ToString()).StepNo;
                    SaveOrderArgs args = new SaveOrderArgs();
                    args.Order = order;
                    #endregion

                    #region OrderProduct
                    List<OrderProduct> list = new List<OrderProduct>();
                    string Cabinets = Request["Cabinets"];
                    JsonData sj = JsonMapper.ToObject(Cabinets);
                    if (sj.Count > 0)
                    {
                        foreach (JsonData item in sj)
                        {
                            OrderProduct model = new OrderProduct();
                            model.OrderID = order.OrderID;
                            model.ProductID = Guid.Parse(item["ProductID"].ToString());
                            model.ProductName = item["ProductName"].ToString();
                            model.ProductGroup = item["ProductGroup"].ToString();
                            model.Qty = Decimal.Parse(item["Qty"].ToString());
                            model.Price = Decimal.Parse(item["Price"].ToString());
                            model.Size = item["Size"].ToString();
                            model.MaterialStyle = item["MaterialStyle"].ToString();
                            model.Color = item["Color"].ToString();
                            model.MaterialCategory = item["MaterialCategory"].ToString();
                            model.Unit = item["Unit"].ToString();
                            model.Remark = item["Remark"].ToString();
                            model.SalePrice = 0;
                            model.TotalAreal = 0;
                            model.TotalLength = 0;
                            model.ProductStatus = "N";
                            //Product.ProductCode = ((char)(64 + cabinet.Sequence)).ToString();
                            if (flag == "true")
                            {
                                model.Created = DateTime.Now;
                                model.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                            }
                            list.Add(model);
                        }
                    }
                    args.OrderProducts = list;
                    #endregion

                    #region  OrderLog /OrderTask
                    if (flag != "true")
                    {
                        OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.addorder.ToString());
                        OrderStepLog ot = new OrderStepLog();
                        ot.StepID = Guid.NewGuid();
                        ot.OrderID = order.OrderID;
                        ot.StepNo = step.StepNo;
                        ot.StepName = step.StepName;
                        ot.Remark = string.Empty;
                        args.OrderStepLog = ot;
                    }
                    #endregion

                    #region OrderProcessFile
                    string filePath = Config.StorageFolder;
                    Partner partner = p.Client.GetPartner(SenderUser, order.PartnerID);
                    string PartnerCode = partner.PartnerCode;
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyyMM"));
                    filePath = Path.Combine(filePath, PartnerCode);
                    filePath = Path.Combine(filePath, DateTime.Now.ToString("yyyyMM"));
                    filePath = Path.Combine(filePath, PartnerCode + "-" + DateTime.Now.ToString("yyyyMM"));
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    List<OrderProcessFile> ProcessFiles = new List<OrderProcessFile>();
                    IList<HttpPostedFile> SceneFiles = Request.Files.GetMultiple("SceneFile");
                    foreach (HttpPostedFile file in SceneFiles)
                    {
                        if (file.ContentLength == 0) continue;
                        string savepath = Path.Combine(filePath, "SceneFile");
                        if (!Directory.Exists(savepath))
                        {
                            Directory.CreateDirectory(savepath);
                        }
                        savepath = Path.Combine(savepath, file.FileName);
                        if (File.Exists(savepath))
                        {
                            File.Delete(savepath);
                        }
                        file.SaveAs(savepath);
                        OrderProcessFile pf = p.Client.GetOrderProcessFileByOrderID_FileType_FileName(SenderUser, order.OrderID, "SceneFile", Path.GetFileName(savepath));
                        if (pf == null)
                        {
                            pf = new OrderProcessFile();
                            pf.OrderID = parm.OrderID;
                            pf.FileID = Guid.NewGuid();
                            pf.FileName = Path.GetFileName(savepath);
                            pf.FilePath = savepath;
                            pf.FileType = "SceneFile";
                        }
                        ProcessFiles.Add(pf);
                    }


                    if (ProcessFiles.Count > 0)
                    {
                        args.OrderProcessFiles = ProcessFiles;
                    }
                    #endregion

                    p.Client.SaveOrder(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void OrdersConfirm()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string remark = Request["Remark"];
                    if (string.IsNullOrEmpty(Request["Remark"]))
                    {
                        throw new Exception("Remark:参数无效");
                    }
                    string OrderID = Request["OrderID"];
                    if (string.IsNullOrEmpty(Request["OrderID"]))
                    {
                        throw new Exception("OrderID:参数无效");
                    }
                    string ConfirmState = Request["ConfirmState"];

                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(OrderID));

                    if (order.Status.ToUpper() == OrderStatus.C.ToString())
                    {
                        SaveOrderArgs args = new SaveOrderArgs();

                        if (ConfirmState == "true")//审核通过
                        {
                            OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.ordersconfirm.ToString());
                            OrderStepLog ot = new OrderStepLog();
                            ot.StepID = Guid.NewGuid();
                            ot.OrderID = order.OrderID;
                            ot.StepNo = step.StepNo;
                            ot.StepName = step.StepName;
                            ot.Remark = Request["Remark"];
                            args.OrderStepLog = ot;

                            order.Status = OrderStatus.D.ToString();
                            order.StepNo = step.StepNo;
                            args.Order = order;
                        }
                        else//审核不通过
                        {
                            OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.ordersconfirm.ToString());
                            OrderStepLog ot = new OrderStepLog();
                            ot.StepID = Guid.NewGuid();
                            ot.OrderID = order.OrderID;
                            ot.StepNo = step.StepNo;
                            ot.StepName = step.StepName;
                            ot.Remark = Request["Remark"];
                            args.OrderStepLog = ot;

                            order.Status = OrderStatus.Z.ToString();
                            order.StepNo = 0;
                            args.Order = order;
                        }

                        p.Client.SaveOrder(SenderUser, args);
                        p.Client.UpdatePartnerOrder(args.Order);
                    }

                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void OrdersDesign()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string OrderID = Request["OrderIDs"];
                    if (string.IsNullOrEmpty(OrderID))
                    {
                        throw new Exception("OrderID:参数无效");
                    }

                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(OrderID));

                    if (order.Status.ToUpper() == OrderStatus.D.ToString())
                    {
                        SaveOrderArgs args = new SaveOrderArgs();

                        OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.ordersdesign.ToString());
                        OrderStepLog ot = new OrderStepLog();
                        ot.StepID = Guid.NewGuid();
                        ot.OrderID = order.OrderID;
                        ot.StepNo = step.StepNo;
                        ot.StepName = step.StepName;
                        ot.Remark =string.Empty;
                        args.OrderStepLog = ot;

                        order.Status = OrderStatus.E.ToString();
                        order.StepNo = step.StepNo;
                        args.Order = order;

                        p.Client.SaveOrder(SenderUser, args);
                        p.Client.UpdatePartnerOrder(args.Order);
                    }
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void OrdersPrize()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Order order = p.Client.GetOrder(SenderUser, parm.OrderID);

                    if (order.Status.ToUpper() == OrderStatus.E.ToString())
                    {
                        SaveOrderArgs args = new SaveOrderArgs();

                        OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.ordersprice.ToString());
                        OrderStepLog ot = new OrderStepLog();
                        ot.StepID = Guid.NewGuid();
                        ot.OrderID = order.OrderID;
                        ot.StepNo = step.StepNo;
                        ot.StepName = step.StepName;
                        ot.Remark =string.Empty;
                        args.OrderStepLog = ot;

                        order.Status = OrderStatus.F.ToString();
                        order.StepNo = step.StepNo;
                        args.Order = order;

                        List<OrderProduct> list = new List<OrderProduct>();
                        string Cabinets = Request["Cabinets"];
                        JsonData sj = JsonMapper.ToObject(Cabinets);
                        if (sj.Count > 0)
                        {
                            foreach (JsonData item in sj)
                            {
                                OrderProduct model = p.Client.GetOrderProduct(SenderUser, Guid.Parse(item["ProductID"].ToString()));
                                model.SalePrice = Decimal.Parse(item["SalePrice"].ToString());
                                list.Add(model);
                            }
                        }
                        args.OrderProducts = list;

                        p.Client.SaveOrder(SenderUser, args);
                        p.Client.UpdatePartnerOrder(args.Order);
                    }
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void OrderReview()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string OrderID = Request["OrderID"];
                    if (string.IsNullOrEmpty(OrderID))
                    {
                        throw new Exception("OrderID:参数无效");
                    }
                    string Remark = Request["Remark"];
                    if (string.IsNullOrEmpty(Remark))
                    {
                        throw new Exception("Remark:参数无效");
                    }
                    Order order = p.Client.GetOrder(SenderUser, Guid.Parse(OrderID));

                    if (order.Status.ToUpper() == OrderStatus.F.ToString())
                    {
                        SaveOrderArgs args = new SaveOrderArgs();

                        OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.ordersreview.ToString());
                        OrderStepLog ot = new OrderStepLog();
                        ot.StepID = Guid.NewGuid();
                        ot.OrderID = order.OrderID;
                        ot.StepNo = step.StepNo;
                        ot.StepName = step.StepName;
                        ot.Remark = Remark;
                        args.OrderStepLog = ot;

                        order.Status = OrderStatus.G.ToString();
                        order.StepNo = step.StepNo;
                        args.Order = order;

                        p.Client.SaveOrder(SenderUser, args);
                        p.Client.UpdatePartnerOrder(args.Order);
                    }

                    #region PartnerTransDetail
                    string Payee = Request["Payee"].ToString();//收款人
                    string Amount = Request["Amount"].ToString();//收款金额
                    string TransDate = Request["TransDate"].ToString();//收款日期
                    string VoucherNo = Request["VoucherNo"].ToString();//凭证号
                    if (!string.IsNullOrEmpty(Payee) && !string.IsNullOrEmpty(Amount) && !string.IsNullOrEmpty(TransDate) && !string.IsNullOrEmpty(VoucherNo))
                    {
                        ReviewDetail model = new ReviewDetail()
                        {
                            TransID = Guid.NewGuid(),
                            OrderID = order.OrderID,
                            Payee = Payee,
                            Amount = decimal.Parse(Amount),
                            TransDate = Convert.ToDateTime(TransDate),
                            VoucherNo = VoucherNo,
                        };
                        p.Client.SaveReviewDetail(SenderUser, model);
                    }
                    #endregion

                    #region ProductBOM
                    List<OrderProduct> list = p.Client.GetOrderProductByOrderID(SenderUser, order.OrderID);
                    foreach(OrderProduct Item in list)
                    {
                        ProductBOM model = new ProductBOM()
                        {
                            ProductCode = Item.ProductCode,
                            Status =false,
                        };
                        p.Client.SaveProductBOM(SenderUser, model);
                    }
                    #endregion
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void CancelOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid OrderID = new Guid(Request["OrderID"]);
                    Order order = p.Client.GetOrder(SenderUser, OrderID);



                    order.Status = "C"; // 订单取消
                    SaveOrderArgs args = new SaveOrderArgs();
                    args.Order = order;
                    order.StepNo++;


                    List<OrderProduct> list = p.Client.GetOrderProductByOrderID(SenderUser, order.OrderID);
                    foreach (OrderProduct item in list)
                    {
                        item.ProductStatus = "C";
                    }
                    args.OrderProducts = list;

                    p.Client.SaveOrder(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        #endregion

    }
}