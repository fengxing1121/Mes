using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:02。
	/// </summary>
	public class WorkCenterSchedulingParm
	{
		private HttpContext _context;
		public WorkCenterSchedulingParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///
		///</summary>
		public Guid WorkID
		{
			get { return Guid.Parse(_context.Request["WorkID"]);}
			set { this.workID = value; }
		}
		private Guid workID;
		
		///<summary>
		///设备ID
		///</summary>
		public Guid WorkCenterID
		{
			get { return Guid.Parse(_context.Request["WorkCenterID"]);}
			set { this.workCenterID = value; }
		}
		private Guid workCenterID;
		
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
		///预计生产时间
		///</summary>
		public DateTime Started
		{
			get { return  Convert.ToDateTime(_context.Request["Started"]);}
			set { this.started = value; }
		}
		private DateTime started;
		
		///<summary>
		///结束时间
		///</summary>
		public DateTime Ended
		{
			get { return  Convert.ToDateTime(_context.Request["Ended"]);}
			set { this.ended = value; }
		}
		private DateTime ended;
		
		///<summary>
		///状态(N：等 待；P：生产中；F：完成，C：取消）
		///</summary>
		public string Status
		{
			get { return Convert.ToString(_context.Request["Status"]);}
			set { this.status = value; }
		}
		private string status;
		
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
