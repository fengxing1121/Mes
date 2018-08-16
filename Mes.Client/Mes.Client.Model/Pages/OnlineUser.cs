using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Mes.Client.Model.Pages
{
    [Serializable]
    public class OnlineUser
    {
        public OnlineUser()
        {
        }
        public Guid UserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }
        public string LoginIP { get; set; }
        public DateTime LoginTime { get; set; }
        public string MacAddress { get; set; }
        public string IDNumber { get; set; }      
        public string AppCode { get; set; }
        private static Dictionary<Guid, OnlineUser> onlineUsers = new Dictionary<Guid, OnlineUser>();
        public static bool Lock(SessionUser user)
        {
            lock (onlineUsers)
            {
                OnlineUser ou = null;
                if (onlineUsers.TryGetValue(user.UserID, out ou))
                {
                    if (ou.LoginIP.ToLower() == user.IP.ToLower())
                    {
                        ou.LoginTime = DateTime.Now;
                        return true;
                    }
                    else
                    {
                        ou.LoginIP = user.IP;
                        ou.LoginTime = DateTime.Now;
                        return true;
                    }
                }
                ou = new OnlineUser();
                ou.UserID = user.UserID;
                ou.UserCode = user.UserCode;
                ou.UserType = user.UserType;
                ou.UserName = user.UserName;
                ou.LoginIP = user.IP;
                ou.LoginTime = DateTime.Now;
                ou.MacAddress = "";
                ou.IDNumber = user.IDNumber;
                onlineUsers.Add(user.UserID, ou);
                return true;
            }
        }       
        public static void Unlock(Guid id)
        {
            lock (onlineUsers)
            {
                if (onlineUsers.ContainsKey(id))
                {
                    onlineUsers.Remove(id);
                }
            }
        }
        public static DataTable Search(string key)
        {
            List<OnlineUser> oUsers = new List<OnlineUser>();
            lock (onlineUsers)
            {
                foreach (OnlineUser iou in onlineUsers.Values)
                {
                    if (key == null || iou.UserID.ToString().ToLower().Contains(key.ToLower())
                                    || iou.UserCode.ToLower().Contains(key.ToLower())
                                    || iou.UserName.ToLower().Contains(key.ToLower())
                                    || iou.LoginIP.ToLower().Contains(key.ToLower())
                                    || iou.IDNumber.ToLower().Contains(key.ToLower()))
                    {
                        OnlineUser oUser = new OnlineUser();
                        oUser.UserID = iou.UserID;
                        oUser.UserCode = iou.UserCode;
                        oUser.UserName = iou.UserName;
                        oUser.LoginIP = iou.LoginIP;
                        oUser.LoginTime = iou.LoginTime;
                        oUser.MacAddress = iou.MacAddress;
                        oUser.IDNumber = iou.IDNumber;                       
                        oUsers.Add(oUser);
                    }
                }
            }
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(Guid)));
            dt.Columns.Add(new DataColumn("UserCode", typeof(string)));
            dt.Columns.Add(new DataColumn("UserName", typeof(string)));
            dt.Columns.Add(new DataColumn("LoginIP", typeof(string)));
            dt.Columns.Add(new DataColumn("MacAddress", typeof(string)));
            dt.Columns.Add(new DataColumn("LoginTime", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("IDNumber", typeof(string)));            
            foreach (OnlineUser oUser in oUsers)
            {
                DataRow dr = dt.NewRow();
                dr[0] = oUser.UserID;
                dr[1] = oUser.UserCode;
                dr[2] = oUser.UserName;
                dr[3] = oUser.LoginIP;
                dr[4] = oUser.MacAddress;
                dr[5] = oUser.LoginTime;
                dr[6] = oUser.IDNumber;               
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public static OnlineUser GetOnlineUser(Guid id)
        {
            lock (onlineUsers)
            {
                OnlineUser ou = null;
                if (onlineUsers.TryGetValue(id, out ou))
                    return ou;

                return null;
            }
        }
    }
}
