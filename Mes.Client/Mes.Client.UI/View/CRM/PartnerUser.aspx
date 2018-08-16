<%@ Page Title="经销商用户" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnerUser.aspx.cs" Inherits="Mes.Client.UI.View.CRM.PartnerUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.partnerUser.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="用户管理" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="background: #fff; border: 0px solid #ccc;">
                <table id="datagrid"></table>
            </div>
            <div region="north" border="false" style="text-align: left; height: 70px; overflow: hidden;" id="search_window">
                <div style="height: 60px; padding: 5px;" class="datagrid-toolbar">
                    <form id="search_form">
                        <table style="width: 100%; height: 50px;">
                            <tr>
                                <td class="lbl-caption">用户帐号:</td>
                                <td>
                                    <input type="text" id="UserCode" name="UserCode" />
                                </td>
                                <td class="lbl-caption">姓名:</td>
                                <td>
                                    <input id="UserName" type="text" name="UserName" style="width: 130px" />
                                </td>
                                <td class="lbl-caption">是否禁用:</td>
                                <td colspan="2">
                                    <select style="width: 120px" id="Select1" name="IsDisabled" class="easyui-combobox">
                                        <option value="请选择">请选择</option>
                                        <option value="true">是</option>
                                        <option value="false">否</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">手机号码:</td>
                                <td>
                                    <input type="text" id="Mobile" name="Mobile" />
                                </td>
                                <td style="text-align: left;">
                                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div region="east" split="true" title="用户资料管理" style="width: 400px;">
        <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_new">新增</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-edit" plain="true" id="editpass">重置密码</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="UserID" name="UserID" />
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                            <input type="hidden" id="RoleIDs" name="RoleIDs" />
                        </div>
                        <table cellpadding="3" id="tbPartnerUser">
                            <tr>
                                <td class="lbl-caption">用户编号:</td>
                                <td class="Wdate">
                                    <input name="UserCode" type="text" class="easyui-validatebox" required="true" maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">姓名:</td>
                                <td class="Wdate">
                                    <input name="UserName" type="text" class="easyui-validatebox" required="true" maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">性别:</td>
                                <td class="Wdate">
                                    <select id="Sex" name="Sex" style="width: 132px; text-align: center" class="easyui-combobox">
                                        <option value="男" selected="selected">男</option>
                                        <option value="女">女</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">职位:</td>
                                <td class="Wdate">
                                    <select id="Position" name="Position" style="width: 132px;" class="easyui-combobox" required="true">
                                        <option value="请选择">请选择</option>
                                        <option value="管理员">管理员</option>
                                        <option value="安装">安装</option>
                                        <option value="销售员">销售员</option>
                                        <option value="设计师">设计师</option>
                                        <option value="量尺">量尺</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">电子邮件:</td>
                                <td class="Wdate">
                                    <input id="Email" name="Email" type="text" class="easyui-validatebox" validtype="email" maxlength="30" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">移动电话:</td>
                                <td class="Wdate">
                                    <input id="Text3" validtype="mobile" name="Mobile" type="text" class="easyui-validatebox" required="true" maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">是否禁用:</td>
                                <td class="Wdate">
                                    <input type="checkbox" id="IsDisabled" name="IsDisabled" value="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">是否锁定:</td>
                                <td class="Wdate">
                                    <input type="checkbox" id="IsLocked" name="IsLocked" value="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">
                                    <label style="width: 120px;">描述</label>
                                </td>
                                <td colspan="3">
                                    <textarea id="Description" name="Description" cols="72" rows="3" style="width: 100%; height: 80px;" class="easyui-validatebox"
                                        validtype="length[0,800]" maxlength="800"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div title="所属角色" style="padding: 10px">
                        <ul id="tree"></ul>
                    </div>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
