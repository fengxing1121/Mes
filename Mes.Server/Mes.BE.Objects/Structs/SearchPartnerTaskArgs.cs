using System;
using System.Collections.Generic;
using System.Text;

namespace Mes.BE.Objects
{
 	[Serializable]
	public struct SearchPartnerTaskArgs
	{
		public string OrderBy;
		public int? RowNumberFrom;
		public int? RowNumberTo;

        /// <summary>
        /// 任务ID
        /// </summary>
        public Guid? TaskID;
        /// <summary>
        /// 步骤名称
        /// </summary>
        public List<string> StepNames;
        /// <summary>
        /// 任务编码
        /// </summary>
        public string TaskNo;
        /// <summary>
        /// 任务类型
        /// </summary>
        public string TaskType;
        /// <summary>
        /// 创建时间From
        /// </summary>
        public DateTime? CreatedFrom;
        /// <summary>
        /// 创建时间To
        /// </summary>
        public DateTime? CreatedTo;
        /// <summary>
        /// 处理任务资源
        /// </summary>
        public string Resource;
        public Guid? ReferenceID;        
        public string EndedBy;
        public Guid? PartnerID;
        public string StepNo;
        public string PartnerIDs;
        public string UserCodes;
        public Guid? CompanyID;
        /// <summary>
        /// 任务步骤
        /// </summary>
	}
}
