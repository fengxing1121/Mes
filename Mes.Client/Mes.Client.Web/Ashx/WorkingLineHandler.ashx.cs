using Eagle.Data;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// WorkingLineHandler 的摘要说明
    /// </summary>
    public class WorkingLineHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        WorkingLineParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";

                if (!string.IsNullOrEmpty(method))
                {
                    parm = new WorkingLineParm(context);
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

        public void SearchWorkingLines()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWorkingLineArgs args = new SearchWorkingLineArgs();
                    args.OrderBy = "[Created]";
                    if (!string.IsNullOrEmpty(Request["WorkingLineName"]))
                    {
                        args.WorkingLineName = Request["WorkingLineName"].ToString();
                    }

                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchWorkingLine(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void newWorkingLine()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkingLine line = new WorkingLine();
                    line.WorkingLineID = Guid.NewGuid();
                    line.WorkingLineName = "";
                    line.Remark = "";
                    Response.Write(JSONHelper.Object2Json(line));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveWorkingLine()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SaveWorkingLineArgs args = new SaveWorkingLineArgs();
                    WorkingLine line = p.Client.GetWorkingLine(SenderUser, parm.WorkingLineID);
                    if (line == null)
                    {
                        line = new WorkingLine();
                        line.WorkingLineID = parm.WorkingLineID;
                    }
                    line.WorkingLineName = parm.WorkingLineName;
                    line.Remark = parm.Remark;
                    args.WorkingLine = line;

                    p.Client.SaveWorkingLine(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkingLine()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkingLine line = p.Client.GetWorkingLine(SenderUser, parm.WorkingLineID);
                    Response.Write(JSONHelper.Object2Json(line));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkingLines()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {

                    List<WorkingLine> lines = p.Client.GetAllWorkingLines(SenderUser);
                    WorkingLine wf = new WorkingLine();
                    wf.WorkingLineName = "请选择";
                    wf.WorkingLineID = Guid.Empty;
                    lines.Insert(0, wf);
                    //lines.Sort((x, y) => x.WorkingLineName.CompareTo(y.WorkingLineName));
                    Response.Write(JSONHelper.Object2JSON(lines));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetMaterialType()
        {
            try
            {
                string CabinetIDs = Request["CabinetIDs"];
                Database db = new Database("BE_OrderDetail_Proc", "GETMETERIALS", 0, 0, "", "", CabinetIDs);
                DataTable dt = db.ExecuteDataTable();
                Response.Write(JSONHelper.DataTableToJSON(dt));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}