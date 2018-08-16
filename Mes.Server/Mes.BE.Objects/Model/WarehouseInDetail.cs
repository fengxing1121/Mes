using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:05。
	/// </summary>
	[Serializable]
	[DataContract(Name = "WarehouseInDetail")]
	public class WarehouseInDetail
	{
		public WarehouseInDetail()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "DetailID")]
		public Guid DetailID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "InID")]
		public Guid InID
		{
			get;
			set;
		}
		
		/// <summary>
		///物料ID
		/// </summary>
		[DataMember(Name = "MaterialID")]
		public Guid MaterialID
		{
			get;
			set;
		}
		
		/// <summary>
		///数量
		/// </summary>
		[DataMember(Name = "Qty")]
		public decimal Qty
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
		///仓位ID
		/// </summary>
		[DataMember(Name = "LocationID")]
		public Guid LocationID
		{
			get;
			set;
		}
	}
}
