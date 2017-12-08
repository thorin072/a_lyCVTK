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
        public static void PointToFile(IList<CentroMass.ContourWithMass> points, int timeend)
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
            double TIME = 1 * 1e-3;
            int COUNT = 3;

            //Интерпритация команды опускания пера манипулятора 
            var STRUCT = RobotCommand.Start(ref TIME, 687);
            for (int i = 0; i < STRUCT.Count; i++)
            {
                workSheet.Cells[COUNT, 1] = STRUCT[i].time;
                workSheet.Cells[COUNT, 4] = STRUCT[i].z;
                workSheet.Cells[COUNT, 2] = STRUCT[i].x;
                workSheet.Cells[COUNT, 3] = STRUCT[i].y;
                COUNT++;
            }
            STRUCT = null;

            STRUCT = RobotCommand.ToTheContourPoint(ref TIME, 202, -52, 500.000025, points[0].Contr[0].X - 100, points[0].Contr[0].Y + 500);
            for (int i = 0; i < STRUCT.Count; i++)
            {
                workSheet.Cells[COUNT, 1] = STRUCT[i].time;
                workSheet.Cells[COUNT, 4] = STRUCT[i].z;
                workSheet.Cells[COUNT, 2] = STRUCT[i].x;
                workSheet.Cells[COUNT, 3] = STRUCT[i].y;
                COUNT++;
            }
            STRUCT = null;


            bool flagContourType;// флаг для поднятия

            for (int i = 0; i < points.Count; i++) // Коллекция I - ых контуров ( количество найденых 0..n)
            {
                for (int m = 0; m < points[i].Contr.Count; m++) // Обращение к элементам коллекции points[i].Contr 
                {
                    workSheet.Cells[COUNT, 1] = TIME;
                    workSheet.Cells[COUNT, 4] = points[i].Contr[m].X - 100;
                    workSheet.Cells[COUNT, 2] = points[i].Contr[m].Y + 500.000025;
                    workSheet.Cells[COUNT, 3] = 200;
                    COUNT++;
                    TIME = 0.001 + TIME;
                    flagContourType = true; // идем по контуру
                }

                if (i == points.Count - 1)
                {
                    break;
                }
                flagContourType = false; // переход

                if (flagContourType == false)
                {
                    STRUCT = RobotCommand.PenUp(ref TIME, 200, points[i].Contr[points[i].Contr.Count - 1].X - 100, points[i].Contr[points[i].Contr.Count - 1].Y + 500.000025, 1 * 1e-3);
                    for (int j = 0; j < STRUCT.Count; j++)
                    {
                        workSheet.Cells[COUNT, 1] = STRUCT[j].time;
                        workSheet.Cells[COUNT, 4] = STRUCT[j].z;
                        workSheet.Cells[COUNT, 2] = STRUCT[j].x;
                        workSheet.Cells[COUNT, 3] = STRUCT[j].y;
                        COUNT++;
                    }
                    STRUCT = null;

                    STRUCT = RobotCommand.PenPause(ref TIME, 215, points[i].Contr[points[i].Contr.Count - 1].X - 100, points[i].Contr[points[i].Contr.Count - 1].Y + 500.000025, points[i + 1].Contr[points[i + 1].Contr.Count - 1].X - 100, points[i + 1].Contr[points[i + 1].Contr.Count - 1].Y + 500.000025);

                    for (int j = 0; j < STRUCT.Count; j++)
                    {
                        workSheet.Cells[COUNT, 1] = STRUCT[j].time;
                        workSheet.Cells[COUNT, 4] = STRUCT[j].z;
                        workSheet.Cells[COUNT, 2] = STRUCT[j].x;
                        workSheet.Cells[COUNT, 3] = STRUCT[j].y;
                        COUNT++;
                    }
                    STRUCT = null;

                    STRUCT = RobotCommand.PenDown(ref TIME, 215, points[i + 1].Contr[points[i + 1].Contr.Count - 1].X - 100, points[i + 1].Contr[points[i + 1].Contr.Count - 1].Y + 500.000025, 1 * 1e-3);
                    for (int j = 0; j < STRUCT.Count; j++)
                    {
                        workSheet.Cells[COUNT, 1] = STRUCT[j].time;
                        workSheet.Cells[COUNT, 4] = STRUCT[j].z;
                        workSheet.Cells[COUNT, 2] = STRUCT[j].x;
                        workSheet.Cells[COUNT, 3] = STRUCT[j].y;
                        COUNT++;
                    }
                    STRUCT = null;
                }
            }

            STRUCT = RobotCommand.Stop(ref TIME, timeend, points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].X - 100, points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].Y + 500.000025, 200);
            for (int j = 0; j < STRUCT.Count; j++)
            {
                workSheet.Cells[COUNT, 1] = STRUCT[j].time;
                workSheet.Cells[COUNT, 4] = STRUCT[j].z;
                workSheet.Cells[COUNT, 2] = STRUCT[j].x;
                workSheet.Cells[COUNT, 3] = STRUCT[j].y;
                COUNT++;
            }
            
            //Обработка ошибки сохранения
            try
            {
                string outpath = Environment.CurrentDirectory + "/";
                workBook.SaveAs(@outpath + "end_position1.xlsx");
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
        private static Tuple<double, double, double> Coefficients(double x1, double y1, double x2, double y2)
        {
            //(y1-y2)*x+(x2-x1)*y+(x1y2-x2y1) = 0
            //Ax+By+C=0
            var A = (y1 - y2);
            var B = (x2 - x1);
            var C = (x1 * y2 - x2 * y1);
            return Tuple.Create(A, B, C);
        }
    }
}
