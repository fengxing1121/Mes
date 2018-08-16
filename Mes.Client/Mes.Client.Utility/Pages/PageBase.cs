using Mes.Client.Model.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Mes.Client.Utility.Pages
{
    public class PageBase : System.Web.UI.MasterPage
    {
        public HttpRequest request;

        #region 构造函数
        public PageBase()
            : base()
        {
            request = Context.Request;
        }

        public PageBase(HttpRequest _request)
        {
            request = _request;
        }

        #endregion

        #region 固定变量
        /// <summary>
        /// 用户初始密码
        /// </summary>
        public const string KEY_USER_DEFAULT_PASSWORD = "KeyUserDefaultPassword";                            // 用户初始密码
        /// <summary>
        /// 第一次登录必须修改密码
        /// </summary>
        public const string KEY_MUST_CHANGE_PASSWORD_AT_FIRST_LOGIN = "KeyMustChangePasswordAtFirstLogin";   // 第一次登录必须修改密码
        /// <summary>
        /// 密码过期天数
        /// </summary>
        public const string KEY_DAYS_PASSWORD_EXPIRED = "KeyDaysPasswordExpired";                            // 密码过期天数
        /// <summary>
        /// 校验密码强度
        /// </summary>
        public const string KEY_MUST_VERIFY_PASSWORD_STRENGTH = "KeyMustVerifyPasswordStrength";             // 校验密码强度
        /// <summary>
        /// 新密码不可以和最后N次密码相同
        /// </summary>
        public const string KEY_PASSWORD_CAN_NOT_SAME_COUNT = "KeyPasswordCanNotSameCount";                  // 新密码不可以和最后N次密码相同
        /// <summary>
        /// 连续输入密码错误次数锁定用户
        /// </summary>
        public const string KEY_LOGIN_ERROR_COUNT = "KeyLoginErrorCount";                                    // 连续输入密码错误次数锁定用户 
        /// <summary>
        /// 工序代码：清洗
        /// </summary>
        public const string KEY_WORKFLOW_CLEAN_CODE = "Key_WorkFlow_CleanCode";
        /// <summary>
        /// 工序代码：封边
        /// </summary>
        public const string KEY_WORKFLOW_KEYEDGEDESC_CODE = "Key_WorkFlow_EdgeDescCode";
        /// <summary>
        /// 工序代码：普通开孔
        /// </summary>
        public const string KEY_WORKFLOW_NORMALDRILLINGHOLE_CODE = "Key_WorkFlow_NormalDrillingHoleCode";
        /// <summary>
        /// 工序代码：普通开槽
        /// </summary>
        public const string KEY_WORKFLOW_NORMALGROOVING_CODE = "Key_WorkFlow_NormalGroovingCode";
        /// <summary>
        /// 工序代码：普通开料
        /// </summary>
        public const string KEY_WORKFLOW_NORMALMADE_CODE = "Key_WorkFlow_NormalMadeCode";
        /// <summary>
        /// 工序代码：包装
        /// </summary>
        public const string KEY_WORKFLOW_PAGAGE_CODE = "Key_WorkFlow_PagageCode";
        /// <summary>
        /// 工序代码：异形打孔
        /// </summary>
        public const string KEY_WORKFLOW_SPECIALDRILLINGHOLE_CODE = "Key_WorkFlow_SpecialDrillingHoleCode";
        /// <summary>
        /// 工序代码：异形开槽
        /// </summary>
        public const string KEY_WORKFLOW_SPECIALGROOVING_CODE = "Key_WorkFlow_SpecialGroovingCode";
        /// <summary>
        /// 工序代码：异形开料
        /// </summary>
        public const string KEY_WORKFLOW_SPECIALMADE_CODE = "Key_WorkFlow_SpecialMadeCode";
        #endregion

        public Sender SenderUser
        {
            get
            {
                Sender sender = new Sender();
                sender.UserCode = CurrentUser.UserCode;
                sender.UserName = CurrentUser.UserName;
                sender.IdentityHostName = request.LogonUserIdentity.Name;
                sender.IPAddress = request.UserHostAddress;
                return sender;
            }
        }

        public SessionUser CurrentUser
        {
            get
            {
                SessionUser su = (SessionUser)Session["CustomPage_CurrentUser"];
                if (su == null)
                {
                    Session["CustomPage_CurrentUser"] = new SessionUser();
                    su = (SessionUser)Session["CustomPage_CurrentUser"];
                }
                return su;
            }
            set { Session["CustomPage_CurrentUser"] = value; }
        }

        /// <summary>
        /// 是否登录
        /// </summary>
        public bool IsLogin
        {
            get { return CurrentUser.UserID != Guid.Empty; }
        }

        public void RedirectErrorPage(string info)
        {
            Response.Redirect("/ErrorPage.aspx?error=" + info);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!IsLogin || OnlineUser.GetOnlineUser(CurrentUser.UserID) == null)
            {
                Response.Write("<script type=\"text/javascript\">top.location.href = '/View/Account/Login.aspx';</script>");
                return;
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// 无权访问
        /// </summary>
        public void NoRightAccess()
        {
            Response.Redirect("~/noright.aspx");
        }

        /// <summary>
        /// 执行脚本方法
        /// </summary>
        /// <param name="script"></param>
        public void ExcuteScript(string script)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), script, true);
        }

        /// <summary>
        /// 判断是否有权限操作
        /// </summary>
        /// <param name="plcode"></param>
        /// <param name="itemcode"></param>
        public bool CheckOpt(string plcode, string itemcode)
        {
            //判断是否有该菜单权限
            if (CurrentUser.PrivilegeCodes.ContainsKey(plcode.ToLower()))
            {
                //判断是否存在操作项权限
                List<string> items = CurrentUser.PrivilegeCodes[plcode.ToLower()];
                if (items.Contains(itemcode))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 获取菜单项下的操作项
        /// </summary>
        /// <param name="plcode"></param>
        /// <returns></returns>
        public string CheckOpt(string plcode)
        {
            //判断是否有该菜单权限
            if (CurrentUser.PrivilegeCodes.ContainsKey(plcode.ToLower()))
            {
                List<string> items = CurrentUser.PrivilegeCodes[plcode.ToLower()] as List<string>;
                string resutItem = string.Join(",", items.ToArray());
                return resutItem;
            }
            return "";
        }
    }
}
