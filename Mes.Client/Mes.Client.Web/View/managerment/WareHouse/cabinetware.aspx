<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cabinetware.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.cabinetware" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.forms.cabinetware.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="线条仓库库存" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">材料编号:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="MaterialCode" name="MaterialCode" type="text" />
                                </td>
                                <td class="lbl-caption">材料名称</td>
                                <td style="width: 120px;">
                                    <input type="text" style="width: 120px" id="MaterialName" name="MaterialName" />
                                </td>
                                <td class="lbl-caption">材料类型:
                                </td>
                                <td>
                                    <input style="width: 120px" id="CategoryID" name="Category" class="easyui-combobox" value="" />
                                </td>
                                <td class="lbl-caption">子类型:
                                </td>
                                <td>
                                    <input style="width: 120px" id="SubCategoryID" name="SubCategory" class="easyui-combobox" value="" />
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
</asp:Content>
