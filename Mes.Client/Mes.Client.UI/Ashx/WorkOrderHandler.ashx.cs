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
using System.Text;
using System.Web;
using LitJson;
using Mes.Client.Utility.Enum;

namespace Mes.Client.UI.Ashx
{
    public class WorkOrderHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        WorkOrderParm parm = null;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new WorkOrderParm(context);
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

        #region 查询数据
        public void SearchWorkOrder()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWorkOrderArgs args = new SearchWorkOrderArgs();

                    args.OrderBy = "Created desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(Request["WorkOrderID"]))
                    {
                        args.WorkOrderID = parm.WorkOrderID;
                    }
                    if (!string.IsNullOrEmpty(Request["WorkOrderNo"]))
                    {
                        args.WorkOrderNo = parm.WorkOrderNo;
                    }
                    if (!string.IsNullOrEmpty(Request["OrderID"]))
                    {
                        args.OrderID = parm.OrderID;
                    }
                    if (!string.IsNullOrEmpty(Request["ProductionID"]))
                    {
                        args.ProductionID = parm.ProductionID;
                    }
                    if (!string.IsNullOrEmpty(Request["Status"]))
                    {
                        args.Status = parm.Status;
                    }
                    if (!string.IsNullOrEmpty(Request["Created"]))
                    {
                        args.Created = parm.Created;
                    }
                    if (!string.IsNullOrEmpty(Request["CreatedBy"]))
                    {
                        args.CreatedBy = parm.CreatedBy;
                    }

                    SearchResult sr = p.Client.SearchWorkOrder(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }

        public void SearchProductComponents()
        {
            try
            {
                string ComponentID = Request["ComponentID"];
                if (string.IsNullOrEmpty(ComponentID))
                {
                    Response.Write("{\"total\":0,\"rows\":[]}");
                }
                using (ProxyBE p = new ProxyBE())
                {
                    SearchComponentMaterialArgs args = new SearchComponentMaterialArgs();

                    args.OrderBy = "Created desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    args.ComponentID = int.Parse(ComponentID);

                    SearchResult sr = p.Client.SearchComponentMaterialByComponentID(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
        #endregion

        #region 操作数据

        public void SaveWorkOrders()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SaveWorkOrderArgs args = new SaveWorkOrderArgs();
                    WorkOrder obj = new WorkOrder();
                    if (string.IsNullOrEmpty(Request["ProductionIDs"]))
                    {
                        throw new Exception("参数错误！");
                    }
                    string[] array = Request["ProductionIDs"].TrimEnd(',').Split(',');
                    for (int i = 0; i < array.Length; i++)
                    {
                        Guid ProductionID = new Guid(array[i]);
                        ProductionOrder productionorder = p.Client.GetProductionOrder(SenderUser, ProductionID);
                        if (productionorder == null)
                        {
                            throw new Exception(string.Format("生产订单{0}不存在！", productionorder.ProduceNo));
                        }
                        if (productionorder.Status!= ProductionOrderStatus.Y.ToString())
                        {
                            throw new Exception(string.Format("生产订单{0}未排单！", productionorder.ProduceNo));
                        }
                        productionorder.Status = ProductionOrderStatus.K.ToString();
                        args.ProductionOrder = productionorder;

                        #region 工单
                        //一阶组件
                        List<ProductComponent> componentlist = p.Client.GetProductComponentByOrderID(SenderUser, productionorder.OrderID);
                        //组件对照表
                        List<ComponentType> typelist = p.Client.GetAllComponentTypes(SenderUser);

                        pageValues = new List<ProductComponent>();
                        foreach (ProductComponent Item in componentlist)
                        {
                            FindLastChild(typelist, Item.ComponentTypeID, Item.ProductCode);
                        }

                        List <WorkOrder> list = new List<WorkOrder>();
                        foreach (ProductComponent Item in pageValues)
                        {
                            var componentmodel= p.Client.GetProductComponentByComponentTypeID(SenderUser, Item.ComponentTypeID, Item.ProductCode);
                            if (componentmodel != null)
                            {
                                WorkOrder model = new WorkOrder()
                                {
                                    WorkOrderID = Guid.NewGuid(),
                                    OrderID = productionorder.OrderID,
                                    ProductionID = productionorder.ProductionID,
                                    Status = "N",
                                    ComponentID= componentmodel.ComponentID,
                                    ComponentTypeID = componentmodel.ComponentTypeID,
                                }; 
                                list.Add(model);
                            }
                        }
                        args.WorkOrders = list;

                        #endregion
                    }
                    if (args.WorkOrders.Count < 1)
                    {
                        throw new Exception("递归数据查询中未找到任何数据！");
                    }
                    p.Client.SaveWorkOrders(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }
        List<ProductComponent> pageValues = new List<ProductComponent>();
        /// <summary>
        /// 根据父ID查找最末级节点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parent"></param>
        /// <param name="ProductCode">查找ProductComponent唯一性用</param>
        public void FindLastChild(List<ComponentType> list, int parent = 0, string ProductCode="")
        {
            var typelist = list.Where(o => o.ParentID == parent).ToList();
            if (typelist.Count > 0)
            {
                foreach (var item in typelist)
                {
                    FindLastChild(list, item.ComponentTypeID, ProductCode);
                }
            }
            else
            {
                ComponentType model = list.Where(t => t.ComponentTypeID == parent).FirstOrDefault();
                if (model != null)
                {
                    ProductComponent Info = new ProductComponent()
                    {
                        ComponentTypeID = model.ComponentTypeID,
                        ProductCode = ProductCode,
                    };
                    pageValues.Add(Info);
                }
            }
        }

        #endregion
    }
}

