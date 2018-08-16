using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-08-28 10:41:50。
	/// </summary>
	[Serializable]
	[DataContract(Name = "PartnerUserPassword")]
	public class PartnerUserPassword
	{
		public PartnerUserPassword()
		{
		}
		
		/// <summary>
		///用户ID
		/// </summary>
		[DataMember(Name = "UserID")]
		public Guid UserID
		{
			get;
			set;
		}
		
		/// <summary>
		///密码
		/// </summary>
		[DataMember(Name = "Password")]
		public string Password
		{
			get;
			set;
		}
		
		/// <summary>
		///修改时间
		/// </summary>
		[DataMember(Name = "Modified")]
		public DateTime Modified
		{
			get;
			set;
		}
		
		/// <summary>
		///修改人
		/// </summary>
		[DataMember(Name = "ModifiedBy")]
		public string ModifiedBy
		{
			get;
			set;
		}
	}
}
