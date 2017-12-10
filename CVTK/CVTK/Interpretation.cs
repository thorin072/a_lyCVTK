using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVTK
{
    public static class Interpretation
    {
        public class Constants
        {
            /// <summary>
            /// Ноль манипулятора (Z)
            /// </summary>
            public const int StartHight = 687;
            /// <summary>
            /// Высота для перемещения пера от начальной к след.точке
            /// </summary>
            public const int HightPause = 202;
            public const int StartXPlot = -52;
            public const double StartYPlot = 500.000025;
            /// <summary>
            /// Рабочая высота
            /// </summary>
            public const int ZPlot = 200;
            /// <summary>
            /// Время для опускания/поднятия
            /// </summary>
            public const double timeUp = 1 * 1e-3;
            /// <summary>
            /// Высота для перехода с контура на контур
            /// </summary>
            public const int ZPlotPause = 215;
        }
        public class Times
        {
            public static double TIME;
        }

 
        public static IEnumerable<RobotCommand.RobotPosition> InterpretationOfCommands(IList<CentroMass.ContourWithMass> points, int timeend)
        {
            Times.TIME = 1 * 1e-3;

            var STRUCT = RobotCommand.Start(Times.TIME, Constants.StartHight);
            foreach (var position in STRUCT)
            {
                RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                result.x = position.x;
                result.y = position.y;
                result.z = position.z;
                result.time = position.time;
                Times.TIME = 0.001 + Times.TIME;
                yield return result;
            }
            STRUCT = RobotCommand.ToTheContourPoint(Times.TIME, Constants.HightPause, Constants.StartXPlot, Constants.StartYPlot, points[0].Contr[0].X - 100, points[0].Contr[0].Y+Constants.StartYPlot);
            foreach (var position in STRUCT)
            {
                RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                result.x = position.x;
                result.y = position.y;
                result.z = position.z;
                result.time = position.time;
                Times.TIME = 0.001 + Times.TIME;
                yield return result;
            }

            bool flagContourType;// флаг для поднятия
            for (int i = 0; i < points.Count; i++) // Коллекция I - ых контуров ( количество найденых 0..n)
            {
                for (int m = 0; m < points[i].Contr.Count; m++) // Обращение к элементам коллекции points[i].Contr 
                {
                    RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                    result.time = Times.TIME;
                    result.z = points[i].Contr[m].X - 100;
                    result.x = points[i].Contr[m].Y + Constants.StartYPlot;
                    result.y = Constants.ZPlot;
                    Times.TIME = 0.001 + Times.TIME;
                    flagContourType = true; // идем по контуру
                    yield return result;
                }

                if (i == points.Count - 1)
                {
                    break;
                }
                flagContourType = false; // переход

                if (flagContourType == false)
                {
                    STRUCT = RobotCommand.PenUp(Times.TIME, Constants.ZPlot, points[i].Contr[points[i].Contr.Count - 1].X - 100, points[i].Contr[points[i].Contr.Count - 1].Y + Constants.StartYPlot, Constants.timeUp);
                    foreach (var position in STRUCT)
                    {
                        RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                        result.x = position.x;
                        result.y = position.y;
                        result.z = position.z;
                        result.time = position.time;
                        Times.TIME = 0.001 + Times.TIME;
                        yield return result;
                    }
                    

                    STRUCT = RobotCommand.PenPause(Times.TIME, Constants.ZPlotPause, points[i].Contr[points[i].Contr.Count - 1].X - 100, points[i].Contr[points[i].Contr.Count - 1].Y + Constants.StartYPlot, points[i + 1].Contr[points[i + 1].Contr.Count - 1].X - 100, points[i + 1].Contr[points[i + 1].Contr.Count - 1].Y + Constants.StartYPlot);

                    foreach (var position in STRUCT)
                    {
                        RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                        result.x = position.x;
                        result.y = position.y;
                        result.z = position.z;
                        result.time = position.time;
                        Times.TIME = 0.001 + Times.TIME;
                        yield return result;
                    }

                    STRUCT = RobotCommand.PenDown(Times.TIME, Constants.ZPlotPause, points[i + 1].Contr[points[i + 1].Contr.Count - 1].X - 100, points[i + 1].Contr[points[i + 1].Contr.Count - 1].Y + Constants.StartYPlot, Constants.timeUp);
                    foreach (var position in STRUCT)
                    {
                        RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                        result.x = position.x;
                        result.y = position.y;
                        result.z = position.z;
                        result.time = position.time;
                        Times.TIME = 0.001 + Times.TIME;
                        yield return result;
                    }
                }
            }
            STRUCT = RobotCommand.Stop(Times.TIME, timeend, points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].X - 100, points[points.Count - 1].Contr[points[points.Count - 1].Contr.Count - 1].Y + Constants.StartYPlot, Constants.ZPlot);
            foreach (var position in STRUCT)
            {
                RobotCommand.RobotPosition result = new RobotCommand.RobotPosition();
                result.x = position.x;
                result.y = position.y;
                result.z = position.z;
                result.time = position.time;
                Times.TIME = 0.001 + Times.TIME;
                yield return result;
            }

        }
    }
}
