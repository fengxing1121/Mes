using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-08-15 11:45:50。
	/// </summary>
	public class MaterialParm
	{
		private HttpContext _context;
		public MaterialParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid MaterialID
		{
			get { return Guid.Parse(_context.Request["MaterialID"]);}
			set { this.materialID = value; }
		}
		private Guid materialID;
		
		///<summary>
		///大类
		///</summary>
		public string Category
		{
			get { return Convert.ToString(_context.Request["Category"]);}
			set { this.category = value; }
		}
		private string category;
		
		///<summary>
		///小类
		///</summary>
		public string SubCategory
		{
			get { return Convert.ToString(_context.Request["SubCategory"]);}
			set { this.subCategory = value; }
		}
		private string subCategory;
		
		///<summary>
		///材料编号
		///</summary>
		public string MaterialCode
		{
			get { return Convert.ToString(_context.Request["MaterialCode"]);}
			set { this.materialCode = value; }
		}
		private string materialCode;


		///<summary>
		///材料名称
		///</summary>
		public string MaterialName
		{
			get { return Convert.ToString(_context.Request["MaterialName"]);}
			set { this.materialName = value; }
		}
		private string materialName;
		
		///<summary>
		///型号
		///</summary>
		public string Style
		{
			get { return Convert.ToString(_context.Request["Style"]);}
			set { this.style = value; }
		}
		private string style;
		
		///<summary>
		///颜色
		///</summary>
		public string Color
		{
			get { return Convert.ToString(_context.Request["Color"]);}
			set { this.color = value; }
		}
		private string color;
		
		///<summary>
		///厚度
		///</summary>
		public int Deepth
		{
			get { return Convert.ToInt32(_context.Request["Deepth"]);}
			set { this.deepth = value; }
		}
		private int deepth;
		
		///<summary>
		///报价
		///</summary>
		public decimal QuotedPrice
		{
			get { return Convert.ToDecimal(_context.Request["QuotedPrice"]);}
			set { this.quotedPrice = value; }
		}
		private decimal quotedPrice;
		
		///<summary>
		///单位
		///</summary>
		public string Unit
		{
			get { return Convert.ToString(_context.Request["Unit"]);}
			set { this.unit = value; }
		}
		private string unit;
		
		///<summary>
		///图片地址
		///</summary>
		public string ImageUrl
		{
			get { return Convert.ToString(_context.Request["ImageUrl"]);}
			set { this.imageUrl = value; }
		}
		private string imageUrl;
		
		///<summary>
		///备注
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
		
		///<summary>
		///预扣数量
		///</summary>
		public decimal Withholding_Qty
		{
			get { return Convert.ToDecimal(_context.Request["Withholding_Qty"]);}
			set { this.withholding_Qty = value; }
		}
		private decimal withholding_Qty;
		
		///<summary>
		///安全库存
		///</summary>
		public decimal SafetyStock_Qty
		{
			get { return Convert.ToDecimal(_context.Request["SafetyStock_Qty"]);}
			set { this.safetyStock_Qty = value; }
		}
		private decimal safetyStock_Qty;
		
		///<summary>
		///
		///</summary>
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		
		///<summary>
		///
		///</summary>
		public DateTime Modified
		{
			get { return  Convert.ToDateTime(_context.Request["Modified"]);}
			set { this.modified = value; }
		}
		private DateTime modified;
		
		///<summary>
		///
		///</summary>
		public string ModifiedBy
		{
			get { return Convert.ToString(_context.Request["ModifiedBy"]);}
			set { this.modifiedBy = value; }
		}
		private string modifiedBy;
	}
}
