using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-09-23 11:29:10。
	/// </summary>
	[Serializable]
	[DataContract(Name = "OrderScheduling")]
	public class OrderScheduling
	{
		public OrderScheduling()
		{
		}
		
		/// <summary>
		///排产ID
		/// </summary>
		[DataMember(Name = "MadeID")]
		public Guid MadeID
		{
			get;
			set;
		}
		
		/// <summary>
		///订单ID
		/// </summary>
		[DataMember(Name = "OrderID")]
		public Guid OrderID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CabinetID")]
		public Guid CabinetID
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
        ///批次号
        /// </summary>
        [DataMember(Name = "BatchNum")]
        public string BatchNum
        {
            get;
            set;
        }

        /// <summary>
        ///工序ID
        /// </summary>
        [DataMember(Name = "WorkFlowID")]
		public Guid WorkFlowID
		{
			get;
			set;
		}
		
		/// <summary>
		///工序部件总数量
		/// </summary>
		[DataMember(Name = "TotalQty")]
		public int TotalQty
		{
			get;
			set;
		}
		
		/// <summary>
		///已生产数量
		/// </summary>
		[DataMember(Name = "MadeTotalQty")]
		public int MadeTotalQty
		{
			get;
			set;
		}
		
		/// <summary>
		///工序部件总面积
		/// </summary>
		[DataMember(Name = "TotalAreal")]
		public decimal TotalAreal
		{
			get;
			set;
		}
		
		/// <summary>
		///已生产面积
		/// </summary>
		[DataMember(Name = "MadeTotalAreal")]
		public decimal MadeTotalAreal
		{
			get;
			set;
		}
		
		/// <summary>
		///工序部件总长度
		/// </summary>
		[DataMember(Name = "TotalLength")]
		public decimal TotalLength
		{
			get;
			set;
		}
		
		/// <summary>
		///已生产总长度
		/// </summary>
		[DataMember(Name = "MadeTotalLength")]
		public decimal MadeTotalLength
		{
			get;
			set;
		}
		
		/// <summary>
		///预计生产结束时间
		/// </summary>
		[DataMember(Name = "Estimated")]
		public DateTime Estimated
		{
			get;
			set;
		}
		
		/// <summary>
		///实际生产日期
		/// </summary>
		[DataMember(Name = "MadeStarted")]
		public DateTime MadeStarted
		{
			get;
			set;
		}
		
		/// <summary>
		///生产结束时间
		/// </summary>
		[DataMember(Name = "MadeEnded")]
		public DateTime MadeEnded
		{
			get;
			set;
		}
		
		/// <summary>
		///预计生产时长
		/// </summary>
		[DataMember(Name = "ProductionPeriod")]
		public decimal ProductionPeriod
		{
			get;
			set;
		}
		
		/// <summary>
		///序号
		/// </summary>
		[DataMember(Name = "Sequence")]
		public int Sequence
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
