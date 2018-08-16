<%@ Page Title="补板件" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addorderdetail.aspx.cs" Inherits="Mes.Client.Web.View.Orders.addorderdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/orders/jquery.forms.addorderdetail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="north" border="false">
         <form id="add_orderdetail_from" method="post" style="width:100%;height:100%; overflow:hidden;">
               <div>
                   <%--<input type="hidden" name="OrderDetails" id="OrderDetails"/>--%>
               </div>
               <table style="height: auto; padding: 5px;">
                   <tr>
                       <td class="lbl-caption" style="width:120px;">补漏件:</td>
                       <td><input type="checkbox" name="IsCheck" id="IsLeak" checked="checked" value="补漏件"/></td>
                       <td class="lbl-caption" style="width:120px;">补损件:</td>
                       <td><input type="checkbox" name="IsCheck" id="IsDamage" value="补损件"/></td>
                   </tr>  
               </table>
               <!--补漏件-->
               <div id="IsLeakDiv">              
                   <table style="height: auto; padding: 5px;">
                        <tr>
                             <td class="lbl-caption" style="width:120px;">选择订单:</td>
                             <td><input type="text" id="OrderIDIsLeak" name="OrderID" class="easyui-combogrid" style="height: 27px; width: 300px;" editable="false"/></td>
                             <td class="lbl-caption" style="width:120px;">选择产品:</td>
                             <td><input type="text" id="CabinetIDIsLeak" name="CabinetID" class="easyui-combogrid" style="height: 27px; width: 300px;" editable="false" required="true"/></td>
                        </tr>
                        <tr>
                           <td class="lbl-caption">产品类型:</td>
                           <td><input type="text" name="CabinetType" id="CabinetType" readonly="true" style="height: 27px; width: 300px;"/></td>
                        </tr>
                        <tr>
                           <td class="lbl-caption">客户名称:</td>
                           <td><input type="text" name="CustomerName" readonly="true" style="height: 27px; width: 300px;"/></td>
                        </tr>
                   </table>
                </div>
               <!--补损件-->
               <div id="IsDamageDiv" style="display:none;">
                    <table style="height: auto; padding: 5px;">
                        <tr>
                             <td class="lbl-caption" style="width:120px;">选择订单:</td> 
                             <td><input type="text" id="OrderIDIsDamage"  name="OrderID" class="easyui-combogrid" style="height: 27px; width: 300px;" editable="false"/></td>
                             <td class="lbl-caption" style="width:120px;">选择产品:</td>
                             <td><input type="text" id="CabinetIDIsDamage"  name="CabinetID" class="easyui-combogrid" style="height: 27px; width: 300px;" editable="false"/></td>
                        </tr>
                        <tr>
                           <td class="lbl-caption">产品类型:</td>
                           <td><input type="text" name="CabinetType" readonly="true" style="height: 27px; width: 300px;"/></td>
                           <td class="lbl-caption">板件条码:</td>
                           <td><input type="text" name="BarcodeNo" style="height: 27px; width: 300px;"/></td>
                        </tr>
                        <tr>
                           <td class="lbl-caption">客户名称:</td>
                           <td><input type="text" name="CustomerName" readonly="true" style="height: 27px; width: 300px;"/></td>
                           <td class="lbl-caption">搜索:</td>
                           <td><a href="javascript:void(0)" class="easyui-linkbutton" id="btn_search_order" icon="icon-search" style="width: 80px;">搜索</a></td>
                        </tr>
                    </table>
                </div>
         </form>
    </div>

    <div region="center" border="false" style="height:500px;" fit="true">
        <div id="dgOrderDetailIsIsLeakDiv" style="height:400px;">
            <div  class="easyui-tabs" fit="true" border="false">
                <div title="补漏件">
                     <table id="dgOrderDetailIsIsLeak"></table>
                </div>            
            </div>
        </div>
        <div id="dgOrderDetailsIsDamageDiv"  style="display:none;height:400px;">
             <div  class="easyui-tabs" fit="true" border="false">
                 <div title="补损件">
                     <table id="dgOrderDetailsIsDamage"></table>
                 </div>
             </div>
        </div>
    </div>
    <div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;">
         <a id="btn_edit_save" icon="icon-save" style="background: #ff6a00; color: #fff;" class="easyui-linkbutton" href="javascript:void(0)">提交</a>
    </div>

    <!--漏检搜索订单-->
    <div id="order_IsLeak_bar" style="padding: 5px; height: auto">
        <form id="search_form_orderIsLeak">
            <table>
                <tr>
                    <td class="lbl-caption">订单编号: </td>
                    <td style="text-align: left">
                        <input type="text" name="OrderNo"/></td>
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" name="CustomerName"/></td>
                    <td class="lbl-caption">手机: </td>
                    <td style="text-align: left">
                        <input type="text" name="Mobile"/>
                    </td>
                </tr>
                <tr>
                    <td class="lbl-caption">采购单号: </td>
                    <td style="text-align: left">
                        <input type="text" name="PurchaseNo"/></td>
                    <td class="lbl-caption">产品类型</td>
                    <td style="text-align: left">
                        <input type="text" id="SearchCabinetType" name="CabinetType" class="easyui-combobox" style="height: 26px;" /></td>
                    <td colspan="2" style="text-align: center;">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_orderIsLeak">搜索</a>
                    </td>
                </tr>
            </table>
            <div>
               <%-- <input type="hidden" name="Status" value="F" />--%>
            </div>
        </form>
    </div>

    <!--损件搜索订单--> 
    <div id="order_IsDamage_bar" style="padding: 5px; height: auto">
        <form id="search_form_orderIsDamage">
            <table>
                <tr>
                    <td class="lbl-caption">订单编号: </td>
                    <td style="text-align: left">
                        <input type="text" name="OrderNo"/></td>
                    <td class="lbl-caption">客户名称: </td>
                    <td style="text-align: left">
                        <input type="text" name="CustomerName"/></td>
                    <td class="lbl-caption">手机: </td>
                    <td style="text-align: left">
                        <input type="text" name="Mobile"/>
                    </td>
                </tr>
                <tr>
                    <td class="lbl-caption">采购单号: </td>
                    <td style="text-align: left">
                        <input type="text" name="PurchaseNo"/></td>
                    <td class="lbl-caption">产品类型</td>
                    <td style="text-align: left">
                        <input type="text" id="Text1" name="CabinetType" class="easyui-combobox" style="height: 26px;" /></td>
                    <td colspan="2" style="text-align: center;">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_search_orderIsDamage">搜索</a>
                    </td>
                </tr>
            </table>
            <div>
               <%-- <input type="hidden" name="Status" value="F" />--%>
            </div>
        </form>
    </div>
</asp:Content>
