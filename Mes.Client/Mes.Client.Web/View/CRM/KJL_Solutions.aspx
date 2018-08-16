<%@ Page Title="酷家乐方案" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KJL_Solutions.aspx.cs" Inherits="Mes.Client.Web.View.CRM.KJL_Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="../../Content/css/ext_icons.css" rel="stylesheet" />
    <script src="../../Script/forms/crm/jquery.forms.kjlsolutions.js"></script>
    <style>
        #list li {
            list-style: none;
            float: left;
            margin: 5px;
            width: 320px auto;
            height: 280px;
            border: solid 1px #eee;
        }

            #list li:hover {
                border: solid 1px rgba(255, 106, 0, 0.22);
                border-radius: 3px;
            }

        .imgwrap {
            display: table-cell;
            text-align: center;
            vertical-align: middle;
            float: left;
        }

            .imgwrap img {
                max-width: 280px;
                max-height: 210px;
                height: 210px auto;
                width: 280px auto;
                vertical-align: middle;
                text-align: center;
                clear: both;
            }

        .product_item {
            width: 200px;
            height: 180px;
            float: left;
            margin: 0px;
            padding: 0px;
            float: left;
        }

            .product_item .title {
                font-size: 16pt;
                text-align: center;
                font-weight: bold;
            }

            .product_item .caption {
                font-size: 9pt;
                text-align: right;
            }

        .kjl-button {
            margin: 5px;
            width: 100px;
            height: 30px;
            border: solid 1px #eee;
            text-align: center;
            vertical-align: middle;
            line-height: 30px;
            list-style: none;
            background: #fff;
            border-radius: 3px;
            float: left;
            cursor: pointer;
        }

            .kjl-button:hover {
                background-color: #ff6a00;
            }
    </style>
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
                    <div style="height: 30px; width: 100px;">
                        <div class="kjl-button" onclick="jsNewSolution()">新建设计</div>
                    </div>
                    <ul id="list">
                        <%--<li>
                            <div style="width: 100% auto; height: 280px; border: solid 1px #eee;">
                                <div style="width: 95%; height: 30px; font-size: 16pt; line-height: 30px; padding-left: 10px; font-weight: bold; border-bottom: solid 1px #eee;">广州万科城</div>
                                <div class="imgwrap">
                                    <img src="https://qhyxpicoss.kujiale.com/fpimgnew/2017/07/05/WVxPIwr7-jRp5wAAAAk_800x800.jpg@!200x200" />
                                </div>
                                <div class="product_item">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="title" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td class="caption">地址：</td>
                                            <td>客户地址 </td>
                                        </tr>
                                        <tr>
                                            <td class="caption">户型：</td>
                                            <td>三房两厅2卫</td>
                                        </tr>
                                        <tr>
                                            <td class="caption">设计时间：</td>
                                            <td>2017-07-13 </td>
                                        </tr>
                                        <tr>
                                            <td class="caption">最后修改：</td>
                                            <td>2017-07-13 </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="clear: both; width: 320px; line-height: 30px; text-align: center; padding-top: 10px;">
                                    <div class="kjl-button" onclick="jsDesigner()">去装修</div>
                                    <div class="kjl-button" onclick="jsDownloadSolution('')">导出拆单文件</div>
                                </div>
                            </div>
                        </li>--%>
                    </ul>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
