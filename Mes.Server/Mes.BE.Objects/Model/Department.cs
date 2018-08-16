using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:55。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Department")]
	public class Department
	{
		public Department()
		{
		}
		
		/// <summary>
		///部门ID
		/// </summary>
		[DataMember(Name = "DepartmentID")]
		public Guid DepartmentID
		{
			get;
			set;
		}
		
		/// <summary>
		///门店编号
		/// </summary>
		[DataMember(Name = "DepartmentCode")]
		public string DepartmentCode
		{
			get;
			set;
		}
		
		/// <summary>
		///部门名称
		/// </summary>
		[DataMember(Name = "DepartmentName")]
		public string DepartmentName
		{
			get;
			set;
		}
		
		/// <summary>
		///部门电话
		/// </summary>
		[DataMember(Name = "Tel")]
		public string Tel
		{
			get;
			set;
		}
		
		/// <summary>
		///部门传真
		/// </summary>
		[DataMember(Name = "Fax")]
		public string Fax
		{
			get;
			set;
		}
		
		/// <summary>
		///禁用标志
		/// </summary>
		[DataMember(Name = "IsDisabled")]
		public bool IsDisabled
		{
			get;
			set;
		}
		
		/// <summary>
		///描述
		/// </summary>
		[DataMember(Name = "Description")]
		public string Description
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
