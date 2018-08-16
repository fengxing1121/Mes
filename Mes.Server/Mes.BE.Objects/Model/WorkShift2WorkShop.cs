using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:07。
	/// </summary>
	[Serializable]
	[DataContract(Name = "WorkShift2WorkShop")]
	public class WorkShift2WorkShop
	{
		public WorkShift2WorkShop()
		{
		}
		
		/// <summary>
		///班组ID
		/// </summary>
		[DataMember(Name = "WorkShiftID")]
		public Guid WorkShiftID
		{
			get;
			set;
		}
		
		/// <summary>
		///车间ID
		/// </summary>
		[DataMember(Name = "WorkShopID")]
		public Guid WorkShopID
		{
			get;
			set;
		}
	}
}
