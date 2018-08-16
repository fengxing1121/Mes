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
    public partial interface IServiceBE
    {
        [OperationContract]
        OrderDetail GetOrderDetailByBarcode(Sender sender, string Barcode);
        [OperationContract]
        List<OrderDetail> GetOrderDetailsByWorkFlowID(Guid orderID, Guid WorkFlowID, int MadeQty);
        [OperationContract]
        bool IsOrderDetailBarcodeDuplicated(Sender sender, OrderDetail orderDetail);
        [OperationContract]
        SearchResult SearchOrderDetail(Sender sender, SearchOrderDetailArgs args);
        [OperationContract]
        List<OrderDetail> GetOrderDetails(Sender sender, Guid OrderID);
        [OperationContract]
        OrderDetail GetOrderDetail(Sender sender, Guid ItemID);
        [OperationContract]
        void DeleteOrderDetailByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        void DeleteOrderDetailByCabinetID(Sender sender, Guid CabinetID);
        [OperationContract]
        SearchResult SearchAPSByTotal(SearchAPSDetailsArgs args);
        [OperationContract]
        SearchResult SearchAPSByOrderDetails(SearchAPSDetailsArgs args);
        [OperationContract]
        SearchResult SearchAPSByRemoveDetails(SearchAPSDetailsArgs args);
    }
}
