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
    [DataContract(Name = "PartnerTask")]
    public class PartnerTask
    {
        public PartnerTask()
        {
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "PartnerID")]
        public Guid PartnerID
        {
            get;
            set;
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
        [DataMember(Name = "TaskNo")]
        public string TaskNo
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "StepNo")]
        public int StepNo
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "StepName")]
        public string StepName
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "TaskType")]
        public string TaskType
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
        /// <summary>
        ///关联ID
        /// </summary>
        [DataMember(Name = "ReferenceID")]
        public object ReferenceID { get; set; }
    }
}
