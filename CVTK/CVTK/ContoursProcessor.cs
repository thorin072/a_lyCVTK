using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Collections.Generic;
using System.Drawing;

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
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxTc89Kcos);
                
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

        public static IList<Point> GetImageContours(Image<Gray, byte> bin, double eps)
        {
            var result = new List<Point>();

            Mat hierarchy = new Mat();// создаю память для контуров 
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                // процедура поиска контура в бинарнике исходного изображения
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxTc89Kcos);

                for (int i = 0; i < contours.Size; i++)
                {
                    using (VectorOfPoint contour = contours[i])// ищем i-тый контур в коллекции всех контуров 
                    {
                        result.AddRange(contours[i].ToArray());
                    }
                }
            }

            return result;
        }
    }
}
