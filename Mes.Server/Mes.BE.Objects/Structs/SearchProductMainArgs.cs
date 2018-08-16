using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchProductMainArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;
	}
}
