using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchRoomDesignerFileArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;
	}
}
