using LitJson;
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
    /// WarehouseOutMainHandler 的摘要说明
    /// </summary>
    public class WarehouseOutMainHandler : BaseHttpHandler
    {
        WarehouseOutMainParm Parm;

        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            Parm = new WarehouseOutMainParm(context);

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

        public void SearchWarehouseOutMain()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWarehouseOutMainArgs args = new SearchWarehouseOutMainArgs();

                    args.OrderBy = "[CheckOutDate] Desc";
                    if (!string.IsNullOrEmpty(Parm.BillNo))
                    {
                        args.BillNo = Parm.BillNo;
                    }
                    if (!string.IsNullOrEmpty(Parm.HandlerMan))
                    {
                        args.HandlerMan = Parm.HandlerMan;
                    }
                    if (!string.IsNullOrEmpty(Request["WareShopName"]))
                    {
                        args.WorkShopName = Request["WareShopName"].ToString();
                    }

                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    SearchResult sr = p.Client.SearchWarehouseOutMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                //WriteError(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// 出库详细
        /// </summary>
        public void SearchOutMainDetail()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["OutID"]))
                {
                    throw new Exception("入库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWarehouseOutDetailArgs args = new SearchWarehouseOutDetailArgs();
                    args.OrderBy = "[Qty]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.OutID = new Guid(Request["OutID"]);

                    SearchResult sr = p.Client.SearchWarehouseOutDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        /// <summary>
        /// 新增出库产品保存
        /// </summary>
        public void SaveWareHouseOut()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WarehouseOutMain ware = new WarehouseOutMain();
                    ware.OutID = Parm.OutID;
                    ware.BillNo = Parm.BillNo;
                    ware.CheckOutDate = Parm.CheckOutDate;
                    ware.HandlerMan = Parm.HandlerMan;
                    ware.WorkShopID = Parm.WorkShopID;
                    ware.Remark = Parm.Remark;
                    SaveWarehouseOutMainArgs args = new SaveWarehouseOutMainArgs();
                    args.WarehouseOutMain = ware;


                    //遍历详细页
                    List<WarehouseOutDetail> listdetails = new List<WarehouseOutDetail>();
                    string WarehouseOutDetail = Request["WarehouseOutDetail"];
                    JsonData sj = JsonMapper.ToObject(WarehouseOutDetail);
                    if (sj.Count > 0)
                    {
                        //遍历对象元素，保存                        
                        foreach (JsonData item in sj)
                        {
                            WarehouseOutDetail detail = new WarehouseOutDetail();
                            detail.OutID = ware.OutID;
                            detail.DetailID = Guid.NewGuid();
                            detail.MaterialID = Guid.Parse(item["MaterialID"].ToString());
                            detail.LocationID = Guid.Parse(item["LocationID"].ToString());
                            detail.Qty = int.Parse(item["Qty"].ToString());
                            listdetails.Add(detail);
                        }
                    }
                    args.WarehouseOutDetails = listdetails;
                    p.Client.SaveWarehouseOutMain(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        /// <summary>
        /// 获取对应OutMain数据
        /// </summary>
        public void GetOutMain()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["OutID"]))
                {
                    throw new Exception("出库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWarehouseOutMainArgs args = new SearchWarehouseOutMainArgs();
                    args.OutID = new Guid(Request["OutID"]);

                    SearchResult sr = p.Client.SearchWarehouseOutMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
    }
}