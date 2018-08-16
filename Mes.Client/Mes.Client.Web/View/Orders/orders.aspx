<%@ Page Title="订单查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/orders.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="订单列表" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">订单编号:</td>
                                <td>
                                    <input type="text" style="width: 120px" id="OrderNo" name="OrderNo" />
                                </td>
                                 <td class="lbl-caption">采购单号:
                                </td>
                                <td>
                                    <input style="width: 120px; height: 22px;" id="PurchaseNo" name="PurchaseNo" type="text" />
                                </td>
                                <td class="lbl-caption">订单状态:
                                </td>
                                <td class="lbl-caption">
                                    <select id="Status" name="Status" style="width: 125px;height:23px;" editable="false" class="easyui-combobox" required="true">
                                        <option value="">全部</option>
                                        <option value="N">待审核</option>
                                        <option value="S">待拆单</option>
                                        <option value="Y">拆单确认</option>
                                        <option value="U">待上传</option>
                                        <option value="T">待排产</option>
                                        <option value="M">待生产</option>
                                        <option value="F">已完成</option>
                                        <option value="C">已取消</option>
                                        <option value="P">生产中</option>
                                        <option value="I">待入库</option>
                                        <option value="O">待备货</option>
                                        <option value="R">待发货</option>
                                        <option value="D">待财务审核</option>
                                        <option value="B">已退回</option>
                                        <option value="E">拆单失败</option>
                                    </select>
                                </td>
                                <td class="lbl-caption">产品类型:
                                </td>
                                <td>
                                    <select style="width: 125px;height:23px;" id="CabinetType" name="CabinetType" class="easyui-combobox"  required="true">
                                        <option value="请选择">请选择</option>
                                    </select>
                                </td>
                               
                            </tr>
                            <tr>
                                <td class="lbl-caption">订货日期：</td>
                                <td>
                                    <input type="text" id="BookingDateFrom" name="BookingDateFrom" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">至：</td>
                                <td>
                                    <input type="text" id="BookingDateTo" name="BookingDateTo" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                               <td class="lbl-caption">客户名称:
                                </td>
                                <td >
                                    <input style="width: 120px; height: 22px;" id="CustomerName" name="CustomerName" type="text" />  
                                </td>
                                 <td class="lbl-caption">订单类型:
                               </td>
                               <td >                                 
                                <select id="OrderType" name="OrderType" style="width: 125px;height:25px;" class="easyui-combobox" required="true">
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
                                <td class="lbl-caption">交货日期：</td>
                                <td>
                                    <input type="text" id="ShipDateFrom" name="ShipDateFrom" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">至：</td>
                                <td>
                                    <input type="text" id="ShipDateTo" name="ShipDateTo" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td>
                                    <input style="width: 120px; height: 22px;" id="Mobile" name="Mobile" type="text" />
                                </td>
                                 <td class="lbl-caption">外部单号:
                                </td>
                                <td>
                                    <input style="width: 120px; height: 22px;" id="OutOrderNo" name="OutOrderNo" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">客户地址:
                                </td>
                                <td colspan="3">
                                    <input type="text" id="Address" name="Address" style="width: 100%;"   />
                                </td>
                                 <td class="lbl-caption">批次号:
                                </td>
                                <td>
                                    <input type="text" id="BattchNum" name="BattchNum" style="width:120px;"   />
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
            <div id="edit_window" class="easyui-window" closed="true" title="审核明细" data-options="iconCls:'icon-save'"
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
