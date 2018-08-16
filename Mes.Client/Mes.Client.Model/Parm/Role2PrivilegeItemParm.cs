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
	public class Role2PrivilegeItemParm
	{
		private HttpContext _context;
		public Role2PrivilegeItemParm(HttpContext context)
		{
			this._context = context;
		}
		
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
		///模块项ID
		///</summary>
		public Guid PrivilegeItemID
		{
			get { return Guid.Parse(_context.Request["PrivilegeItemID"]);}
			set { this.privilegeItemID = value; }
		}
		private Guid privilegeItemID;
	}
}
