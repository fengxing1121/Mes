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
        PartnerRole GetPartnerRole(Sender sender, Guid roleId);
        [OperationContract]
        PartnerRole GetPartnerRoleByName(Sender sender, Guid GroupID, string roleName);
        [OperationContract]
        List<PartnerRole> GetAllPartnerRoles(Sender sender);
        [OperationContract]
        List<PartnerRole> GetPartnerRolesByGroupID(Sender sender, Guid userGroupID);
        [OperationContract]
        List<PartnerRole> GetPartnerRolesByUserID(Sender sender, Guid userId);
        [OperationContract]
        bool PartnerRoleIsDuplicated(Sender sender, PartnerRole role);
        [OperationContract]
        SearchResult SearchPartnerRole(Sender sender, SearchPartnerRoleArgs args);
        [OperationContract]
        void SavePartnerRole(Sender sender, SavePartnerRoleArgs args);
        [OperationContract]
        void DeletePartnerRole(Sender sender, Guid roleId);

    }
}
