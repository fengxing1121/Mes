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
	public class PrivilegeParm
	{
		private HttpContext _context;
		public PrivilegeParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///权限id
		///</summary>
		public Guid PrivilegeID
		{
			get { return Guid.Parse(_context.Request["PrivilegeID"]);}
			set { this.privilegeID = value; }
		}
		private Guid privilegeID;
		
		///<summary>
		///
		///</summary>
		public Guid CategoryID
		{
			get { return Guid.Parse(_context.Request["CategoryID"]);}
			set { this.categoryID = value; }
		}
		private Guid categoryID;
		
		///<summary>
		///权限名称
		///</summary>
		public string PrivilegeName
		{
			get { return Convert.ToString(_context.Request["PrivilegeName"]);}
			set { this.privilegeName = value; }
		}
		private string privilegeName;
		
		///<summary>
		///权限编码
		///</summary>
		public string PrivilegeCode
		{
			get { return Convert.ToString(_context.Request["PrivilegeCode"]);}
			set { this.privilegeCode = value; }
		}
		private string privilegeCode;
		
		///<summary>
		///页面
		///</summary>
		public string PageURL
		{
			get { return Convert.ToString(_context.Request["PageURL"]);}
			set { this.pageURL = value; }
		}
		private string pageURL;
		
		///<summary>
		///
		///</summary>
		public string IconClass
		{
			get { return Convert.ToString(_context.Request["IconClass"]);}
			set { this.iconClass = value; }
		}
		private string iconClass;
		
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
		///是否禁用
		///</summary>
		public bool IsDisabled
		{
			get { return Convert.ToBoolean(_context.Request["IsDisabled"]);}
			set { this.isDisabled = value; }
		}
		private bool isDisabled;
		
		///<summary>
		///排序编号
		///</summary>
		public int Sequence
		{
			get { return Convert.ToInt32(_context.Request["Sequence"]);}
			set { this.sequence = value; }
		}
		private int sequence;
		
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
