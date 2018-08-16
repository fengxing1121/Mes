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
        #region 角色
        public Role GetRole(Sender sender, Guid roleID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Role role = new Role();
                    role.RoleID = roleID;
                    if (op.LoadRoleByRoleID(role) == 0)
                    {
                        return null;
                    }
                    return role;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Role GetRoleByName(Sender sender, Guid GroupID, string roleName)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Role role = new Role();
                    role.RoleName = roleName;
                    role.GroupID = GroupID;
                    if (op.LoadRoleByGroupID_RoleName(role) == 0)
                    {
                        return null;
                    }
                    return role;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Role> GetAllRoles(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadRoles();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Role> GetRolesByUserID(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadRolesByUserID(userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool RoleIsDuplicated(Sender sender, Role role)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Role r = new Role();
                    r.RoleName = role.RoleName;
                    r.GroupID = role.GroupID;
                    if (op.LoadRoleByGroupID_RoleName(r) == 0)
                    {
                        return false;
                    }
                    return r.RoleID != role.RoleID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchRole(Sender sender, SearchRoleArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchRole(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveRole(Sender sender, SaveRoleArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.Role.RoleName))
                {
                    throw new Exception(string.Format("角色名称:{0}命名无效，可能存在特殊字符。", args.Role.RoleName));
                }

                if (RoleIsDuplicated(sender, args.Role))
                {
                    throw new Exception(string.Format("角色名称:{0}已存在，请重新输入。", args.Role.RoleName));
                }

                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Role role = new Role();
                    role.RoleID = args.Role.RoleID;
                    if (op.LoadRoleByRoleID(role) == 0)
                    {
                        role = null;
                    }

                    if (role == null)
                    {
                        args.Role.Created = DateTime.Now;
                        args.Role.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Role.Modified = args.Role.Created;
                        args.Role.ModifiedBy = args.Role.CreatedBy;
                        op.InsertRole(args.Role);
                    }
                    else
                    {
                        args.Role.Modified = DateTime.Now;
                        args.Role.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateRoleByRoleID(args.Role);
                    }
                    if (args.UserIDs != null)
                    {
                        op.DeleteUser2RolesByRoleID(args.Role.RoleID);
                        foreach (Guid userID in args.UserIDs)
                        {
                            User2Role ug = new User2Role();
                            ug.UserID = userID;
                            ug.RoleID = args.Role.RoleID;
                            op.InsertUser2Role(ug);
                        }
                    }

                    if (args.PrivilegeItemIDs != null)
                    {
                        op.DeleteRole2PrivilegeItemsByRoleID(args.Role.RoleID);

                        foreach (Guid privilege in args.PrivilegeItemIDs)
                        {
                            Role2PrivilegeItem rp = new Role2PrivilegeItem();
                            rp.RoleID = args.Role.RoleID;
                            rp.PrivilegeItemID = privilege;
                            op.InsertRole2PrivilegeItem(rp);
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
        public void DeleteRole(Sender sender, Guid roleId)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteUser2RolesByRoleID(roleId);
                    //op.DeleteRole2PrivilegesByRoleID(roleId);
                    op.DeleteRoleByRoleID(roleId);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Role> GetRolesByGroupID(Sender sender, Guid groupID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadRolesByGroupID(groupID);
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
