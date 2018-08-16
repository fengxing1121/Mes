using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:07。
	/// </summary>
	[Serializable]
	[DataContract(Name = "WorkShop")]
	public class WorkShop
	{
		public WorkShop()
		{
		}
		
		/// <summary>
		///车间ID
		/// </summary>
		[DataMember(Name = "WorkShopID")]
		public Guid WorkShopID
		{
			get;
			set;
		}
		
		/// <summary>
		///车间编号
		/// </summary>
		[DataMember(Name = "WorkShopCode")]
		public string WorkShopCode
		{
			get;
			set;
		}
		
		/// <summary>
		///车间名称
		/// </summary>
		[DataMember(Name = "WorkShopName")]
		public string WorkShopName
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "WorkingLineID")]
		public Guid WorkingLineID
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
