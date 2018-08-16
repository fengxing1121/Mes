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
        UserGroup GetUserGroup(Sender sender, Guid groupID);
        [OperationContract]
        List<UserGroup> GetAllUserGroup(Sender sender);
        [OperationContract]
        SearchResult SearchUserGroup(Sender sender, SearchUserGroupArgs args);
        [OperationContract]
        bool UserGroupIsDuplicated(Sender sender, UserGroup userGroup);
        [OperationContract]
        void SaveUserGroup(Sender sender, SaveUserGroupArgs args);
        [OperationContract]
        void DeleteUserGroup(Sender sender, Guid groupID);

    }
}
