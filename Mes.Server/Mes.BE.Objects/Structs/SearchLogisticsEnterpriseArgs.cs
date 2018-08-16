using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchLogisticsEnterpriseArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public string EnterpriseName;
        public string Address;
        public string LinkMan;
        public string Mobile;
        public string Tel;
	}
}
