using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Model
{
    [Serializable]
    public class UploadToken
    {
        public string name { get; set; }
        public long size { get; set; }
        public string token { get; set; }

        public long upsize { get; set; }

        public string filePath { get; set; }
        public string modified { get; set; }
    }

    public class UploadResult
    {
        public string message { get; set; }
        public long start { get; set; }
        public bool success { get; set; }
        public string filePath { get; set; }
    }

    public class TokenResult
    {
        public string message { get; set; }
        public string token { get; set; }
        public bool success { get; set; }
    }

    public class filemodel
    {
        public string id { get; set; }
        public string filePath { get; set; }
    }
}
