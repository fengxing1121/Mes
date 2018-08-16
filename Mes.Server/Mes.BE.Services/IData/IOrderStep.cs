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
        OrderStep GetOrderStep(Sender sender, Guid StepID);

        [OperationContract]
        List<OrderStep> GetAllOrderSteps(Sender sender);

        [OperationContract]
        void SaveOrderStep(Sender sender, OrderStep obj);

        [OperationContract]
        OrderStep GetOrderStepByStepCode(Sender sender, string StepCode);

        [OperationContract]
        OrderStep GetOrderStepByPrivilegeID(Sender sender, Guid PrivilegeID);
    }
}

