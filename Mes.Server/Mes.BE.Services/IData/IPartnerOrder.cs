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
        PartnerOrder GetPartnerOrder(Sender sender, Guid OrderID);

        [OperationContract]
        void SavePartnerOrder(Sender sender, SavePartnerOrderArgs args);

        [OperationContract]
        SearchResult SearchPartnerOrder(Sender sender, SearchPartnerOrderArgs args);

        [OperationContract]
        int UpdatePartnerOrder(Order args);
    }
}
