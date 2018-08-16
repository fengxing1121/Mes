<%@ Page Title="订单排料优化" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordersoptimize.aspx.cs" Inherits="Mes.Client.Web.View.Orders.ordersoptimize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.ordersoptimize.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="订单列表" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false" >
            <div region="center" title="批次柜体明细" border="true">
                <table id="dgdetail">
                </table>
            </div>
            <div region="west" title="待优化批次" iconcls="text_list_bullets" border="true" style="width: 300px;" collapsible="false">
                    <div>
                        <ul id="battchs_tree">
                        </ul>
                    </div>
                </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <div>
                            <input type="hidden" id="Status" name="Status" value="M" />
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
                                    <select style="width: 120px" id="Select2" name="CabinetType" class="easyui-combobox" required="true">
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
                                <td class="lbl-caption">
                                </td>
                                <td colspan="2" style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
            <div id="submit_window" class="easyui-window" closed="true" title="系统提示" data-options="iconCls:'cog'"
                style="width: 300px; height: 200px; background: #fff;" minimizable="false" maximizable="false" closable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 33px;">
                                    <img src="/Content/images/ui-loading-pink-32x32.gif" />
                                </td>
                                <td style="width: 100%;">
                                    <span>正在下载优化开料数据，请稍候...</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div id="optimize_window" class="easyui-window" closed="true" title="选择批次" data-options="iconCls:'application_get'"
                style="width: 300px; height: 150px; background: #fff;" minimizable="false" maximizable="false" closable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                        <form id="optimize_form" method="post">
                            <table style="width: 100%; height: 100%;">
                                <tr>
                                    <td style="width: 100px; text-align: right;">批次号：
                                    </td>
                                    <td>
                                        <input type="text" id="BattchNum" name="BattchNum" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center;">
                                        <a href="javascript:void(0)" id="btn_optimize" class="easyui-linkbutton" icon="icon-save" style="width: 80px;">导出数据</a>
                                        <a href="javascript:void(0)" id="btn_optimize_close" class="easyui-linkbutton" icon="icon-save" style="width: 80px;">关闭</a>
                                    </td>
                                </tr>
                            </table>
                        </form>
                    </div>

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
