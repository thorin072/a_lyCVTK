using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace CVTK
{
    public static class ContoursProcessor
    {
        public static IList<Point> GetImagePoints(Image<Gray, byte> bin)
        {
            var result = new List<Point>();
            Mat hierarchy = new Mat();// создаю память для контуров 
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                // процедура поиска контура в бинарнике исходного изображения
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                for (int i = 0; i < contours.Size; i++)
                {
                    using (VectorOfPoint contour = contours[i])// ищем i-тый контур в коллекции всех контуров 
                    {
                        result.AddRange(contour.ToArray());
                    }
                }
            }
            return result;
        }

        public static IList<Point> catching(IList<Point> point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= point.Count - 2; ++i)
            {
                if ((point[i + 1].X != point[i].X + 1) && (point[i + 1].Y != point[i].Y + 1))
                {
                    point.Add(new Point(point[i].X, point[i].Y));
                    point.Add(new Point(point[i + 1].X, point[i + 1].Y));
                }
                else
                {
                    continue;
                }
            }
            return result;
        }

        /// <summary>
        /// Нахождения коэфициентов A,B,C для точки (x1,y1) и (x2,y2)
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static Tuple<int, int, int> Coefficients(int x1, int y1, int x2, int y2)
        {
            // (y1-y2)*x+(x2-x1)*y+(x1y2-x2y1) = 0
            //Ax+By+C=0
            var A = (y1 - y2);
            var B = (x2 - x1);
            var C = (x1 * y2 - x2 * y1);
            return Tuple.Create(A, B, C);
        }

        /// <summary>
        /// Проверка лежат ли точки на одной прямой 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public static Tuple<int, bool, string> On_one_straight_linet(int x, int y, int x1, int y1)
        {
            var probe = Probe(x, y, x1, y1); // нахождение пробной точки для i-ой 
            var coefIP = Coefficients(x, y, probe.Item1, probe.Item2);
            var coefIJ = Coefficients(x, y, x1, y1);

            if (coefIP.Item1 == 0 && coefIJ.Item1 == 0) // лежат на одном у
            {
                var resy = (-coefIP.Item1 * x - coefIP.Item3) / coefIP.Item2;
                return Tuple.Create(resy, true, "y");
            }

            if (coefIP.Item2 == 0 && coefIJ.Item2 == 0) // лежат на одном x
            {
                var resx = (-coefIP.Item2 * y - coefIP.Item3) / coefIP.Item1;
                return Tuple.Create(resx, true, "x");
            }
            else
            { return Tuple.Create(0, false, ""); }
        }

        /// <summary>
        /// Нахождение пробной точки для i-ой
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static Tuple<int, int> ProbeC(int x1, int y1, int x2, int y2)
        {
            if ((x1 != x2) && (y1 != y2))
            {
                if ((y1 <= y2) && (x1 >= x2))
                {
                    return Tuple.Create(x2 - 1, y2 - 1);
                }
                else
                {
                    return Tuple.Create(x2 - 1, y1 - 1);
                }

            }
            return Tuple.Create(0, 0);

        }
        public static Tuple<int, int> Probe(int x1, int y1, int x2, int y2)
        {

            if (x1 == x2) // const x 
            {
                if (y1 > y2)// i-ая выше j-ой
                {
                    return Tuple.Create(x1, y1 - 1);
                }
                else// j-ая выше i-ой
                {
                    return Tuple.Create(x1, y1 + 1);
                }
            }
            if (y1 == y2) // const y 
            {
                if (x1 > x2)// i-ая дальше j-ой
                {
                    return Tuple.Create(x1 - 1, y1);
                }
                else // j-ая дальше i-ой
                {
                    return Tuple.Create(x1 + 1, y1);
                }
            }

            return Tuple.Create(0, 0);
        }

        public static Tuple<List<Point>, bool> Curve(int x, int y, int x1, int y1)
        {
            var result = new List<Point>();
            var probe = ProbeC(x, y, x1, y1); // нахождение пробной точки для i-ой 
            var coefIP = Coefficients(x, y, probe.Item1, probe.Item2);
            var coefIJ = Coefficients(x, y, x1, y1);

            for (int a = x1; a < x; a += 1)
            {
                var resy = (-coefIP.Item1 * a - coefIP.Item3) / coefIP.Item2;
                if (a == resy) { break; }
                result.Add(new Point(a, resy));


            }
            return Tuple.Create(result, true);
        }

        /// <summary>
        /// Поиск прямых, диагоналей на множетсве входных точек
        /// </summary>
        /// <param name="first_point"></param>
        /// <returns></returns>
        public static Tuple<List<Point>, List<Point>> Found_lines(IList<Point> first_point)
        {
            var point_contr = new List<Point>();
            var angle_point = new List<Point>();
            byte c_line = 0; // счетчик прямых
            for (int i = 0; i <= first_point.Count - 2; ++i)
            {
                int x1 = first_point[i].X;
                int y1 = first_point[i].Y;
                int x2 = first_point[i + 1].X;
                int y2 = first_point[i + 1].Y;
                var flag = On_one_straight_linet(x1, y1, x2, y2); // создание кортежа 

                point_contr.Add(new Point(x1, y1));

                if (flag.Item2 == false)
                {
                    //var new_contour = Curve(x1, y1, x2, y2);
                    //if (new_contour.Item2 == true)
                    //{
                    //    point_contr.AddRange(new_contour.Item1);
                    //}
                    continue;
                }

                // если точка лежит на прямой 
                if (flag.Item2 == true) 
                {
                    if (flag.Item3 == "y")
                    {
                        c_line++;
                        MainCV ADD_TO_LIST = new MainCV(); // добавляет X,Y в ЛИСТ_КОНТУРОВ прямые, где const x
                        var Ylist = new List<Point>();

                        angle_point.Add(new Point(x1, y1));
                        for (int a = x1; a <= x2; a += 1)
                        {
                            point_contr.Add(new Point(a, flag.Item1));
                            Ylist.Add(new Point(flag.Item1, a));
                        }
                        ADD_TO_LIST.AddList(Ylist, "Прямая const x",c_line);
                    }
                    if (flag.Item3 == "x")
                    {
                        c_line++;
                        MainCV ADD_TO_LIST = new MainCV();// добавляет X,Y в ЛИСТ_КОНТУРОВ прямые, где const y
                        var Xlist = new List<Point>();

                        angle_point.Add(new Point(x1, y1));
                        for (int a = y1; a <= y2; a += 1)
                        {
                            point_contr.Add(new Point(flag.Item1, a));
                            Xlist.Add(new Point(flag.Item1, a));
                        }
                        ADD_TO_LIST.AddList(Xlist, "Прямая const y",c_line);
                    }
                }
                point_contr.Add(new Point(x2, y2));

            }

            // var new_contour = Curve(point_contr);

            return Tuple.Create(point_contr, angle_point);
        }
    }
}
