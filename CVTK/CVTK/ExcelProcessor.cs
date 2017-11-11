using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace CVTK
{
    public static class ExcelProcessor
    {

        public static void Pointtofile(int[] x, int[] y)
        {
            // Создаём экземпляр приложения
            Excel.Application excelApp = new Excel.Application();
            // Создаём экземпляр рабочий книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            for (int i = 0; i <= x.Length - 1; i++)
            {
                workSheet.Cells[i + 1, 1] = x[i];
            }
            for (int i = 0; i <= y.Length - 1; i++)
            {
                workSheet.Cells[i + 1, 2] = y[i];
            }
            string outpath = Environment.CurrentDirectory+ "/";
            workBook.SaveAs(@outpath + "end_points.xlsx");
            workBook.Close();
            excelApp.Quit();
        }
    }
}
