using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:55。
	/// </summary>
	[Serializable]
	[DataContract(Name = "CustomerFollowUp")]
	public class CustomerFollowUp
	{
		public CustomerFollowUp()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "FollowID")]
		public Guid FollowID
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
		///跟进方式,D：直接登门；V：邀约登门；T：电话跟进，M：手机短信；，O：其他
		/// </summary>
		[DataMember(Name = "FollowType")]
		public string FollowType
		{
			get;
			set;
		}
		
		/// <summary>
		///跟进主题
		/// </summary>
		[DataMember(Name = "Title")]
		public string Title
		{
			get;
			set;
		}
		
		/// <summary>
		///跟进内容
		/// </summary>
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///重要信息及结果
		/// </summary>
		[DataMember(Name = "ImportantResult")]
		public string ImportantResult
		{
			get;
			set;
		}
		
		/// <summary>
		///建议及应对策略
		/// </summary>
		[DataMember(Name = "Suggest")]
		public string Suggest
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
