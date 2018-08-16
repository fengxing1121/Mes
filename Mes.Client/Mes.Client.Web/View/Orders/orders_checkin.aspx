<%@ Page Title="订单上架" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders_checkin.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orders_checkin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.orders_checkin.js"></script>
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
                                <td style="width: 80px; text-align: right;">入库单号:
                                </td>
                                <td>
                                    <input type="text" id="Text1" name="BillNo" style="width: 100%;" />
                                </td>
                                <td style="width: 100px; text-align: right;">订单号：
                                </td>
                                <td>
                                    <input id="Text2" type="text" name="OrderNo" style="width: 100%;" />
                                </td>
                                <td style="width: 80px; text-align: right;">客户名称:
                                </td>
                                <td>
                                    <input type="text" id="Text3" name="CustomerName" style="width: 100%;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px; text-align: right;">客户地址:
                                </td>
                                <td>
                                    <input type="text" id="Address" name="Address" style="width: 100%;" />
                                </td>

                                <td style="width: 80px; text-align: right;">联系人:
                                </td>
                                <td>
                                    <input type="text" id="LinkMan" name="LinkMan" style="width: 100%;" />
                                </td>
                                <td style="width: 80px; text-align: right;">联系电话:
                                </td>
                                <td>
                                    <input type="text" id="Text5" name="Mobile" style="width: 100%;" />
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
            <!--新增入库-->
            <div id="edit_window" class="easyui-window" closed="true" title="新增入库" data-options="iconCls:'icon-save'"
                style="width: 700px; height: 380px; background: #fff;" minimizable="false" maximizable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false">
                        <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                            <div class="easyui-layout" fit="true" border="false">
                                <div region="north" border="false">
                                    <div>
                                        <input type="hidden" id="InID" name="InID" />
                                        <input type="hidden" id="H_OrderNo" name="H_OrderNo" />
                                        <input type="hidden" id="InDetail" name="InDetail" />
                                    </div>
                                    <table style="width: 100%; height: auto; padding: 5px;">
                                        <tr>
                                            <td class="lbl-caption">入库单号:
                                            </td>
                                            <td>
                                                <input type="text" id="BillNo" name="BillNo" class="easyui-validatebox" style="width: 150px;" required="true" />
                                            </td>

                                            <td class="lbl-caption">入库订单:
                                            </td>
                                            <td class="lbl-caption">
                                                <input type="text" style="width: 150px;" id="OrderID" name="OrderID" class="easyui-combogrid" editable="false" required="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div region="center" style="width: 10%; height: 100%;">
                                    <table id="selectedPackages">
                                    </table>
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

    <div id="Location_bar" style="padding: 5px; height: auto">
        <form id="search_form_location">
            <table>
                <tr>
                    <td>位置编号: </td>
                    <td style="text-align: left">
                        <input type="text" id="LocationCode" name="LocationCode" /></td>
                    <td>货架号: </td>
                    <td style="text-align: left">
                        <input type="text" id="CabinetNum" name="CabinetNum" /></td>
                    <td colspan="2" style="text-align: center;"><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btnSearchLocation">搜索</a>
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
                    <td class="lbl-caption">手机: </td>
                    <td style="text-align: left">
                        <input type="text" id="Mobile" name="Mobile" /></td>

                </tr>
                <tr>
                    <td class="lbl-caption">采购单号: </td>
                    <td style="text-align: left">
                        <input type="text" id="PurchaseNo" name="PurchaseNo" /></td>
                    <td class="lbl-caption">产品类型</td>
                    <td style="text-align: left">
                        <input type="text" id="SearchCabinetType" name="CabinetType" class="easyui-combobox" style="height: 26px;" /></td>
                    <td colspan="2" style="text-align: center;"><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btnSearchOrder">搜索</a>
                    </td>
                </tr>
            </table>
            <div>
                <input type="hidden" id="Status" name="Status" value="I" />
            </div>
        </form>
    </div>

</asp:Content>
