<%@ Page Title="云拆单付款" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordersplitspayment.aspx.cs" Inherits="Mes.Client.Web.View.Orders.ordersplitspayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.min.ordersplitspayment.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="订单列表" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="overflow: hidden;" id="search_window">
                <div style="height: auto 50px;">
                    <div style="height: auto 50px;" class="datagrid-toolbar">
                        <form id="search_form" method="post">
                            <div>
                                <input type="hidden" id="Status" name="Status" value="Y" />
                            </div>
                            <table>
                                <tr>
                                    <td style="width: 100px;">订单类型:
                                    </td>
                                    <td style="width: 120px;">
                                        <select id="OrderType" name="OrderType" style="width: 100%; height: 23px;" class="easyui-combobox" required="true">
                                            <option value="">全部</option>
                                            <option value="正常">正常</option>
                                            <option value="加急">加急</option>
                                            <option value="补货">补货</option>
                                            <option value="工程">工程</option>
                                            <option value="展会">展会</option>
                                        </select>
                                    </td>
                                    <td style="width: 100px;">订单编号:
                                    </td>
                                    <td style="width: 120px;">
                                        <input style="width: 120px; height: 22px;" id="OrderNo" name="OrderNo" type="text" />
                                    </td>
                                    <td style="width: 100px;">客户名称:
                                    </td>
                                    <td style="width: 120px;">
                                        <input style="width: 120px; height: 22px;" id="CustomerName" name="CustomerName" type="text" />
                                    </td>
                                    <td colspan="2" style="text-align: left">
                                        <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" class="easyui-linkbutton" style="width: 80px;">搜索</a>
                                    </td>
                                </tr>
                            </table>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="payment_window" class="easyui-window" closed="true" title="拆单确认" data-options="iconCls:'icon-save'"
        style="width: 800px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="payment_form" method="post" style="height: 100%; width: 100%;">
                    <div class="easyui-layout" fit="true" border="false">
                        <div class="hidden">
                            <input type="hidden" id="OrderIDs" name="OrderIDs" />
                        </div>
                        <div region="north" border="false" style="height: auto; padding: 10px;">
                            <table style="width: 100%;">
                                <tr>
                                    <td class="lbl-caption">帐户余额：</td>
                                    <td>
                                        <input type="text" id="Amount" name="Amount" readonly="readonly" /><a href="#" class="easyui-linkbutton" iconcls="money_add">去充值</a></td>
                                    <td class="lbl-caption">本次拆单金额：</td>
                                    <td>
                                        <input type="text" id="CostAmount" name="CostAmount" readonly="readonly" /></td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">待支付金额：</td>
                                    <td>
                                        <input type="text" id="PayAmount" name="PayAmount" readonly="readonly" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align:center;">
                                        <a id="btn_confirm_pay" class="easyui-linkbutton" icon="icon-save" href="javascript:void(0)">确认支付</a>
                                        <a id="btn_cancel"  icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div region="center" border="true">
                            <table id="dgpayment">
                            </table>
                        </div>                        
                    </div>
                </form>
            </div>
        </div>
    </div>
    <div id="loading_window" class="easyui-window" closed="true" title="系统提示" data-options="iconCls:'cog'"
        style="width: 300px; height: 200px; background: #fff;" minimizable="false" maximizable="false" closable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td style="width: 33px;">
                            <img src="/Content/images/ui-loading-pink-32x32.gif" />
                        </td>
                        <td style="width: 100%;">
                            <span>正在支付拆单，请稍候...</span>                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
