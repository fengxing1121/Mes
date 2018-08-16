using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchOrderMadeStateArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public Guid? WorkFlowID;
        public Guid? CabinetID;
        public Guid? OrderID;
        public Guid? WorkShiftID;
        public Guid? ItemID;
        public string WorkFlowName;
        public string ProcessedBy;
        public DateTime? ProcessedFrom;
        public DateTime? ProcessedTo;
    }
}
