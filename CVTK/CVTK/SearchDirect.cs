using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace CVTK
{
    /// <summary>
    /// Класс нахождения двух вершин для прямой
    /// </summary>
    public static class SearchDirect
    {
        /// <summary>
        /// Нахождение вершин прямых
        /// </summary>
        /// <param name="point">Лист аппроксимированныч точек</param>
        /// <returns></returns>
        public static IList<Point> SortTopPoint(IList<Point> point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= point.Count - 2; ++i)
            {
                int x1 = point[i].X;
                int y1 = point[i].Y;
                int x2 = point[i + 1].X;
                int y2 = point[i + 1].Y;
                var FlagDirect = CalculationOfTheLine.OnOneStraightLine(x1, y1, x2, y2); // лежит ли точка на линии 
                if (FlagDirect == true)
                {
                    result.Add(new Point(x1, y1));
                    result.Add(new Point(x2, y2));
                }
            }
            return result;
        }
    }
}
