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
        public PartnerUser GetPartnerUser(Sender sender, Guid userId)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerUser user = new PartnerUser();
                    user.UserID = userId;
                    if (op.LoadPartnerUserByUserID(user) == 0)
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
        public PartnerUser GetPartnerUserByUserCode(Sender sender, string userCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerUser user = new PartnerUser();
                    user.UserCode = userCode;
                    if (op.LoadPartnerUserByUserCode(user) == 0)
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
        public PartnerUser GetPartnerUserByMobile(Sender sender, string Mobile)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerUser user = new PartnerUser();
                    user.Mobile = Mobile;
                    if (op.LoadPartnerUserByMobile(user) == 0)
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
        public List<PartnerUser> GetAllPartnerUsers(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerUsers();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchPartnerUser(Sender sender, SearchPartnerUserArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPartnerUser(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerUser> GetPartnerUsersByRole(Sender sender, Guid roleId)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerUsersByRoleID(roleId);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool PartnerUserIsDuplicated(Sender sender, PartnerUser user)
        {
            try
            {
                PartnerUser u = new PartnerUser();
                u.UserCode = user.UserCode;
                using (ObjectProxy op = new ObjectProxy())
                {
                    if (op.LoadPartnerUserByUserCode(u) == 0)
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
        public bool PartnerUserMobileIsDuplicated(Sender sender, PartnerUser user)
        {
            try
            {
                PartnerUser u = new PartnerUser();
                u.Mobile = user.Mobile;
                using (ObjectProxy op = new ObjectProxy())
                {
                    if (op.LoadPartnerUserByMobile(u) == 0)
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
        public void SavePartnerUser(Sender sender, SavePartnerUserArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.PartnerUser.UserCode))
                {
                    throw new Exception(string.Format("用户编号:{0}命名无效，可能存在特殊字符。", args.PartnerUser.UserCode));
                }

                if (string.IsNullOrEmpty(args.PartnerUser.UserName))
                {
                    throw new Exception(string.Format("用户名称:{0}命名无效，可能存在特殊字符。", args.PartnerUser.UserName));
                }

                if (PartnerUserIsDuplicated(sender, args.PartnerUser))
                {
                    throw new Exception(string.Format("用户编号:{0}已存在，请重新输入。", args.PartnerUser.UserCode));
                }
                if (PartnerUserMobileIsDuplicated(sender, args.PartnerUser))
                {
                    throw new Exception(string.Format("用户手机号:{0}已存在，请重新输入。", args.PartnerUser.Mobile));
                }
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    PartnerUser user = new PartnerUser();
                    user.UserID = args.PartnerUser.UserID;
                    if (op.LoadPartnerUserByUserID(user) == 0)
                    {
                        user = null;
                    }

                    if (user == null)
                    {
                        args.PartnerUser.Created = DateTime.Now;
                        args.PartnerUser.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.PartnerUser.Modified = args.PartnerUser.Created;
                        args.PartnerUser.ModifiedBy = args.PartnerUser.CreatedBy;
                        op.InsertPartnerUser(args.PartnerUser);
                        PartnerUserPassword up = new PartnerUserPassword();
                        up.UserID = args.PartnerUser.UserID;
                        up.Password = args.PartnerUser.Password;
                        up.Modified = DateTime.Now;
                        up.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPartnerUserPassword(up);
                    }
                    else
                    {
                        args.PartnerUser.Modified = DateTime.Now;
                        args.PartnerUser.ModifiedBy = sender.UserCode + "." + sender.UserName;

                        op.UpdatePartnerUserByUserID(args.PartnerUser);
                        if (args.RoleIDs != null)
                        {
                            op.DeletePartnerUser2RolesByUserID(args.PartnerUser.UserID);
                        }

                        if (args.PartnerUser.Password != user.Password)
                        {
                            PartnerUserPassword up = new PartnerUserPassword();
                            up.UserID = args.PartnerUser.UserID;
                            up.Password = args.PartnerUser.Password;
                            up.Modified = DateTime.Now;
                            up.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertPartnerUserPassword(up);
                        }
                    }
                    if (args.RoleIDs != null)
                    {
                        foreach (Guid roleID in args.RoleIDs)
                        {
                            PartnerUser2Role ur = new PartnerUser2Role();
                            ur.UserID = args.PartnerUser.UserID;
                            ur.RoleID = roleID;
                            op.InsertPartnerUser2Role(ur);
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
        public void DeletePartnerUser(Sender sender, Guid userId)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeletePartnerUser2RolesByUserID(userId);
                    op.DeletePartnerUserPasswordsByUserID(userId);
                    op.DeletePartnerUserByUserID(userId);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void UpdatePartnerUserIsFinishInfoByUserID(Sender sender, SavePartnerUserArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.UpdatePartnerUserIsFinishInfoByUserID(args.PartnerUser);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void UpdatePartnerUserDisabled(Guid UserID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.UpdatePartnerUserDisabled(UserID);
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
