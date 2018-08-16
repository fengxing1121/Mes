<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Mes.Client.UI.View.WorkOrder.add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="/Script/forms/WorkOrder/jquery.forms.add.js?ver=1.24"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="新建工单" region="center" style="border: 0px;" border="false">
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
                                 <td class="lbl-caption">来源单号:
                                </td>
                                <td>
                                    <input style="width: 120px; height: 22px;" id="OutOrderNo" name="OutOrderNo" type="text" />
                                </td>
                                <td class="lbl-caption">门店名称:
                                </td>
                                <td >
                                    <input style="width: 120px; height: 22px;" id="PartnerName" name="PartnerName" type="text" />  
                                </td>
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td >
                                    <input style="width: 120px; height: 22px;" id="CustomerName" name="CustomerName" type="text" />  
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">订货日期:</td>
                                <td>
                                    <input type="text" id="BookingDateFrom" name="BookingDateFrom" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">至:</td>
                                <td>
                                    <input type="text" id="BookingDateTo" name="BookingDateTo" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">订单状态:
                                </td>
                                <td>
                                    <select id="Status" name="Status" style="width: 125px;height:25px;"  class="easyui-combobox"></select>
                                </td>
                                 <td class="lbl-caption">订单类型:
                               </td>
                               <td>                                 
                                <select id="OrderType" name="OrderType" style="width: 125px;height:25px;" class="easyui-combobox"></select>
                            </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">交货日期:</td>
                                <td>
                                    <input type="text" id="ShipDateFrom" name="ShipDateFrom" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">至:</td>
                                <td>
                                    <input type="text" id="ShipDateTo" name="ShipDateTo" class="easyui-datebox" style="width: 125px;height:25px;" /></td>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td>
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
            <div id="steps_window" class="easyui-window" closed="true" title="审核明细" data-options="iconCls:'icon-save'"
                style="width: 850px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="center" border="false">
                        <table id="dgsteps"></table>
                    </div>
                </div>
            </div>

             <div id="submit_window" class="easyui-window" closed="true" title="系统提示" data-options="iconCls:'cog'"
            style="width: 400px; height: 300px; background: #fff;" minimizable="false" maximizable="false" closable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                    <table style="width: 100%; height: 100%;">
                        <tr>
                            <td style="width: 33px;">
                                <img src="/Content/images/ui-loading-pink-32x32.gif" />
                            </td>
                            <td style="width: 100%;">
                                <span>正在提交数据，请稍候...</span>
                                <p>
                                    <span class="runtime">已经运行：</span>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        </div>
    </div>
</asp:Content>

