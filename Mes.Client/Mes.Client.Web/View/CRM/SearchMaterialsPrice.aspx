<%@ Page Title="材料价格查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchMaterialsPrice.aspx.cs" Inherits="Mes.Client.Web.View.CRM.SearchMaterialsPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Script/forms/crm/jquery.forms.SearchMaterialPrice.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="材料价格" region="center" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">材料类型: </td>
                                <td>
                                    <input style="width: 120px" id="SearchCategoryID" name="Category" class="easyui-combobox" />
                                </td>
                                <td class="lbl-caption">子类型:</td>
                                <td>
                                    <input style="width: 120px" id="SearchSubCategoryID" name="SubCategory" class="easyui-combobox" />
                                </td>
                                <td class="lbl-caption">材料名称:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" name="MaterialName" type="text" />
                                </td>
                                <td class="lbl-caption">型号:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" name="Style" type="text" />
                                </td>
                                <td class="lbl-caption">颜色:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" name="Color" type="text" />
                                </td>
                                <td>
                                    <a href="javascript:void(0)" id="btn_search_ok" class="easyui-linkbutton" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                                <td class="lbl-caption"></td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
