using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-26 17:30:51。
	/// </summary>
	[Serializable]
	[DataContract(Name = "WorkCenter")]
	public class WorkCenter
	{
		public WorkCenter()
		{
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
		///生产车间ID
		/// </summary>
		[DataMember(Name = "WorkShopID")]
		public Guid WorkShopID
		{
			get;
			set;
		}
		
		/// <summary>
		///设备编号
		/// </summary>
		[DataMember(Name = "WorkCenterCode")]
		public string WorkCenterCode
		{
			get;
			set;
		}
		
		/// <summary>
		///设备名称
		/// </summary>
		[DataMember(Name = "WorkCenterName")]
		public string WorkCenterName
		{
			get;
			set;
		}
		
		/// <summary>
		///对应生产工序ID
		/// </summary>
		[DataMember(Name = "WorkFlowID")]
		public Guid WorkFlowID
		{
			get;
			set;
		}
		
		/// <summary>
		///最大产能（小时）
		/// </summary>
		[DataMember(Name = "MaxCapacity")]
		public int MaxCapacity
		{
			get;
			set;
		}
		
		/// <summary>
		///最大产能计算方式
		/// </summary>
		[DataMember(Name = "CountCapacityType")]
		public string CountCapacityType
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Style")]
		public string Style
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Model")]
		public string Model
		{
			get;
			set;
		}
		
		/// <summary>
		///备注
		/// </summary>
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "SettingCode")]
		public string SettingCode
		{
			get;
			set;
		}
		
		/// <summary>
		///排序编号
		/// </summary>
		[DataMember(Name = "Sequence")]
		public int Sequence
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
