$(function () {
    var t = $("#Table1").html();
    var sex1 = $.trim($("#sex :selected").val());
    $("#sex").change(function () {
        sex1 = $(this).val();

    });
    $("#Table1 tr:gt(8) td :checkbox").change(function () {

        var name = $.trim($("#Name").val());
        var dept = $.trim($("#Dept").val());
        var sf = $.trim($("#sflx :selected").val());
        var sfz = $.trim($("#sfz").val());
        sex1 = $.trim($("#sex :selected").val());

        var bx = $("#hjsum").text();
        var sum = parseInt(bx);

        if (name == "") {
            alert("请填写姓名");
            $(this).prop("checked", false);
            return false;
        }
        if (sf == "请选择") {
            alert("请选择身份");
            $(this).prop("checked", false);
            return false;
        }
        if (sfz == "") {
            alert("请填写身份证");
            $(this).prop("checked", false);
            return false;
        }
        if (dept == "") {
            alert("请填写单位");
            $(this).prop("checked", false);
            return false;
        }
        if (sex1 == "请选择") {

            alert("请选择性别");
            $(this).prop("checked", false);
            return false;
        }

        if (sex1 == '男') {
            $("#Table1 tr:gt(8)").find(":checkbox:checked").each(function () {
                var sf = $(this).parent().prev().prev().text();

                if (sf != "") {
                    sum = sum + parseInt(sf);
                }

            });
        } else {

            $("#Table1 tr:gt(8)").find(":checkbox:checked").each(function () {
                var sf = $(this).parent().prev().text();

                if (sf != "") {
                    sum = sum + parseInt(sf);
                }

            });
        }
        alert("已选费用：" + sum);
        //$(this).append("<b>fsfdsdf</b>");
    }
   );
})

