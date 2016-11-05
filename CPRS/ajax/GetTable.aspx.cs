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
namespace BLOGBack.ajax
{
    public partial class GetTable1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("");
        }

        private string ReadExcel()
        {
            int beginRow = 6; int beginCol = 0;

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

            string tr = "<tr ><td rowspan='61' class='xmwidth'></td><td></td><td></td ><td class='xmsmwidth'></td> <td class='lcwidth'></td> <td>60</td><td>60</td> <td><input type=\"checkbox\" id= /></td></tr>";
            for (int i = 6; i < 67; i++) { 
            
            }
            return tr;
        }


    }
}