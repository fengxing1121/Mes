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
        SpecialCompanent GetSpecialCompanent(Sender sender, Guid SpecialID);
        [OperationContract]
        void SaveSpecialCompanent(Sender sender, SaveSpecialCompanentArgs args);
        [OperationContract]
        List<SpecialCompanent> GetSpecialCompanents(Sender sender);
        [OperationContract]
        List<SpecialCompanent2WorkFlow> GetSpecialCompanent2WorkFlows(Sender sender, Guid SpecialID);
        [OperationContract]
        SearchResult SearchSpecialCompanent(Sender sender, SearchSpecialCompanentArgs args);
        [OperationContract]
        SearchResult SearchSpecialCompanent2WorkFlow(Sender sender, SearchSpecialCompanent2WorkFlowArgs args);
    }
}
