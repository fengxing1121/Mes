<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mes.Client.Web.View.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>用户登陆 - MES生产管理系统</title>
    <link rel="shortcut icon" href="../../Content/images/meiwu.png" type="image/x-icon" />
    <link href="../../Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../../Script/layui/layui.js"></script>
    <script src="../../Script/forms/login/login.js"></script>
    <style>
        .layui-input::-webkit-input-placeholder,.layui-select::-webkit-input-placeholder,.layui-textarea::-webkit-input-placeholder{color:#ccc;line-height:1.3}.layui-form-radio>i:hover,.layui-form-radioed>i{color:#1E9FFF}.y-row{margin-right:auto;margin-left:auto;max-width:1200px;min-width:1000px;zoom:1}#header{padding:0;width:100%;height:74px;border-bottom:1px solid #e3e3e3;background-color:#fff}#header .header-layout{overflow:hidden;padding:17px 0}#header .header-layout .logo{float:left;display:inline-block;height:40px;background-size:100%;font-weight:300;font-size:26px;line-height:40px}#header .header-layout .header-nav{float:right;margin-top:10px;width:auto;height:14px;line-height:14px}#header .header-layout .header-nav li{float:left;margin-right:10px;padding:0 0 0 10px;border-left:1px solid #4d4d4d}#header .header-layout .header-nav li.nav-first{border-left:0}#header .header-layout .header-nav li a{color:#666;text-decoration:none;font-size:14px}.layadmin-user-login{position:relative;top:0;left:0;box-sizing:border-box;padding:110px 0;min-height:100%}#LAY-user-login,.layadmin-user-display-show{display:block!important}.layadmin-user-login-icon{position:absolute;top:1px;left:1px;width:38px;color:#d2d2d2;text-align:center;line-height:36px}.layadmin-user-login-main{box-sizing:border-box;margin:0 auto;width:375px}.layadmin-user-login-box{padding:20px}.layadmin-user-login-header{text-align:center}.layadmin-user-login-header h2{margin-bottom:10px;color:#000;font-weight:300;font-size:22px}.layadmin-user-login-header p{color:#999;font-weight:300}.layadmin-user-login-body .layui-form-item{position:relative}.layadmin-user-login-icon{position:absolute;top:1px;left:1px;width:38px;color:#d2d2d2;text-align:center;line-height:36px}.layadmin-user-login-body .layui-form-item .layui-input{padding-left:38px}.layadmin-user-login-codeimg{box-sizing:border-box;width:100%;max-height:38px;border:1px solid #e6e6e6;cursor:pointer}.layadmin-user-login-other{position:relative;padding-top:20px;font-size:0;line-height:38px}.layadmin-user-login-other>*{display:inline-block;margin-right:10px;vertical-align:middle;font-size:14px}.layadmin-user-login-other .layui-icon{position:relative;top:2px;font-size:26px}.layadmin-user-login-other a:hover{opacity:.8}.layadmin-user-jump-change{float:right;color:#999}.copyright-100{clear:both;border-top:1px solid #e5e5e5;background:#fff}.copyright-100 .copyright{padding:35px 0 40px;color:#999;text-align:center}.copyright-100 .copyright p{padding:5px 0}.copyright-100 .copyright span{padding:0 5px}.copyright-100 .copyright p.big a{color:#666;text-decoration:none}
    </style>
</head>
<body>
    <div id="header">
        <div class="header-layout y-row" style="margin: 0 auto; padding-top: 20px;">
            <h2 class="logo" id="logo">定制家具生产管理系统
            </h2>
            <ul class="header-nav">
                <li class="nav-first"><a href="http://www.egui.biz/" target="_blank">全屋衣柜 </a></li>
                <li><a href="http://gzmeiwu.com/" target="_blank">公司网站 </a></li>
            </ul>
        </div>
    </div>
    <div class="layadmin-user-login layadmin-user-display-show">
        <div class="layadmin-user-login-main">
            <div class="layadmin-user-login-box layadmin-user-login-header">
                <h2>MES生产管理系统</h2>
                <p>家具生产管理系统用户登录</p>
            </div>
            <div class="layadmin-user-login-box layadmin-user-login-body layui-form">
                <form class="layui-form" action="">
                    <div class="layui-form-item">
                        <label class="layadmin-user-login-icon layui-icon layui-icon-username" for="LAY-user-login-username"></label>
                        <input type="text" name="username" id="LAY-user-login-username" lay-verify="required" placeholder="用户名" class="layui-input" />
                    </div>
                    <div class="layui-form-item">
                        <label class="layadmin-user-login-icon layui-icon layui-icon-password" for="LAY-user-login-password"></label>
                        <input type="password" name="password" id="LAY-user-login-password" lay-verify="required" placeholder="密码" class="layui-input" />
                    </div>
                    <div class="layui-form-item">
                        <div class="layui-row">
                            <div class="layui-col-xs7">
                                <label class="layadmin-user-login-icon layui-icon layui-icon-vercode" for="LAY-user-login-verifycode"></label>
                                <input type="text" name="verifycode" id="LAY-user-login-verifycode" lay-verify="required|verifycode" placeholder="图形验证码" class="layui-input" />
                            </div>
                            <div class="layui-col-xs5">
                                <div style="margin-left: 10px;">
                                    <img src="/Ashx/VerifyCodeHanler.ashx" title="看不清？换一张" class="layadmin-user-login-codeimg" id="LAY-user-get-vercode" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="layui-form-item" style="margin-bottom: 30px;">
                        <div>
                            <input type="radio" name="loginRoles" value="factory" title="工厂登录" checked="" />
                            <input type="radio" name="loginRoles" value="partner" title="门店登录" />
                            <a href="ResetPwd.aspx" class="layadmin-user-jump-change layadmin-link" style="margin-top: 7px;">忘记密码？</a>
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <button class="layui-btn layui-btn-fluid layui-btn-normal" lay-submit="" lay-filter="LAY-user-login-submit">登 录</button>
                    </div>
                    <%--<div class="layui-trans layui-form-item layadmin-user-login-other">
                    <label>社交账号登入</label>
                    <a href="javascript:;"><i class="layui-icon layui-icon-login-qq"></i></a>
                    <a href="javascript:;"><i class="layui-icon layui-icon-login-wechat"></i></a>
                    <a href="javascript:;"><i class="layui-icon layui-icon-login-weibo"></i></a>

                    <a lay-href="/user/reg" class="layadmin-user-jump-change layadmin-link">注册帐号</a>
                </div>--%>
                </form>
            </div>
        </div>
    </div>
    <div class="copyright-100" data-spm="999" style="overflow-x: hidden; overflow-y: hidden;">
        <div class="y-row copyright">
            <p class="big">
                <span><a href="#" target="_blank">关于我们</a></span>
                <span><a href="#" target="_blank">服务条款</a></span>
                <span><a href="#" target="_blank">帮助中心</a></span>
                <span><a href="#" target="_blank">用户手册</a></span>
            </p>
            <%--<p><span><a href="#" target="_blank">广州美屋互联网科技有限公司 </a></span></p>--%>
            <p>Copyright ©  2016-<%=DateTime.Now.Year %> gzmeiwu.com 版权所有   </p>
        </div>
    </div>
</body>
</html>
