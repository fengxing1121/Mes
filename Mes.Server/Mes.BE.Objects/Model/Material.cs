using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:56。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Material")]
	public class Material
	{
		public Material()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "MaterialID")]
		public Guid MaterialID
		{
			get;
			set;
		}
		
		/// <summary>
		///大类
		/// </summary>
		[DataMember(Name = "Category")]
		public string Category
		{
			get;
			set;
		}
		
		/// <summary>
		///小类
		/// </summary>
		[DataMember(Name = "SubCategory")]
		public string SubCategory
		{
			get;
			set;
		}
		
		/// <summary>
		///材料编号
		/// </summary>
		[DataMember(Name = "MaterialCode")]
		public string MaterialCode
		{
			get;
			set;
		}
		
		/// <summary>
		///材料名称
		/// </summary>
		[DataMember(Name = "MaterialName")]
		public string MaterialName
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
		///颜色
		/// </summary>
		[DataMember(Name = "Color")]
		public string Color
		{
			get;
			set;
		}
		
		/// <summary>
		///厚度
		/// </summary>
		[DataMember(Name = "Deepth")]
		public int Deepth
		{
			get;
			set;
		}
		
		/// <summary>
		///报价
		/// </summary>
		[DataMember(Name = "QuotedPrice")]
		public decimal QuotedPrice
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
		
		/// <summary>
		///图片地址
		/// </summary>
		[DataMember(Name = "ImageUrl")]
		public string ImageUrl
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
		///预扣数量
		/// </summary>
		[DataMember(Name = "Withholding_Qty")]
		public decimal Withholding_Qty
		{
			get;
			set;
		}
		
		/// <summary>
		///安全库存
		/// </summary>
		[DataMember(Name = "SafetyStock_Qty")]
		public decimal SafetyStock_Qty
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
