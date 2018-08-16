using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// MaterialHandler 的摘要说明
    /// </summary>
    public class MaterialHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        MaterialParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new MaterialParm(context);
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

        public void SearchMaterials()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchMaterialArgs args = new SearchMaterialArgs();
                    args.OrderBy = "Created Desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    if (!string.IsNullOrEmpty(Request["MaterialID"]))
                    {
                        args.MaterialIDs = new List<Guid>();
                        args.MaterialIDs.Add(Guid.Parse(Request["MaterialID"].ToString()));
                    }

                    if (!string.IsNullOrEmpty(Request["MaterialCode"]))
                    {
                        args.MaterialCode = Request["MaterialCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["MaterialName"]))
                    {
                        args.MaterialName = Request["MaterialName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["Category"]))
                    {
                        args.Categorys = new List<string>();
                        args.Categorys.Add(Request["Category"].ToString());
                    }
                    if (!string.IsNullOrEmpty(Request["SubCategory"]))
                    {
                        args.SubCategorys = new List<string>();
                        args.SubCategorys.Add(Request["SubCategory"].ToString());
                    }
                    SearchResult sr = p.Client.SearchMaterial(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveMaterial()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (parm.Category == null || parm.Category == "")
                    {
                        throw new Exception("请填写材料类型。");
                    }
                    //if (parm.SubCategory == null || parm.SubCategory == "")
                    //{
                    //    throw new Exception("请选择对应子类型。");
                    //}
                    //Guid guidCategory = new Guid(parm.Category);
                    //Guid guidSubCategory = new Guid(parm.SubCategory);
                    //Category category = p.Client.GetCategory(SenderUser, guidCategory);
                    //Category subCategory = p.Client.GetCategory(SenderUser, guidSubCategory);

                    SaveMaterialArgs args = new SaveMaterialArgs();
                    Material material = p.Client.GetMaterial(SenderUser, parm.MaterialID);
                    if (material == null)
                    {
                        material = new Material();
                        material.MaterialID = parm.MaterialID;
                    }
                    material.MaterialID = parm.MaterialID;
                    material.Category = parm.Category;
                    material.SubCategory = "";
                    material.MaterialCode = parm.MaterialCode;
                    material.MaterialName = parm.MaterialName;
                    material.Style = parm.Style;
                    material.Unit = parm.Unit;
                    material.Color = parm.Color;
                    material.Deepth = parm.Deepth;
                    material.QuotedPrice = parm.QuotedPrice;
                    material.SafetyStock_Qty = parm.SafetyStock_Qty;
                    material.Withholding_Qty = parm.Withholding_Qty;
                    material.ImageUrl = "";
                    material.Remark = "";
                    args.Material = material;
                    p.Client.SaveMaterial(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetMaterial()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Material material = p.Client.GetMaterial(SenderUser, parm.MaterialID);
                    Response.Write(JSONHelper.Object2Json(material));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void NewMaterial()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Material material = new Material();
                    material.MaterialID = Guid.NewGuid();
                    material.MaterialCode = "";
                    material.MaterialName = "";
                    material.Style = "";
                    material.Color = "";
                    material.Deepth = 0;
                    material.Unit = "";
                    material.SafetyStock_Qty = 0;
                    material.Withholding_Qty = 0;
                    Response.Write(JSONHelper.Object2Json(material));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        /// <summary>
        /// 获取材料类型
        /// </summary>
        public void GetCategories()
        {

            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "MaterialType");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);

                        Category wf = new Category();
                        //wf.CategoryName = "请选择";
                        //wf.CategoryID = Guid.Empty;
                        //lists.Insert(0, wf);
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
        /// 获取子类型
        /// </summary>
        public void GetSubCategories()
        {
            Guid categoryid = new Guid(Request["id"]);
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (categoryid != Guid.Empty)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, categoryid);
                        Category wf = new Category();
                        //wf.CategoryName = "请选择";
                        //wf.CategoryID = Guid.Empty;
                        //lists.Insert(0, wf);
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