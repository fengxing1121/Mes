using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:56。
	/// </summary>
	[Serializable]
	[DataContract(Name = "LogisticsEnterprise")]
	public class LogisticsEnterprise
	{
		public LogisticsEnterprise()
		{
		}
		
		/// <summary>
		///企业ID
		/// </summary>
		[DataMember(Name = "EnterpriseID")]
		public Guid EnterpriseID
		{
			get;
			set;
		}
		
		/// <summary>
		///物流公司名称
		/// </summary>
		[DataMember(Name = "EnterpriseName")]
		public string EnterpriseName
		{
			get;
			set;
		}
		
		/// <summary>
		///地址
		/// </summary>
		[DataMember(Name = "Address")]
		public string Address
		{
			get;
			set;
		}
		
		/// <summary>
		///联系人
		/// </summary>
		[DataMember(Name = "LinkMan")]
		public string LinkMan
		{
			get;
			set;
		}
		
		/// <summary>
		///联系手机
		/// </summary>
		[DataMember(Name = "Mobile")]
		public string Mobile
		{
			get;
			set;
		}
		
		/// <summary>
		///固定电话
		/// </summary>
		[DataMember(Name = "Tel")]
		public string Tel
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
