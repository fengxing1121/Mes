using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace  Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:00。
	/// </summary>
	public class OrderResourceParm
	{
		private HttpContext _context;
		public OrderResourceParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///任务ID
		///</summary>
		public Guid OrderID
		{
			get { return Guid.Parse(_context.Request["OrderID"]);}
			set { this.orderID = value; }
		}
		private Guid orderID;
		
		///<summary>
		///任务处理资源（角色/用户)
		///</summary>
		public string Resource
		{
			get { return Convert.ToString(_context.Request["Resource"]);}
			set { this.resource = value; }
		}
		private string resource;
		
		///<summary>
		///请求处理页面
		///</summary>
		public string Request
		{
			get { return Convert.ToString(_context.Request["Request"]);}
			set { this.request = value; }
		}
		private string request;
		
		///<summary>
		///任务开始时间
		///</summary>
		public DateTime Started
		{
			get { return  Convert.ToDateTime(_context.Request["Started"]);}
			set { this.started = value; }
		}
		private DateTime started;
		
		///<summary>
		///任务开始处理人
		///</summary>
		public string StartedBy
		{
			get { return Convert.ToString(_context.Request["StartedBy"]);}
			set { this.startedBy = value; }
		}
		private string startedBy;
	}
}
