using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// CategoryHandler 的摘要说明
    /// </summary>
    public class CategoryHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        CategoryParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";

                if (!string.IsNullOrEmpty(method))
                {
                    parm = new CategoryParm(context);
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
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
        #endregion

        public void SearchCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchCategoryArgs args = new SearchCategoryArgs();
                    //args.ParentID = ;                    
                    args.OrderBy = "[Sequence]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (parm.ParentID != Guid.Empty)
                    {
                        args.ParentID = parm.ParentID;
                    }

                    if (!string.IsNullOrEmpty(Request["SearchCategoryCode"]))
                    {
                        args.CategoryCode = Request["SearchCategoryCode"].ToString();
                    }

                    if (!string.IsNullOrEmpty(Request["SearchCategoryName"]))
                    {
                        args.CategoryName = Request["SearchCategoryName"].ToString();
                    }
                    //Where
                    SearchResult sr = p.Client.SearchCategory(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                //WriteError(ex.Message, ex);
            }
        }
        public void NewCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SaveCategoryArgs args = new SaveCategoryArgs();
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, "CK");
                    if (category == null)
                    {
                        category = new Category();
                        category.CategoryID = Guid.NewGuid();

                        category.CategoryCode = "CK";
                        category.CategoryName = "仓库资料";
                        category.ParentID = Guid.Empty;
                        category.Sequence = 0;
                        category.ShortName = "";
                        args.Category = category;
                        p.Client.SaveCategory(SenderUser, args);
                    }

                    Category subCategory = new Category();
                    subCategory.CategoryID = Guid.NewGuid();

                    subCategory.ParentID = category.CategoryID;
                    category.CategoryCode = "";
                    category.CategoryName = "";
                    category.Sequence = 0;
                    category.ShortName = "";
                    Response.Write(JSONHelper.Object2Json(subCategory));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        public void SaveCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SaveCategoryArgs args = new SaveCategoryArgs();
                    Category category = p.Client.GetCategory(SenderUser, parm.CategoryID);
                    if (category == null)
                    {
                        category = new Category();
                        category.CategoryID = parm.CategoryID;
                    }

                    category.CategoryCode = parm.CategoryCode;
                    category.CategoryName = parm.CategoryName;
                    category.ParentID = parm.ParentID;
                    category.Sequence = parm.Sequence;
                    category.ShortName = parm.ShortName;
                    category.IsDisabled = Convert.ToBoolean(parm.IsDisabled);
                    args.Category = category;
                    p.Client.SaveCategory(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        public void DeleteCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (parm.CategoryID == Guid.Empty)
                    {
                        throw new Exception("请选择需要删除的数据字典。");
                    }
                    p.Client.DeleteCategory(SenderUser, parm.CategoryID);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        public void GetCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategory(SenderUser, parm.CategoryID);
                    Response.Write(JSONHelper.Object2Json(category));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        public void GetCategoryChildren()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, parm.CategoryCode);
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        Response.Write(JSONHelper.Object2Json(lists));
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(new List<Category>()));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        public void CategoryTree()
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[{");
            jsonBuilder.Append("\"id\":\"" + Guid.Empty.ToString() + "\"");
            jsonBuilder.Append(",\"text\":\"数据字典\"");
            jsonBuilder.Append(",\"attributes\":{\"ParentID\":\"" + Guid.Empty.ToString() + "\"}");
            StringBuilder jsontree = initTree(Guid.Empty, jsonBuilder);
            jsontree.Append("}]");
            Response.Write(jsontree.ToString());
        }

        private StringBuilder initTree(Guid CategoryID, StringBuilder jsonBuilder)
        {
            using (ProxyBE p = new ProxyBE())
            {
                List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, CategoryID);
                lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                if (lists.Count == 0)
                {
                    jsonBuilder.AppendFormat(",\"state\":\"open\"");
                    return jsonBuilder;
                }
                else
                {
                    jsonBuilder.AppendFormat(",\"state\":\"closed\"");
                    jsonBuilder.AppendFormat(",\"children\":");
                    jsonBuilder.Append("[");
                    foreach (Category item in lists)
                    {
                        jsonBuilder.Append("{");
                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.CategoryID);
                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.CategoryName);

                        jsonBuilder.Append(",\"attributes\":{\"ParentID\":\"" + item.ParentID + "\",\"CategoryCode\":\"" + item.CategoryCode + "\"}");
                        initTree(item.CategoryID, jsonBuilder);
                        jsonBuilder.Append("}");
                        jsonBuilder.Append(",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("]");
                }
            }
            return jsonBuilder;
        }
        public void RegionTree()
        {
            using (ProxyBE p = new ProxyBE())
            {
                StringBuilder jsonBuilder = new StringBuilder();
                jsonBuilder.Append("[{");
                jsonBuilder.Append("\"id\":\"\"");
                jsonBuilder.Append(",\"text\":\"省市区\"");
                jsonBuilder.Append(",\"attributes\":{\"ParentID\":\"" + Guid.Empty.ToString() + "\"}");
                Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, "Region");
                if (category != null)
                {
                    jsonBuilder = initTree(category.CategoryID, jsonBuilder);
                }
                jsonBuilder.Append("}]");
                Response.Write(jsonBuilder.ToString());
            }
        }

        public void GetCategoryTreeByCategoryCode()
        {
            string CategoryCode = "";
            if (Request["CategoryCode"] != null)
            {
                CategoryCode = Request["CategoryCode"].ToString();
            }
            string RootName = "数据字典";
            if (Request["RootName"] != null)
            {
                RootName = Request["RootName"].ToString();
            }

            Category c = null;
            using (ProxyBE p = new ProxyBE())
            {
                c = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, CategoryCode);
                StringBuilder jsonBuilder = new StringBuilder();
                jsonBuilder.Append("[{");
                jsonBuilder.Append("\"id\":\"\"");
                jsonBuilder.Append(",\"text\":\"" + RootName + "\"");
                jsonBuilder.Append(",\"attributes\":{\"ParentID\":\"" + Guid.Empty.ToString() + "\"}");
                StringBuilder jsontree = initTree(c.CategoryID, jsonBuilder);
                jsontree.Append("}]");
                Response.Write(jsontree.ToString());
            }
        }

        public void LoadCategoryTreeByRootID()
        {
            Guid RootID = Guid.Empty;
            if (Request["RootID"] != null)
            {
                RootID = new Guid(Request["RootID"]);
            }
            string RootName = "数据字典";
            if (Request["RootName"] != null)
            {
                RootName = Request["RootName"].ToString();
            }
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[{");
            jsonBuilder.Append("\"id\":\"" + Guid.Empty.ToString() + "\"");
            jsonBuilder.Append(",\"text\":\"" + RootName + "\"");
            jsonBuilder.Append(",\"attributes\":{\"ParentID\":\"" + Guid.Empty.ToString() + "\"}");
            StringBuilder jsontree = initTree(RootID, jsonBuilder);
            jsontree.Append("}]");
            Response.Write(jsontree.ToString());
        }
        public void LoadCategoryTreeByCategoryCode()
        {
            string CategoryCode = "";
            if (Request["CategoryCode"] != null)
            {
                CategoryCode = Request["CategoryCode"].ToString();
            }
            string RootName = "数据字典";
            if (Request["RootName"] != null)
            {
                RootName = Request["RootName"].ToString();
            }

            Category c = null;
            using (ProxyBE p = new ProxyBE())
            {
                c = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, Guid.Empty, CategoryCode);
                StringBuilder jsonBuilder = new StringBuilder();
                jsonBuilder.Append("[{");
                jsonBuilder.Append("\"id\":\"\"");
                jsonBuilder.Append(",\"text\":\"" + RootName + "\"");
                jsonBuilder.Append(",\"attributes\":{\"ParentID\":\"" + Guid.Empty.ToString() + "\"}");
                StringBuilder jsontree = initOperation(c.CategoryID, jsonBuilder);
                jsontree.Append("}]");
                Response.Write(jsontree.ToString());
            }
        }

        private StringBuilder initOperation(Guid CategoryID, StringBuilder jsonBuilder)
        {
            using (ProxyBE p = new ProxyBE())
            {
                Guid PrivilegeID = new Guid(Request["PrivilegeID"]);
                List<PrivilegeItem> listItems = p.Client.GetPrivilegeItemByPrivilegeID(SenderUser, PrivilegeID);
                List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, CategoryID);
                lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                if (lists.Count == 0)
                {
                    return null;
                }
                else
                {
                    if (CategoryID != Guid.Empty)
                    {
                        jsonBuilder.AppendFormat(",\"state\":\"open\"");
                    }
                    jsonBuilder.AppendFormat(",\"children\":");
                    jsonBuilder.Append("[");
                    foreach (Category item in lists)
                    {
                        jsonBuilder.Append("{");
                        jsonBuilder.AppendFormat("\"id\":\"{0}\"", item.CategoryCode);
                        jsonBuilder.AppendFormat(",\"text\":\"{0}\"", item.CategoryName);
                        if (listItems.Find(li => li.PrivilegeItemCode == item.CategoryCode) != null)
                        {
                            jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                        }
                        jsonBuilder.Append(",\"attributes\":{\"CategoryID\":\"" + item.CategoryID + "\",\"ParentID\":\"" + item.CategoryID + "\"}");
                        initTree(item.CategoryID, jsonBuilder);
                        jsonBuilder.Append("}");
                        jsonBuilder.Append(",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("]");
                }
            }
            return jsonBuilder;
        }

        /// <summary>
        /// 材质风格
        /// </summary>
        public void GetMaterialStyle()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "MaterialStyle");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public void GetCabinetName()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "ProductName");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 产品类型
        /// </summary>
        public void GetCabinetType()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "ProductType");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        Category wf = new Category();
                        wf.CategoryName = "请选择";
                        wf.CategoryID = Guid.Empty;
                        lists.Insert(0, wf);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 颜色类型
        /// </summary>
        public void GetColorType()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "ColorType");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 移门名称
        /// </summary>
        public void GetDoorName()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "DoorName");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 材质类型
        /// </summary>
        public void GetMaterialCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "MaterialCategory");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 单位类型
        /// </summary>
        public void GetUnitCategory()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "UnitCategory");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}