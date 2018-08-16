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
        PartnerTask GetPartnerTask(Sender sender, Guid TaskID);
        [OperationContract]
        void SavePartnerTask(Sender sender, SavePartnerTaskArgs args);
        [OperationContract]
        SearchResult SearchPartnerTask(Sender sender, SearchPartnerTaskArgs args);
        [OperationContract]
        List<PartnerTaskStep> GetPartnerTaskStepByTaskID(Sender sender, Guid TaskID);

    }
}
