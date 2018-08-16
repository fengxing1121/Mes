using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchSolution2HardwareArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid? SolutionID;
        
        public Guid? CabinetID;
        public string SolutionCode;
        public string SolutionName;        
        public string Color;
        public string MaterialStyle;
        public string MaterialCategory;
        public string Size;      
	}
}
