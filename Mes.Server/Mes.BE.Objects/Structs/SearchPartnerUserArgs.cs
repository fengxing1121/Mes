using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPartnerUserArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? PartnerID;
        public List<Guid> UserIDs;
        public List<string> UserNames;
        public List<string> UserCodes;     
        public bool? IsLocked;
        public bool? IsDisabled;
        public bool? IsSystem;
        public List<Guid> RKeyUserIDs;
        public List<Guid> RKeyRoleIDs;       
        public Guid NotUsersByRoleID;
        public bool? IsDefaultDepartment;
        public string Mobile;
        public string EndDate;
        public int? MemberClass;
    }
}
