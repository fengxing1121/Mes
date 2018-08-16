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
	[DataContract(Name = "ProductMain")]
	public class ProductMain
	{
		public ProductMain()
		{
		}
		
		/// <summary>
		///产品ID
		/// </summary>
		[DataMember(Name = "ProductID")]
		public Guid ProductID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CategoryID")]
		public Guid CategoryID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ImageUrl")]
		public string ImageUrl
		{
			get;
			set;
		}
		
		/// <summary>
		///产品编号
		/// </summary>
		[DataMember(Name = "ProductCode")]
		public string ProductCode
		{
			get;
			set;
		}
		
		/// <summary>
		///产品名称
		/// </summary>
		[DataMember(Name = "ProductName")]
		public string ProductName
		{
			get;
			set;
		}
		
		/// <summary>
		///尺寸
		/// </summary>
		[DataMember(Name = "Size")]
		public string Size
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
		///款式
		/// </summary>
		[DataMember(Name = "MaterialStyle")]
		public string MaterialStyle
		{
			get;
			set;
		}
		
		/// <summary>
		///材质类型
		/// </summary>
		[DataMember(Name = "MaterialCategory")]
		public string MaterialCategory
		{
			get;
			set;
		}
		
		/// <summary>
		///
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
