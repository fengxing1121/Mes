using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:06。
	/// </summary>
	[Serializable]
	[DataContract(Name = "WorkShift")]
	public class WorkShift
	{
		public WorkShift()
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
		///班组编号
		/// </summary>
		[DataMember(Name = "WorkShiftCode")]
		public string WorkShiftCode
		{
			get;
			set;
		}
		
		/// <summary>
		///班组名称
		/// </summary>
		[DataMember(Name = "WorkShiftName")]
		public string WorkShiftName
		{
			get;
			set;
		}
		
		/// <summary>
		///上班时间
		/// </summary>
		[DataMember(Name = "Started")]
		public string Started
		{
			get;
			set;
		}
		
		/// <summary>
		///下班时间
		/// </summary>
		[DataMember(Name = "Ended")]
		public string Ended
		{
			get;
			set;
		}
		
		/// <summary>
		///创建时间
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///创建人
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
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
