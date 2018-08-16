<%@ Page Title="财务审核订单详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordersreview.aspx.cs" Inherits="Mes.Client.Web.View.Orders.ordersreview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <style>
        #content ul li
        {
            float: left;
            list-style: none;
            margin: 5px;
        }

        #content .item ul li > a:hover
        {
            background: #eaf2ff;
            color: #000000;
        }

        #div_content ul li
        {
            float: left;
            list-style: none;
            margin-left: 5px;
        }

        #div_content ul li:hover
        {
            background: #ff6a00;
            color: #000000;
            -o-transition: all 0.1s ease-in-out;
            -webkit-transition: all 0.1s ease-in-out;
            -moz-transition: all 0.1s ease-in-out;
            -ms-transition: all 0.1s ease-in-out;
            transition: all 0.1s ease-in-out;
            cursor: pointer;
         }

        #div_content .active
        {
            background: #ff6a00;
        }

        #div_content .item
        {
            width: 120px;
            height: 22px;
            float: left;
            border: 1px solid #eee;
            line-height: 22px;
            text-align: center;
        }

        input[readonly]
        {
            border: none;
        }
    </style>
     <script src="/Script/forms/orders/jquery.forms.ordersreview.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="订单详情" region="north" border="false" style="height: 250px; width: 100%; overflow: hidden;" collapsible="false">
        <div style="width: 100%">
            <form id="search_form">
                <div>
                    <input type="hidden" id="PurNo"/>
                    <input type="hidden" id="PartnerID" name="PartnerID"/>
                    <input type="hidden" id="OrderID" name="OrderID"/>                   
                    <input type="hidden" id="H_OrderNo" name="OrderNo"/>
                    <input type="hidden" id="CabinetNum" name="CabinetNum"/>
                    <input type="hidden" id="Doors" name="Doors"/>
                </div>
                <table style="width: 100%; height: 100px;">
                    <tr>
                        <td style="width: 80px; text-align: right;">订单编号:</td>
                        <td>
                            <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">订单类型:</td>
                        <td>
                            <input id="OrderType" type="text" name="OrderType" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">订单状态:</td>
                        <td>
                            <input type="text" id="Status" name="Status" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">采购单号:</td>
                        <td>
                            <input type="text" id="PurchaseNo" name="PurchaseNo" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">产品类型:
                        </td>
                        <td>
                            <input type="text" id="CabinetType" name="CabinetType" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">是否正标:
                        </td>
                        <td>
                            <input type="text" id="IsStandard" name="IsStandard" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">是否外购:
                        </td>
                        <td>
                            <input type="text" id="IsOutsourcing" name="IsOutsourcing" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">开始生产:
                        </td>
                        <td>
                            <input type="text" id="ManufactureDate" name="ManufactureDate" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">客户名称:
                        </td>
                        <td>
                            <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">联系电话:
                        </td>
                        <td>
                            <input type="text" id="Mobile" name="Mobile" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">客户地址:
                        </td>
                        <td colspan="4">
                            <input type="text" id="Address" name="Address" style="width: 100%;" />
                        </td>   
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">联系人:
                        </td>
                        <td>
                            <input type="text" id="LinkMan" name="LinkMan" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">订货日期:
                        </td>
                        <td>
                            <input type="text" id="BookingDate" name="BookingDate" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">交货日期:
                        </td>
                        <td>
                            <input type="text" id="ShipDate" name="ShipDate" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">创建时间:
                        </td>
                        <td>
                            <input type="text" id="Created" name="Created" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">总金额(元):</td>
                        <td>
                            <input type="text" id="QuoteAmount" name="QuoteAmount" style="width: 100%;"/>
                        </td>
                        <td style="width: 80px; text-align: right;">折扣率(%):</td>
                        <td>
                            <input type="text" id="Discount" name="Discount" style="width: 100%;"/>
                        </td>
                        <td style="width: 80px; text-align: right;">折扣金额(元):</td>
                        <td>
                            <input type="text" id="DiscountAmount" name="DiscountAmount" style="width: 100%;"/>
                        </td>
                        <td style="width: 80px; text-align: right;">外部单号:</td>
                        <td>
                            <input type="text" id="OutOrderNo" name="OutOrderNo" style="width: 100%;" />
                        </td> 
                    </tr>                  
                    <tr>
                        <td style="width: 80px; text-align: right;">备注:
                        </td>
                        <td colspan="5">
                            <textarea id="Remark" disabled="disabled" name="Remark" cols="4" rows="4" style="width: 100%; height: 60px;"></textarea>
                        </td>                      
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <div region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false">
                <div class="easyui-tabs" fit="true" border="false" id="tt">
                    <div title="产品明细" fit="true" border="false">
                        <table id="dgorder"></table>
                    </div>
                    <div title="订单明细" fit="true" border="false">                        
                        <table id="dgdetail"></table>
                    </div>
                    <div title="五金明细" fit="true" border="false">                       
                        <table id="dgHardware"></table>
                    </div>                     
                    <div title="移门数据" fit="true" border="false" >                      
                        <table id="dgdoors"></table>                       
                    </div>                   
                    <div title="财务审核" fit="true" border="false">
                        <div class="easyui-layout" fit="true" border="false">
                            <div region="center" border="false" fit="true">
                                <form id="review_form">                                          
                                     <table style="width: 100%; padding: 5px;">
                                            <tr>
                                                <td style="text-align: right;">收款金额(元):</td>
                                                <td>
                                                    <input type="text" id="Amount" name="Amount" class="easyui-numberbox" data-options="precision:2" maxlength="50" style="width:180px; height:25px;"/>
                                                </td>
                                                <td style="text-align: right;">收款人:</td>
                                                <td>
                                                    <input type="text" id="Payee" name="Payee"  style="width: 100%;" maxlength="100"   class="easyui-validatebox"/>
                                                </td>
                                                <td style="text-align: right;">收款日期:</td>
                                                <td>
                                                    <input type="text" id="TransDate" name="TransDate" class="easyui-datebox" style="width: 80%;"/>
                                                </td>
                                                <td style="text-align: right;">凭证号:</td>
                                                <td>
                                                    <input type="text" id="VoucherNo" name="VoucherNo" class="easyui-validatebox"  maxlength="100" style="width: 100%;"/>
                                                </td> 
                                            </tr>
                                            <tr>
                                                 <td style="text-align: right;">审核意见:</td>
                                                 <td colspan="5">
                                                    <textarea id="option_Remark" name="option_Remark" cols="5" rows="10" style="width:100%;height:50px;" class="easyui-validatebox"  validtype="length[0,800]"  required="true"></textarea>
                                                 </td>
                                            </tr>
                                     </table>                                                               
                                </form>
                                <%-- 步骤显示 --%>
                                <div>                                      
                                    <div class="easyui-panel" style="margin-bottom: 10px;" border="false">
                                                <div id="Div1" class="process_flow" style="width: 640px;">
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
                            </div>                          
                        </div>
                    </div>              
                </div>
            </div>
        </div>
    </div>
    <div region="south" border="false" style="text-align: center; padding: 2px;overflow: hidden; height: 50px;">
         <a id="btn_review_ok" icon="icon-save" style="width:100px;height:30px; background:#ff6a00;color:#fff;" class="easyui-linkbutton" href="javascript:void(0)">审核通过</a>
         <a id="btn_review_reject" icon="icon-cancel" style="width:100px;height:30px; background: #87CEFF; border: #87CEFF;" class="easyui-linkbutton" href="javascript:void(0)">拒绝</a>
    </div>
</asp:Content>
