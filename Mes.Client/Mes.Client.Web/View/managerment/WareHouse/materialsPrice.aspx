<%@ Page Title="材料价格管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="materialsPrice.aspx.cs" Inherits="Mes.Client.Web.View.Management.WareHouse.materialsPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="/Script/forms/stock/jquery.forms.materialPrice.js"></script>
    <style type="text/css">
        #add_form ,#edit_form .lbl-input input{width:200px; background: #f0f0f0;}       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="材料价格" region="center" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false">
                <table id="dgdetail"></table>
            </div>
            <div region="north" border="false" style="text-align: right; overflow: hidden;" id="search_window">
                <div style="height: auto 50px;" class="datagrid-toolbar">
                    <form id="search_form" method="post">
                        <table>
                            <tr>                                
                                <td class="lbl-caption">材料类型: </td>
                                <td>
                                    <input style="width: 120px" id="SearchCategoryID" name="Category" class="easyui-combobox"/>
                                </td>
                                <td class="lbl-caption">子类型:</td>
                                <td>
                                    <input style="width: 120px" id="SearchSubCategoryID" name="SubCategory" class="easyui-combobox"/>
                                </td>                                               
                                <td class="lbl-caption">材料名称:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;"  name="MaterialName" type="text"/>
                                </td>
                                <td class="lbl-caption">型号:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;"  name="Style" type="text"/>
                                </td>
                                <td class="lbl-caption">颜色:</td>
                                <td style="width: 120px;">
                                    <input style="width: 120px; height: 22px;"  name="Color" type="text"/>
                                </td>                                
                                <td style="width: 100px">
                                    <a href="javascript:void(0)" id="btn_search_ok" class="easyui-linkbutton" icon="icon-search">搜索</a>
                                </td>
                                <td class="lbl-caption"></td>
                            </tr>
                        </table>
                    </form>
                </div>
            </div>           
        </div>
    </div>
    <div title="材料价格管理" region="east" style="width:400px;" split="true">
         <div data-options="region:'center',border:false">
            <form id="edit_form">
                   <div style="margin:8px;">                      
                       <a href="#" class="easyui-linkbutton" iconcls="icon-save" id="btn_edit">保存</a>                   
                   </div>
                   <div class="easyui-tabs" border="false">
                        <div title="材料价格信息">      
                             <input id="MaterialID" name="MaterialID" type="hidden"/>                                              
                             <table cellpadding="3">                                                                 
                                    <tr>
                                        <td class="lbl-caption">材料类型:</td>
                                        <td class="lbl-input">
                                            <input  name="Category" type="text" readonly="true"/>
                                        </td>                                    
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">子类型: </td>
                                        <td class="lbl-input">
                                            <input name="SubCategory" type="text" readonly="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">材料名称:</td>
                                        <td class="lbl-input">
                                            <input style="width: 200px" name="MaterialName"/>
                                        </td>                                     
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">材料编号:</td>
                                        <td class="lbl-input">
                                            <input name="MaterialCode" type="text" readonly="true"/>
                                        </td>
                                    </tr>                                  
                                    <tr>
                                        <td class="lbl-caption">型号/款式:</td>
                                        <td class="lbl-input">
                                            <input name="Style" type="text" readonly="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">颜色:</td>
                                        <td class="lbl-input">
                                            <input name="Color" type="text" readonly="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">厚度</td>
                                        <td class="lbl-input">
                                            <input name="Deepth" type="text" readonly="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">单位</td>
                                        <td class="lbl-input">
                                            <input name="Unit" type="text" readonly="true"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl-caption">单价</td>
                                        <td class="lbl-input">
                                            <input id="Price" name="Price" type="text" class="easyui-numberbox" data-options="precision:2" required="true" maxlength="30"/>
                                        </td>
                                    </tr>
                             </table>                                                        
                        </div>
                   </div>
             </form>
         </div>        
    </div>  
</asp:Content>
