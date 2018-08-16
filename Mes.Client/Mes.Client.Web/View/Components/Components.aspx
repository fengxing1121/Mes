<%@ Page Title="基础库列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Components.aspx.cs" Inherits="Mes.Client.Web.View.Components.Components" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <script src="../../Script/forms/products/parts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="产品库信息" region="center" style="border: 0px;" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="south" border="false" style="display: none;">
                <div id="pp" class="easyui-pagination" style="background: #eee;"></div>
            </div>
            <div region="center" border="false">
                <div id="content">
                    <ul id="list"></ul>
                </div>
            </div>
        </div>
    </div>
    <div region="west" title="产品类别" style="text-align: right; overflow: hidden; width: 250px;">
        <div class="easyui-layout" fit="true" border="false">
            <div region="north" border="false" style="height: auto 50px; width: 250px;">
                <form id="Form1" method="post">
                    <table>
                        <tr>
                            <td class="lbl-caption">品牌:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px" id="Text1" name="Brand" class="easyui-combobox" value="请选择" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">产品名称:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Text2" name="ProductName" type="text" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lbl-caption">设计师:
                            </td>
                            <td style="width: 120px;">
                                <input style="width: 120px; height: 22px;" id="Text3" name="Designer" type="text" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <a href="javascript:void(0)" id="btn_search_ok" icon="icon-search" style="width: 80px;">搜索</a>
                            </td>
                        </tr>
                    </table>
                </form>
            </div>
            <div region="center" border="false" title="产品类型">
                <div title="TreeMenu" data-options="iconCls:'icon-search'" style="padding: 10px;">
                    <ul class="easyui-tree">
                        <li>
                            <span>全屋家具</span>
                            <ul>
                                <li>
                                    <span>桌</span>
                                    <ul>
                                        <li>餐桌</li>
                                        <li>书桌</li>
                                        <li>茶几</li>
                                    </ul>
                                </li>
                                <li>
                                    <span>床</span>
                                    <ul>
                                        <li>儿童床</li>
                                        <li>主卧床</li>
                                        <li>次卧床</li>
                                    </ul>
                                </li>
                                <li>
                                    <span>柜</span>
                                    <ul>
                                        <li>衣柜</li>
                                        <li>厨柜</li>
                                        <li>鞋柜</li>
                                        <li>床头柜</li>
                                    </ul>
                                </li>
                                <li>
                                    <span>沙发</span>
                                    <ul>
                                        <li>
                                            <span>布艺沙发</span>
                                            <ul>
                                                <li>单人沙发</li>
                                                <li>贵妃沙发</li>
                                                <li>L型</li>
                                                <li>二人沙发</li>
                                                <li>多人沙发</li>
                                            </ul>
                                        </li>
                                        <li>
                                            <span>实木沙发</span>
                                            <ul>
                                                <li>红木沙发</li>
                                                <li>鸡翅木沙发</li>
                                                <li>仿古沙发</li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
