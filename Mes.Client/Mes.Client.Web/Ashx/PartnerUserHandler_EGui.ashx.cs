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

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// PartnerUserHandler_EGui 的摘要说明
    /// </summary>
    public class PartnerUserHandler_EGui : BaseHttpHandler
    {
        #region ===============初始化加载===============
        PartnerUserParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                parm = new PartnerUserParm(context);
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

        public void SearchPartnerUser()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPartnerUserArgs args = new SearchPartnerUserArgs();
                    args.OrderBy = pagingParm.SortOrder;
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    if (!string.IsNullOrEmpty(Request["IsSystem"]))
                    {
                        args.IsSystem = Convert.ToBoolean(Request["IsSystem"]);
                    }

                    if (!string.IsNullOrEmpty(parm.UserCode))
                    {
                        List<string> UserCode = new List<string>();
                        UserCode.Add(parm.UserCode);
                        args.UserCodes = UserCode;
                    }
                    if (!string.IsNullOrEmpty(parm.UserName))
                    {
                        List<string> UserName = new List<string>();
                        UserName.Add(parm.UserName);
                        args.UserNames = UserName;
                    }
                    if (!string.IsNullOrEmpty(Request["IsDisabled"]) && Request["IsDisabled"] != "请选择")
                    {
                        args.IsDisabled = Convert.ToBoolean(Request["IsDisabled"]);
                    }

                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        args.Mobile = parm.Mobile;
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        args.PartnerID = CurrentUser.PartnerID;
                    }
                    SearchResult sr = p.Client.SearchPartnerUser(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetPartnerUser()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["UserID"]))
                {
                    throw new Exception("参数无效");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    Guid uid = Guid.Parse(Request["UserID"]);
                    PartnerUser partnerUser = p.Client.GetPartnerUser(SenderUser, uid);
                    if (partnerUser == null)
                    {
                        throw new Exception("查询用户不存在");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(partnerUser));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SavePartnerUser()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    PartnerUser partnerUser = p.Client.GetPartnerUser(null, parm.UserID);
                    if (partnerUser == null)
                    {
                        //新增
                        partnerUser = new PartnerUser();
                        partnerUser.UserID = parm.UserID;
                        partnerUser.Created = DateTime.Now;
                        //partnerUser.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                        partnerUser.CreatedBy = "EGui平台";
                        partnerUser.Modified = DateTime.Now;
                        //partnerUser.ModifiedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                        partnerUser.ModifiedBy = "EGui平台";
                        //partnerUser.Password = MES.Libraries.CEncrypt.EncryptString(UserDefaultPassword);
                        partnerUser.Password = CEncrypt.EncryptString(HttpContext.Current.Request["UserPwd"]);//PWD
                    }
                    //partnerUser.UserCode = parm.UserCode.Trim();
                    partnerUser.UserCode = HttpContext.Current.Request["UserPhone"];//电话注册
                    bool flag = p.Client.PartnerUserIsDuplicated(SenderUser, partnerUser);
                    if (flag)
                    {
                        throw new Exception("该账户已经存在,请重新输入。");
                    }
                    //partnerUser.PartnerID = this.CurrentUser.PartnerID;
                    partnerUser.PartnerID = new Guid("14D08A0B-D52B-FD09-3B0E-A9C308783C90");//经销商ID
                    //partnerUser.UserName = parm.UserName.Trim();
                    partnerUser.UserName = "用户" + HttpContext.Current.Request["UserPhone"];
                    //partnerUser.Sex = parm.Sex.Trim();
                    partnerUser.Sex = "";
                    //if (parm.Position == "" || parm.Position == "请选择")
                    //{
                    //    throw new Exception("请选择职位!");
                    //}
                    //partnerUser.Position = parm.Position.Trim();
                    partnerUser.Position = "量尺";
                    //partnerUser.Email = parm.Email.Trim();
                    partnerUser.Email = "";
                    //partnerUser.Mobile = parm.Mobile.Trim();
                    partnerUser.Mobile = HttpContext.Current.Request["UserPhone"];

                    //partnerUser.Description = parm.Description.Trim();
                    partnerUser.Description = "";
                    partnerUser.LoginErrorCount = 0;
                    //partnerUser.IsDisabled = parm.IsDisabled;
                    //partnerUser.IsLocked = parm.IsLocked;

                    partnerUser.IsDisabled = false;
                    partnerUser.IsLocked = false;

                    SavePartnerUserArgs args = new SavePartnerUserArgs();
                    args.PartnerUser = partnerUser;

                    string roleIDs = "33c49247-4d4e-828e-7fc1-b3d7cf4d2078";//角色权限
                    args.RoleIDs = new List<Guid>();
                    if (!string.IsNullOrEmpty(roleIDs))
                    {
                        string[] roles = roleIDs.Split(',');
                        foreach (var item in roles)
                        {
                            args.RoleIDs.Add(new Guid(item));
                        }
                    }
                    p.Client.SavePartnerUser(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SavePartnerManagerUser()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    #region  PartnerUser
                    PartnerUser partnerUser = p.Client.GetPartnerUser(SenderUser, parm.UserID);
                    if (partnerUser != null)
                    {
                        partnerUser.UserCode = parm.UserCode.Trim();
                        bool flag = p.Client.PartnerUserIsDuplicated(SenderUser, partnerUser);
                        if (flag)
                        {
                            throw new Exception("该账号已经存在,请重新输入。");
                        }
                        partnerUser.PartnerID = parm.PartnerID;
                        partnerUser.UserName = parm.UserName.Trim();
                        partnerUser.Sex = parm.Sex.Trim();
                        partnerUser.Position = parm.Position.Trim();
                        partnerUser.IsSystem = true;
                        partnerUser.Email = parm.Email.Trim();
                        partnerUser.Description = parm.Description.Trim();
                        partnerUser.Mobile = parm.Mobile.Trim();
                        partnerUser.LoginErrorCount = 0;
                        partnerUser.IsDisabled = Convert.ToBoolean(parm.IsDisabled);
                        partnerUser.IsLocked = parm.IsLocked;
                    }
                    SavePartnerUserArgs args = new SavePartnerUserArgs();
                    args.PartnerUser = partnerUser;
                    p.Client.SavePartnerUser(SenderUser, args);
                    #endregion

                    #region  PartnerUserGroup
                    PartnerUserGroup UserGroup = null;
                    SearchPartnerUserGroupArgs UserGroupArgs = new SearchPartnerUserGroupArgs();
                    UserGroupArgs.PartnerID = partnerUser.PartnerID;
                    UserGroupArgs.GroupName = "默认组";
                    Guid GroupID = Guid.Empty;
                    SearchResult sr = p.Client.SearchPartnerUserGroup(SenderUser, UserGroupArgs);
                    if (sr.Total > 0)
                    {
                        foreach (DataRow item in sr.DataSet.Tables[0].Rows)
                        {
                            GroupID = Guid.Parse(item["GroupID"].ToString());
                        }
                        UserGroup = p.Client.GetPartnerUserGroup(SenderUser, GroupID);
                    }
                    if (GroupID == Guid.Empty)
                    {
                        UserGroup = new PartnerUserGroup();
                        UserGroup.GroupID = Guid.NewGuid();
                        UserGroup.GroupName = "默认组";
                        UserGroup.IsSystem = true;
                        UserGroup.PartnerID = partnerUser.PartnerID;
                        SavePartnerUserGroupArgs GroupArgs = new SavePartnerUserGroupArgs();
                        GroupArgs.PartnerUserGroup = UserGroup;
                        p.Client.SavePartnerUserGroup(SenderUser, GroupArgs);
                    }
                    #endregion

                    #region  PartnerRole
                    string PrivilegeItemS = Request["PrivilegeItemS"];
                    List<Guid> PrivilegeItemIDS = new List<Guid>();
                    if (!string.IsNullOrEmpty(PrivilegeItemS))
                    {
                        string[] ItemS = PrivilegeItemS.Split(',');
                        foreach (var item in ItemS)
                        {
                            PrivilegeItemIDS.Add(new Guid(item));
                        }
                    }
                    PartnerRole partnerRole = p.Client.GetPartnerRoleByName(SenderUser, UserGroup.GroupID, "root");
                    if (partnerRole == null)
                    {
                        partnerRole = new PartnerRole();
                        partnerRole.GroupID = UserGroup.GroupID;
                        partnerRole.IsSystem = true;
                        partnerRole.RoleID = Guid.NewGuid();
                        partnerRole.RoleName = "root";
                    }
                    SavePartnerRoleArgs roleArgs = new SavePartnerRoleArgs();
                    roleArgs.PartnerRole = partnerRole;
                    roleArgs.PrivilegeItemIDs = PrivilegeItemIDS;
                    p.Client.SavePartnerRole(SenderUser, roleArgs);
                    #endregion

                    #region PartnerUser2Role
                    PartnerUser2Role PartnerUser2Role = new PartnerUser2Role();
                    PartnerUser2Role.UserID = partnerUser.UserID;
                    PartnerUser2Role.RoleID = partnerRole.RoleID;

                    SavePartnerUser2RoleArgs sargs = new SavePartnerUser2RoleArgs();
                    sargs.PartnerUser2Role = PartnerUser2Role;
                    p.Client.SavePartnerUser2Role(SenderUser, sargs);
                    #endregion

                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void ResetPwd()
        {
            try
            {
                Guid UserID = Guid.Empty;
                if (!string.IsNullOrEmpty(Request["UserID"]))
                    UserID = Guid.Parse(Request["UserID"].ToString());
                using (ProxyBE p = new ProxyBE())
                {
                    var partnerUser = p.Client.GetPartnerUser(SenderUser, UserID);
                    if (partnerUser == null)
                    {
                        throw new Exception("查找的用户不存在");
                    }
                    partnerUser.Password = CEncrypt.EncryptString(UserDefaultPassword);
                    partnerUser.LoginErrorCount = 0;
                    partnerUser.IsLocked = false;
                    partnerUser.IsLocked = false;

                    SavePartnerUserArgs args = new SavePartnerUserArgs();
                    args.PartnerUser = partnerUser;
                    p.Client.SavePartnerUser(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// (树)经销商权限
        /// </summary>
        public void RoleTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string UserID = Request["UserID"];
                    List<PartnerUser2Role> partnerUser2Role = new List<PartnerUser2Role>();
                    if (!string.IsNullOrEmpty(UserID))
                        partnerUser2Role = p.Client.GetPartnerUser2RoleByUserID(SenderUser, new Guid(UserID));
                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[{");
                    jsonBuilder.Append("\"id\":\"0\"");
                    jsonBuilder.Append(",\"text\":\"角色设置\"");
                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                    #region 用户组
                    //用户组
                    SearchPartnerUserGroupArgs pargs = new SearchPartnerUserGroupArgs();
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        pargs.PartnerID = CurrentUser.PartnerID;
                    }
                    pargs.IsSystem = false;
                    SearchResult sr = p.Client.SearchPartnerUserGroup(SenderUser, pargs);
                    if (sr.Total > 0)
                    {
                        jsonBuilder.AppendFormat(",\"children\":");
                        jsonBuilder.Append("[");
                        for (int j = 0; j < sr.DataSet.Tables[0].Rows.Count; j++)
                        {
                            DataRow drow = sr.DataSet.Tables[0].Rows[j];
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", drow["GroupID"]);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", drow["GroupName"]);
                            jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "group");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\",\"ParentID\":\"" + drow["GroupID"] + "\"}");
                            jsonBuilder.AppendFormat(",\"children\":");
                            jsonBuilder.Append("[");
                            #region 角色
                            //角色
                            List<PartnerRole> pRole = p.Client.GetPartnerRolesByGroupID(SenderUser, new Guid((drow["GroupID"].ToString())));
                            if (pRole != null)
                            {
                                for (int n = 0; n < pRole.Count; n++)
                                {
                                    PartnerRole itemRole = pRole[n];
                                    if (itemRole.IsSystem) continue;
                                    jsonBuilder.Append("{");
                                    jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemRole.RoleID);
                                    jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemRole.RoleName);
                                    jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "user");

                                    if (partnerUser2Role.Find(pl => pl.RoleID == itemRole.RoleID) != null)
                                        jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"3\",\"ParentID\":\"" + drow["GroupID"].ToString() + "\"}");
                                    jsonBuilder.Append("}");
                                    if (n < pRole.Count - 1)
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
    }
}