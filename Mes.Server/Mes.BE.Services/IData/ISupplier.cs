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
        Supplier GetSupplier(Sender sender, Guid SupplierID);
        [OperationContract]
        void SaveSupplier(Sender sender, SaveSupplierArgs args);
        [OperationContract]
        SearchResult SearchSupplier(Sender sender, SearchSupplierArgs args);
    }
}
