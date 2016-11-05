<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DongHua.aspx.cs" Inherits="BLOGBack.SystemManage.DongHua" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Repeater ID="Repeater1" runat="server" >     
      <HeaderTemplate>
       <table style="border:1px solid black;">           
        <tr>
        <td colspan='8'>2016年邛崃东华医院体检菜单</td>
        </tr>
        <tr>
        <td colspan='3'>姓名：<asp:TextBox ID="Name" runat="server" Width='100px'></asp:TextBox></td>
        <td colspan='3'>单位：<asp:TextBox ID="Dept" runat="server" Width='100px'></asp:TextBox></td>
        <td colspan='2'>体检号：<asp:TextBox ID="TestNum" runat="server" Width='100px'></asp:TextBox></td>
        </tr>
       
      </HeaderTemplate>

      <ItemTemplate>
      </ItemTemplate>

      <FooterTemplate>
          </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>
    </form>
</body>
</html>
