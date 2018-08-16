using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// WorkShopHandler 的摘要说明
    /// </summary>
    public class WorkShopHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        WorkShopParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";

                if (!string.IsNullOrEmpty(method))
                {
                    parm = new WorkShopParm(context);
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

        public void SearchWorkShops()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWorkShopArgs args = new SearchWorkShopArgs();
                    args.OrderBy = "[WorkShopCode]";
                    if (!string.IsNullOrEmpty(Request["WorkCenterCode"]))
                    {
                        args.WorkShopCode = Request["WorkCenterCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["WorkCenterName"]))
                    {
                        args.WorkShopName = Request["WorkCenterName"].ToString();
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchWorkShop(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void newWorkShop()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkShop workshop = new WorkShop();
                    workshop.WorkShopID = Guid.NewGuid();
                    workshop.WorkShopCode = "";
                    workshop.WorkShopName = "";
                    workshop.Remark = "";
                    Response.Write(JSONHelper.Object2Json(workshop));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveWorkShop()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (parm.WorkShopID == Guid.Empty)
                    {
                        throw new Exception("请选择对应工序");
                    }
                    if (parm.WorkingLineID == Guid.Empty)
                    {
                        throw new Exception("请选择生产线");
                    }
                    //班组

                    string WorkShiftIDs = Request["WorkShiftIDs"].ToString();

                    List<Guid> ws_IDs = new List<Guid>();
                    foreach (string wsid in WorkShiftIDs.Split(','))
                    {
                        if (!string.IsNullOrEmpty(wsid))
                            ws_IDs.Add(Guid.Parse(wsid));
                    }

                    SaveWorkShopArgs args = new SaveWorkShopArgs();
                    WorkShop workshop = p.Client.GetWorkShop(SenderUser, parm.WorkShopID);
                    if (workshop == null)
                    {
                        workshop = new WorkShop();
                        workshop.WorkShopID = parm.WorkShopID;
                    }
                    workshop.WorkShopCode = parm.WorkShopCode;
                    workshop.WorkShopName = parm.WorkShopName;
                    workshop.WorkShopID = parm.WorkShopID;
                    workshop.WorkingLineID = parm.WorkingLineID;
                    workshop.Remark = parm.Remark;
                    args.WorkShop = workshop;
                    args.WorkShiftIDs = ws_IDs;
                    p.Client.SaveWorkShop(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkShop()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WorkShop workshop = p.Client.GetWorkShop(SenderUser, parm.WorkShopID);
                    Response.Write(JSONHelper.Object2Json(workshop));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkShops()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {

                    List<WorkShop> workshops = p.Client.GetAllWorkShops(SenderUser);
                    WorkShop wf = new WorkShop();
                    wf.WorkShopName = "请选择";
                    wf.WorkShopID = Guid.Empty;
                    workshops.Insert(0, wf);
                    //workshops.Sort((x, y) => x.WorkShopCode.CompareTo(y.WorkShopCode));
                    Response.Write(JSONHelper.Object2JSON(workshops));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetWorkShift2WorkShops()
        {
            using (ProxyBE op = new ProxyBE())
            {
                SearchWorkShift2WorkShopArgs args = new SearchWorkShift2WorkShopArgs();
                args.WorkShopID = Guid.Parse(Request["WorkShopID"].ToString());
                SearchResult sr = op.Client.SearchWorkShift2WorkShop(SenderUser, args);
                Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
            }
        }

        public void GetWorkShiftTree()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid WorkShopID = Guid.Parse(Request["WorkShopID"].ToString());
                    List<WorkShift> ws_lists = p.Client.GetAllWorkShifts(SenderUser);
                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[{");
                    jsonBuilder.Append("\"id\":\"0\"");
                    jsonBuilder.Append(",\"text\":\"班组设置\"");
                    jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"0\"}");
                    #region 班组
                    if (ws_lists.Count > 0)
                    {
                        jsonBuilder.AppendFormat(",\"children\":");
                        jsonBuilder.Append("[");
                        foreach (WorkShift ws in ws_lists)
                        {
                            List<WorkShift2WorkShop> wss = p.Client.GetWorkShift2WorkShopByWorkShopID(SenderUser, WorkShopID);
                            jsonBuilder.Append("{");
                            jsonBuilder.AppendFormat("\"id\":\"{0}\"", ws.WorkShiftID);
                            jsonBuilder.AppendFormat(",\"text\":\"{0}[{1}~{2}]\"", ws.WorkShiftName, ws.Started, ws.Ended);
                            if (wss.Find(pl => pl.WorkShiftID == ws.WorkShiftID) != null)
                                jsonBuilder.AppendFormat(",\"checked\":\"{0}\"", true);
                            jsonBuilder.AppendFormat(",\"iconCls\":\"{0}\"", "group");
                            jsonBuilder.Append(",\"attributes\":{\"IsMenu\":\"2\"}");
                            jsonBuilder.Append("}");
                            jsonBuilder.Append(",");
                        }

                        jsonBuilder = jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                        jsonBuilder.Append("]");
                    }

                    #endregion
                    jsonBuilder.Append("}]");
                    Response.Write(jsonBuilder.ToString());

                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}