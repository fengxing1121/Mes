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
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// CarHandler 的摘要说明
    /// </summary>
    public class CarHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        CarParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new CarParm(context);
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

        public void SearchCars()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchCarArgs sargs = new SearchCarArgs();
                    sargs.OrderBy = "Created desc";
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;

                    //Where
                    if (!string.IsNullOrEmpty(parm.PlateNo))
                    {
                        sargs.PlateNo = parm.PlateNo;
                    }
                    if (!string.IsNullOrEmpty(parm.DriverName))
                    {
                        sargs.DriverName = parm.DriverName;
                    }
                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        sargs.Mobile = parm.Mobile;
                    }
                    SearchResult sr = p.Client.SearchCar(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void NewCar()
        {
            try
            {
                Car car = new Car();
                car.PlateNo = "";
                car.CarName = "";
                car.Mobile = "";
                car.CarStyle = "";
                car.DriverName = "";
                Response.Write(JSONHelper.Object2Json(car));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetCar()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid eid = new Guid(Request["CarID"]);
                    Car le = p.Client.GetCar(SenderUser, eid);
                    if (le == null)
                    {
                        throw new Exception("所查找车辆不存在。");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(le));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveCar()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    Car le = p.Client.GetCar(null, parm.CarID);
                    if (le == null)
                    {
                        le = new Car();
                        le.CarID = parm.CarID;
                    }
                    le.EnterpriseID = parm.EnterpriseID;
                    le.PlateNo = parm.PlateNo.Trim();
                    le.CarName = parm.CarName.Trim();
                    le.Mobile = parm.Mobile.Trim();
                    le.CarStyle = parm.CarStyle.Trim();
                    le.DriverName = parm.DriverName.Trim();
                    SaveCarArgs args = new SaveCarArgs();
                    args.Car = le;
                    p.Client.SaveCar(SenderUser, args);
                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }
    }
}