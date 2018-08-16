using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SavePartnerRoleArgs
	{
		 public PartnerRole PartnerRole;
         public List<Guid> UserIDs;
         public List<Guid> PrivilegeItemIDs;
    }
}
