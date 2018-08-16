<%@ Page Title="材料列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="materials.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.materials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.forms.materials.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div title="材料列表" region="center" style="border: 0px;" border="false">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>
                                <td class="lbl-caption">材料编号:
                                </td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;" id="MaterialCode" name="MaterialCode" type="text" />
                                </td>
                                <td class="lbl-caption">材料名称</td>
                                <td style="width: 120px;">
                                    <input type="text" style="width: 120px" id="MaterialName" name="MaterialName" />
                                </td>
                                <td class="lbl-caption">材料类型:
                                </td>
                                <td>
                                    <input style="width: 120px" id="SearchCategoryID" name="Category" class="easyui-combobox" value="" />
                                </td>
                               <%-- <td class="lbl-caption">子类型:
                                </td>
                                <td>
                                    <input style="width: 120px" id="SearchSubCategoryID" name="SubCategory" class="easyui-combobox" value="" />
                                </td>    --%>                            
                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search">搜索</a>
                                </td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <div region="east" split="true" title="材料管理" style="width: 400px;" border="false">
        <form id="edit_form" method="post">
            <div region="center" border="false" style="padding: 0px; overflow: hidden;">
                <div style="margin-bottom: 5px;">
                    <a id="btn_edit_new" icon="icon-add" class="easyui-linkbutton" href="javascript:void(0)">新增</a>
                    <a id="btn_edit_save" icon="icon-save" class="easyui-linkbutton" href="javascript:void(0)">保存</a>
                </div>
                <div>
                  <input type="hidden" id="MaterialID" name="MaterialID" />                     
                </div>                
                <table style="width: 95%; height: 100%;">
                    <tr>
                        <td class="lbl-caption">材料类型:</td>
                        <td>
                             <input id="CategoryID" name ="Category" class="easyui-combobox" required="true" style="width: 100%;"/>                         
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="lbl-caption">子类型:
                        </td>
                        <td>
                            <input  id="SubCategoryID" name="SubCategory" class="easyui-combobox" required="true" style="width: 100%;"  />
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="lbl-caption">材料编号:
                        </td>
                        <td>
                            <input type="text" id="MaterialCode" name="MaterialCode" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr> 
                    <tr>
                        <td class="lbl-caption">材料名称:</td>
                        <td>
                            <input type="text" id="MaterialName" name="MaterialName" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>  
                    <tr>
                        <td class="lbl-caption">终端销售价(元):</td>
                        <td>
                            <input type="text" id="QuotedPrice" name="QuotedPrice"   class="easyui-numberbox"  data-options="precision:2" style="width: 100%;height:27px;" required="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl-caption">型号/款式:</td>
                        <td>
                            <input type="text" id="Style" name="Style" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>   
                    <tr>
                        <td class="lbl-caption">颜色:</td>
                        <td>
                            <input type="text" id="Color" name="Color" class="easyui-validatebox" style="width: 100%;" />
                        </td>
                    </tr>   
                    <tr>
                        <td class="lbl-caption">厚度:</td>
                        <td>
                            <input type="text" id="Deepth" name="Deepth" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>                    
                    <tr>
                        <td class="lbl-caption">单位:</td>
                        <td>
                            <input type="text" id="Unit" name="Unit" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>  
                    <tr>
                        <td class="lbl-caption">安全库存: </td>
                        <td>
                            <input type="text" id="SafetyStock_Qty" name="SafetyStock_Qty" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>  
                    <tr>
                        <td class="lbl-caption">预扣数量:</td>
                        <td>
                            <input type="text" id="Withholding_Qty" name="Withholding_Qty" class="easyui-validatebox" style="width: 100%;" required="true" />
                        </td>
                    </tr>                                         
                </table>
            </div>
        </form>
    </div>
</asp:Content>
