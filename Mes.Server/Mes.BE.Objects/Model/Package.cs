using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:59。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Package")]
	public class Package
	{
		public Package()
		{
		}
		
		/// <summary>
		///包装箱ID
		/// </summary>
		[DataMember(Name = "PackageID")]
		public Guid PackageID
		{
			get;
			set;
		}
		
		/// <summary>
		///包装箱条码
		/// </summary>
		[DataMember(Name = "PackageBarcode")]
		public string PackageBarcode
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
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CabinetID")]
		public Guid CabinetID
		{
			get;
			set;
		}
		
		/// <summary>
		///包装箱编号
		/// </summary>
		[DataMember(Name = "PackageNum")]
		public int PackageNum
		{
			get;
			set;
		}
		
		/// <summary>
		///宽度
		/// </summary>
		[DataMember(Name = "PackageWidth")]
		public decimal PackageWidth
		{
			get;
			set;
		}
		
		/// <summary>
		///厚度
		/// </summary>
		[DataMember(Name = "PackageHeight")]
		public decimal PackageHeight
		{
			get;
			set;
		}
		
		/// <summary>
		///长度
		/// </summary>
		[DataMember(Name = "PackageLength")]
		public decimal PackageLength
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ItemsQty")]
		public int ItemsQty
		{
			get;
			set;
		}
		
		/// <summary>
		///重量
		/// </summary>
		[DataMember(Name = "Weight")]
		public decimal Weight
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
