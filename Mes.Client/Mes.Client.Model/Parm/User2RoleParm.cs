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
	public class User2RoleParm
	{
		private HttpContext _context;
		public User2RoleParm(HttpContext context)
		{
			this._context = context;
		}
		
		///<summary>
		///用户ID
		///</summary>
		public Guid UserID
		{
			get { return Guid.Parse(_context.Request["UserID"]);}
			set { this.userID = value; }
		}
		private Guid userID;
		
		///<summary>
		///角色ID
		///</summary>
		public Guid RoleID
		{
			get { return Guid.Parse(_context.Request["RoleID"]);}
			set { this.roleID = value; }
		}
		private Guid roleID;
	}
}
