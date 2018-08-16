using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-03-15 21:39:28。
	/// </summary>
	public class ProductMainParm
	{
		private HttpContext _context;
		public ProductMainParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///产品ID
		///</summary>
		public Guid ProductID
		{
			get { return Guid.Parse(_context.Request["ProductID"]);}
			set { this.productID = value; }
		}
		private Guid productID;
		
		///<summary>
		///
		///</summary>
		public Guid CompanyID
		{
			get { return Guid.Parse(_context.Request["CompanyID"]);}
			set { this.companyID = value; }
		}
		private Guid companyID;
		
		///<summary>
		///
		///</summary>
		public Guid CategoryID
		{
			get { return Guid.Parse(_context.Request["CategoryID"]);}
			set { this.categoryID = value; }
		}
		private Guid categoryID;
		
		///<summary>
		///产品编号
		///</summary>
		public string ProductCode
		{
			get { return Convert.ToString(_context.Request["ProductCode"]);}
			set { this.productCode = value; }
		}
		private string productCode;
		
		///<summary>
		///产品名称
		///</summary>
		public string ProductName
		{
			get { return Convert.ToString(_context.Request["ProductName"]);}
			set { this.productName = value; }
		}
		private string productName;
		
		///<summary>
		///尺寸
		///</summary>
		public string Size
		{
			get { return Convert.ToString(_context.Request["Size"]);}
			set { this.size = value; }
		}
		private string size;
		
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
		///款式
		///</summary>
		public string MaterialStyle
		{
			get { return Convert.ToString(_context.Request["MaterialStyle"]);}
			set { this.materialStyle = value; }
		}
		private string materialStyle;
		
		///<summary>
		///材质类型
		///</summary>
		public string MaterialCategory
		{
			get { return Convert.ToString(_context.Request["MaterialCategory"]);}
			set { this.materialCategory = value; }
		}
		private string materialCategory;
		
		///<summary>
		///创建时间
		///</summary>
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///创建人
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		
		///<summary>
		///修改时间
		///</summary>
		public DateTime Modified
		{
			get { return  Convert.ToDateTime(_context.Request["Modified"]);}
			set { this.modified = value; }
		}
		private DateTime modified;
		
		///<summary>
		///修改人
		///</summary>
		public string ModifiedBy
		{
			get { return Convert.ToString(_context.Request["ModifiedBy"]);}
			set { this.modifiedBy = value; }
		}
		private string modifiedBy;

        public decimal Price
        {
            get { return Convert.ToDecimal(_context.Request["Price"]); }
            set { this.price = value; }
        }

        public decimal price;
    }
}
