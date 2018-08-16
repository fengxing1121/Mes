<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Mes.Client.Web.View.Print.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lodop打印</title>
    <script src="../../Script/jquery-1.11.0.min.js"></script>
    <script src="/Script/forms/Print/jquery.forms.LodopFuncs.js"></script>
    <script type="text/javascript">
        
        var IsPrint =<%=IsPrint.ToString().ToLower()%>;//是否可打印
        var IsView =<%=IsView.ToString().ToLower()%>;//是否要预览
        
        var LODOP; //全局变量

        function PrintByHTML() {
            LODOP = getLodop();

            $(".qrcodetable").each(function(){
                var strHtml=$(this).html();
                console.log(strHtml);

                //在新一页输出
                LODOP.NewPage();

                //设置打印内容
                LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", strHtml);	

                //内容超出纸宽或纸高时对应缩小
                LODOP.SET_PRINT_MODE("FULL_WIDTH_FOR_OVERFLOW",true);
                LODOP.SET_PRINT_MODE("FULL_HEIGHT_FOR_OVERFLOW",true);

            });

            if(IsView){
                LODOP.SET_PREVIEW_WINDOW(1,0,1,800,600,"多伦斯MES生产管理系统.开始打印");//打印前弹出选择打印机的对话框
                LODOP.SET_SHOW_MODE("PREVIEW_NO_MINIMIZE",true);//预览窗口禁止最小化，并始终最前
                LODOP.SET_PRINT_MODE("AUTO_CLOSE_PREWINDOW",1);//打印后自动关闭预览窗口
                LODOP.SET_SHOW_MODE("HIDE_PAPER_BOARD",1);//隐藏条纹线
                LODOP.PREVIEW();//预览
            }
            else{
                LODOP.PRINT();//直接打印
            }
        };

        setTimeout(function () {
            if (IsPrint) {
                PrintByHTML();
            }
            else{
                alert("没有要打印的内容");
            }
        }, 1000);

    </script>   
</head>
<body>
    <%=PrintHtml%>
</body>
</html>
