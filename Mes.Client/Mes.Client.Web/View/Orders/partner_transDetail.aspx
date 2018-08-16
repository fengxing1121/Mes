<%@ Page Title="经销商收款" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="partner_transDetail.aspx.cs" Inherits="Mes.Client.Web.View.Orders.partner_transDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.partner_transDetail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">客户名称:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px" name="CustomerName" type="text" />
                                </td>
                                <td class="lbl-caption">订单编号:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" name="OrderNo" type="text" />
                                </td>
                                <td class="lbl-caption">采购单号:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;"  name="PurchaseNo" type="text" />
                                </td>
                                <%--<td class="lbl-caption">报价单号:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" name="QuoteNo" type="text" />
                                </td>--%>
                                <td style="width: 100px;">
                                    <a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_transdetail">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!--添加收款-->
    <div id="save_window" class="easyui-window" closed="true" closable="false" title="收款" data-options="iconCls:'icon-save'" style="width:600px; height: 500px; background: #fff;" minimizable="false" maximizable="false">
         <div  class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="padding: 0px; background: #fff; border: 0px solid #ccc; overflow: hidden;">
                <form id="save_form" name="edit_form" method="post">                  
                    <div>
                        <div  style="padding: 10px" fit="true">
                            <div>
                                <input type="hidden" name="OrderID" id="OrderID"/>
                                <input type="hidden" name="PartnerID" id="PartnerID"/>                                
                            </div>
                            <table cellpadding="3">                       
                                <tr>
                                    <td class="lbl-caption">客户名称:</td>
                                    <td style="width: 120px;">
                                        <input id="CustomerName" name="CustomerName"  type="text" class="easyui-validatebox" editable="false"/>
                                    </td>
                                </tr>                                                  
                                <tr>
                                    <td class="lbl-caption">总金额(元): </td>
                                    <td>
                                        <input id="TotalAmount" name="TotalAmount" type="text" class="easyui-validatebox" readonly="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">折扣率(%):</td>
                                    <td>
                                        <input id="DiscountPercent" name="DiscountPercent" type="text" class="easyui-validatebox" readonly="true"/>
                                    </td>
                                </tr>                           
                                <tr>
                                    <td class="lbl-caption">折扣金额(元):</td>
                                    <td>
                                        <input id="DiscountAmount" name="DiscountAmount" type="text" class="easyui-validatebox" readonly="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">实收金额(元):</td>
                                    <td>
                                        <input id="totalAmount" name="totalAmount" type="text" class="easyui-validatebox" readonly="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">已收款(元):</td>
                                    <td>
                                        <input id="PayAmount" name="PayAmount" type="text" class="easyui-validatebox" readonly="true"/>
                                    </td>
                                </tr>                        
                                <tr>
                                    <td class="lbl-caption">欠收款:</td>
                                    <td>
                                        <input id="NoPay" name="NoPay" type="text" class="easyui-validatebox" readonly="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">收款(元):</td>
                                    <td>
                                        <input id="Amount" name="Amount" type="text" class="easyui-numberbox"  data-options="precision:2" maxlength="60" required="true"/>
                                    </td>
                                </tr> 
                                <tr>
                                    <td class="lbl-caption">凭证号: </td>
                                    <td>
                                        <input id="VoucherNo" name="VoucherNo" style="width:180px;" type="text" class="easyui-validatebox" maxlength="60" required="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">收款日期: </td>
                                    <td>
                                        <input id="TransDate" name="TransDate" type="text" class="easyui-datebox" required="true"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl-caption">收款人:</td>
                                    <td>
                                        <input id="Payee" name="Payee" type="text" class="easyui-validatebox" maxlength="100" required="true"/>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                 <a id="btn_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                 <a id="btn_cancel"icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
         </div>
    </div>

    <!--收款详情-->
    <div id="detail_window" class="easyui-window" closed="true" title="收款详情" data-options="iconCls:'icon-save'" style="width:650px; height: 500px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center">
                <table id="detail"></table>
            </div>
        </div>
    </div>
</asp:Content>
