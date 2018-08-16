<%@ Page Title="订单分拣" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orderspackage.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orderspackage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.orderspackage.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="订单列表" region="center" style="border: 0px;" border="false">
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
                                <td class="lbl-caption">订单编号</td>
                                <td style="width: 120px;">
                                    <input type="text" style="width: 120px" id="OrderNo" name="OrderNo" />
                                </td>
                                <td class="lbl-caption">订单类型:
                                </td>
                                <td class="lbl-caption">
                                    <%--<input style="width: 120px" id="Brand" name="Brand" class="easyui-combobox" value="请选择" />--%>
                                    <select id="OrderType" name="OrderType" style="width: 100%;" class="easyui-combobox" required="true">
                                        <option value="">全部</option>
                                        <option value="正常">正常</option>
                                        <option value="加急">加急</option>
                                        <option value="补货">补货</option>
                                        <option value="工程">工程</option>
                                        <option value="展会">展会</option>
                                    </select>
                                </td>
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="CustomerName" name="CustomerName" type="text" />
                                </td>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                                </td>
                                <td colspan="2" style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
