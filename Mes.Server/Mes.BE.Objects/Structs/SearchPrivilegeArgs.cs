using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPrivilegeArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public List<Guid> PrivilegeIDs;
        public string PrivilegeName;
        public string PrivilegeCode;
        public List<Guid> RKeyUserIDs;
        public List<Guid> RKeyRoleIDs;
        public List<Guid> CategoryIDs;
        public bool? IsDisabled;
	}
}
