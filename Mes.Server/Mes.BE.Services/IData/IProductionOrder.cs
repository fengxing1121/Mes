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
        ProductionOrder GetProductionOrder(Sender sender, Guid ProductionID);

        [OperationContract]
        List<ProductionOrder> GetAllProductionOrders(Sender sender);

        [OperationContract]
        List<ProductionOrder> GetProductionOrderByProductionID(Sender sender, Guid ProductionID);

        [OperationContract]
        SearchResult SearchProductionOrder(Sender sender, SearchProductionOrderArgs args);

        [OperationContract]
        void SaveProductionOrder(Sender sender, SaveProductionOrderArgs args);

        [OperationContract]
        SearchResult SearchProductComponents(Sender sender, Guid OrderID);

        [OperationContract]
        SearchResult SearchOrderByProductionOrder(Sender sender, SearchOrderArgs args);

        [OperationContract]
        void SchedulingProductionOrder(Sender sender, SchedulingProductionOrderArgs args);
    }
}

