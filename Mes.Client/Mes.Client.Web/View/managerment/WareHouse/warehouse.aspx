<%@ Page Title="仓库资料" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="warehouse.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.warehouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.forms.warehouse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="仓位列表" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <div>
                            <input id="ParentID" name="ParentID" type="hidden" />
                        </div>
                        <table>
                            <tr>
                                <td class="lbl-caption">仓库编码</td>
                                <td>
                                    <input type="text" style="width: 120px" id="SearchCategoryCode" name="SearchCategoryCode" />
                                </td>
                                <td class="lbl-caption">仓库名称:
                                </td>
                                <td>
                                    <input type="text" style="width: 120px" id="SearchCategoryName" name="SearchCategoryName" />
                                </td>
                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div region="east" split="true" title="仓库管理" style="width: 400px;" border="false">
        <form id="edit_form" method="post">
            <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                <div style="margin-bottom: 5px;">
                    <a id="btn_edit_new" icon="icon-add" class="easyui-linkbutton" href="javascript:void(0)">新增</a>
                    <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                </div>
                <table style="width: 95%; height: 100%;">
                    <div>
                        <input type="hidden" id="CategoryID" name="CategoryID" />
                        <input type="hidden" id="Hidden1" name="ParentID" />
                        <input type="hidden" id="ShortName" name="ShortName" />
                    </div>
                    <tr>
                        <td class="lbl-caption">仓库编码:
                        </td>
                        <td>
                            <input type="text" id="CategoryCode" name="CategoryCode" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">仓库名称:
                        </td>
                        <td>
                            <input type="text" id="CategoryName" name="CategoryName" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">排序编号:
                        </td>
                        <td>
                            <input type="text" id="Sequence" name="Sequence" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</asp:Content>
