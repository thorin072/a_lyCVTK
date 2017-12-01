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
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var totalresult = new List<ContourWithMass>();
            Mat hierarchy = new Mat();// выделение массива для хранения контуров
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, method);//поиск контуров
                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(mydocpath + @"\WriteLines.txt"))
                {
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

                            outputFile.WriteLine("Номер:" + i.ToString() + " " + "massX:" + massVar.Mass.X.ToString() + " " + "massY:" + massVar.Mass.Y.ToString() + " " + massVar.Contr.Count.ToString());
                            outputFile.WriteLine("---------------------");
                            totalresult.Add(massVar);
                        }
                    }
                }
            }
            List<ContourWithMass> SortedList = totalresult.OrderByDescending(o => o.Mass.X).ToList();
            var sort = SortDeterminationOfCentromass(SortedList);
            return sort;
        }



        private static List<Point> SortDeterminationOfCentromass(List<ContourWithMass> point)
        {
            var endPointAfterMass = new List<Point>();
            var k = 0;
            int i = 0;
            while (i < point.Count)
            {
                var tresult = new List<ContourWithMass>();

                for (int j = k; j < point.Count; j++)
                {
                    if (((point[i].Mass.X <= point[j].Mass.X + 3) && (point[j].Mass.X - 3 <= point[i].Mass.X))
                        && ((point[i].Mass.Y <= point[j].Mass.Y + 3) && (point[j].Mass.Y - 3 <= point[i].Mass.Y)))
                    {
                        ContourWithMass massVar = new ContourWithMass();
                        var result = new List<Point>();
                        result.AddRange(point[j].Contr.ToArray());
                        massVar.Contr = result;
                        tresult.Add(massVar);
                        k++;
                    }
                }
                List<ContourWithMass> SortedList = tresult.OrderByDescending(o => o.Contr.Count).ToList();
                endPointAfterMass.AddRange(SortedList[0].Contr.ToArray());
                i=k;
            }
            return endPointAfterMass;
        }
    }
}
