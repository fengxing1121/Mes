using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Model
{
    public class ResponseResult
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonProperty(PropertyName = "returncode")]
        public int ReturnCode { set; get; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        [JsonProperty(PropertyName = "returnmsg")]
        public string ReturnMsg { set; get; }

        /// <summary>
        /// josn数据对像
        /// </summary>
        [JsonProperty(PropertyName = "jsonobj")]
        public string JsonObj { set; get; }
    }
}
