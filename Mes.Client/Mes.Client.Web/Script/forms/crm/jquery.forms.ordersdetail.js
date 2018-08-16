(function ($) {
    document.msCapsLockWarningOff = true;
    var ordersDetailForm = {
        init: function () {
            ordersDetailForm.initControls();
            ordersDetailForm.events.loadData();
        },
        initControls: function () {
            ordersDetailForm.controls = {             
                search_form: $("#search_form")
            };
        },
        events: {
            loadData: function () {
                var OrderID = getUrlParam("orderid");
                if (OrderID.length == 0) return;
                $.ajax({
                    url: '/ashx/ordershandler.ashx?Method=GetOrder&' + jsNC(),
                    data: { OrderID: OrderID },
                    success: function (data) {
                        ordersDetailForm.controls.search_form.form('load', data);
                        $("#Status").val(GetOrderStatusName(data.Status));//订单状态
                        ordersDetailForm.controls.search_form.find("input").each(function () {
                            $(this).attr('readonly',true);
                        });
                        //是否正标
                        if (data.IsStandard == "True") {
                            $('#IsStandard').val("是")
                        } else {
                            $('#IsStandard').val("否")
                        }
                        //是否外购
                        if (data.IsOutsourcing == "True") {
                            $('#IsOutsourcing').val("是")
                        } else {
                            $('#IsOutsourcing').val("否")
                        }
                        $("#BookingDate").val(new Date(data.BookingDate).Formats("yyyy-MM-dd"));
                        $("#ShipDate").val(new Date(data.ShipDate).Formats("yyyy-MM-dd"));
                        if (('P,F,I,O').indexOf(data.Status)) {
                             $("#ManufactureDate").val("未开始");
                        }else{
                            $("#ManufactureDate").val(new Date(data.ManufactureDate).Formats("yyyy-MM-dd"));
                        }
                    }
                });
            }
        }
    };

    $(function () {
        ordersDetailForm.init();
    });
})(jQuery);