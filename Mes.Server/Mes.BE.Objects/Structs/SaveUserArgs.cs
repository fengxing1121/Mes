using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SaveUserArgs
	{
		 public User User;

         public List<Guid> RoleIDs;
    }
}
