<%@ Page Title="出库详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orders_checkoutDetail.aspx.cs" Inherits="Mes.Client.Web.View.Orders.orders_checkoutDetail" %>
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
    <script src="/Script/forms/orders/jquery.forms.orders_checkoutDetail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="出库详情" region="north" border="false" style="height: 175px; width: 100%; overflow: hidden;" collapsible="false">
        <div style="width: 100%">
            <form id="search_form">
                <div>
                    <input type="hidden" id="TransportID" name="TransportID" />
                </div>
                <table style="width: 100%; height: 50px;">
                    <tr>
                        <td style="width: 80px; text-align: right;">运输单号:
                        </td>
                        <td>
                            <input type="text" id="TransportNo" name="TransportNo" style="width: 100%;" />
                        </td>
                        <td style="width: 100px; text-align: right;">物流公司：
                        </td>
                        <td>
                            <input id="EnterpriseName" type="text" name="EnterpriseName" style="width: 100%;" />
                        </td>
                        <td style="width: 80px; text-align: right;">车牌号:
                        </td>
                        <td>
                            <input type="text" id="PlateNo" name="PlateNo" style="width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; text-align: right;">驾驶人:
                        </td>
                        <td>
                            <input type="text" id="DriverName" name="DriverName" style="width: 100%;" />
                        </td>

                        <td style="width: 80px; text-align: right;">出发地:
                        </td>
                        <td>
                            <input type="text" id="Source" name="Source" style="width: 100%;" />
                        </td>
                         <td style="width: 80px; text-align: right;">目的地:
                        </td>
                        <td>
                            <input type="text" id="Target" name="Target" style="width: 100%;" />
                        </td>
                    </tr>
                     <tr>
                          <td style="width: 80px; text-align: right;">运输费用:
                        </td>
                        <td>
                            <input type="text" id="Price" name="Price" style="width: 100%;" />
                        </td>
                          <td style="width: 80px; text-align: right;">出库时间:
                        </td>
                        <td>
                            <input type="text" id="Created" name="Created" style="width: 100%;" />
                        </td>
                     </tr>
                </table>
            </form>
        </div>
    </div>
    <div region="center" border="false" ">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false">
                <div class="easyui-tabs" fit="true" border="false" id="tt" style="padding: 5px;">
                    <div title="出库明细" fit="true" border="false">
                        <table id="dgdetail">
                        </table>
                    </div>                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
