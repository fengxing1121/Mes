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
	[DataContract(Name = "WarehouseOutMain")]
	public class WarehouseOutMain
	{
		public WarehouseOutMain()
		{
		}
		
		/// <summary>
		///出库ID
		/// </summary>
		[DataMember(Name = "OutID")]
		public Guid OutID
		{
			get;
			set;
		}
		
		/// <summary>
		///出库单号
		/// </summary>
		[DataMember(Name = "BillNo")]
		public string BillNo
		{
			get;
			set;
		}
		
		/// <summary>
		///使用车间
		/// </summary>
		[DataMember(Name = "WorkShopID")]
		public Guid WorkShopID
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
		///出库日期
		/// </summary>
		[DataMember(Name = "CheckOutDate")]
		public DateTime CheckOutDate
		{
			get;
			set;
		}
		
		/// <summary>
		///经手人
		/// </summary>
		[DataMember(Name = "HandlerMan")]
		public string HandlerMan
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
