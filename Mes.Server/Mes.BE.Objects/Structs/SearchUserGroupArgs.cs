using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchUserGroupArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;
        public List<Guid> UserGroupIDs;       
        public string GroupName;
        public bool? IsLocked;
        public bool? IsDisabled;
        public bool? IsSystem;        
	}
}
