<%@ Page Title="权限设置" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnerRoles.aspx.cs" Inherits="Mes.Client.Web.View.CRM.PartnerRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <script src="../../Script/forms/crm/jquery.forms.partnerRoles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div id="div_role" region="west" title="经销商角色" style="width: 400px;">
        <div style="border-top: solid 1px #0094ff;">
            <ul id="tree1"></ul>
        </div>
    </div>
    <div region="center" split="true" title="权限分配设置">
        <form id="edit_form_item" name="edit_form_item" method="post" style="width: 100%; height: 100%;">
            <div title="Hidden parameter">
                <input type="hidden" id="RoleID" name="RoleID" value="" />
                <input type="hidden" id="GroupID" name="GroupID" value="" />
            </div>
            <div style="text-align: left; padding: 10px;">
                &nbsp&nbsp
                <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_newgroup">添加组</a>&nbsp&nbsp
                <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_newrole">添加角色</a>&nbsp&nbsp                
                <a href="#" class="easyui-linkbutton" id="btn_save" icon="icon-save" style="width: 80px;">保存权限</a>
            </div>
            <div class="easyui-tabs" border="false" style="width: 100%; height: 100%;">
                <div id="div_usergroupinfo" title="组信息" style="padding: 10px; width: 100%; height: 100%; display: none;">
                    <input type="hidden" id="group_GroupID" name="GroupID" value="" />
                    <input type="hidden" id="dataType" name="type" value="" />
                    <input type="hidden" id="IsSystem" name="IsSystem" value="" />
                    <table cellpadding="3">
                        <tr>
                            <td>用户组名称:
                            </td>
                            <td>
                                <input id="group_GroupName" name="GroupName" type="text" class="easyui-validatebox" required="true"
                                    maxlength="30" style="width: 160px;" />
                            </td>
                        </tr>
                        <tr>
                            <td>备注:
                            </td>
                            <td>
                                <textarea id="group_Description" name="Description" cols="40" class="easyui-validatebox" validtype="length[0,200]"
                                    rows="3" style="width: 100%; height: 60px"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td>是否禁用:
                            </td>
                            <td>
                                <input type="checkbox" id="group_IsDisabled" name="IsDisabled" value="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>是否锁定:
                            </td>
                            <td>
                                <input type="checkbox" id="group_IsLocked" name="IsLocked" value="false" />
                            </td>
                        </tr>
                    </table>
                </div>

                <div id="div_roleinfo" title="角色信息" style="padding: 10px; width: 100%; height: 100%;">
                    <input type="hidden" id="role_RoleID" name="RoleID" />
                    <table cellpadding="3">
                        <tr>
                            <td>用户组:
                            </td>
                            <td>
                                <input id="role_GroupID" name="GroupID" class="easyui-combobox" style="width: 200px;" />
                            </td>
                        </tr>
                        <tr>
                            <td>角色名称:
                            </td>
                            <td>
                                <input id="role_RoleName" name="RoleName" type="text" class="easyui-validatebox"
                                    maxlength="30" style="width: 200px;" />
                            </td>
                        </tr>
                        <tr>
                            <td>备注:
                            </td>
                            <td>
                                <textarea id="role_Description" name="Description" cols="40" class="easyui-validatebox" validtype="length[0,200]"
                                    rows="3" style="width: 100%; height: 60px;"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td>是否禁用:
                            </td>
                            <td>
                                <input type="checkbox" id="role_IsDisabled" name="IsDisabled" value="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>是否锁定:
                            </td>
                            <td>
                                <input type="checkbox" id="role_IsLocked" name="IsLocked" value="false" />
                            </td>
                        </tr>
                    </table>
                </div>

                <div id="div_role2privilege" title="角色权限" style="padding: 10px; width: 100%; height: 100%;">
                    <ul id="tree2"></ul>
                </div>

                <div id="div_role2user" title="角色用户" style="padding: 10px; width: 100%; height: 100%;">
                    <input type="hidden" id="UserRoles" name="RoleID" />
                    <ul id="tree3"></ul>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
