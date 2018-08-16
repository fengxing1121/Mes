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
	public class OrderStepParm
	{
		private HttpContext _context;
		public OrderStepParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///步骤ID
		///</summary>
		public Guid StepID
		{
			get { return Guid.Parse(_context.Request["StepID"]);}
			set { this.stepID = value; }
		}
		private Guid stepID;
		
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
		///步骤序号
		///</summary>
		public int StepNo
		{
			get { return Convert.ToInt32(_context.Request["StepNo"]);}
			set { this.stepNo = value; }
		}
		private int stepNo;
		
		///<summary>
		///步骤名称
		///</summary>
		public string StepName
		{
			get { return Convert.ToString(_context.Request["StepName"]);}
			set { this.stepName = value; }
		}
		private string stepName;
		
		///<summary>
		///处理动作
		///</summary>
		public string Action
		{
			get { return Convert.ToString(_context.Request["Action"]);}
			set { this.action = value; }
		}
		private string action;
		
		///<summary>
		///下一步处理
		///</summary>
		public string TargetStep
		{
			get { return Convert.ToString(_context.Request["TargetStep"]);}
			set { this.targetStep = value; }
		}
		private string targetStep;
		
		///<summary>
		///提交人
		///</summary>
		public string StartedBy
		{
			get { return Convert.ToString(_context.Request["StartedBy"]);}
			set { this.startedBy = value; }
		}
		private string startedBy;
		
		///<summary>
		///提交时间
		///</summary>
		public DateTime Started
		{
			get { return  Convert.ToDateTime(_context.Request["Started"]);}
			set { this.started = value; }
		}
		private DateTime started;
		
		///<summary>
		///处理人
		///</summary>
		public string EndedBy
		{
			get { return Convert.ToString(_context.Request["EndedBy"]);}
			set { this.endedBy = value; }
		}
		private string endedBy;
		
		///<summary>
		///处理时间
		///</summary>
		public DateTime Ended
		{
			get { return  Convert.ToDateTime(_context.Request["Ended"]);}
			set { this.ended = value; }
		}
		private DateTime ended;
		
		///<summary>
		///处理类型
		///</summary>
		public string RemarkType
		{
			get { return Convert.ToString(_context.Request["RemarkType"]);}
			set { this.remarkType = value; }
		}
		private string remarkType;
		
		///<summary>
		///处理说明
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
	}
}
