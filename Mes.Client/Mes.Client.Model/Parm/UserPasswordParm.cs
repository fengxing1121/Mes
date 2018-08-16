using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Web;


namespace Mes.Client.Model.Parm
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2016-10-18 16:58:02。
	/// </summary>
	public class UserPasswordParm
	{
		private HttpContext _context;
		public UserPasswordParm(HttpContext context)
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
		///密码
		///</summary>
		public string Password
		{
			get { return Convert.ToString(_context.Request["Password"]);}
			set { this.password = value; }
		}
		private string password;
		
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
