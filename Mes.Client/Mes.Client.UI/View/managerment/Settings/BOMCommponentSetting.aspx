<%@ Page Title="部门管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BOMCommponentSetting.aspx.cs" Inherits="Mes.Client.UI.View.Management.Settings.BOMCommponentSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/setting/BOMCommponentSetting.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="组件类型管理" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: 50px;" class="datagrid-toolbar">
                    <form id="search_form">
                        <table>
                            <tr>
                                <td class="lbl-caption">组件类型名称:</td>
                                <td>
                                    <input style="width: 100px" id="ComponentTypeNames" name="ComponentTypeName" class="easyui-validatebox" /></td>
                                <td class="lbl-caption">组件类型编码:</td>
                                <td>
                                    <input style="width: 100px" id="ComponentTypeCodes" name="ComponentTypeCode" class="easyui-validatebox" /></td>
                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>

                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
            <div region="center">
                <table id="datagrid">
                </table>
            </div>
        </div>
    </div>

    <%--右边大模块--%>
    <div region="east" title="组件类型资料管理" style="width: 400px;" split="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 0px; background: #fff; border: 1px solid #ccc;">
                <form id="edit_form" name="edit_form" method="post">
                    <div style="margin-bottom: 5px">
                        <a id="btn_add" class="easyui-linkbutton" icon="icon-add" href="javascript:void(0)" plain="true">新增</a>
                        <a id="btn_save" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)" plain="true">保存</a>
                    </div>
                    <div title="Hidden parameter">
                        <input type="hidden" id="ComponentTypeID" name="ComponentTypeID" value="0" />
                    </div>
                    <table cellpadding="3">
                        <tr>
                            <td class="lbl-caption">组件类型名称:
                            </td>
                            <td align="left">
                                <input id="ComponentTypeName" name="ComponentTypeName" type="text" style="width: 120px;" class="easyui-validatebox" required="true"
                                    maxlength="30" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">组件类型编码:
                            </td>
                            <td>
                                <input id="ComponentTypeCode" name="ComponentTypeCode" type="text" style="width: 120px;" class="easyui-validatebox" required="true"
                                    maxlength="100" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">父节点:
                            </td>
                            <td>
                                <select style="width: 125px" id="ParentID" name="ParentID" class="easyui-combobox">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">禁用标志:
                            </td>
                            <td>
                                <input type="checkbox" id="Status" name="Status" />
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
