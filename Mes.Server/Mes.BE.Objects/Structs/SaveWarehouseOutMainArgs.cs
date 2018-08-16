using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SaveWarehouseOutMainArgs
	{
		 public WarehouseOutMain WarehouseOutMain;
         public List<WarehouseOutDetail> WarehouseOutDetails;
	}
}
