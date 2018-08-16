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
        List<WarehouseOutMain> GetAllWarehouseOutMains(Sender sender);
        [OperationContract]
        WarehouseOutMain GetWarehouseOutMain(Sender sender, Guid OutID);
        [OperationContract]
        void SaveWarehouseOutMain(Sender sender, SaveWarehouseOutMainArgs args);
        [OperationContract]
        SearchResult SearchWarehouseOutMain(Sender sender, SearchWarehouseOutMainArgs args);
    }
}
