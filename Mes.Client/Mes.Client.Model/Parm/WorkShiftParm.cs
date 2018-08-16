using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:03。
	/// </summary>
	public class WorkShiftParm
	{
		private HttpContext _context;
		public WorkShiftParm(HttpContext context)
		{
			this._context = context;
		}
		
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
		///班组ID
		///</summary>
		public Guid WorkShiftID
		{
			get { return Guid.Parse(_context.Request["WorkShiftID"]);}
			set { this.workShiftID = value; }
		}
		private Guid workShiftID;
		
		///<summary>
		///班组编号
		///</summary>
		public string WorkShiftCode
		{
			get { return Convert.ToString(_context.Request["WorkShiftCode"]);}
			set { this.workShiftCode = value; }
		}
		private string workShiftCode;
		
		///<summary>
		///班组名称
		///</summary>
		public string WorkShiftName
		{
			get { return Convert.ToString(_context.Request["WorkShiftName"]);}
			set { this.workShiftName = value; }
		}
		private string workShiftName;
		
		///<summary>
		///上班时间
		///</summary>
		public string Started
		{
			get { return Convert.ToString(_context.Request["Started"]);}
			set { this.started = value; }
		}
		private string started;
		
		///<summary>
		///下班时间
		///</summary>
		public string Ended
		{
			get { return Convert.ToString(_context.Request["Ended"]);}
			set { this.ended = value; }
		}
		private string ended;
		
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
