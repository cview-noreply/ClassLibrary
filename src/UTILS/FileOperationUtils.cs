using ExcelDataReader;
using $safeprojectname$.Const;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace $safeprojectname$.Utils
{
    /// <summary>
    /// ファイル操作クラス
    /// </summary>
    internal class FileOperationUtils
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// インプット

        /// <summary>
        /// テキストファイルのデータをDataTableに格納
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="delimiter">区切り文字</param>
        /// <param name="firstRow">データ開始行</param>
        /// <param name="header">ヘッダー有無</param>
        /// <param name="headerDup">ヘッダー名重複有無</param>
        public static DataTable TextToDataTable(string filePath, char delimiter, int firstRow = 2, bool header = true, bool headerDup = false)
        {
            try
            {
                DataTable dt = new DataTable();
                int headerRow = header ? firstRow - 1 : firstRow;

                //文字コード判別
                byte[] bs = File.ReadAllBytes(filePath);
                Encoding enc = DetectEncoding(bs);

                using (StreamReader sr = new StreamReader(filePath, enc))
                {
                    int rowNo = 0;
                    while (sr.Peek() != -1)
                    {
                        rowNo++;
                        string[] vals = sr.ReadLine().Split(delimiter);

                        //ヘッダーが1行目でない場合、上部の不要な行を飛ばす
                        if (headerRow != 1)
                        {
                            if (rowNo < headerRow) continue;
                        }

                        //列追加
                        if (dt.Columns.Count == 0)
                        {
                            for (int i = 0; i < vals.Length; i++)
                            {
                                dt.Columns.Add();
                            }
                        }

                        if (vals.Length > dt.Columns.Count) throw new Exception(Messages.ERR_FILE_CLM_CNT + filePath);

                        //行追加
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < vals.Length; i++)
                        {
                            dr[i] = vals[i].Trim();
                        }
                        dt.Rows.Add(dr);
                    }
                }

                if (header && !headerDup)
                {
                    dt = HeaderSet(dt);

                    //末尾の不要な列を削除
                    for (int i = dt.Columns.Count - 1; i >= 0; i--)
                    {
                        if (Regex.IsMatch(dt.Columns[i].ColumnName, "^Column[0-9]+$")) dt.Columns.RemoveAt(i);
                        else break;
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 文字コードを判定（Shift-JIS or UTF8）
        /// </summary>
        /// <param name="bytes">バイト配列</param>
        private static Encoding DetectEncoding(byte[] bytes)
        {
            bool judgeSecondByte = false; //次回の判定がShiftJISの2バイト目の判定かどうか

            //バイト配列がSiftJISに一致するかチェック
            for (int i = 0; i < bytes.Length; i++)
            {
                byte b = bytes[i];

                if (!judgeSecondByte)
                {
                    if (b == 0x0D || b == 0x0A || b == 0x09 || (0x20 <= b && b <= 0x7E)) { }     //CR, LF, tab, 半角カナ除く1バイト
                    else if ((0x81 <= b && b <= 0x9F) || (0xE0 <= b && b <= 0xFC))  //ShiftJISの2バイト文字の1バイト目の場合、2バイト目の判定を行う
                    {
                        judgeSecondByte = true;
                    }
                    else if ((0xA1 <= b && b <= 0xDF) || (0x00 <= b && b <= 0x7F)) { }    //ShiftJISの1バイト文字(半角カナ含む)
                    else
                    {
                        //ShiftJISでない
                        return Encoding.UTF8;
                    }
                }
                else
                {
                    //ShiftJISの2バイト文字の2バイト目の場合
                    if ((0x40 <= b && b <= 0x7E) || (0x80 <= b && b <= 0xFC))
                    {
                        judgeSecondByte = false;
                    }
                    else
                    {
                        //ShiftJISでない
                        return Encoding.UTF8;
                    }
                }
            }

            return Encoding.GetEncoding("Shift_JIS");
        }

        /// <summary>
        /// Excel(.xlsx/.xls)のデータをDataTableに格納
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="shName">シート名</param>
        /// <param name="firstRow">データ開始行</param>
        /// <param name="header">ヘッダー有無</param>
        /// <param name="headerDup">ヘッダー名重複有無</param>
        public static DataTable ExcelToDataTable(string filePath, string shName = "", int firstRow = 2, bool header = true, bool headerDup = false)
        {
            try
            {
                DataSet result = null;
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);
                    result = excelReader.AsDataSet();
                    excelReader.Close();
                }

                DataTable dt = shName != "" ? result.Tables[shName] : result.Tables[0];
                if (dt == null)
                {
                    dt = new DataTable();
                    return dt;
                }

                //上部の不要な行を削除
                int headerRow = header ? firstRow - 1 : firstRow;
                for (int i = headerRow - 2; i >= 0; i--)
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }

                if (header && !headerDup)
                {
                    dt = HeaderSet(dt);

                    //末尾の不要な列を削除
                    for (int i = dt.Columns.Count - 1; i >= 0; i--)
                    {
                        if (Regex.IsMatch(dt.Columns[i].ColumnName, "^Column[0-9]+$")) dt.Columns.RemoveAt(i);
                        else break;
                    }
                }

                //ExcelDataReaderは書式「ユーザー定義」の場合ColumnTypeがobjectになるため、stringに変更
                dt = DataTypeChange(dt);

                return dt;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 列の型を変換
        /// </summary>
        public static DataTable DataTypeChange(DataTable dt)
        {
            DataTable changedDt = dt.Clone();

            changedDt.Columns[0].DataType = typeof(string);

            foreach (DataRow dr in dt.Rows)
            {
                changedDt.ImportRow(dr);
            }

            return changedDt;
        }

        /// <summary>
        /// DataTableの1行目の値をヘッダー名にする
        /// </summary>
        public static DataTable HeaderSet(DataTable dt)
        {
            object[] rowdata = dt.Rows[0].ItemArray;

            for (int i = 0; i < rowdata.Length; i++)
            {
                string header = rowdata[i].ToString();
                if (header != "") dt.Columns[i].ColumnName = header.Replace("\n", "");
            }
            dt.Rows.RemoveAt(0);

            return dt;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// アウトプット

        /// <summary>
        /// DataTableをファイル(.xlsx/.xls/.csv/.tsv)に出力
        /// </summary>
        /// <param name="filePath">出力ファイルパス</param>
        /// <param name="dt">出力データ</param>
        /// <param name="headerRow">ヘッダー行</param>
        /// <param name="delimiter">区切り文字(Excel以外のとき必要であれば)</param>
        /// <param name="color">ヘッダーカラー(Excelのとき)</param>
        public static bool DataTableToFile(string filePath, DataTable dt, int headerRow = 1, string delimiter = "", string color = "")
        {
            Excel.Application app = null;
            Excel.Workbooks books = null;
            Excel.Workbook book = null;
            Excel.Sheets sheets = null;
            Excel.Worksheet sheet = null;
            Excel.Range range = null;
            Excel.Range startRange = null;
            Excel.Range endRange = null;
            Excel.Range headerRange = null;

            try
            {
                //同名ファイルがある場合削除
                if (ValidationUtils.IsFileExists(filePath)) File.Delete(filePath);

                app = CreateExcelApplication();
                books = app.Workbooks;
                book = books.Add();
                sheets = book.Worksheets;
                sheet = sheets[1];
                range = sheet.Cells;

                SetColumnFmt(sheet, dt);

                object[,] dtVals = DataTableToArray(dt, true);

                //出力対象Rangeの各セルに値を出力
                startRange = range[headerRow, 1];
                endRange = range[headerRow - 1 + dtVals.GetLength(0), dtVals.GetLength(1)];
                sheet.Range[startRange, endRange].Value2 = dtVals;

                string extension = Path.GetExtension(filePath);
                if (extension.Contains("xls") && color != "")
                {
                    //ヘッダーの背景色を設定
                    headerRange = sheet.Range[range[headerRow, 1], range[headerRow, dt.Columns.Count]];
                    headerRange.Interior.Color = ColorTranslator.FromHtml(color);
                }

                Excel.XlFileFormat fileFmt = Excel.XlFileFormat.xlWorkbookDefault;
                if (extension == ".xls") fileFmt = Excel.XlFileFormat.xlExcel8;
                else if (extension == ".csv" || delimiter == ",") fileFmt = Excel.XlFileFormat.xlCSV;
                else if (extension == ".tsv" || delimiter == "\t") fileFmt = Excel.XlFileFormat.xlCurrentPlatformText;

                book.SaveAs(Path.GetFullPath(filePath), fileFmt);

                return true;
            }
            catch (Exception ex)
            {
                LogUtils.ExportErrLog(ex);
                return false;
            }
            finally
            {
                book?.Close(false);
                app?.Quit();
                EndProcess(headerRange, endRange, startRange, range, sheet, sheets, book, books, app);
            }
        }

        /// <summary>
        /// ExcelApplication初期化
        /// </summary>
        private static Excel.Application CreateExcelApplication()
        {
            var app = new Excel.Application
            {
                Visible = false,
                DisplayAlerts = false
            };
            return app;
        }

        /// <summary>
        /// DataTableのDataTypeにあわせて列毎に書式を設定
        /// </summary>
        private static void SetColumnFmt(Excel.Worksheet sheet, DataTable dt)
        {
            Excel.Range range = null;
            try
            {
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    //書式設定
                    if (!dt.Columns[i].DataType.Name.ToString().Contains("Int"))
                    {
                        range = sheet.Columns[i + 1];
                        range.NumberFormatLocal = "@"; //文字列
                    }
                }
            }
            finally
            {
                if (range != null) Marshal.ReleaseComObject(range);
            }
        }

        /// <summary>
        /// 出力するDataTableの項目名と値を二次元配列に格納
        /// </summary>
        public static object[,] DataTableToArray(DataTable dt, bool header)
        {
            object[,] dtVals;
            int headerRow = 0;
            if (header)
            {
                dtVals = new object[dt.Rows.Count + 1, dt.Columns.Count];
                headerRow = 1;

                //列
                for (int clmNo = 0; clmNo < dt.Columns.Count; clmNo++)
                {
                    dtVals[0, clmNo] = dt.Columns[clmNo].ColumnName;
                }
            }
            else dtVals = new object[dt.Rows.Count, dt.Columns.Count];

            //行
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                for (int clmNo = 0; clmNo < dt.Columns.Count; clmNo++)
                {
                    dtVals[rowNo + headerRow, clmNo] = dt.Rows[rowNo][clmNo].ToString();
                }
            }

            return dtVals;
        }

        /// <summary>
        /// COMオブジェクトの解放
        /// </summary>
        /// <param name="comObjects">COMオブジェクト</param>
        private static void EndProcess(params object[] comObjects)
        {
            try
            {
                foreach (var comObject in comObjects)
                {
                    if (comObject != null) Marshal.ReleaseComObject(comObject);
                }

                //Excelのバックグラウンドプロセスを直接殺す
                foreach (var p in Process.GetProcessesByName("EXCEL"))
                {
                    if (p.MainWindowTitle == "") p.Kill();
                }
            }
            catch
            {
                //何もしない
            }
        }

    }
}
