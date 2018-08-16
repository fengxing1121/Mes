using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SaveMaterialArgs
	{
		 public Material Material;
         public List<Material2Supplier> Material2Suppliers;
	}
}
