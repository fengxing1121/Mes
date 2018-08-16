<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Mes.Client.UI.Index" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
    <link href="/Content/css/ext_icons.css" rel="stylesheet" />
    <link href="/Content/css/Index.css" rel="stylesheet" />
    <script src="/Script/forms/jquery.min.form.index.js?ver=1.12"></script>
    <style>
        .tabs-inner{
            height:30px;
            padding:10px;
            margin:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="Main" runat="server">
    <!-- 头部 -->
    <div region="north" border="false" style="overflow: hidden; height: 50px; line-height: 50px; background: #0e0e0e; color: rgba(255,255,255,.7);">
        <div style="display: inline-block; float: right; height: 50px; line-height: 50px;">
            <span class="head" style="padding-right: 20px;"><label id="userinfo"></label>
            <a href="javascript:void(0);" id="editpass">修改密码</a>
                <a href="javascript:void(0);" id="loginOut">安全退出</a>
            </span>
        </div>
        <span style="padding-left: 50px; font-size: 16px;">全屋定制家具MES生产管理系统
        </span>
    </div>

    <!-- 左侧导航部分 -->
    <div region="west" hide="true" split="false" iconcls="world" title="工作中心" style="width: 190px; padding: 0px;" id="west">
        <div id="nav" class="easyui-accordion" fit="true" border="false"></div>
    </div>

    <input id="tabmax" type="hidden" value='100' />
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden">
        <div id="tabs" class="easyui-tabs" border="false" fit="true">
            <div iconcls="layout" title="我的工作台" region="center">
                <div style="height: 32px; text-align: right; padding-right: 10px; padding-top: 5px;display:none;">
                    <a href="#" id="btn_FavoriteSetting">
                        <img src="/Content/images/menu_nav.png" /></a>
                </div>
                <div class="huanyin">
                    <span></span>
                    <p class="p_1">欢迎使用MES生产管理系统</p>
                    <p class="p_2">真诚至上、用心服务</p>
                </div>
                <ul class="deskmenu" id="nav_deskshortcut">
                </ul>
            </div>
        </div>
    </div>

    <!-- 用户修改密码窗口 -->
    <div id="win_changepwd" class="easyui-window" closed="true" title="修改密码" iconcls="key_add" style="width: 350px; height: 200px; padding: 5px; background: #fafafa; display: none;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc;">
                <form id="win_changepwd_form" name="win_changepwd_form" method="post">
                    <table cellpadding="3" align="center">
                        <tr>
                            <td>旧密码：
                            </td>
                            <td>
                                <input id="OldPassword" name="OldPassword" type="Password" class="easyui-validatebox" required="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>新密码：
                            </td>
                            <td>
                                <input id="NewPassword" name="NewPassword" type="Password" class="easyui-validatebox" required="true" />
                                <div id="passwordStrengthDiv" class="is0"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>确认密码：
                            </td>
                            <td>
                                <input id="NewPasswordRe" name="NewPasswordRe" type="Password" class="easyui-validatebox" required="true" validtype="equalTo['#NewPassword']" />
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; height: 30px;">
                <a id="btnConfirm" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">确定</a>
                <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel" href="javascript:void(0)">关闭</a>
            </div>
        </div>
    </div>


    <!-- Tab右键操作 -->
    <div id="mm" class="easyui-menu" style="width: 150px; display: none;" title="多标签右键菜单" closed="true">
        <div id="mm-tabupdate">
            刷新
        </div>
        <%--<div class="menu-sep">
        </div>--%>
        <div id="mm-tabclose">
            关闭当前页面
        </div>
        <div id="mm-tabcloseall">
            关闭全部页面
        </div>
        <div id="mm-tabcloseother">
            关闭其他页面
        </div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            关闭右侧所有页面
        </div>
        <div id="mm-tabcloseleft">
            关闭左侧所有页面
        </div>
        <div class="menu-sep">
        </div>
        <div id="mm-exit">
            退出
        </div>
    </div>

    <!--我的桌面设置-->
    <div id="favorite_window" class="easyui-window" title="我的桌面设置" closed="true" iconcls="key_add"
        style="width: 600px; height: 480px; background: #fafafa; display: none;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc;">
                <form id="favorite_form" name="favorite_form" method="post" style="width: 100%; height: 100%;">
                    <table id="dgfavorite"></table>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; height: 30px; display: table-cell; vertical-align: middle;">
                <a id="btnCloseFavorite" class="easyui-linkbutton" icon="icon-cancel" href="javascript:void(0)">关闭</a>
            </div>
        </div>
    </div>

    <!--我的权限菜单-->
    <div id="privilege_window" class="easyui-window" title="我的权限菜单" closed="true" iconcls="key_add"
        style="width: 600px; height: 480px; background: #fafafa; display: none;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc;">
                <form id="privilege_form" name="privilege_form" method="post" style="width: 100%; height: 100%;">
                    <table id="dgprivilege"></table>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; height: 30px; display: table-cell; vertical-align: middle;">
                <a id="btnSaveFavorite" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)">确定</a>
                <a id="btnClosePrivilege" class="easyui-linkbutton" icon="icon-cancel" href="javascript:void(0)">关闭</a>
            </div>
        </div>
    </div>

    <div id="view_window" class="easyui-window" closed="true" title="板件浏览器" data-options="iconCls:'icon-save'" style="width: 900px; height: 580px; background: #fff;" minimizable="true" maximizable="true">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <iframe src="#" id="iframeView" name="iframeView" width="100%" height="99%" frameborder="0"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
