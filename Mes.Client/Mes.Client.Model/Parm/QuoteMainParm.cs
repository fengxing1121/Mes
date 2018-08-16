using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-26 17:30:46。
	/// </summary>
	public class QuoteMainParm
	{
		private HttpContext _context;
		public QuoteMainParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid QuoteID
		{
			get { return Guid.Parse(_context.Request["QuoteID"]);}
			set { this.quoteID = value; }
		}
		private Guid quoteID;
		
		///<summary>
		///报价单号
		///</summary>
		public string QuoteNo
		{
			get { return Convert.ToString(_context.Request["QuoteNo"]);}
			set { this.quoteNo = value; }
		}
		private string quoteNo;
		
		///<summary>
		///
		///</summary>
		public Guid SolutionID
		{
			get { return Guid.Parse(_context.Request["SolutionID"]);}
			set { this.solutionID = value; }
		}
		private Guid solutionID;
		
		///<summary>
		///客户
		///</summary>
		public Guid CustomerID
		{
			get { return Guid.Parse(_context.Request["CustomerID"]);}
			set { this.customerID = value; }
		}
		private Guid customerID;
		
		///<summary>
		///失效日期
		///</summary>
		public DateTime ExpiryDate
		{
			get { return  Convert.ToDateTime(_context.Request["ExpiryDate"]);}
			set { this.expiryDate = value; }
		}
		private DateTime expiryDate;
		
		///<summary>
		///折扣百分比
		///</summary>
		public decimal DiscountPercent
		{
			get { return Convert.ToDecimal(_context.Request["DiscountPercent"]);}
			set { this.discountPercent = value; }
		}
		private decimal discountPercent;
		
		///<summary>
		///订单总金额(折扣前)
		///</summary>
		public decimal TotalAmount
		{
			get { return Convert.ToDecimal(_context.Request["TotalAmount"]);}
			set { this.totalAmount = value; }
		}
		private decimal totalAmount;
		
		///<summary>
		///折扣金额
		///</summary>
		public decimal DiscountAmount
		{
			get { return Convert.ToDecimal(_context.Request["DiscountAmount"]);}
			set { this.discountAmount = value; }
		}
		private decimal discountAmount;
		
		///<summary>
		///
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
		
		///<summary>
		///报价单状态，N:确认中,F:已确认,C:已取消
		///</summary>
		public string Status
		{
			get { return Convert.ToString(_context.Request["Status"]);}
			set { this.status = value; }
		}
		private string status;
		
		///<summary>
		///报价日期
		///</summary>
		public DateTime Created
		{
			get { return  Convert.ToDateTime(_context.Request["Created"]);}
			set { this.created = value; }
		}
		private DateTime created;
		
		///<summary>
		///报价人
		///</summary>
		public string CreatedBy
		{
			get { return Convert.ToString(_context.Request["CreatedBy"]);}
			set { this.createdBy = value; }
		}
		private string createdBy;
		
		///<summary>
		///修改日期
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
