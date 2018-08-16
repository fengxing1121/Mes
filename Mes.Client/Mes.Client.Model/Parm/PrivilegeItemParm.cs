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
	public class PrivilegeItemParm
	{
		private HttpContext _context;
		public PrivilegeItemParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///模块项ID
		///</summary>
		public Guid PrivilegeItemID
		{
			get { return Guid.Parse(_context.Request["PrivilegeItemID"]);}
			set { this.privilegeItemID = value; }
		}
		private Guid privilegeItemID;
		
		
		///<summary>
		///模块ID
		///</summary>
		public Guid PrivilegeID
		{
			get { return Guid.Parse(_context.Request["PrivilegeID"]);}
			set { this.privilegeID = value; }
		}
		private Guid privilegeID;
		
		///<summary>
		///模块项的名称
		///</summary>
		public string PrivilegeItemName
		{
			get { return Convert.ToString(_context.Request["PrivilegeItemName"]);}
			set { this.privilegeItemName = value; }
		}
		private string privilegeItemName;
		
		///<summary>
		///模块项的编码
		///</summary>
		public string PrivilegeItemCode
		{
			get { return Convert.ToString(_context.Request["PrivilegeItemCode"]);}
			set { this.privilegeItemCode = value; }
		}
		private string privilegeItemCode;
		
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
