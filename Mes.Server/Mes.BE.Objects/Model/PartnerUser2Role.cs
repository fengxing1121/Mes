using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-08-28 10:00:11。
	/// </summary>
	[Serializable]
	[DataContract(Name = "PartnerUser2Role")]
	public class PartnerUser2Role
	{
		public PartnerUser2Role()
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
