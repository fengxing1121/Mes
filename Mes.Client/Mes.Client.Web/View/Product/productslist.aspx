<%@ Page Title="产品列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productslist.aspx.cs" Inherits="Mes.Client.Web.View.Product.productslist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style>
        #list li
        {
            list-style: none;
            float: left;
            padding: 5px;
        }

            #list li:hover
            {
                background: #ececec;
            }

        .imgwrap
        {            
            display: table-cell;
            text-align: center;
            vertical-align: middle;
            float:left;
        }

            .imgwrap img
            {
                max-width: 280px;
                max-height: 210px;
                height: 210px auto;
                width: 280px auto;
                vertical-align: middle;
                text-align: center;
                clear:both;
            }

        .product_item
        {
            width: 200px;
            height: 100%;
            float: left;
            margin: 0px;
            padding: 0px;
            float:left;
        }

            .product_item .title
            {
                font-size: 16pt;
                text-align: center;
                font-weight: bold;
            }

            .product_item .caption
            {
                font-size: 9pt;
                text-align: right;
            }
    </style>
    <script src="/Script/forms/products/jquery.forms.productslist.js" lang="zh-cn"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div region="center" style="border: 0px;" border="false" fit="true">
        <!--搜索界面-->
        <div class="easyui-layout" fit="true" border="false">
            <div region="south" border="false" style="display: none;">
                <div id="pp" class="easyui-pagination" style="background: #eee;"></div>
            </div>
            <div region="center" border="false" fit="true">
                <form id="edit_form" style="width: 100%; height: 100%;">
                    <ul id="list">                        
                    </ul>
                </form>
            </div>
        </div>
    </div>
    <div region="west" title="产品类别" style="text-align: right; overflow: hidden; width: 250px;" id="search_window">
        <div class="easyui-layout" fit="true" border="false">
            <div region="north" border="false" style="height: auto 50px; width: 250px;">
                <form id="search_form" method="post">
                    <table>
                        <tr>
                            <td class="lbl-caption">品牌:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px" id="Brand" name="Brand" class="easyui-combobox" value="请选择" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">产品名称:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="ProductName" name="ProductName" type="text" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">设计师:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Designer" name="Designer" type="text" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" class="easyui-linkbutton" style="width: 80px;">搜索</a>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
            <div region="center" border="false" title="产品类型">
                <div>
                    <ul id="category_tree">
                    </ul>
                </div>                
            </div>
        </div>
    </div>
</asp:Content>
