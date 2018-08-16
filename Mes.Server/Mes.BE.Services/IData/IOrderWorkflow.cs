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
        SearchResult SearchAllOrderWorkflow(Sender sender, SearchOrderWorkFlowArgs args);
        [OperationContract]
        void ScanBarcode(Sender sender, string Barcode, Guid WorkShiftID, Guid WorkFlowID);
        [OperationContract]
        void ReworkScanBarcode(Sender sender, string Barcode, Guid WorkShiftID, Guid WorkFlowID);
        [OperationContract]
        void UpdateOrderWorkFlowByPrintCount(Sender sender, Guid WorkingID, Guid OrderID);
        [OperationContract]
        List<OrderWorkFlow> GetOrderWorkFlowByItemID(Sender sender, Guid ItemID);
        [OperationContract]
        OrderWorkFlow GetOrderWorkFlow(Sender sender, Guid WorkingID);
        [OperationContract]
        OrderWorkFlow GetOrderWorkFlowByItemID_WorkFlowNo(Sender sender, Guid ItemID, int WorkFlowNo);
        [OperationContract]
        void SaveOrderWorkFlow(Sender sender, SaveOrderWorkFlowArgs args);
        [OperationContract]
        SearchResult SearchOrderWorkFlow(Sender sender, SearchOrderWorkFlowArgs args);
        [OperationContract]
        List<OrderWorkFlow> GetOrderWorkFlowsBySearchKey(Sender sender, string SearchKey);
        [OperationContract]
        List<OrderWorkFlow> GetOrderWorkFlowsByProcessed(Sender sender, Guid ItemID);
        [OperationContract]
        List<OrderWorkFlow> GetOrderWorkFlowByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        int CountOrderWorkFlows(Guid CabinetID);
        [OperationContract]
        SearchResult SearchPrintListByOrderWorkFlow(Sender sender, SearchOrderWorkFlowArgs args);
        [OperationContract]
        SearchResult SearchScanListByOrderWorkFlow(Sender sender, SearchOrderWorkFlowArgs args);
    }
}
