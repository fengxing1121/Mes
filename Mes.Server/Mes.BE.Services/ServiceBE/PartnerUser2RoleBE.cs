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
        public void SavePartnerUser2Role(Sender sender, SavePartnerUser2RoleArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadPartnerUser2RoleByUserID_RoleID(args.PartnerUser2Role) == 0)
                    {
                        op.InsertPartnerUser2Role(args.PartnerUser2Role);
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
        public void DeletePartnerUser2Role(Sender sender, PartnerUser2Role user2Role)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeletePartnerUser2RoleByUserID_RoleID(user2Role.UserID, user2Role.RoleID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerUser2Role> GetPartnerUser2RoleByUserID(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerUser2RolesByUserID(userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PartnerUser2Role> GetPartnerUser2RoleByRoleID(Sender sender, Guid roleID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPartnerUser2RolesByRoleID(roleID);
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
