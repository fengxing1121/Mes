<%@ Page Title="新增订单" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addorder.aspx.cs" Inherits="Mes.Client.Web.View.Orders.addorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.addorder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
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

                                <td class="lbl-caption" style="width: 120px;">采购单号:
                                </td>
                                <td>
                                    <input type="text" id="PurchaseNO" name="PurchaseNO" class="easyui-validatebox" style="width: 300px;"  required="true"  />
                                </td>
                               <td class="lbl-caption">订单类型:
                                </td>
                                <td>
                                    <select id="OrderType" name="OrderType" style="width: 200px;height:25px;" class="easyui-combobox" required="true">
                                        <option value="">请选择</option>
                                        <option value="正常">正常</option>
                                        <option value="加急">加急</option>
                                        <option value="补货">补货</option>
                                        <option value="工程">工程</option>
                                        <option value="展会">展会</option>
                                    </select>
                                </td>                              
                            </tr>
                            <tr>
                                 <td class="lbl-caption">产品类型:
                                </td>
                                <td>
                                    <select style="width: 120px;height:25px;" id="CabinetType" name="CabinetType" class="easyui-combobox"  required="true">
                                        <option value="请选择">请选择</option>
                                    </select>
                                </td>
                                <td class="lbl-caption">是否正标:
                                </td>
                                <td>
                                    <select id="IsStandard" name="IsStandard" style="width: 200px;height:25px;" class="easyui-combobox" required="true">
                                        <option value="true">是</option>
                                        <option value="false">否</option>
                                    </select>
                                </td>
                                <td class="lbl-caption">是否外购:
                                </td>
                                <td>
                                    <select id="IsOutsourcing" name="IsOutsourcing" style="width: 200px;height:25px;" class="easyui-combobox" required="true">                                        
                                        <option value="true">是</option>
                                        <option value="false">否</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">订货日期:
                                </td>
                                <td>
                                    <input type="text" id="BookingDate" name="BookingDate" class="easyui-datebox" style="width: 100%;height:25px;" required="true"  />
                                </td>
                                 <td class="lbl-caption">交货日期:
                                </td>
                                <td>
                                    <input type="text" id="ShipDate" name="ShipDate" style="width: 100%;height:25px;" class="easyui-datebox" required="true" />
                                </td>
                                 <td class="lbl-caption">外部单号:
                                </td>
                                <td >
                                    <input type="text" style="width: 200px;" id="OutOrderNo" name="OutOrderNo" class="easyui-validatebox" required="true"/>
                                </td>
                            </tr>

                            <tr>
                                 
                                <td class="lbl-caption">客户名称:
                                </td>
                                <td colspan="3">
                                    <input type="text" style="width: 100%;height:25px;" id="CustomerID" name="CustomerID" class="easyui-combogrid" editable="false" required="true" />
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="lbl-caption">联系电话:
                                </td>
                                <td >
                                    <input type="text" id="Mobile" name="Mobile" style="width: 300px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">联系人:
                                </td>
                                <td>
                                    <input type="text" id="LinkMan" name="LinkMan" style="width: 300px;" readonly="true" />
                                </td>
                                <%--<td class="lbl-caption">联系电话:
                                </td>
                                <td >
                                    <input type="text" id="ReceiveMobile" name="Mobile" style="width: 300px;" readonly="true" />
                                </td>
                                <td class="lbl-caption">联系人:
                                </td>
                                <td>
                                    <input type="text" id="ReceiveLinkMan" name="LinkMan" style="width: 300px;" readonly="true" />
                                </td>--%>

                                <td class="lbl-caption">订单状态:
                                </td>
                                <td>
                                    <input type="text" id="Status" name="Status" style="width: 100%;" value="信息待确认" placeholder="信息待确认" readonly="true" />
                                </td>
                            </tr>                             

                            <tr>
                                <td class="lbl-caption">客户地址:
                                </td>
                                <td colspan="7">
                                    <input type="text" id="Address" name="Address" style="width: 100%;" readonly="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl-caption">备注:
                                </td>
                                <td colspan="5">
                                    <textarea id="Remark" name="Remark" cols="5" rows="5" style="width: 100%; height: 80px;"></textarea>
                                </td>
                            </tr>
                             
                        </table>
                    </div>
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 80px;">
                        <table id="dgCabinet" title="添加订单产品"></table>
                    </div>
                    <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
                        <a id="btn_edit_save" icon="icon-save" style="background:#ff6a00;color:#fff;" class="easyui-linkbutton" href="javascript:void(0)">提交订单</a>
                        <%--<a id="btn_edit_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>--%>
                    </div>
                </div>
            </form>
        </div>


    </div>

    <div id="tb" style="padding: 5px; height: auto">
        <form id="search_form_customer">
            <table>
                <tr>                    
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" id="CustomerNames" name="CustomerName" /></td>
                    <td class="lbl-caption">移动电话: </td>
                    <td style="text-align: left">
                        <input type="text" id="Mobile" name="Mobile" /></td>
                </tr>
                <tr>
                    <td class="lbl-caption">联系地址: </td>
                    <td style="text-align: left">
                        <input type="text" id="Address" name="Address" /></td>
                   <td class="lbl-caption"></td>
                    <td><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_customer">搜索</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</asp:Content>
