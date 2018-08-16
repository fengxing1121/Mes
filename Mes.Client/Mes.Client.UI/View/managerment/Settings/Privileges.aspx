<%@ Page Title="权限管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Privileges.aspx.cs" Inherits="Mes.Client.UI.View.Management.Settings.Privileges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/setting/Privileges.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" border="false" hide="true" split="true" title="菜单分组" fit="true">
        <table id="datagrid3" class="easyui-datagrid" style="width: 35%; height: auto">
        </table>
    </div>
    <%--子菜单--%>
    <div region="east" border="false" split="true" style="text-align: center; width: 65%;" title="子菜单">
        <table id="datagrid1">
        </table>
    </div>
    <div id="edit_window" class="easyui-window" closed="true" title="编辑" style="width: 600px; height: 450px;"
        closed="true">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false">
                <form id="edit_form" name="edit_form" method="post" style="width:100%;height:100%;">
                    <div class="easyui-layout" fit="true">
                        <div region="center" title="基本信息" style="padding: 0px; background: #fff;">
                            <table cellpadding="3">
                                <tr>
                                    <td class="lbl-caption">分组名称:
                                    </td>
                                    <td>
                                        <select style="width: 120px" id="CategoryID" name="CategoryID" class="easyui-combobox">
                                        </select>
                                    </td>
                                    <%--<td style="width: 200px;">操作权限</td>--%>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">页面地址:
                                    </td>
                                    <td>
                                        <input id="PageURL" name="PageURL" type="text" class="easyui-validatebox" required="true" maxlength="500" style="width: 200px;" />
                                    </td>
                                    <%--<td rowspan="7" style="vertical-align: top;">
                                        
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">模块名称:
                                    </td>
                                    <td>
                                        <input id="PrivilegeName" name="PrivilegeName" type="text" class="easyui-validatebox" required="true" maxlength="30" style="width: 150px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">图标:
                                    </td>
                                    <td>
                                        <input id="IconClass" name="IconClass" type="text" class="easyui-validatebox" maxlength="30" style="width: 150px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">模块编码:
                                    </td>
                                    <td>
                                        <input id="PrivilegeCode" name="PrivilegeCode" type="text" class="easyui-validatebox" required="true" maxlength="30" style="width: 150px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">显示序号: </td>
                                    <td>
                                        <input id="Sequence" name="Sequence" type="text" class="easyui-numberboxx" required="true" maxlength="30" style="width: 150px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">描述:
                                    </td>
                                    <td>
                                        <textarea id="Description" name="Description" cols="40" class="easyui-validatebox" validtype="length[0,200]"
                                            rows="3" style="width: 200px; height: 60px;"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">是否禁用:
                                    </td>
                                    <td>
                                        <input type="checkbox" id="IsDisabled" name="IsDisabled" />
                                    </td>
                                </tr>
                            </table>
                            <div title="Hidden parameter">
                                <input type="hidden" id="PrivilegeID" name="PrivilegeID" value="0" />
                                <input type="hidden" id="PCategoryID" name="PCategoryID" value="" />
                                <input type="hidden" id="PriviegeItems" name="PriviegeItems" value="" />
                            </div>
                        </div>
                        <div region="east" title="操作权限" collapsible="false" style="padding: 0px; background: #fff; width: 200px;">
                            <ul id="opertiontree">
                            </ul>
                        </div>
                        <div region="south" border="false" style="text-align: center; height: 40px;padding-top:10px;">
                            <a id="btn_edit_ok" icon="icon-save" href="javascript:void(0)">确定</a>
                            <a id="btn_edit_cancel" icon="icon-cancel" href="javascript:void(0)">关闭</a>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
