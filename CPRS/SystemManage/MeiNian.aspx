<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MeiNian.aspx.cs" Inherits="BLOGBack.SystemManage.MeiNian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        table
        {
        	border:1px solid black;
            border-collapse:collapse;
            width:900px;
        }
        td
        {
        	border:1px solid black;
        	font-size:12px;
            border-collapse:collapse;
            text-align:center;
            white-space:nowrap;

        }
        div
        {
        	margin-top:1px;
        }
        
        table input
        {
            width:100px;
        }
       
       .lcwidth
       {
         
          width:100px;
          
           word-break: break-all; word-wrap:break-word;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
      <table id="Table1" style="border:1px solid black;" runat="server">           
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
        <tr ><td rowspan='4'>必选项目（体检基本内容）</td><td>1</td><td>甲肝</td><td></td> <td>辅助诊断甲型肝炎</td> <td>13</td><td>13</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>
        <tr ><td>2</td><td>乙肝（定性）</td><td>乙肝表面抗原、乙肝<br />表面抗体、乙肝e抗原<br />、乙肝e抗体、乙肝核心抗体</td> <td class='lcwidth'>可了解是否感染乙肝病毒，是否产生对肝炎病毒的抗体，是否应该注射疫苗以及注射疫苗后的效果。</td> <td>18</td><td>18</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>
        <tr ><td>3</td><td>甲肝</td><td></td> <td>辅助诊断丙型肝炎</td> <td>13</td><td>13</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>
        <tr ><td>4</td><td>甲肝</td><td>胸部正位片</td> <td>了解有无肺部疾病及心脏、主动脉、纵膈、横隔疾病等。</td> <td>60</td><td>60</td> <td><input type="checkbox" checked="checked"  disabled="disabled"/></td></tr>

        </table>    
</asp:Content>
