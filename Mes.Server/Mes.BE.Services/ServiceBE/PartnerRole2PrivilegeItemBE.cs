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
        public PartnerRole2PrivilegeItem GetPartnerRole2PrivilegeItem(Sender sender, Guid RoleID, Guid PrivilegeItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    PartnerRole2PrivilegeItem obj = new PartnerRole2PrivilegeItem();
                    obj.RoleID = RoleID;
                    obj.PrivilegeItemID = PrivilegeItemID;
                    if (op.LoadPartnerRole2PrivilegeItemByRoleID_PrivilegeItemID(obj) == 0)
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
    }
}
