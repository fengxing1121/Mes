using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchBattchFileArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? WorkingLineID;
        public Guid? FileID;
        public string BattchNum;
        public string WorkCenterName;
        public bool? IsDownload;
	}
}
