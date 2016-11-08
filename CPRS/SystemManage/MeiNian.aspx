﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MeiNian.aspx.cs" Inherits="BLOGBack.SystemManage.MeiNian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        table.second
        {
        	border:1px dotted balck;
            border-collapse:collapse;
            width:900px;
        }
        table.second td
        {
        	border:1px solid black;
        	font-size:12px;
            border-collapse:collapse;
            text-align:center;          

        }
        
        
        table.second input
        {
            width:100px;
        }
       
       .lcwidth
       {
         text-align:left;
         white-space:pre-wrap;
         width:200px;
        }
        .xmsmwidth
       {
         text-align:left;
         white-space:pre-wrap;
         width:150px;
        }
         .xmwidth
       {
         text-align:center;
         white-space:pre-wrap;
         width:150px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="padding-left: 2px">
                    <a href="#"  id="a_print"
                        class="easyui-linkbutton" iconcls="icon-print">导出</a> 
                </td>
             </tr>
        </table>
   
       
        <div id="testr">
        </div> 
        <script type="text/javascript">
            $(function () {
                $.ajaxSetup({//取消异步，防止取不到返回html 
                    async: false
                });
                $.get("/ajax/GetTable.aspx", { "method": "ReadMnExcel" }, function (data, status) {
                    var dd = $('table :last').html();
                    var tr = $("data");
                    $("#testr").html(data);
                    flag_load = true;
                });
               
                var flag;
                $("#a_print").click(function () {
                    var sf = $.trim($("#sflx :selected").val());
                    var sfz = $.trim($("#sfz").val());

                    var dept = $.trim($("#Dept").val());
                    var sex = $.trim($("#sex :selected").val());
                    if (sex == "请选择") {
                        alert("请输入性别");
                        return false;
                    }
                    var name = $.trim($("#Name").val());

                    if (name == "") {
                        alert("请输入姓名");
                        return false;
                    }
                    var ids = "";
                    var bx = $("#hjsum").text();
                    var sum = parseInt(bx);
                    var $ids = $("#Table1 tr:gt(8)").find(":checkbox:not(:checked)").each(function () {
                        ids = ids + $(this).val() + ",";
                    });
                    ids = ids.substring(0, ids.length - 1);

                    if (sex == '男') {
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

                    if (sum > 500) {
                        flag = false;
                    } else {
                        flag = true;
                    }

                    if (flag == true) {
                        alert("输入的金额：" + sum);
                        $.get("/ajax/PrintExcel.aspx", { "method": "PrintMnExcelFile", "dept": dept, "name": name,"sf":sf,"sfz":sfz, "sex": sex, "ids": ids }, function (data, status) {

                            var model = JSON.parse(data);

                            if (model.state == "yes") {

                                window.location.href = "/ajax/PrintExcel.aspx?method=BuildExcelByUrl&url=" + model.msg;
                            } else {
                                $.alert(model.msg);
                            }
                        });

                    } else {
                        alert("输入的金额：" + sum + " 大于500");
                    }

                });


            });
</script>

<script type="text/javascript" src="../JS/tip.js"></script>
</asp:Content>
