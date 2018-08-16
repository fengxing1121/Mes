using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-26 16:45:36。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Category")]
	public class Category
	{
		public Category()
		{
		}
		
		/// <summary>
		///字典ID
		/// </summary>
		[DataMember(Name = "CategoryID")]
		public Guid CategoryID
		{
			get;
			set;
		}
		
		/// <summary>
		///所属父级
		/// </summary>
		[DataMember(Name = "ParentID")]
		public Guid ParentID
		{
			get;
			set;
		}
		
		/// <summary>
		///字典码
		/// </summary>
		[DataMember(Name = "CategoryCode")]
		public string CategoryCode
		{
			get;
			set;
		}
		
		/// <summary>
		///字典名称
		/// </summary>
		[DataMember(Name = "CategoryName")]
		public string CategoryName
		{
			get;
			set;
		}
		
		/// <summary>
		///简称
		/// </summary>
		[DataMember(Name = "ShortName")]
		public string ShortName
		{
			get;
			set;
		}
		
		/// <summary>
		///排序号
		/// </summary>
		[DataMember(Name = "Sequence")]
		public int Sequence
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
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Extend")]
		public string Extend
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
