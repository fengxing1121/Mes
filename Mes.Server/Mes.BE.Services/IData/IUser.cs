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
        User GetUser(Sender sender, Guid userID);
        [OperationContract]
        User GetUserByUserCode(Sender sender, string userCode);
        [OperationContract]
        User GetUserByMobile(Sender sender, string Mobile);
        [OperationContract]
        SearchResult SearchUser(Sender sender, SearchUserArgs args);
        [OperationContract]
        List<User> GetAllUsers(Sender sender);
        [OperationContract]
        List<User> GetUsersByDepartmentID(Sender sender, Guid departmentID);
        [OperationContract]
        List<User> GetUsersByRole(Sender sender, Guid roleID);
        [OperationContract]
        bool UserIsDuplicated(Sender sender, User user);
        [OperationContract]
        bool UserMobileIsDuplicated(Sender sender, User user);
        [OperationContract]
        void SaveUser(Sender sender, SaveUserArgs args);
        [OperationContract]
        void DeleteUser(Sender sender, Guid userID);
        [OperationContract]
        List<UserPassword> GetUserPasswords(Sender sender, Guid userID);

    }
}
