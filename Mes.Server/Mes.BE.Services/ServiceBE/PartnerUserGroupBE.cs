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
        public PartnerUserGroup GetPartnerUserGroup(Sender sender, Guid groupID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerUserGroup ug = new PartnerUserGroup();
                    ug.GroupID = groupID;

                    if (op.LoadPartnerUserGroupByGroupID(ug) == 0)
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
        public List<PartnerUserGroup> GetAllPartnerUserGroups(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerUserGroups();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchPartnerUserGroup(Sender sender, SearchPartnerUserGroupArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchPartnerUserGroup(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool PartnerUserGroupIsDuplicated(Sender sender, PartnerUserGroup userGroup)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerUserGroup ug = new PartnerUserGroup();
                    ug.PartnerID = userGroup.PartnerID;
                    ug.GroupName = userGroup.GroupName;
                    if (op.LoadPartnerUserGroupByPartnerID_GroupName(ug) == 0)
                    {
                        return false;
                    }
                    return ug.GroupID != userGroup.GroupID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SavePartnerUserGroup(Sender sender, SavePartnerUserGroupArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.PartnerUserGroup.GroupName))
                {
                    throw new CException("用户组名称:{0}命名无效，可能存在特殊字符。", args.PartnerUserGroup.GroupName);
                }

                if (PartnerUserGroupIsDuplicated(sender, args.PartnerUserGroup))
                {
                    throw new CException("用户组名称:{0}已存在，请重新输入。", args.PartnerUserGroup.GroupName);
                }

                using (ObjectProxy op = new ObjectProxy(true))
                {
                    PartnerUserGroup ug = new PartnerUserGroup();
                    ug.GroupID = args.PartnerUserGroup.GroupID;
                    if (op.LoadPartnerUserGroupByGroupID(ug) == 0)
                    {
                        ug = null;
                    }
                    if (ug == null)
                    {
                        args.PartnerUserGroup.Created = DateTime.Now;
                        args.PartnerUserGroup.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.PartnerUserGroup.Modified = DateTime.Now;
                        args.PartnerUserGroup.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertPartnerUserGroup(args.PartnerUserGroup);
                    }
                    else
                    {
                        args.PartnerUserGroup.Modified = DateTime.Now;
                        args.PartnerUserGroup.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdatePartnerUserGroupByGroupID(args.PartnerUserGroup);
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
        public void DeletePartnerUserGroup(Sender sender, Guid groupID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    //删除用户组下面的角色用户；
                    List<PartnerRole> roles = op.LoadPartnerRolesByGroupID(groupID);
                    foreach (PartnerRole role in roles)
                    {
                        op.DeletePartnerUser2RolesByRoleID(role.RoleID);
                    }
                    //删除用户组下的角色
                    op.DeletePartnerRolesByGroupID(groupID);
                    //删除用户组
                    op.DeletePartnerUserGroupByGroupID(groupID);
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
