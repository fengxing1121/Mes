using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSolutionOthersArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? SolutionID;
        public Guid? DetailID;
        public string CabinetGroup;
        public string ItemType;
        public string ItemCode;
        public string ItemName;
	}
}
