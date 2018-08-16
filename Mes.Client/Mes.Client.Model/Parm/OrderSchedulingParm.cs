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
	public class OrderSchedulingParm
	{
		private HttpContext _context;
		public OrderSchedulingParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///排产ID
		///</summary>
		public Guid MadeID
		{
			get { return Guid.Parse(_context.Request["MadeID"]);}
			set { this.madeID = value; }
		}
		private Guid madeID;
		
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
		///批次号
		///</summary>
		public string BattchNum
		{
			get { return Convert.ToString(_context.Request["BattchNum"]);}
			set { this.battchNum = value; }
		}
		private string battchNum;
		
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
		///工序部件总数量
		///</summary>
		public int TotalQty
		{
			get { return Convert.ToInt32(_context.Request["TotalQty"]);}
			set { this.totalQty = value; }
		}
		private int totalQty;
		
		///<summary>
		///工序部件总面积
		///</summary>
		public decimal TotalAreal
		{
			get { return Convert.ToDecimal(_context.Request["TotalAreal"]);}
			set { this.totalAreal = value; }
		}
		private decimal totalAreal;
		
		///<summary>
		///工序部件总长度
		///</summary>
		public decimal TotalLength
		{
			get { return Convert.ToDecimal(_context.Request["TotalLength"]);}
			set { this.totalLength = value; }
		}
		private decimal totalLength;
		
		///<summary>
		///预计生产结束时间
		///</summary>
		public DateTime Estimated
		{
			get { return  Convert.ToDateTime(_context.Request["Estimated"]);}
			set { this.estimated = value; }
		}
		private DateTime estimated;
		
		///<summary>
		///实际生产日期
		///</summary>
		public DateTime MadeStarted
		{
			get { return  Convert.ToDateTime(_context.Request["MadeStarted"]);}
			set { this.madeStarted = value; }
		}
		private DateTime madeStarted;
		
		///<summary>
		///生产结束时间
		///</summary>
		public DateTime MadeEnded
		{
			get { return  Convert.ToDateTime(_context.Request["MadeEnded"]);}
			set { this.madeEnded = value; }
		}
		private DateTime madeEnded;
		
		///<summary>
		///预计生产时长
		///</summary>
		public decimal ProductionPeriod
		{
			get { return Convert.ToDecimal(_context.Request["ProductionPeriod"]);}
			set { this.productionPeriod = value; }
		}
		private decimal productionPeriod;
		
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
