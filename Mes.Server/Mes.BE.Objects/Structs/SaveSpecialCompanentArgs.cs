using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SaveSpecialCompanentArgs
	{
		 public SpecialCompanent SpecialCompanent;
         public List<SpecialCompanent2WorkFlow> SpecialCompanent2WorkFlows;
	}
}
