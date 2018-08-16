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
	[DataContract(Name = "WorkCenterScheduling")]
	public class WorkCenterScheduling
	{
		public WorkCenterScheduling()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "WorkID")]
		public Guid WorkID
		{
			get;
			set;
		}
		
		/// <summary>
		///设备ID
		/// </summary>
		[DataMember(Name = "WorkCenterID")]
		public Guid WorkCenterID
		{
			get;
			set;
		}
		
		/// <summary>
		///批次号
		/// </summary>
		[DataMember(Name = "BattchNum")]
		public string BattchNum
		{
			get;
			set;
		}
		
		/// <summary>
		///预计生产时间
		/// </summary>
		[DataMember(Name = "Started")]
		public DateTime Started
		{
			get;
			set;
		}
		
		/// <summary>
		///结束时间
		/// </summary>
		[DataMember(Name = "Ended")]
		public DateTime Ended
		{
			get;
			set;
		}
		
		/// <summary>
		///状态(N：等 待；P：生产中；F：完成，C：取消）
		/// </summary>
		[DataMember(Name = "Status")]
		public string Status
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Modified")]
		public DateTime Modified
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "ModifiedBy")]
		public string ModifiedBy
		{
			get;
			set;
		}
	}
}
