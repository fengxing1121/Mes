<%@ Page Title="订单补货" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orderservice.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orderservice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <script src="/Script/forms/orders/jquery.forms.orderservice.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
            <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="north" border="false">
                        <div>
                            <input type="hidden" id="OrderID" name="OrderID" />
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                            <input type="hidden" id="H_CustomerID" name="CustomerName" />
                            <input type="hidden" id="Cabinets" name="Cabinets" />
                            <input type="hidden" id="HardwareDetails" name="HardwareDetails" />
                            <input type="hidden" id="OrderDetails" name="OrderDetails" />
                        </div>
                        <table style="width: 100%; height: auto; padding: 5px;">
                            <tr>
                                <td class="lbl-caption" style="width: 120px;">订单编号:
                                </td>
                                <td>
                                    <input type="text" id="OrderNo" name="OrderNo" style="width: 200px;" placeholder="自动生成" readonly="true" />
                                </td>

                                <td class="lbl-caption" style="width: 120px;">源订单号:
                                </td>
                                <td>
                                    <input type="text" id="PurchaseNo" name="PurchaseNo" class="easyui-combogrid" editable="true" style="height: 27px; width: 200px;" />
                                </td>
                                <td class="lbl-caption">订单类型:
                                </td>
                                <td>
                                    <input type="text" id="OrderType" name="OrderType" value="补货" readonly="true" style="height: 27px; width: 200px;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">产品类型:
                                </td>
                                <td>
                                    <input type="text" style="height: 27px; width: 200px;" id="CabinetType" name="CabinetType" class="easyui-combobox" required="true">
                                </td>
                                <td class="lbl-caption">是否正标:
                                </td>
                                <td>
                                    <input type="checkbox" id="IsStandard" name="IsStandard" value="false" />
                                </td>
                                <td class="lbl-caption">是否外购:
                                </td>
                                <td>
                                    <input type="checkbox" id="IsOutsourcing" name="IsOutsourcing" value="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">客户名称: </td>
                                <td>
                                    <input type="text" id="CustomerID" name="CustomerID" class="easyui-combogrid" style="height: 27px; width: 200px;" editable="false" required="true" />
                                </td>
                                <td class="lbl-caption">订货日期: </td>
                                <td>
                                    <input type="text" id="BookingDate" name="BookingDate" class="easyui-datebox" style="height: 27px; width: 200px;" required="true" />
                                </td>
                                <td class="lbl-caption">交货日期:</td>
                                <td>
                                    <input type="text" id="ShipDate" name="ShipDate" class="easyui-datebox" style="height: 27px; width: 200px;" required="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td>
                                    <input type="text" id="Mobile" name="Mobile" style="width: 200px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">联系人:
                                </td>
                                <td>
                                    <input type="text" id="LinkMan" name="LinkMan" style="width: 200px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">订单状态:
                                </td>
                                <td>
                                    <input type="text" id="Status" name="Status" style="width: 200px;" value="待拆单" placeholder="待拆单" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">客户地址:
                                </td>
                                <td colspan="7">
                                    <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">备注:
                                </td>
                                <td colspan="5">
                                    <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 50px;"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">补货原因:
                                </td>
                                <td colspan="5">
                                    <select id="Description" name="Description" style="width: 200px; height: 27px;" class="easyui-combobox" required="true">
                                        <option>客户增加板件/产品</option>
                                        <option>产品尺寸有误</option>
                                        <option>运输中板件损坏</option>
                                        <option>运输中部件遗失</option>
                                        <option>五金件尺寸有误</option>
                                        <option>五金件数量有误</option>
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;">
                        <div class="easyui-tabs" border="false" fit="true">
                            <div title="补板件" iconcls="icon table">
                                <div class="easyui-layout" fit="true">
                                    <div region="center" border="false">
                                        <table id="dgOrderDetail">
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div title="补五金" iconcls="icon table">
                                <div class="easyui-layout" fit="true">
                                    <div region="center" border="false">
                                        <table id="dgHardware">
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div title="补产品" fit="true" iconcls="icon table" border="false">
                                <div class="easyui-layout" fit="true">
                                    <div region="center" border="false">
                                        <table id="dgCabinet">
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                        <a id="btn_edit_save" icon="icon-save" style="width: 100px; height: 30px; background: #ff6a00; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">提交订单</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div id="tb" style="padding: 5px; height: auto">
        <form id="search_form_customer">
            <table>
                <tr>
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" id="CustomerNames" name="CustomerName" /></td>
                    <td class="lbl-caption">移动电话: </td>
                    <td style="text-align: left">
                        <input type="text" id="Text1" name="Mobile" /></td>
                </tr>
                <tr>
                    <td class="lbl-caption">联系地址: </td>
                    <td style="text-align: left">
                        <input type="text" id="Text2" name="Address" /></td>
                    <td class="lbl-caption"></td>
                    <td><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_customer">搜索</a>
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
                <input type="hidden" id="Status" name="Status" value="F" />
            </div>
        </form>
    </div>
</asp:Content>
