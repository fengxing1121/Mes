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
    /// WarehouseHandler 的摘要说明
    /// </summary>
    public class WarehouseHandler : BaseHttpHandler
    {
        LocationParm parm;
        MaterialParm materialParm;
        WarehouseParm warehouseParm;

        #region ===================初始加载=====================
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";
            parm = new LocationParm(context);
            materialParm = new MaterialParm(context);
            warehouseParm = new WarehouseParm(context);
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

        /// <summary>
        /// 仓位管理
        /// </summary>
        public void SearchLocation()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchLocationArgs args = new SearchLocationArgs();
                    args.OrderBy = "[Created] Desc";
                    if (!string.IsNullOrEmpty(parm.CabinetNum))
                    {
                        args.CabinetNum = parm.CabinetNum;
                    }
                    if (!string.IsNullOrEmpty(parm.LocationCode))
                    {
                        args.LocationCode = parm.LocationCode;
                    }
                    if (!string.IsNullOrEmpty(parm.LayerNum))
                    {
                        args.LayerNum = parm.LayerNum;
                    }
                    if (!string.IsNullOrEmpty(Request["Category"]))
                    {
                        //判断"请选择"选项
                        if (Request["Category"] != Guid.Empty.ToString())
                        {
                            args.WarehouseID = Guid.Parse(Request["Category"].ToString());
                        }
                    }
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchLocation(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 出库详细
        /// </summary>
        public void SearchWarehouse()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchWarehouseArgs args = new SearchWarehouseArgs();
                    args.OrderBy = "[Category],[SubCategory],[MaterialCode]";
                    //if (!string.IsNullOrEmpty(warehouseParm.MaterialCode))
                    //{
                    //    args.MaterialCode = warehouseParm.MaterialCode;
                    //}
                    //if (!string.IsNullOrEmpty(materialParm.MaterialName))
                    //{
                    //    args.MaterialName = warehouseParm.MaterialName;
                    //}

                    //if (!string.IsNullOrEmpty(warehouseParm.Category))
                    //{
                    //    args.Categorys = warehouseParm.Category.Split(',').ToList();
                    //}
                    //if (!string.IsNullOrEmpty(warehouseParm.SubCategory))
                    //{
                    //    args.SubCategorys = warehouseParm.SubCategory.Split(',').ToList();
                    //}

                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchWarehouse(SenderUser, args);
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
        /// 成品仓库
        /// </summary>
        public void SearchMaterials()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchMaterialArgs args = new SearchMaterialArgs();
                    args.OrderBy = "Category,MaterialCode";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    //Where   

                    if (!string.IsNullOrEmpty(Request["MaterialID"]))
                    {
                        args.MaterialIDs = new List<Guid>();
                        args.MaterialIDs.Add(Guid.Parse(Request["MaterialID"].ToString()));
                    }

                    if (!string.IsNullOrEmpty(Request["MaterialCode"]))
                    {
                        args.MaterialCode = Request["MaterialCode"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["MaterialName"]))
                    {
                        args.MaterialName = Request["MaterialName"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["Category"]))
                    {
                        args.Categorys = new List<string>();
                        args.Categorys.Add(Request["Category"].ToString());
                    }
                    if (!string.IsNullOrEmpty(Request["SubCategory"]))
                    {
                        args.SubCategorys = new List<string>();
                        args.SubCategorys.Add(Request["SubCategory"].ToString());
                    }
                    SearchResult sr = p.Client.SearchMaterial(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
                throw ex;
            }
        }

        /// <summary>
        /// 批量添加仓位
        /// </summary>
        public void SaveBattchLocation()
        {
            try
            {
                string Category = Request["Category"];
                if (Category == Guid.Empty.ToString())
                {
                    throw new Exception("请选择对应所属仓库。");
                }

                string CabinetNumCode = Request["CabinetNumCode"];
                string CabinetNumFrom = Request["CabinetNumFrom"];
                string CabinetNumTo = Request["CabinetNumTo"];
                string LayerNumCode = Request["LayerNumCode"];
                string LayerNumFrom = Request["LayerNumFrom"];
                string LayerNumTo = Request["LayerNumTo"];
                string MaxWeight = Request["MaxWeight"];
                string MaxPackage = Request["MaxPackage"];
                string Qty = Request["Qty"];

                using (ProxyBE p = new ProxyBE())
                {
                    List<Location> Locations = new List<Location>();
                    Category categoryid = p.Client.GetCategory(SenderUser, Guid.Parse(parm.Category));

                    for (int i = int.Parse(CabinetNumFrom); i <= int.Parse(CabinetNumTo); i++)
                    {
                        for (int n = int.Parse(LayerNumFrom); n <= int.Parse(LayerNumTo); n++)
                        {
                            for (int m = 1; m <= int.Parse(Qty); m++)
                            {
                                string CabinetNum = string.Format("{0}{1}", CabinetNumCode, i.ToString("000"));
                                string LayerNum = string.Format("{0}{1}", LayerNumCode, n.ToString("000"));
                                Location location = new Location();
                                location.LocationID = Guid.NewGuid();
                                location.Category = categoryid.CategoryName;
                                location.WarehouseID = Guid.Parse(Category);
                                location.LocationCode = string.Format("{0}-{1}-{2}", CabinetNum, LayerNum, m.ToString("000"));
                                location.CabinetNum = CabinetNum;
                                location.LayerNum = LayerNum;
                                location.MaxPackage = int.Parse(MaxPackage);
                                location.MaxWeight = int.Parse(MaxWeight);
                                location.IsDisabled = false;
                                location.Flag = false;
                                location.PackageQty = 0;
                                location.Weight = 0;
                                Locations.Add(location);
                                SaveLocationArgs args = new SaveLocationArgs();
                                args.Location = location;
                                p.Client.SaveLocation(SenderUser, args);
                            }
                        }
                    }
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                WriteError(ex.Message, ex);
            }
        }

        public void GetLocation()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Location location = p.Client.GetLocation(SenderUser, parm.LocationID);
                    Response.Write(JSONHelper.Object2Json(location));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void NewLocation()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Location location = new Location();
                    location.LocationID = Guid.NewGuid();
                    location.Category = "";
                    location.LocationCode = "";
                    location.MaxWeight = 0;
                    location.MaxPackage = 0;
                    location.LayerNum = "";
                    location.IsDisabled = false;
                    location.Flag = false;
                    location.PackageQty = 0;
                    location.Weight = 0;
                    Response.Write(JSONHelper.Object2Json(location));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存仓位管理
        /// </summary>
        public void SaveLocation()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    if (parm.WarehouseID == Guid.Empty)
                    {
                        throw new Exception("请选择对应所属仓库。");
                    }
                    SaveLocationArgs args = new SaveLocationArgs();
                    Location location = p.Client.GetLocation(SenderUser, parm.LocationID);
                    if (location == null)
                    {
                        location = new Location();
                        location.LocationID = parm.LocationID;
                    }
                    Category categoryid = p.Client.GetCategory(SenderUser, parm.WarehouseID);
                    location.WarehouseID = parm.WarehouseID;
                    location.Category = categoryid.CategoryName;
                    location.LocationCode = parm.LocationCode;
                    location.CabinetNum = parm.CabinetNum;
                    location.LayerNum = parm.LayerNum;
                    location.MaxWeight = parm.MaxWeight;
                    location.MaxPackage = parm.MaxPackage;
                    location.IsDisabled = Convert.ToBoolean(parm.IsDisabled);
                    args.Location = location;
                    p.Client.SaveLocation(SenderUser, args);
                }
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        /// <summary>
        /// 1.入库产品详细下拉仓库；2.仓位管理下拉
        /// </summary>
        public void GetCategories()
        {

            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Category category = p.Client.GetCategoryByParentID_CategoryCode(SenderUser, CategoryRootID, "CK");
                    if (category != null)
                    {
                        List<Category> lists = p.Client.GetCategoriesByParentID(SenderUser, category.CategoryID);

                        Category wf = new Category();
                        wf.CategoryName = "请选择";
                        wf.CategoryID = Guid.Empty;
                        lists.Insert(0, wf);
                        lists.Sort((x, y) => x.Sequence.CompareTo(y.Sequence));
                        Response.Write(JSONHelper.Object2JSON(lists));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }

        }

        /// <summary>
        /// 订单上架：所选仓位
        /// </summary>
        public void SearchOrderLocation()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchLocationArgs args = new SearchLocationArgs();
                    args.OrderBy = "[Created] Desc";
                    if (!string.IsNullOrEmpty(parm.CabinetNum))
                    {
                        args.CabinetNum = parm.CabinetNum;
                    }
                    if (!string.IsNullOrEmpty(parm.LocationCode))
                    {
                        args.LocationCode = parm.LocationCode;
                    }
                    if (!string.IsNullOrEmpty(parm.LayerNum))
                    {
                        args.LayerNum = parm.LayerNum;
                    }
                    args.Category = "成品仓";
                    args.Flag = false;
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;
                    SearchResult sr = p.Client.SearchLocation(SenderUser, args);
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