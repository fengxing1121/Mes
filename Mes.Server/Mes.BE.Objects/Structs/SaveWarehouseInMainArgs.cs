using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SaveWarehouseInMainArgs
	{
		 public WarehouseInMain WarehouseInMain;
         public List<WarehouseInDetail> WarehouseInDetails;
	}
}
