using LitJson;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Enum;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// PrivilegeHandler 的摘要说明
    /// </summary>
    public class PrivilegeHandler : BaseHttpHandler
    {
        /// <summary>
        /// CRM(CategoryID)
        /// </summary>
        private const string CategoryID = "10000000-0000-0000-0000-000000001500";

        PrivilegeParm parm;
        PrivilegeCategoryParm CategoryParm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                parm = new PrivilegeParm(context);
                CategoryParm = new PrivilegeCategoryParm(context);
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

        /// <summary>
        /// 树（角色权限树）
        /// </summary>
        public void Tree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string ProleID = Request["ProleID"];
                    List<PrivilegeItem> PrivilegeItems = p.Client.GetPrivilegeItemByRoleID(SenderUser, new Guid(ProleID));
                    PrivilegeItems = PrivilegeItems ?? new List<PrivilegeItem>();
                    if (!string.IsNullOrEmpty(ProleID))
                    {
                        StringBuilder jsonBuilder = new StringBuilder();
                        jsonBuilder.Append("[{");
                        jsonBuilder.Append("\"id\":\"0\"");
                        jsonBuilder.Append(",\"text\":\"权限菜单\"");
                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");

                        jsonBuilder.AppendFormat(",\"children\":");
                        //UserGroup userGroup = p.Client.GetUserGroup(SenderUser, new Guid(RGroupID));
                        List<PrivilegeCategory> privilegeCategorys = p.Client.GetPrivilegeCategorys(SenderUser);
                        //获取当前应用系统下的所有菜单项
                        jsonBuilder.Append("[");
                        for (int n = 0; n < privilegeCategorys.Count; n++)
                        {
                            PrivilegeCategory item = privilegeCategorys[n];
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.CategoryID);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.CategoryName);
                            jsonBuilder.Append(",\"state\":\"closed\"");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");
                            jsonBuilder.AppendFormat(",\"children\":");
                            jsonBuilder.Append("[");
                            #region 权限菜单

                            List<Privilege> Privileges = p.Client.GetPrivilegesByCategoryID(SenderUser, item.CategoryID);

                            for (int i = 0; i < Privileges.Count; i++)
                            {
                                Privilege itemPrivilege = Privileges[i];
                                jsonBuilder.Append("{");
                                jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilege.PrivilegeID);
                                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilege.PrivilegeName);
                                jsonBuilder.Append(",\"state\":\"closed\"");
                                jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");

                                #region 权限项

                                //是否权限项
                                List<PrivilegeItem> listPrivilegeItem = p.Client.GetPrivilegeItemByPrivilegeID(SenderUser, itemPrivilege.PrivilegeID);
                                if (listPrivilegeItem != null)
                                {
                                    jsonBuilder.AppendFormat(",\"children\":");
                                    jsonBuilder.Append("[");
                                    for (int j = 0; j < listPrivilegeItem.Count; j++)
                                    {

                                        PrivilegeItem itemPrivilegeItem = listPrivilegeItem[j];
                                        jsonBuilder.Append("{");
                                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilegeItem.PrivilegeItemID);
                                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilegeItem.PrivilegeItemName);
                                        if (PrivilegeItems.Find(pl => pl.PrivilegeItemID == itemPrivilegeItem.PrivilegeItemID) != null)
                                            jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                                        jsonBuilder.Append("}");
                                        if (j < listPrivilegeItem.Count - 1)
                                        {
                                            jsonBuilder.Append(",");
                                        }
                                    }
                                    jsonBuilder.Append("]");
                                }

                                #endregion

                                jsonBuilder.Append("}");
                                if (i < Privileges.Count - 1)
                                {
                                    jsonBuilder.Append(",");
                                }
                            }

                            #endregion
                            jsonBuilder.Append("]");
                            jsonBuilder.Append("}");
                            if (n < privilegeCategorys.Count - 1)
                            {
                                jsonBuilder.Append(",");
                            }
                        }

                        jsonBuilder.Append("]");
                        jsonBuilder.Append("}]");
                        Response.Write(jsonBuilder.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 树(CRM管理)
        /// </summary>
        public void CrmTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string RoleID = Request["RoleID"];
                    var PrivilegeItems = p.Client.GetPrivilegeItemByPartnerRoleID(SenderUser, new Guid(RoleID));
                    PrivilegeItems = PrivilegeItems ?? new List<PrivilegeItem>();
                    if (!string.IsNullOrEmpty(RoleID))
                    {
                        StringBuilder jsonBuilder = new StringBuilder();
                        jsonBuilder.Append("[{");
                        jsonBuilder.Append("\"id\":\"0\"");
                        jsonBuilder.Append(",\"text\":\"权限菜单\"");
                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");

                        jsonBuilder.AppendFormat(",\"children\":");
                        PrivilegeCategory item = p.Client.GetPrivilegeCategory(SenderUser, new Guid(CategoryID));
                        //获取当前应用系统下的所有菜单项
                        jsonBuilder.Append("[");
                        if (item != null)
                        {
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.CategoryID);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.CategoryName);
                            jsonBuilder.Append(",\"state\":\"closed\"");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");
                            jsonBuilder.AppendFormat(",\"children\":");
                            jsonBuilder.Append("[");
                            #region 权限菜单

                            List<Privilege> Privileges = p.Client.GetPrivilegesByCategoryID(SenderUser, item.CategoryID);

                            for (int i = 0; i < Privileges.Count; i++)
                            {
                                Privilege itemPrivilege = Privileges[i];
                                if (itemPrivilege.IsDisabled)
                                {
                                    continue;
                                }
                                jsonBuilder.Append("{");
                                jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilege.PrivilegeID);
                                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilege.PrivilegeName);
                                jsonBuilder.Append(",\"state\":\"closed\"");
                                jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");
                                #region 权限项
                                //是否权限项
                                List<PrivilegeItem> listPrivilegeItem = p.Client.GetPrivilegeItemByPrivilegeID(SenderUser, itemPrivilege.PrivilegeID);
                                if (listPrivilegeItem != null)
                                {
                                    jsonBuilder.AppendFormat(",\"children\":");
                                    jsonBuilder.Append("[");
                                    for (int j = 0; j < listPrivilegeItem.Count; j++)
                                    {
                                        PrivilegeItem itemPrivilegeItem = listPrivilegeItem[j];
                                        jsonBuilder.Append("{");
                                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilegeItem.PrivilegeItemID);
                                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilegeItem.PrivilegeItemName);
                                        if (PrivilegeItems.Find(pl => pl.PrivilegeItemID == itemPrivilegeItem.PrivilegeItemID) != null)
                                            jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                                        jsonBuilder.Append("}");
                                        if (j < listPrivilegeItem.Count - 1)
                                        {
                                            jsonBuilder.Append(",");
                                        }
                                    }
                                    jsonBuilder.Append("]");
                                }

                                #endregion
                                jsonBuilder.Append("}");
                                if (i < Privileges.Count - 1)
                                {
                                    jsonBuilder.Append(",");
                                }
                            }
                            #endregion
                            jsonBuilder.Append("]");
                            jsonBuilder.Append("}");
                        }
                        jsonBuilder.Append("]");
                        jsonBuilder.Append("}]");
                        Response.Write(jsonBuilder.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 树(经销商)
        /// </summary>
        public void PartnerTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    string PartnerID = Request["PartnerID"].ToString();
                    PartnerRole partnerRole = null;
                    if (!string.IsNullOrEmpty(PartnerID))
                    {
                        SearchPartnerUserGroupArgs UserGroupArgs = new SearchPartnerUserGroupArgs();
                        UserGroupArgs.PartnerID = new Guid(PartnerID);
                        UserGroupArgs.GroupName = "默认组";
                        Guid GroupID = Guid.Empty;
                        SearchResult sr = p.Client.SearchPartnerUserGroup(SenderUser, UserGroupArgs);
                        if (sr.Total > 0)
                        {
                            foreach (DataRow item in sr.DataSet.Tables[0].Rows)
                            {
                                GroupID = Guid.Parse(item["GroupID"].ToString());
                            }
                        }
                        if (GroupID != Guid.Empty)
                        {
                            partnerRole = p.Client.GetPartnerRoleByName(SenderUser, GroupID, "root");
                        }
                    }
                    if (partnerRole != null)
                    {
                        #region 第二次
                        var PrivilegeItems = p.Client.GetPrivilegeItemByPartnerRoleID(SenderUser, partnerRole.RoleID);
                        PrivilegeItems = PrivilegeItems ?? new List<PrivilegeItem>();
                        StringBuilder jsonBuilder = new StringBuilder();
                        jsonBuilder.Append("[{");
                        jsonBuilder.Append("\"id\":\"0\"");
                        jsonBuilder.Append(",\"text\":\"权限菜单\"");
                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");

                        jsonBuilder.AppendFormat(",\"children\":");
                        PrivilegeCategory item = p.Client.GetPrivilegeCategory(SenderUser, new Guid(CategoryID));
                        //获取当前应用系统下的所有菜单项
                        jsonBuilder.Append("[");
                        if (item != null)
                        {
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.CategoryID);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.CategoryName);
                            jsonBuilder.Append(",\"state\":\"closed\"");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");
                            jsonBuilder.AppendFormat(",\"children\":");
                            jsonBuilder.Append("[");
                            #region 权限菜单

                            List<Privilege> Privileges = p.Client.GetPrivilegesByCategoryID(SenderUser, item.CategoryID).Where(t => !t.IsDisabled).ToList();

                            for (int i = 0; i < Privileges.Count; i++)
                            {
                                Privilege itemPrivilege = Privileges[i];
                                //if (itemPrivilege.IsDisabled)
                                //{
                                //    continue;
                                //}
                                jsonBuilder.Append("{");
                                jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilege.PrivilegeID);
                                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilege.PrivilegeName);
                                jsonBuilder.Append(",\"state\":\"closed\"");
                                jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");
                                #region 权限项
                                //是否权限项
                                List<PrivilegeItem> listPrivilegeItem = p.Client.GetPrivilegeItemByPrivilegeID(SenderUser, itemPrivilege.PrivilegeID);
                                if (listPrivilegeItem != null)
                                {
                                    jsonBuilder.AppendFormat(",\"children\":");
                                    jsonBuilder.Append("[");
                                    for (int j = 0; j < listPrivilegeItem.Count; j++)
                                    {
                                        PrivilegeItem itemPrivilegeItem = listPrivilegeItem[j];
                                        jsonBuilder.Append("{");
                                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilegeItem.PrivilegeItemID);
                                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilegeItem.PrivilegeItemName);
                                        if (PrivilegeItems.Find(pl => pl.PrivilegeItemID == itemPrivilegeItem.PrivilegeItemID) != null)
                                            jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                                        jsonBuilder.Append("}");
                                        if (j < listPrivilegeItem.Count - 1)
                                        {
                                            jsonBuilder.Append(",");
                                        }
                                    }
                                    jsonBuilder.Append("]");
                                }

                                #endregion
                                jsonBuilder.Append("}");
                                if (i < Privileges.Count - 1)
                                {
                                    jsonBuilder.Append(",");
                                }
                            }
                            #endregion
                            jsonBuilder.Append("]");
                            jsonBuilder.Append("}");
                        }
                        jsonBuilder.Append("]");
                        jsonBuilder.Append("}]");
                        Response.Write(jsonBuilder.ToString());
                        #endregion
                    }
                    else
                    {
                        #region 初始化
                        var PrivilegeItems = new List<PrivilegeItem>();
                        StringBuilder jsonBuilder = new StringBuilder();
                        jsonBuilder.Append("[{");
                        jsonBuilder.Append("\"id\":\"0\"");
                        jsonBuilder.Append(",\"text\":\"权限菜单\"");
                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");

                        jsonBuilder.AppendFormat(",\"children\":");
                        PrivilegeCategory item = p.Client.GetPrivilegeCategory(SenderUser, new Guid(CategoryID));
                        //获取当前应用系统下的所有菜单项
                        jsonBuilder.Append("[");
                        if (item != null)
                        {
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.CategoryID);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.CategoryName);
                            jsonBuilder.Append(",\"state\":\"closed\"");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");
                            jsonBuilder.AppendFormat(",\"children\":");
                            jsonBuilder.Append("[");
                            #region 权限菜单

                            List<Privilege> Privileges = p.Client.GetPrivilegesByCategoryID(SenderUser, item.CategoryID).Where(t => !t.IsDisabled).ToList();

                            for (int i = 0; i < Privileges.Count; i++)
                            {
                                Privilege itemPrivilege = Privileges[i];
                                //if (itemPrivilege.IsDisabled)
                                //{
                                //    continue;
                                //}
                                jsonBuilder.Append("{");
                                jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilege.PrivilegeID);
                                jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilege.PrivilegeName);
                                jsonBuilder.Append(",\"state\":\"closed\"");
                                jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"1\"}");
                                #region 权限项
                                //是否权限项
                                List<PrivilegeItem> listPrivilegeItem = p.Client.GetPrivilegeItemByPrivilegeID(SenderUser, itemPrivilege.PrivilegeID);
                                if (listPrivilegeItem != null)
                                {
                                    jsonBuilder.AppendFormat(",\"children\":");
                                    jsonBuilder.Append("[");
                                    for (int j = 0; j < listPrivilegeItem.Count; j++)
                                    {
                                        PrivilegeItem itemPrivilegeItem = listPrivilegeItem[j];
                                        jsonBuilder.Append("{");
                                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", itemPrivilegeItem.PrivilegeItemID);
                                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", itemPrivilegeItem.PrivilegeItemName);
                                        if (PrivilegeItems.Find(pl => pl.PrivilegeItemID == itemPrivilegeItem.PrivilegeItemID) != null)
                                            jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                                        jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                                        jsonBuilder.Append("}");
                                        if (j < listPrivilegeItem.Count - 1)
                                        {
                                            jsonBuilder.Append(",");
                                        }
                                    }
                                    jsonBuilder.Append("]");
                                }

                                #endregion
                                jsonBuilder.Append("}");
                                if (i < Privileges.Count - 1)
                                {
                                    jsonBuilder.Append(",");
                                }
                            }
                            #endregion
                            jsonBuilder.Append("]");
                            jsonBuilder.Append("}");
                        }
                        jsonBuilder.Append("]");
                        jsonBuilder.Append("}]");
                        Response.Write(jsonBuilder.ToString());
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }


        public void GetAllPrivilegeCategorys()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPrivilegeCategoryArgs sargs = new SearchPrivilegeCategoryArgs();
                    if (!string.IsNullOrEmpty(pagingParm.SortOrder.Trim()))
                    {
                        sargs.OrderBy = pagingParm.SortOrder;
                    }
                    else
                        sargs.OrderBy = "[Sequence] ASC";
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchPrivilegeCategory(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError("查询菜单组：" + ex.Message);
            }
        }

        public void ListByCategory()
        {
            try
            {
                string PCategoryID = Request["CategoryID"];
                using (ProxyBE p = new ProxyBE())
                {
                    List<Privilege> privileges = p.Client.GetPrivilegesByCategoryID(SenderUser, new Guid(PCategoryID));
                    privileges.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                    Response.Write(JSONHelper.Object2DataSetJson(privileges));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// detail or edit
        /// </summary>
        public void AddOrUpdate()
        {
            try
            {
                Guid PrivilegeID = new Guid(Request["PrivilegeID"]);
                using (ProxyBE p = new ProxyBE())
                {
                    Privilege pl = p.Client.GetPrivilege(SenderUser, PrivilegeID);
                    if (pl != null)
                    {
                        Response.Write(JSONHelper.Object2Json(pl));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(null));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        public void NewPrivilege()
        {
            try
            {
                Guid CategoryID = new Guid(Request["CategoryID"]);
                Privilege pl = new Privilege();
                pl.PrivilegeID = Guid.NewGuid();
                pl.PageURL = "";
                pl.PrivilegeName = "";
                pl.PrivilegeCode = "";
                pl.Description = "";
                pl.IsDisabled = false;
                pl.CategoryID = CategoryID;
                pl.Sequence = 0;
                Response.Write(JSONHelper.Object2Json(pl));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// Add Or Update(save)
        /// </summary>
        public void Save()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Privilege pl = p.Client.GetPrivilege(SenderUser, parm.PrivilegeID);
                    if (pl == null)
                    {
                        pl = new Privilege();
                    }
                    pl.PrivilegeID = parm.PrivilegeID;
                    pl.PageURL = parm.PageURL;
                    pl.IconClass = parm.IconClass;
                    pl.PrivilegeName = parm.PrivilegeName;
                    pl.PrivilegeCode = parm.PrivilegeCode;
                    pl.Description = parm.Description;
                    pl.IsDisabled = parm.IsDisabled;
                    pl.CategoryID = parm.CategoryID;
                    pl.Sequence = parm.Sequence;
                    bool flag = p.Client.PrivilegeCodeIsDuplicated(SenderUser, pl);
                    if (flag)
                    {
                        throw new Exception("已经存在该编码，请重新填写!");
                    }
                    SavePrivilegeArgs args = new SavePrivilegeArgs();
                    args.Privilege = pl;
                    args.PrivilegeItems = new List<PrivilegeItem>();
                    string PriviegeItems = Request["PriviegeItems"].ToString();
                    JsonData sj = JsonMapper.ToObject(PriviegeItems);
                    if (sj.Count > 0)
                    {
                        //遍历对象元素，保存                        
                        foreach (JsonData item in sj)
                        {
                            PrivilegeItem pi = new PrivilegeItem();
                            pi.PrivilegeItemID = Guid.NewGuid();
                            pi.PrivilegeID = pl.PrivilegeID;
                            pi.PrivilegeItemCode = item["Code"].ToString();
                            pi.PrivilegeItemName = item["Name"].ToString();
                            pi.IsDisabled = false;
                            pi.Description = "";
                            args.PrivilegeItems.Add(pi);
                        }
                    }
                    p.Client.SavePrivilege(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SavePrivilegeCategory()
        {
            try
            {
                using (ProxyBE op = new ProxyBE())
                {
                    PrivilegeCategory obj = op.Client.GetPrivilegeCategory(SenderUser, CategoryParm.CategoryID);
                    if (obj == null)
                    {
                        obj = new PrivilegeCategory();
                    }
                    obj.CategoryID = CategoryParm.CategoryID;
                    obj.CategoryName = CategoryParm.CategoryName;
                    obj.IconClass = CategoryParm.IconClass;
                    obj.Sequence = CategoryParm.Sequence;
                    SavePrivilegeCategoryArgs args = new SavePrivilegeCategoryArgs();
                    args.PrivilegeCategory = obj;
                    op.Client.SavePrivilegeCategory(SenderUser, args);
                }

                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 主菜单添加后，子菜单同步加载
        /// </summary>
        public void GetSubCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {

                    List<PrivilegeCategory> Pcate = p.Client.GetPrivilegeCategorys(SenderUser);
                    PrivilegeCategory pc = new PrivilegeCategory();
                    Pcate.Insert(0, pc);
                    Pcate.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                    Response.Write(JSONHelper.Object2JSON(Pcate));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        public void SearchFavoritePrivilege()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchFavoriteArgs args = new SearchFavoriteArgs();
                    args.OrderBy = "[CategoryID],[Sequence]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.UserID = CurrentUser.UserID;
                    SearchResult sr = p.Client.SearchFavorite(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
        public void SearchPrivilegeByCurrentUser()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPrivilegeArgs args = new SearchPrivilegeArgs();
                    args.OrderBy = "[MainSequence],[Sequence]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    //用户
                    if (CurrentUser.UserType == (int)UserType.U)
                    {
                        args.RKeyUserIDs = new List<Guid>() { CurrentUser.UserID };
                    }
                    //经销商
                    if (CurrentUser.UserType == (int)UserType.D)
                    {
                        args.CategoryIDs = new List<Guid>();
                        args.CategoryIDs.Add(Guid.Parse(CategoryID));
                    }
                    args.IsDisabled = true;
                    SearchResult sr = p.Client.SearchPrivilege(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
        public void SaveFavoritePrivilege()
        {
            try
            {
                string PrivilegeIDs = Request["PrivilegeIDs"];
                if (string.IsNullOrEmpty(PrivilegeIDs))
                {
                    throw new Exception("请选择需要创建快捷链接的菜单");
                }
                string[] IDs = PrivilegeIDs.Split(',');
                SaveFavoritesArgs args = new SaveFavoritesArgs();
                args.Favorites = new List<Favorite>();
                foreach (string ID in IDs)
                {
                    Favorite fr = new Favorite();
                    fr.UserID = CurrentUser.UserID;
                    fr.PrivilegeID = new Guid(ID);
                    args.Favorites.Add(fr);
                }
                using (ProxyBE p = new ProxyBE())
                {
                    p.Client.SaveFavorites(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }
        public void DeleteFavoritePrivile()
        {
            try
            {
                string PrivilegeID = Request["PrivilegeID"];
                if (string.IsNullOrEmpty(PrivilegeID))
                {
                    throw new Exception("请选择需要删除的快捷链接菜单。");
                }

                using (ProxyBE p = new ProxyBE())
                {
                    p.Client.DeleteFavorite(SenderUser, CurrentUser.UserID, new Guid(PrivilegeID));
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }
    }
}