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
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxNone);
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
        public static IList<Point> GetTopPoint(Image<Gray, byte> bin)
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

        public static IList<Point> Sort_Top_Point(IList<Point> point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= point.Count - 2; ++i)
            {
                int x1 = point[i].X;
                int y1 = point[i].Y;
                int x2 = point[i + 1].X;
                int y2 = point[i + 1].Y;
                var flag = On_one(x1, y1, x2, y2); // лежит ли точка на линии 
                if (flag == true)
                {
                    result.Add(new Point(x1, y1));
                    result.Add(new Point(x2, y2));
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

        public static Tuple<int, bool, string> On_one_straight_linet2(int x, int y, int x1, int y1)
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
        /// Проверка лежат ли точки на одной прямой 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <returns></returns>
        public static bool On_one(int x, int y, int x1, int y1)
        {
            var probe = Probe(x, y, x1, y1); // нахождение пробной точки для i-ой 
            var coefIP = Coefficients(x, y, probe.Item1, probe.Item2);
            var coefIJ = Coefficients(x, y, x1, y1);

            if (coefIP.Item1 == 0 && coefIJ.Item1 == 0) // лежат на одном у
            {
                var resy = (-coefIP.Item1 * x - coefIP.Item3) / coefIP.Item2;
                return true;
            }

            if (coefIP.Item2 == 0 && coefIJ.Item2 == 0) // лежат на одном x
            {
                var resx = (-coefIP.Item2 * y - coefIP.Item3) / coefIP.Item1;
                return true;
            }
            else
            { return false; }
        }

        /// <summary>
        /// Нахождение пробной точки для i-ой
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

            return Tuple.Create(0, 0);
        }
    }
}
