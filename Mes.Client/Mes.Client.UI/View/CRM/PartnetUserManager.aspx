<%@ Page Title="门店账户" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnetUserManager.aspx.cs" Inherits="Mes.Client.UI.View.CRM.PartnetUserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.partnerUserManager.js?ver=1.3"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="门店账户" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="background: #fff; border: 0px solid #ccc;">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: left; height: 70px; overflow: hidden;" id="search_window">
                <div style="height: 60px; padding: 5px;" class="datagrid-toolbar">
                    <form id="search_form">
                        <table style="width: 100%; height: 50px;">
                            <tr>
                                <td class="lbl-caption">门店账户:</td>
                                <td>
                                    <input type="text" id="UserCode" name="UserCode" />
                                </td>
                                <td class="lbl-caption">姓名:</td>
                                <td>
                                    <input id="UserName" type="text" name="UserName" style="width: 130px" />
                                </td>
                                <td class="lbl-caption">是否禁用:</td>
                                <td colspan="2">
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
    <div region="east" split="true" title="门店账户管理" style="width: 400px;">
        <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
            <form id="edit_form" name="edit_form" method="post">
                <div style="margin-bottom: 5px">
                    <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-edit" plain="true" id="btn_editpass">重置密码</a>
                </div>
                <div class="easyui-tabs" border="false">
                    <div title="基本信息" style="padding: 10px" fit="true">
                        <div>
                            <input type="hidden" id="UserID" name="UserID" />
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                            <input type="hidden" id="RoleIDs" name="RoleIDs" />
                            <input type="hidden" id="PrivilegeItemS" name="PrivilegeItemS" />
                        </div>
                        <table cellpadding="3" id="tbPartnerUser">
                            <tr>
                                <td class="lbl-caption">门店账户:<span style="color: red;">*</span></td>
                                <td class="Wdate">
                                    <input id="UserCodes" name="UserCode" type="text" class="easyui-validatebox" required="true" maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">姓名:<span style="color: red;">*</span></td>
                                <td class="Wdate">
                                    <input id="Text2" name="UserName" type="text" class="easyui-validatebox" required="true" maxlength="30" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">移动电话:<span style="color: red;">*</span></td>
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
                                    <textarea id="Description" name="Description" cols="72" rows="3" style="width: 100%; height: 80px;" class="easyui-validatebox"  validtype="length[0,800]" maxlength="800"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div title="经销商权限" style="padding: 10px">
                        <ul id="tree"></ul>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
