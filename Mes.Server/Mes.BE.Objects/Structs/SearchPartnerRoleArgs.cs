using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPartnerRoleArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public List<Guid> RoleIDs;
        public List<string> RoleNames;
        public List<Guid> RKeyUserIDs;
        public List<Guid> GroupIDs;
        public bool? IsLocked;
        public bool? IsDisabled;
        public bool? IsSystem;
	}
}
