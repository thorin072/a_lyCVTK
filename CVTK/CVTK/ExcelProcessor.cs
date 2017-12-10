using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
//адовая оптимизация
namespace CVTK
{
    /// <summary>
    /// Класс реализации для создания выходного файла Excel
    /// </summary>
    public static class ExcelProcessor
    {
        /// <summary>
        /// Вывод файла координат
        /// </summary>
        /// <param name="points">Лист контуров с соответствующим цетром масс для контура</param>
        public static void PointToFile(IEnumerable<RobotCommand.RobotPosition> points)
        {
            //****Создание экземпляра файла Excel****
            // Создаём экземпляр приложения
            Excel.Application excelApp = new Excel.Application();
            // Создаём экземпляр рабочий книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            //Внесение в книгу первых строк констант
            workSheet.Name = "data1";
            workSheet.Range["A2:D10000"].NumberFormat = "0.00E+00"; // установка формата ячеек
            workSheet.Cells[1, 1] = "t";
            workSheet.Cells[1, 2] = "x";
            workSheet.Cells[1, 3] = "y";
            workSheet.Cells[1, 4] = "z";
            workSheet.Cells[2, 1] = 0 * 1e-3;
            workSheet.Cells[2, 4] = 0;
            workSheet.Cells[2, 2] = 390;
            workSheet.Cells[2, 3] = 686.6;

            int COUNT = 3;

            foreach (var position in points)
            {
                workSheet.Cells[COUNT, 1] = position.time;
                workSheet.Cells[COUNT, 4] = position.z; //------для X = Z —--— 
                workSheet.Cells[COUNT, 2] = position.x;
                workSheet.Cells[COUNT, 3] = position.y;
                COUNT++;
            }

            //Обработка ошибки сохранения
            try
            {
                string outpath = Environment.CurrentDirectory + "/";
                workBook.SaveAs(@outpath + "end_position.xlsx");
                workBook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                workBook.Close();
                excelApp.Quit();
                System.Windows.Forms.MessageBox.Show(ex.Message + "Ошибка сохранения. Файл остался в прежнем состоянии. Ресурсы освобождены.");
            }
        }
    }
}
