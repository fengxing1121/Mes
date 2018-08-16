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
    /// ComponentTypeHandler 的摘要说明
    /// </summary>
    public class ComponentTypeHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        ComponentTypeParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";

                if (!string.IsNullOrEmpty(method))
                {
                    parm = new ComponentTypeParm(context);
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
                    SearchComponentTypeArgs args = new SearchComponentTypeArgs();
                    if (!string.IsNullOrEmpty(parm.ComponentTypeCode))
                    {
                        args.ComponentTypeCode = parm.ComponentTypeCode;
                    }
                    if (!string.IsNullOrEmpty(parm.ComponentTypeName))
                    {
                        args.ComponentTypeName = parm.ComponentTypeName;
                    }
                    if (!string.IsNullOrEmpty(Request["Status"]))
                    {
                        args.Status = Convert.ToBoolean(Request["Status"]);
                    }
                    args.OrderBy = string.IsNullOrEmpty(pagingParm.SortOrder.Trim()) ? "ComponentTypeID" : pagingParm.SortOrder;
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    //Where

                    SearchResult sr = p.Client.SearchComponentType(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void NewComponentType()
        {
            try
            {
                WriteJsonSuccess(null, new ComponentType());
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveComponentType()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    ComponentType model = p.Client.GetComponentType(SenderUser, parm.ComponentTypeID);
                    if (model == null)
                    {
                        model = new ComponentType();
                    }
                    model.ComponentTypeName = parm.ComponentTypeName;
                    model.ComponentTypeCode = parm.ComponentTypeCode;
                    model.ParentID = parm.ParentID;
                    model.Status = parm.Status;
                    p.Client.SaveComponentType(SenderUser, model);
                    WriteJsonSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetComponentType()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    int componentTypeID = Convert.ToInt32(Request["ComponentTypeID"]);
                    ComponentType model = p.Client.GetComponentType(SenderUser, componentTypeID);
                    if (model == null)
                    {
                        WriteError("所查找组件类型不存在。");
                    }
                    else
                    {
                        WriteJsonSuccess(Const.SuccessMsg, model);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
                throw;
            }
        }

        public void LoadBomComponentTypes()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    List<ComponentType> ComponentTypeList = p.Client.GetAllComponentTypes(SenderUser);
                    ComponentTypeList = ComponentTypeList.Where(x => x.Status == false).ToList();
                    if (ComponentTypeList != null)
                    {
                        Response.Write(JSONHelper.Object2JSON(ComponentTypeList));
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