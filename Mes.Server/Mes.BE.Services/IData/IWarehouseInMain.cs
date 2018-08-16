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
        SearchResult SearchWarehouseInDetail(Sender sender, SearchWarehouseInDetailArgs args);
        [OperationContract]
        List<WarehouseInMain> GetAllWarehouseInMains(Sender sender);
        [OperationContract]
        WarehouseInMain GetWarehouseInMain(Sender sender, Guid InID);
        [OperationContract]
        void SaveWarehouseInMain(Sender sender, SaveWarehouseInMainArgs args);
        [OperationContract]
        SearchResult SearchWarehouseInMain(Sender sender, SearchWarehouseInMainArgs args);
    }
}
