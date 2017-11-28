using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace CVTK
{
    /// <summary>
    /// Класс реализации для создания выходного файла Excel
    /// </summary>
    public static class ExcelProcessor
    {

        public static void PointToFile(float[] x, float[] y, float[] xT, float[] yT)
        {
            // Создаём экземпляр приложения
            Excel.Application excelApp = new Excel.Application();
            // Создаём экземпляр рабочий книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            workSheet.Cells[1, 1] = "t";
            workSheet.Cells[1, 2] = "x";
            workSheet.Cells[1, 3] = "y-const";
            workSheet.Cells[1, 4] = "z";
            workSheet.Cells[2, 1] = 0*1e-3;
            //---time---
            double time = 1*1e-3;
            for (int i = 2; i <= x.Length - 1; i++) 
            {
                workSheet.Cells[i + 1, 1] = time;
                time =0.001+time ;
            }
            //------для X = Z ------
            for (int i = 1; i <= x.Length-1 ; i++) 
            {
                workSheet.Cells[i + 1, 4] = x[i];//*1e+1;
            }
            //------для Y = X------
            for (int i = 1; i <= y.Length-1; i++) 
            {
                workSheet.Cells[i + 1, 2] = y[i];//* 1e+1;
            }

            workSheet.Cells[1, 6] = "XT";
            workSheet.Cells[1,7] = "YT";
            //------для XT = Z ------
            for (int i = 1; i <= xT.Length - 1; i++)
            {
                workSheet.Cells[i + 1, 6] = xT[i];// * 1e+1;
            }
            //------для YT = X------
            for (int i = 1; i <= yT.Length - 1; i++)
            {
                workSheet.Cells[i + 1, 7] = yT[i];// * 1e+1;
            }
            // для момента когда x - const

            //for (int i = 1; i <= y.Length - 1; i++)
            //{
            //    for (int j = 1; j <= yT.Length - 1; j++)
            //    {
            //        if (y[i]
            //    }
            //    workSheet.Cells[i + 1, 4] = x[i] * 1e+1;
            //}

            try
            {
                string outpath = Environment.CurrentDirectory + "/";
                workBook.SaveAs(@outpath + "end_points.xlsx");
                workBook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                workBook.Close();
                excelApp.Quit();
                System.Windows.Forms.MessageBox.Show(ex.Message);
                System.Windows.Forms.MessageBox.Show("Ошибка сохранения. Файл остался в прежнем состоянии. Ресурсы освобождены.");
            }
        }
    }
}
