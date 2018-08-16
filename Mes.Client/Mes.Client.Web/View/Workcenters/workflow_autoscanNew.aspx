<%@ Page Title="工位扫描" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="workflow_autoscanNew.aspx.cs" Inherits="Mes.Client.Web.View.Workcenters.workflow_autoscanNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style type="text/css">
        input[readonly="true"], textarea[readonly="true"] {
            background: #f0f0f0;
        }

        .process_flow_input {
            margin: -1px auto;
        }

        .textbox .textbox-text {
            font-size: 18px;
        }
    </style>
     <script src="/Script/forms/workcenters/jquery.forms.workflow.autoscanNew.js?v=1.8"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div region="center" border="false">
        <div region="north" border="false" overflow: hidden;">
            <table style="width:100%;">
                <tr>
                    <td style="width:80%;">
                        <input class="easyui-textbox" id="Barcode" name="Barcode" style="height:40px;width:70%; font-size: 18pt;padding-left:10px;" data-options="
			                    prompt: '请扫描或输入订单和产品(二维)码',
			                    icons:[{
				                    iconCls:'icon-search',
				                    handler: function(e){
					                    scanForm.events.btnfinish();
				                    }
			                    }]
			                    ">
                        <label><input onclick="javascript: CheckScanRework();"  type="checkbox" value="返工" id="ckRework"/>返工</label>
                       </td>                                   
                </tr>
                <tr>
                <td style="text-align: left;" >
                    <span>
                        <input name="testradio" id="t1" type="radio" value="BatchNum" checked="checked" /><label for="t1">按批次</label>
                       |
                        <input name="testradio" id="t2" type="radio" value="OrderNum" /><label for="t2">按订单</label>
                     </span>
                </td>             
               </tr>
                <tr>
                <td style="text-align: left;" >
                    <span class="msg_scanresult" style="font-size: 14pt;color:green;">信息提示：待扫描二维码</span>
                </td>             
               </tr>
               
            </table>
        </div>
        <div region="center" border="false"  style="margin-top:10px;">
            <div style="width: 100%">
                <form id="edit_form">
                    <table style="width: 99%;" border="0" cellpadding="5" cellspacing="0">
                        <tr>
                            <td colspan="4" style="font-size:14px;text-align:center;"></td>           
                        </tr>
                        <tr>
                            <td style="width:12%;">订单编号:</td>
                            <td style="width:38%;">
                                <input type="text" id="OrderNo" name="OrderNo" style="width: 100%;" readonly="true" />
                            </td>   
                            <td style="width:12%;">外部单号:</td>
                            <td style="width:38%;">
                                <input type="text" id="OutOrderNo" name="OutOrderNo" style="width: 100%;" readonly="true" />
                            </td>             
                        </tr>
                        <tr>
                            <td>订单类型:</td>
                            <td>
                                <input type="text" id="OrderType" name="OrderType" style="width: 100%;" readonly="true" />
                            </td>   
                            <td>订单状态:</td>
                            <td>
                                <input type="text" id="Status" name="Status" style="width: 100%;" readonly="true" />
                            </td>             
                        </tr>
                        <tr>
                            <td>产品类型:</td>
                            <td>
                                <input type="text" id="CabinetType" name="CabinetType" style="width: 100%;" readonly="true" />
                            </td>   
                            <td>是否正标:</td>
                            <td>
                                <input type="text" id="IsStandard" name="IsStandard" style="width: 100%;" readonly="true" />
                            </td>             
                        </tr>
                        <tr>
                            <td>联系电话:</td>
                            <td>
                                <input type="text" id="Mobile" name="Mobile" style="width: 100%;" readonly="true" />
                            </td>   
                            <td>客户地址:</td>
                            <td>
                                <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" />
                            </td>             
                        </tr>
                        <tr>
                            <td>订货日期:</td>
                            <td>
                                <input type="text" id="BookingDate" name="BookingDate" style="width: 100%;" readonly="true" />
                            </td>   
                            <td>创建时间:</td>
                            <td>
                                <input type="text" id="Created" name="Created" style="width: 100%;" readonly="true" />
                            </td>             
                        </tr>
                        <tr>
                            <td>客户名称:</td>
                            <td>
                                <input type="text" id="CustomerName" name="CustomerName" style="width: 100%;" readonly="true" />
                            </td>   
                            <td></td>
                            <td></td>             
                        </tr>
                        <tr>
                            <td>备注:</td>
                            <td colspan="3">
                                <textarea id="Remark" name="Remark" style="width: 100%; height: 100px;" readonly="true" ></textarea>
                            </td>                 
                        </tr>
                        <tr>
                            <td>产品进度:</td>
                            <td colspan="3">
                                <div id="process_flow" class="process_flow"><%--process_flow_left--%>
                                    
                                </div> 
                            </td>                 
                        </tr>
  <%--                       <tr>
                            <td colspan="4" style="height:50px;"></td>                 
                        </tr>--%>
                        <tr>
                            <td colspan="4">

                                <table style="margin:0px auto;">
                                    <tr>
                                        <td><a href="javascript:void(0)" style="position:fixed; bottom:15px; width: 120px;"  class="l-btn l-btn-small l-btn-print"  id="btnPrint"><span class="l-btn-left l-btn-icon-left"><span class="l-btn-text" style="line-height: 40px;font-size: 16px;">确认完工</span><span class="l-btn-icon icon-ok">&nbsp;</span></span></a>
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
    <div region="east" split="true"  style="width:50%;">
        <div class="easyui-tabs" border="false"  style="height:100%;">
            <div title="待扫描产品" style="padding: 10px;" fit="true">
                <table id="dgUnScan" style="height:100%;"></table>
            </div>
            <div title="已扫描产品" style="padding: 10px">
                <table id="dgScan" style="height:100%;"></table>
            </div>
        </div>
    </div>
</asp:Content>
