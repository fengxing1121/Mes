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

namespace Mes.Client.UI.Ashx
{
    /// <summary>
    /// CustomerHandler 的摘要说明
    /// </summary>
    public class CustomerHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        CustomerParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new CustomerParm(context);
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

        public void SearchCustomers()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchCustomerArgs sargs = new SearchCustomerArgs();
                    sargs.OrderBy = "Created desc";

                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;
                    //Where
                    if (!string.IsNullOrEmpty(parm.CustomerName))
                    {
                        sargs.CustomerName = parm.CustomerName;
                    }
                    if (!string.IsNullOrEmpty(parm.LinkMan))
                    {
                        sargs.LinkMan = parm.LinkMan;
                    }
                    if (!string.IsNullOrEmpty(parm.Tel))
                    {
                        sargs.Tel = parm.Tel;
                    }
                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        sargs.Mobile = parm.Mobile;
                    }
                    if (!string.IsNullOrEmpty(parm.Fax))
                    {
                        sargs.Fax = parm.Fax;
                    }
                    if (!string.IsNullOrEmpty(parm.Province))
                    {
                        sargs.Province = parm.Province;
                    }
                    if (!string.IsNullOrEmpty(parm.City))
                    {
                        sargs.City = parm.City;
                    }
                    if (!string.IsNullOrEmpty(parm.Address))
                    {
                        sargs.Address = parm.Address;
                    }
                    if (!string.IsNullOrEmpty(parm.Position))
                    {
                        sargs.Position = parm.Position;
                    }
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        sargs.PartnerIDs = new List<Guid>();
                        sargs.PartnerIDs.Add(CurrentUser.PartnerID);
                    }

                    //搜索条件 缺收货地址、联系方式

                    SearchResult sr = p.Client.SearchCustomer(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void NewCustomer()
        {
            try
            {
                Customer cust = new Customer();
                cust.CustomerID = Guid.NewGuid();
                cust.CustomerName = "";
                cust.Province = "";
                cust.City = "";
                cust.Address = "";
                cust.Position = "";
                cust.Mobile = "";
                cust.Tel = "";
                cust.Fax = "";
                cust.Email = "";
                cust.HomePage = "";
                cust.LinkMan = "";
                cust.Remark = "";
                Response.Write(JSONHelper.Object2Json(cust));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetCustomer()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid custid = new Guid(Request["CustomerID"]);
                    Customer cust = p.Client.GetCustomer(SenderUser, custid);
                    if (cust == null)
                    {
                        throw new Exception("所查找客户不存在。");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(cust));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SaveCustomer()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    if (Request["Province"] == "")
                    {
                        throw new Exception("请选择省份");
                    }

                    Customer cust = p.Client.GetCustomer(null, parm.CustomerID);
                    if (cust == null)
                    {
                        cust = new Customer();
                        cust.CustomerID = parm.CustomerID;
                    }
                    cust.CustomerName = parm.CustomerName.Trim();
                    cust.LinkMan = parm.LinkMan.Trim();
                    cust.PartnerID = parm.PartnerID;
                    cust.Position = parm.Position.Trim();
                    cust.Email = parm.Email.Trim();
                    cust.Mobile = parm.Mobile.Trim();
                    cust.Tel = parm.Tel.Trim();
                    cust.Fax = parm.Fax.Trim();
                    cust.Remark = parm.Remark.Trim();
                    cust.HomePage = parm.HomePage.Trim();
                    cust.Province = parm.Province;
                    if (Request["City"] == "请选择城市")
                    {
                        cust.City = "";
                    }
                    else
                    {
                        cust.City = parm.City;
                    }
                    cust.Address = parm.Address.Trim();
                    SaveCustomerArgs args = new SaveCustomerArgs();
                    args.Customer = cust;
                    p.Client.SaveCustomer(SenderUser, args);
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