<%@ Page Title="打印条码" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="workflow_scan.aspx.cs" Inherits="Mes.Client.Web.View.Workcenters.workflow_scan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <style type="text/css">
        input[readonly="true"],textarea[readonly="true"]
        {
            background: #f0f0f0;
        }
        .delete {
            /*background: url(/Content/images/exticons/eye.png) center center no-repeat;*/
            background: url(/Content/images/exticons/printer/printer.png) center center no-repeat;
        }
         .textbox .textbox-text {
            font-size: 18px;
        }
    </style>
    <script src="/Script/forms/workcenters/jquery.forms.workflow.scan.js?v=1.341"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" border="false">
        <div region="north" border="false" overflow: hidden;">
            <table style="width:100%;">
                <tr>
                    <td  style="width:80%;">
                        <input class="easyui-textbox" id="Barcode" name="Barcode" data-options="buttonText:'查 询&nbsp&nbsp',buttonIcon:'icon-search',prompt:'请扫描或输入订单和产品(二维)码'" style="width:450px;height:35px;">
                    </td>                                        
                </tr>
            </table>
        </div>
        <div region="center" border="false"  style="margin-top:10px;">
            <div style="width: 100%">
                <form id="edit_form">
                    <table style="width: 99%;" border="0" cellpadding="5" cellspacing="0">
                        <tr>
                            <td>订单编号:</td>
                            <td>
                                <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" readonly="true" />
                            </td>   
                            <td>外部单号:</td>
                            <td>
                                <input type="text" id="OutOrderNo" name="OutOrderNo" style="width: 100%;" readonly="true"/>
                            </td>             
                        </tr>
                        <tr>
                            <td>订单类型:</td>
                            <td>
                                <input type="text" id="OrderType" name="OrderType" style="width: 100%;" readonly="true"/>
                            </td>   
                            <td>订单状态:</td>
                            <td>
                                <input type="text" id="Status" name="Status" style="width: 100%;" readonly="true"/>
                            </td>             
                        </tr>
                        <tr>
                            <td>产品类型:</td>
                            <td>
                                <input type="text" id="CabinetType" name="CabinetType" style="width: 100%;" readonly="true"/>
                            </td>   
                            <td>是否正标:</td>
                            <td>
                                <input type="text" id="IsStandard" name="IsStandard" style="width: 100%;" readonly="true"/>
                            </td>             
                        </tr>
                        <tr>
                            <td>联系电话:</td>
                            <td>
                                <input type="text" id="Mobile" name="Mobile" style="width: 100%;" readonly="true"/>
                            </td>   
                            <td>客户地址:</td>
                            <td>
                                <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true"/>
                            </td>             
                        </tr>
                        <tr>
                            <td>订货日期:</td>
                            <td>
                                <input type="text" id="BookingDate" name="BookingDate" style="width: 100%;" readonly="true"/>
                            </td>   
                            <td>创建时间:</td>
                            <td>
                                <input type="text" id="Created" name="Created" style="width: 100%;" readonly="true"/>
                            </td>             
                        </tr>
                         <tr>
                            <td>客户名称:</td>
                            <td>
                                <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" readonly="true"/>
                            </td>   
                            <td></td>
                            <td></td>             
                        </tr>
                        <tr>
                            <td>备注:</td>
                            <td colspan="3">
                                <textarea id="Remark" name="Remark" style="width: 100%; height: 100px;" readonly="true"></textarea>
                            </td>                 
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="margin:0px auto;">
                                    <tr>
                                        <td>
                                            <div  style="position:fixed; bottom:15px; ">
                                                <a href="#"   style="width: 120px;" class="l-btn l-btn-small l-btn-print" id="btnPrint"><span class="l-btn-left l-btn-icon-left"><span class="l-btn-text" style="line-height: 40px;font-size: 16px;">打印条码</span><span class="l-btn-icon icon-print">&nbsp;</span></span></a>
                                                <label style=" font-size: 14px;margin-top:3px;"><input  id="checkview" type="checkbox"/>预览</label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
    </div>
    </div>

    <div region="east" split="true"  style="width:60%;">
        <div class="easyui-tabs" border="false"  style="height:100%;">
            <div title="待打印产品" style="padding: 10px;" fit="true">
                <table id="dgUnScan" style="height:100%;"></table>
            </div>
            <div title="已打印产品" style="padding: 10px">
                <table id="dgScan" style="height:100%;"></table>
            </div>
        </div>
    </div>

    <div id="submit_window" class="easyui-window" closed="true" title="打印提示" data-options="iconCls:'cog'"
        style="width: 400px; height: 300px; background: #fff;" minimizable="true" maximizable="true" closable="true">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                <table style="width: 100%; height: 100%;">
                    <tr>
                        <td style="width: 33px;">
                            <img src="/Content/images/ui-loading-pink-32x32.gif" />
                        </td>
                        <td style="width: 100%;">
                            <span>正在打印数据，请稍候...</span>
                            <p>
                                <span class="runtime">已经运行：</span>
                            </p>
                        </td>
                    </tr>
                    <tr style="font-weight:bolder;font-size:18px;">
                        <td colspan="2"></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <img  src="http://www.c-lodop.com/Content/images/yes.png?ver=<%=DateTime.Now.ToString("ffff")%>" id="lodopImg" width="0" height="0" onerror="javascript:this.src='/Content/images/yes.png'"/>
</asp:Content>
