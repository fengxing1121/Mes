<%@ Page Title="订单发货" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders_checkout.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orders_checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.orders_checkout.js"></script>
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
                                <td style="width: 80px; text-align: right;">运输单号:
                                </td>
                                <td>
                                    <input type="text" id="txtTransportNo" name="TransportNo" style="width: 100%;" />
                                </td>
                                <td style="width: 100px; text-align: right;">车牌号：
                                </td>
                                <td>
                                    <input id="txtPlateNo" type="text" name="PlateNo" style="width: 100%;" />
                                </td>
                                <td style="width: 80px; text-align: right;">驾驶人:
                                </td>
                                <td>
                                    <input type="text" id="txtDriverName" name="DriverName" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; text-align: right;">物流企业:
                                </td>
                                <td>
                                    <input type="text" id="EnterpriseName" name="EnterpriseName" style="width: 100%;" />
                                </td>

                                <td style="width: 80px; text-align: right;">出发地:
                                </td>
                                <td>
                                    <input type="text" id="txtSource" name="Source" style="width: 100%;" />
                                </td>

                                <td style="width: 80px; text-align: right;">目的地:
                                </td>
                                <td>
                                    <input type="text" id="txtTarget" name="Target" style="width: 100%;" />
                                </td>

                                <td style="width: 80px; text-align: right;"></td>
                                <td colspan="2" style="text-align: left">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>

            <!--新增出库-->
            <div id="edit_window" class="easyui-window" closed="true" title="新增出库" data-options="iconCls:'icon-save'"
                style="width: 800px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false">
                        <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                            <div class="easyui-layout" fit="true" border="false">
                                <div region="north" border="false">
                                    <div>
                                        <input type="hidden" id="TransportID" name="TransportID" />
                                        <input type="hidden" id="OutDetail" name="OutDetail" />
                                    </div>
                                    <table style="width: 100%; height: auto; padding: 5px;">
                                        <tr>
                                            <td class="lbl-caption" style="width: 120px;">运输单号:
                                            </td>
                                            <td>
                                                <input type="text" id="TransportNo" name="TransportNo" style="width: 100%;" class="easyui-validatebox" required="true"/>
                                            </td>
                                            <td class="lbl-caption">车辆:
                                            </td>
                                            <td>
                                                <input id="CarID" name="CarID" class="easyui-combogrid" required="true" style="width: 120px;" />
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="lbl-caption">出发地:
                                            </td>
                                            <td>
                                                <input type="text" id="Source" name="Source" style="width: 100%;" class="easyui-validatebox" required="true" />
                                            </td>
                                            <td class="lbl-caption">目的地:
                                            </td>
                                            <td>
                                                <input type="text" id="Target" name="Target" style="width: 100%;" class="easyui-validatebox" required="true" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="lbl-caption">运输费用:
                                            </td>
                                            <td>
                                                <input type="text" id="Price" name="Price" style="width: 100%;" class="easyui-validatebox" required="true" />
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;">
                                    <table id="dgWareHouseOut" title="添加出库订单"></table>
                                </div>

                            </div>
                        </form>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                        <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                        <a id="btn_edit_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div id="car_bar" style="padding: 5px; height: auto">
        <form id="search_form_car">
            <table>
                <tr>
                    <td class="lbl-caption">车牌号:
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px" id="PlateNo" name="PlateNo" type="text" />
                    </td>
                    <td class="lbl-caption">驾驶人：
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="DriverName" name="DriverName" type="text" />
                    </td>
                    <%--<td class="lbl-caption">移动电话:
                    </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                    </td>--%>
                    <td colspan="2" style="text-align: left">
                        <a href="javascript:void(0)" id="search_car" icon="icon-search" style="width: 80px;">搜索</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>

    <div id="order_bar" style="padding: 5px; height: auto">
        <form id="search_form_order">
            <table>
                <tr>
                    <td class="lbl-caption">订单编号: </td>
                    <td style="text-align: left">
                        <input type="text" id="OrderNo" name="OrderNo" /></td>
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" id="CustomerName" name="CustomerName" /></td>
                </tr>
                <tr>
                    <td class="lbl-caption">采购单号: </td>
                    <td style="text-align: left">
                        <input type="text" id="PurchaseNo" name="PurchaseNo" /></td>
                    <td class="lbl-caption">手机: </td>
                    <td style="text-align: left">
                        <input type="text" id="Mobile" name="Mobile" /></td>
                    <td colspan="2" style="text-align: center;"><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btnSearchOrder">搜索</a>
                    </td>
                </tr>
            </table>
            <div>
                <input type="hidden" id="Status" name="Status" value="R" />
            </div>
        </form>
    </div>
</asp:Content>
