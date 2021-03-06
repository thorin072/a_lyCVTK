﻿//Класс CentroMass
using System.Collections.Generic;
using System.Linq;
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
        /// Структура с центром масс и листом точек контура
        /// </summary>
        public class ContourWithMass
        {
            /// <summary>
            /// Центр масс контура
            /// </summary>
            public Point Mass;
            /// <summary>
            /// Лист точек контура
            /// </summary>
            public List<Point> Contr;
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
                            result.Add(new Point(contour[contour.Size - 1].X, contour[contour.Size - 1].Y));
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
            var sortToX = SortDeterminationOfCentromass(SortedList);
            return sortToX;
        }

        private static List<ContourWithMass> SortDeterminationOfCentromass(List<ContourWithMass> point)
        {
            var endPointAfterMass = new List<ContourWithMass>(); //  лист для хранения ВСЕХ ИСТИННЫХ КОНТУРОВ
            int i = 0, k = 0;// счетчик для отсечки 
            // цикл находящий подобные контуры
            while (i < point.Count)
            {
                var tresult = new List<ContourWithMass>();
                for (int j = k; j < point.Count; j++)
                {
                    if (((point[i].Mass.X <= point[j].Mass.X + 2) && (point[j].Mass.X - 2 <= point[i].Mass.X))
                       && ((point[i].Mass.Y <= point[j].Mass.Y + 2) && (point[j].Mass.Y - 2 <= point[i].Mass.Y)))
                    {
                        //создание нового экземпляра класса 
                        ContourWithMass massVar = new ContourWithMass();
                        massVar.Contr = point[j].Contr;
                        tresult.Add(massVar);
                        k++;
                    }
                }
                List<ContourWithMass> SortedList = tresult.OrderByDescending(o => o.Contr.Count).ToList(); // сортировка листа по убыванию по числу точек контура
                List<ContourWithMass> SortedList2 = SortedList.OrderBy(o => o.Contr[0].X).ToList(); // сортировка по центру массы 
                // использование класса , но уже с хранением не центра масс , а последней точки контура
                ContourWithMass STRUCTendPointAndContr = new ContourWithMass();
                STRUCTendPointAndContr.Mass.X = SortedList2[0].Contr[SortedList2[0].Contr.Count - 1].X;
                STRUCTendPointAndContr.Mass.Y = SortedList2[0].Contr[SortedList2[0].Contr.Count - 1].Y;
                STRUCTendPointAndContr.Contr = SortedList2[0].Contr;
                endPointAfterMass.Add(STRUCTendPointAndContr);
                i = k;// происходит отческа ,т.е на новом шаге происходит обработка новой коллекции подобных контуров
            }
            return endPointAfterMass;
        }
    }
}