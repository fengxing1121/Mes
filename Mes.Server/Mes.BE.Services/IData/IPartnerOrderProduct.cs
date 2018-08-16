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
        PartnerOrderProduct GetPartnerOrderProduct(Sender sender, Guid ProductID);

        [OperationContract]
        List<PartnerOrderProduct> GetAllPartnerOrderProducts(Sender sender);

        [OperationContract]
        List<PartnerOrderProduct> GetPartnerOrderProductByOrderID(Sender sender, Guid ProductID);

        [OperationContract]
        SearchResult SearchPartnerOrderProduct(Sender sender, SearchPartnerOrderProductArgs args);

        [OperationContract]
        void SavePartnerOrderProduct(Sender sender, PartnerOrderProduct obj);
    }
}

