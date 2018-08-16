using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:55。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Favorite")]
	public class Favorite
	{
		public Favorite()
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
		[DataMember(Name = "PrivilegeID")]
		public Guid PrivilegeID
		{
			get;
			set;
		}
	}
}
