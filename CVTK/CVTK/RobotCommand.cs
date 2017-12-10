using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVTK
{
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

        
        public static IEnumerable<RobotPosition> Start(double time, double ZHight)
        {
            while (ZHight > 202)
            {
                RobotPosition result = new RobotPosition();
                result.time = time;
                result.z = 0 - (0.000123457 * Math.Pow(time * 1000, 2)) / 2;
                result.x = 390 + (0.000271605 * Math.Pow(time * 1000, 2)) / 2;
                ZHight = 687 - (0.00120148148148148 * Math.Pow((1000 * time), 2)) / 2;
                result.y = ZHight;
                time = 0.001 + time;
                ZHight--;
                yield return result ;
            }  
        }

        public static IEnumerable<RobotPosition> ToTheContourPoint( double time, double ZHight, int x1, double y1, double x2, double y2)
        {
            double lastX = 0, lastY = 0;
            var coef = Coefficients(x1, y1, x2, y2); // коэффициенты для прямой перехода
            for (int i = x1; i > x2; i--) // вычисление точек траектории
            {
                RobotPosition result = new RobotPosition();
                var Yzn = ((-coef.Item1 * i) - coef.Item3) / coef.Item2;
                result.time = time;
                result.z = i;
                result.x = Yzn;
                result.y = ZHight;
                time = 0.001 + time;
                lastX = result.z;
                lastY = result.x;
                yield return result;
            }
            for (double i = ZHight; i >= 200; i--) // опустить перо в первую точку контура
            {
                RobotPosition result = new RobotPosition();
                result.time = time;
                result.z = lastX;
                result.x = lastY;
                result.y = i;
                time = 0.001 + time;
                yield return result;
            }
        }


        public static IEnumerable<RobotPosition> PenUp( double time, double ZHight, int x1, double y1, double timeUP)
        {
            while (ZHight <= 215)
            {
                RobotPosition result = new RobotPosition();
                ZHight = 200 + (0.00120148148148148 * Math.Pow((1000 * timeUP), 2)) / 2;
                result.y = ZHight;
                result.time = time;
                result.z = x1;
                result.x = y1;
                time = 0.001 + time;
                timeUP = 0.001 + timeUP;
                yield return result;
            } 
        }

        public static IEnumerable<RobotPosition> PenPause( double time, double ZHight, int x1, double y1, double x2, double y2)
        {
            var coef = Coefficients(x1, y1, x2, y2); // коэффициенты для прямой перехода
            for (int i = x1; i < x2; i++) // вычисление точек траектории
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

        public static IEnumerable<RobotPosition> PenDown( double time, double ZHight, int x1, double y1, double timeUP)
        {
            while (ZHight >= 200)
            {
                RobotPosition result = new RobotPosition();
                ZHight = 215 - (0.00120148148148148 * Math.Pow((1000 * timeUP), 2)) / 2;
                result.y = ZHight;
                result.time = time;
                result.z = x1;
                result.x = y1;
                time = 0.001 + time;
                timeUP = 0.001 + timeUP;
                yield return result;
            }
            
        }

        public static IEnumerable<RobotPosition> Stop ( double time,double timeend , int x1, double y1,double ZHight)
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
