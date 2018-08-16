<%@ Page Title="实时进度" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="batchNumOrders.aspx.cs" Inherits="Mes.Client.Web.View.Workcenters.batchNumOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/workcenters/jquery.forms.batchNumOrders.js?v=1.1"></script>
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
                        <input type="hidden" id="Status" name="Status" value="M,P" />
                    </div>
                    <table>
                        <tr>
                            <td style="width: 100px;">批次订单状态:
                            </td>
                            <td style="width: 120px;">
                                <%--<input style="width: 120px" id="OrderType" name="Brand" class="easyui-combobox" value="请选择" />--%>
                                <select id="Status" name="Status" style="width: 100%;" editable="false" class="easyui-combobox" required="true">
                                    <option value="">全部</option>
                                    <option value="M" selected>待生产</option>
                                    <option value="P">生产中</option>
                                    <option value="F">已完成</option>
                                    <option value="C">已取消</option>
                                    <option value="P">待包装</option>
                                    <option value="I">待入库</option>
                                    <option value="O">待备货</option>
                                </select>
                            </td>

                            <td style="width: 100px;">订单类型:
                            </td>
                            <td style="width: 120px;">
                                <%--<input style="width: 120px" id="OrderType" name="Brand" class="easyui-combobox" value="请选择" />--%>
                                <select id="OrderType" name="OrderType" style="width: 100%;" editable="false" class="easyui-combobox" required="true">
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
                            <td style="width:200px">
                                <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                <a style="margin-left:30px;" href="/View/workcenters/jit.aspx?nocache=1527562603418&pid=fe7bbbbc-2c7c-4b54-8931-ec645d2d0564">按订单统计</a>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
        </div>
    </div>

    
    <div id="edit_window" class="easyui-window" closed="true" data-options="iconCls:'icon-save'" style="width: 1250px; height: 480px; background: #fff;" minimizable="true" maximizable="true">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgCabinet"></table>
            </div>
        </div>
    </div>
</asp:Content>
