using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchWorkCenterArgs
    {
        public string OrderBy;
        public int? RowNumberFrom;
        public int? RowNumberTo;

        public Guid CompanyID;
        public Guid? WorkCenterID;
        public string WorkCenterCode;
        public string WorkCenterName;
        public Guid? WorkFlowID;
        public string WorkFlowName;
        public string WorkFlowCode;
        public Guid? WorkShopID;
        public Guid? WorkingLineID;
    }
}
