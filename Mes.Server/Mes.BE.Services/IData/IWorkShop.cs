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
        List<WorkShop> GetAllWorkShops(Sender sender);
        [OperationContract]
        WorkShop GetWorkShop(Sender sender, Guid WorkShopID);
        [OperationContract]
        WorkShop GetWorkShopByWorkShopCode(Sender sender, string WorkShopCode);
        [OperationContract]
        void SaveWorkShop(Sender sender, SaveWorkShopArgs args);
        [OperationContract]
        SearchResult SearchWorkShop(Sender sender, SearchWorkShopArgs args);
    }
}
