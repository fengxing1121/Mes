using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-17 15:24:58。
	/// </summary>
	[Serializable]
	[DataContract(Name = "OrderProcessFile")]
	public class OrderProcessFile
	{
		public OrderProcessFile()
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
		///文件类型（BOM文件\五金文件\加工后置文件\效果图)
		/// </summary>
		[DataMember(Name = "FileType")]
		public string FileType
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "Tag")]
		public string Tag
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "OrderID")]
		public Guid OrderID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "CabinetID")]
		public Guid CabinetID
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "FileName")]
		public string FileName
		{
			get;
			set;
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "FilePath")]
		public string FilePath
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
