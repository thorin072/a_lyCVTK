//Класс RobotCommand
using System;
using System.Collections.Generic;


namespace CVTK
{
    /// <summary>
    /// Класс реализации (интерпритации) команд для робота
    /// </summary>
    public static class RobotCommand
    {
        /// <summary>
        /// Структура положения робота в реальный момент времени
        /// </summary>
        public class RobotPosition
        {
            public double x; // = z
            public double y; // = x
            public double z; // = y
            public double time;
        }

        /// <summary>
        /// Старт
        /// </summary>
        /// <param name="time">Начальное время</param>
        /// <param name="ZHight">Ноль манипулятора по Y</param>
        /// <param name="YHight">Ноль манипулятора по Х </param>
        /// <param name="x1">Первая точка контура</param>
        /// <param name="y1">Первая точка конутра</param>
        /// <returns></returns>
        public static IEnumerable<RobotPosition> Start(double time, double ZHight,double YHight,double x1,double y1)
        {
            var aX = (2*(y1-YHight)/Math.Pow(10,6)); // ускорение по оси Х
            var aY = Math.Abs((2*(200-ZHight))/ Math.Pow(10, 6)); // ускорение по оси Y
            var aZ = (2 * (x1 - 0)) / Math.Pow(10, 6)*(-1); // ускорение по оси Z

            while (ZHight >= Interpretation.Constants.HightPause)
            {
                RobotPosition result = new RobotPosition();
                result.time = time;
                result.z = 0 - (aZ * Math.Pow(time * 1000, 2)) / 2;
                result.x = 390 + (aX * Math.Pow(time * 1000, 2)) / 2;
                ZHight = 687 - (aY * Math.Pow((1000 * time), 2)) / 2;
                result.y = ZHight;
                time = 0.001 + time;
                ZHight--;
                yield return result;
            }
        }

        /// <summary>
        /// Поднятие пера
        /// </summary>
        /// <param name="time">Время</param>
        /// <param name="ZHight">Высота для поднятия манипулятора</param>
        /// <param name="x1">Координата в которой осуществляется подьем</param>
        /// <param name="y1">Координата в которой осуществляется подьем</param>
        /// <param name="timeUP">Время для поднятия пера</param>
        /// <returns></returns>
        public static IEnumerable<RobotPosition> PenUp(double time, double ZHight, int x1, double y1, double timeUP)
        {
            var aY = Math.Abs((2 * (Interpretation.Constants.ZPlotPause - ZHight)) / Math.Pow(10, 6))*12; // ускорение по оси Y
            while (ZHight <= 215)
            {
                RobotPosition result = new RobotPosition();
                ZHight = 200 + (aY * Math.Pow((1000 * timeUP), 2)) / 2;
                result.y = ZHight;
                result.time = time;
                result.z = x1;
                result.x = y1;
                time = 0.001 + time;
                timeUP = 0.001 + timeUP;
                yield return result;
            }
        }

        /// <summary>
        /// Манипулятор остается на заданой высоте, происзодит перемещение по траектории от контура к контуру 
        /// </summary>
        /// <param name="time">Время</param>
        /// <param name="ZHight">Высота на которой происходит перемещение (постоянна)</param>
        /// <param name="x1">Последняя точка первого контура</param>
        /// <param name="y1">Последняя точка первого контура</param>
        /// <param name="x2">Первая точка нового контура</param>
        /// <param name="y2">Первая точка нового контура</param>
        /// <returns></returns>
        public static IEnumerable<RobotPosition> PenPause(double time, double ZHight, double x1, double y1, double x2, double y2)
        {
            var coef = Coefficients(x1, y1, x2, y2); // коэффициенты для прямой перехода
            for (double i = x1; i < x2; i++) // вычисление точек траектории
            {
                RobotPosition result = new RobotPosition();
                var Yzn = ((-coef.Item1 * i) - coef.Item3) / coef.Item2;
                result.time = time;
                result.z = i;
                result.x = Yzn;
                result.y = ZHight;
                time = 0.001 + time;
                yield return result;
            }
        }
        /// <summary>
        /// Опускание пера манипулятора
        /// </summary>
        /// <param name="time">Время</param>
        /// <param name="ZHight">Высота с которой опускают</param>
        /// <param name="x1">Точка в которой осуществляется опускание</param>
        /// <param name="y1">Точка в которой осуществляется опускание</param>
        /// <param name="timeUP">Время для опускания</param>
        /// <returns></returns>
        public static IEnumerable<RobotPosition> PenDown(double time, double ZHight, int x1, double y1, double timeUP)
        {
            var aY = Math.Abs((2 * (Interpretation.Constants.ZPlot-ZHight)) / Math.Pow(10, 6))*12; // ускорение по оси Y
            while (ZHight >= 200)
            {
                RobotPosition result = new RobotPosition();
                ZHight = 215 - (aY* Math.Pow((1000 * timeUP), 2)) / 2;
                result.y = ZHight;
                result.time = time;
                result.z = x1;
                result.x = y1;
                time = 0.001 + time;
                timeUP = 0.001 + timeUP;
                yield return result;
            }
        }
        /// <summary>
        /// Фиксация точки в конечном положении
        /// </summary>
        /// <param name="time">Время</param>
        /// <param name="timeend">Время процесса</param>
        /// <param name="x1">Точка удержания</param>
        /// <param name="y1">Точка удержания</param>
        /// <param name="ZHight">Рабочая высота</param>
        /// <returns></returns>
        public static IEnumerable<RobotPosition> Stop(double time, double timeend, int x1, double y1, double ZHight)
        {
            while (time <= timeend)
            {
                RobotPosition result = new RobotPosition();
                result.y = ZHight;
                result.time = time;
                result.z = x1;
                result.x = y1;
                time = 0.001 + time;
                yield return result;
            }
        }
        /// <summary>
        /// Нахождение коэфициетов прямой
        /// </summary>
        /// <returns></returns>
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
