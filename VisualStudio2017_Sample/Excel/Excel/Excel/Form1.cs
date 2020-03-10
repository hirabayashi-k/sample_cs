using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel
{
    public partial class Form1 : Form
    {
        // 縦　列 Column
        // 横　行 Row

        // postion X 
        int posColumnX = 1;
        int posRowX = 3;

        // postion Y 
        int posColumnY = 2;
        int posRowY = 3;

        // Retry
        int RetryColumn = 3;
        int RetryRow = 2;

        // RetryInterval
        int RetryIntervalColumn = 4;
        int RetryIntervalRow = 2;

        // Inspection board
        int InspectionBoardColumn = 6;
        int InspectionBoardRow = 2;

        // Script Start
        int ScriptStartColumn = 9;
        int ScriptStartRow = 4;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenExcelBt_Click(object sender, EventArgs e)
        {
            try
            {
                // 2重Open対策
                try
                {
                    using (var fs = File.OpenWrite(System.IO.Path.GetFullPath(@"./1Y13_TEST.xlsx")))
                    {

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Excelが開かれている。");
                    return;
                }


                // EXCEL操作用オブジェクト
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Microsoft.Office.Interop.Excel.Workbooks xlBooks = null;
                Microsoft.Office.Interop.Excel.Workbook xlBook = null;
                Microsoft.Office.Interop.Excel.Sheets xlSheets = null;
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = null;

                // EXCELアプリケーション生成
                xlApp = new Microsoft.Office.Interop.Excel.Application();

                // ◆操作対象のEXCELブックを開く◆
                // OPENメソッド
                xlBooks = xlApp.Workbooks;
                xlBook = xlBooks.Open(System.IO.Path.GetFullPath(@"./1Y13_TEST.xlsx"));

                // シートを選択する
                xlSheets = xlBook.Worksheets;
                xlSheet = xlSheets[1] as Microsoft.Office.Interop.Excel.Worksheet; // 1シート目を操作対象に設定する

                // 表示
                xlApp.Visible = true;

                // ■■■以下、COMオブジェクトの解放■■■

                // SHEET解放
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheets);

                // BOOK解放
                //XLBOOK.CLOSE();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

                // EXCELアプリケーションを解放
                //XLAPP.QUIT();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Excel操作用オブジェクト
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Microsoft.Office.Interop.Excel.Workbooks xlBooks = null;
                Microsoft.Office.Interop.Excel.Workbook xlBook = null;
                Microsoft.Office.Interop.Excel.Sheets xlSheets = null;
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = null;

                // Excelアプリケーション生成
                xlApp = new Microsoft.Office.Interop.Excel.Application();

                // 既存のBookを開く
                xlBooks = xlApp.Workbooks;
                xlBook = xlBooks.Open(System.IO.Path.GetFullPath(@"./1Y13_TEST.xlsx"), Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, "takt3277", Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing);

                // シートを選択する
                xlSheets = xlBook.Worksheets;
                // 1シート目を操作対象に設定する
                // ※Worksheets[n]はオブジェクト型を返すため、Worksheet型にキャスト
                xlSheet = xlSheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

                // 表示
                xlApp.Visible = false;

                // セルのオブジェクト
                Microsoft.Office.Interop.Excel.Range xlRange = null;
                Microsoft.Office.Interop.Excel.Range xlCells = null;




                List<ScriptData> scriptlist = new List<ScriptData>();

                // A1セルを指定　縦　横
                int x, y,count;
                x = ScriptStartRow;
                y = ScriptStartColumn;
                count = 0;
                while (true)
                {
                    ScriptData script = new ScriptData();

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x] as Microsoft.Office.Interop.Excel.Range;

                    if (xlRange.Value == null)
                    {
                        break;
                    }
                    string data = xlRange.Value.ToString();

                    // テスト名
                    script.testName = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 1] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.comment = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 2] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.direction1 = data.ToString();

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 3] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.direction2 = data.ToString();

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 4] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.direction3 = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 5] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.direction4 = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 6] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.direction5 = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 7] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.command = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 8] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.gain = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 9] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.Lower = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 10] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.Upper = data;

                    xlCells = xlSheet.Cells;
                    xlRange = xlCells[y + count, x + 11] as Microsoft.Office.Interop.Excel.Range;
                    data = xlRange.Value.ToString();
                    script.btciresult = data;

                    scriptlist.Add(script);

                    count++;
                }


                // A1セルを指定 縦　横
                xlCells = xlSheet.Cells;
                xlRange = xlCells[1, 1] as Microsoft.Office.Interop.Excel.Range;

                // ◆現在の値を表示◆
                MessageBox.Show(xlRange.Value);

                // ◆値を設定◆
                //xlRange.Value = "変更後の値";

                // 変更後の値を表示
                //MessageBox.Show(xlRange.Value);

                // ■■■以下、COMオブジェクトの解放■■■

                // cell解放
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlCells);

                // Sheet解放
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheets);

                // Book解放
                //xlBook.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);

                // Excelアプリケーションを解放
                //xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


    public class ScriptData
    {
        public string testName { get; set; } = "";
        public string comment { get; set; } = "" ;
        public string direction1 { get; set; } = "";
        public string direction2 { get; set; } = "";
        public string direction3 { get; set; } = "";
        public string direction4 { get; set; } = "";
        public string direction5 { get; set; } = "";
        public string command { get; set; } = "";
        public string gain { get; set; } = "";
        public string Lower { get; set; } = "";
        public string Upper { get; set; } = "";
        public  string btciresult { get; set; } = "";

    }
}
