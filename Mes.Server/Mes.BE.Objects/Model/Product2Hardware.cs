using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:00。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Product2Hardware")]
	public class Product2Hardware
	{
		public Product2Hardware()
		{
		}
		
		/// <summary>
		///明细ID
		/// </summary>
		[DataMember(Name = "ItemID")]
		public Guid ItemID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ProductID")]
		public Guid ProductID
		{
			get;
			set;
		}
		
		/// <summary>
		///条码编号
		/// </summary>
		[DataMember(Name = "BarcodeNo")]
		public string BarcodeNo
		{
			get;
			set;
		}
		
		/// <summary>
		///五金编号
		/// </summary>
		[DataMember(Name = "HardwareCode")]
		public string HardwareCode
		{
			get;
			set;
		}
		
		/// <summary>
		///名称
		/// </summary>
		[DataMember(Name = "HardwareName")]
		public string HardwareName
		{
			get;
			set;
		}
		
		/// <summary>
		///类型
		/// </summary>
		[DataMember(Name = "HardwareCategory")]
		public string HardwareCategory
		{
			get;
			set;
		}
		
		/// <summary>
		///型号
		/// </summary>
		[DataMember(Name = "Style")]
		public string Style
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
		[DataMember(Name = "Unit")]
		public string Unit
		{
			get;
			set;
		}
		
		/// <summary>
		///备注
		/// </summary>
		[DataMember(Name = "Remarks")]
		public string Remarks
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
