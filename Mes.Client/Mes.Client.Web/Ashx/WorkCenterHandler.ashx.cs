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
    /// WorkCenterHandler 的摘要说明
    /// </summary>
    public class WorkCenterHandler : BaseHttpHandler
    {
        WorkCenterParm parm;
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            parm = new WorkCenterParm(context);
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

        public void SearchWorkCenters()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWorkCenterArgs args = new SearchWorkCenterArgs();
                    args.OrderBy = "[Sequence]";
                    if (!string.IsNullOrEmpty(parm.WorkCenterCode))
                    {
                        args.WorkCenterCode = parm.WorkCenterCode;
                    }
                    if (!string.IsNullOrEmpty(parm.WorkCenterName))
                    {
                        args.WorkCenterName = parm.WorkCenterName;
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchWorkCenter(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                //WriteError(ex.Message, ex);
                Response.Write(ex);
            }
        }

        public void newWorkCenter()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkCenter workcenter = new WorkCenter();
                    workcenter.WorkCenterID = Guid.NewGuid();
                    workcenter.WorkCenterCode = "";
                    workcenter.WorkCenterName = "";
                    workcenter.MaxCapacity = 1;
                    workcenter.CountCapacityType = "";
                    workcenter.Sequence = 0;
                    Response.Write(JSONHelper.Object2Json(workcenter));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveWorkCenter()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (parm.WorkShopID == Guid.Empty)
                    {
                        throw new Exception("请选择车间。");
                    }
                    if (parm.WorkFlowID == Guid.Empty)
                    {
                        throw new Exception("请选择对应工序。");
                    }

                    if (parm.CountCapacityType == "请选择")
                    {
                        throw new Exception("请选择产能计算方式。");

                    }

                    SaveWorkCenterArgs args = new SaveWorkCenterArgs();
                    WorkCenter workcenter = p.Client.GetWorkCenter(SenderUser, parm.WorkCenterID);
                    if (workcenter == null)
                    {
                        workcenter = new WorkCenter();
                        workcenter.WorkCenterID = parm.WorkCenterID;
                    }
                    workcenter.WorkCenterCode = parm.WorkCenterCode;
                    workcenter.WorkCenterName = parm.WorkCenterName;
                    workcenter.WorkFlowID = parm.WorkFlowID;
                    workcenter.MaxCapacity = parm.MaxCapacity;
                    workcenter.WorkShopID = parm.WorkShopID;
                    workcenter.Style = parm.Style;
                    workcenter.Model = parm.Model;
                    workcenter.Sequence = parm.Sequence;
                    workcenter.Remark = parm.Remark;
                    workcenter.CountCapacityType = parm.CountCapacityType;
                    args.WorkCenter = workcenter;
                    p.Client.SaveWorkCenter(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkCenter()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkCenter workcenter = p.Client.GetWorkCenter(SenderUser, parm.WorkCenterID);
                    Response.Write(JSONHelper.Object2Json(workcenter));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkFlows()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {

                    List<WorkFlow> workcenters = p.Client.GetAllWorkFlows(SenderUser);
                    WorkFlow wf = new WorkFlow();
                    wf.WorkFlowName = "请选择";
                    wf.WorkFlowID = Guid.Empty;
                    workcenters.Insert(0, wf);
                   // workcenters.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                    Response.Write(JSONHelper.Object2JSON(workcenters));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}