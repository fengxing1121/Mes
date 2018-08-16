using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:57:59。
	/// </summary>
	public class Order2CabinetParm
	{
		private HttpContext _context;
		public Order2CabinetParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///产品ID
		///</summary>
		public Guid CabinetID
		{
			get { return Guid.Parse(_context.Request["CabinetID"]);}
			set { this.cabinetID = value; }
		}
		private Guid cabinetID;
		
		///<summary>
		///订单ID
		///</summary>
		public Guid OrderID
		{
			get { return Guid.Parse(_context.Request["OrderID"]);}
			set { this.orderID = value; }
		}
		private Guid orderID;
		
		///<summary>
		///产品名称
		///</summary>
		public string CabinetName
		{
			get { return Convert.ToString(_context.Request["CabinetName"]);}
			set { this.cabinetName = value; }
		}
		private string cabinetName;
		
		///<summary>
		///
		///</summary>
		public int Qty
		{
			get { return Convert.ToInt32(_context.Request["Qty"]);}
			set { this.qty = value; }
		}
		private int qty;
		
		///<summary>
		///销售价格
		///</summary>
		public decimal Price
		{
			get { return Convert.ToDecimal(_context.Request["Price"]);}
			set { this.price = value; }
		}
		private decimal price;
		
		///<summary>
		///成本价格
		///</summary>
		public decimal CostPrice
		{
			get { return Convert.ToDecimal(_context.Request["CostPrice"]);}
			set { this.costPrice = value; }
		}
		private decimal costPrice;
		
		///<summary>
		///
		///</summary>
		public decimal DealerPrice
		{
			get { return Convert.ToDecimal(_context.Request["DealerPrice"]);}
			set { this.dealerPrice = value; }
		}
		private decimal dealerPrice;
		
		///<summary>
		///板件总面积
		///</summary>
		public decimal TotalAreal
		{
			get { return Convert.ToDecimal(_context.Request["TotalAreal"]);}
			set { this.totalAreal = value; }
		}
		private decimal totalAreal;
		
		///<summary>
		///板件总长度
		///</summary>
		public decimal TotalLength
		{
			get { return Convert.ToDecimal(_context.Request["TotalLength"]);}
			set { this.totalLength = value; }
		}
		private decimal totalLength;
		
		///<summary>
		///文件上传标志
		///</summary>
		public bool FileUploadFlag
		{
			get { return Convert.ToBoolean(_context.Request["FileUploadFlag"]);}
			set { this.fileUploadFlag = value; }
		}
		private bool fileUploadFlag;
		
		///<summary>
		///是否是装
		///</summary>
		public bool IsTestAssemble
		{
			get { return Convert.ToBoolean(_context.Request["IsTestAssemble"]);}
			set { this.isTestAssemble = value; }
		}
		private bool isTestAssemble;
		
		///<summary>
		///主材
		///</summary>
		public Guid MainMaterialID
		{
			get { return Guid.Parse(_context.Request["MainMaterialID"]);}
			set { this.mainMaterialID = value; }
		}
		private Guid mainMaterialID;
		
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
	}
}
