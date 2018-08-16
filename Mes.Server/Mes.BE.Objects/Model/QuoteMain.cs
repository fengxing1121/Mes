using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-08-15 11:45:55。
	/// </summary>
	[Serializable]
	[DataContract(Name = "QuoteMain")]
	public class QuoteMain
	{
		public QuoteMain()
		{
		}

        /// <summary>
        ///合作商ID
        /// </summary>
        [DataMember(Name = "PartnerID")]
        public Guid PartnerID
        {
            get;
            set;
        }

		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "QuoteID")]
		public Guid QuoteID
		{
			get;
			set;
		}
		
		/// <summary>
		///报价单号
		/// </summary>
		[DataMember(Name = "QuoteNo")]
		public string QuoteNo
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "SolutionID")]
		public Guid SolutionID
		{
			get;
			set;
		}
		
		/// <summary>
		///客户
		/// </summary>
		[DataMember(Name = "CustomerID")]
		public Guid CustomerID
		{
			get;
			set;
		}
		
		/// <summary>
		///失效日期
		/// </summary>
		[DataMember(Name = "ExpiryDate")]
		public DateTime ExpiryDate
		{
			get;
			set;
		}
		
		/// <summary>
		///折扣百分比
		/// </summary>
		[DataMember(Name = "DiscountPercent")]
		public decimal DiscountPercent
		{
			get;
			set;
		}
		
		/// <summary>
		///订单总金额(折扣前)
		/// </summary>
		[DataMember(Name = "TotalAmount")]
		public decimal TotalAmount
		{
			get;
			set;
		}
		
		/// <summary>
		///折扣金额
		/// </summary>
		[DataMember(Name = "DiscountAmount")]
		public decimal DiscountAmount
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///报价单状态，N:确认中,F:已确认,C:已取消
		/// </summary>
		[DataMember(Name = "Status")]
		public string Status
		{
			get;
			set;
		}
		
		/// <summary>
		///报价日期
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
		
		/// <summary>
		///报价人
		/// </summary>
		[DataMember(Name = "CreatedBy")]
		public string CreatedBy
		{
			get;
			set;
		}
		
		/// <summary>
		///修改日期
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
        /// <summary>
        ///修改人刘耀方
        /// </summary>
        [DataMember(Name = "SolutionCode")]
        public string SolutionCode
        {
            get;
            set;
        }
        /// <summary>
        ///修改人刘耀方
        /// </summary>
        [DataMember(Name = "DesignerNo")]
        public string DesignerNo
        {
            get;
            set;
        }
    }
}
