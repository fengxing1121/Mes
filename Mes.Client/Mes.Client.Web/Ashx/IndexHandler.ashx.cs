using Mes.Client.Service;
using Mes.Client.Service.BE;
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
    /// IndexHandler 的摘要说明
    /// </summary>
    public class IndexHandler : BaseHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            if (!string.IsNullOrEmpty(method))
            {
                //parm = new PrivilegeParm(context);
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
        public void InitMenus()
        {
            try
            {
                //权限菜单模块
                StringBuilder jsonBuilder = new StringBuilder();
                jsonBuilder.Append("{menus:");
                jsonBuilder.Append("[");

                using (ProxyBE p = new ProxyBE())
                {
                    SearchPrivilegeCategoryArgs sargsPCategory = new SearchPrivilegeCategoryArgs();
                    sargsPCategory.OrderBy = "[Sequence] ASC";
                    sargsPCategory.PrivilegeIDs = CurrentUser.PrivilegeIDs;
                    SearchResult srPCategory = p.Client.SearchPrivilegeCategory(SenderUser, sargsPCategory);
                    DataTable dt = srPCategory.DataSet.Tables[0];

                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        jsonBuilder.Append("{");
                        jsonBuilder.AppendFormat("\"menuid\":\"{0}\",", row["CategoryID"].ToString());
                        jsonBuilder.AppendFormat("\"menuname\":\"{0}\",", row["CategoryName"].ToString());
                        jsonBuilder.AppendFormat("\"url\":\"{0}\",", "#");

                        SearchPrivilegeArgs pa = new SearchPrivilegeArgs();
                        pa.OrderBy = "[Sequence] ASC";
                        pa.CategoryIDs = new List<Guid>() { new Guid(row["CategoryID"].ToString()) };
                        pa.PrivilegeIDs = CurrentUser.PrivilegeIDs;
                        pa.IsDisabled = false;
                        SearchResult spa = p.Client.SearchPrivilege(SenderUser, pa);
                        if (spa.DataSet.Tables[0].Rows.Count != 0)
                        {
                            string iconcls = row["IconClass"].ToString();
                            if (string.IsNullOrEmpty(iconcls))
                            {
                                iconcls = "icon-sys";
                            }
                            jsonBuilder.AppendFormat("\"icon\":\"{0}\",", iconcls);
                            jsonBuilder.AppendFormat("\"menus\":");
                            jsonBuilder.Append("[");
                            foreach (DataRow rw in spa.DataSet.Tables[0].Rows)
                            {
                                iconcls = rw["IconClass"].ToString();
                                if (string.IsNullOrEmpty(iconcls))
                                {
                                    iconcls = "icon-nav";
                                }
                                jsonBuilder.Append("{");
                                jsonBuilder.AppendFormat("\"menuid\":\"{0}\",", rw["PrivilegeID"].ToString());
                                jsonBuilder.AppendFormat("\"menuname\":\"{0}\",", rw["PrivilegeName"].ToString());
                                jsonBuilder.AppendFormat("\"url\":\"{0}\",", rw["PageURL"].ToString());
                                jsonBuilder.AppendFormat("\"icon\":\"{0}\"", iconcls);
                                jsonBuilder.Append("}");
                                jsonBuilder.Append(",");
                            }
                            StringBuilder sb = new StringBuilder();
                            sb.Append(jsonBuilder.ToString().TrimEnd(','));
                            jsonBuilder = sb;
                            jsonBuilder.Append("]");
                            jsonBuilder.Replace(",]", "]");
                        }
                        else
                        {
                            jsonBuilder.AppendFormat("\"icon\":\"{0}\",", "icon-sys");
                            jsonBuilder.Append("\"menus\":[]");
                        }
                        jsonBuilder.Append("}");
                        if (i != dt.Rows.Count - 1)
                        {
                            jsonBuilder.Append(",");
                        }
                        i++;
                    }
                    jsonBuilder.Append("]");
                    jsonBuilder.Append("}");
                    Response.Write(jsonBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        public void InitShortLink()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchFavoriteArgs args = new SearchFavoriteArgs();
                    args.OrderBy = "[FavoriteCategory],[Sequence]";
                    args.UserID = CurrentUser.UserID;
                    SearchResult sr = p.Client.SearchFavorite(SenderUser, args);
                    DataTable tb_category = sr.DataSet.Tables[0].DefaultView.ToTable(true, "FavoriteCategory");

                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("{\"menus\":");
                    jsonBuilder.Append("[");

                    bool isCategoryFirst = true;

                    foreach (DataRow row in tb_category.Rows)
                    {
                        if (!isCategoryFirst)
                        {
                            jsonBuilder.Append(",");
                        }
                        else
                        {
                            isCategoryFirst = false;
                        }
                        DataRow[] row_items = sr.DataSet.Tables[0].Select(string.Format("FavoriteCategory='{0}'", row["FavoriteCategory"].ToString()));
                        jsonBuilder.Append("{");
                        jsonBuilder.AppendFormat("\"menuid\":\"{0}\",", Guid.Empty);
                        jsonBuilder.AppendFormat("\"menuname\":\"{0}\",", row["FavoriteCategory"].ToString());
                        jsonBuilder.AppendFormat("\"url\":\"{0}\",", "#");
                        if (row_items.Length == 0)
                        {
                            jsonBuilder.AppendFormat("\"icon\":\"{0}\",", "icon-sys");
                            jsonBuilder.Append("\"menus\":[]");
                            jsonBuilder.Append("}");
                            continue;
                        }
                        jsonBuilder.AppendFormat("\"menus\":");
                        jsonBuilder.Append("[");
                        bool isItemFirst = true;
                        foreach (DataRow dr in row_items)
                        {
                            string iconcls = dr["IconClass"].ToString();
                            if (string.IsNullOrEmpty(iconcls))
                            {
                                iconcls = "icon-nav";
                            }
                            if (!isItemFirst)
                            {
                                jsonBuilder.Append(",");
                            }
                            else
                            {
                                isItemFirst = false;
                            }
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"menuid\":\"{0}\",", dr["PrivilegeID"].ToString());
                            jsonBuilder.AppendFormat("\"menuname\":\"{0}\",", dr["PrivilegeName"].ToString());
                            jsonBuilder.AppendFormat("\"url\":\"{0}\",", dr["PageURL"].ToString());
                            jsonBuilder.AppendFormat("\"icon\":\"{0}\"", iconcls);
                            jsonBuilder.Append("}");
                        }
                        jsonBuilder.Append("]}");
                    }
                    jsonBuilder.Append("]");
                    jsonBuilder.Append("}");
                    Response.Write(jsonBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }
    }
}