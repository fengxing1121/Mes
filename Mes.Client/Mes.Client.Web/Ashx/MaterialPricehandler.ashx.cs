using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.BE.Objects;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// MaterialPricehandler 的摘要说明
    /// </summary>
    public class MaterialPricehandler : BaseHttpHandler
    {
        #region ===================初始加载=====================

        Material2SupplierParm parm;

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new Material2SupplierParm(context);
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

        public void SearchMaterialPrice()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchMaterial2SupplierArgs sargs = new SearchMaterial2SupplierArgs();

                    sargs.OrderBy = "[Price]";
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;

                    //Where
                    //if (!string.IsNullOrEmpty(parm.))
                    //{
                    //    sargs.MaterialName = parm.MaterialName;
                    //}
                    //if (!string.IsNullOrEmpty(parm.Category))
                    //{
                    //    sargs.Category = parm.Category;
                    //}
                    //if (!string.IsNullOrEmpty(parm.SubCategory))
                    //{
                    //    sargs.SubCategory = parm.SubCategory;
                    //}
                    //if (!string.IsNullOrEmpty(parm.Color))
                    //{
                    //    sargs.Color = parm.Color;
                    //}
                    //if (!string.IsNullOrEmpty(parm.Style))
                    //{
                    //    sargs.Style = parm.Style;
                    //}
                    SearchResult sr = p.Client.SeachMaterial2Supplier(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}