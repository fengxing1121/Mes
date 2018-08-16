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
        WorkFlow GetWorkFlow(Sender sender, Guid WorkFlowID);

        [OperationContract]
        List<WorkFlow> GetAllWorkFlows(Sender sender);

        [OperationContract]
        List<WorkFlow> GetWorkFlowByWorkFlowID(Sender sender, Guid WorkFlowID);

        [OperationContract]
        void SaveWorkFlow(Sender sender, WorkFlow obj);

        [OperationContract]
        SearchResult SearchWorkFlow(Sender sender, SearchWorkFlowArgs args);

    }
}

