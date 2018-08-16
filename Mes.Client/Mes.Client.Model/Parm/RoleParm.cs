using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:01。
	/// </summary>
	public class RoleParm
	{
		private HttpContext _context;
		public RoleParm(HttpContext context)
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
		///角色ID
		///</summary>
		public Guid RoleID
		{
			get { return Guid.Parse(_context.Request["RoleID"]);}
			set { this.roleID = value; }
		}
		private Guid roleID;
		
		///<summary>
		///
		///</summary>
		public Guid GroupID
		{
			get { return Guid.Parse(_context.Request["GroupID"]);}
			set { this.groupID = value; }
		}
		private Guid groupID;
		
		///<summary>
		///名称
		///</summary>
		public string RoleName
		{
			get { return Convert.ToString(_context.Request["RoleName"]);}
			set { this.roleName = value; }
		}
		private string roleName;
		
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
		///禁用标志
		///</summary>
		public bool IsDisabled
		{
			get { return Convert.ToBoolean(_context.Request["IsDisabled"]);}
			set { this.isDisabled = value; }
		}
		private bool isDisabled;
		
		///<summary>
		///锁定标志
		///</summary>
		public bool IsLocked
		{
			get { return Convert.ToBoolean(_context.Request["IsLocked"]);}
			set { this.isLocked = value; }
		}
		private bool isLocked;
		
		///<summary>
		///
		///</summary>
		public bool IsSystem
		{
			get { return Convert.ToBoolean(_context.Request["IsSystem"]);}
			set { this.isSystem = value; }
		}
		private bool isSystem;
		
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
