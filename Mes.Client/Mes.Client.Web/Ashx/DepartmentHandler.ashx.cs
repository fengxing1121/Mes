using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// DepartmentHandler 的摘要说明
    /// </summary>
    public class DepartmentHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        DepartmentParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new DepartmentParm(context);
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

        #region ====================基础方法====================

        /// <summary>
        /// List
        /// </summary>
        public void List()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {

                    SearchDepartmentArgs sargs = new SearchDepartmentArgs();

                    if (!string.IsNullOrEmpty(parm.DepartmentCode))
                    {
                        List<string> DepartmentCode = new List<string>();
                        DepartmentCode.Add(parm.DepartmentCode);
                        sargs.DepartmentCodes = DepartmentCode;
                    }
                    if (!string.IsNullOrEmpty(parm.DepartmentName) && parm.DepartmentName != "请选择")
                    {
                        List<string> DepartmentName = new List<string>();
                        DepartmentName.Add(parm.DepartmentName);
                        sargs.DepartmentNames = DepartmentName;

                    }


                    //if (!string.IsNullOrEmpty(Request["Closed"]))
                    //{
                    //    sargs.ClosedFrom = DateTime.Today;

                    //}


                    if (!string.IsNullOrEmpty(Request["IsDisabled"]))
                    {
                        sargs.IsDisabled = Convert.ToBoolean(Request["IsDisabled"]);
                    }
                    sargs.OrderBy = string.IsNullOrEmpty(pagingParm.SortOrder.Trim()) ? "DepartmentID" : pagingParm.SortOrder;
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    //Where

                    SearchResult sr = p.Client.SearchDepartment(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        /// <summary>
        /// 部门添加
        /// </summary>
        public void NewDepartment()
        {
            try
            {
                Department dept = new Department();
                dept.DepartmentID = Guid.NewGuid();
                dept.DepartmentName = "";
                dept.DepartmentCode = "";
                dept.Tel = "";
                dept.Fax = "";
                dept.Description = "";
                Response.Write(JSONHelper.Object2Json(dept));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }


        /// <summary>
        /// 添加、修改保存
        /// </summary>
        public void SaveDepartment()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Department pl = p.Client.GetDepartment(SenderUser, parm.DepartmentID);
                    if (pl == null)
                    {
                        pl = new Department();
                        pl.DepartmentID = Guid.NewGuid();
                    }
                    pl.DepartmentCode = parm.DepartmentCode;
                    pl.DepartmentName = parm.DepartmentName;
                    pl.Tel = parm.Tel;
                    pl.Fax = parm.Fax;
                    pl.Description = parm.Description;
                    pl.IsDisabled = parm.IsDisabled;
                    SaveDepartmentArgs args = new SaveDepartmentArgs();
                    args.Department = pl;
                    p.Client.SaveDepartment(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取对应记录或者修改
        /// </summary>
        public void GetDepartment()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid deptID = new Guid(Request["DepartmentID"]);
                    Department dept = p.Client.GetDepartment(SenderUser, deptID);
                    if (dept == null)
                    {
                        throw new Exception("所查找部门不存在。");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(dept));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }


        /// <summary>
        /// detail or edit 此方法暂时不用
        /// </summary>
        //public void AddOrUpdate()
        //{
        //    try
        //    {
        //        using (ProxyBE p = new ProxyBE())
        //        {
        //            string DepartmentID = Request["DepartmentIDs"];
        //            if (!string.IsNullOrEmpty(DepartmentID))
        //            {
        //                Department pl = p.Client.GetDepartment(SenderUser, new Guid(DepartmentID));
        //                if (pl != null)
        //                {
        //                    Response.Write(JSONHelper.Object2Json(pl));
        //                }
        //                else
        //                {
        //                    WriteError("该记录不存在");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteError(ex.Message, ex);
        //    }
        //}


        public void DeptList()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {

                    SearchDepartmentArgs sargs = new SearchDepartmentArgs();

                    if (!string.IsNullOrEmpty(parm.DepartmentCode))
                    {
                        List<string> DepartmentCode = new List<string>();
                        DepartmentCode.Add(parm.DepartmentCode);
                        sargs.DepartmentCodes = DepartmentCode;
                    }
                    if (!string.IsNullOrEmpty(parm.DepartmentName) && parm.DepartmentName != "请选择")
                    {
                        List<string> DepartmentName = new List<string>();
                        DepartmentName.Add(parm.DepartmentName);
                        sargs.DepartmentNames = DepartmentName;
                    }

                    sargs.IsDisabled = false;
                    sargs.OrderBy = string.IsNullOrEmpty(pagingParm.SortOrder.Trim()) ? "DepartmentID" : pagingParm.SortOrder;
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    //Where

                    SearchResult sr = p.Client.SearchDepartment(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        #endregion

        #region ================自定义方法======================
        /// <summary>
        /// 获取用户
        /// </summary>
        public void ListToUser()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchDepartmentArgs sargs = new SearchDepartmentArgs();
                    if (!string.IsNullOrEmpty(parm.DepartmentCode))
                    {
                        List<string> DepartmentCode = new List<string>();
                        DepartmentCode.Add(parm.DepartmentCode);
                        sargs.DepartmentCodes = DepartmentCode;
                    }
                    if (!string.IsNullOrEmpty(parm.DepartmentName))
                    {
                        List<string> DepartmentName = new List<string>();
                        DepartmentName.Add(parm.DepartmentName);
                        sargs.DepartmentNames = DepartmentName;
                    }
                    sargs.OrderBy = pagingParm.SortOrder;
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    //Where
                    SearchResult sr = p.Client.SearchDepartment(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));


                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取部门
        /// </summary>
        public void getDepartment()
        {
            ProxyBE p = new ProxyBE();

            SearchDepartmentArgs args = new SearchDepartmentArgs();
            //args.Areal = Request.QueryString["Area"];

            SearchResult sr = p.Client.SearchDepartment(SenderUser, args);
            DataTable dt = sr.DataSet.Tables[0]; ;
            var Areas = from d in dt.AsEnumerable() select new { DepartmentCode = d["DepartmentCode"], DepartmentName = d["DepartmentName"] };
            string str = "[";

            str += ("{\"text\":\"请选择\",");
            str += ("\"value\":\"请选择\"},");
            foreach (var p1 in Areas.Distinct())
            {
                str += "{\"DepartmentCode\":\"" + p1.DepartmentCode + "\",\"DepartmentName\":\"" + p1.DepartmentName + "\"},";

            }
            if (str.Length > 1)
            {
                str = str.Substring(0, str.LastIndexOf(","));
            }
            str += "]";
            Response.Write(str);
        }


        #endregion
    }
}