using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:58。
	/// </summary>
	[Serializable]
	[DataContract(Name = "OrderMadeState")]
	public class OrderMadeState
	{
		public OrderMadeState()
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
		///订单ID
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
		///工件ID
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
		[DataMember(Name = "Barcode")]
		public string Barcode
		{
			get;
			set;
		}
		
		/// <summary>
		///工序ID
		/// </summary>
		[DataMember(Name = "WorkFlowID")]
		public Guid WorkFlowID
		{
			get;
			set;
		}
		
		/// <summary>
		///班次
		/// </summary>
		[DataMember(Name = "WorkShiftID")]
		public Guid WorkShiftID
		{
			get;
			set;
		}
		
		/// <summary>
		///数量
		/// </summary>
		[DataMember(Name = "Qty")]
		public int Qty
		{
			get;
			set;
		}
		
		/// <summary>
		///处理人/班组
		/// </summary>
		[DataMember(Name = "ProcessedBy")]
		public string ProcessedBy
		{
			get;
			set;
		}
		
		/// <summary>
		///处理时间
		/// </summary>
		[DataMember(Name = "Processed")]
		public DateTime Processed
		{
			get;
			set;
		}
		
		/// <summary>
		///板件长
		/// </summary>
		[DataMember(Name = "MadeLength")]
		public decimal MadeLength
		{
			get;
			set;
		}
		
		/// <summary>
		///板件宽
		/// </summary>
		[DataMember(Name = "MadeWidth")]
		public decimal MadeWidth
		{
			get;
			set;
		}
		
		/// <summary>
		///板件厚
		/// </summary>
		[DataMember(Name = "MadeHeight")]
		public decimal MadeHeight
		{
			get;
			set;
		}
		
		/// <summary>
		///面积
		/// </summary>
		[DataMember(Name = "TotalAreal")]
		public decimal TotalAreal
		{
			get;
			set;
		}
		
		/// <summary>
		///板件周长
		/// </summary>
		[DataMember(Name = "Perimeter")]
		public decimal Perimeter
		{
			get;
			set;
		}
		
		/// <summary>
		///计费方式
		/// </summary>
		[DataMember(Name = "PaymentType")]
		public string PaymentType
		{
			get;
			set;
		}
		
		/// <summary>
		///价格
		/// </summary>
		[DataMember(Name = "Price")]
		public decimal Price
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
	}
}
