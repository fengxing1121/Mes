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
        PartnerUser GetPartnerUser(Sender sender, Guid userId);
        [OperationContract]
        PartnerUser GetPartnerUserByUserCode(Sender sender, string userCode);
        [OperationContract]
        PartnerUser GetPartnerUserByMobile(Sender sender, string Mobile);
        [OperationContract]
        List<PartnerUser> GetAllPartnerUsers(Sender sender);
        [OperationContract]
        SearchResult SearchPartnerUser(Sender sender, SearchPartnerUserArgs args);
        [OperationContract]
        List<PartnerUser> GetPartnerUsersByRole(Sender sender, Guid roleId);
        [OperationContract]
        bool PartnerUserIsDuplicated(Sender sender, PartnerUser user);
        [OperationContract]
        bool PartnerUserMobileIsDuplicated(Sender sender, PartnerUser user);
        [OperationContract]
        void SavePartnerUser(Sender sender, SavePartnerUserArgs args);
        [OperationContract]
        void DeletePartnerUser(Sender sender, Guid userId);
        [OperationContract]
        void UpdatePartnerUserIsFinishInfoByUserID(Sender sender, SavePartnerUserArgs args);
        [OperationContract]
        void UpdatePartnerUserDisabled(Guid UserID);
    }
}
