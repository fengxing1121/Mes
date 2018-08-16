using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchDepartmentArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public List<Guid> DepartmentIDs;       
        public List<string> DepartmentCodes;
        public List<string> DepartmentNames; 
        public bool? IsDisabled;        
	}
}
