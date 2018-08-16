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
	public class UserParm
	{
		private HttpContext _context;
		public UserParm(HttpContext context)
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
		///用户ID
		///</summary>
		public Guid UserID
		{
			get { return Guid.Parse(_context.Request["UserID"]);}
			set { this.userID = value; }
		}
		private Guid userID;
		
		///<summary>
		///用户编号
		///</summary>
		public string UserCode
		{
			get { return Convert.ToString(_context.Request["UserCode"]);}
			set { this.userCode = value; }
		}
		private string userCode;
		
		///<summary>
		///姓名
		///</summary>
		public string UserName
		{
			get { return Convert.ToString(_context.Request["UserName"]);}
			set { this.userName = value; }
		}
		private string userName;
		
		///<summary>
		///
		///</summary>
		public Guid DepartmentID
		{
			get { return Guid.Parse(_context.Request["DepartmentID"]);}
			set { this.departmentID = value; }
		}
		private Guid departmentID;
		
		///<summary>
		///性别
		///</summary>
		public string Sex
		{
			get { return Convert.ToString(_context.Request["Sex"]);}
			set { this.sex = value; }
		}
		private string sex;
		
		///<summary>
		///职位
		///</summary>
		public string Position
		{
			get { return Convert.ToString(_context.Request["Position"]);}
			set { this.position = value; }
		}
		private string position;
		
		///<summary>
		///电子邮件
		///</summary>
		public string Email
		{
			get { return Convert.ToString(_context.Request["Email"]);}
			set { this.email = value; }
		}
		private string email;
		
		///<summary>
		///移动电话
		///</summary>
		public string Mobile
		{
			get { return Convert.ToString(_context.Request["Mobile"]);}
			set { this.mobile = value; }
		}
		private string mobile;
		
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
		///证件号码
		///</summary>
		public string IDNumber
		{
			get { return Convert.ToString(_context.Request["IDNumber"]);}
			set { this.iDNumber = value; }
		}
		private string iDNumber;
		
		///<summary>
		///登录密码
		///</summary>
		public string Password
		{
			get { return Convert.ToString(_context.Request["Password"]);}
			set { this.password = value; }
		}
		private string password;
		
		///<summary>
		///登录错误的次数
		///</summary>
		public int LoginErrorCount
		{
			get { return Convert.ToInt32(_context.Request["LoginErrorCount"]);}
			set { this.loginErrorCount = value; }
		}
		private int loginErrorCount;
		
		///<summary>
		///最后一次登录时间
		///</summary>
		public DateTime LastLoginTime
		{
			get { return  Convert.ToDateTime(_context.Request["LastLoginTime"]);}
			set { this.lastLoginTime = value; }
		}
		private DateTime lastLoginTime;
		
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
		///是否锁定
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
