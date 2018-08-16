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
    /// MaterialsPriceHandler 的摘要说明
    /// </summary>
    public class MaterialsPriceHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        MaterialQuotePriceParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new MaterialQuotePriceParm(context);
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
                    SearchMaterialQuotePriceArgs args = new SearchMaterialQuotePriceArgs();
                    args.OrderBy = "MaterialCode";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

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

                    if (!string.IsNullOrEmpty(Request["MaterialName"]))
                    {
                        args.MaterialName = Request["MaterialName"].ToString();
                    }

                    if (!string.IsNullOrEmpty(Request["Style"]))
                    {
                        args.Style = Request["Style"].ToString();
                    }

                    if (!string.IsNullOrEmpty(Request["Color"]))
                    {
                        args.Color = Request["Color"].ToString();
                    }

                    SearchResult sr = p.Client.SearchMaterialQuotePrice(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void NewMaterialPrice()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    var materialPrice = p.Client.GetMaterialQuotePrice(null, parm.MaterialID);
                    if (materialPrice != null)
                    {
                        WriteError("该材料已确定价格,请选择其他材料");
                    }
                    else
                    {
                        MaterialQuotePrice MaterialQuotePrice = new MaterialQuotePrice();
                        MaterialQuotePrice.MaterialID = parm.MaterialID;
                        MaterialQuotePrice.Price = parm.Price;

                        SaveMaterialQuotePriceArgs args = new SaveMaterialQuotePriceArgs();
                        args.MaterialQuotePrice = MaterialQuotePrice;

                        p.Client.SaveMaterialQuotePrice(SenderUser, args);
                        WriteSuccess();
                    }
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void ModifyMaterialPrice()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    MaterialQuotePrice materialQuotePrice = p.Client.GetMaterialQuotePrice(SenderUser, parm.MaterialID);
                    if (materialQuotePrice == null)
                    {
                        materialQuotePrice.MaterialID = parm.MaterialID;
                    }
                    materialQuotePrice.Price = parm.Price;

                    SaveMaterialQuotePriceArgs args = new SaveMaterialQuotePriceArgs();
                    args.MaterialQuotePrice = materialQuotePrice;

                    p.Client.SaveMaterialQuotePrice(SenderUser, args);
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