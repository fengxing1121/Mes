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
	[DataContract(Name = "SolutionFile")]
	public class SolutionFile
	{
		public SolutionFile()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "FileID")]
		public Guid FileID
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
		///柜子ID
		/// </summary>
		[DataMember(Name = "SourceID")]
		public Guid SourceID
		{
			get;
			set;
		}
		
		/// <summary>
		///文件类型，S：解决方案文件； C：单个产品方案文件
		/// </summary>
		[DataMember(Name = "SourceType")]
		public string SourceType
		{
			get;
			set;
		}
		
		/// <summary>
		///文件名
		/// </summary>
		[DataMember(Name = "FileName")]
		public string FileName
		{
			get;
			set;
		}
		
		/// <summary>
		///文件存储路径
		/// </summary>
		[DataMember(Name = "FileUrl")]
		public string FileUrl
		{
			get;
			set;
		}
		
		/// <summary>
		///状态：N，未拆单，F：已拆单
		/// </summary>
		[DataMember(Name = "Status")]
		public string Status
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
