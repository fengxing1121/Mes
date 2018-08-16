using Mes.BE.Objects;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Mes.BE.Services
{
    public partial class ServiceBE : IServiceBE
    {
        public OrderDetail GetOrderDetailByBarcode(Sender sender, string Barcode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderDetail obj = new OrderDetail();
                    obj.BarcodeNo = Barcode;

                    if (op.LoadOrderDetailByBarcodeNo(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        /// <summary>
        /// 查询指定工序下产品记录
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="WorkFlowID">工序ID</param>
        /// <param name="MadeQty">生产状态</param>
        /// <returns></returns>
        public List<OrderDetail> GetOrderDetailsByWorkFlowID(Guid orderID, Guid WorkFlowID, int MadeQty)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderDetailsByWorkFlowID(orderID, WorkFlowID, MadeQty);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public bool IsOrderDetailBarcodeDuplicated(Sender sender, OrderDetail orderDetail)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderDetail obj = new OrderDetail();
                    obj.BarcodeNo = orderDetail.BarcodeNo;

                    if (op.LoadOrderDetailByBarcodeNo(obj) == 0)
                    {
                        return false;
                    }
                    return obj.ItemID != orderDetail.ItemID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchOrderDetail(Sender sender, SearchOrderDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchOrderDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<OrderDetail> GetOrderDetails(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadOrderDetailsByOrderID(OrderID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public OrderDetail GetOrderDetail(Sender sender, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    OrderDetail obj = new OrderDetail();
                    obj.ItemID = ItemID;
                    if (op.LoadOrderDetailByItemID(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrderDetailByOrderID(Sender sender, Guid OrderID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrderDetailsByOrderID(OrderID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteOrderDetailByCabinetID(Sender sender, Guid CabinetID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteOrderDetailsByCabinetID(CabinetID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public SearchResult SearchAPSByTotal(SearchAPSDetailsArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchAPSByTotal(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchAPSByOrderDetails(SearchAPSDetailsArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchAPSByOrderDetails(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchAPSByRemoveDetails(SearchAPSDetailsArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchAPSByRemoveDetails(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
