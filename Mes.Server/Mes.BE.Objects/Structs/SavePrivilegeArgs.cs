using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SavePrivilegeArgs
	{
		 public Privilege Privilege;
         public List<PrivilegeItem> PrivilegeItems;
	}
}
