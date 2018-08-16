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
    /// WarehouseInMainHandler 的摘要说明
    /// </summary>
    public class WarehouseInMainHandler : BaseHttpHandler
    {
        WarehouseInMainParm Parm;
        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            Parm = new WarehouseInMainParm(context);

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

        public void SearchWarehouseInMain()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWarehouseInMainArgs args = new SearchWarehouseInMainArgs();
                    args.OrderBy = "[CheckInDate] Desc";
                    if (!string.IsNullOrEmpty(Parm.BillNo))
                    {
                        args.BillNo = Parm.BillNo;
                    }
                    if (!string.IsNullOrEmpty(Parm.HandlerMan))
                    {
                        args.HandlerMan = Parm.HandlerMan;
                    }
                    //args少BattchNo
                    //if (!string.IsNullOrEmpty(Parm.BattchNo))
                    //{
                    //    args.BattchNo = Parm.BattchNo;
                    //}
                    if (!string.IsNullOrEmpty(Request["SupplierName"]))
                    {
                        args.SupplierName = Request["SupplierName"].ToString();
                    }

                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchWarehouseInMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 入库详细
        /// </summary>
        public void SearchInMainDetail()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["InID"]))
                {
                    throw new Exception("入库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWarehouseInDetailArgs args = new SearchWarehouseInDetailArgs();
                    args.OrderBy = "[Qty]";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.InID = new Guid(Request["InID"]);


                    SearchResult sr = p.Client.SearchWarehouseInDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                //WriteError(ex.Message, ex);
            }

        }

        /// <summary>
        /// 新增入库产品保存
        /// </summary>
        public void SaveWareHouseIn()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    WarehouseInMain ware = new WarehouseInMain();

                    ware.InID = Parm.InID;
                    ware.BillNo = Parm.BillNo;
                    ware.BattchNo = Parm.BattchNo;
                    ware.CheckInDate = Parm.CheckInDate;
                    ware.HandlerMan = Parm.HandlerMan;
                    ware.SupplierID = Parm.SupplierID;
                    ware.Remark = Parm.Remark;
                    SaveWarehouseInMainArgs args = new SaveWarehouseInMainArgs();
                    args.WarehouseInMain = ware;

                    //遍历详细页
                    List<WarehouseInDetail> listdetails = new List<WarehouseInDetail>();
                    string WarehouseInDetail = Request["WarehouseInDetail"];


                    JsonData sj = JsonMapper.ToObject(WarehouseInDetail);
                    if (sj.Count > 0)
                    {
                        //遍历对象元素，保存                        
                        foreach (JsonData item in sj)
                        {
                            WarehouseInDetail detail = new WarehouseInDetail();
                            detail.InID = ware.InID;
                            detail.DetailID = Guid.NewGuid();
                            detail.MaterialID = Guid.Parse(item["MaterialID"].ToString());
                            detail.LocationID = Guid.Parse(item["LocationID"].ToString());
                            detail.Qty = int.Parse(item["Qty"].ToString());
                            detail.Price = Decimal.Parse(item["Price"].ToString());
                            listdetails.Add(detail);
                        }
                    }
                    args.WarehouseInDetails = listdetails;
                    p.Client.SaveWarehouseInMain(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        /// <summary>
        /// 获取对应InMain数据
        /// </summary>
        public void GetInMain()
        {
            try
            {
                if (string.IsNullOrEmpty(Request["InID"]))
                {
                    throw new Exception("入库ID参数无效。");
                }
                using (ProxyBE p = new ProxyBE())
                {

                    SearchWarehouseInMainArgs args = new SearchWarehouseInMainArgs();
                    args.InID = new Guid(Request["InID"]);
                    SearchResult sr = p.Client.SearchWarehouseInMain(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void PieData()
        {
            try
            {

                using (ProxyBE p = new ProxyBE())
                {
                    SearchWarehouseInDetailArgs args = new SearchWarehouseInDetailArgs();
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;


                    SearchResult sr = p.Client.SearchWarehouseInDetail(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
                //WriteError(ex.Message, ex);
            }
        }
    }
}