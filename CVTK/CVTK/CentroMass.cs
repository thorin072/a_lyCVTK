﻿using System;
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
    /// <summary>
    /// Класс для определения цетра масс контура 
    /// </summary>
    public static class CentroMass
    {
        /// <summary>
        /// Специальная структура для выходного листа данных
        /// </summary>
        public class ContourWithMass
        {
            public Point Mass; // (x,y) - центра масс
            public List<Point> Contr; // лист точек контура 
        }

        public static IList<ContourWithMass> DeterminationOfCentromass(Image<Gray, byte> bin, ChainApproxMethod method)
        {
            var totalresult = new List<ContourWithMass>(); // лист для хранения ВСЕХ НАЙДЕНЫХ КОНТУРОВ
            Mat hierarchy = new Mat();// выделение массива для хранения контуров
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(bin, contours, hierarchy, RetrType.List, method);//поиск контуров
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
                            totalresult.Add(massVar);
                        }
                    }
                }
            }
            List<ContourWithMass> SortedList = totalresult.OrderByDescending(o => o.Mass.X).ToList();
            var sort = SortDeterminationOfCentromass(SortedList);
            return sort;
        }

        private static List<ContourWithMass> SortDeterminationOfCentromass(List<ContourWithMass> point)
        {
            var endPointAfterMass = new List<ContourWithMass>(); //  лист для хранения ВСЕХ ИСТИННЫХ КОНТУРОВ
            int i = 0, k = 0;// счетчик для отсечки 
            while (i < point.Count)
            {
                var tresult = new List<ContourWithMass>();
                for (int j = k; j < point.Count; j++)
                {
                    //проблема с О
                    if (((point[i].Mass.X <= point[j].Mass.X + 2) && (point[j].Mass.X - 2 <= point[i].Mass.X))
                       && ((point[i].Mass.Y <= point[j].Mass.Y + 2) && (point[j].Mass.Y - 2 <= point[i].Mass.Y)))
                    {
                        ContourWithMass massVar = new ContourWithMass();
                        var result = new List<Point>();
                        result.AddRange(point[j].Contr.ToArray());
                        massVar.Contr = result;
                        tresult.Add(massVar);
                        k++;
                    }
                }
                List<ContourWithMass> SortedList = tresult.OrderByDescending(o => o.Contr.Count).ToList(); // сортировка листа по убыванию по числу точек контура
                // использование класса , но уже с хранением не центра масс , а последней точки контура
                ContourWithMass endPointAndContr = new ContourWithMass();
                endPointAndContr.Mass.X = tresult[0].Contr[tresult[0].Contr.Count - 1].X;
                endPointAndContr.Mass.Y = tresult[0].Contr[tresult[0].Contr.Count - 1].Y;
                endPointAndContr.Contr = tresult[0].Contr;
                endPointAfterMass.Add(endPointAndContr);
                i = k;
            }
            return endPointAfterMass;
        }
    }
}
