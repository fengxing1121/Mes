using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPrivilegeCategoryArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;
        public List<Guid> CategoryIDs;       
        public string CategoryName;
        public List<Guid> PrivilegeIDs;
	}
}
