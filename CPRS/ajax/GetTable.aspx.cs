using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.Util;
using System.Text;
namespace BLOGBack.ajax
{
    public partial class GetTable1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string method = Request.QueryString["method"];
            switch (method) {
                case "ReadKltExcel":
                    Response.Write(ReadKltExcel());                   
                    break;
                    case "ReadMnExcel":
                    Response.Write(ReadMnExcel());                  
                    break;
                    case "ReadDHExcel":
                    Response.Write(ReadDHExcel());                   
                    break;
            }
           
        }

        #region  读取东华excel
        private string ReadDHExcel()
        {
            int beginRow = 6; int beginCol = 0;
            int endRow = 83; int endCol = 7;

            //有数据开始生成表格
            string save_path = "", tick = "";
            string temp_path = Server.MapPath("~/UploadFile/xls_files");//生成的文件存放路径
            if (!Directory.Exists(temp_path))
                Directory.CreateDirectory(temp_path);
            FileStream fs = new FileStream(Server.MapPath("~/Excel/东华.xls"), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var hssfworkbook = new HSSFWorkbook(fs);
            var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;
            var si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;

            var style_border = hssfworkbook.CreateCellStyle();
            var font = hssfworkbook.CreateFont();
            font.FontHeight = 16 * 16;
            style_border.VerticalAlignment = VerticalAlignment.CENTER;
            style_border.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style_border.BorderBottom = CellBorderType.THIN;
            style_border.BottomBorderColor = HSSFColor.BLACK.index;
            style_border.BorderLeft = CellBorderType.THIN;
            style_border.LeftBorderColor = HSSFColor.BLACK.index;
            style_border.BorderRight = CellBorderType.THIN;
            style_border.RightBorderColor = HSSFColor.BLACK.index;
            style_border.BorderTop = CellBorderType.THIN;
            style_border.TopBorderColor = HSSFColor.BLACK.index;
            style_border.SetFont(font);

            ISheet sheet1 = hssfworkbook.GetSheet("Sheet1");
            IRow row = sheet1.GetRow(beginRow);
            ICell cell = row.GetCell(beginCol);
            string value = cell.ToString();

            StringBuilder table = new StringBuilder("<table id=\"Table1\" class='second' style=\"border:1px solid black;\"");
            table.Append("<tr> <td colspan='8'>2016年邛崃东华医院体检菜单</td> </tr>");
            table.Append("<tr><td colspan='3'>姓名：<input id=\"Name\" type=\"text\"  /></td> <td colspan='3'>单位：<input id=\"Dept\" type=\"text\"  /></td> <td colspan='2'>性别：<select  id=\"sex\"><option value=\"请选择\">请选择</option><option value=\"男\">男</option><option value=\"女\">女</option>〈/select></td></tr>");
            table.Append("<tr><td rowspan='2'>项目</td><td rowspan='2'>序号</td><td rowspan='2'>项    目</td> <td rowspan='2'>项目说明</td> <td rowspan='2'>临床意义</td><td colspan='2' >检查对象</td> <td  rowspan='2'>选择项目</td>  </tr>");
            table.Append("<tr> <td >男性</td> <td >女性</td></tr>");
            //        table.Append(" <tr ><td rowspan='4'  class='xmwidth'>必选项目（体检基本内容）</td><td>1</td><td>甲肝</td><td class='xmsmwidth'></td> <td class='lcwidth'>辅助诊断甲型肝炎</td> <td>13</td><td>13</td> <td><input type=\"checkbox\" checked=\"checked\"  disabled=\"disabled\"/></td></tr>");

            string trr = "";

            for (int i = beginRow; i < beginRow + 4; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr = trr + "<tr>";
                for (int j = beginCol; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow && j == beginCol)
                    {
                        trr = trr + "<td rowspan='4'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol)
                    {
                        continue;
                    }
                    else if (j == 3)
                    {
                        trr = trr + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr = trr + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == endCol)
                    {

                        trr = trr + "<td><input id='ck" + i + "' type=\"checkbox\" checked=\"checked\"  disabled=\"disabled\"/></td>";

                    }
                    else
                    {
                        trr = trr + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr = trr + "</tr>";
            }

            table.Append(trr);

            IRow row2 = sheet1.GetRow(beginRow + 4);
            ICell cell2 = row2.GetCell(0);
            ICell cell3 = row2.GetCell(5);
            table.Append("<tr><td colspan='5'>" + cell2.ToString() + "</td><td colspan='3' id='hjsum'>" + cell3.ToString().Replace('_', ' ').Trim() + "</td></tr>");

            //
            IRow row5 = sheet1.GetRow(beginRow + 5);
            string tr5 = "<tr>";
            string id5 = "";
            for (int j = beginCol; j < endCol + 1; j++)
            { //5

                ICell cell5 = row5.GetCell(j);
                if (j == 1)
                {
                    id5 = cell5.ToString();
                }
                if (j == beginCol)
                {
                    tr5 = tr5 + "<td rowspan='73'  class='xmwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == 3)
                {
                    tr5 = tr5 + "<td class='xmsmwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == 4)
                {
                    tr5 = tr5 + "<td class='lcwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == endCol)
                {

                    tr5 = tr5 + "<td><input id='ck" + beginRow + 5 + "' type=\"checkbox\" value='" + beginRow + 5 + "' /></td>";

                }
                else
                {
                    tr5 = tr5 + "<td>" + cell5.ToString().Replace('_', ' ').Trim() + "</td>";
                }

            }
            table.Append(tr5);




            //13-17
            string trr13 = "";
            for (int i = beginRow + 6; i < beginRow + 11; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr13 = trr13 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 6 && j == beginCol + 3)
                    {
                        trr13 = trr13 + "<td rowspan='5'  class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 6 && j == beginCol + 4)
                    {
                        trr13 = trr13 + "<td rowspan='5'  class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol + 3 || j == beginCol + 4)
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr13 = trr13 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr13 = trr13 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr13 = trr13 + "</tr>";
            }

            table.Append(trr13);

            //18-21
            string trr11 = "";
            for (int i = beginRow + 11; i < beginRow + 15; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr11 = trr11 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);


                    if (j == endCol)
                    {

                        trr11 = trr11 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else if (j == 3)
                    {
                        trr11 = trr11 + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr11 = trr11 + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else
                    {
                        trr11 = trr11 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr11 = trr11 + "</tr>";
            }

            table.Append(trr11);


            //22-26
            string trr22 = "";
            for (int i = beginRow + 15; i < beginRow + 20; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr22 = trr22 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 15 && j == beginCol + 2)
                    {
                        trr22 = trr22 + "<td rowspan='5'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 15 && j == beginCol + 1)
                    {
                        trr22 = trr22 + "<td rowspan='5'  >" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 15 && j == beginCol + 4)
                    {
                        trr22 = trr22 + "<td rowspan='3'  class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol + 1 || j == beginCol + 2 || (j == beginCol + 4 && (i == beginRow + 16 || i == beginRow + 17)))
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr22 = trr22 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr22 = trr22 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr22 = trr22 + "</tr>";
            }

            table.Append(trr22);


            //27-33
            string trr27 = "";
            for (int i = beginRow + 20; i < beginRow + 27; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr27 = trr27 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 20 && j == beginCol + 2)
                    {
                        trr27 = trr27 + "<td rowspan='7'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 20 && j == beginCol + 1)
                    {
                        trr27 = trr27 + "<td rowspan='7'  >" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 20 && j == beginCol + 4)
                    {
                        trr27 = trr27 + "<td rowspan='7'  class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol + 2 || j == beginCol + 4 || j == beginCol + 1)
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr27 = trr27 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr27 = trr27 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr27 = trr27 + "</tr>";
            }

            table.Append(trr27);



            string trrElse = "";
            for (int i = beginRow + 27; i < beginRow + 77; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trrElse = trrElse + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);


                    if (j == endCol)
                    {

                        trrElse = trrElse + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else if (j == 3)
                    {
                        trrElse = trrElse + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trrElse = trrElse + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else
                    {
                        trrElse = trrElse + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trrElse = trrElse + "</tr>";
            }

            table.Append(trrElse);



            table.Append("</table>");
            return table.ToString();
        }
        #endregion


        #region 读取可利特excel
        private string ReadKltExcel() {
            int beginRow = 4; int beginCol = 0;
            int endRow = 45; int endCol = 7;

            //有数据开始生成表格
            string save_path = "", tick = "";
            string temp_path = Server.MapPath("~/UploadFile/xls_files");//生成的文件存放路径
            if (!Directory.Exists(temp_path))
                Directory.CreateDirectory(temp_path);
            FileStream fs = new FileStream(Server.MapPath("~/Excel/klt.xls"), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var hssfworkbook = new HSSFWorkbook(fs);
            var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;
            var si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;

            var style_border = hssfworkbook.CreateCellStyle();
            var font = hssfworkbook.CreateFont();
            font.FontHeight = 16 * 16;
            style_border.VerticalAlignment = VerticalAlignment.CENTER;
            style_border.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style_border.BorderBottom = CellBorderType.THIN;
            style_border.BottomBorderColor = HSSFColor.BLACK.index;
            style_border.BorderLeft = CellBorderType.THIN;
            style_border.LeftBorderColor = HSSFColor.BLACK.index;
            style_border.BorderRight = CellBorderType.THIN;
            style_border.RightBorderColor = HSSFColor.BLACK.index;
            style_border.BorderTop = CellBorderType.THIN;
            style_border.TopBorderColor = HSSFColor.BLACK.index;
            style_border.SetFont(font);

            ISheet sheet1 = hssfworkbook.GetSheet("Sheet1");
            IRow row = sheet1.GetRow(beginRow);
            ICell cell = row.GetCell(beginCol);
            string value = cell.ToString();

            StringBuilder table = new StringBuilder("<table id=\"Table1\" class='second' style=\"border:1px solid black;\"");
            table.Append("<tr> <td colspan='8'>可利特体检检查模版</td> </tr>");
            table.Append("<tr><td colspan='3'>姓名：<input id=\"Name\" type=\"text\"  /></td> <td colspan='3'>单位：<input id=\"Dept\" type=\"text\"  /></td> <td colspan='2'>性别：<select  id=\"sex\"><option value=\"请选择\">请选择</option><option value=\"男\">男</option><option value=\"女\">女</option>〈/select></td></tr>");
            table.Append("<tr><td rowspan='2'>项目</td><td rowspan='2'>序号</td><td rowspan='2'>项    目</td> <td rowspan='2'>项目说明</td> <td rowspan='2'>临床意义</td><td colspan='2' >检查对象</td> <td  rowspan='2'>选择项目</td>  </tr>");
            table.Append("<tr> <td >男性</td> <td >女性</td></tr>");
            //        table.Append(" <tr ><td rowspan='4'  class='xmwidth'>必选项目（体检基本内容）</td><td>1</td><td>甲肝</td><td class='xmsmwidth'></td> <td class='lcwidth'>辅助诊断甲型肝炎</td> <td>13</td><td>13</td> <td><input type=\"checkbox\" checked=\"checked\"  disabled=\"disabled\"/></td></tr>");

            string trr = "";

            for (int i = beginRow; i < beginRow + 4; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr = trr + "<tr>";
                for (int j = beginCol; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow && j == beginCol)
                    {
                        trr = trr + "<td rowspan='4'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol)
                    {
                        continue;
                    }
                    else if (j == 3)
                    {
                        trr = trr + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr = trr + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == endCol)
                    {

                        trr = trr + "<td><input id='ck" + i + "' type=\"checkbox\" checked=\"checked\"  disabled=\"disabled\"/></td>";

                    }
                    else
                    {
                        trr = trr + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr = trr + "</tr>";
            }

            table.Append(trr);
            //必检项目
            IRow row2 = sheet1.GetRow(beginRow + 4);
            ICell cell2 = row2.GetCell(0);
            ICell cell3 = row2.GetCell(5);
            table.Append("<tr><td colspan='5'>" + cell2.ToString() + "</td><td colspan='3' id='hjsum'>" + cell3.ToString().Replace('_', ' ').Trim() + "</td></tr>");


            //可选项目第一个
            //
            IRow row5 = sheet1.GetRow(beginRow + 5);
            string tr5 = "<tr>";
            string id5 = "";
            for (int j = beginCol; j < endCol + 1; j++)
            { //5

                ICell cell5 = row5.GetCell(j);
                if (j == 1)
                {
                    id5 = cell5.ToString();
                }
                if (j == beginCol)
                {
                    tr5 = tr5 + "<td rowspan='73'  class='xmwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == 3)
                {
                    tr5 = tr5 + "<td class='xmsmwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == 4)
                {
                    tr5 = tr5 + "<td class='lcwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == endCol)
                {

                    tr5 = tr5 + "<td><input id='ck" + 9 + "' type=\"checkbox\" value='" + 9 + "' /></td>";

                }
                else
                {
                    tr5 = tr5 + "<td>" + cell5.ToString().Replace('_', ' ').Trim() + "</td>";
                }

            }
            table.Append(tr5);




            //11-14
            string trr12 = "";
            for (int i = beginRow + 6; i < beginRow + 10; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr12 = trr12 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 6 && j == beginCol + 3)
                    {
                        trr12 = trr12 + "<td rowspan='4'  class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 6 && j == beginCol + 4)
                    {
                        trr12 = trr12 + "<td rowspan='4'  class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol + 3 || j == beginCol + 4)
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr12 = trr12 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr12 = trr12 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr12 = trr12 + "</tr>";
            }

            table.Append(trr12);



            //15-21
            string trr15 = "";
            for (int i = beginRow + 10; i < beginRow + 17; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr15 = trr15 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);


                    if (j == endCol)
                    {

                        trr15 = trr15 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else if (j == 3)
                    {
                        trr15 = trr15 + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr15 = trr15 + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else
                    {
                        trr15 = trr15 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr15 = trr15 + "</tr>";
            }

            table.Append(trr15);


            //22-26
            string trr22 = "";
            for (int i = beginRow + 17; i < beginRow + 22; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr22 = trr22 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 17 && j == beginCol + 2)
                    {
                        trr22 = trr22 + "<td rowspan='5'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 17 && j == beginCol + 1)
                    {
                        trr22 = trr22 + "<td rowspan='5'  >" + cell1.ToString() + "</td>";
                    }

                    else if (j == beginCol + 2 || j == beginCol + 1)
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr22 = trr22 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr22 = trr22 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr22 = trr22 + "</tr>";
            }

            table.Append(trr22);



            //27-28
            string trr27 = "";
            for (int i = beginRow + 22; i < beginRow + 24; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr27 = trr27 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 22 && j == beginCol + 2)
                    {
                        trr27 = trr27 + "<td rowspan='2'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow +22 && j == beginCol + 1)
                    {
                        trr27 = trr27 + "<td rowspan='2'  >" + cell1.ToString() + "</td>";
                    }

                    else if (j == beginCol + 2 || j == beginCol + 1)
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr27 = trr27 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr27 = trr27 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr27 = trr27 + "</tr>";
            }

            table.Append(trr27);


            //29
            IRow row19 = sheet1.GetRow(beginRow + 24);
            string tr19 = "<tr>";

            for (int j = beginCol + 1; j <= endCol; j++)
            { //5

                ICell cell5 = row19.GetCell(j);
                 if (j == 3)
                {
                    tr19 = tr19 + "<td class='xmsmwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == 4)
                {
                    tr19 = tr19 + "<td class='lcwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == endCol)
                {

                    tr19 = tr19 + "<td><input id='ck" + row19.RowNum + "' type=\"checkbox\" value='" + row19.RowNum + "' /></td>";

                }
                else
                {
                    tr19 = tr19 + "<td>" + cell5.ToString().Replace('_', ' ').Trim() + "</td>";
                }

            }
            table.Append(tr19);



            //30-31
            string trr30 = "";
            for (int i = beginRow + 25; i < beginRow + 27; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr30 = trr30 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 25 && j == beginCol + 2)
                    {
                        trr30 = trr30 + "<td rowspan='2'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 25 && j == beginCol + 1)
                    {
                        trr30 = trr30 + "<td rowspan='2'  >" + cell1.ToString() + "</td>";
                    }

                    else if (j == beginCol + 2 || j == beginCol + 1)
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr30 = trr30 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr30 = trr30 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr30 = trr30 + "</tr>";
            }

            table.Append(trr30);

            //32-34
            string trr32 = "";
            for (int i = beginRow + 27; i < beginRow + 30; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr32 = trr32 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 27 && j == beginCol + 2)
                    {
                        trr32 = trr32 + "<td   class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 27 && j == beginCol + 1)
                    {
                        trr32 = trr32 + "<td   >" + cell1.ToString() + "</td>";
                    }

                    

                    else if (j == endCol)
                    {

                        trr32 = trr32 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr32 = trr32 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr32 = trr32 + "</tr>";
            }

            table.Append(trr32);


            //35-38
            
            string trr35 = "";
            for (int i = beginRow + 30; i < beginRow + 34; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr35 = trr35 + "<tr>";
                for (int j = beginCol + 1; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 30 && j == beginCol + 2)
                    {
                        trr35 = trr35 + "<td rowspan='4'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (i == beginRow + 30 && j == beginCol + 1)
                    {
                        trr35 = trr35 + "<td rowspan='4'  >" + cell1.ToString() + "</td>";
                    }

                    else if (j == beginCol + 2 || j == beginCol + 1)
                    {
                        continue;
                    }

                    else if (j == endCol)
                    {

                        trr35 = trr35 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr35 = trr35 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr35 = trr35 + "</tr>";
            }

            table.Append(trr35);



            //39
            IRow row39 = sheet1.GetRow(beginRow + 34);
            string tr39 = "<tr>";

            for (int j = beginCol + 1; j <= endCol; j++)
            { //5

                ICell cell5 = row39.GetCell(j);
                if (j == 3)
                {
                    tr39 = tr39 + "<td class='xmsmwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == 4)
                {
                    tr39 = tr39 + "<td class='lcwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == endCol)
                {

                    tr39 = tr39 + "<td><input id='ck" + row39.RowNum + "' type=\"checkbox\" value='" + row39.RowNum + "' /></td>";

                }
                else
                {
                    tr39 = tr39 + "<td>" + cell5.ToString().Replace('_', ' ').Trim() + "</td>";
                }

            }
            table.Append(tr39);


            //40-43


            //39
            IRow row40= sheet1.GetRow(beginRow + 35);
            string tr40 = "<tr>";

            for (int j = beginCol + 1; j <= endCol; j++)
            { //5

                ICell cell5 = row40.GetCell(j);
                if (j == 3)
                {
                    tr40 = tr40 + "<td class='xmsmwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == 4)
                {
                    tr40 = tr40 + "<td class='lcwidth'>" + cell5.ToString() + "</td>";
                }
                else if (j == endCol)
                {

                    tr40 = tr40 + "<td><input id='ck" + row40.RowNum + "' type=\"checkbox\" value='" + row40.RowNum + "' /></td>";

                }
                else
                {
                    tr40 = tr40 + "<td>" + cell5.ToString().Replace('_', ' ').Trim() + "</td>";
                }

            }
            table.Append(tr40);


            return table.ToString();
        
        }
        #endregion


        #region 读取美年

        private string ReadMnExcel() {
            int beginRow = 4; int beginCol = 0;
            int endRow = 45; int endCol = 7;

            //有数据开始生成表格
            string save_path = "", tick = "";
            string temp_path = Server.MapPath("~/UploadFile/xls_files");//生成的文件存放路径
            if (!Directory.Exists(temp_path))
                Directory.CreateDirectory(temp_path);
            FileStream fs = new FileStream(Server.MapPath("~/Excel/美年体检最新报价.xls"), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var hssfworkbook = new HSSFWorkbook(fs);
            var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;
            var si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;

            var style_border = hssfworkbook.CreateCellStyle();
            var font = hssfworkbook.CreateFont();
            font.FontHeight = 16 * 16;
            style_border.VerticalAlignment = VerticalAlignment.CENTER;
            style_border.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style_border.BorderBottom = CellBorderType.THIN;
            style_border.BottomBorderColor = HSSFColor.BLACK.index;
            style_border.BorderLeft = CellBorderType.THIN;
            style_border.LeftBorderColor = HSSFColor.BLACK.index;
            style_border.BorderRight = CellBorderType.THIN;
            style_border.RightBorderColor = HSSFColor.BLACK.index;
            style_border.BorderTop = CellBorderType.THIN;
            style_border.TopBorderColor = HSSFColor.BLACK.index;
            style_border.SetFont(font);

            ISheet sheet1 = hssfworkbook.GetSheet("Sheet1");
            IRow row = sheet1.GetRow(beginRow);
            ICell cell = row.GetCell(beginCol);
            string value = cell.ToString();

            StringBuilder table = new StringBuilder("<table id=\"Table1\" class='second' style=\"border:1px solid black;\"");
            table.Append("<tr> <td colspan='8'>体检检查模版</td> </tr>");
            table.Append("<tr><td colspan='3'>姓名：<input id=\"Name\" type=\"text\"  /></td> <td colspan='3'>单位：<input id=\"Dept\" type=\"text\"  /></td> <td colspan='2'>性别：<select  id=\"sex\"><option value=\"请选择\">请选择</option><option value=\"男\">男</option><option value=\"女\">女</option>〈/select></td></tr>");
            table.Append("<tr><td rowspan='2'>项目</td><td rowspan='2'>序号</td><td rowspan='2'>项    目</td> <td rowspan='2'>项目说明</td> <td rowspan='2'>临床意义</td><td colspan='2' >检查对象</td> <td  rowspan='2'>选择项目</td>  </tr>");
            table.Append("<tr> <td >男性</td> <td >女性</td></tr>");
            //        table.Append(" <tr ><td rowspan='4'  class='xmwidth'>必选项目（体检基本内容）</td><td>1</td><td>甲肝</td><td class='xmsmwidth'></td> <td class='lcwidth'>辅助诊断甲型肝炎</td> <td>13</td><td>13</td> <td><input type=\"checkbox\" checked=\"checked\"  disabled=\"disabled\"/></td></tr>");

            string trr = "";

            for (int i = beginRow; i < beginRow + 4; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr = trr + "<tr>";
                for (int j = beginCol; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow && j == beginCol)
                    {
                        trr = trr + "<td rowspan='4'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol)
                    {
                        continue;
                    }
                    else if (j == 3)
                    {
                        trr = trr + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr = trr + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == endCol)
                    {

                        trr = trr + "<td><input id='ck" + i + "' type=\"checkbox\" checked=\"checked\"  disabled=\"disabled\"/></td>";

                    }
                    else
                    {
                        trr = trr + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr = trr + "</tr>";
            }

            table.Append(trr);
            //必检项目
            IRow row2 = sheet1.GetRow(beginRow + 4);
            ICell cell2 = row2.GetCell(0);
            ICell cell3 = row2.GetCell(5);
            table.Append("<tr><td colspan='5'>" + cell2.ToString() + "</td><td colspan='3' id='hjsum'>" + cell3.ToString().Replace('_', ' ').Trim() + "</td></tr>");

            //11-16
            string trr1 = "";
            for (int i = beginRow + 5; i < beginRow + 11;i++ )
            {
                IRow row1 = sheet1.GetRow(i);
                trr = trr + "<tr>";
                for (int j = beginCol; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 5 && j == beginCol)
                    {
                        trr1 = trr1 + "<td rowspan='6'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol)
                    {
                        continue;
                    }
                    else if (j == 3)
                    {
                        trr1 = trr1 + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr1 = trr1 + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == endCol)
                    {

                        trr1 = trr1 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr1 = trr1 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr1 = trr1 + "</tr>";
            }
            table.Append(trr1);


            

            //16-20
            string trr21 = "";
            for (int i = beginRow + 11; i < beginRow + 16; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr21 = trr21 + "<tr>";
                for (int j = beginCol; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 11 && j == beginCol)
                    {
                        trr21 = trr21 + "<td rowspan='5'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol)
                    {
                        continue;
                    }
                    else if (j == 3)
                    {
                        trr21 = trr21 + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr21 = trr21 + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == endCol)
                    {

                        trr21 = trr21 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr21 = trr21 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr21 = trr21 + "</tr>";
            }
            table.Append(trr21);


            //21-26
            string trr16 = "";
            for (int i = beginRow + 16; i < beginRow + 22; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr16 = trr16 + "<tr>";
                for (int j = beginCol; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 16 && j == beginCol)
                    {
                        trr16 = trr16 + "<td rowspan='6'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol)
                    {
                        continue;
                    }
                    else if (j == 3)
                    {
                        trr16 = trr16 + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr16 = trr16 + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == endCol)
                    {

                        trr16 = trr16 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr16 = trr16 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr16 = trr16 + "</tr>";
            }
            table.Append(trr16);



            //27-46
            string trr22 = "";
            for (int i = beginRow + 22; i < beginRow + 42; i++)
            {
                IRow row1 = sheet1.GetRow(i);
                trr22 = trr22 + "<tr>";
                for (int j = beginCol; j <= endCol; j++)
                {
                    ICell cell1 = row1.GetCell(j);
                    if (i == beginRow + 22 && j == beginCol)
                    {
                        trr22 = trr22 + "<td rowspan='20'  class='xmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == beginCol)
                    {
                        continue;
                    }
                    else if (j == 3)
                    {
                        trr22 = trr22 + "<td class='xmsmwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == 4)
                    {
                        trr22 = trr22 + "<td class='lcwidth'>" + cell1.ToString() + "</td>";
                    }
                    else if (j == endCol)
                    {

                        trr22 = trr22 + "<td><input id='ck" + i + "' value='" + i + "' type=\"checkbox\" /></td>";

                    }
                    else
                    {
                        trr22 = trr22 + "<td>" + cell1.ToString().Replace('_', ' ').Trim() + "</td>";
                    }
                }
                trr22 = trr22 + "</tr>";
            }
            table.Append(trr22);

            return table.ToString();
        
        }
        #endregion


       

    }
}