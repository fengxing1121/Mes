using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchWorkCenterSchedulingArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public DateTime? StartedFrom;
        public DateTime? StartedTo;
        public DateTime? EndedFrom;
        public DateTime? EndedTo;
        public string WorkCenterName;
        public Guid? WorkCenterID;
        public string BattchNum;
        public string OrderNo;
        public string CustomerName;
        public Guid? PartnerID;
        public string PartnerName;
        public Guid? WorkingLineID;
        public Guid? WorkShopID;
	}
}
