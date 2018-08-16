using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
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

        public void SearchWorkFlows()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWorkFlowArgs args = new SearchWorkFlowArgs();
                    args.OrderBy = "[Sequence]";
                    if (!string.IsNullOrEmpty(parm.WorkFlowCode))
                    {
                        args.WorkFlowCode = parm.WorkFlowCode;
                    }
                    if (!string.IsNullOrEmpty(parm.WorkFlowName))
                    {
                        args.WorkFlowName = parm.WorkFlowName;
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchWorkFlow(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void SearchWorkFlowss()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchOrderSchedulingArgs args = new SearchOrderSchedulingArgs();
                    string WorkFlowID = Request["WorkFlowID"];
                    args.OrderBy = "[BattchNum],[Sequence]";

                    if (WorkFlowID != null)
                    {
                        args.WorkFlowID = new Guid(WorkFlowID);
                    }
                    SearchResult sr = p.Client.SearchOrderScheduling(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void newWorkFlow()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkFlow workflow = new WorkFlow();
                    workflow.WorkFlowID = Guid.NewGuid();
                    workflow.WorkFlowCode = "";
                    workflow.WorkFlowName = "";
                    workflow.Remark = "";
                    //workflow.Sequence = 0;
                   // workflow.Price = 0;
                    //workflow.PaymentType = "1";
                    Response.Write(JSONHelper.Object2Json(workflow));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveWorkFlow()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    //SaveWorkFlowArgs args = new SaveWorkFlowArgs();
                    //WorkFlow workflow = p.Client.GetWorkFlow(SenderUser, parm.WorkFlowID);
                    //if (workflow == null)
                    //{
                    //    workflow = new WorkFlow();
                    //    workflow.WorkFlowID = parm.WorkFlowID;
                    //}
                    //workflow.WorkFlowCode = parm.WorkFlowCode;
                    //workflow.WorkFlowName = parm.WorkFlowName;
                    //workflow.PaymentType = parm.PaymentType;
                    //workflow.Price = parm.Price;
                    //workflow.ImageUrl = parm.ImageUrl;
                    //workflow.Sequence = parm.Sequence;
                    //workflow.Remark = parm.Remark;
                    //args.WorkFlow = workflow;
                    //p.Client.SaveWorkFlow(SenderUser, args);
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