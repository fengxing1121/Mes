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
        Privilege GetPrivilege(Sender sender, Guid privilegeID);
        [OperationContract]
        Privilege GetPrivilegeByCategoryID_PrivilegeCode(Sender sender, string privilegeCode);
        [OperationContract]
        List<Privilege> GetAllPrivileges(Sender sender);
        [OperationContract]
        List<Privilege> GetPrivilegesByUserID(Sender sender, Guid userID);
        [OperationContract]
        List<Privilege> GetPrivilegesByCategoryID(Sender sender, Guid CategoryID);
        [OperationContract]
        bool PrivilegeCodeIsDuplicated(Sender sender, Privilege privilege);
        [OperationContract]
        SearchResult SearchPrivilege(Sender sender, SearchPrivilegeArgs args);
        [OperationContract]
        void SavePrivilege(Sender sender, SavePrivilegeArgs args);
        [OperationContract]
        PrivilegeItem GetPrivilegeItem(Sender sender, Guid privilegeItemID);
        [OperationContract]
        bool PrivilegeItemNameIsDuplicated(Sender sender, PrivilegeItem privilegeItem);
        [OperationContract]
        bool PrivilegeItemCodeIsDuplicated(Sender sender, PrivilegeItem privilegeItem);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByPrivilegeID(Sender sender, Guid privilegeID);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByRoleID(Sender sender, Guid roleID);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByUserID(Sender sender, Guid userID);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByPrivilegeID_UserID(Sender sender, Guid privilegeID, Guid userID);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByPrivilegeCode_UserID(Sender sender, string privilegeCode, Guid userID);
        [OperationContract]
        void SavePrivilegeItem(Sender sender, SavePrivilegeItemArgs args);
        [OperationContract]
        SearchResult SearchPrivilegeItem(Sender sender, SearchPrivilegeItemArgs args);
        [OperationContract]
        Role2PrivilegeItem GetRole2PrivilegeItem(Sender sender, Guid RoleID, Guid PrivilegeItemID);
        [OperationContract]
        List<Privilege> GetPrivilegesByPartnerUserID(Sender sender, Guid userID);

    }
}
