using Mes.Client.Service.BE;
using System;
using System.Collections.Generic;

namespace Mes.Client.Model.Pages
{
    [Serializable]
    public class SessionUser
    {
        public SessionUser()
        {
            this.UserID = Guid.Empty;
            this.PartnerID = Guid.Empty;
            this.LoginUrl = "";
            this.UserCode = "";
            this.UserName = "";
            this.UserType = -1;
            this.Mobile = "";
            this.IDNumber = "";
            this.Roles = new List<Role>();
            this.PrivilegeItemIDs = new List<Guid>();
            this.PrivilegeIDs = new List<Guid>();
            this.DepartmentID = Guid.Empty;
            this.Position = "";

            this.PasswordExpired = false;
            this.PrivilegeCodes = new Dictionary<string, List<string>>();
            this.IP = "";
            this.HostName = "";

            this.CompanyID = Guid.Empty;
            this.PID = "";
            this.Key="";
            this.APPSECRET="";
            this.IsSystemUser = false;
            this.LastLoginTime = DateTime.MinValue;
            this.IsFinishInfo = false;
            this.HeadNum = new Random().Next(1, 99);
            this.Sex = "";
            this.Email = "";
        }
        public Guid UserID { get; set; }
        public Guid PartnerID { get; set;}
        public string LoginUrl{ get;set;}
        public string UserCode { get; set;}
        public string Mobile { get; set; }      
        public string UserName { get; set; }
        public int UserType { get; set; }
        public string IDNumber { get; set; }
        public List<Role> Roles { get; set; }
        public List<Guid> PrivilegeIDs { get; set; }
        public Guid DepartmentID { get; set; }
        public Dictionary<string, List<string>> PrivilegeCodes { get; set; }
        public List<Guid> PrivilegeItemIDs { get; set; }        
        public bool PasswordExpired { get; set; }
        public string IP { get; set; }
        public string HostName { get; set; }
        public string MacAddress { get; set; }
        public Guid CompanyID { get; set; }
        public string PID { get; set; }
        public string Key { get; set; }
        public string APPSECRET { get; set; }
        public bool IsSystemUser { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string Position { get; set; }
        public bool IsFinishInfo { get; set; }
        public int HeadNum { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
    }
}
