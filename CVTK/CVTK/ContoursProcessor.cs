using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace CVTK
{
    ///центромассный 
    /// <summary>
    /// Класс для нахождения контуров изображения
    /// </summary>
    public static class ContoursProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bin">Изображение после обработки Сanny</param>
        /// <param name="method">Метод аппроксимации</param>
        /// <returns></returns>
        public static List<Point> GetImagePoints(Image<Gray, byte> bin, ChainApproxMethod method)
        {
            var result = new List<Point>();
            Mat hierarchy = new Mat();// выделение массива для хранения контуров
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, method);//поиск контуров
                var r = contours.Size;
                for (int i = 0; i < contours.Size; i++)
                {
                    using (VectorOfPoint contour = contours[i])// ищем i-тый контур в коллекции всех контуров 
                    {
                        result.AddRange(contour.ToArray());// добавление
                    }
                }
            }
            //  ListWithMass.Add(new Tuple<Point, Point>((new Point(points[i].X, points[i].Y)), (new Point((int)massx, (int)massy))));
            return result;
        }
    }
}
