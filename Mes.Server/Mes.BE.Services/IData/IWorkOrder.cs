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
        WorkOrder GetWorkOrder(Sender sender, Guid WorkOrderID);

        [OperationContract]
        List<WorkOrder> GetAllWorkOrders(Sender sender);

        [OperationContract]
        List<WorkOrder> GetWorkOrderByWorkOrderID(Sender sender, Guid WorkOrderID);

        [OperationContract]
        SearchResult SearchWorkOrder(Sender sender, SearchWorkOrderArgs args);

        [OperationContract]
        void SaveWorkOrders(Sender sender, SaveWorkOrderArgs args);
    }
}

