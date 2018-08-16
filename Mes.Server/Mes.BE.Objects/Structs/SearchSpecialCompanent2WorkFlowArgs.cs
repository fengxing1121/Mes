using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSpecialCompanent2WorkFlowArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? SpecialID;
     
        public Guid? WorkFlowID;
        public string ItemName;
        public bool? IsDisabled;

	}
}
