using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Flann;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Linq;
namespace CVTK
{
    public class KeyPoint
    {
        public static IList<Point> SortTopPoint(IList<CentroMass.ContourWithMass> point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= point.Count - 2; ++i)
            {
                int x1 = point[i].Contr[i].X;
                int y1 = point[i].Contr[i].Y;
                int x2 = point[i + 1].Contr[i+1].X;
                int y2 = point[i + 1].Contr[i+1].Y;
                var FlagDirect = OnOneStraightLine(x1, y1, x2, y2); // лежит ли точка на линии 
                if (FlagDirect == true)
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
        private static Tuple<int, int, int> Coefficients(int x1, int y1, int x2, int y2)
        {
            //(y1-y2)*x+(x2-x1)*y+(x1y2-x2y1) = 0            //Ax+By+C=0
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
        private static bool OnOneStraightLine(int x, int y, int x1, int y1)
        {
            var probe = ProbePoint(x, y, x1, y1); // нахождение пробной точки для i-ой 
            var coefIP = Coefficients(x, y, probe.Item1, probe.Item2);
            var coefIJ = Coefficients(x, y, x1, y1);

            if (coefIP.Item1 == 0 && coefIJ.Item1 == 0) // лежат на одном у
            {
                return true;
            }

            if (coefIP.Item2 == 0 && coefIJ.Item2 == 0) // лежат на одном x
            {
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
        private static Tuple<int, int> ProbePoint(int x1, int y1, int x2, int y2)
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


