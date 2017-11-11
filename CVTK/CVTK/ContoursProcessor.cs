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

        // я подумал, что можно находить для каждых двух соседних точек прямую , НО
          public static IList<Point> Kramer(IList<Point> first_point)
        {
            var result = new List<Point>();
            for (int i = 0; i <= first_point.Count - 1; ++i)
            {
                int x1 = first_point[i].X;
                int y1 = first_point[i].Y;
                int x2 = first_point[i + 1].X;
                int y2 = first_point[i + 1].Y;

                int sqrx1 = (int)Math.Pow(x1, 2);
                int sqrx2 = (int)Math.Pow(x2, 2);

                int sumXi = x1 + x2; 
                int sumSqr = sqrx1 + sqrx2; 
                int sumYi = y1 + y2;
                int sumXiYi = (x1 * y1) + (x2 * y2); 
                int n = 2; 

                int[,] det = new int[,] { { sumSqr, sumXi }, { sumXi, n } };
                int[,] det1 = new int[,] { { sumXiYi, sumYi }, { sumXi, n } };
                int[,] det2 = new int[,] { { sumSqr, sumXiYi }, { sumXi, sumYi } };

                int det_mat = det[0, 0] * det[1, 1] - det[0, 1] * det[1, 0];
                int det_a = det1[0, 0] * det1[1, 1] - det1[0, 1] * det1[1, 0];
                int det_b = det2[0, 0] * det2[1, 1] - det2[0, 1] * det2[1, 0];

                float a = (float) det_a / det_mat;
                float b = (float)det_b / det_mat;

                
                // y = ax+b; - а - найденый коэф, b - найденый коэф
                // лишние точки
                for (int j = x1; j < x2; j++)
                {
                    
                    int y = (int)(a * j + b);
                    result.Add(new Point(j, y));
                }

                for (int j = y1; j < y2; j++)
                {
                    int y = (int)(a * j + b);
                    result.Add(new Point(x1, j));
                }
                result.Add(new Point(x2, y2));
            }
            return result;
        }
    }
}
