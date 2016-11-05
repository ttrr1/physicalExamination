<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MeiNian.aspx.cs" Inherits="BLOGBack.SystemManage.MeiNian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        table.second
        {
        	border:1px solid black;
            border-collapse:collapse;
            width:900px;
        }
        table.second td
        {
        	border:1px solid black;
        	font-size:12px;
            border-collapse:collapse;
            text-align:center;
            white-space:nowrap;

        }
        
        
        table.second input
        {
            width:100px;
        }
       
       .lcwidth
       {
         text-align:left;
         white-space:pre-wrap;
         width:150px;
        }
        .xmsmwidth
       {
         text-align:left;
         white-space:pre-wrap;
         width:120px;
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
<script type="text/javascript">
    $(function () {
        $.get("//", function (data,status) {
        
         });
    });
</script>
 <form id="Form1" runat="server">

  <div id="tab_toolbar" style="padding: 0 2px;"  runat="server">
        <table cellpadding="0" cellspacing="0" style="width: 100%"  runat="server">
            <tr>
                <td style="padding-left: 2px"  runat="server">
                  
                           <asp:Button ID="Button1" runat="server" Text="导出" onclick="Button1_Click" />         
                    <input type="text" runat="server" id="test" />
                    
                </td>
                
              
            </tr>
        </table>
    </div>
      <table id="Table1" class='second' style="border:1px solid black;" runat="server">           
        <tr>
        <td colspan='8'>2016年邛崃东华医院体检菜单</td>
        </tr>
        <tr>
        <td colspan='3'>姓名：<input id="Name" type="text"  /></td>
        <td colspan='3'>单位：<input id="Dept" type="text"  /></td>
        <td colspan='2'>体检号：<input id="TestNum" type="text"  /></td>
        </tr>
        <tr>
        <td rowspan='2'>项目</td>
        <td rowspan='2'>序号</td>
        <td rowspan='2'>项    目</td>
        <td rowspan='2'>项目说明</td>
        <td rowspan='2'>临床意义</td>
        <td colspan='2' >检查对象</td>
        <td  rowspan='2'>选择项目</td>       
        </tr>
        <tr>        
        <td >男性</td>
        <td >女性</td>
        </tr>
        <tr ><td rowspan='4'  class='xmwidth'>必选项目（体检基本内容）</td><td>1</td><td>甲肝</td><td class='xmsmwidth'></td> <td class='lcwidth'>辅助诊断甲型肝炎</td> <td>13</td><td>13</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>
        <tr ><td>2</td><td>乙肝（定性）</td><td class='xmsmwidth'>乙肝表面抗原、乙肝表面抗体、乙肝e抗原、乙肝e抗体、乙肝核心抗体</td> <td class='lcwidth'>可了解是否感染乙肝病毒，是否产生对肝炎病毒的抗体，是否应该注射疫苗以及注射疫苗后的效果。</td> <td>18</td><td>18</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>
        <tr ><td>3</td><td>甲肝</td><td class='xmsmwidth'></td> <td class='lcwidth'>辅助诊断丙型肝炎</td> <td>13</td><td>13</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>
        <tr ><td>4</td><td>甲肝</td ><td class='xmsmwidth'>胸部正位片</td> <td class='lcwidth'>了解有无肺部疾病及心脏、主动脉、纵膈、横隔疾病等。</td> <td>60</td><td>60</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>
        <tr><td colspan='5'>必检项目合计</td><td colspan='3'>104</td></tr>
        <tr ><td rowspan='61' class='xmwidth'>自选项目（可根据自身情况自由选择）</td><td>4</td><td>甲肝</td ><td class='xmsmwidth'>胸部正位片</td> <td class='lcwidth'>了解有无肺部疾病及心脏、主动脉、纵膈、横隔疾病等。</td> <td>60</td><td>60</td> <td><input type="checkbox"  /></td></tr>

        </table>  
        </form>  
</asp:Content>
