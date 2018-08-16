<%@ Page Title="仓库出库" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="warehouse_out.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.warehouse_out" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.forms.warehouse_out.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="出库列表" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail">
                </table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">                       
                        <table>
                            <tr>
                                <td class="lbl-caption">出库单号</td>
                                <td >
                                    <input type="text" style="width: 120px" id="BillNo" name="BillNo" />
                                </td>
                                <td class="lbl-caption">使用车间:
                                </td>
                                <td>
                                    <input type="text" style="width: 120px" id="WareShopName" name="WareShopName"  />
                                </td>

                                <td class="lbl-caption">经手人:
                                </td>
                                <td>
                                    <input type="text" style="width: 120px" id="Text3" name="HandlerMan"  />
                                </td>

                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>

         <!--新增出库-->
        <div id="edit_window" class="easyui-window" closed="true" title="新增出库" data-options="iconCls:'icon-save'"
            style="width: 800px; height: 480px; background: #fff;" minimizable="false" maximizable="false">
            <div class="easyui-layout" fit="true" border="false">
                <div region="center" border="false">
                    <form id="edit_form" method="post" enctype="multipart/form-data" style="height: 100%;">
                        <div class="easyui-layout" fit="true" border="false">
                            <div region="north" border="false">
                                <div>
                                    <input type="hidden" id="OutID" name="OutID" />
                                     <input type="hidden" id="WarehouseOutDetail" name="WarehouseOutDetail" />
                                </div>
                                <table style="width: 100%; height: auto; padding: 5px;">
                                    <tr>
                                        <td class="lbl-caption" style="width: 120px;">出库单号:
                                        </td>
                                        <td>
                                            <input type="text" id="BillNoID" name="BillNo" style="width: 100%;"  />
                                        </td>
                                        <td class="lbl-caption">车间:
                                        </td>
                                        <td>
                                             <input id="WorkShopID" name="WorkShopID" class="easyui-combobox" required="true" style="width: 120px;" />  
                                        </td>
                                        <td class="lbl-caption">出库日期:
                                        </td>
                                        <td>
                                            <input type="text" id="CheckOutDate" name="CheckOutDate" class="easyui-datetimebox" style="width: 100%;" required="true"  />
                                            
                                        </td>
                                    </tr>
                                    <tr>                                       

                                        <td class="lbl-caption">经手人:
                                        </td>
                                        <td>
                                            <input type="text" id="HandlerMan" name="HandlerMan" style="width: 100%;" class="easyui-validatebox" required="true" />
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
                                <table id="dgWareHouseOut" title="添加出库产品"></table>
                            </div>

                        </div>
                    </form>
                </div>
                <div region="south" border="false" style="text-align: center; padding: 0px; overflow: hidden; height: 30px;">
                    <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                    <a id="btn_edit_cancel" icon="icon-cancel" class="easyui-linkbutton" href="javascript:void(0)">取消</a>
                </div>
            </div>
        </div>
    </div>     

          <!--材料名称下拉-->
    <div id="tbMaterial" style="padding: 5px; height: auto">
        <form id="search_form_material">
            <table>
                <tr>
                    <td class="lbl-caption">材料编号: </td>
                    <td style="width: 120px;">
                        <input style="width: 120px; height: 22px;" id="MaterialCode" name="MaterialCode" type="text" />
                    </td>
                    <td class="lbl-caption">材料名称</td>
                    <td style="width: 120px;">
                        <input type="text" style="width: 120px" id="MaterialName" name="MaterialName" />
                    </td>

                </tr>
                <tr>
                    <td class="lbl-caption">材料类型:
                    </td>
                    <td>
                        <input style="width: 120px" id="SearchCategoryID" name="Category" class="easyui-combobox" value="" />
                    </td>
                    <td class="lbl-caption">子类型:
                    </td>
                    <td>
                        <input style="width: 120px" id="SearchSubCategoryID" name="SubCategory" class="easyui-combobox" value="" />
                    </td>
                    <td><a href="#" class="easyui-linkbutton" iconcls="icon-search" id="btn_form_material">搜索</a>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</asp:Content>
