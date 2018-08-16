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
        Role GetRole(Sender sender, Guid roleID);
        [OperationContract]
        Role GetRoleByName(Sender sender, Guid GroupID, string roleName);
        [OperationContract]
        List<Role> GetAllRoles(Sender sender);
        [OperationContract]
        List<Role> GetRolesByUserID(Sender sender, Guid userID);
        [OperationContract]
        bool RoleIsDuplicated(Sender sender, Role role);
        [OperationContract]
        SearchResult SearchRole(Sender sender, SearchRoleArgs args);
        [OperationContract]
        void SaveRole(Sender sender, SaveRoleArgs args);
        [OperationContract]
        void DeleteRole(Sender sender, Guid roleId);
        [OperationContract]
        List<Role> GetRolesByGroupID(Sender sender, Guid groupID);
       
    }
}
