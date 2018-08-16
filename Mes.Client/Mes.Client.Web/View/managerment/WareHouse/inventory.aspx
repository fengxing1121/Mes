<%@ Page Title="订单备货" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inventory.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.form.inventory.js"></script>
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
                        <div>
                            <input type="hidden" id="Status" name="Status" value="O" />
                        </div>
                        <table>
                            <tr>
                                <td class="lbl-caption">订单编号:</td>
                                <td style="width: 120px;">
                                    <input type="text" style="width: 120px" id="OrderNo" name="OrderNo" />
                                </td>
                                <td class="lbl-caption">采购单号:  </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="PurchaseNo" name="PurchaseNo" type="text" />
                                </td>
                                <td class="lbl-caption">批次号：
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="BattchNum" name="BattchNum" type="text" />
                                </td>

                                <td class="lbl-caption">产品类型:
                                </td>
                                <td>
                                    <select style="width: 120px" id="CabinetType" name="CabinetType" class="easyui-combobox" required="true">
                                        <option value="请选择">请选择</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>订货日期：</td>
                                <td>
                                    <input type="text" id="BookingDateFrom" name="BookingDateFrom" class="easyui-datebox" style="width: 125px; height: 25px;" /></td>
                                <td>至：</td>
                                <td>
                                    <input type="text" id="BookingDateTo" name="BookingDateTo" class="easyui-datebox" style="width: 125px; height: 25px;" /></td>
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="CustomerName" name="CustomerName" type="text" />
                                </td>
                                <td class="lbl-caption">订单类型:
                                </td>
                                <td style="width: 120px;">
                                    <select id="Select3" name="OrderType" style="width: 100%;" class="easyui-combobox" required="true">
                                        <option value="">全部</option>
                                        <option value="正常">正常</option>
                                        <option value="加急">加急</option>
                                        <option value="补货">补货</option>
                                        <option value="工程">工程</option>
                                        <option value="展会">展会</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>交货日期：</td>
                                <td>
                                    <input type="text" id="ShipDateFrom" name="ShipDateFrom" class="easyui-datebox" style="width: 125px; height: 25px;" /></td>
                                <td>至：</td>
                                <td>
                                    <input type="text" id="ShipDateTo" name="ShipDateTo" class="easyui-datebox" style="width: 125px; height: 25px;" /></td>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                                </td>
                                <td class="lbl-caption"></td>
                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
             
            <div id="steps_window" class="easyui-window" closed="true" title="审核明细" data-options="iconCls:'icon-save'"
                style="width: 850px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false">
                        <table id="dgsteps"></table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
