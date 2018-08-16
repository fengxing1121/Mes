using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-12-20 14:41:27。
	/// </summary>
	public class WorkShopParm
	{
		private HttpContext _context;
		public WorkShopParm(HttpContext context)
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
		///车间ID
		///</summary>
		public Guid WorkShopID
		{
			get { return Guid.Parse(_context.Request["WorkShopID"]);}
			set { this.workShopID = value; }
		}
		private Guid workShopID;
		
		///<summary>
		///车间编号
		///</summary>
		public string WorkShopCode
		{
			get { return Convert.ToString(_context.Request["WorkShopCode"]);}
			set { this.workShopCode = value; }
		}
		private string workShopCode;
		
		///<summary>
		///车间名称
		///</summary>
		public string WorkShopName
		{
			get { return Convert.ToString(_context.Request["WorkShopName"]);}
			set { this.workShopName = value; }
		}
		private string workShopName;
		
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
		///备注
		///</summary>
		public string Remark
		{
			get { return Convert.ToString(_context.Request["Remark"]);}
			set { this.remark = value; }
		}
		private string remark;
		
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
