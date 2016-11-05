<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BLOGBack.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="JS/easyUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="JS/wikmenu.js" type="text/javascript"></script>
    <script src="JS/wikmain.js" type="text/javascript"></script>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var _menus = { "menus": [
						{ "menuid": "1", "icon": "icon-sys", "menuname": "管理员系统",
						    "menus": [{ "menuid": "11", "menuname": "链接管理", "icon": "icon-nav", "url": "/SystemManage/MeiNian.aspx" },
									{ "menuid": "12", "menuname": "文章管理", "icon": "icon-add", "url": "/SystemManage/ArticleManage.aspx" },
									{ "menuid": "13", "menuname": "管理员管理", "icon": "icon-users", "url": "/SystemManage/AdminInfo.aspx" },
									{ "menuid": "14", "menuname": "博客用户管理(添加修改功能有BUG)", "icon": "icon-role", "url": "/SystemManage/BlogUserManage.aspx" },
									{ "menuid": "15", "menuname": "回复管理", "icon": "icon-set", "url": "/SystemManage/RevertList.aspx" }								]
						}
				]
        };

        //设置登录窗口
        function openPwd() {
            $('#w').window({
                title: '修改密码',
                width: 300,
                modal: true,
                shadow: true,
                closed: true,
                height: 160,
                resizable: false
            });
        }

        //初始化左侧
        function InitLeftMenu1() {

            $(".easyui-accordion1").empty();
            var menulist = "";

            $.each(_menus.menus, function (i, n) {
                menulist += '<div title="' + n.menuname + '"  icon="' + n.icon + '" style="overflow:auto;">';
                menulist += '<ul>';
                $.each(n.menus, function (j, o) {
                    menulist += '<li><div><a ref="' + o.menuid + '" href="#" rel="' + o.url + '" ><span class="icon ' + o.icon + '" >&nbsp;</span><span class="nav">' + o.menuname + '</span></a></div></li> ';
                })
                menulist += '</ul></div>';
            })

            $(".easyui-accordion1").append(menulist);

            $('.easyui-accordion1 li a').click(function () {
                var tabTitle = $(this).children('.nav').text();

                var url = $(this).attr("rel");
                var menuid = $(this).attr("ref");
                var icon = getIcon(menuid, icon);

                addTab(tabTitle, url, icon);
                $('.easyui-accordion1 li div').removeClass("selected");
                $(this).parent().addClass("selected");
            }).hover(function () {
                $(this).parent().addClass("hover");
            }, function () {
                $(this).parent().removeClass("hover");
            });

            //导航菜单绑定初始化
            $(".easyui-accordion1").accordion();
        }

        //关闭登录窗口
        function closePwd() {
            $('#w').window('close');
            $('#txtNewPass').val('');
            $('#txtRePass').val('');
        }

        //修改密码
        function serverLogin() {

            var $newpass = $('#txtNewPass');
            var $rePass = $('#txtRePass');

            if ($newpass.val() == '') {
                msgShow('系统提示', '请输入密码！', 'warning');
                return false;
            }
            if ($rePass.val() == '') {
                msgShow('系统提示', '请再一次输入密码！', 'warning');
                return false;
            }

            if ($newpass.val() != $rePass.val()) {
                msgShow('系统提示', '两次密码不一至！请重新输入', 'warning');
                return false;
            }

            $.post('/ajax/EditPassword.ashx', { "username": $("#ipt_UserName").val(), "newpass": $newpass.val() },

             function (msg) {
                 msgShow('系统提示', '恭喜，密码修改成功！<br>您的新密码为：' + msg, 'info');
                 $newpass.val('');
                 $rePass.val('');
                 closePwd();
             });
        }

        $(function () {
            openPwd();
            InitLeftMenu1();

            $('#editpass').click(function () {
                $('#w').window('open');
            });

            $('#btnEp').click(function () {
                serverLogin();
            });

            $('#btnCancel').click(function () { closePwd(); })

            $('#loginOut').click(function () {
                $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {

                    if (r) {
                        location.href = '/ajax/loginout.ashx';
                    }
                });
            })
        });
    </script>
    <title>管理信息系统</title>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scroll="no">
    <input type="hidden" id="ipt_UserName" name="ipt_UserName" value="<%=UserName%>" />
    <noscript>
        <div style="position: absolute; z-index: 100000; height: 2046px; top: 0px; left: 0px;
            width: 100%; background: white; text-align: center;">
            <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 30px;
        background: url(images/layout-browser-hd-bg.gif) #7f99be repeat-x center 50%;
        line-height: 20px; color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float: right; padding-right: 20px;" class="head">欢迎
            <%=UserName%>
            <a href="javascript:void()" style="cursor: pointer; text-decoration: none;" id="editpass">
                修改密码</a> <a href="javascript:void()" id="loginOut" style="cursor: pointer; text-decoration: none;">
                    安全退出</a></span> <span style="padding-left: 10px; font-size: 16px;">
                        <img src="/images/blocks.gif" width="20" height="20" align="absmiddle" />
                        管理信息系统</span>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2;">
        <div class="footer">
            &nbsp;&nbsp;&nbsp; xxxxxxxxxxxx</div>
    </div>
    <div region="west" split="true" title="导航菜单" style="width: 180px;" id="west">
        <div class="easyui-accordion1" fit="true" border="false">
            <!--  导航内容 -->
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
            <div title="欢迎使用" style="padding: 20px; overflow: hidden;" id="home">
                <h1>
                    欢迎使用EASYUI后台系统!</h1>
            </div>
        </div>
    </div>
    <!--修改密码窗口-->
    <div id="w" class="easyui-window" title="修改密码" collapsible="false" minimizable="false"
        maximizable="false" icon="icon-save" style="width: 300px; height: 150px; padding: 5px;
        background: #fafafa;">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 10px; background: #fff; border: 1px solid #ccc;">
                <table cellpadding="3">
                    <tr>
                        <td>
                            新密码：
                        </td>
                        <td>
                            <input id="txtNewPass" type="Password" class="txt01" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            确认密码：
                        </td>
                        <td>
                            <input id="txtRePass" type="Password" class="txt01" />
                        </td>
                    </tr>
                </table>
            </div>
            <div region="south" border="false" style="text-align: right; height: 30px; line-height: 30px;">
                <a id="btnEp" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)">确定</a>
                <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel" href="javascript:void(0)">
                    取消</a>
            </div>
        </div>
    </div>
    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="mm-tabclose">
            关闭</div>
        <div id="mm-tabcloseall">
            全部关闭</div>
        <div id="mm-tabcloseother">
            除此之外全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-tabcloseright">
            当前页右侧全部关闭</div>
        <div id="mm-tabcloseleft">
            当前页左侧全部关闭</div>
        <div class="menu-sep">
        </div>
        <div id="mm-exit">
            退出</div>
    </div>
</body>
</html>
