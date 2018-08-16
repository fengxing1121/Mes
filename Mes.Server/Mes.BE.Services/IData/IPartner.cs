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
        void SavePartner(Sender sender, SavePartnerArgs args);
        [OperationContract]
        Partner GetPartner(Sender sender, Guid PartnerID);
        [OperationContract]
        Company GetCompany(Sender sender, Guid CompanyID);
        [OperationContract]
        List<Partner> GetPartners(Sender sender);
        [OperationContract]
        SearchResult SearchCompany(Sender sender, SearchCompanyArgs args);
        [OperationContract]
        SearchResult SearchPartner(Sender sender, SearchPartnerArgs args);
        [OperationContract]
        Partner GetPartnerByMobile(Sender sender, string mobile);
    }
}
