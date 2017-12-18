//Класс Interpretation
using System.Collections.Generic;

namespace CVTK
{
    /// <summary>
    /// Класс для создания выходного (полного) списка всех параметров манипулятора в зависимости от времени
    /// </summary>
    public static class Interpretation
    {
        public static double AllTime;
        public class Constants
        {
            /// <summary>
            /// Ноль манипулятора (Z)
            /// </summary>
            public const double StartZ= 686.6;
            /// <summary>
            /// Ноль манипулятора (Y)
            /// </summary>
            public const double StartY = 390;
            /// <summary>
            /// Коэфициент для перевода точки на точку плоскости
            /// </summary>
            public const double StartYPlot = 500.000025;
            /// <summary>
            /// Время для опускания/поднятия
            /// </summary>
            public const double timeUp = 1 * 1e-3;
        }
        public class TimeAll
        {
            public double Time;
            

        }

        /// <summary>
        /// Интерпритация команд для робота (вычисление траекторий)
        /// </summary>
        /// <param name="points">Входной лист точек всего контура</param>
        /// <param name="Zplot">Высота на которой находится раб.обл</param>
        /// <param name="ZplotPause">Высота на которой будет происходить перемещение с контура на контур</param>
        /// <returns></returns>
        public static IEnumerable<RobotCommand.RobotPosition> InterpretationOfCommands(IList<CentroMass.ContourWithMass> points,double Zplot,double ZplotPause)
        {
            TimeAll Times = new TimeAll();
            Times.Time = 1 * 1e-3;

            AllTime = Times.Time;
            ///Манипулятор из точки (0,390,687) будет медленно опускаться в первую точку контура (x1,y1,200)
            var STRUCT = RobotCommand.Start(Times.Time, Constants.StartZ, Constants.StartY, points[0].Contr[0].X - 100, points[0].Contr[0].Y + Constants.StartYPlot, Zplot);
            foreach (var position in STRUCT)
            {
                RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                result.x = position.x;
                result.y = position.y;
                result.z = position.z;
                result.time = position.time;
                Times.Time = 0.001 + Times.Time;
                yield return result;
            }

            bool flagContourType;// флаг для поднятия
            for (int i = 0; i < points.Count; i++) // Коллекция I - ых контуров ( количество найденых 0..n)
            {
                for (int m = 0; m < points[i].Contr.Count; m++) // Обращение к элементам коллекции points[i].Contr 
                {
                    ///рисуем контур на плоскости
                    RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                    result.time = Times.Time;
                    result.z = points[i].Contr[m].X - 100;
                    result.x = points[i].Contr[m].Y + Constants.StartYPlot;
                    result.y = Zplot;
                    Times.Time = 0.001 + Times.Time;
                    flagContourType = true; // идем по контуру
                    yield return result;
                }

                ///если контур последний , выход из цикла рисования
                if (i == points.Count - 1)
                {
                    break;
                }
                flagContourType = false; // переход

                ///поднимаем манипулятор, флаг ложь 
                if (flagContourType == false)
                {
                    ///поднятие пера в одной точке 
                    STRUCT = RobotCommand.PenUp(Times.Time, Zplot, points[i].Contr[points[i].Contr.Count - 1].X - 100, points[i].Contr[points[i].Contr.Count - 1].Y + Constants.StartYPlot, Constants.timeUp, Zplot, ZplotPause);
                    foreach (var position in STRUCT)
                    {
                        RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                        result.x = position.x;
                        result.y = position.y;
                        result.z = position.z;
                        result.time = position.time;
                        Times.Time = 0.001 + Times.Time;
                        yield return result;
                    }

                    ///вычисление тракетории перемещения из (x1,y1,210) в (x2,y2,210)
                    STRUCT = RobotCommand.PenPause(Times.Time, ZplotPause, points[i].Contr[points[i].Contr.Count - 1].X - 100, points[i].Contr[points[i].Contr.Count - 1].Y + Constants.StartYPlot, points[i + 1].Contr[points[i + 1].Contr.Count - 1].X - 100, points[i + 1].Contr[points[i + 1].Contr.Count - 1].Y + Constants.StartYPlot);

                    foreach (var position in STRUCT)
                    {
                        RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                        result.x = position.x;
                        result.y = position.y;
                        result.z = position.z;
                        result.time = position.time;
                        Times.Time = 0.001 + Times.Time;
                        yield return result;
                    }

                    ///опускание пера в одной точке
                    STRUCT = RobotCommand.PenDown(Times.Time, ZplotPause, points[i + 1].Contr[points[i + 1].Contr.Count - 1].X - 100, points[i + 1].Contr[points[i + 1].Contr.Count - 1].Y + Constants.StartYPlot, Constants.timeUp, Zplot);
                    foreach (var position in STRUCT)
                    {
                        RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                        result.x = position.x;
                        result.y = position.y;
                        result.z = position.z;
                        result.time = position.time;
                        Times.Time = 0.001 + Times.Time;
                        yield return result;
                    }
                }
            }
            

            ///поднятие органа манипулятор
            STRUCT = RobotCommand.Stop(Times.Time, Constants.StartZ, Constants.StartY, points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].X - 100, points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].Y + Constants.StartYPlot, Zplot);
            foreach (var position in STRUCT)
            {
                RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                result.x = position.x;
                result.y = position.y;
                result.z = position.z;
                result.time = position.time;
                Times.Time = 0.001 + Times.Time;
                yield return result;
            }

            

        }
    }
}