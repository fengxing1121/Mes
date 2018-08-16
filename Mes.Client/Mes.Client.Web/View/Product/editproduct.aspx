<%@ Page Title="改单|消单" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="editproduct.aspx.cs" Inherits="Mes.Client.Web.View.Product.editproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/products/jquery.forms.editproduct.js?ver=1.84"></script>
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
                        <table style="width: 100%; height: auto; padding: 5px;display:none;">
                            <tr>
                                <td class="lbl-caption" style="width: 150px;">请输入要查询的订单编号:</td>
                                <td style="width: 300px;">
                                    <input type="text" id="OrderNo" name="OrderNo" style="width: 300px;"  />
                                </td>
                                <td style="width: 100px;">
                                     <a id="btn_searchorder" style="width:100px;height:30px;"   class="easyui-linkbutton" href="javascript:editorderForm.events.loadCabinet(false)">查询订单</a>
                                </td>
                                <td></td>
                              </tr>                 
                        </table>
                    </div>
                    <div region="center" border="false" style="padding: 0px; overflow: hidden; height: 100px;">
                        <table id="dgCabinet" title="订单产品"></table>
                    </div>
                    <%--<div region="south" border="false" style="text-align: center; padding: 2px; overflow: hidden; height: 50px;display:none;">
                        <a id="btn_edit_save" icon="icon-save" style="width:100px;height:30px; " class="easyui-linkbutton" href="javascript:void(0)">提交申请</a> 
                        <a id="btn_cancelorder" icon="icon-cancel" style="width:100px;height:30px;"   class="easyui-linkbutton" href="javascript:editorderForm.events.loadCabinet(false)">取消修改</a>
                    </div>--%>
                </div>
            </form>
        </div>
    </div>

        <div id="edit_window" class="easyui-window" closed="true" title="改单|消单记录" data-options="iconCls:'icon-save'"
    style="width: 850px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
    <div class="easyui-layout" fit="true" border="false">
        <div region="center" border="false">
            <table id="dgsteps"></table>
        </div>
    </div>
</div>
</asp:Content>
