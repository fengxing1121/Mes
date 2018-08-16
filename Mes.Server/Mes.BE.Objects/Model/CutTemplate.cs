using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
	/// <summary>
	/// 代码工具生成，不可以手工修改。2017-05-26 16:45:36。
	/// </summary>
	[Serializable]
	[DataContract(Name = "CutTemplate")]
	public class CutTemplate
	{
		public CutTemplate()
		{
		}
		
		/// <summary>
		///
		/// </summary>
		[DataMember(Name = "TemplateID")]
		public Guid TemplateID
		{
			get;
			set;
		}
		
		/// <summary>
		///模板代码
		/// </summary>
		[DataMember(Name = "TemplateCode")]
		public string TemplateCode
		{
			get;
			set;
		}
		
		/// <summary>
		///模板名称
		/// </summary>
		[DataMember(Name = "TemplateName")]
		public string TemplateName
		{
			get;
			set;
		}
		
		/// <summary>
		///锯鏠
		/// </summary>
		[DataMember(Name = "Saw")]
		public decimal Saw
		{
			get;
			set;
		}
		
		/// <summary>
		///再次修边
		/// </summary>
		[DataMember(Name = "TrimZ")]
		public decimal TrimZ
		{
			get;
			set;
		}
		
		/// <summary>
		///裁切高度
		/// </summary>
		[DataMember(Name = "PackageHeight")]
		public decimal PackageHeight
		{
			get;
			set;
		}
		
		/// <summary>
		///转向次数限制
		/// </summary>
		[DataMember(Name = "MaxTurns")]
		public decimal MaxTurns
		{
			get;
			set;
		}
		
		/// <summary>
		///最小板宽
		/// </summary>
		[DataMember(Name = "MinWidthBand")]
		public decimal MinWidthBand
		{
			get;
			set;
		}
		
		/// <summary>
		///最大长度
		/// </summary>
		[DataMember(Name = "MaxLengthBand")]
		public decimal MaxLengthBand
		{
			get;
			set;
		}
		
		/// <summary>
		///初始方向的切割0 =任何，1 =长度，2 =宽度，3 =长度最好，4 =宽度最好
		/// </summary>
		[DataMember(Name = "DirectCut")]
		public int DirectCut
		{
			get;
			set;
		}
		
		/// <summary>
		///大板裁切排序 0-降序,1-升序,2-向中间缩小,3-不排序
		/// </summary>
		[DataMember(Name = "SortBy")]
		public int SortBy
		{
			get;
			set;
		}
		
		/// <summary>
		///中间板裁切排序 0-降序,1-升序,2-向中间缩小,3-不排序
		/// </summary>
		[DataMember(Name = "SortInBand")]
		public int SortInBand
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
