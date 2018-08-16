<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordersprice.aspx.cs" Inherits="Mes.Client.UI.View.Orders.ordersprice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <script src="/Script/forms/orders/jquery.forms.ordersprice.js?ver=1.23"></script>
    <style type="text/css">
        .stream-cell-file .stream-cancel {
           display:none;
        }
        .datagrid-body .datagrid-editable {
            margin: 0 0px; 
        }
        textarea[readonly="true"] {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false" title="订单信息">
            <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                   <div class="easyui-layout" fit="true" border="false">
                    <div region="north" border="false">
                        <div>
                            <input type="hidden" id="OrderID" name="OrderID" />
                            <input type="hidden" id="PartnerID" name="PartnerID" />
                            <input type="hidden" id="H_CustomerID" name="CustomerName" />
                            <input type="hidden" id="Cabinets" name="Cabinets" />
                        </div>
                        <table style="width: 100%; height: auto; padding: 5px;">
                            <tr>
                                <td class="lbl-caption" style="width: 120px;">订单编号:
                                </td>
                                <td>
                                    <input type="text" id="OrderNo" name="OrderNo" style="width: 300px;" placeholder="自动生成" readonly="true" />
                                </td>

                                <td class="lbl-caption" style="width: 120px;">来源单号:
                                </td>
                                <td>
                                    <input type="text" id="OutOrderNo" name="OutOrderNo" class="easyui-validatebox" style="width: 300px;"  required="true" readonly="true"  />
                                </td>
                               <td class="lbl-caption"></td>
                                <td></td>                              
                            </tr>
                            <tr>
                                <td class="lbl-caption">订单类型:
                                </td>
                                <td>
                                    <select id="OrderType" name="OrderType" style="width: 306px;height:28px;" class="easyui-combobox" readonly="true" ></select>
                                </td>    
                                <td class="lbl-caption">订货日期:
                                </td>
                                <td>
                                    <input type="text" id="BookingDate" name="BookingDate" class="easyui-datebox" style="width:306px;height:28px;" required="true"  readonly="true" />
                                </td>
                                 <td class="lbl-caption">交货日期:
                                </td>
                                <td>
                                    <input type="text" id="ShipDate" name="ShipDate" style="width: 306px;height:28px;" class="easyui-datebox" required="true" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                               <td class="lbl-caption">客户名称:
                                </td>
                                <td >
                                    <input type="text" style="width: 306px;height:28px;" id="CustomerID" name="CustomerID" class="easyui-combogrid" editable="false" required="true" readonly="true" />
                                </td>
                                <td class="lbl-caption">客户地址:
                                </td>
                                <td >
                                    <input type="text"  id="Address" name="Address" style="width: 300px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td >
                                    <input type="text" id="Mobile" name="Mobile" style="width: 300px;" readonly="true" />
                                </td>
                            </tr>  
                            <tr>
                                <td class="lbl-caption">门店名称:
                                </td>
                                <td>
                                    <input type="text" id="PartnerName" name="PartnerName" style="width: 300px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">业务人员:
                                </td>
                                <td>
                                    <input type="text" id="SalesMan" name="SalesMan" style="width: 300px;" readonly="true" />
                                </td>
                                 <td class="lbl-caption">订单附件
                                </td>
                                <td>
                                    <input type="text" id="AttachmentFile" name="AttachmentFile" style="width:235px;" readonly="true" />
                                    <input type="button"  value="选择文件"  disabled="disabled"/>
                                </td>
                            </tr>                           
                            <tr>
                                <td class="lbl-caption">订单备注:
                                </td>
                                <td colspan="5">
                                    <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;" readonly="true" ></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;">
                        <table id="dgCabinet" title="订单产品（单击行编辑）"></table>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                        <a id="btn_edit_save" icon="icon-ok"   class="easyui-linkbutton" href="javascript:void(0)">提交报价</a>
                       <%-- <a id="btn_edit_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消订单</a>--%>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>


