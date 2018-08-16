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
        void SaveUser2Role(Sender sender, SaveUser2RoleArgs args);
        [OperationContract]
        void DeleteUser2Role(Sender sender, User2Role user2Role);
        [OperationContract]
        List<User2Role> GetUser2RoleByUserID(Sender sender, Guid userID);
        [OperationContract]
        List<User2Role> GetUser2RoleByRoleID(Sender sender, Guid roleID);
        [OperationContract]
        List<PrivilegeCategory> GetPrivilegeCategorys(Sender sender);
        [OperationContract]
        PrivilegeCategory GetPrivilegeCategory(Sender sender, Guid CategoryID);
        [OperationContract]
        void SavePrivilegeCategory(Sender sender, SavePrivilegeCategoryArgs args);
        [OperationContract]
        SearchResult SearchPrivilegeCategory(Sender sender, SearchPrivilegeCategoryArgs args);
        [OperationContract]
        bool PrivilegeCategoryIsDuplicated(Sender sender, PrivilegeCategory privilegeCategory);

    }
}
