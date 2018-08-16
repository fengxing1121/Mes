using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-10-12 11:08:43。
	/// </summary>
	[Serializable]
	[DataContract(Name = "PartnerTaskResource")]
	public class PartnerTaskResource
	{
		public PartnerTaskResource()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "TaskID")]
		public Guid TaskID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Resource")]
		public string Resource
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Request")]
		public string Request
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Started")]
		public DateTime Started
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "StartedBy")]
		public string StartedBy
		{
			get;
			set;
		}
	}
}
