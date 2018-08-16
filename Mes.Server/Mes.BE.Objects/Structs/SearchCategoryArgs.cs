using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchCategoryArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public List<Guid> CategoryIDs;
        public Guid? ParentID;
        public string CategoryCode;
        public string CategoryName;
        public string ShortName;
        public bool? IsDisabled;

	}
}
