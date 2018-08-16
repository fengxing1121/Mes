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
	[DataContract(Name = "KeyValue")]
	public class KeyValue
	{
		public KeyValue()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Key")]
		public string Key
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Value")]
		public string Value
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
	}
}
