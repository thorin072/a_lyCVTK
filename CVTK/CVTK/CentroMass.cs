using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace CVTK
{
    public static class CentroMass
    {
        public struct ContourWithMass
        {
            public  Point mass;
            public  List<Point> contr;
        }

        public static IList<ContourWithMass> DeterminationOfCentromass(Image<Gray, byte> bin, ChainApproxMethod method)
        {
            var result = new List<Point>();
            var totalresult = new List<ContourWithMass>();
            Mat hierarchy = new Mat();// выделение массива для хранения контуров
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, method);//поиск контуров
                var r = contours.Size;
                for (int i = 0; i < contours.Size; i++)
                {
                    using (VectorOfPoint contour = contours[i])// ищем i-тый контур в коллекции всех контуров 
                    {
                        ContourWithMass massVar = new ContourWithMass();
                        result.AddRange(contour.ToArray());// добавление
                        massVar.mass.X = (int)result.Average(_ => _.X);
                        massVar.mass.Y = (int)result.Average(_ => _.Y);
                        massVar.contr = result;
                        totalresult.Add(new ContourWithMass());
                    }
                }
            }

            return totalresult;
           

        }
        
    }
}
