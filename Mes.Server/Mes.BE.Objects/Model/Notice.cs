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
	[DataContract(Name = "Notice")]
	public class Notice
	{
		public Notice()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "NoticeID")]
		public Guid NoticeID
		{
			get;
			set;
		}
		
		/// <summary>
		///消息类型,S：系统消息；O：订单消息；A：系统公告；T：优惠消息；
		/// </summary>
		[DataMember(Name = "NoticeType")]
		public string NoticeType
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "SourceURL")]
		public string SourceURL
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "TargetID")]
		public Guid TargetID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Message")]
		public string Message
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "NoticeTime")]
		public DateTime NoticeTime
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "IsNoticeOnSMS")]
		public bool IsNoticeOnSMS
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "IsNoticeOnEmail")]
		public bool IsNoticeOnEmail
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "IsRead")]
		public bool IsRead
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
	}
}
