using Eagle.Data;
using Mes.Client.Model;
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
    /// PartnerHandlerRegister_EGui 的摘要说明
    /// </summary>
    public class PartnerHandlerRegister_EGui : BaseHttpHandler
    {
        #region ===================初始加载=====================
        PartnerParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string method = Request["Method"] ?? "";

            if (!string.IsNullOrEmpty(method))
            {
                parm = new PartnerParm(context);
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
        /// 获取手机验证码
        /// </summary>
        public void GetSMSCode()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    string phone = Request["phone"];
                    if (string.IsNullOrEmpty(phone))
                    {
                        throw new Exception("手机号不能为空");
                    }
                    Partner partnerModel = p.Client.GetPartnerByMobile(SenderUser, phone);
                    if (partnerModel != null)
                    {
                        throw new Exception("该手机号码已经被注册");
                    }

                    string smsCode = SMSHelper.GetRandom(6);
                    bool isComplete = false;
                    //短信验证码限制:小于等于 1天/5次 5条/小时 累计10条/天
                    string message = SMSHelper.SendMessage(phone, smsCode, out isComplete);
                    if (isComplete)
                    {
                        // 将手机验证码存入session
                        SetCacheSMSCode(smsCode);

                        //记录手机注册短信到数据库表
                        SMSLog smsLog = new SMSLog()
                        {
                            ID = Guid.NewGuid(),
                            Phone = phone,
                            Message = smsCode,
                            Created = DateTime.Now,
                            Status = true
                        };
                        SaveSMSLogArgs args = new SaveSMSLogArgs();
                        args.SMSLog = smsLog;
                        p.Client.SaveSMSLog(SenderUser, args);

                        //短信日志
                        WriteSuccess();
                    }
                    else
                    {
                        throw new Exception("发送失败," + message);
                    }
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// 将手机验证码存入session
        /// </summary>
        private void SetCacheSMSCode(string smsCode)
        {
            //设置页面不被缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.AppendHeader("Pragma", "No-Cache");

            Session["RegisterSMSCode"] = smsCode;
            Session["RegisterSMSCode_TimeOut"] = DateTime.Now.AddMinutes(10);
        }

        public void SearchPartners()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchPartnerArgs sargs = new SearchPartnerArgs();
                    sargs.OrderBy = "[PartnerCode]";
                    sargs.RowNumberFrom = pagingParm.RowNumberFrom;
                    sargs.RowNumberTo = pagingParm.RowNumberTo;

                    //Where
                    if (!string.IsNullOrEmpty(parm.PartnerCode))
                    {
                        sargs.PartnerCode = parm.PartnerCode;
                    }
                    if (!string.IsNullOrEmpty(parm.PartnerName))
                    {
                        sargs.PartnerName = parm.PartnerName;
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
                    if (CurrentUser.PartnerID != Guid.Empty)
                    {
                        sargs.PartnerIDs = new List<Guid>();
                        sargs.PartnerIDs.Add(CurrentUser.PartnerID);
                    }
                    SearchResult sr = p.Client.SearchPartner(SenderUser, sargs);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
                throw ex;
            }
        }

        public void GetPartner()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Guid custid = new Guid(Request["PartnerID"]);
                    Partner cust = p.Client.GetPartner(SenderUser, custid);
                    if (cust == null)
                    {
                        throw new Exception("所查找商户不存在。");
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

        public void ModifyPartner()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    Partner partner = p.Client.GetPartner(SenderUser, parm.PartnerID);
                    if (partner == null)
                    {
                        partner = new Partner();
                        partner.PartnerID = parm.PartnerID;
                    }
                    if (Request["Province"] == "")
                    {
                        throw new Exception("请选择省份");
                    }
                    if (Request["City"] == "请选择城市")
                    {
                        throw new Exception("请选择城市");
                    }
                    partner.ShopType = parm.ShopType;
                    partner.PartnerName = parm.PartnerName.Trim();
                    partner.LinkMan = parm.LinkMan.Trim();
                    partner.Email = parm.Email.Trim();
                    partner.Mobile = parm.Mobile.Trim();
                    partner.Tel = parm.Tel.Trim();
                    partner.Fax = parm.Fax.Trim();
                    partner.Remark = parm.Remark.Trim();
                    partner.Province = parm.Province;
                    partner.City = parm.City;
                    partner.ShopSize = parm.ShopSize;
                    partner.Address = parm.Address.Trim();
                    SavePartnerArgs args = new SavePartnerArgs();
                    args.Partner = partner;
                    p.Client.SavePartner(SenderUser, args);
                    WriteSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message, ex);
            }
        }

        public void SavePartner()
        {
            using (ProxyBE p = new ProxyBE())
            {
                try
                {
                    #region 验证
                    string phone = Request["egui-phone"];
                    string password = Request["egui-pwd"];
                    string smsCode = Request["egui-smscode"];
                    if (string.IsNullOrEmpty(phone))
                    {
                        throw new Exception("手机号不能为空");
                    }
                    Partner partnerModel = p.Client.GetPartnerByMobile(SenderUser, phone);
                    if (partnerModel != null)
                    {
                        throw new Exception("该手机号码已经被注册");
                    }
                    if (string.IsNullOrEmpty(password))
                    {
                        throw new Exception("密码不能为空");
                    }
                    if (string.IsNullOrEmpty(smsCode) || (!string.IsNullOrEmpty(smsCode) && smsCode.ToLower() != Session["RegisterSMSCode"].ToString().ToLower()))
                    {
                        throw new Exception("验证码错误");
                    }
                    #endregion

                    #region Partner
                    if (Request["Province"] == "")
                    {
                        //throw new Exception("请选择省份");
                    }
                    if (Request["City"] == "请选择城市")
                    {
                        //throw new Exception("请选择城市");
                    }
                    Partner Partner = new Partner();
                    Partner.PartnerID = parm.PartnerID;
                    Partner.ShopType = "1";
                    Partner.PartnerName = "商户" + phone;//
                    Partner.LinkMan = "联系人" + phone;//联系人
                    Partner.Email = "";
                    Partner.Mobile = phone;
                    Partner.Tel = "无(主动注册)";//销售人员
                    Partner.Fax = "";
                    Partner.Remark = "";
                    Partner.Province = "";
                    Partner.City = "";
                    Partner.ShopSize = 0;
                    Partner.Address = "";
                    SavePartnerArgs args = new SavePartnerArgs();
                    args.Partner = Partner;
                    p.Client.SavePartner(SenderUser, args);
                    #endregion

                    #region PartnerUser 
                    PartnerUser PartnerUser = new PartnerUser();
                    PartnerUser.UserID = Guid.NewGuid();
                    PartnerUser.Created = DateTime.Now;
                    //PartnerUser.CreatedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                    PartnerUser.CreatedBy = "Egui.biz";
                    PartnerUser.Modified = DateTime.Now;
                    //PartnerUser.ModifiedBy = SenderUser.UserCode + "." + SenderUser.UserName;
                    PartnerUser.ModifiedBy = "Egui.biz";
                    //admin经销商默认密码 123456
                    //PartnerUser.Password = MES.Libraries.CEncrypt.EncryptString(UserDefaultPassword);
                    PartnerUser.Password = MES.Libraries.CEncrypt.EncryptString(HttpContext.Current.Request["egui-pwd"]);

                    //int num = p.Client.GetIncrease(SenderUser, "admin");
                    //PartnerUser.UserCode = "admin" + num.ToString("#000
                    PartnerUser.UserCode = phone;


                    PartnerUser.UserName = "用户" + phone;
                    PartnerUser.PartnerID = parm.PartnerID;
                    PartnerUser.Sex = "男";
                    PartnerUser.Position = "管理员";
                    PartnerUser.Email = "";
                    PartnerUser.Mobile = phone;
                    PartnerUser.EndDate = DateTime.Now;
                    PartnerUser.Description = "管理员";
                    PartnerUser.LoginErrorCount = 0;
                    PartnerUser.IsDisabled = false;
                    PartnerUser.IsLocked = false;
                    PartnerUser.IsSystem = true;
                    PartnerUser.IsFinishInfo = false;
                    PartnerUser.MemberClass = -1;
                    bool flag = p.Client.PartnerUserIsDuplicated(SenderUser, PartnerUser);
                    if (flag)
                    {
                        throw new Exception("该手机号码已经被注册");
                    }
                    SavePartnerUserArgs pargs = new SavePartnerUserArgs();
                    pargs.PartnerUser = PartnerUser;
                    p.Client.SavePartnerUser(SenderUser, pargs);
                    #endregion

                    WriteSuccess();
                }
                catch (Exception ex)
                {
                    WriteError(ex.Message, ex);
                }
            }
        }

        public void SearchSMSLogs()
        {
            try
            {
                using (ProxyBE p = new ProxyBE())
                {
                    SearchSMSLogArgs args = new SearchSMSLogArgs();

                    args.OrderBy = "Created desc";
                    args.RowNumberFrom = pagingParm.RowNumberFrom;
                    args.RowNumberTo = pagingParm.RowNumberTo;

                    if (!string.IsNullOrEmpty(Request["CreatedFrom"]))
                    {
                        args.CreatedFrom = Convert.ToDateTime(Request["CreatedFrom"]);
                    }
                    if (!string.IsNullOrEmpty(Request["CreatedTo"]))
                    {
                        args.CreatedTo = Convert.ToDateTime(Request["CreatedTo"]).AddDays(1);
                    }

                    //Where
                    SearchResult sr = p.Client.SearchSMSLogs(SenderUser, args);
                    Response.Write(JSONHelper.Dataset2Json(sr.DataSet));
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                Response.Write(ex.Message);
            }
        }
    }
}