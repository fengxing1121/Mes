using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:57:58。
	/// </summary>
	public class DepartmentParm
	{
		private HttpContext _context;
		public DepartmentParm(HttpContext context)
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
		///部门ID
		///</summary>
		public Guid DepartmentID
		{
			get { return Guid.Parse(_context.Request["DepartmentID"]);}
			set { this.departmentID = value; }
		}
		private Guid departmentID;
		
		///<summary>
		///门店编号
		///</summary>
		public string DepartmentCode
		{
			get { return Convert.ToString(_context.Request["DepartmentCode"]);}
			set { this.departmentCode = value; }
		}
		private string departmentCode;
		
		///<summary>
		///部门名称
		///</summary>
		public string DepartmentName
		{
			get { return Convert.ToString(_context.Request["DepartmentName"]);}
			set { this.departmentName = value; }
		}
		private string departmentName;
		
		///<summary>
		///部门电话
		///</summary>
		public string Tel
		{
			get { return Convert.ToString(_context.Request["Tel"]);}
			set { this.tel = value; }
		}
		private string tel;
		
		///<summary>
		///部门传真
		///</summary>
		public string Fax
		{
			get { return Convert.ToString(_context.Request["Fax"]);}
			set { this.fax = value; }
		}
		private string fax;
		
		///<summary>
		///禁用标志
		///</summary>
		public bool IsDisabled
		{
			get { return Convert.ToBoolean(_context.Request["IsDisabled"]);}
			set { this.isDisabled = value; }
		}
		private bool isDisabled;
		
		///<summary>
		///描述
		///</summary>
		public string Description
		{
			get { return Convert.ToString(_context.Request["Description"]);}
			set { this.description = value; }
		}
		private string description;
		
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
