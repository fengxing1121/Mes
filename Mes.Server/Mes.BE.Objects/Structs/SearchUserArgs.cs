using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchUserArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public List<Guid> UserIDs;
        public List<string> UserNames;
        public List<string> UserCodes;
        public Guid? DepartmentID;
        public string IDNumber;
        public bool? IsLocked;
        public bool? IsDisabled;
        public bool? IsSystem;
        public List<Guid> RKeyUserIDs;
        public List<Guid> RKeyRoleIDs;      
        public string DepartmentName;
        public Guid NotUsersByRoleID;       
        public bool? IsDefaultDepartment;
        public string Mobile;
    }
}
