using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchOrderWorkFlowArgs
	{
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid CompanyID;
        public Guid? WorkFlowID;
        public string WorkFlowCode;
        public string WorkFlowName;
        public Guid? OrderID;
        public Guid? ItemID;
        public string OrderNo;
        public Guid? CabinetID;
        public bool? ScanFlag;
        public string RolesTemp;
        public string MadeQty;
        public string PrintCount;
    }
}
