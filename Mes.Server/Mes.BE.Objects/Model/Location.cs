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
	[DataContract(Name = "Location")]
	public class Location
	{
		public Location()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "LocationID")]
		public Guid LocationID
		{
			get;
			set;
		}
		
		/// <summary>
		///所属仓库ID
		/// </summary>
		[DataMember(Name = "WarehouseID")]
		public Guid WarehouseID
		{
			get;
			set;
		}
		
		/// <summary>
		///所属仓库
		/// </summary>
		[DataMember(Name = "Category")]
		public string Category
		{
			get;
			set;
		}
		
		/// <summary>
		///仓位编号
		/// </summary>
		[DataMember(Name = "LocationCode")]
		public string LocationCode
		{
			get;
			set;
		}
		
		/// <summary>
		///最大重量
		/// </summary>
		[DataMember(Name = "MaxWeight")]
		public decimal MaxWeight
		{
			get;
			set;
		}
		
		/// <summary>
		///最大包数/件数
		/// </summary>
		[DataMember(Name = "MaxPackage")]
		public int MaxPackage
		{
			get;
			set;
		}
		
		/// <summary>
		///柜号
		/// </summary>
		[DataMember(Name = "CabinetNum")]
		public string CabinetNum
		{
			get;
			set;
		}
		
		/// <summary>
		///层号
		/// </summary>
		[DataMember(Name = "LayerNum")]
		public string LayerNum
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "IsDisabled")]
		public bool IsDisabled
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "PackageQty")]
		public int PackageQty
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Weight")]
		public decimal Weight
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Flag")]
		public bool Flag
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Modified")]
		public DateTime Modified
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ModifiedBy")]
		public string ModifiedBy
		{
			get;
			set;
		}
	}
}
