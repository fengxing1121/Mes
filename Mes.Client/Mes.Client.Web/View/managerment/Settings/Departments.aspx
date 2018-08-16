<%@ Page Title="部门管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="Mes.Client.Web.View.Management.Settings.Departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/setting/departments.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="部门管理" region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: 50px;" class="datagrid-toolbar">
                    <form id="search_form">
                        <table>
                            <tr>
                                <td class="lbl-caption">部门编号:</td>
                                <td>
                                    <input style="width: 100px" id="DepartmentCodes" name="DepartmentCode" class="easyui-validatebox" /></td>
                                <td class="lbl-caption">部门名称:</td>
                                <td>
                                    <input style="width: 100px" id="DepartmentNames" name="DepartmentName" class="easyui-validatebox" /></td>
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
    <div  region="east" title="部门资料管理" style="width: 400px;" split="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 0px; background: #fff; border: 1px solid #ccc;">
                <form id="edit_form" name="edit_form" method="post">
                    <div style="margin-bottom: 5px">
                        <a id="btn_add" class="easyui-linkbutton" icon="icon-add" href="javascript:void(0)" plain="true">新增</a>
                        <a id="btn_save" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)" plain="true">保存</a>
                    </div>
                    <div title="Hidden parameter">
                        <input type="hidden" id="DepartmentID" name="DepartmentID" value="0" />
                    </div>
                    <table cellpadding="3">
                        <tr>
                            <td class="lbl-caption">部门编号:
                            </td>
                            <td align="left">
                                <input id="DepartmentCode" name="DepartmentCode" type="text" style="width: 120px;" class="easyui-validatebox" required="true"
                                    maxlength="30" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">部门名称:
                            </td>
                            <td>
                                <input id="DepartmentName" name="DepartmentName" type="text" style="width: 120px;" class="easyui-validatebox" required="true"
                                    maxlength="100" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">部门电话:
                            </td>
                            <td>
                                <input id="Tel" name="Tel" type="text" style="width: 120px;" class="easyui-validatebox"
                                    maxlength="30" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">传真:
                            </td>
                            <td>
                                <input id="Fax" name="Fax" type="text" style="width: 120px;" class="easyui-validatebox"
                                    maxlength="30" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">禁用标志:
                            </td>
                            <td>
                                <input type="checkbox" id="IsDisabled" name="IsDisabled"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">备注说明:
                            </td>
                            <td>
                                <textarea id="Description" name="Description" cols="72" rows="3" style="width: 100%; height: 80px;" class="easyui-validatebox" validtype="length[0,200]"></textarea>
                            </td>
                        </tr>

                    </table>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
