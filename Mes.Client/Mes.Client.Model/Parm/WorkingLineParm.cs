using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-12-20 14:41:26。
	/// </summary>
	public class WorkingLineParm
	{
		private HttpContext _context;
		public WorkingLineParm(HttpContext context)
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
		///
		///</summary>
		public Guid WorkingLineID
		{
			get { return Guid.Parse(_context.Request["WorkingLineID"]);}
			set { this.workingLineID = value; }
		}
		private Guid workingLineID;
		
		///<summary>
		///
		///</summary>
		public string WorkingLineName
		{
			get { return Convert.ToString(_context.Request["WorkingLineName"]);}
			set { this.workingLineName = value; }
		}
		private string workingLineName;
		
		///<summary>
		///备注
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
		
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
