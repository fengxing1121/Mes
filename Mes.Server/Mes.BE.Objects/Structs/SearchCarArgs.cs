using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchCarArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? CarID;
        
        public string EnterpriseName;
        public string Address;
        public string LinkMan;
        public string Mobile;
        public string Tel;
        public string PlateNo;
        public string DriverName;
	}
}
