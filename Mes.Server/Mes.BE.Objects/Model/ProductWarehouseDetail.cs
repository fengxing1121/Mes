using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:01。
	/// </summary>
	[Serializable]
	[DataContract(Name = "ProductWarehouseDetail")]
	public class ProductWarehouseDetail
	{
		public ProductWarehouseDetail()
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
		///包号ID
		/// </summary>
		[DataMember(Name = "PackageID")]
		public Guid PackageID
		{
			get;
			set;
		}
		
		/// <summary>
		///位置ID
		/// </summary>
		[DataMember(Name = "LocationID")]
		public Guid LocationID
		{
			get;
			set;
		}
		
		/// <summary>
		///创建时间
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///创建人
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
		{
			get;
			set;
		}
	}
}
