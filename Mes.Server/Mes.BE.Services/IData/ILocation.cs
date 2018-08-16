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
        Location GetLocation(Sender sender, Guid LocationID);
        [OperationContract]
        void SaveLocation(Sender sender, SaveLocationArgs args);
        [OperationContract]
        SearchResult SearchLocation(Sender sender, SearchLocationArgs args);
        [OperationContract]
        SearchResult SearchWarehouse(Sender sender, SearchWarehouseArgs args);
    }
}
