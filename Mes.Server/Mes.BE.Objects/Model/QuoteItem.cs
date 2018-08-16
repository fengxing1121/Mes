using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-08-15 11:45:55。
	/// </summary>
	[Serializable]
	[DataContract(Name = "QuoteItem")]
	public class QuoteItem
	{
		public QuoteItem()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ItemID")]
		public Guid ItemID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CategoryCode")]
		public string CategoryCode
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "SubCagegoryCode")]
		public string SubCagegoryCode
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ItemCode")]
		public string ItemCode
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ItemName")]
		public string ItemName
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Style")]
		public string Style
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Model")]
		public string Model
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Unit")]
		public string Unit
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
