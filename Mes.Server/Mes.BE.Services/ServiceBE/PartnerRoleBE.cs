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
        public PartnerRole GetPartnerRole(Sender sender, Guid roleId)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerRole role = new PartnerRole();
                    role.RoleID = roleId;
                    if (op.LoadPartnerRoleByRoleID(role) == 0)
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
        public PartnerRole GetPartnerRoleByName(Sender sender, Guid GroupID, string roleName)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerRole role = new PartnerRole();
                    role.RoleName = roleName;
                    role.GroupID = GroupID;
                    if (op.LoadPartnerRoleByGroupID_RoleName(role) == 0)
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
        public List<PartnerRole> GetAllPartnerRoles(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerRoles();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerRole> GetPartnerRolesByGroupID(Sender sender, Guid userGroupID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerRolesByGroupID(userGroupID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerRole> GetPartnerRolesByUserID(Sender sender, Guid userId)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerRolesByUserID(userId);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool PartnerRoleIsDuplicated(Sender sender, PartnerRole role)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerRole r = new PartnerRole();
                    r.RoleName = role.RoleName;
                    r.GroupID = role.GroupID;
                    if (op.LoadPartnerRoleByGroupID_RoleName(r) == 0)
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
        public SearchResult SearchPartnerRole(Sender sender, SearchPartnerRoleArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPartnerRole(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePartnerRole(Sender sender, SavePartnerRoleArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.PartnerRole.RoleName))
                {
                    throw new Exception(string.Format("角色名称:{0}命名无效，可能存在特殊字符。", args.PartnerRole.RoleName));
                }

                if (PartnerRoleIsDuplicated(sender, args.PartnerRole))
                {
                    throw new Exception(string.Format("角色名称:{0}已存在，请重新输入。", args.PartnerRole.RoleName));
                }

                using (ObjectProxy op = new ObjectProxy(true))
                {
                    PartnerRole role = new PartnerRole();
                    role.RoleID = args.PartnerRole.RoleID;
                    if (op.LoadPartnerRoleByRoleID(role) == 0)
                    {
                        role = null;
                    }

                    if (role == null)
                    {
                        args.PartnerRole.Created = DateTime.Now;
                        args.PartnerRole.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.PartnerRole.Modified = args.PartnerRole.Created;
                        args.PartnerRole.ModifiedBy = args.PartnerRole.CreatedBy;
                        op.InsertPartnerRole(args.PartnerRole);
                    }
                    else
                    {
                        args.PartnerRole.Modified = DateTime.Now;
                        args.PartnerRole.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdatePartnerRoleByRoleID(args.PartnerRole);
                    }
                    if (args.UserIDs != null)
                    {
                        op.DeletePartnerUser2RolesByRoleID(args.PartnerRole.RoleID);
                        foreach (Guid userID in args.UserIDs)
                        {
                            PartnerUser2Role ug = new PartnerUser2Role();
                            ug.UserID = userID;
                            ug.RoleID = args.PartnerRole.RoleID;
                            op.InsertPartnerUser2Role(ug);
                        }
                    }

                    if (args.PrivilegeItemIDs != null)
                    {
                        op.DeletePartnerRole2PrivilegeItemsByRoleID(args.PartnerRole.RoleID);
                        foreach (Guid privilege in args.PrivilegeItemIDs)
                        {
                            PartnerRole2PrivilegeItem rp = new PartnerRole2PrivilegeItem();
                            rp.RoleID = args.PartnerRole.RoleID;
                            rp.PrivilegeItemID = privilege;
                            op.InsertPartnerRole2PrivilegeItem(rp);
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
        public void DeletePartnerRole(Sender sender, Guid roleId)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeletePartnerUser2RolesByRoleID(roleId);
                    op.DeletePartnerRoleByRoleID(roleId);
                    op.CommitTransaction();
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
