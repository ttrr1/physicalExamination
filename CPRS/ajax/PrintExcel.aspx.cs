using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;

namespace BLOGBack.ajax
{
    public partial class PrintExcel : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
            //获取方法名
            string methodName = Request.QueryString["method"];
            //获取当前实例
            Type type = GetType();
            //获取指定的public方法
            MethodInfo method = type.GetMethod(methodName);
            if (method != null)
            {
                //调用当前实例方法
                method.Invoke(this, null);
            }

           // PrintMnExcelFile( name, sex,dept, ids);
        }

        #region 导出美年
        public  void PrintMnExcelFile()
        {
            string name = Request.QueryString["name"];
            string sex = Request.QueryString["sex"];
            string sf = Request.QueryString["sf"];
            string sfz = Request.QueryString["sfz"];
            string dept = Request.QueryString["dept"];
            string ids = Request.QueryString["ids"];
            string sum = Request.QueryString["sum"];
            string result = "";
            try
            {
                int beginRow = 4; int beginCol = 0;
                int endRow = 46; int endCol = 7;

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
                IRow row1 = sheet1.GetRow(1);
                ICell cellName = row1.GetCell(0);
                string biaotou = "姓名：" + name + "   身份：" + sf + "   身份证：" + sfz+"   单位：" + dept + "   性别："+sex;
                cellName.SetCellValue(biaotou);


                IRow rowend = sheet1.GetRow(endRow);
                ICell cellend2 = rowend.GetCell(4);
                string hhjjh = cellend2.ToString();
                ICell cellend = rowend.GetCell(5);
                cellend.SetCellValue(sum);
                string[] idArray = ids.Split(',');
                foreach (var item in idArray) {
                    int id = int.Parse(item);
                    IRow rowID = sheet1.GetRow(id);
                    rowID.ZeroHeight = true;//行的高度为0,隐藏 等同于删除行
                }
               
             
                sheet1.ForceFormulaRecalculation = true;
                
                 tick = "美年体检模板表" + DateTime.Now.ToString("yyMMddhhmmss"); ;
                 string vname = ".xls";
                 save_path = temp_path + "\\" + tick + vname;
                 var file = new FileStream(save_path, FileMode.Create);
                 hssfworkbook.Write(file);
                 file.Dispose();
                 file.Close();
                 
                
                result = "{\"state\":\"yes\",\"msg\":\"~/UploadFile/xls_files/" + tick + vname + "\"}";
               // result = "{\"state\":\"yes\",\"msg\":\"~/Excel/" + tick + vname + "\"}";
            }
            catch (Exception ex) {

                result = "{\"state\":\"no\",\"msg\":\"生成报表失败错误信息:" + ex.Message + "!\"}";
                throw (ex);
            }
            Response.Write(result);
            
        }

        #endregion



        #region 导出可利特
        public void PrintKltExcelFile()
        {
            string sf = Request.QueryString["sf"];
            string sfz = Request.QueryString["sfz"];
            string name = Request.QueryString["name"];
            string sex = Request.QueryString["sex"];
            string dept = Request.QueryString["dept"];
            string ids = Request.QueryString["ids"];
            string sum = Request.QueryString["sum"];

            string result = "";
            try
            {
                int beginRow = 4; int beginCol = 0;
                int endRow = 40; int endCol = 7;

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
                
                IRow row1 = sheet1.GetRow(1);
                ICell cellName = row1.GetCell(0);
                string biaotou = "姓名：" + name + "   身份：" + sf + "   身份证：" + sfz + "   单位：" + dept + "   性别：" + sex;
                cellName.SetCellValue(biaotou);

                IRow rowend = sheet1.GetRow(endRow);
                ICell cellend2 = rowend.GetCell(4);
                string hhjjh = cellend2.ToString();
                ICell cellend = rowend.GetCell(5);
                cellend.SetCellValue(sum);
                string[] idArray = ids.Split(',');
                foreach (var item in idArray)
                {
                    int id = int.Parse(item);
                    IRow rowID = sheet1.GetRow(id);
                    rowID.ZeroHeight = true;//行的高度为0,隐藏 等同于删除行
                }
               // IRow row9 = sheet1.GetRow(9);
                //  sheet1.RemoveRow(row9);//清除行数据
              //  ICell cell91 = row9.GetCell(1);
               // row9.ZeroHeight = true;//行的高度为0,隐藏 等同于删除行

                sheet1.ForceFormulaRecalculation = true;

                tick = "可利特体检模板表" + DateTime.Now.ToString("yyMMddhhmmss"); ;
                string vname = ".xls";
                save_path = temp_path + "\\" + tick + vname;
                var file = new FileStream(save_path, FileMode.Create);
                hssfworkbook.Write(file);
                file.Dispose();
                file.Close();
                
               
                result = "{\"state\":\"yes\",\"msg\":\"~/UploadFile/xls_files/" + tick + vname + "\"}";
                // result = "{\"state\":\"yes\",\"msg\":\"~/Excel/" + tick + vname + "\"}";
            }
            catch (Exception ex)
            {
                

                result = "{\"state\":\"no\",\"msg\":\"生成报表失败错误信息:" + ex.Message + "!\"}";
                throw (ex);
            }
            Response.Write(result);
            
        }
        #endregion

        #region 导出东华
        public void PrintDhExcelFile()
        {
            string sf = Request.QueryString["sf"];
            string sfz = Request.QueryString["sfz"];
            string name = Request.QueryString["name"];
            string sex = Request.QueryString["sex"];
            string dept = Request.QueryString["dept"];
            string ids = Request.QueryString["ids"];
            string sum = Request.QueryString["sum"];
            string result = "";
            try
            {
                int beginRow = 4; int beginCol = 0;
                int endRow = 84; int endCol = 7;

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
                IRow row1 = sheet1.GetRow(3);
                ICell cellName = row1.GetCell(0);
                string biaotou = "姓名：" + name + "   身份：" + sf + "   身份证：" + sfz + "   单位：" + dept + "   性别：" + sex;
                cellName.SetCellValue(biaotou);
                IRow rowend = sheet1.GetRow(84);
                ICell cellend2 = rowend.GetCell(4);
                string hhjjh = cellend2.ToString();
                ICell cellend = rowend.GetCell(5);
                cellend.SetCellValue(sum);
                string[] idArray = ids.Split(',');
                foreach (var item in idArray)
                {
                    int id = int.Parse(item);
                    IRow rowID = sheet1.GetRow(id);
                    rowID.ZeroHeight = true;//行的高度为0,隐藏 等同于删除行
                }
               // IRow row9 = sheet1.GetRow(9);
                //  sheet1.RemoveRow(row9);//清除行数据
               // ICell cell91 = row9.GetCell(1);
               // row9.ZeroHeight = true;//行的高度为0,隐藏 等同于删除行

                sheet1.ForceFormulaRecalculation = true;

                tick = "东华体检模板表" + DateTime.Now.ToString("yyMMddhhmmss"); ;
                string vname = ".xls";
                save_path = temp_path + "\\" + tick + vname;
                var file = new FileStream(save_path, FileMode.Create);
                hssfworkbook.Write(file);
                file.Dispose();
                file.Close();
                

                result = "{\"state\":\"yes\",\"msg\":\"~/UploadFile/xls_files/" + tick + vname + "\"}";
                // result = "{\"state\":\"yes\",\"msg\":\"~/Excel/" + tick + vname + "\"}";
            }
            catch (Exception ex)
            {

                result = "{\"state\":\"no\",\"msg\":\"生成报表失败错误信息:" + ex.Message + "!\"}";
                throw (ex);
            }
            Response.Write(result);
            
        }
        #endregion
        /// <summary>
        /// 根据路劲下载
        /// </summary>
        public void BuildExcelByUrl()
        {
            string url = Request.QueryString["url"];
            Response.Redirect(url, false);
        }
    }
}