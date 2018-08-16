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
        void DeletePackageItem(Sender sender, string Barcode, Guid WorkFlowID, bool IsRemovePackage);
        [OperationContract]
        Package GetPackage(Sender sender, Guid PackageID);
        [OperationContract]
        List<Package> GetPackagesByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        void SavePackage(Sender sender, SavePackageArgs args);
        [OperationContract]
        int GetMaxPackageNum(Sender sender, Guid OrderID, Guid CabinetID);
        [OperationContract]
        void SavePackageDetail(Sender sender, SavePackageDetailArgs args);
        [OperationContract]
        SearchResult SearchPackage(Sender sender, SearchPackageArgs args);
    }
}
