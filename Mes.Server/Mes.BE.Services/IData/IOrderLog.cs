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
        List<OrderLog> GetOrderLogs(Sender sender, Guid OrderID);
        [OperationContract]
        List<OrderLog> GetOrderStatusLogsByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        void SaveOrderLog(Sender sender, SaveOrderLogArgs args);
    }
}
