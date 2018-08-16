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
	[DataContract(Name = "PartnerRole2PrivilegeItem")]
	public class PartnerRole2PrivilegeItem
	{
		public PartnerRole2PrivilegeItem()
		{
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
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "PrivilegeItemID")]
		public Guid PrivilegeItemID
		{
			get;
			set;
		}
	}
}
