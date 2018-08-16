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
	[DataContract(Name = "Supplier")]
	public class Supplier
	{
		public Supplier()
		{
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
		///供应商类型
		/// </summary>
		[DataMember(Name = "Category")]
		public string Category
		{
			get;
			set;
		}
		
		/// <summary>
		///供应商编号
		/// </summary>
		[DataMember(Name = "SupplierCode")]
		public string SupplierCode
		{
			get;
			set;
		}
		
		/// <summary>
		///供应商名称
		/// </summary>
		[DataMember(Name = "SupplierName")]
		public string SupplierName
		{
			get;
			set;
		}
		
		/// <summary>
		///详细地址
		/// </summary>
		[DataMember(Name = "Address")]
		public string Address
		{
			get;
			set;
		}
		
		/// <summary>
		///所属省份
		/// </summary>
		[DataMember(Name = "Province")]
		public string Province
		{
			get;
			set;
		}
		
		/// <summary>
		///所属城市
		/// </summary>
		[DataMember(Name = "City")]
		public string City
		{
			get;
			set;
		}
		
		/// <summary>
		///联系人
		/// </summary>
		[DataMember(Name = "LinkMan")]
		public string LinkMan
		{
			get;
			set;
		}
		
		/// <summary>
		///联系电话
		/// </summary>
		[DataMember(Name = "Tel")]
		public string Tel
		{
			get;
			set;
		}
		
		/// <summary>
		///手机
		/// </summary>
		[DataMember(Name = "Mobile")]
		public string Mobile
		{
			get;
			set;
		}
		
		/// <summary>
		///邮箱
		/// </summary>
		[DataMember(Name = "Email")]
		public string Email
		{
			get;
			set;
		}
		
		/// <summary>
		///备注
		/// </summary>
		[DataMember(Name = "Remark")]
		public string Remark
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
		
		/// <summary>
		///修改时间
		/// </summary>
		[DataMember(Name = "Modified")]
		public DateTime Modified
		{
			get;
			set;
		}
		
		/// <summary>
		///修改人
		/// </summary>
		[DataMember(Name = "ModifiedBy")]
		public string ModifiedBy
		{
			get;
			set;
		}
	}
}
