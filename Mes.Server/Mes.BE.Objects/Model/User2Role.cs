using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:04。
	/// </summary>
	[Serializable]
	[DataContract(Name = "User2Role")]
	public class User2Role
	{
		public User2Role()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "UserID")]
		public Guid UserID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "RoleID")]
		public Guid RoleID
		{
			get;
			set;
		}
	}
}
