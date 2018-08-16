using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPrivilegeItemArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public List<Guid> PrivilegeItemIDs;
        public List<Guid> PrivilegeIDs;
        public string PrivilegeCode;
        public string PrivilegeItemCode;
        public string PrivilegeItemName;
        public List<Guid> RKeyUserIDs;
        public List<Guid> RKeyRoleIDs;
        public bool? IsLocked;
        public bool? IsDisabled;        
	}
}
