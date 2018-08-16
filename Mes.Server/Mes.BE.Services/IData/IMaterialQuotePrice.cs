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
        MaterialQuotePrice GetMaterialQuotePrice(Sender sender, Guid MaterialID);
        [OperationContract]
        void SaveMaterialQuotePrice(Sender sender, SaveMaterialQuotePriceArgs args);
        [OperationContract]
        void DeleteMaterialQuotePrice(Sender sender, Guid MaterialID);
        [OperationContract]
        SearchResult SearchMaterialQuotePrice(Sender sender, SearchMaterialQuotePriceArgs args);
    }
}
