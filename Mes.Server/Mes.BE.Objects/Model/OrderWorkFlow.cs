using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:59。
	/// </summary>
	[Serializable]
	[DataContract(Name = "OrderWorkFlow")]
	public class OrderWorkFlow
	{
		public OrderWorkFlow()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "WorkingID")]
		public Guid WorkingID
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
        [DataMember(Name = "BatchNum")]
        public string BatchNum
        {
            get;
            set;
        }

        /// <summary>
        ///板件ID
        /// </summary>
        [DataMember(Name = "ItemID")]
		public Guid ItemID
		{
			get;
			set;
		}
		
		/// <summary>
		///工序ID
		/// </summary>
		[DataMember(Name = "WorkFlowNo")]
		public int WorkFlowNo
		{
			get;
			set;
		}
		
		/// <summary>
		///发起工序
		/// </summary>
		[DataMember(Name = "SourceWorkFlowID")]
		public Guid SourceWorkFlowID
		{
			get;
			set;
		}
		
		/// <summary>
		///动作
		/// </summary>
		[DataMember(Name = "Action")]
		public string Action
		{
			get;
			set;
		}

        /// <summary>
        /// 扫描时间
        /// </summary>
        public string Processed
        {
            get;
            set;
        }
        
        /// <summary>
        ///目标工序
        /// </summary>
        [DataMember(Name = "TargetWorkFlowID")]
		public Guid TargetWorkFlowID
		{
			get;
			set;
		}
		
		/// <summary>
		///生产总数量
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
		[DataMember(Name = "MadeQty")]
		public int MadeQty
		{
			get;
			set;
		}
	}
}
