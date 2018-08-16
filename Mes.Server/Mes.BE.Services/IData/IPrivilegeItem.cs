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
    public partial interface IServiceBE
    {
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByPartnerUserID(Sender sender, Guid userID);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByPartnerRoleID(Sender sender, Guid roleID);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByPrivilegeID_PartnerUserID(Sender sender, Guid privilegeID, Guid userID);
        [OperationContract]
        List<PrivilegeItem> GetPrivilegeItemByPrivilegeCode_PartnerUserID(Sender sender, string privilegeCode, Guid userID);
    }
}
