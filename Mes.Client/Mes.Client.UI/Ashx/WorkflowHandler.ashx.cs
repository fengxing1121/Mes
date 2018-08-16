using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Reflection;
using System.Web;

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// WorkflowHandler 的摘要说明
    /// </summary>
    public class WorkflowHandler : BaseHttpHandler
    {
        WorkFlowParm parm;
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            parm = new WorkFlowParm(context);
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

        public void SearchWorkFlow()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWorkFlowArgs args = new SearchWorkFlowArgs();

                    args.OrderBy = "SortNo asc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(Request["WorkFlowID"]))
                    {
                        args.WorkFlowID = parm.WorkFlowID;
                    }
                    if (!string.IsNullOrEmpty(Request["WorkFlowCode"]))
                    {
                        args.WorkFlowCode = parm.WorkFlowCode;
                    }
                    if (!string.IsNullOrEmpty(Request["WorkFlowName"]))
                    {
                        args.WorkFlowName = parm.WorkFlowName;
                    }
                    if (!string.IsNullOrEmpty(Request["ImageUrl"]))
                    {
                        args.ImageUrl = parm.ImageUrl;
                    }
                    if (!string.IsNullOrEmpty(Request["Remark"]))
                    {
                        args.Remark = parm.Remark;
                    }
                    if (!string.IsNullOrEmpty(Request["Created"]))
                    {
                        args.Created = parm.Created;
                    }
                    if (!string.IsNullOrEmpty(Request["CreatedBy"]))
                    {
                        args.CreatedBy = parm.CreatedBy;
                    }

                    SearchResult sr = p.Client.SearchWorkFlow(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void SaveWorkFlow()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkFlow obj = new WorkFlow();
                    if (!string.IsNullOrEmpty(Request["WorkFlowID"]))
                    {
                        obj = p.Client.GetWorkFlow(SenderUser, parm.WorkFlowID);
                        if (obj == null)
                        {
                            throw new Exception("数据不存在");
                        }
                    }
                    else
                    {
                        
                        obj.WorkFlowID = Guid.NewGuid();
                    }
                    obj.WorkFlowCode = parm.WorkFlowCode;
                    obj.WorkFlowName = parm.WorkFlowName;
                    obj.ImageUrl = parm.ImageUrl;
                    obj.Remark = parm.Remark;
                    obj.SortNo = parm.SortNo;
                    p.Client.SaveWorkFlow(SenderUser, obj);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkFlow()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkFlow workflow = p.Client.GetWorkFlow(SenderUser, parm.WorkFlowID);
                    Response.Write(JSONHelper.Object2Json(workflow));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}