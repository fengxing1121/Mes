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
        void SaveSMSLog(Sender sender, SaveSMSLogArgs args);
        [OperationContract]
        SearchResult SearchSMSLogs(Sender sender, SearchSMSLogArgs args);

    }
}
