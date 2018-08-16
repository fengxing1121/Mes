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
	[DataContract(Name = "SpecialCompanent2WorkFlow")]
	public class SpecialCompanent2WorkFlow
	{
		public SpecialCompanent2WorkFlow()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "SpecialDetailID")]
		public Guid SpecialDetailID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "SpecialID")]
		public Guid SpecialID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "WorkFlowID")]
		public Guid WorkFlowID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Sequence")]
		public int Sequence
		{
			get;
			set;
		}
	}
}
