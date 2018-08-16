using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSolutionFileArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? SolutionID;
        
        public Guid? FileID;
        public Guid? CabinetID;
        public string FileName;
        public string Status;
        public string SourceType;
    }
}
