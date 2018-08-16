<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mprView.aspx.cs" Inherits="Mes.Client.Web.View.Orders.mprView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Content/css/mpr/index.css" rel="stylesheet" />
    <script src="../../Script/forms/mpr/jquery-1.9.1.min.js"></script>
    <%if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
        {%>
    <script src="../../Script/forms/mpr/jquery.forms.search.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.entity.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.math.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.mpr.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.index.js"></script>
    <%}
    %>
    <%else
        {%>
    <script src="../../Script/forms/mpr/jquery.forms.search.encry.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.entity.encry.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.math.encry.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.mpr.encry.js"></script>
    <script src="../../Script/forms/mpr/jquery.forms.index.encry.js"></script>
    <%}
    %>
</head>
<body>
    <div width="80%" height="100%">
        <div id="panel_radio" style="width: 100%; height: 25px; display: none;"></div>
        <canvas id="panel_canvas" width="834" height="500" style="border: 0px solid #d3d3d3; float: left">浏览器不支持画图功能
        </canvas>
    </div>
    <input type="hidden" id="txtContext" />
    <input type="button" id="BtnSearch" style="display: none;" />
</body>
</html>
