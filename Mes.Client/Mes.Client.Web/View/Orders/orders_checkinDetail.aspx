<%@ Page Title="入库库详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders_checkinDetail.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orders_checkinDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <style>
        #content ul li
        {
            float: left;
            list-style: none;
            margin: 5px;
        }

        #content .item ul li > a:hover
        {
            background: #eaf2ff;
            color: #000000;
        }

        #div_content ul li
        {
            float: left;
            list-style: none;
            margin-left: 5px;
        }

            #div_content ul li:hover
            {
                background: #fbf8e9;
                color: #000000;
                -o-transition: all 0.1s ease-in-out;
                -webkit-transition: all 0.1s ease-in-out;
                -moz-transition: all 0.1s ease-in-out;
                -ms-transition: all 0.1s ease-in-out;
                transition: all 0.1s ease-in-out;
                cursor: pointer;
            }

        #div_content .active
        {
            background: #ff6a00;
        }

        #div_content .item
        {
            width: 120px;
            height: 22px;
            float: left;
            border: 1px solid #eee;
            line-height: 22px;
            text-align: center;
        }
    </style>
    <script src="/Script/forms/orders/jquery.forms.orders_checkinDetail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <div title="出库详情" region="north" border="false" style="height: 175px; width: 100%; overflow: hidden;" collapsible="false">
        <div style="width: 100%">
            <form id="search_form">
                <div>
                    <input type="hidden" id="InID" name="InID" />
                </div>
                <table style="width: 100%; height: 50px;">
                    <tr>
                        <td style="width: 80px; text-align: right;">入库单号:
                        </td>
                        <td>
                            <input type="text" id="BillNo" name="BillNo" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">订单号：
                        </td>
                        <td>
                            <input id="OrderNo" type="text" name="OrderNo" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">客户名称:
                        </td>
                        <td>
                            <input type="text" id="Text3" name="CustomerName" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">客户地址:
                        </td>
                        <td>
                            <input type="text" id="Address" name="Address" style="width: 100%;" />
                        </td>

                        <td style="width: 80px; text-align: right;">联系人:
                        </td>
                        <td>
                            <input type="text" id="LinkMan" name="LinkMan" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">联系电话:
                        </td>
                        <td>
                            <input type="text" id="Text5" name="Mobile" style="width: 100%;" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <div region="center" border="false" >
        <div class="easyui-layout" fit="true">
            <div region="center" border="false">
                <div class="easyui-tabs" fit="true" border="false" id="tt" style="padding: 5px;">
                    <div title="入库明细" fit="true" border="false">
                        <table id="dgdetail">
                        </table>
                    </div>                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
