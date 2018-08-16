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
    /// WorkShiftHandler 的摘要说明
    /// </summary>
    public class WorkShiftHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        WorkShiftParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";

                if (!string.IsNullOrEmpty(method))
                {
                    parm = new WorkShiftParm(context);
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

        public void SearchWorkShifts()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWorkShiftArgs args = new SearchWorkShiftArgs();
                    args.OrderBy = "[WorkShiftCode]";
                    if (!string.IsNullOrEmpty(Request["WorkShiftCode"]))
                    {
                        args.WorkShiftCode = Request["WorkShiftCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["WorkShiftName"]))
                    {
                        args.WorkShiftName = Request["WorkShiftName"].ToString();
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchWorkShift(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                //WriteError(ex.Message, ex);
                Response.Write(ex);
            }
        }
        public void GetWorkShifts()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    List<WorkShift> ws_lists = p.Client.GetAllWorkShifts(SenderUser);
                    Response.Write(JSONHelper.Object2JSON(ws_lists));
                }
            }
            catch (Exception ex)
            {
                //WriteError(ex.Message, ex);
                Response.Write(ex);
            }
        }
        public void newWorkShift()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkShift workshift = new WorkShift();
                    workshift.WorkShiftID = Guid.NewGuid();
                    workshift.WorkShiftCode = "";
                    workshift.WorkShiftName = "";
                    workshift.Started = "08:00";
                    workshift.Ended = "18:00";
                    Response.Write(JSONHelper.Object2Json(workshift));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveWorkShift()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (parm.WorkShiftID == Guid.Empty)
                    {
                        throw new Exception("请选择对应工序。");
                    }
                    SaveWorkShiftArgs args = new SaveWorkShiftArgs();
                    WorkShift workshift = p.Client.GetWorkShift(SenderUser, parm.WorkShiftID);
                    if (workshift == null)
                    {
                        workshift = new WorkShift();
                        workshift.WorkShiftID = parm.WorkShiftID;
                    }
                    workshift.WorkShiftCode = parm.WorkShiftCode;
                    workshift.WorkShiftName = parm.WorkShiftName;
                    workshift.WorkShiftID = parm.WorkShiftID;
                    workshift.Started = parm.Started;
                    workshift.Ended = parm.Ended;
                    args.WorkShift = workshift;
                    p.Client.SaveWorkShift(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkShift()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkShift workshift = p.Client.GetWorkShift(SenderUser, parm.WorkShiftID);
                    Response.Write(JSONHelper.Object2Json(workshift));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}