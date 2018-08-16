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
	public class OrderMadeStateParm
	{
		private HttpContext _context;
		public OrderMadeStateParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid DetailID
		{
			get { return Guid.Parse(_context.Request["DetailID"]);}
			set { this.detailID = value; }
		}
		private Guid detailID;
		
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
		///工件ID
		///</summary>
		public Guid ItemID
		{
			get { return Guid.Parse(_context.Request["ItemID"]);}
			set { this.itemID = value; }
		}
		private Guid itemID;
		
		///<summary>
		///工序ID
		///</summary>
		public Guid WorkFlowID
		{
			get { return Guid.Parse(_context.Request["WorkFlowID"]);}
			set { this.workFlowID = value; }
		}
		private Guid workFlowID;
		
		///<summary>
		///数量
		///</summary>
		public int Qty
		{
			get { return Convert.ToInt32(_context.Request["Qty"]);}
			set { this.qty = value; }
		}
		private int qty;
		
		///<summary>
		///处理人/班组
		///</summary>
		public string ProcessedBy
		{
			get { return Convert.ToString(_context.Request["ProcessedBy"]);}
			set { this.processedBy = value; }
		}
		private string processedBy;
		
		///<summary>
		///处理时间
		///</summary>
		public DateTime Processed
		{
			get { return  Convert.ToDateTime(_context.Request["Processed"]);}
			set { this.processed = value; }
		}
		private DateTime processed;
	}
}
