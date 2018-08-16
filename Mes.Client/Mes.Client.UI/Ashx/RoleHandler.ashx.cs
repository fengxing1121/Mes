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
using System.Web;

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// RoleHandler 的摘要说明
    /// </summary>
    public class RoleHandler : BaseHttpHandler
    {
        #region ===================初始化加载===================
        RoleParm parm;
        UserGroupParm usergroupParm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                parm = new RoleParm(context);
                usergroupParm = new UserGroupParm(context);
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
        #endregion

        #region BaseMethod

        /// <summary>
        /// List
        /// </summary>
        public void List()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    SearchRoleArgs sargs = new SearchRoleArgs();
                    sargs.OrderBy = pagingParm.SortOrder;
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;

                    SearchResult sr = p.Client.SearchRole(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }


        public void ListUserGroup()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    List<UserGroup> ugs = p.Client.GetAllUserGroup(SenderUser);
                    Response.Write(JSONHelper.Object2JSON(ugs));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Custom Method

        /// <summary>
        /// 保存角色权限
        /// </summary>
        public void SaveRoleMenuFun()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    string roleid = Request["Proleid"];
                    string menufunid = Request["menufunids"];
                    List<System.Guid> PrivilegeItemIDs = new List<System.Guid>();
                    SaveRoleArgs sargs = new SaveRoleArgs();

                    if (!string.IsNullOrEmpty(menufunid))
                    {
                        string[] menufunids = menufunid.Split(',');
                        foreach (string item in menufunids)
                        {
                            PrivilegeItemIDs.Add(new Guid(item));
                        }
                    }

                    var roleItem = p.Client.GetRole(SenderUser, new Guid(roleid));
                    if (roleItem == null)
                        return;
                    sargs.PrivilegeItemIDs = PrivilegeItemIDs;
                    sargs.Role = roleItem;
                    //保存角色时，只要把角色对应的权限赋值给它即可,引擎会自动处理.
                    p.Client.SaveRole(SenderUser, sargs);
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// 树（角色权限树）
        /// </summary>
        public void RoleTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string UserID = Request["UserID"];
                    List<User2Role> listUser2Role = new List<User2Role>();
                    if (!string.IsNullOrEmpty(UserID))
                        listUser2Role = p.Client.GetUser2RoleByUserID(SenderUser, new Guid(UserID));
                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[{");
                    jsonBuilder.Append("\"id\":\"0\"");
                    jsonBuilder.Append(",\"text\":\"角色设置\"");
                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                    #region 用户组
                    //用户组
                    SearchUserGroupArgs ugargs = new SearchUserGroupArgs();
                    //ugargs.IsSystem = false;                    
                    SearchResult sr = p.Client.SearchUserGroup(SenderUser, ugargs);
                    if (sr.Total > 0)
                    {
                        jsonBuilder.AppendFormat(",\"children\":");
                        jsonBuilder.Append("[");
                        for (int j = 0; j < sr.DataSet.Tables[0].Rows.Count; j++)
                        {
                            DataRow drow = sr.DataSet.Tables[0].Rows[j];
                            // PrivilegeCategory itemPC = listPrivilegeCategory[j];
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", drow["GroupID"]);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", drow["GroupName"]);
                            jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "group");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\",\"ParentID\":\"" + drow["GroupID"] + "\"}");
                            jsonBuilder.AppendFormat(",\"children\":");
                            jsonBuilder.Append("[");
                            #region 角色
                            //角色
                            List<Role> listRole = p.Client.GetRolesByGroupID(SenderUser, new Guid((drow["GroupID"].ToString())));
                            if (listRole != null)
                            {

                                for (int n = 0; n < listRole.Count; n++)
                                {

                                    Role itemRole = listRole[n];
                                    //if (itemRole.IsSystem) continue;
                                    jsonBuilder.Append("{");
                                    jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemRole.RoleID);
                                    jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemRole.RoleName);
                                    jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "user");
                                    if (listUser2Role.Find(pl => pl.RoleID == itemRole.RoleID) != null)
                                        jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"3\",\"ParentID\":\"" + drow["GroupID"].ToString() + "\"}");
                                    jsonBuilder.Append("}");
                                    if (n < listRole.Count - 1)
                                    {
                                        jsonBuilder.Append(",");
                                    }
                                }
                            }
                            #endregion
                            jsonBuilder.Append("]");
                            jsonBuilder.Append("}");
                            if (j < sr.DataSet.Tables[0].Rows.Count - 1)
                            {
                                jsonBuilder.Append(",");
                            }
                        }
                        jsonBuilder.Append("]");
                    }

                    #endregion
                    jsonBuilder.Append("}]");
                    Response.Write(jsonBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GroupTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string UserID = Request["UserID"];

                    List<User2Role> listUser2Role = new List<User2Role>();
                    if (!string.IsNullOrEmpty(UserID))
                        listUser2Role = p.Client.GetUser2RoleByUserID(SenderUser, new Guid(UserID));
                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[{");
                    jsonBuilder.Append("\"id\":\"0\"");
                    jsonBuilder.Append(",\"text\":\"用户组\"");
                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                    #region 用户组
                    //用户组
                    SearchUserGroupArgs ugargs = new SearchUserGroupArgs();
                    SearchResult sr = p.Client.SearchUserGroup(SenderUser, ugargs);
                    if (sr.Total > 0)
                    {
                        jsonBuilder.AppendFormat(",\"children\":");
                        jsonBuilder.Append("[");
                        for (int j = 0; j < sr.DataSet.Tables[0].Rows.Count; j++)
                        {
                            DataRow drow = sr.DataSet.Tables[0].Rows[j];
                            // PrivilegeCategory itemPC = listPrivilegeCategory[j];
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", drow["GroupID"]);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", drow["GroupName"]);
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\",\"ParentID\":\"" + drow["GroupID"] + "\"}");
                            jsonBuilder.Append("}");
                            if (j < sr.DataSet.Tables[0].Rows.Count - 1)
                            {
                                jsonBuilder.Append(",");
                            }
                        }
                        jsonBuilder.Append("]");
                    }

                    #endregion
                    jsonBuilder.Append("}]");
                    Response.Write(jsonBuilder.ToString());

                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取用户组信息
        /// </summary>
        public void GetGroupInfo()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    var gid = new Guid(Request["GroupID"].ToString());
                    if (gid != Guid.Empty)
                    {
                        UserGroup ug = p.Client.GetUserGroup(SenderUser, gid);
                        Response.Write(JSONHelper.Object2Json(ug));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        public void GetRoleInfo()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    var rid = new Guid(Request["RoleID"].ToString());
                    if (rid != Guid.Empty)
                    {
                        Role ug = p.Client.GetRole(SenderUser, rid);
                        Response.Write(JSONHelper.Object2Json(ug));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 按部门分类加载用户
        /// </summary>
        public void UserTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string RoleID = Request["UserRoleID"];

                    List<User2Role> listUser2Role = new List<User2Role>();
                    if (!string.IsNullOrEmpty(RoleID))
                        listUser2Role = p.Client.GetUser2RoleByRoleID(SenderUser, new Guid(RoleID));
                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[{");
                    jsonBuilder.Append("\"id\":\"0\"");
                    jsonBuilder.Append(",\"text\":\"用户设置\"");
                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                    #region 部门类型

                    SearchDepartmentArgs ugargs = new SearchDepartmentArgs();
                    ugargs.IsDisabled = false;
                    SearchResult sr = p.Client.SearchDepartment(SenderUser, ugargs);
                    if (sr.Total > 0)
                    {
                        jsonBuilder.AppendFormat(",\"children\":");
                        jsonBuilder.Append("[");
                        for (int j = 0; j < sr.DataSet.Tables[0].Rows.Count; j++)
                        {
                            DataRow drow = sr.DataSet.Tables[0].Rows[j];
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", drow["DepartmentID"]);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", drow["DepartmentName"]);
                            jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "group");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\",\"ParentID\":\"" + drow["DepartmentID"] + "\"}");
                            jsonBuilder.AppendFormat(",\"children\":");
                            jsonBuilder.Append("[");
                            #region 用户                            
                            List<User> listuser = p.Client.GetUsersByDepartmentID(SenderUser, new Guid((drow["DepartmentID"].ToString())));
                            if (listuser != null)
                            {
                                for (int n = 0; n < listuser.Count; n++)
                                {
                                    User item = listuser[n];
                                    if (item.IsDisabled) continue;
                                    jsonBuilder.Append("{");
                                    jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.UserID);
                                    jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.UserName);
                                    jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "user");
                                    if (listUser2Role.Find(pl => pl.UserID == item.UserID) != null)
                                        jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"3\",\"ParentID\":\"" + drow["DepartmentID"].ToString() + "\"}");
                                    jsonBuilder.Append("}");
                                    if (n < listuser.Count - 1)
                                    {
                                        jsonBuilder.Append(",");
                                    }
                                }
                            }
                            #endregion
                            jsonBuilder.Append("]");
                            jsonBuilder.Append("}");
                            if (j < sr.DataSet.Tables[0].Rows.Count - 1)
                            {
                                jsonBuilder.Append(",");
                            }
                        }
                        jsonBuilder.Append("]");
                    }

                    #endregion
                    jsonBuilder.Append("}]");
                    Response.Write(jsonBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存角色用户 
        /// </summary>
        public void SaveUserRoleFun()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string roleid = Request["roleid"];
                    string userfunids = Request["userfunids"];
                    SaveRole(roleid, userfunids);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        private void SaveRole(string roleID, string userfunids)
        {
            using (ProxyBE p = new ProxyBE())
            {
                List<System.Guid> roleItemIDs = new List<System.Guid>();
                SaveRoleArgs sargs = new SaveRoleArgs();
                if (!string.IsNullOrEmpty(userfunids))
                {
                    string[] roles = userfunids.Split(',');
                    foreach (string item in roles)
                    {
                        roleItemIDs.Add(new Guid(item));
                    }
                }

                var userItem = p.Client.GetRole(SenderUser, new Guid(roleID));
                if (userItem == null)
                    return;
                sargs.UserIDs = roleItemIDs;
                sargs.Role = userItem;
                //保存用户时，只要把角色赋值给它即可,引擎会自动处理.
                p.Client.SaveRole(SenderUser, sargs);
            }
        }

        public void SaveGroup()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    var GroupID = new Guid(Request["GroupID"].ToString());
                    var GroupName = Request["GroupName"].ToString();

                    if (GroupID != Guid.Empty)
                    {
                        UserGroup gp = p.Client.GetUserGroup(SenderUser, GroupID);
                        if (gp == null)
                        {
                            gp = new UserGroup();
                            gp.GroupID = this.usergroupParm.GroupID;
                        }
                        gp.GroupName = GroupName;
                        gp.Description = usergroupParm.Description;
                        gp.IsDisabled = usergroupParm.IsDisabled;
                        gp.IsLocked = usergroupParm.IsLocked;
                        bool flag = p.Client.UserGroupIsDuplicated(SenderUser, gp);
                        if (flag)
                        {
                            throw new Exception("用户组已经存!");
                        }
                        SaveUserGroupArgs args = new SaveUserGroupArgs();
                        args.UserGroup = gp;
                        p.Client.SaveUserGroup(SenderUser, args);
                        WriteSuccess();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveRoleInfo()
        {

            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    var GroupID = new Guid(Request["GroupID"].ToString());
                    var RoleID = new Guid(Request["RoleID"].ToString());
                    var RoleName = Request["RoleName"].ToString();
                    var Description = Request["Description"].ToString();

                    Role pl = p.Client.GetRole(SenderUser, parm.RoleID);
                    if (pl == null)
                    {
                        pl = new Role();
                        pl.RoleID = parm.RoleID;
                    }
                    pl.GroupID = GroupID;
                    pl.RoleName = RoleName;
                    pl.Description = Description;
                    pl.IsDisabled = parm.IsDisabled;
                    pl.IsLocked = parm.IsLocked;
                    bool flag = p.Client.RoleIsDuplicated(SenderUser, pl);
                    if (flag)
                    {
                        throw new Exception("当前用户组已经存在该角色!");
                    }
                    SaveRoleArgs args = new SaveRoleArgs();
                    args.Role = pl;
                    p.Client.SaveRole(SenderUser, args);
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