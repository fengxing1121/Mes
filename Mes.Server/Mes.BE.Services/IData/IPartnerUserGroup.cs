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
        PartnerUserGroup GetPartnerUserGroup(Sender sender, Guid groupID);
        [OperationContract]
        List<PartnerUserGroup> GetAllPartnerUserGroups(Sender sender);
        [OperationContract]
        SearchResult SearchPartnerUserGroup(Sender sender, SearchPartnerUserGroupArgs args);
        [OperationContract]
        bool PartnerUserGroupIsDuplicated(Sender sender, PartnerUserGroup userGroup);
        [OperationContract]
        void SavePartnerUserGroup(Sender sender, SavePartnerUserGroupArgs args);
        [OperationContract]
        void DeletePartnerUserGroup(Sender sender, Guid groupID);
    }
}
