using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSolutionArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        
        public Guid? SolutionID;       
        public Guid? CustomerID;
        public string SolutionCode;
        public string SolutionName;
        public string CustomerName;
        public string Status;
        public string Designer;
        public Guid? PartnerID;
        public Guid? DesignerID;
        public string PartnerIDs;
        public string UserCodes;
        public Guid? CompanyID;
    }
}
