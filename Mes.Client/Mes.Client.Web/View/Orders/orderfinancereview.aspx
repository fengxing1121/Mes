<%@ Page Title="订单财务审核" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orderfinancereview.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orderfinancereview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.orderfinancereview.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
            <table id="dgdetail">
            </table>
        </div>
        <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
            <div style="height: auto 50px;" class="datagrid-toolbar">
                <form id="search_form" method="post">
                    <div>
                        <input type="hidden" id="Status" name="Status" value="D" />
                    </div>
                    <table>
                        <tr>
                            <td class="lbl-caption">订单编号:</td>
                            <td style="width: 120px;">
                                <input type="text" style="width: 120px" id="Text1" name="OrderNo" />
                            </td>
                            <td class="lbl-caption">外部订单号:</td>
                            <td style="width: 120px;">
                                <input type="text" style="width: 120px" id="OutOrderNo" name="OutOrderNo" />
                            </td>
                            <td class="lbl-caption">采购单号:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="PurchaseNo" name="PurchaseNo" type="text" />
                            </td>

                            <td class="lbl-caption">产品类型:
                            </td>
                            <td>
                                <select style="width: 120px" id="Select2" name="CabinetType" class="easyui-combobox" required="true">
                                   <option value="请选择">请选择</option>
                                </select>
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
                            <td>订货日期：</td>
                            <td>
                                <input type="text" id="BookingDateFrom" name="BookingDateFrom" class="easyui-datebox" style="width: 100%;" /></td>
                            <td>至：</td>
                            <td>
                                <input type="text" id="BookingDateTo" name="BookingDateTo" class="easyui-datebox" style="width: 100%;" /></td>
                            <td class="lbl-caption">客户名称:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Text4" name="CustomerName" type="text" />
                            </td>

                        </tr>
                        <tr>
                            <td>交货日期：</td>
                            <td>
                                <input type="text" id="ShipDateFrom" name="ShipDateFrom" class="easyui-datebox" style="width: 100%;" /></td>
                            <td>至：</td>
                            <td>
                                <input type="text" id="ShipDateTo" name="ShipDateTo" class="easyui-datebox" style="width: 100%;" /></td>
                            <td class="lbl-caption">联系电话:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Text5" name="Mobile" type="text" />
                            </td>
                            <td class="lbl-caption"></td>
                            <td colspan="2" style="text-align: left">
                                <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
        </div>

    </div>
    <div id="review_window" class="easyui-window" closed="true" title="订单审核" icon="icon-save"
        style="width: 640px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="review_form">
                    <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                        <input type="hidden" id="OrderIDs" name="OrderIDs" />
                        <table style="width: 100%; height: 100%; padding: 5px;">
                            <tr>
                                <td>审核意见:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="Remark" name="Remark" cols="5" rows="5" class="easyui-validatebox"
                                        validtype="length[0,800]" style="width: 100%; height: 80px;" required="true"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div region="north" border="false">
                        <%-- 步骤显示 --%>
                        <div class="easyui-panel" style="margin-bottom: 10px;" border="false">
                            <div id="process_flow" class="process_flow" style="width: 640px;">
                                <div class="process_flow_left">
                                    <a title="新订单" class="process_flow_input">新订单</a>
                                    <span>
                                        <p class="name">新订单</p>
                                    </span>
                                </div>

                                <div class="process_flow_arrive">
                                    <a title="拆单申请" class="process_flow_input">拆单申请</a>
                                    <span>
                                        <p class="name">拆单申请</p>
                                    </span>
                                </div>
                                <div class="process_flow_arrive">
                                    <a title="拆单上传" class="process_flow_input">拆单上传</a>
                                    <span>
                                        <p class="name">拆单上传</p>
                                    </span>
                                </div>
                                <div class="process_flow_arrive">
                                    <a title="订单确认" class="process_flow_input">订单确认</a>
                                    <span>
                                        <p class="name">订单确认</p>
                                    </span>
                                </div>
                                <div class="process_flow_arrive">
                                    <a title="财务确认" class="process_flow_input">财务确认</a>
                                    <span>
                                        <p class="name">财务确认</p>
                                    </span>
                                </div>
                                <div class="process_flow_wait">
                                    <a title="订单排产" class="process_flow_input">订单排产</a>
                                    <span>
                                        <p class="name">订单排产</p>
                                    </span>
                                </div>
                                <div class="process_flow_wait">
                                    <a title="订单生产" class="process_flow_input">订单生产</a>
                                    <span>
                                        <p class="name">订单生产</p>
                                    </span>
                                </div>
                                <div class="process_flow_wait">
                                    <a title="生产打包" class="process_flow_input">生产打包</a>
                                    <span>
                                        <p class="name">生产打包</p>
                                    </span>
                                </div>
                                <div class="process_flow_wait">
                                    <a title="出库" class="process_flow_input">出库</a>
                                    <span>
                                        <p class="name">出库</p>
                                    </span>
                                </div>
                                <div class="process_flow_right_wait">
                                    <a title="完成" class="process_flow_input">完成</a>
                                    <span>
                                        <p class="name">完成</p>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 50px;">
                <a id="btn_review_ok" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">审核通过</a>
                <a id="btn_review_reject" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">拒绝</a>
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
</asp:Content>
