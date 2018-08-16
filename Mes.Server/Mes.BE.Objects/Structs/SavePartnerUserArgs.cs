using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
    [Serializable]
    public struct SavePartnerUserArgs
    {
        public PartnerUser PartnerUser;
        public List<Guid> RoleIDs;
    }
}
