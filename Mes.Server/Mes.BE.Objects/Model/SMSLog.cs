using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

using MES.Libraries;

namespace Mes.BE.Objects
{
    /// <summary>
    /// 代码工具生成，不可以手工修改。2017-05-17 15:25:01。
    /// </summary>
    [Serializable]
    [DataContract(Name = "SMSLog")]
    public class SMSLog
    {
        public SMSLog()
        {
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "ID")]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Phone")]
        public string Phone
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
        [DataMember(Name = "Created")]
        public DateTime Created
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        [DataMember(Name = "Status")]
        public bool Status
        {
            get;
            set;
        }
    }
}
