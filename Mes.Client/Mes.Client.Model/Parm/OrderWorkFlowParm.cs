using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:00。
	/// </summary>
	public class OrderWorkFlowParm
	{
		private HttpContext _context;
		public OrderWorkFlowParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid WorkingID
		{
			get { return Guid.Parse(_context.Request["WorkingID"]);}
			set { this.workingID = value; }
		}
		private Guid workingID;
		
		///<summary>
		///
		///</summary>
		public Guid OrderID
		{
			get { return Guid.Parse(_context.Request["OrderID"]);}
			set { this.orderID = value; }
		}
		private Guid orderID;
		
		///<summary>
		///
		///</summary>
		public Guid ItemID
		{
			get { return Guid.Parse(_context.Request["ItemID"]);}
			set { this.itemID = value; }
		}
		private Guid itemID;
		
		///<summary>
		///
		///</summary>
		public int WorkFlowNo
		{
			get { return Convert.ToInt32(_context.Request["WorkFlowNo"]);}
			set { this.workFlowNo = value; }
		}
		private int workFlowNo;
		
		///<summary>
		///
		///</summary>
		public string WorkFlowCode
		{
			get { return Convert.ToString(_context.Request["WorkFlowCode"]);}
			set { this.workFlowCode = value; }
		}
		private string workFlowCode;
		
		///<summary>
		///
		///</summary>
		public string Action
		{
			get { return Convert.ToString(_context.Request["Action"]);}
			set { this.action = value; }
		}
		private string action;
		
		///<summary>
		///
		///</summary>
		public string TargetWorkFlowCode
		{
			get { return Convert.ToString(_context.Request["TargetWorkFlowCode"]);}
			set { this.targetWorkFlowCode = value; }
		}
		private string targetWorkFlowCode;
		
		///<summary>
		///生产总数量
		///</summary>
		public int TotalQty
		{
			get { return Convert.ToInt32(_context.Request["TotalQty"]);}
			set { this.totalQty = value; }
		}
		private int totalQty;
		
		///<summary>
		///已生产数量
		///</summary>
		public int MadeQty
		{
			get { return Convert.ToInt32(_context.Request["MadeQty"]);}
			set { this.madeQty = value; }
		}
		private int madeQty;
	}
}
