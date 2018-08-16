using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchOrderSchedulingArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? OrderID;
        public Guid? WorkFlowID;
        public string WorkFlowCode;
        public string WorkFlowName;
        public string OrderNo;
        public string BatchNo;
        public DateTime? BookingDateFrom;
        public DateTime? BookingDateTo;
        public DateTime? ShipDateFrom;
        public DateTime? ShipDateTo;
        
	}
}
