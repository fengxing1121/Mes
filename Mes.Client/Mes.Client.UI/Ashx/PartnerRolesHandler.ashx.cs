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
    /// PartnerRolesHandler 的摘要说明
    /// </summary>
    public class PartnerRolesHandler : BaseHttpHandler
    {
        #region ===============初始化加载===============
        PartnerUserGroupParm pugParm = null;
        PartnerRoleParm prParm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                pugParm = new PartnerUserGroupParm(context);
                prParm = new PartnerRoleParm(context);
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

        /// <summary>
        /// 获取组信息
        /// </summary>
        public void GetGroupInfo()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["GroupID"]))
                {
                    throw new Exception("GroupID,参数无效!");
                }

                var GroupID = Guid.Parse(Request["GroupID"].ToString());
                using (ProxyBE p = new ProxyBE())
                {
                    if (GroupID != Guid.Empty)
                    {
                        PartnerUserGroup pUserGroup = p.Client.GetPartnerUserGroup(SenderUser, GroupID);
                        if (pUserGroup != null)
                        {
                            Response.Write(JSONHelper.Object2Json(pUserGroup));
                        }
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
                if (string.IsNullOrEmpty(Request["RoleID"]))
                {
                    throw new Exception("RoleID,参数无效!");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Guid RoleID = Guid.Parse(Request["RoleID"].ToString());
                    if (RoleID != Guid.Empty)
                    {
                        PartnerRole pRole = p.Client.GetPartnerRole(SenderUser, RoleID);
                        if (pRole != null)
                        {
                            Response.Write(JSONHelper.Object2Json(pRole));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取组集合
        /// </summary>
        public void GetGroupList()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    List<PartnerUserGroup> list = p.Client.GetAllPartnerUserGroups(SenderUser);
                    List<PartnerUserGroup> userGroup = list.FindAll(x => x.PartnerID == CurrentUser.PartnerID && x.IsSystem == false);
                    if (userGroup != null)
                    {
                        Response.Write(JSONHelper.Object2JSON(userGroup));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取经销商用户
        /// </summary>
        public void UserTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string RoleID = Request["UserRoleID"];
                    List<PartnerUser2Role> listPartnerUser2Role = new List<PartnerUser2Role>();
                    if (!string.IsNullOrEmpty(RoleID))
                        listPartnerUser2Role = p.Client.GetPartnerUser2RoleByRoleID(SenderUser, new Guid(RoleID));

                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[{");
                    jsonBuilder.Append("\"id\":\"0\"");
                    jsonBuilder.Append(",\"text\":\"用户设置\"");
                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                    #region 经销商用户

                    SearchPartnerUserArgs agrs = new SearchPartnerUserArgs();
                    agrs.PartnerID = this.CurrentUser.PartnerID;
                    agrs.IsDisabled = false;
                    agrs.IsSystem = false;
                    SearchResult sr = p.Client.SearchPartnerUser(SenderUser, agrs);

                    if (sr.Total > 0)
                    {
                        jsonBuilder.AppendFormat(",\"children\":");
                        jsonBuilder.Append("[");
                        for (int j = 0; j < sr.DataSet.Tables[0].Rows.Count; j++)
                        {
                            DataRow drow = sr.DataSet.Tables[0].Rows[j];
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", drow["UserID"]);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", drow["UserName"]);
                            jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "user");
                            if (listPartnerUser2Role.Find(pl => pl.UserID == Guid.Parse(drow["UserID"].ToString())) != null)
                                jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\",\"ParentID\":\"" + drow["PartnerID"] + "\"}");
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
        /// 保存用户组
        /// </summary>
        public void SaveGroup()
        {
            try
            {
                Guid GroupID = Guid.Empty;
                if (!string.IsNullOrEmpty(Request["GroupID"]))
                    GroupID = new Guid(Request["GroupID"]);
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUserGroup group = p.Client.GetPartnerUserGroup(SenderUser, GroupID);
                    if (group == null)
                    {
                        group = new PartnerUserGroup();
                        group.GroupID = pugParm.GroupID;
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        group.PartnerID = CurrentUser.PartnerID;
                    }
                    group.GroupName = pugParm.GroupName;
                    group.Description = pugParm.Description;
                    group.IsDisabled = pugParm.IsDisabled;
                    group.IsLocked = pugParm.IsLocked;
                    bool flag = p.Client.PartnerUserGroupIsDuplicated(SenderUser, group);
                    if (flag)
                    {
                        throw new Exception("用户组已存在！");
                    }
                    SavePartnerUserGroupArgs args = new SavePartnerUserGroupArgs();
                    args.PartnerUserGroup = group;
                    p.Client.SavePartnerUserGroup(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存角色信息
        /// </summary>
        public void SaveRoleInfo()
        {
            try
            {
                Guid RoleID = Guid.Empty;
                if (!string.IsNullOrEmpty(Request["RoleID"]))
                    RoleID = new Guid(Request["RoleID"]);
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerRole role = p.Client.GetPartnerRole(SenderUser, RoleID);
                    if (role == null)
                    {
                        role = new PartnerRole();
                        role.RoleID = prParm.RoleID;
                    }
                    role.GroupID = prParm.GroupID;
                    role.RoleName = prParm.RoleName;
                    role.IsDisabled = prParm.IsDisabled;
                    role.IsLocked = prParm.IsLocked;
                    bool flag = p.Client.PartnerRoleIsDuplicated(SenderUser, role);
                    if (flag)
                    {
                        throw new Exception("当前组已存在该角色");
                    }
                    SavePartnerRoleArgs args = new SavePartnerRoleArgs();
                    args.PartnerRole = role;
                    p.Client.SavePartnerRole(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        public void SaveRoleMenuFun()
        {
            try
            {
                Guid RoleID = Guid.Empty;
                if (!string.IsNullOrEmpty(Request["RoleID"]))
                {
                    RoleID = Guid.Parse(Request["RoleID"]);
                }
                string PrivilegeItemS = Request["PrivilegeItemS"];
                using (ProxyBE p = new ProxyBE())
                {
                    List<Guid> PrivilegeItemIDS = new List<Guid>();
                    if (!string.IsNullOrEmpty(PrivilegeItemS))
                    {
                        string[] ItemS = PrivilegeItemS.Split(',');
                        foreach (var item in ItemS)
                        {
                            PrivilegeItemIDS.Add(new Guid(item));
                        }
                    }

                    var pRole = p.Client.GetPartnerRole(SenderUser, RoleID);
                    if (pRole == null)
                        return;
                    SavePartnerRoleArgs args = new SavePartnerRoleArgs();

                    args.PartnerRole = pRole;
                    args.PrivilegeItemIDs = PrivilegeItemIDS;
                    p.Client.SavePartnerRole(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存角色-用户
        /// </summary>
        public void SaveUserRoleFun()
        {
            try
            {
                Guid RoleID = Guid.Empty;
                if (!string.IsNullOrEmpty(Request["RoleID"]))
                    RoleID = Guid.Parse(Request["RoleID"]);
                string UserIDs = Request["UserIDs"];

                using (ProxyBE p = new ProxyBE())
                {
                    List<Guid> roleIDs = new List<Guid>();
                    if (!string.IsNullOrEmpty(UserIDs))
                    {
                        string[] roles = UserIDs.Split(',');
                        foreach (var item in roles)
                        {
                            roleIDs.Add(new Guid(item));
                        }
                    }

                    var user = p.Client.GetPartnerRole(SenderUser, RoleID);
                    if (user == null)
                        return;
                    SavePartnerRoleArgs args = new SavePartnerRoleArgs();
                    args.UserIDs = roleIDs;
                    args.PartnerRole = user;
                    p.Client.SavePartnerRole(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}