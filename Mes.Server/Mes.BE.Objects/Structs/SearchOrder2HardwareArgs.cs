using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchOrder2HardwareArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? OrderID;
        public Guid? CabinetID;
        public string CabinetName;
        public Guid? ItemID;
        public string HardwareCode;
        public string HardwareName;
        public string HardwareCategory;
        public string Style;
	}
}
