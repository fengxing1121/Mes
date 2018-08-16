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
        SearchResult SearchWorkShift2WorkShop(Sender sender, SearchWorkShift2WorkShopArgs args);
        [OperationContract]
        List<WorkShift2WorkShop> GetWorkShift2WorkShopByWorkShopID(Sender sender, Guid WorkShopID);
    }
}
