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
        public class ContourWithMass
        {
            public Point Mass;
            public List<Point> Contr;
        }

        public static IList<Point> DeterminationOfCentromass(Image<Gray, byte> bin, ChainApproxMethod method)
        {

            var totalresult = new List<ContourWithMass>();
            Mat hierarchy = new Mat();// выделение массива для хранения контуров
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, method);//поиск контуров
                for (int i = 0; i < contours.Size; i++)
                {
                    using (VectorOfPoint contour = contours[i])// ищем i-тый контур в коллекции всех контуров 
                    {
                        ContourWithMass massVar = new ContourWithMass();
                        var result = new List<Point>();
                        result.AddRange(contour.ToArray());
                        massVar.Mass.X = (int)result.Average(_ => _.X);
                        massVar.Mass.Y = (int)result.Average(_ => _.Y);
                        massVar.Contr = result;
                        totalresult.Add(massVar);
                    }
                }
            }
            var sort = SortDeterminationOfCentromass(totalresult);
            return sort;
        }

        private static List<Point> SortDeterminationOfCentromass(List<ContourWithMass> point)
        {
            var tresult = new List<ContourWithMass>();
            var endPointAfterMass = new List<Point>();
            for (int i = 0; i < point.Count - 1; i++)
            {
                for (int j = i + 1; j < point.Count; j++)
                {
                    ContourWithMass massVar = new ContourWithMass();
                    if (((point[i].Mass.X > point[j].Mass.X - 7) && (point[i].Mass.X < point[j].Mass.X + 7)) && ((point[i].Mass.Y > point[j].Mass.Y - 7) && (point[i].Mass.Y < point[j].Mass.Y + 7)))
                    {
                        if (point[i].Contr.Count > point[i + 1].Contr.Count)
                        {
                            var result = new List<Point>();
                            result.AddRange(point[j].Contr.ToArray());
                            massVar.Mass.X = (int)result.Average(_ => _.X);
                            massVar.Mass.Y = (int)result.Average(_ => _.Y);
                            massVar.Contr = result;
                            tresult.Add(massVar);
                        }
                        else
                        {
                            var result = new List<Point>();
                            result.AddRange(point[j].Contr.ToArray());
                            massVar.Mass.X = (int)result.Average(_ => _.X);
                            massVar.Mass.Y = (int)result.Average(_ => _.Y);
                            massVar.Contr = result;
                            tresult.Add(massVar); ;
                        }
                    }
                }
            }

            List<ContourWithMass> SortedList = tresult.OrderBy(o => o.Mass.X).ToList();
            for (int i = 0; i < SortedList.Count; i++)
            {
                endPointAfterMass.AddRange(SortedList[i].Contr.ToArray());
            }

            return endPointAfterMass;
        }
    }
}
