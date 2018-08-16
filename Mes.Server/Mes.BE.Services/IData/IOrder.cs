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
        Order GetOrder(Sender sender, Guid OrderID);

        [OperationContract]
        void SaveOrder(Sender sender, SaveOrderArgs args);

        [OperationContract]
        SearchResult SearchOrder(Sender sender, SearchOrderArgs args);

        [OperationContract]
        int UpdateOrder(Order args);


        #region  以下为旧接口，不用。如需使用请将方法移到外面，后续项目整理时这里面方法将删除
        [OperationContract]
        Order GetOrderByOrderNo(Sender sender, string OrderNo);
        [OperationContract]
        List<Order> GetAllOrders(Sender sender);

        [OperationContract]
        SearchResult SearchCloudSplitOrder(Sender sender, SearchOrderArgs args);
        [OperationContract]
        bool IsExistsCabinetNum(Guid OrderID, string CabinetNum);
        [OperationContract]
        SearchResult SearchOrdersByOrderNoList(Sender sender, List<string> orderNoList);
        [OperationContract]
        void UpdateOrderStatusByOrderIDs(Sender sender, List<Guid> OrderIDs, string OrderStatus, Guid ItemID);
        [OperationContract]
        void UpdateOrderStatusByBattchNum(Sender sender, string BattchNum, string OrderStatus);
        [OperationContract]
        SearchResult SearchPrintOrderData(Sender sender, string OrderNo);
        [OperationContract]
        int GetTotalOrderBattchQty(Sender sender, string BattchNo);
        [OperationContract]
        void UpdateOrderBattchIndex(Sender sender, string BattchNum);
        [OperationContract]
        string GetTaskNo(Sender sender);
        [OperationContract]
        string GetOrderNo(Sender sender);
        [OperationContract]
        string GetBattchNum(Sender sender);
        #endregion

    }
}

