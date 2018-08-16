using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SaveRoleArgs
	{
		 public Role Role;
         public List<Guid> UserIDs;       
         public List<Guid> PrivilegeItemIDs;
    }
}
