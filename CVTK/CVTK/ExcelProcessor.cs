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
            //****Файл инициализирован****


            //****Заполнение данными 
            double time = 1 * 1e-3;
            int count = 0, m = 0, i = 0, counttime = 3;
            double u = 687, k = 687;

            //опускает перо
            while (k > 202)
            {
                workSheet.Cells[counttime, 1] = time;
                workSheet.Cells[counttime, 4] = 0 - (0.000123457 * Math.Pow(time * 1000, 2)) / 2; //------для X = Z —--— 
                workSheet.Cells[counttime, 2] = 390 + (0.000271605 * Math.Pow(time * 1000, 2)) / 2; //------для Y = X----—
                k = u - (0.00120148148148148 * Math.Pow((1000 * time), 2)) / 2;
                workSheet.Cells[counttime, 3] = k;
                time = 0.001 + time;
                counttime++;
                k--;
            }

            //переещение от точки старта до точки контура 
            var Xdx = -52.0000850000001; // точка старта для манипулятора
            var Ydx = 500.000025;

            var oneX1 = -52; ; // X точки поднятия
            var oneY1 = 500.000025; // Y точки поднятия  
            var firstX1 = points[0].Contr[0].X - 100; // X точки опускания ///БАГ
            var firstY1 = points[0].Contr[0].Y; // Y точки опускания ////БАГ
            var coef1 = Coefficients(oneX1, oneY1, firstX1, firstY1); // коэффициенты для прямой перехода



            for (int h = oneX1; h < firstX1; h++)
            {
                var Yzn = ((-coef1.Item1 * h) - coef1.Item3) / coef1.Item2;
                workSheet.Cells[counttime, 1] = time;
                workSheet.Cells[counttime, 4] = h; //------для X = Z —--— 
                workSheet.Cells[counttime, 2] = Yzn; //------для Y = X----—
                workSheet.Cells[counttime, 3] = k;
                time = 0.001 + time;
                counttime++;
                Xdx--;
                Ydx++;
            }
            count = counttime;


            var Y = 500.000025;

            bool flagContourType;// флаг для поднятия

            while (i < points.Count) // Коллекция I - ых контуров ( количество найденых 0..n)
            {

                while (m < points[i].Contr.Count) // Обращение к элементам коллекции points[i].Contr 
                {
                    workSheet.Cells[count, 1] = time;
                    workSheet.Cells[count, 4] = points[i].Contr[m].X - 100;
                    workSheet.Cells[count, 2] = points[i].Contr[m].Y + Y;
                    workSheet.Cells[count, 3] = 200;
                    count++;
                    m++;
                    time = 0.001 + time;
                    flagContourType = true; // идем по контуру
                }

                if (i == points.Count - 1)
                {
                    break;
                }


                flagContourType = false; // переход
                if (flagContourType == false)
                {
                    k = 200; // начальное положения для поднятия по Z

                    var oneX = points[i].Contr[points[i].Contr.Count - 1].X - 100; // X точки поднятия
                    var oneY = points[i].Contr[points[i].Contr.Count - 1].Y + Y; // Y точки поднятия  
                    var firstX = points[i + 1].Contr[points[i + 1].Contr.Count - 1].X - 100; // X точки опускания ///БАГ
                    var firstY = points[i + 1].Contr[points[i + 1].Contr.Count - 1].Y + Y; // Y точки опускания ////БАГ
                    var coef = Coefficients(oneX, oneY, firstX, firstY); // коэффициенты для прямой перехода

                    ///---------Поднятие пера------------

                    var timeUP = 1 * 1e-3; // время , чтобы поднять
                    while (k <= 215)
                    {
                        k = 200 + (0.00120148148148148 * Math.Pow((1000 * timeUP), 2)) / 2;
                        workSheet.Cells[count, 3] = k;
                        workSheet.Cells[count, 1] = time;
                        workSheet.Cells[count, 4] = oneX; //------для X = Z —--— 
                        workSheet.Cells[count, 2] = oneY; //------для Y = X----—
                        time = 0.001 + time;
                        timeUP = 0.001 + timeUP;
                        count++;
                    }

                    ///траектория для перехода с контура на контур                   
                    //y = -ax-c/b
                    for (int d = oneX; d < firstX; d++)
                    {
                        var Yzn = ((-coef.Item1 * d) - coef.Item3) / coef.Item2;
                        workSheet.Cells[count, 3] = k;
                        workSheet.Cells[count, 1] = time;
                        workSheet.Cells[count, 4] = d; //------для X = Z —--— 
                        workSheet.Cells[count, 2] = Yzn; //------для Y = X----—
                        time = 0.001 + time;
                        count++;
                    }
                    ///

                    ///---------Опустить перо------------
                    timeUP = 1 * 1e-3;// время , чтобы опустить
                    while (k >= 200)
                    {
                        k = 215 - (0.00120148148148148 * Math.Pow((1000 * timeUP), 2)) / 2;
                        workSheet.Cells[count, 3] = k;
                        workSheet.Cells[count, 1] = time;
                        workSheet.Cells[count, 4] = firstX;
                        workSheet.Cells[count, 2] = firstY;
                        time = 0.001 + time;
                        timeUP = 0.001 + timeUP;
                        count++;
                    }
                }
                i++;
                m = 0;
            }

            //cтабилизация точки при завершении
            while (time <= timeend)
            {
                workSheet.Cells[count, 4] = points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].X - 100; //------для X = Z —--— 
                workSheet.Cells[count, 2] = points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].Y + Y; //------для Y = X----—
                workSheet.Cells[count, 1] = time;
                workSheet.Cells[count, 3] = 200;
                time = 0.01 + time;
                count++;
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
