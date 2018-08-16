<%@ Page Title="订单排产" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ordersscheduling.aspx.cs" Inherits="Mes.Client.Web.View.Orders.ordersscheduling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.ordersscheduling.js?ver=1.214"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="easyui-layout" fit="true" border="false">
        <div region="north" style="height: auto; border-bottom: solid 1px #b5dbf6;" collapsible="false" border="false">
            <div style="height: auto 50px;" class="datagrid-toolbar">
                <form id="search_form" method="post" style="width: 100%;">
                    <div>
                        <input type="hidden" id="Status" name="Status" value="T" />
                    </div>
                    <table>
                        <tr>
                            <td class="lbl-caption">订单编号:</td>
                            <td style="width: 120px;">
                                <input type="text" style="width: 120px" id="Text1" name="OrderNo" />
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
                            <td class="lbl-caption">订货日期：</td>
                            <td>
                                <input type="text" id="BookingDateFrom" name="BookingDateFrom" class="easyui-datebox" style="width: 100%;" /></td>
                            <td class="lbl-caption">至：</td>
                            <td>
                                <input type="text" id="BookingDateTo" name="BookingDateTo" class="easyui-datebox" style="width: 100%;" /></td>
                            <td class="lbl-caption">客户名称:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Text4" name="CustomerName" type="text" />
                            </td>


                        </tr>
                        <tr>
                            <td class="lbl-caption">交货日期：</td>
                            <td>
                                <input type="text" id="ShipDateFrom" name="ShipDateFrom" class="easyui-datebox" style="width: 100%;" /></td>
                            <td class="lbl-caption">至：</td>
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
        <div region="center" border="false">
            <div class="easyui-layout" fit="true">
                <div region="west" title="待排产订单" iconcls="text_list_bullets" border="true" style="width: 300px;" collapsible="false">
                    <div>
                        <ul id="orders_tree">
                        </ul>
                    </div>
                </div>
                <div region="center" border="false">
                    <div class="easyui-layout" fit="true">
                        <div region="north" border="true" style="overflow: hidden;">
                            <table>
                                <tr>
                                    <td class="lbl-caption">排产线：</td>
                                    <td colspan="5" style="width:20px">
                                        <input type="text" id="WorkingLineID" class="easyui-combobox" style="width: 100%; height: 25px;" /></td>
                                    <td>
                                        <a href="javascript:void(0);" id="btnScheduleSetting" iconcls="cog_add" style="width: 120px;" class="easyui-linkbutton">参数设置</a>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0);" id="btnCreate_Scheduling" iconcls="clock_add" style="width: 120px;" class="easyui-linkbutton">开始排产</a>
                                    </td>
                                    <td class="lbl-caption">材质类型：</td>
                                    <td style="width:20px">
                                        <input type="text" id="MaterialType" class="easyui-combobox" style="width: 100%; height: 25px;" />
                                        <input type="text" id="MID" style="width: 100%; height: 25px;display:none;" />
                                    </td>
                                    <td>&nbsp;交货日期:</td>
                                    <td style="width:20px">
                                        <input type="text" id="ShipDate" name="ShipDate" class="easyui-datebox" style="width: 100%;" editable="false" />
                                        <input type="text" id="SD" style="width: 100%; height: 25px;display:none;" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div region="center" border="true">
                            <div class="easyui-tabs" fit="true" border="false" id="tt">
                                <%-- <div title="用料预计" fit="true" iconcls="chart_bar" border="false">
                                    <table id="dgtotal">
                                    </table>
                                </div>
                                <div title="待排产板件明细" iconcls="application_view_columns" fit="true" border="false">
                                    <table id="dgdetail">
                                    </table>
                                </div>
                                <div title="排除板件" iconcls="layout_delete" fit="true" border="false">
                                    <table id="dgremovedetails">
                                    </table>
                                </div>
                                <div title="异形板件" iconcls="disconnect" fit="true" border="false">
                                    <table id="dgsharp">
                                    </table>
                                </div>--%>

                                <div title="混单排产" iconcls="application_view_columns" fit="true" border="false">

                                    <table id="dgdetail">
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="edit_window" class="easyui-window" closed="true" title="排产参数设置" data-options="iconCls:'cog'"
            style="width: 800px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false" style="overflow: hidden;">
                    <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                        <div class="easyui-layout" border="false" fit="true" border="false">
                            <div region="west" title="特殊部件" iconcls="star" style="width: 200px;">
                                <ul id="SpecialParts"></ul>
                            </div>
                            <div region="center" iconcls="text_list_numbers" title="工序详情">
                                <div class="easyui-layout" fit="true" border="false">
                                    <div region="north" border="false">
                                        <div style="margin-bottom: 5px">
                                            <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="btn_add">新增部件</a>
                                            <a href="#" class="easyui-linkbutton" iconcls="icon-save" plain="true" id="btn_save">保存</a>
                                        </div>
                                        <div>
                                            <input type="hidden" id="SpecialID" name="SpecialID" />
                                            <input type="hidden" id="WorkFlows" name="WorkFlows" />
                                        </div>
                                        <table style="border-top: 1px solid #b5dbf6; border-bottom: 1px solid #b5dbf6; width: 100%;">
                                            <tr>
                                                <td class="lbl-caption">部件名称：</td>
                                                <td>
                                                    <input type="text" id="ItemName" name="ItemName" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="lbl-caption">是否禁用：</td>
                                                <td>
                                                    <input type="checkbox" id="IsDisabled" name="IsDisabled" value="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div region="center" border="false">
                                        <table id="dgSpecial"></table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div id="workingline_window" class="easyui-window" closed="true" title="选择排产线" data-options="iconCls:'cog'"
            style="width: 500px; height: 300px; background: #fff;" minimizable="false" maximizable="false" closable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false" style="overflow: hidden; padding: 5px;">
                    <ul id="ul_WorkingLine">
                        <li style="width: 100px; height: 50px; float: left; padding: 10px;">
                            <a href="#" onclick="Create_Scheduling();">
                                <div>一线生产线</div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="submit_window" class="easyui-window" closed="true" title="系统提示" data-options="iconCls:'cog'"
            style="width: 400px; height: 300px; background: #fff;" minimizable="false" maximizable="false" closable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false" style="overflow: hidden; padding: 15px;">
                    <table style="width: 100%; height: 100%;">
                        <tr>
                            <td style="width: 33px;">
                                <img src="/Content/images/ui-loading-pink-32x32.gif" />
                            </td>
                            <td style="width: 100%;">
                                <span>正在提交数据，请稍候...</span>
                                <p>
                                    <span class="runtime">已经运行：</span>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                    </table>
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

         <div id="barcode_window" class="easyui-window" closed="true" title="补打条码" data-options="iconCls:'icon-save'"
        style="width: 600px; height: 460px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="barcode_form" method="post">
                    <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                        <div>
                            <input type="hidden" id="WaitPrintOrder" name="WaitPrintOrder" />
                        </div>
                        <table style="width: 100%; height: 100%; padding: 5px;">
                            <tbody>
                                <tr>
                                    <td>订单编号: </td>
                                    <td style="width: 150px;">
                                        <input type="text" style="width: 150px" id="OrderNo" name="OrderNo" class="easyui-validatebox" required="true" /></td>
                                    <td style="text-align: center">
                                        <a href="javascript:void(0)" id="btn_barcode_addOrderNo" icon="icon-search" style="width: 78px;" class="l-btn l-btn-small" group="">
                                            <span class="l-btn-left l-btn-icon-left" style="margin-top: 0px;"><span class="l-btn-text">添加</span>
                                                <span class="l-btn-icon icon-add">&nbsp;</span>
                                            </span>
                                        </a>
                                        <a href="javascript:void(0)" id="btn_barcode_remove" icon="icon-clear" style="width: 78px;" class="l-btn l-btn-small" group="">
                                            <span class="l-btn-left l-btn-icon-left" style="margin-top: 0px;"><span class="l-btn-text">清空</span>
                                                <span class="l-btn-icon icon-remove">&nbsp;</span>
                                            </span>
                                        </a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div id="p" class="easyui-panel" title="待打印订单列表" style="width:586px;height: 330px;">
                            <div style="padding:5px">
                                打印份数：<input id="print_number" class="easyui-numberspinner" value="1" data-options="min:1,max:50,increment:1"  style="width:70px;" />
                                <label><input  id="checkview1" type="checkbox"/>打印预览</label>
                            </div>
                            <ul id="wait_order" style="list-style:none;padding:0;margin:0;">
                            </ul>
                        </div>
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                 <a id="btn_barcode_print" icon="icon-print" class="easyui-linkbutton" href="javascript:void(0)">打印</a>
                 <a id="btn_barcode_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>


        <div id="settime_window" class="easyui-window" closed="true" title="设置排产时间" data-options="iconCls:'icon-save'" style="width: 580px; height: 430px; background: #fff;" minimizable="false" maximizable="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <form id="settime_form" method="post">
                    <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                        <div>
                             <input type="hidden"  name="OrderID" />
                        </div>
                        <table style="width: 100%; height: 100%; padding: 25px;">
                            <tr style="height:35px;">
                                <td style="text-align:right">开料时间段:</td>
                                <td style="width:148px;">
                                    <input type="text" id="MaterialMadeStarted" name="MaterialMadeStarted" style="width: 150px" class="easyui-datebox" /></td>
                                <td style="width:10px;">至</td>
                                <td>                                  
                                    <input type="text" id="MaterialMadeEnded" name="MaterialMadeEnded" style="width: 150px" class="easyui-datebox" />
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="text-align:right">封边时间段: </td> 
                                <td>
                                    <input type="text" id="WoodMadeStarted" name="WoodMadeStarted" style="width: 150px" class="easyui-datebox" />
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" id="WoodMadeEnded" name="WoodMadeEnded" style="width: 150px" class="easyui-datebox" />
                                </td>
                            </tr>
                            <tr style="height:35px;"> 
                                <td style="text-align:right">铣型时间段: </td>
                                <td>
                                    <input type="text" id="DetectMadeStarted" name="DetectMadeStarted" style="width: 150px" class="easyui-datebox"/>
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" id="DetectMadeEnded" name="DetectMadeEnded" style="width: 150px" class="easyui-datebox" />
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="text-align:right">打孔时间段: </td>
                                <td>
                                    <input type="text" id="PaintMadeStarted" name="PaintMadeStarted" style="width: 150px" class="easyui-datebox"/>
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" id="PaintMadeEnded" name="PaintMadeEnded"  style="width: 150px" class="easyui-datebox"/>
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="text-align:right">检验时间段: </td>
                                <td>
                                    <input type="text" id="PrisonMadeStarted" name="PrisonMadeStarted" style="width: 150px" class="easyui-datebox"/>
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" id="PrisonMadeEnded" name="PrisonMadeEnded" style="width: 150px" class="easyui-datebox"/>
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="text-align:right">美容时间段: </td>
                                <td>
                                    <input type="text" id="CosmetologyStarted" name="PackagMadeStarted" style="width: 150px" class="easyui-datebox"/>
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" id="CosmetologyEnded" name="PackagMadeEnded" style="width: 150px" class="easyui-datebox"/>
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="text-align:right">包装时间段: </td>
                                <td>
                                    <input type="text" id="PackagMadeStarted" name="PackagMadeStarted" style="width: 150px" class="easyui-datebox"/>
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" id="PackagMadeEnded" name="PackagMadeEnded" style="width: 150px" class="easyui-datebox"/>
                                </td>
                            </tr>
                            <tr style="height:35px;"> 
                                <td style="text-align:right">入库时间段: </td>
                                <td>
                                    <input type="text" id="WarehousMadeStarted" name="WarehousMadeStarted" style="width: 150px" class="easyui-datebox" />
                                </td>
                                <td>至</td>
                                <td>
                                    <input type="text" id="WarehousMadeEnded" name="WarehousMadeEnded" style="width: 150px" class="easyui-datebox" />
                                </td>
                            </tr>
                        </table>                      
                    </div>
                </form>
            </div>
            <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                <a id="btn_scheduling_save" icon="icon-save" class="easyui-linkbutton" href="javascript:ordersSchedulingForm.events.saveOrderScheduling(false)">确定</a>
                <a id="btn_scheduling_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:ordersSchedulingForm.events.saveOrderSchedulingBySkip()">跳过</a>
            </div>
        </div>
    </div>
</div>
</asp:Content>
