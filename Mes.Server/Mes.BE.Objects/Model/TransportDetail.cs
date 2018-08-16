using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:03。
	/// </summary>
	[Serializable]
	[DataContract(Name = "TransportDetail")]
	public class TransportDetail
	{
		public TransportDetail()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "TransportID")]
		public Guid TransportID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "OrderID")]
		public Guid OrderID
		{
			get;
			set;
		}
	}
}
