using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mes.Package.Common
{
    
    [Serializable]
    public class OnlineUser
    {
        public OnlineUser()
        {
            this.UserID = Guid.Empty;
            this.CompanyID = Guid.Empty;
            this.UserName = "";
            this.UserCode = "";               
        }
        public Guid CompanyID { get; set; }
        public Guid UserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }           
    }
}
