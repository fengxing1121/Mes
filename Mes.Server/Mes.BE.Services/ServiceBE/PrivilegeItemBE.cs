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
        public List<PrivilegeItem> GetPrivilegeItemByPartnerUserID(Sender sender, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemsByPartnerUserID(userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByPartnerRoleID(Sender sender, Guid roleID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemsByPartnerRoleID(roleID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByPrivilegeID_PartnerUserID(Sender sender, Guid privilegeID, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemByPrivilegeID_PartnerUserID(privilegeID, userID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<PrivilegeItem> GetPrivilegeItemByPrivilegeCode_PartnerUserID(Sender sender, string privilegeCode, Guid userID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadPrivilegeItemByPrivilegeCode_PartnerUserID(privilegeCode, userID);
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
