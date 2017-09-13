using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using TaskManage.Utils.Db;

namespace TaskManage.Utils.Excel
{
    public enum DataType
    {
        String,
        Int,
        Double,
        Datetime
    }
    public class ExcelHelper : IDisposable
    {
        private readonly string fileName; //文件名
        private bool disposed;
        private FileStream fs;
        private IWorkbook workbook;

        public ExcelHelper()
        {
        }

        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <param name="ignoreColumnIndex">忽略需要转换的列，解决科学计数法</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten, int[] ignoreColumnIndex)
        {
            var i = 0;
            var j = 0;
            var count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten) //写入DataTable的列名
                {
                    var row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }
                var rValue = string.Empty;
                double doubleValue = 0;
                ICell cell = null;
                for (i = 0; i < data.Rows.Count; ++i)
                {
                    var row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        //解决数字Excel显示问题
                        rValue = data.Rows[i][j].ToString();
                        cell = row.CreateCell(j);
                        if (double.TryParse(rValue, out doubleValue) && Array.IndexOf(ignoreColumnIndex, j) == -1)
                        {
                            cell.SetCellValue(doubleValue);
                        }
                        else
                        {
                            cell.SetCellValue(Convert.ToString(rValue));
                        }
                        // row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        public static HSSFWorkbook ExportStream(HSSFWorkbook workbook, HSSFSheet sheet, DataTable data,
            bool isColumnWritten, int[] ignoreColumnIndex)
        {
            try
            {
                int i;
                int j;
                int count;
                if (isColumnWritten) //写入DataTable的列名
                {
                    var row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }
                for (i = 0; i < data.Rows.Count; ++i)
                {
                    var row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        //解决数字Excel显示问题
                        var rValue = data.Rows[i][j].ToString();
                        var cell = row.CreateCell(j);
                        double doubleValue;
                        if (double.TryParse(rValue, out doubleValue) && Array.IndexOf(ignoreColumnIndex, j) == -1)
                        {
                            cell.SetCellValue(doubleValue);
                        }
                        else
                        {
                            cell.SetCellValue(Convert.ToString(rValue));
                        }
                    }
                    ++count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return workbook;
        }

        /// <summary>
        ///     将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            var data = new DataTable();
            var startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName) ?? workbook.GetSheetAt(0);
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    var firstRow = sheet.GetRow(10);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            var cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                var cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    var column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = 10; //sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    var rowCount = sheet.LastRowNum;
                    for (var i = startRow; i <= rowCount; ++i)
                    {
                        var row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        var dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        ///     將DataSet 匯出Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="exportname"></param>
        public static string Export(DataSet ds, string exportname)
        {
            var workbook = new HSSFWorkbook();
            workbook = ExportStream(ds, exportname);
            return ExportExcel(workbook, exportname);
        }

        /// <summary>
        ///     將DataSet 匯出Excel 多個DataTable 轉換成多個Excel 工作薄
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="exportname"></param>
        private static HSSFWorkbook ExportStream(DataSet ds, string exportname)
        {
            var workbook = new HSSFWorkbook();
            var ms = new MemoryStream();
            var count = 0;
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        count++;
                        //創建新增
                        var sheet = (HSSFSheet) workbook.CreateSheet(exportname + count);
                        var headerRow = (HSSFRow) sheet.CreateRow(0);
                        sheet.DefaultColumnWidth = 11;
                        //表頭
                        var c = 0;
                        foreach (DataColumn column in dt.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            c++;
                        }
                        //表身
                        var r = 1;
                        var rValue = string.Empty;
                        double doutValue = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            var bodyRow = (HSSFRow) sheet.CreateRow(r);

                            foreach (DataColumn column in dt.Columns)
                            {
                                rValue = row[column.ColumnName].ToString();

                                if (double.TryParse(rValue, out doutValue))
                                {
                                    if (column.ColumnName == "OrderNo" || column.ColumnName == "ERPPartNo" ||
                                        column.ColumnName == "InvoiceNo" ||
                                        column.ColumnName == "SupplierInvoiceNo" ||
                                        column.ColumnName == "DeclarationForm")
                                    {
                                        //針對EmbestShippingRpt 科學計數法顯示問題
                                        bodyRow.CreateCell(column.Ordinal).SetCellValue(rValue);
                                    }
                                    else
                                    {
                                        bodyRow.CreateCell(column.Ordinal).SetCellValue(doutValue);
                                    }
                                }
                                else
                                {
                                    bodyRow.CreateCell(column.Ordinal).SetCellValue(rValue);
                                }
                            }
                            r++;
                        }
                    }
                }
            }
            return workbook;
        }

        /// <summary>
        ///     通過數據流，以及文件名，匯出excle檔
        /// </summary>
        public static string ExportExcel(HSSFWorkbook workbook, string exportname)
        {
            var strFilename = AppDomain.CurrentDomain.BaseDirectory;
            strFilename = strFilename + "File";
            var filearr2 = Directory.GetFiles(strFilename, "*" + exportname + "*");
            for (var i = 0; i < filearr2.Length; i++)
            {
                try
                {
                    File.Delete(filearr2[i]);
                }
                catch (Exception ex)
                {
                }
            }

            strFilename = strFilename + "\\" + exportname + ".xls";

            using (var stream = new FileStream(@strFilename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
                workbook = null;
                stream.Close();
                stream.Dispose();
            }

            return strFilename;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }

        public static string GetFileName(string exportname)
        {
            var strFilename = AppDomain.CurrentDomain.BaseDirectory;
            strFilename = strFilename + "File";
            var filearr = Directory.GetFiles(strFilename, "*" + exportname + "*");
            for (var i = 0; i < filearr.Length; i++)
            {
                try
                {
                    File.Delete(filearr[i]);
                }
                catch (Exception ex)
                {
                }
            }
            strFilename = strFilename + "\\" + exportname +  ".xls";
            return strFilename;
        }

        /// <summary>
        /// 將excel數據導入到DataTable,第一行為標題行,不導入
        /// </summary>
        /// <param name="path">excel路徑</param>
        /// <param name="actiontype">獲取表結構，在存儲過程Web_GetImportSchema中</param>
        /// <returns>不成功返回null</returns>
        public DataTable ToDataTable(string path, string actiontype)
        {
            if (File.Exists(path))
            {
                DataTable dt = GetTableSchema(actiontype);

                if (dt == null)
                    return null;
                Dictionary<int, DataType> dic = GetDataTableColType(dt);
                int cols = dic.Count;

                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    IWorkbook book = null;
                    ISheet sheet = null;
                    book = WorkbookFactory.Create(fs);
                    sheet = book.GetSheetAt(0);
                    if (sheet != null && sheet.LastRowNum > 0 && sheet.FirstRowNum >= 0 && sheet.LastRowNum != sheet.FirstRowNum)
                    {
                        int begin = sheet.FirstRowNum + 1, last = sheet.LastRowNum + 1;
                        while (begin < last)
                        {
                            NPOI.SS.UserModel.IRow row = sheet.GetRow(begin);
                            if (row == null)
                                break;
                            DataRow dr = dt.NewRow();

                            for (int i = 0; i < cols; i++)
                            {
                                AddColValue(dr, row.GetCell(i), i, dic[i]);
                            }
                           
                            dt.Rows.Add(dr);
                            begin += 1;
                        }
                    }
                }
                return dt;
            }
            return null;
        }
        private DataTable GetTableSchema(string actiontype)
        {
            var db = new DBHelper("WMSConn");
            var cmd = db.CreateCommand("Web_GetImportSchema", true);
            cmd.Parameters.Add(new SqlParameter("ActionType", actiontype));
            var dt = db.ExecuteDataTable(cmd);
            return dt;
        }       
        private void AddColValue(DataRow dr, NPOI.SS.UserModel.ICell cell, int col, DataType type)
        {
            if (cell == null)
            {
                dr[col] = DBNull.Value;
                return;
            }
            switch (cell.CellType)
            {
                //case NPOI.SS.UserModel.CellType.STRING:
                case NPOI.SS.UserModel.CellType.String:
                    string v = cell.StringCellValue.Trim();

                    switch (type)
                    {
                        case DataType.String:
                            dr[col] = v;
                            break;
                        case DataType.Int:
                            int iv;
                            if (int.TryParse(v, out iv))
                            {
                                dr[col] = v;
                            }
                            else
                                dr[col] = DBNull.Value;
                            break;
                        case DataType.Double:
                            double dvv;
                            if (double.TryParse(v, out dvv))
                            {
                                dr[col] = v;
                            }
                            else
                                dr[col] = DBNull.Value;
                            break;
                        case DataType.Datetime:
                            DateTime dt;
                            if (DateTime.TryParse(v, out dt))
                            {
                                dr[col] = v;
                            }
                            else
                                dr[col] = DBNull.Value;
                            break;
                    }

                    break;
                case NPOI.SS.UserModel.CellType.Numeric:
                    double dv = cell.NumericCellValue;
                    switch (type)
                    {
                        case DataType.Double:
                            dr[col] = dv;
                            break;
                        case DataType.Int:
                            dr[col] = (int)dv;
                            break;
                        case DataType.Datetime:
                            dr[col] = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                            break;
                        case DataType.String:
                            dr[col] = dv.ToString("R8");
                            break;

                    }
                    break;
                default:
                    dr[col] = DBNull.Value;
                    break;
            }


        }
        private Dictionary<int, DataType> GetDataTableColType(DataTable dt)
        {
            Dictionary<int, DataType> dic = new Dictionary<int, DataType>(dt.Columns.Count);
            int i = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                switch (dc.DataType.Name)
                {
                    case "String":
                        dic.Add(i, DataType.String);
                        break;
                    case "Int32":
                        dic.Add(i, DataType.Int);
                        break;
                    case "Decimal":
                    case "Double":
                        dic.Add(i, DataType.Double);
                        break;
                    case "DateTime":
                        dic.Add(i, DataType.Datetime);
                        break;
                    default:
                        dic.Add(i, DataType.String);
                        break;
                }

                i += 1;
            }
            return dic;
        }
    }
}