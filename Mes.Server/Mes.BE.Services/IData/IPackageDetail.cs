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
        SearchResult SearchPackageDetail(Sender sender, SearchPackageDetailArgs args);
        [OperationContract]
        PackageDetail GetPackageDetail(Sender sender, Guid DetailID);
        [OperationContract]
        List<PackageDetail> GetPackageDetailsByItemID(Sender sender, Guid ItemID);
    }
}
