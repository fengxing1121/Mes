<%@ Page Title="我的消息" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notice.aspx.cs" Inherits="Mes.Client.Web.View.system.notice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
     <style>
        .msg
        {
            background: url(/Content/images/icons_workStyle1ca3fe.png) no-repeat;
            background-position-x: 0px;
            background-position-y: 0;
            color: #747474;
            line-height: 56px;
            display: inline-block;
            width: 56px;
            height: 56px;
        }

        .msg-order
        {
            background-position: left;
            background-position-x: 0px;
            background-position-y: 0;
        }

        .msg-sys
        {
            background-position: left;
            background-position-x: -55px;
            background-position-y: 0;
        }

        .msg-ticket
        {
            background-position: left;
            background-position-x: -110px;
            background-position-y: 0;
        }

        .msg-task
        {
            background-position: left;
            background-position-x: -165px;
            background-position-y: 0;
        }

        .msg-time
        {
            display: inline-block;
            background-color: #f7f7f7;
            width: 62px;
            height: 25px;
            padding: 5px;
            border-radius: 3px;
            text-align: center;
        }

        .msg-box
        {
            margin: 10px 20px;
            background-color: #f3f3f3;
            padding: 10px 20px;
            border: 1px solid #FFF;
        }

            .msg-box:hover
            {
                border: 1px solid #ccc;
            }

            .msg-box .msg-content
            {
                padding-top: 10px;
                padding-bottom: 10px;
                height: auto;
            }

            .msg-box .mg-details
            {
                float: right;
                color: #005ea7;
            }

        .msg-title
        {
            height: 32px;
            line-height: 32px;
            position: relative;
            border-bottom: 1px solid #d3d3d3;
        }

            .msg-title h4
            {
                text-align: left;
                padding-bottom: 5px;
            }

        .clearfix
        {
        }

        ul li
        {
            list-style: none;
        }

        ul
        {
            margin-left: 10px;
            list-style-type: disc;
            -webkit-margin-before: 1em;
            -webkit-margin-after: 1em;
            -webkit-margin-start: 0px;
            -webkit-margin-end: 0px;
            -webkit-padding-start: 10px;
        }

        .nav
        {
        }

            .nav li
            {
                padding-top: 5px;
                cursor:pointer;
            }

            .nav .nav-item
            {
                border: solid 1px #99ccff;
                text-align: left;
                width: 250px;
                padding: 5px;
                background: #fff;
            }

                .nav .nav-item:hover
                {
                    background: #ececec;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div title="我的消息" region="center" border="false">
        <div class="easyui-layout" fit="true" border="false">
            <div region="center" border="false" style="text-align: left; height: auto; overflow: hidden;" id="search_window">
                <div id="dg_notice" class="msg-body">
                    <ul style="padding: 0px;">
                        <li>
                            <span class="msg-time" style="width: 125px; margin-left: 230px">2016-12-01 12:46:07</span>
                            <div class="msg-box">
                                <div class="msg-title">
                                    <h4>活动礼包</h4>
                                    <s style="cursor: pointer" onclick="logicDeleteMessage(11293149897)"></s>
                                </div>
                                <div class="msg-content clearfix">
                                    <div>送您本月钻石会员专享礼包，祝您购物愉快！</div>
                                    <a href="#" class="mg-details">查看详情>>></a>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div region="west" style="width: 300px; border-right: solid 1px #99ccff; text-align: center; padding: 10px;" border="false">
                <ul style="padding: 0px;" class="nav">
                    <li>
                        <div class="nav-item">
                            <span class="msg msg-order">&nbsp;</span><span style="padding-left: 10px;">系统消息</span>
                        </div>
                    </li>
                    <li>
                        <div class="nav-item">
                            <div>
                                <span class="msg msg-sys">&nbsp;</span><span style="padding-left: 10px;">订单消息</span>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="nav-item">
                            <span class="msg msg-ticket">&nbsp;</span><span style="padding-left: 10px;">优惠消息</span>
                        </div>
                    </li>
                    <li>
                        <div class="nav-item">
                            <span class="msg msg-task">&nbsp;</span><span style="padding-left: 10px;">任务消息</span>
                        </div>
                    </li>
                    <li>
                        <div class="nav-item">
                            <span class="msg msg-task">&nbsp;</span><span style="padding-left: 10px;">系统公告</span>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
