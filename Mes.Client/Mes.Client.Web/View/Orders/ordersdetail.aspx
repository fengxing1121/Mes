<%@ Page Title="订单详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordersdetail.aspx.cs" Inherits="Mes.Client.Web.View.Orders.ordersdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.ordersdetail.js"></script>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="订单详情" region="north" border="false" style="height: 220px;overflow: hidden;" collapsible="false">
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
                            <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">订单类型:
                        </td>
                        <td>
                            <input id="OrderType" type="text" name="OrderType" style="width: 100%;" />
                        </td>

                        <td style="width: 100px; text-align: right;">订单状态:
                        </td>
                        <td>
                            <input type="text" id="Status" name="Status" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">采购单号:
                        </td>
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
                        <td style="width: 80px; text-align: right;">备注:
                        </td>
                        <td colspan="3">
                            <textarea id="Remark" name="Remark" cols="4" rows="4" style="width: 100%; height: 40px;"></textarea>
                        </td>
                         <td style="width: 100px; text-align: right;">外部单号:
                        </td>
                        <td>
                            <input type="text" id="OutOrderNo" name="OutOrderNo" style="width: 100%;" />
                        </td>                        
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <div region="center" border="false">
        <div class="easyui-layout" fit="true">
            <div region="north" border="false" title="产品列表" collapsible="false">
                <div id="div_content">
                    <span style='width: 120px; float: left; padding: 5px; text-align: right;'>产品列表：</span><ul id="cabinets"></ul>
                </div>
            </div>
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
                    </div>
                </div>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                 <a id="btn_review_open" icon="icon-save" style="width:100px;height:30px; background:#ff6a00;color:#fff;"  class="easyui-linkbutton" href="javascript:void(0)">订单审核</a>                       
            </div>
        </div>
    </div>
    <div id="review_window" class="easyui-window" closed="true" title="订单确认" icon="icon-save"
        style="width: 640px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="review_form">               
                    <div region="center" border="false" style="padding: 0px; overflow: hidden;">                    
                        <table style="width: 100%; height: 100%; padding: 5px;">
                            <tr>
                                <td>确认意见:</td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea id="option_remark" name="Remark" cols="5" rows="5" class="easyui-validatebox" validtype="length[0,800]" style="width: 100%; height: 80px;" required="true"></textarea>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div region="north" border="false">
                        <%-- 步骤显示 --%>
                        <div class="easyui-panel" style="margin-bottom: 10px;" border="false">
                            <div id="process_flow" class="process_flow" style="width: 640px;">
                                <div class="process_flow_wait">
                                    <a title="新订单" class="process_flow_input">新订单</a>
                                    <span>
                                        <p class="name">新订单</p>
                                    </span>
                                </div>
                                <%--<div class="process_flow_wait">
                                    <a title="拆单申请" class="process_flow_input">拆单申请</a>
                                    <span>
                                        <p class="name">拆单申请</p>
                                    </span>
                                </div>--%>
                               <%-- <div class="process_flow_wait">
                                    <a title="拆单上传" class="process_flow_input">拆单上传</a>
                                    <span>
                                        <p class="name">拆单上传</p>
                                    </span>
                                </div>--%>
                                <div class="process_flow_wait">
                                    <a title="订单确认" class="process_flow_input">订单确认</a>
                                    <span>
                                        <p class="name">订单确认</p>
                                    </span>
                                </div>
                                <div class="process_flow_wait">
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
                          <div style=" color:red">
                              注意：【信息待审核】订单，若拒绝，订单则改回【已退回】状态，并回到【订单确认】界面！
                          </div>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 50px;">
                <a id="btn_review_ok" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">确认通过</a> 
                <a id="btn_review_reject" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">拒绝</a>
            </div>
        </div>
    </div>
</asp:Content>
