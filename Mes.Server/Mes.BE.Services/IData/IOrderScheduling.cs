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
        void CreatedScheduling(Sender sender, SaveCreatedSchedulingArgs args);
        [OperationContract]
        List<OrderScheduling> GetAllOrderSchedulings(Sender sender);
        [OperationContract]
        OrderScheduling GetOrderScheduling(Sender sender, Guid MadeID);
        [OperationContract]
        void SaveOrderScheduling(Sender sender, SaveOrderSchedulingArgs args);
        [OperationContract]
        List<OrderScheduling> GetOrderSchedulingByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        SearchResult SearchOrderScheduling(Sender sender, SearchOrderSchedulingArgs args);
    }
}
