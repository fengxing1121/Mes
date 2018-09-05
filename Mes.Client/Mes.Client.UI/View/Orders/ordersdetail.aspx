<%@ Page Title="订单详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordersdetail.aspx.cs" Inherits="Mes.Client.UI.View.Orders.ordersdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.ordersdetail.js?ver=1.314"></script>
     <style type="text/css">
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
         textarea[readonly]
        {
            border: none;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="订单信息" region="north" border="false" style="height: 200px; width: 100%; overflow: hidden;" collapsible="false">
        <div style="width: 100%">
            <form id="search_form">
                <div>
                    <input type="hidden" id="OrderID" name="OrderID" />                   
                    <input type="hidden" id="H_OrderNo" name="OrderNo" />
                    <input type="hidden" id="CabinetNum" name="CabinetNum" />
                    <input type="hidden" id="Doors" name="Doors" />
                </div>
                <table style="width: 100%; height: 50px;">
                    <tr>
                        <td style="width: 80px; text-align: right;">订单编号:
                        </td>
                        <td>
                            <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" readonly="readonly"/>
                        </td>
                        <td style="width: 100px; text-align: right;">来源单号:
                        </td>
                        <td>
                            <input type="text" id="OutOrderNo" name="OutOrderNo" style="width: 100%;" readonly="readonly"/>
                        </td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">订单类型:
                        </td>
                        <td>
                            <input type="text" id="OrderType" name="OrderType" style="width: 100%;" readonly="readonly"/>
                        </td>
                        <td style="width: 100px; text-align: right;">订货日期:
                        </td>
                        <td>
                            <input type="text" id="BookingDate" name="BookingDate" style="width: 100%;" readonly="readonly"/>
                        </td>
                        <td style="width: 100px; text-align: right;">交货日期:
                        </td>
                        <td>
                            <input type="text" id="ShipDate" name="ShipDate" style="width: 100%;" readonly="readonly"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">客户名称:
                        </td>
                        <td>
                            <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" readonly="readonly"/>
                        </td>
                        <td style="width: 80px; text-align: right;">客户地址:
                        </td>
                        <td>
                            <input type="text" id="Address" name="Address" style="width: 100%;" readonly="readonly"/>
                        </td>  
                        <td style="width: 100px; text-align: right;">联系电话:
                        </td>
                        <td>
                            <input type="text" id="Mobile" name="Mobile" style="width: 100%;" readonly="readonly"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">门店名称:
                        </td>
                        <td>
                            <input type="text" id="PartnerName" name="PartnerName" style="width: 100%;" readonly="readonly"/>
                        </td>
                        <td style="width: 80px; text-align: right;">业务人员:
                        </td>
                        <td>
                            <input type="text" id="SalesMan" name="SalesMan" style="width: 100%;" readonly="readonly"/>
                        </td>
                        <td style="width: 80px; text-align: right;">订单附件:
                        </td>
                        <td>
                            <input type="text" id="AttachmentFile" name="AttachmentFile" style="width: 60%;" readonly="readonly"/>
                            <a href="#" target="_blank" id="downfile" style="color:red;display:none;">[下载]</a>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">订单备注:
                        </td>
                        <td colspan="5">
                            <textarea id="Remark" name="Remark" cols="4" rows="4" style="width: 100%; height: 40px;" readonly="readonly"></textarea>
                        </td>                     
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <div region="center" border="false">
        <div class="easyui-layout" fit="true">
<%--            <div region="north" border="false" title="产品列表" style="height: 70px;" collapsible="false">
                <div id="div_content">
                    <span style='width: 120px; height: 22px; float: left; padding: 5px; text-align: right;'>产品列表：</span><ul id="cabinets"></ul>
                </div>
            </div>--%>
            <div region="center" border="false">
                <div class="easyui-tabs" fit="true" border="false" id="tt">
                    <div title="产品明细" fit="true" border="false">
                        <table id="dgorder"></table>
                    </div>
                   <%-- <div title="订单明细" fit="true" border="false">                        
                        <table id="dgdetail"></table>
                    </div>
                    <div title="五金明细" fit="true" border="false">                       
                        <table id="dgHardware"></table>
                    </div>                     
                    <div title="移门数据" fit="true" border="false" >                       
                        <table id="dgdoors"></table>                       
                    </div>
                    <div title="加工文件" fit="true" border="false">
                        <table id="dgProcessFile"></table>
                    </div>
                    <div title="图纸文件" fit="true" border="false">
                        <table id="dgDrawing"></table>
                    </div>
                    <div title="效果图" style="padding: 10px">
                        <div region="center" border="false" fit="true">
                            <div id="content" fit="true">
                                <ul id="list"></ul>
                            </div>
                        </div>
                    </div> 
                    <div title="skp文件" fit="true" border="false">
                        <table id="skpFile"></table>
                    </div>--%>
                </div>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;display:none;">
                 <a id="btn_confirm_open" icon="icon-ok" style="width:120px;height:30px;display:none;"  class="easyui-linkbutton" href="javascript:void(0)">订单初审</a>  
                 <a id="btn_review_open" icon="icon-ok" style="width:120px;height:30px;display:none;"  class="easyui-linkbutton" href="javascript:void(0)">财务审核</a>                     
            </div>
        </div>
    </div>

    <div id="confirm_window" class="easyui-window" closed="true" title="订单初审" icon="icon-save"  style="width: 640px; height: 480px; background: #fff;display:none;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="confirm_form">               
                    <div region="center" border="false" style="padding: 0px; overflow: hidden;">                    
                        <table style="width: 100%; height: 100%; padding: 5px;">
                            <tr>
                                <td>初审意见:</td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="option_remark" name="Remark" cols="5" rows="5" class="easyui-validatebox" validtype="length[0,800]" style="width: 100%; height:200px;" required="true"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td style=" color:red">
                                      <h2>注意：</h2>
                                      &nbsp;&nbsp;&nbsp;若订单【初审通过】，则该订单提交设计；<br />
                                      &nbsp;&nbsp;&nbsp;若订单【初审拒绝】，则该订单取消，需门店重新下单！
                                </td>
                            </tr>
                        </table>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 50px;">
                <a id="btn_confirm_ok" icon="icon-ok" class="easyui-linkbutton" href="javascript:void(0)">初审通过</a> 
                <a id="btn_confirm_reject" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">初审拒绝</a>
            </div>
        </div>
    </div>

     <div id="review_window" class="easyui-window" closed="true" title="财务审核" icon="icon-save"  style="width: 640px; height: 480px; background: #fff;display:none;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                    <form id="review_form">                                          
                        <table style="width: 100%; padding: 5px;">
                        <tr>
                        <td style="text-align: right;">收款金额(元):</td>
                        <td>
                            <input type="text" id="Amount" name="Amount" class="easyui-numberbox" data-options="precision:2" maxlength="50" style="width:300px; height:25px;"/>
                        </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">收款人:</td>
                            <td>
                                <input type="text" id="Payee" name="Payee"  style="width:300px; height:25px;" maxlength="100"   class="easyui-validatebox"/>
                            </td>
                        </tr>
                        <tr>
                             <td style="text-align: right;">收款日期:</td>
                            <td>
                                <input type="text" id="TransDate" name="TransDate" class="easyui-datebox" style="width:300px; height:25px;"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">凭证号:</td>
                            <td>
                                <input type="text" id="VoucherNo" name="VoucherNo" class="easyui-validatebox"  maxlength="100" style="width:300px; height:25px;"/>
                            </td> 
                        </tr>
                        <tr>
                            <td style="text-align: right;">审核意见:</td>
                            <td colspan="5">
                            <textarea id="option_Remark" name="option_Remark" cols="5" rows="10" style="width:500px;height:50px;" class="easyui-validatebox"  validtype="length[0,800]"  required="true"></textarea>
                            </td>
                        </tr>
                        </table>                                                               
                      </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 50px;">
                <a id="btn_review_ok" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">审核通过</a> 
                <a id="btn_review_reject" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">拒绝通过</a>
            </div>
        </div>
    </div>
</asp:Content>
