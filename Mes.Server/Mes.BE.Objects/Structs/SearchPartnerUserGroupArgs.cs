using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPartnerUserGroupArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? PartnerID;
        public List<Guid> UserGroupIDs;
        public string GroupName;
        public bool? IsLocked;
        public bool? IsDisabled;
        public bool? IsSystem;    
	}
}
