using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchRoomDesignerArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? CustomerID;
        public Guid? DesignerID;
        public string CustomerName;
        public Guid? PartnerID;
        public string PartnerName;
        public string Designer;
        public DateTime? DesignedFrom;
        public DateTime? DesignedTo;
        public List<string> Status;
        public string VillageName;
        public string Building;
        public string DesignerName;
        public string DesignerNo;
    }
}
