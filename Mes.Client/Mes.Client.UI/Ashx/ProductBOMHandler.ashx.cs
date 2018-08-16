using Mes.Client.Model.Constants;
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
using System.Web;

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// ProductBOMHandler 的摘要说明
    /// </summary>
    public class ProductBOMHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        ProductBOMParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";

                if (!string.IsNullOrEmpty(method))
                {
                    parm = new ProductBOMParm(context);
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

        public void List()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchProductBOMArgs args = new SearchProductBOMArgs();
                    if (!string.IsNullOrEmpty(parm.BOMID))
                    {
                        args.BOMID = parm.BOMID;
                    }
                    if (!string.IsNullOrEmpty(parm.ProductCode))
                    {
                        args.ProductCode = parm.ProductCode;
                    }
                    if (!string.IsNullOrEmpty(parm.ProductName))
                    {
                        args.ProductName = parm.ProductName;
                    }
                    if (!string.IsNullOrEmpty(Request["Status"]))
                    {
                        args.Status = Convert.ToBoolean(Request["Status"]);
                    }
                    if (!string.IsNullOrEmpty(Request["CreatedFrom"]))
                    {
                        args.CreatedFrom = parm.CreatedFrom;
                    }
                    if (!string.IsNullOrEmpty(Request["CreatedTo"]))
                    {
                        args.CreatedTo = parm.CreatedTo.AddDays(1);
                    }
                    args.OrderBy = string.IsNullOrEmpty(pagingParm.SortOrder.Trim()) ? "ID" : pagingParm.SortOrder;
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    //Where

                    SearchResult sr = p.Client.SearchProductBOM(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void ImportBOM()
        {
            try
            {
                string bomID = Request["BOMID"];
                if (string.IsNullOrEmpty(bomID))
                {
                    throw new Exception("BOMID为空或者不存在");
                }
                string filePath = Request["FilePath"];
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new Exception("要导入的BOM文件路径错误，请检查后重新上传");
                }
                WriteJsonSuccess("上传成功");
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}