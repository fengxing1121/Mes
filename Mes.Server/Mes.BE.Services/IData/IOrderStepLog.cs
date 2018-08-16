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
        OrderStepLog GetOrderStepLog(Sender sender, Guid StepID);

        [OperationContract]
        List<OrderStepLog> GetAllOrderStepLogs(Sender sender);

        [OperationContract]
        List<OrderStepLog> GetOrderStepLogByOrderID(Sender sender, Guid OrderID);

        [OperationContract]
        void SaveOrderStepLog(Sender sender, OrderStepLog obj);
    }
}

