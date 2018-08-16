using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-08-15 11:45:50。
	/// </summary>
	[Serializable]
	[DataContract(Name = "MaterialQuotePrice")]
	public class MaterialQuotePrice
	{
		public MaterialQuotePrice()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "MaterialID")]
		public Guid MaterialID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Price")]
		public decimal Price
		{
			get;
			set;
		}
	}
}
