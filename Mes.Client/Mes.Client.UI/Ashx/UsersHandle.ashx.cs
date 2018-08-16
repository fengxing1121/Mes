using Mes.Client.Model.Pages;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// UsersHandle 的摘要说明
    /// </summary>
    public class UsersHandle : BaseHttpHandler
    {
        UserParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                parm = new UserParm(context);
                foreach (MethodInfo mi in this.GetType().GetMethods())
                {
                    if (mi.Name.ToLower() == method.ToLower())
                    {
                        mi.Invoke(this, null);
                        break;
                    }
                }
            }
        }

        #region BaseMethod

        /// <summary>
        /// Search User
        /// </summary>
        public void SearchUser()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchUserArgs sargs = new SearchUserArgs();
                    sargs.OrderBy = pagingParm.SortOrder;
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    sargs.IsSystem = false;

                    if (!string.IsNullOrEmpty(parm.UserCode))
                    {
                        List<string> UserCode = new List<string>();
                        UserCode.Add(parm.UserCode);
                        sargs.UserCodes = UserCode;
                    }
                    if (!string.IsNullOrEmpty(parm.UserName))
                    {
                        List<string> UserName = new List<string>();
                        UserName.Add(parm.UserName);
                        sargs.UserNames = UserName;
                    }
                    if (!string.IsNullOrEmpty(Request["IsDisabled"]) && Request["IsDisabled"] != "请选择")
                    {
                        sargs.IsDisabled = Convert.ToBoolean(Request["IsDisabled"]);
                    }

                    if (!string.IsNullOrEmpty(Request["DepartmentID"]) && Request["DepartmentID"] != "请选择")
                    {
                        sargs.DepartmentID = Guid.Parse(Request["DepartmentID"].ToString());
                    }

                    if (!string.IsNullOrEmpty(parm.IDNumber))
                        sargs.IDNumber = parm.IDNumber;
                    if (!string.IsNullOrEmpty(parm.Mobile))
                        sargs.Mobile = parm.Mobile;
                    SearchResult sr = p.Client.SearchUser(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// Save User
        /// </summary>
        public void SaveUser()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    if (Request["DepartmentID"] == "请选择")
                    {
                        throw new Exception("请选择所属部门");
                    }

                    User user = p.Client.GetUser(null, parm.UserID);
                    if (user == null)
                    {
                        user = new User();
                        user.UserID = parm.UserID;
                        user.Created = DateTime.Now;
                        user.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                        user.Modified = DateTime.Now;
                        user.ModifiedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                        user.Password = CEncrypt.EncryptString(UserDefaultPassword);
                    }
                    user.UserCode = parm.UserCode.Trim();
                    user.UserName = parm.UserName.Trim();
                    user.Sex = parm.Sex.Trim();
                    user.Position = parm.Position.Trim();
                    user.Email = parm.Email.Trim();
                    //手机号码唯一
                    user.Mobile = parm.Mobile.Trim();
                    user.Description = parm.Description.Trim();
                    user.IDNumber = parm.IDNumber;
                    user.LoginErrorCount = 0;
                    user.IsDisabled = Convert.ToBoolean(parm.IsDisabled);
                    user.IsLocked = parm.IsLocked;
                    user.DepartmentID = parm.DepartmentID;
                    SaveUserArgs args = new SaveUserArgs();
                    args.User = user;

                    string RoleIDs = Request["RoleIDs"];
                    if (!string.IsNullOrEmpty(RoleIDs))
                    {
                        args.RoleIDs = new List<Guid>();
                        string[] roles = RoleIDs.Split(',');
                        foreach (string item in roles)
                        {
                            args.RoleIDs.Add(new Guid(item));
                        }
                    }
                    p.Client.SaveUser(SenderUser, args);
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }
        /// <summary>
        /// *delete*
        /// </summary>
        public void DeleteUser()
        {
            string ids = Request["ids"];
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    p.Client.DeleteUser(SenderUser, new Guid(ids));
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// List
        /// </summary>
        public void ListToRole()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string GroupID = Request["GroupID"];
                    string roleid = Request["roleid"];
                    string username = Request["username"];
                    string usercode = Request["usercode"];
                    if (!string.IsNullOrEmpty(GroupID))
                    {

                        SearchUserArgs sargs = new SearchUserArgs();
                        sargs.OrderBy = pagingParm.SortOrder;
                        sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                        sargs.RowNumberTo = pagingParm.RowNumberTo;
                        UserGroup userGroup = p.Client.GetUserGroup(SenderUser, new Guid(GroupID));
                        //Where
                        sargs.UserCodes = new List<string>() { { Regex.Replace(usercode, "", "%") } };
                        sargs.UserNames = new List<string>() { { Regex.Replace(username, "", "%") } };
                        SearchResult sr = p.Client.SearchUser(SenderUser, sargs);
                        DataTable dt = sr.DataSet.Tables[0];
                        Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2DataSetJson(null));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }


        public void GetUser()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid userid = new Guid(Request["UserID"]);
                    User user = p.Client.GetUser(SenderUser, userid);
                    if (user == null)
                    {
                        throw new Exception("所查找用户不存在。");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(user));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 批量保存所有用户角色
        /// </summary>
        public void SaveRoles()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string userID = Request["userid"];
                    string rolesfunids = Request["rolesfunids"];
                    SaveRole(userID, rolesfunids);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        private void SaveRole(string userID, string rolesfunids)
        {
            using (ProxyBE p = new ProxyBE())
            {
                List<System.Guid> roleItemIDs = new List<System.Guid>();
                SaveUserArgs sargs = new SaveUserArgs();
                if (!string.IsNullOrEmpty(rolesfunids))
                {
                    string[] roles = rolesfunids.Split(',');
                    foreach (string item in roles)
                    {
                        roleItemIDs.Add(new Guid(item));
                    }
                }

                var userItem = p.Client.GetUser(SenderUser, new Guid(userID));
                if (userItem == null)
                    return;
                sargs.RoleIDs = roleItemIDs;
                sargs.User = userItem;
                //保存用户时，只要把角色赋值给它即可,引擎会自动处理.
                p.Client.SaveUser(SenderUser, sargs);
            }
        }
        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        public void GetOnlineUser()
        {
            try
            {
                DataTable dt = OnlineUser.Search(null);
                Response.Write(JSONHelper.Object2DataSetJson(dt));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// detail or edit
        /// </summary>
        public void GetUserInfo()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    User pl = p.Client.GetUser(SenderUser, CurrentUser.UserID);
                    if (pl != null)
                    {
                        pl.Mobile = pl.Mobile.Substring(0, 4) + "****" + pl.Mobile.Substring(8, 3);
                        Response.Write(JSONHelper.Object2Json(pl));
                    }
                    else
                    {
                        WriteError("不存在用户信息！");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetUserLoginInfo()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (CurrentUser != null)
                    {
                        Response.Write(JSONHelper.Object2Json(CurrentUser));
                    }
                    else
                    {
                        WriteError("不存在用户信息！");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        public void DepartmentName()
        {
            using (ProxyBE p = new ProxyBE())
            {
                StringBuilder str = new StringBuilder();
                try
                {

                    SearchDepartmentArgs args = new SearchDepartmentArgs();
                    args.IsDisabled = false;
                    var codeName = p.Client.SearchDepartment(SenderUser, args).DataSet.Tables[0];
                    str.Append("[");
                    str.Append("{\"text\":\"请选择\",");
                    str.Append("\"value\":\"请选择\"},");
                    if (codeName.Rows.Count > 0)
                    {

                        for (int i = 0; i < codeName.Rows.Count; i++)
                        {

                            str.Append("{");
                            str.Append(string.Format("\"text\":\"{0}\",", codeName.Rows[i]["DepartmentName"]));
                            str.Append(string.Format("\"value\":\"{0}\"", codeName.Rows[i]["DepartmentID"]));
                            str.Append("},");

                        }
                    }
                    str.Append("]");
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
                string strm = str.ToString().Replace("},]", "}]");
                Response.Write(strm);
            }
        }

        //当前用户修改密码
        public void ModifiyPsw()
        {

            string OldPassword = Request["OldPassword"];
            string NewPassword = Request["NewPassword"];

            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    User user = p.Client.GetUser(SenderUser, this.CurrentUser.UserID);

                    if (CEncrypt.DecryptString(user.Password) != OldPassword)
                    {
                        throw new Exception("旧密码错误");
                    }
                    user.Password = CEncrypt.EncryptString(NewPassword);
                    SaveUserArgs sarg = new SaveUserArgs();
                    sarg.User = user;
                    p.Client.SaveUser(SenderUser, sarg);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        //用户管理重置密码
        public void ResetPsw()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid userid = new Guid(Request["UserID"]);
                    User user = p.Client.GetUser(SenderUser, userid);
                    if (user == null)
                    {
                        throw new Exception("所查找用户不存在。");
                    }

                    user.Password = CEncrypt.EncryptString(UserDefaultPassword);
                    user.LoginErrorCount = 0;
                    user.IsLocked = false;
                    user.IsDisabled = false;
                    SaveUserArgs sarg = new SaveUserArgs();
                    sarg.User = user;
                    p.Client.SaveUser(SenderUser, sarg);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        #endregion
    }
}