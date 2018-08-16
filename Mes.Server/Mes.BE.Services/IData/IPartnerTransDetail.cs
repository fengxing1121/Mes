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
        PartnerTransDetail GetPartnerTransDetail(Sender sender, Guid TransID);
        [OperationContract]
        SearchResult SearchPartnerTransDetail(Sender sender, SearchPartnerTransDetailArgs args);
        [OperationContract]
        List<PartnerTransDetail> GetPartnerTransDetailsByPartnerID(Sender sender, Guid PartnerID);
        [OperationContract]
        List<PartnerTransDetail> GetPartnerTransDetailsByOrderID(Sender sender, Guid OrderID);
        [OperationContract]
        void SavePartnerTransDetail(Sender sender, SavePartnerTransDetailArgs args);
        [OperationContract]
        void DeletePartnerTransDetail(Sender sender, Guid TransID);

    }
}
