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

    public class PartnerOrderHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        PartnerOrderParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new PartnerOrderParm(context);
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

        #region 查询预订单
        public void SearchPartnerOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPartnerOrderArgs args = new SearchPartnerOrderArgs();

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
                    if (!string.IsNullOrEmpty(Request["source"]))
                    {
                        args.Status = OrderStatus.B.ToString().Split(',').ToList();
                    }
                    if (!string.IsNullOrEmpty(parm.OrderType) && Request["OrderType"] != "全部")
                    {
                        args.OrderTypes = parm.OrderType.Split(',').ToList();
                    }
                    if (!string.IsNullOrEmpty(parm.OrderNo))
                    {
                        args.OrderNo = parm.OrderNo;
                    }

                    if (!string.IsNullOrEmpty(parm.OutOrderNo))
                    {
                        args.OutOrderNo = parm.OutOrderNo;
                    }
                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        args.Mobile = parm.Mobile;
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
                        args.StepNo = (model==null?"-1": (model.StepNo-1).ToString());
                    }

                    if (CurrentUser.UserType == (int)UserType.D)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }

                    SearchResult sr = p.Client.SearchPartnerOrder(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void GetPartnerOrder()
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
                    var orderInfo = p.Client.GetPartnerOrder(SenderUser, OrderID);
                    Response.Write(JSONHelper.Object2Json(orderInfo));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetOrderStep()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    List<OrderStep> list = p.Client.GetAllOrderSteps(SenderUser);
                    Response.Write(JSONHelper.Object2JSON(list));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetPartnerOrderProduct()
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
                        Guid OrderID = new Guid(Request["OrderID"]);//默认按OrderID查询
                        List<PartnerOrderProduct> lists = p.Client.GetPartnerOrderProductByOrderID(SenderUser, new Guid(Request["OrderID"]));
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

        #endregion

        #region 操作预订单

        public void SavePartnerOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    #region Order
                    var flag = "false";
                    PartnerOrder order = p.Client.GetPartnerOrder(SenderUser, parm.OrderID);
                    if (parm.OrderType == "")
                    {
                        throw new Exception("请选择订单类型");
                    }
                    if (order == null)
                    {
                        order = new PartnerOrder();
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
                    order.Status = OrderStatus.A.ToString();
                    order.StepNo = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.partneraddorder.ToString()).StepNo;
                    SavePartnerOrderArgs args = new SavePartnerOrderArgs();
                    args.Order = order;
                    #endregion

                    #region OrderProduct
                    List<PartnerOrderProduct> list = new List<PartnerOrderProduct>();
                    string Cabinets = Request["Cabinets"];
                    JsonData sj = JsonMapper.ToObject(Cabinets);
                    if (sj.Count > 0)
                    {
                        foreach (JsonData item in sj)
                        {
                            PartnerOrderProduct model = new PartnerOrderProduct();
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
                    args.PartnerOrderProducts = list;
                    #endregion

                    #region  OrderLog /OrderTask
                    if (flag != "true")
                    {
                        OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.partneraddorder.ToString());
                        OrderStepLog ot = new OrderStepLog();
                        ot.StepID = Guid.NewGuid();
                        ot.OrderID = order.OrderID;
                        ot.StepNo = step.StepNo;
                        ot.StepName = step.StepName;
                        ot.Remark = string.Empty;
                        args.OrderStepLog = ot;
                    }
                    #endregion

                    p.Client.SavePartnerOrder(SenderUser, args);
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

                    PartnerOrder order = p.Client.GetPartnerOrder(SenderUser, Guid.Parse(OrderID));
                    if (order.Status.ToUpper() == OrderStatus.A.ToString())
                    {
                        SavePartnerOrderArgs args = new SavePartnerOrderArgs();

                        if (ConfirmState == "true")//审核通过
                        {
                            OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.partnerordersconfirm.ToString());
                            OrderStepLog ot = new OrderStepLog();
                            ot.StepID = Guid.NewGuid();
                            ot.OrderID = order.OrderID;
                            ot.StepNo = step.StepNo;
                            ot.StepName = step.StepName;
                            ot.Remark = Request["Remark"];
                            args.OrderStepLog = ot;

                            order.Status = OrderStatus.B.ToString();
                            order.StepNo = step.StepNo;
                            args.Order = order;
                        }
                        else//审核不通过
                        {
                            OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.partnerordersconfirm.ToString());
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

                        p.Client.SavePartnerOrder(SenderUser, args);

                    }

                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void ImportPartnerOrder()
        {
            try
            {

                string OrderID = Request["OrderID"];
                if (string.IsNullOrEmpty(OrderID))
                {
                    throw new Exception("请选择订单类型");
                }
                if (CurrentUser.UserType == (int)UserType.D)
                {
                    throw new Exception("非法操作");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SaveOrderArgs args = new SaveOrderArgs();

                    PartnerOrder parm = p.Client.GetPartnerOrder(SenderUser, new Guid(OrderID));

                    //订单数据
                    Order order = new Order();
                    order.OrderID = parm.OrderID;
                    //order.OrderNo = parm.OrderNo;
                    order.PartnerID = parm.PartnerID;
                    order.CustomerID = parm.CustomerID;
                    order.OutOrderNo = parm.OrderNo;
                    order.Address = parm.Address;
                    order.CustomerName = parm.CustomerName;
                    order.AttachmentFile = parm.AttachmentFile;
                    order.PartnerName = parm.PartnerName;
                    order.SalesMan = parm.SalesMan;
                    order.BookingDate = parm.BookingDate;
                    order.Mobile = parm.Mobile;
                    order.ShipDate = parm.ShipDate;
                    order.OrderType = parm.OrderType;
                    order.Remark = parm.Remark;
                    order.Status = OrderStatus.C.ToString();
                    order.StepNo = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.importorder.ToString()).StepNo;
                    order.Created = DateTime.Now;
                    order.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                    args.Order = order;

                    //产品数据
                    List<PartnerOrderProduct> list = p.Client.GetPartnerOrderProductByOrderID(SenderUser, new Guid(OrderID));
                    List<OrderProduct> Products = new List<OrderProduct>();
                    foreach (PartnerOrderProduct item in list)
                    {
                        OrderProduct Product = new OrderProduct();
                        Product.OrderID = order.OrderID;
                        Product.ProductID = item.ProductID;
                        Product.ProductName = item.ProductName;
                        Product.ProductGroup = item.ProductGroup;
                        Product.Qty = item.Qty;
                        Product.Price = item.Price;
                        Product.Size = item.Size;
                        Product.MaterialStyle = item.MaterialStyle;
                        Product.Color = item.Color;
                        Product.MaterialCategory = item.MaterialCategory;
                        Product.Unit = item.Unit;
                        Product.Remark = item.Remark;
                        Product.SalePrice = item.SalePrice;
                        Product.TotalAreal = item.TotalAreal;
                        Product.TotalLength = item.TotalLength;
                        Product.Created = DateTime.Now;
                        Product.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                        Products.Add(Product);
                    }
                    args.OrderProducts = Products;

                    OrderStep step = p.Client.GetOrderStepByStepCode(SenderUser, StepCode.importorder.ToString());

                    OrderStepLog ot = new OrderStepLog();
                    ot.StepID = Guid.NewGuid();
                    ot.OrderID = order.OrderID;
                    ot.StepNo = step.StepNo;
                    ot.StepName = step.StepName;
                    ot.Remark =string.Empty;
                    args.OrderStepLog = ot;

                    p.Client.SaveOrder(SenderUser, args);
                    Order model = new Order()
                    {
                        Status= args.Order.Status,
                        StepNo = args.Order.StepNo,
                        OrderID = args.Order.OrderID,
                    };
                    p.Client.UpdatePartnerOrder(model);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        #endregion

    }
}