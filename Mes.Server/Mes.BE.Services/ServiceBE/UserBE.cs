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
    public partial class ServiceBE: IServiceBE
    {

        public User GetUser(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    User user = new User();
                    user.UserID = userID;
                    if (op.LoadUserByUserID(user) == 0)
                    {
                        return null;
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public User GetUserByUserCode(Sender sender, string userCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    User user = new User();
                    user.UserCode = userCode;
                    if (op.LoadUserByUserCode(user) == 0)
                    {
                        return null;
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public User GetUserByMobile(Sender sender, string Mobile)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    User user = new User();
                    user.Mobile = Mobile;
                    if (op.LoadUserByMobile(user) == 0)
                    {
                        return null;
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchUser(Sender sender, SearchUserArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchUser(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<User> GetAllUsers(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadUsers();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<User> GetUsersByDepartmentID(Sender sender, Guid departmentID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadUsersByDepartmentID(departmentID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<User> GetUsersByRole(Sender sender, Guid roleID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadUsersByRoleID(roleID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool UserIsDuplicated(Sender sender, User user)
        {
            try
            {
                User u = new User();
                u.UserCode = user.UserCode;
                using (ObjectProxy op = new ObjectProxy())
                {
                    if (op.LoadUserByUserCode(u) == 0)
                    {
                        return false;
                    }
                    return u.UserID != user.UserID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool UserMobileIsDuplicated(Sender sender, User user)
        {
            try
            {
                User u = new User();
                u.Mobile = user.Mobile;
                using (ObjectProxy op = new ObjectProxy())
                {
                    if (op.LoadUserByMobile(u) == 0)
                    {
                        return false;
                    }
                    return u.UserID != user.UserID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveUser(Sender sender, SaveUserArgs args)
        {
            try
            {

                if (string.IsNullOrEmpty(args.User.UserCode))
                {
                    throw new Exception(string.Format("用户编号:{0}命名无效，可能存在特殊字符。", args.User.UserCode));
                }

                if (string.IsNullOrEmpty(args.User.UserName))
                {
                    throw new Exception(string.Format("用户名称:{0}命名无效，可能存在特殊字符。", args.User.UserName));
                }

                if (UserIsDuplicated(sender, args.User))
                {
                    throw new Exception(string.Format("用户编号:{0}已存在，请重新输入。", args.User.UserCode));
                }
                if (UserMobileIsDuplicated(sender, args.User))
                {
                    throw new Exception(string.Format("用户手机号:{0}已存在，请重新输入。", args.User.Mobile));
                }
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    User user = new User();
                    user.UserID = args.User.UserID;
                    if (op.LoadUserByUserID(user) == 0)
                    {
                        user = null;
                    }

                    if (user == null)
                    {
                        args.User.Created = DateTime.Now;
                        args.User.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.User.Modified = args.User.Created;
                        args.User.ModifiedBy = args.User.CreatedBy;
                        op.InsertUser(args.User);
                        UserPassword up = new UserPassword();
                        up.UserID = args.User.UserID;
                        up.Password = args.User.Password;
                        up.Modified = DateTime.Now;
                        up.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertUserPassword(up);
                    }
                    else
                    {
                        args.User.Modified = DateTime.Now;
                        args.User.ModifiedBy = sender.UserCode + "." + sender.UserName;

                        op.UpdateUserByUserID(args.User);
                        if (args.RoleIDs != null)
                        {
                            op.DeleteUser2RolesByUserID(args.User.UserID);
                        }

                        if (args.User.Password != user.Password)
                        {
                            UserPassword up = new UserPassword();
                            up.UserID = args.User.UserID;
                            up.Password = args.User.Password;
                            up.Modified = DateTime.Now;
                            up.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertUserPassword(up);
                        }
                    }
                    if (args.RoleIDs != null)
                    {
                        foreach (Guid roleID in args.RoleIDs)
                        {
                            User2Role ur = new User2Role();
                            ur.UserID = args.User.UserID;
                            ur.RoleID = roleID;
                            op.InsertUser2Role(ur);
                        }
                    }
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteUser(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteUser2RolesByUserID(userID);
                    op.DeleteUserPasswordsByUserID(userID);
                    op.DeleteUserByUserID(userID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<UserPassword> GetUserPasswords(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadUserPasswordsByUserID(userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

    }
}
