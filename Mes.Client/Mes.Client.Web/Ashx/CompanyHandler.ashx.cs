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
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// CompanyHandler 的摘要说明
    /// </summary>
    public class CompanyHandler : BaseHttpHandler
    {
        #region ===================初始加载=====================
        CompanyParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new CompanyParm(context);
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

        public void SearchCompanys()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchCompanyArgs sargs = new SearchCompanyArgs();
                    sargs.OrderBy = "[Created] desc";
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;

                    //Where
                    if (!string.IsNullOrEmpty(parm.CompanyCode))
                    {
                        sargs.CompanyCode = parm.CompanyCode;
                    }
                    if (!string.IsNullOrEmpty(parm.CompanyName))
                    {
                        sargs.CompanyName = parm.CompanyName;
                    }
                    if (!string.IsNullOrEmpty(parm.LinkMan))
                    {
                        sargs.LinkMan = parm.LinkMan;
                    }
                    if (!string.IsNullOrEmpty(parm.Mobile))
                    {
                        sargs.Mobile = parm.Mobile;
                    }
                    if (!string.IsNullOrEmpty(parm.Address))
                    {
                        sargs.Address = parm.Address;
                    }
                    SearchResult sr = p.Client.SearchCompany(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
                throw ex;
            }
        }
        public void GetCompanies()
        {
            try
            {
                Database dbCompany = new Database("BE_Company_Proc", "COMPANYBOX", 0, 0, "", "", "");
                DataTable dtCompanys = dbCompany.ExecuteDataTable();
                Response.Write(JSONHelper.ToJson(dtCompanys));
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void GetCompany()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid Companyid = new Guid(Request["CompanyID"]);
                    Company comp = p.Client.GetCompany(SenderUser, Companyid);
                    if (comp == null)
                    {
                        throw new Exception("所查找公司不存在。");
                    }
                    else
                    {
                        Response.Write(JSONHelper.Object2Json(comp));
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void ModifyCompany()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    //if (Request["Province"] == "")
                    //{
                    //    throw new Exception("请选择省份");
                    //}
                    //if (Request["City"] == "请选择城市")
                    //{
                    //    throw new Exception("请选择城市");
                    //}

                    string CompanyCode = parm.CompanyCode;
                    string CompanyName = parm.CompanyName;
                    string Province = parm.Province;
                    string City = parm.City;
                    string Address = parm.Address;
                    string Email = parm.Email;
                    string Mobile = parm.Mobile;
                    string LinkMan = parm.LinkMan;
                    string Amount = "0";
                    string Score = "0";
                    string Remark = parm.Remark;
                    string ReferralCode = "";
                    string ReferralBy = "";
                    string Status = Request.Form["Status"];
                    string Modified = DateTime.Now.ToString();
                    string Sort = parm.Sort.ToString();
                    string S3 = CompanyCode + "|" + CompanyName + "|" + Province + "|" + City + "|" + Address + "|" + Email + "|" + Mobile + "|"
                        + LinkMan + "|" + Amount + "|" + Score + "|" + Remark + "|" + ReferralCode + "|" + ReferralBy + "|"
                        + Status + "|" + Modified + "|" + Sort;

                    Database db = new Database("BE_Company_Proc", "UPONE", 0, 0, parm.CompanyID.ToString(), "", S3);
                    db.ExecuteNoQuery();
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        //public void ModifyPartner_EGui()
        //{
        //    try
        //    {
        //        using (ProxyBE p = new ProxyBE())
        //        {
        //            Partner partner = p.Client.GetPartner(SenderUser, parm.PartnerID);
        //            if (partner == null)
        //            {
        //                partner = new Partner();
        //                partner.PartnerID = parm.PartnerID;
        //            }
        //            if (Request["Province"] == "")
        //            {
        //                throw new Exception("请选择省份");
        //            }
        //            if (Request["City"] == "请选择城市")
        //            {
        //                throw new Exception("请选择城市");
        //            }
        //            partner.PartnerName = parm.PartnerName.Trim();
        //            partner.LinkMan = parm.LinkMan.Trim();
        //            partner.Province = parm.Province;
        //            partner.City = parm.City;
        //            partner.ShopSize = parm.ShopSize;
        //            partner.Address = parm.Address.Trim();
        //            SavePartnerArgs args = new SavePartnerArgs();
        //            args.Partner = partner;
        //            p.Client.SavePartner(SenderUser, args);

        //            PartnerUser PartnerUser = new PartnerUser();
        //            PartnerUser.UserID = CurrentUser.UserID;
        //            PartnerUser.IsFinishInfo = true;
        //            SavePartnerUserArgs pargs = new SavePartnerUserArgs();
        //            pargs.PartnerUser = PartnerUser;
        //            p.Client.UpdatePartnerUserIsFinishInfoByUserID(SenderUser, pargs);

        //            CurrentUser.IsFinishInfo = true;
        //            WriteSuccess();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteError(ex.Message, ex);
        //    }
        //}
        public void SaveCompany()
        {
            try
            {
                //if (Request["Province"] == "")
                //{
                //    throw new Exception("请选择省份");
                //}
                //if (Request["City"] == "请选择城市")
                //{
                //    throw new Exception("请选择城市");
                //}

                string CompanyCode = parm.CompanyCode;
                string CompanyName = parm.CompanyName;
                string Province = parm.Province;
                string City = parm.City;
                string Address = parm.Address;
                string Email = parm.Email;
                string Mobile = parm.Mobile;
                string LinkMan = parm.LinkMan;
                string Amount = "0";
                string Score = "0";
                string Remark = parm.Remark;
                string ReferralCode = "";
                string ReferralBy = "";
                string Status = Request.Form["Status"];
                string Modified = DateTime.Now.ToString();
                string Sort = parm.Sort.ToString();
                string S3 = CompanyCode + "|" + CompanyName + "|" + Province + "|" + City + "|" + Address + "|" + Email + "|" + Mobile + "|"
                    + LinkMan + "|" + Amount + "|" + Score + "|" + Remark + "|" + ReferralCode + "|" + ReferralBy + "|"
                    + Status + "|" + Modified + "|" + Sort;

                Database db = new Database("BE_Company_Proc", "ADDONE", 0, 0, "", "", S3);
                db.ExecuteNoQuery();
                WriteSuccess();
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        //public void SavePartner()
        //{
        //    using (ProxyBE p = new ProxyBE())
        //    {
        //        try
        //        {
        //            #region Partner
        //            //if (Request["Province"] == "")
        //            //{
        //            //    throw new Exception("请选择省份");
        //            //}
        //            //if (Request["City"] == "请选择城市")
        //            //{
        //            //    throw new Exception("请选择城市");
        //            //}
        //            Partner Partner = new Partner();
        //            //公司
        //            Partner.CompanyID = parm.CompanyID;
        //            Partner.PartnerID = parm.PartnerID;
        //            Partner.ShopType = parm.ShopType;
        //            Partner.PartnerName = parm.PartnerName.Trim();
        //            Partner.LinkMan = parm.LinkMan.Trim();
        //            Partner.Email = parm.Email.Trim();
        //            Partner.Mobile = parm.Mobile.Trim();
        //            Partner.Tel = parm.Tel.Trim();
        //            Partner.Fax = parm.Fax.Trim();
        //            Partner.Remark = parm.Remark.Trim();
        //            Partner.Province = parm.Province;
        //            Partner.City = parm.City;
        //            Partner.ShopSize = parm.ShopSize;
        //            Partner.Address = parm.Address.Trim();

        //            bool flag = p.Client.PartnerUserIsDuplicated(SenderUser, new PartnerUser() { UserCode = Partner.Mobile });
        //            if (flag)
        //            {
        //                throw new Exception("手机号已注册");
        //            }

        //            SavePartnerArgs args = new SavePartnerArgs();
        //            args.Partner = Partner;
        //            p.Client.SavePartner(SenderUser, args);
        //            #endregion

        //            #region PartnerUser 
        //            PartnerUser PartnerUser = new PartnerUser();

        //            PartnerUser.CompanyID = parm.CompanyID;
        //            PartnerUser.UserID = Guid.NewGuid();
        //            PartnerUser.Created = DateTime.Now;
        //            PartnerUser.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
        //            PartnerUser.Modified = DateTime.Now;
        //            PartnerUser.ModifiedBy = SenderUser.UserCode + "." + SenderUser.UserName;

        //            //admin经销商默认密码 123456
        //            PartnerUser.Password = MES.Libraries.CEncrypt.EncryptString(UserDefaultPassword);
        //            int num = p.Client.GetIncrease(SenderUser, "admin");
        //            // PartnerUser.UserCode = "admin" +num.ToString("#000");
        //            PartnerUser.UserCode = Partner.Mobile;
        //            PartnerUser.UserName = parm.PartnerName;
        //            PartnerUser.PartnerID = parm.PartnerID;
        //            PartnerUser.Sex = "男";
        //            PartnerUser.Position = "管理员";
        //            PartnerUser.Email = "";
        //            PartnerUser.Mobile = parm.Mobile.Trim();
        //            PartnerUser.Description = "管理员";
        //            PartnerUser.LoginErrorCount = 0;
        //            PartnerUser.IsDisabled = false;
        //            PartnerUser.IsLocked = false;
        //            PartnerUser.IsSystem = true;
        //            bool flag2 = p.Client.PartnerUserIsDuplicated(SenderUser, PartnerUser);
        //            if (flag2)
        //            {
        //                throw new Exception("服务器忙,请稍候再试");
        //            }
        //            SavePartnerUserArgs pargs = new SavePartnerUserArgs();
        //            pargs.PartnerUser = PartnerUser;
        //            p.Client.SavePartnerUser(SenderUser, pargs);
        //            #endregion

        //            WriteSuccess();
        //        }
        //        catch (Exception ex)
        //        {
        //            WriteError(ex.Message, ex);
        //        }
        //    }
        //}
    }
}