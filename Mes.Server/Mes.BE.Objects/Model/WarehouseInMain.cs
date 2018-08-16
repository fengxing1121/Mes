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
	[DataContract(Name = "WarehouseInMain")]
	public class WarehouseInMain
	{
		public WarehouseInMain()
		{
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
		///单号
		/// </summary>
		[DataMember(Name = "BillNo")]
		public string BillNo
		{
			get;
			set;
		}
		
		/// <summary>
		///批次号
		/// </summary>
		[DataMember(Name = "BattchNo")]
		public string BattchNo
		{
			get;
			set;
		}
		
		/// <summary>
		///供应商ID
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
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///入库时间
		/// </summary>
		[DataMember(Name = "CheckInDate")]
		public DateTime CheckInDate
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
