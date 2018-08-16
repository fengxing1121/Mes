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
        List<Order2CabinetLog> GetOrder2CabinetLog(Sender sender, Guid CabinetID);
        [OperationContract]
        SearchResult SearchOrder2CabinetLogs(Sender sender, SearchOrder2CabinetArgs args);
    }
}
