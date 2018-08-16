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
        void SaveSysLog(Sender sender, SaveSysLogArgs args);
        [OperationContract]
        SearchResult SearchSysLogs(Sender sender, SearchSysLogArgs args);
    }
}
