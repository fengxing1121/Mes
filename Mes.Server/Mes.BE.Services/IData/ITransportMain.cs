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
        void SaveTransport(Sender sender, SaveTransportArgs args);
        [OperationContract]
        TransportMain GetTransportMain(Sender sender, Guid TransportID);
        [OperationContract]
        SearchResult SearchTransportMain(Sender sender, SearchTransportMainArgs args);
        [OperationContract]
        SearchResult SearchTransportDetail(Sender sender, SearchTransportDetailArgs args);
    }
}
