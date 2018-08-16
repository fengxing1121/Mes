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
        void SaveMaterial2Supplier(Sender sender, SaveMaterial2SupplierArgs args);
        [OperationContract]
        Material2Supplier GetMaterial2Supplier(Sender sender, Guid MaterialID, Guid SupplierID);
        [OperationContract]
        List<Material2Supplier> GetMaterial2SuppliersByMaterialID(Sender sender, Guid MaterialID);
        [OperationContract]
        List<Material2Supplier> GetMaterial2SuppliersBySupplierID(Sender sender, Guid SupplierID);
        [OperationContract]
        SearchResult SeachMaterial2Supplier(Sender sender, SearchMaterial2SupplierArgs args);
    }
}
