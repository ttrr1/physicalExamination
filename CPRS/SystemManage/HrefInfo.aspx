﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="HrefInfo.aspx.cs" Inherits="BLOGBack.SystemManage.HrefInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--列表 start--%>
    <form id="form_list" name="form_list" method="post">
    <table id="tab_list">
    </table>
    <div id="tab_toolbar" style="padding: 0 2px;">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="padding-left: 2px">
                    <a href="#" onclick="$('#form_edit input').val('');OpenWin();return false;" id="a_add"
                        class="easyui-linkbutton" iconcls="icon-add">添加</a> <a href="#" onclick="DelData(0);return false;"
                            id="a_del" class="easyui-linkbutton" iconcls="icon-cancel">删除</a>
                </td>
                <td style="text-align: right; padding-right: 15px">
                    <input id="ipt_search" menu="#search_menu" />
                    <div id="search_menu" style="width: 120px">
                        <div name="Name">
                            链接名称
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <%--列表 end--%>
    <%--添加 修改 start--%>
    <div id="edit" class="easyui-dialog" title="编辑链接" style="width: 250px; height: 200px;"
        modal="true" closed="true" buttons="#edit-buttons">
        <form id="form_edit" name="form_edit" method="post" url="HrefInfo.aspx">
        <table class="table_edit">
            <tr>
                <td class="tdal">
                    链接名称：
                </td>
                <td class="tdar">
                    <input id="ipt_Name" name="ipt_Name" type="text" class="easyui-validatebox" required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">
                    链接URL：
                </td>
                <td class="tdar">
                    <input id="ipt_Url" name="ipt_Url" type="text" class="easyui-validatebox" required="true" />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton">提交</a> <a href="javascript:;"
            class="easyui-linkbutton" onclick="$('#edit').dialog('close');return false;">取消</a>
    </div>
    <%--添加 修改 end--%>
    <script type="text/javascript">

        $(function () {
            InitGird();
            InitSearch();
        });
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '链接列表', //表格标题
                url: location.href, //请求数据的页面
                sortName: 'JSON_HrefID', //排序字段
                idField: 'JSON_HrefID', //标识字段,主键
                iconCls: '', //标题左边的图标
                width: '50%', //宽度
                height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 300, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: 'desc', //排序类型
                remoteSort: true, //定义是否从服务器给数据排序
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                {field: 'cbx', checkbox: true },
				]],
                columns: [[
                    { title: '链接名称', field: 'JSON_Name', width: 100 },
                    { title: '链接URL', field: 'JSON_Url', width: 150 },
                    { title: '操作', field: 'JSON_HrefID', width: 80, formatter: function (value, rec) {
                        return '<a style="color:red" href="javascript:;" onclick="EditData(' + value + ');$(this).parent().click();return false;">修改</a>';
                    }
                    }
                ]],
                toolbar: "#tab_toolbar",
                queryParams: { "action": "query" },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
            });
        }

        //初始化搜索框
        function InitSearch() {
            $("#ipt_search").searchbox({
                width: 200,
                iconCls: 'icon-save',
                searcher: function (val, name) {
                    $('#tab_list').datagrid('options').queryParams.search_type = name;
                    $('#tab_list').datagrid('options').queryParams.search_value = val;
                    $('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的信息'
            });
        }

        //打开添加窗口
        function OpenWin() {
            $("#edit").dialog("open");
            $("#edit-buttons a:first").attr("onclick", "Add(0); return false;")
        }
        function GetInputData(id, cmd) {
            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });
            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }

        //提交按钮事件
        function Add(uid) {
            if (!$("#form_edit").form("validate")) {
                return;
            }
            var json = GetInputData('edit', 'submit');

            json.id = uid;
            $.post(location.href, json, function (data) {
                $.messager.alert('提示', data, 'info', function () {
                    if (data.indexOf("成功") > 0) {
                        console.info(data);
                        $("#tab_list").datagrid("reload");
                        $("#edit").dialog("close");
                    }
                });
            });
        }

        //修改链接 事件
        function EditData(uid) {
            $("#edit").dialog("open");
            $("#btn_add").attr("onclick", "Add(" + uid + "); return false;")

            $.post(location.href, { "action": "queryone", "id": uid }, function (data) {
                var dataObj = eval("(" + data + ")"); //转换为json对象
                console.info(dataObj);
                $("#form_edit").form('load', dataObj);
            });
        }

        //删除按钮事件
        function DelData(id) {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    var selected = "";
                    if (id <= 0) {
                        $($('#tab_list').datagrid('getSelections')).each(function () {
                            selected += this.JSON_HrefID + ",";
                        });
                        selected = selected.substr(0, selected.length - 1);
                        if (selected == "") {
                            $.messager.alert('提示', '请选择要删除的数据！', 'info');
                            return;
                        }
                    }
                    else {
                        selected = id;
                    }
                    $.post(location.href, { "action": "del", "cbx_select": selected }, function (data) {
                        $.messager.alert('提示', data, 'info', function () { $("#tab_list").datagrid("reload"); });
                    });
                }
            });
        }
    </script>
</asp:Content>
