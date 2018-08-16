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
        #region 菜单
        public Privilege GetPrivilege(Sender sender, Guid privilegeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Privilege Info = new Privilege();
                    Info.PrivilegeID = privilegeID;
                    if (op.LoadPrivilegeByPrivilegeID(Info) == 0)
                    {
                        return null;
                    }
                    return Info;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Privilege GetPrivilegeByCategoryID_PrivilegeCode(Sender sender, string privilegeCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Privilege Info = new Privilege();
                    Info.PrivilegeCode = privilegeCode;
                    if (op.LoadPrivilegeByPrivilegeCode(Info) == 0)
                    {
                        return null;
                    }
                    return Info;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Privilege> GetAllPrivileges(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivileges();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Privilege> GetPrivilegesByUserID(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegesByUserID(userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public List<Privilege> GetPrivilegesByCategoryID(Sender sender, Guid CategoryID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegesByCategoryID(CategoryID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool PrivilegeCodeIsDuplicated(Sender sender, Privilege privilege)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Privilege p = new Privilege();
                    p.PrivilegeCode = privilege.PrivilegeCode;
                    p.CategoryID = privilege.CategoryID;
                    if (op.LoadPrivilegeByPrivilegeCode(p) == 0)
                    {
                        return false;
                    }
                    return p.PrivilegeID != privilege.PrivilegeID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchPrivilege(Sender sender, SearchPrivilegeArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPrivilege(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePrivilege(Sender sender, SavePrivilegeArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.Privilege.PrivilegeName))
                {
                    throw new CException("权限名称:{0}命名无效，可能存在特殊字符。", args.Privilege.PrivilegeName);
                }
                if (PrivilegeCodeIsDuplicated(sender, args.Privilege))
                {
                    throw new CException("权限编号:{0}已存在，请重新输入。", args.Privilege.PrivilegeCode);
                }

                //if (PrivilegeNameIsDuplicated(sender, args.Privilege))
                //{
                //    throw new CException("权限名称:{0}已存在，请重新输入。", args.Privilege.PrivilegeName);
                //}
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Privilege p = new Privilege();
                    p.PrivilegeID = args.Privilege.PrivilegeID;
                    if (op.LoadPrivilegeByPrivilegeID(p) == 0)
                    {
                        args.Privilege.Created = DateTime.Now;
                        args.Privilege.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Privilege.Modified = DateTime.Now;
                        args.Privilege.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPrivilege(args.Privilege);
                    }
                    else
                    {
                        args.Privilege.Modified = DateTime.Now;
                        args.Privilege.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdatePrivilegeByPrivilegeID(args.Privilege);
                    }

                    if (args.PrivilegeItems != null)
                    {
                        //先把所有的功能项置为禁用
                        op.UpdatePrivilegeItemsByPrivilegeID(args.Privilege.PrivilegeID);
                        foreach (PrivilegeItem item in args.PrivilegeItems)
                        {
                            PrivilegeItem pi = new PrivilegeItem();
                            pi.PrivilegeID = item.PrivilegeID;
                            pi.PrivilegeItemCode = item.PrivilegeItemCode;
                            if (op.LoadPrivilegeItemByPrivilegeID_PrivilegeItemCode(pi) == 0)
                            {
                                item.Created = DateTime.Now;
                                item.CreatedBy = sender.UserCode + "." + sender.UserName;
                                item.Modified = DateTime.Now;
                                item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.InsertPrivilegeItem(item);
                            }
                            else
                            {
                                pi.IsDisabled = false;
                                pi.Modified = DateTime.Now;
                                pi.ModifiedBy = sender.UserCode + "." + sender.UserName;
                                op.UpdatePrivilegeItemByPrivilegeID_PrivilegeItemCode(pi);
                            }
                        }
                        //删除禁用的功能操作
                        op.DeletePrivilegeItemsByPrivilegeID_Disabled(args.Privilege.PrivilegeID);
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

        public PrivilegeItem GetPrivilegeItem(Sender sender, Guid privilegeItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PrivilegeItem pi = new PrivilegeItem();
                    pi.PrivilegeItemID = privilegeItemID;
                    if (op.LoadPrivilegeItemByPrivilegeItemID(pi) == 0)
                    {
                        return null;
                    }
                    return pi;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool PrivilegeItemNameIsDuplicated(Sender sender, PrivilegeItem privilegeItem)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PrivilegeItem p = new PrivilegeItem();
                    p.PrivilegeID = privilegeItem.PrivilegeID;
                    p.PrivilegeItemName = privilegeItem.PrivilegeItemName;
                    if (op.LoadPrivilegeItemsByPrivilegeID_PrivilegeItemName(p) == 0)
                    {
                        return false;
                    }
                    return p.PrivilegeItemID != privilegeItem.PrivilegeItemID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool PrivilegeItemCodeIsDuplicated(Sender sender, PrivilegeItem privilegeItem)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PrivilegeItem p = new PrivilegeItem();
                    p.PrivilegeID = privilegeItem.PrivilegeID;
                    p.PrivilegeItemCode = privilegeItem.PrivilegeItemCode;
                    if (op.LoadPrivilegeItemByPrivilegeID_PrivilegeItemCode(p) == 0)
                    {
                        return false;
                    }
                    return p.PrivilegeItemID != privilegeItem.PrivilegeItemID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByPrivilegeID(Sender sender, Guid privilegeID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemsByPrivilegeID(privilegeID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByRoleID(Sender sender, Guid roleID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemsByRoleID(roleID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByUserID(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemsByUserID(userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByPrivilegeID_UserID(Sender sender, Guid privilegeID, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemByPrivilegeID_UserID(privilegeID, userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByPrivilegeCode_UserID(Sender sender, string privilegeCode, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemByPrivilegeCode_UserID(privilegeCode, userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePrivilegeItem(Sender sender, SavePrivilegeItemArgs args)
        {
            try
            {
                //if (!PAssembly.VerifyIdentityText(args.PrivilegeItem.PrivilegeItemCode))
                //{
                //    throw new CException("权限项编码:{0}命名无效，可能存在特殊字符。", args.PrivilegeItem.PrivilegeItemCode);
                //}

                //if (!PAssembly.VerifyIdentityText(args.PrivilegeItem.PrivilegeItemName))
                //{
                //    throw new CException("权限项名称:{0}命名无效，可能存在特殊字符。", args.PrivilegeItem.PrivilegeItemName);
                //}

                if (PrivilegeItemCodeIsDuplicated(sender, args.PrivilegeItem))
                {
                    throw new CException("权限项编号：{0}已存在，请重新输入。", args.PrivilegeItem.PrivilegeItemCode);
                }

                if (PrivilegeItemNameIsDuplicated(sender, args.PrivilegeItem))
                {
                    throw new CException("权限项名称：{0}已存在，请重新输入。", args.PrivilegeItem.PrivilegeItemName);
                }

                using (ObjectProxy op = new ObjectProxy(true))
                {
                    PrivilegeItem pi = new PrivilegeItem();
                    pi.PrivilegeItemID = args.PrivilegeItem.PrivilegeItemID;
                    if (op.LoadPrivilegeItemByPrivilegeItemID(pi) == 0)
                    {
                        pi = null;
                    }

                    if (pi == null)
                    {
                        args.PrivilegeItem.Created = DateTime.Now;
                        args.PrivilegeItem.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.PrivilegeItem.Modified = DateTime.Now;
                        args.PrivilegeItem.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPrivilegeItem(args.PrivilegeItem);
                    }
                    else
                    {
                        args.PrivilegeItem.Modified = DateTime.Now;
                        args.PrivilegeItem.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdatePrivilegeItemByPrivilegeItemID(args.PrivilegeItem);
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
        public SearchResult SearchPrivilegeItem(Sender sender, SearchPrivilegeItemArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPrivilegeItem(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Role2PrivilegeItem GetRole2PrivilegeItem(Sender sender, Guid RoleID, Guid PrivilegeItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Role2PrivilegeItem obj = new Role2PrivilegeItem();
                    obj.RoleID = RoleID;
                    obj.PrivilegeItemID = PrivilegeItemID;
                    if (op.LoadRole2PrivilegeItemByRoleID_PrivilegeItemID(obj) == 0)
                    {
                        return null;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Privilege> GetPrivilegesByPartnerUserID(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegesByPartnerUserID(userID);
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
