layui.use(['form', 'jquery'], function () {
    var form = layui.form;
    var $ = layui.jquery;
    //自定义验证规则
    form.verify({
        verifycode: function (value) {
            if (value.length != 4) {
                return '验证码得4个字符啊';
            }
        }
    });

    //验证码
    $('#LAY-user-get-vercode').click(function () {
        $(this).attr('src', '/Ashx/VerifyCodeHanler.ashx?pid=CN23000101&f=html&ck=1&r=' + Math.random());
    });

    //提交
    form.on('submit(LAY-user-login-submit)', function (formData) {
        var _this = this;
        var postData = formData.field;
        //工厂登录地址
        var reqestUrl = '/Ashx/loginhandler.ashx?Method=Login&r=';
        if (postData.loginRoles === 'partner') {
            //经销商登录地址
            reqestUrl = '/Ashx/partnetLoginHandler.ashx?Method=Login&r=';
        }
        $.ajax({
            url: reqestUrl + (new Date()).getTime().valueOf(),
            type: 'post',
            data: formData.field,
            dataType: 'json',
            beforeSend: function () {
                $(_this).text('正在登录中...')
                $(_this).addClass('layui-btn-disabled');
                $(_this).attr('disabled', true);
            }, success: function (res) {
                console.log(res);
                if (res.isOk == 1) {
                    window.location.href = res.url;
                } else {
                    layer.msg(res.message);
                }
            }, error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.msg(textStatus);
                //console.log(XMLHttpRequest.status);
                //console.log(XMLHttpRequest.readyState);
                //console.log(textStatus);
            }, complete: function () {
                $(_this).text('登 录');
                $(_this).removeClass('layui-btn-disabled');
                $(_this).attr('disabled', false);
                $('#LAY-user-get-vercode').attr('src', '/Ashx/VerifyCodeHanler.ashx?pid=CN23000101&f=html&ck=1&r=' + Math.random());
            }
        });
    });
});

$(function () {
    $("#LAY-user-login-username").blur(function () {
        var username = $("#" + this.id).val();
        if (username != "") {
            $.ajax({
                url: '/ashx/PartnetLoginHandler.ashx?Method=Userexist',
                dataType: 'text',
                data: { username: username },
                success: function (returnData) {
                    //console.log(JSON.stringify(returnData));
                    if (returnData == "true") {
                        $("#select>div").find("div").eq(2).click();
                    }
                    else {
                        $("#select>div").find("div").eq(1).click();
                    }
                }
            });
        }
    });
});
