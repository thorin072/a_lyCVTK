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
        public static IList<Point> GetImagePoints(Image<Gray, byte> bin, double eps)
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
        public static Tuple<int, bool, string> On_one_straight_linet(int x, int y, int x1, int y1)
        {
            var probe = Probe(x, y, x1, y1);
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

            if (Ap == 0 && Aj == 0) // лежат на одном x
            {
                var resy = (-Ap * x - Cp) / Bp;
                return Tuple.Create(resy, true, "y");

            }
            //else { return Tuple.Create(0, false, ""); }

            if (Bp == 0 && Bj == 0) // лежат на одном x
            {
                var resx = (-Bp * y - Cp) / Ap;
                return Tuple.Create(resx, true, "x");

            }
            else { return Tuple.Create(0, false, ""); }
        }

        public static Tuple<int, int> Probe(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2) // const x 
            {
                if (y1 > y2)// i-ая выше j-ой
                {
                    return Tuple.Create(x1, y1 - 1);
                }
                if (y2 > y1)// j-ая выше i-ой
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
                if (x2 > x1)// j-ая дальше i-ой
                {
                    return Tuple.Create(x1 + 1, y1);
                }
            }
            return Tuple.Create(0, 0);
        }

        public static IList<Point> Kramer(IList<Point> first_point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= first_point.Count - 2; ++i)
            {
                int x1 = first_point[i].X;
                int y1 = first_point[i].Y;
                int x2 = first_point[i + 1].X;
                int y2 = first_point[i + 1].Y;

                var flag = On_one_straight_linet(x1, y1, x2, y2);

                result.Add(new Point(x1, y1));

                if (flag.Item2 == true)
                {
                    if (flag.Item3 == "y")
                    {
                        for (int a = x1; a <= x2; a++)
                        {
                            result.Add(new Point(a, flag.Item1));

                        }
                    }
                    if (flag.Item3 == "x")
                    {
                        for (int a = y1; a <= y2; a++)
                        {
                            result.Add(new Point(flag.Item1, a));

                        }
                    }

                }
                else { continue; }
                result.Add(new Point(x2, y2));
            }


            return result;
        }
    }
}
