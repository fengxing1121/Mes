using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPartnerRole2PrivilegeItemArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;
	}
}
