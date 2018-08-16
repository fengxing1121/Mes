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
    /// SupplierHandler 的摘要说明
    /// </summary>
    public class SupplierHandler : BaseHttpHandler
    {
        SupplierParm parm;
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            parm = new SupplierParm(context);

            if (!string.IsNullOrEmpty(method))
            {
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

        public void SearchSuppliers()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchSupplierArgs args = new SearchSupplierArgs();

                    args.OrderBy = "[Created] Desc";
                    if (!string.IsNullOrEmpty(parm.Category))
                    {
                        args.Category = parm.Category;
                    }
                    if (!string.IsNullOrEmpty(parm.SupplierCode))
                    {
                        args.SupplierCode = parm.SupplierCode;
                    }

                    if (!string.IsNullOrEmpty(parm.SupplierName))
                    {
                        args.SupplierName = parm.SupplierName;
                    }

                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        args.Mobile = parm.Mobile;
                    }

                    if (!string.IsNullOrEmpty(parm.Province))
                    {
                        args.Province = parm.Province;
                    }

                    if (!string.IsNullOrEmpty(parm.City))
                    {
                        args.City = parm.City;
                    }
                    if (!string.IsNullOrEmpty(parm.Address))
                    {
                        args.Address = parm.Address;
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchSupplier(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                //WriteError(ex.Message, ex);
                throw ex;
            }
        }

        public void NewSupplier()
        {
            try
            {
                Supplier supplier = new Supplier();
                supplier.SupplierID = Guid.NewGuid();
                supplier.SupplierName = "";
                supplier.Address = "";
                supplier.SupplierCode = "";
                supplier.Mobile = "";
                supplier.Tel = "";
                supplier.Province = "";
                supplier.City = "";
                supplier.Email = "";
                supplier.LinkMan = "";
                supplier.Remark = "";
                Response.Write(JSONHelper.Object2Json(supplier));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveSupplier()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    if (Request["Province"] == "")
                    {
                        throw new Exception("请选择省份");
                    }
                    if (Request["City"] == "请选择城市")
                    {
                        throw new Exception("请选择城市");
                    }
                    Supplier supplier = p.Client.GetSupplier(null, parm.SupplierID);
                    if (supplier == null)
                    {
                        supplier = new Supplier();
                        supplier.SupplierID = parm.SupplierID;
                    }
                    supplier.SupplierName = parm.SupplierName.Trim();
                    supplier.LinkMan = parm.LinkMan.Trim();
                    supplier.SupplierCode = parm.SupplierCode.Trim();
                    supplier.Email = parm.Email.Trim();
                    supplier.Mobile = parm.Mobile.Trim();
                    supplier.Tel = parm.Tel.Trim();
                    supplier.Category = parm.Category.Trim();
                    supplier.Remark = parm.Remark.Trim();
                    supplier.Province = parm.Province;
                    supplier.City = parm.City;
                    supplier.Address = parm.Address.Trim();
                    SaveSupplierArgs args = new SaveSupplierArgs();
                    args.Supplier = supplier;
                    p.Client.SaveSupplier(SenderUser, args);
                    WriteSuccess();

                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void GetSupplier()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid supplierid = new Guid(Request["SupplierID"]);
                    Supplier cust = p.Client.GetSupplier(SenderUser, supplierid);
                    if (cust == null)
                    {
                        throw new Exception("所查找供应商不存在。");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(cust));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取供应商类型
        /// </summary>
        public void GetCategories()
        {

            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "SupplierType");
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
    }
}