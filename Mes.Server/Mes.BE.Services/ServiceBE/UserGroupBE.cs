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
    public partial class ServiceBE : IServiceBE
    {
        #region 用户组
        public UserGroup GetUserGroup(Sender sender, Guid groupID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    UserGroup ug = new UserGroup();
                    ug.GroupID = groupID;

                    if (op.LoadUserGroupByGroupID(ug) == 0)
                    {
                        return null;
                    }
                    return ug;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<UserGroup> GetAllUserGroup(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadUserGroups();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchUserGroup(Sender sender, SearchUserGroupArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchUserGroup(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool UserGroupIsDuplicated(Sender sender, UserGroup userGroup)
        {
            using (ObjectProxy op = new ObjectProxy())
            {
                UserGroup ug = new UserGroup();
                ug.GroupName = userGroup.GroupName;
                if (op.LoadUserGroupByGroupName(ug) == 0)
                {
                    return false;
                }
                return ug.GroupID != userGroup.GroupID;
            }
        }
        public void SaveUserGroup(Sender sender, SaveUserGroupArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.UserGroup.GroupName))
                {
                    throw new CException("用户组名称:{0}命名无效，可能存在特殊字符。", args.UserGroup.GroupName);
                }

                if (UserGroupIsDuplicated(sender, args.UserGroup))
                {
                    throw new CException("用户组名称:{0}已存在，请重新输入。", args.UserGroup.GroupName);
                }

                using (ObjectProxy op = new ObjectProxy(true))
                {
                    UserGroup ug = new UserGroup();
                    ug.GroupID = args.UserGroup.GroupID;
                    if (op.LoadUserGroupByGroupID(ug) == 0)
                    {
                        ug = null;
                    }
                    if (ug == null)
                    {
                        args.UserGroup.Created = DateTime.Now;
                        args.UserGroup.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.UserGroup.Modified = DateTime.Now;
                        args.UserGroup.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertUserGroup(args.UserGroup);
                    }
                    else
                    {
                        args.UserGroup.Modified = DateTime.Now;
                        args.UserGroup.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateUserGroupByGroupID(args.UserGroup);
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
        public void DeleteUserGroup(Sender sender, Guid groupID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    //删除用户组下面的角色用户；
                    List<Role> roles = op.LoadRolesByGroupID(groupID);
                    foreach (Role role in roles)
                    {
                        op.DeleteUser2RolesByRoleID(role.RoleID);
                    }
                    //删除用户组下的角色
                    op.DeleteRolesByGroupID(groupID);
                    //删除用户组
                    op.DeleteUserGroupByGroupID(groupID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
