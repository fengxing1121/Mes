using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:04。
	/// </summary>
	[Serializable]
	[DataContract(Name = "TransportMain")]
	public class TransportMain
	{
		public TransportMain()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "TransportID")]
		public Guid TransportID
		{
			get;
			set;
		}
		
		/// <summary>
		///运输单号
		/// </summary>
		[DataMember(Name = "TransportNo")]
		public string TransportNo
		{
			get;
			set;
		}
		
		/// <summary>
		///车辆ID
		/// </summary>
		[DataMember(Name = "CarID")]
		public Guid CarID
		{
			get;
			set;
		}
		
		/// <summary>
		///出发地
		/// </summary>
		[DataMember(Name = "Source")]
		public string Source
		{
			get;
			set;
		}
		
		/// <summary>
		///目的地
		/// </summary>
		[DataMember(Name = "Target")]
		public string Target
		{
			get;
			set;
		}
		
		/// <summary>
		///运输费用
		/// </summary>
		[DataMember(Name = "Price")]
		public decimal Price
		{
			get;
			set;
		}
		
		/// <summary>
		///创建人
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///创建时间
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
		{
			get;
			set;
		}
	}
}
