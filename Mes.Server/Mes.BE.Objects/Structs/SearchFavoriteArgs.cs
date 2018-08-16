using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchFavoriteArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        public Guid UserID;
        public Guid? PrivilegeID;
        public Guid? CategoryID;
        public bool? IsDisabled;
        public string FavoriteCategory;

	}
}
