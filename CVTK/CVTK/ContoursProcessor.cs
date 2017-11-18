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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public static Tuple<int, bool, string> On_one_straight_linet(int x, int y, int x1, int y1)
        {
            var probe = Probe(x, y, x1, y1); // нахождение пробной точки для i-ой 
            // (y1-y2)*x+(x2-x1)*y+(x1y2-x2y1) = 0
            //Ax+By+C=0

            //точка i и пробная 
            var Ap = (y - probe.Item2);
            var Bp = (probe.Item1 - x);
            var Cp = (x * probe.Item2 - probe.Item1 * y);
            //точка i и j
            var Aj = (y - y1);
            var Bj = (x1 - x);
            var Cj = (x * y1 - x1 * y);

            if ((Ap == Aj * 2) && (Bp == Bj * 2) && (Cp == Cj * 2))
            {
                if (x > y)
                {
                    var resx = (-Bp * y - Cp) / Ap;

                    return Tuple.Create(resx, true, "digx");

                }
                if (x < y)
                {
                    var resy = (-Ap * x - Cp) / Bp;
                    return Tuple.Create(resy, true, "digy");

                }

            }
            if (Ap == 0 && Aj == 0) // лежат на одном у
            {
                var resy = (-Ap * x - Cp) / Bp;
                return Tuple.Create(resy, true, "y");
            }

            if (Bp == 0 && Bj == 0) // лежат на одном x
            {
                var resx = (-Bp * y - Cp) / Ap;
                return Tuple.Create(resx, true, "x");
            }
            else
            { return Tuple.Create(0, false, ""); }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
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
            if ((x1 != x2)&& (y1 != y2))
            {
                if (y2 > x1)
                {
                    return Tuple.Create(x1 + 1, y1 + 1);
                }
                else
                {
                    return Tuple.Create(x1 + 1, y1 - 1);
                }
            }
            return Tuple.Create(0, 0);
        }
        public static IList<Point> arc_found(IList<Point> point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= point.Count - 2; ++i)
            {
                //if ((point[i].X == point[i + 1].X) && (point[i].Y == point[i + 1].Y))
                //{
                //    point.RemoveAt(i + 1);
                //    continue;

                //}
                if ((point[i].X != point[i + 1].X) && (point[i].Y != point[i + 1].Y))
                {
                    result.Add(new Point(point[i].X, point[i].Y));
                    result.Add(new Point(point[i + 1].X, point[i + 1].Y));
                }
                else
                {

                }


            }

            return result;
        }

        public static IList<Point> Curve(IList<Point> point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= point.Count - 2; ++i)
            {
                if ((point[i].X == point[i + 1].X) && (point[i].Y == point[i + 1].Y))
                {
                    continue;
                }
                else
                {
                    var Aj = (point[i].Y - point[i + 1].Y);
                    var Bj = (point[i + 1].X - point[i].X);
                    var Cj = (point[i].X * point[i + 1].Y - point[i + 1].X * point[i].Y);

                    if (Aj == 0) { break; }
                    for (int a = point[i].Y; a <= point[i + 1].Y; a += 1)
                    {
                        var resx = (-Bj * a - Cj) / Aj;
                        point.Add(new Point(resx, a));
                    }

                }
            }
            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="first_point"></param>
        /// <returns></returns>
        public static Tuple<List<Point>, List<Point>> Found_lines(IList<Point> first_point)
        {
            var point_contr = new List<Point>();
            var angle_point = new List<Point>();

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
                    continue;
                }

                if (flag.Item2 == true) // если точка лежит на прямой 
                {
                    if (flag.Item3 == "y")
                    {
                        angle_point.Add(new Point(x1, y1));
                        for (int a = x1; a <= x2; a += 1)
                        {
                            point_contr.Add(new Point(a, flag.Item1));
                        }
                    }
                    if (flag.Item3 == "x")
                    {
                        angle_point.Add(new Point(x1, y1));
                        for (int a = y1; a <= y2; a += 1)
                        {
                            point_contr.Add(new Point(flag.Item1, a));
                        }
                    }
                    //if (flag.Item3 == "digx")
                    //{
                    //    angle_point.Add(new Point(x1, y1));
                    //    for (int a = y1; a <= y2; a += 1)
                    //    {
                    //        point_contr.Add(new Point(flag.Item1, a));
                    //    }
                    //}
                    //if (flag.Item3 == "digy")
                    //{
                    //    angle_point.Add(new Point(x1, y1));
                    //    for (int a = x1; a <= x2; a += 1)
                    //    {
                    //        point_contr.Add(new Point(a, flag.Item1));
                    //    }
                    //}
                }
                point_contr.Add(new Point(x2, y2));
            }
            var new_contour = Curve(point_contr);
            point_contr.AddRange(new_contour);
            return Tuple.Create(point_contr, angle_point);
        }
    }
}
