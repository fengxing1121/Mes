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
        #region 用户权限
        public void SaveUser2Role(Sender sender, SaveUser2RoleArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadUser2RoleByUserID_RoleID(args.User2Role) == 0)
                    {
                        op.InsertUser2Role(args.User2Role);
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
        public void DeleteUser2Role(Sender sender, User2Role user2Role)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteUser2RoleByUserID_RoleID(user2Role.UserID, user2Role.RoleID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<User2Role> GetUser2RoleByUserID(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadUser2RolesByUserID(userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<User2Role> GetUser2RoleByRoleID(Sender sender, Guid roleID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadUser2RolesByRoleID(roleID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<PrivilegeCategory> GetPrivilegeCategorys(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeCategorys();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public PrivilegeCategory GetPrivilegeCategory(Sender sender, Guid CategoryID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PrivilegeCategory pc = new PrivilegeCategory();
                    pc.CategoryID = CategoryID;
                    if (op.LoadPrivilegeCategoryByCategoryID(pc) == 0)
                    {
                        return null;
                    }
                    return pc;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePrivilegeCategory(Sender sender, SavePrivilegeCategoryArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (PrivilegeCategoryIsDuplicated(sender, args.PrivilegeCategory))
                    {
                        throw new Exception("权限模块分类名称已经存在。");
                    }

                    PrivilegeCategory rc = new PrivilegeCategory();
                    rc.CategoryID = args.PrivilegeCategory.CategoryID;
                    if (op.LoadPrivilegeCategoryByCategoryID(rc) == 0)
                    {
                        args.PrivilegeCategory.Created = DateTime.Now;
                        args.PrivilegeCategory.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.PrivilegeCategory.Modified = DateTime.Now;
                        args.PrivilegeCategory.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPrivilegeCategory(args.PrivilegeCategory);
                    }
                    else
                    {
                        args.PrivilegeCategory.Modified = DateTime.Now;
                        args.PrivilegeCategory.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdatePrivilegeCategoryByCategoryID(args.PrivilegeCategory);
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
        public SearchResult SearchPrivilegeCategory(Sender sender, SearchPrivilegeCategoryArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPrivilegeCategory(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool PrivilegeCategoryIsDuplicated(Sender sender, PrivilegeCategory privilegeCategory)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PrivilegeCategory rc = new PrivilegeCategory();
                    rc.CategoryName = privilegeCategory.CategoryName;
                    if (op.LoadPrivilegeCategoryByCategoryName(rc) == 0)
                    {
                        return false;
                    }
                    return privilegeCategory.CategoryID != rc.CategoryID;
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
