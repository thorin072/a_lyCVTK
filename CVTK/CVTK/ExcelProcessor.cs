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
        public static void PointToFile(IList<CentroMass.ContourWithMass> points)
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
            workSheet.Range["A2:D10000"].NumberFormat = "0.00E+00"; // установка формата ячеек
            workSheet.Cells[1, 1] = "t";
            workSheet.Cells[1, 2] = "x";
            workSheet.Cells[1, 3] = "y";
            workSheet.Cells[1, 4] = "z";
            workSheet.Cells[2, 1] = 0*1e-3;
            workSheet.Cells[2, 4] = 0 * 1e-3;
            workSheet.Cells[2, 2] =points[0].Contr[0].Y;
            workSheet.Cells[2, 3] = 686.6;
            //****Файл инициализирован****н

            //****Заполнение данными 
            double time = 1 * 1e-3;
            int count = 3;
            double u = 686.6;
            for (int i = 0; i < points.Count; i++) // Коллекция I - ых контуров ( количество найденых 0..n)
            {
                for (int m = 0; m < points[i].Contr.Count; m++) // Обращение к элементам коллекции points[i].Contr 
                {
                    workSheet.Cells[count, 1] = time;
                    workSheet.Cells[count, 4] = points[i].Contr[m].X; //------для X = Z —--— 
                    workSheet.Cells[count, 2] = points[i].Contr[m].Y; //------для Y = X----—
                    workSheet.Cells[count, 3] = u - (0.00120148148148148 * Math.Pow((1000 * time), 2))/ 2;
                    if ((points[i].Contr[m].X == points[i].Mass.X) && (points[i].Contr[m].Y == points[i].Mass.Y))
                    {
                        workSheet.Cells[count, 3] = 0; // проверка
                    }
                    count++;
                    time = 0.001 + time;
                }
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
