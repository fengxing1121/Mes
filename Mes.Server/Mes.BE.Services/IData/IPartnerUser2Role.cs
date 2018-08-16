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
        void SavePartnerUser2Role(Sender sender, SavePartnerUser2RoleArgs args);
        [OperationContract]
        void DeletePartnerUser2Role(Sender sender, PartnerUser2Role user2Role);
        [OperationContract]
        List<PartnerUser2Role> GetPartnerUser2RoleByUserID(Sender sender, Guid userID);
        [OperationContract]
        List<PartnerUser2Role> GetPartnerUser2RoleByRoleID(Sender sender, Guid roleID);
    }
}
