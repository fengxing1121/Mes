using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-10-30 10:23:05。
	/// </summary>
	[Serializable]
	[DataContract(Name = "SolutionOthers")]
	public class SolutionOthers
	{
		public SolutionOthers()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "SolutionID")]
		public Guid SolutionID
		{
			get;
			set;
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
		///产品名称
		/// </summary>
		[DataMember(Name = "CabinetGroup")]
		public string CabinetGroup
		{
			get;
			set;
		}
		
		/// <summary>
		///类型
		/// </summary>
		[DataMember(Name = "ItemType")]
		public string ItemType
		{
			get;
			set;
		}
		
		/// <summary>
		///明细项编码
		/// </summary>
		[DataMember(Name = "ItemCode")]
		public string ItemCode
		{
			get;
			set;
		}
		
		/// <summary>
		///明细项名称
		/// </summary>
		[DataMember(Name = "ItemName")]
		public string ItemName
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
		///长度
		/// </summary>
		[DataMember(Name = "Length")]
		public decimal Length
		{
			get;
			set;
		}
		
		/// <summary>
		///宽度
		/// </summary>
		[DataMember(Name = "Width")]
		public decimal Width
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
		///单位
		/// </summary>
		[DataMember(Name = "Unit")]
		public string Unit
		{
			get;
			set;
		}
	}
}
