using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:25:03。
	/// </summary>
	[Serializable]
	[DataContract(Name = "SysLog")]
	public class SysLog
	{
		public SysLog()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "LogID")]
		public Guid LogID
		{
			get;
			set;
		}		
		
		/// <summary>
		///日志类型
		/// </summary>
		[DataMember(Name = "LogType")]
		public string LogType
		{
			get;
			set;
		}
		
		/// <summary>
		///来源ID
		/// </summary>
		[DataMember(Name = "SourceID")]
		public Guid SourceID
		{
			get;
			set;
		}
		
		/// <summary>
		///操作用户
		/// </summary>
		[DataMember(Name = "UserCode")]
		public string UserCode
		{
			get;
			set;
		}
		
		/// <summary>
		///日志描述
		/// </summary>
		[DataMember(Name = "Remark")]
		public string Remark
		{
			get;
			set;
		}
		
		/// <summary>
		///来源页面
		/// </summary>
		[DataMember(Name = "URL")]
		public string URL
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Mehtod")]
		public string Mehtod
		{
			get;
			set;
		}
		
		/// <summary>
		///来源IP
		/// </summary>
		[DataMember(Name = "IP")]
		public string IP
		{
			get;
			set;
		}
		
		/// <summary>
		///日志时间
		/// </summary>
		[DataMember(Name = "Created")]
		public DateTime Created
		{
			get;
			set;
		}
	}
}
