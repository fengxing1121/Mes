using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchOrderProcessFileArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? OrderID;
        public Guid? CabinetID;
        public List<string> FileType;
        public string CabinetName;
        public string Tag;
        public string OrderNo;
        public string BattchNum;
        
	}
}
