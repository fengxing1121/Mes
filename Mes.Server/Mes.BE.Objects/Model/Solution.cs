using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:02。
	/// </summary>
	[Serializable]
	[DataContract(Name = "Solution")]
	public class Solution
	{
		public Solution()
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
		///方案ID
		/// </summary>
		[DataMember(Name = "SolutionID")]
		public Guid SolutionID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CustomerID")]
		public Guid CustomerID
		{
			get;
			set;
		}
		
		/// <summary>
		///方案编号
		/// </summary>
		[DataMember(Name = "SolutionCode")]
		public string SolutionCode
		{
			get;
			set;
		}
		
		/// <summary>
		///方案名称
		/// </summary>
		[DataMember(Name = "SolutionName")]
		public string SolutionName
		{
			get;
			set;
		}
		
		/// <summary>
		///方案设计软件:DSC，酷家乐...
		/// </summary>
		[DataMember(Name = "DesignSoft")]
		public string DesignSoft
		{
			get;
			set;
		}
		
		/// <summary>
		///方案描述
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
		[DataMember(Name = "Version")]
		public string Version
		{
			get;
			set;
		}
		
		/// <summary>
		///设计师
		/// </summary>
		[DataMember(Name = "Designer")]
		public string Designer
		{
			get;
			set;
		}
		
		/// <summary>
		///方案状态：N,待上传方案文件；P,待生成报价明细；Q,已报价；F,方案成交；C,已取消；
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
        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "DesignerID")]
        public object DesignerID { get; set; }
    }
}
