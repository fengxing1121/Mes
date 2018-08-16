using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SaveTransportArgs
	{
        public TransportMain TransportMain;
		 public List<TransportDetail> TransportDetails;
	}
}
