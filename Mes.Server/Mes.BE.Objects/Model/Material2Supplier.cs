using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:56。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Material2Supplier")]
	public class Material2Supplier
	{
		public Material2Supplier()
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
		[DataMember(Name = "SupplierID")]
		public Guid SupplierID
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
		
		/// <summary>
		///最小采购量
		/// </summary>
		[DataMember(Name = "MinPurchaseQty")]
		public int MinPurchaseQty
		{
			get;
			set;
		}
		
		/// <summary>
		///最小交期
		/// </summary>
		[DataMember(Name = "MinDelivery")]
		public int MinDelivery
		{
			get;
			set;
		}
	}
}
