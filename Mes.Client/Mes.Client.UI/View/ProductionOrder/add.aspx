<%@ Page Title="新建生产订单" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Mes.Client.UI.View.ProductionOrder.add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/easyui/datagrid/datagrid-groupview.js"></script>
    <script src="/Script/forms/ProductionOrder/jquery.forms.add.js?ver=1.2"></script>
    <style type="text/css">
        .stream-cell-file .stream-cancel {
           display:none;
        }
        .datagrid-body .datagrid-editable {
            margin: 0 0px; 
        }
         textarea[readonly]
        {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false"  title="生产订单">
            <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                <div class="easyui-layout" fit="true" border="false">
                    <div region="north" border="false">
                        <div>
                            <input type="hidden" id="OrderID" name="OrderID" />
                            <input type="hidden" id="OrderNos" name="OrderNos" />
                            <input type="hidden" id="Cabinets" name="Cabinets" />
                        </div>
                        <table style="width: 100%; height: auto; padding: 5px;">
                            <tr>
                                <td class="lbl-caption" style="width: 120px;">来源销售订单:
                                </td>
                                <td>
                                    <input type="text" style="width: 306px;height:28px;" id="OrderNo" name="OrderNo" class="easyui-combogrid" editable="false" required="true"/>
                                </td>
                                 <td class="lbl-caption" style="width: 120px;">生产订单号:
                                </td>
                                <td>
                                    <input type="text" id="ProductionOrderNo" name="ProductionOrderNo" style="width: 300px;" placeholder="自动生成" readonly="true" />
                                </td>
                                <td class="lbl-caption" style="width: 120px;">订单类型:
                                </td>
                                <td>
                                    <input type="text" id="OrderType" name="OrderType"  style="width: 300px;" readonly="true" />
                                </td>                      
                            </tr>
                            <tr>
                                 <td class="lbl-caption" style="width: 120px;">门店名称:
                                </td>
                                <td>
                                    <input type="text" id="PartnerName" name="PartnerName"  style="width: 300px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td >
                                    <input type="text" id="CustomerName" name="CustomerName"  style="width: 300px;" readonly="true" />
                                </td>  
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td >
                                    <input type="text" id="Mobile" name="Mobile"  style="width: 300px;" readonly="true" />
                                </td>                        
                            </tr>
                            <tr>
                                <td class="lbl-caption">订货日期:
                                </td>
                                <td>
                                    <input type="text" id="BookingDate" name="BookingDate"  style="width: 300px;" readonly="true" />
                                </td>
                                 <td class="lbl-caption">交货日期:
                                </td>
                                <td>
                                    <input type="text" id="ShipDate" name="ShipDate"  style="width: 300px;" readonly="true" />
                                </td>
                                 <td class="lbl-caption" style="display:none;">预计完工日期:
                                </td>
                                <td style="display:none;">
                                    <input type="text" id="FinishDate" name="FinishDate" style="width: 306px;height:28px;" class="easyui-datebox" />
                                </td>  
                            </tr>
                            <%--<tr>
                                <td class="lbl-caption">订单备注:
                                </td>
                                <td colspan="5">
                                    <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;" readonly="true" ></textarea>
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;">
                        <table id="dgCabinet" title="一阶制成品"></table>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                        <a id="btn_edit_save" icon="icon-ok"   class="easyui-linkbutton" href="javascript:void(0)" style="display:none;">一键生成</a>
                        <a id="btn_edit_cancel" icon="icon-reload" class="easyui-linkbutton" href="javascript:void(0)" style="display:none;">清空所有</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div id="tb" style="padding: 5px; height: auto">
        <form id="search_form_customer">
            <table>
                <tr>                    
                    <td class="lbl-caption">订单编号: </td>
                    <td style="text-align: left">
                        <input type="text" id="OrderNo" name="OrderNo" /></td>
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" id="CustomerName" name="CustomerName" /></td>
                     <td><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_customer">搜索</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</asp:Content>


