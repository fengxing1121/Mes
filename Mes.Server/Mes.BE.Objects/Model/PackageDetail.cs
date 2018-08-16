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
	[DataContract(Name = "PackageDetail")]
	public class PackageDetail
	{
		public PackageDetail()
		{
		}

        /// <summary>
        ///是否已包装
        /// </summary>
        [DataMember(Name = "IsPakaged")]
        public bool IsPakaged
        {
            get;
            set;
        }
        /// <summary>
        ///板件唯一ID
        /// </summary>
        [DataMember(Name = "DetailID")]
		public Guid DetailID
		{
			get;
			set;
		}
		
		/// <summary>
		///生产批次号
		/// </summary>
		[DataMember(Name = "BattchNo")]
		public string BattchNo
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
		///数量
		/// </summary>
		[DataMember(Name = "Qty")]
		public int Qty
		{
			get;
			set;
		}
		
		/// <summary>
		///包号ID
		/// </summary>
		[DataMember(Name = "PakageID")]
		public Guid PakageID
		{
			get;
			set;
		}
		
		/// <summary>
		///所在层
		/// </summary>
		[DataMember(Name = "LayerNum")]
		public int LayerNum
		{
			get;
			set;
		}
		
		/// <summary>
		///是否已包装
		/// </summary>
		[DataMember(Name = "IsPackaged")]
		public bool IsPackaged
		{
			get;
			set;
		}
		
		/// <summary>
		///是否已优化排版
		/// </summary>
		[DataMember(Name = "IsOptimized")]
		public bool IsOptimized
		{
			get;
			set;
		}
		
		/// <summary>
		///是否已经排产
		/// </summary>
		[DataMember(Name = "IsPlanning")]
		public bool IsPlanning
		{
			get;
			set;
		}
		
		/// <summary>
		///是否取消（损坏）
		/// </summary>
		[DataMember(Name = "IsDisabled")]
		public bool IsDisabled
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CheckedBy")]
		public string CheckedBy
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
