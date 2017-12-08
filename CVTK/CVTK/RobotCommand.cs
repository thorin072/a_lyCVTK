using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVTK
{
    public static class RobotCommand
    {
        /// <summary>
        /// Структура положения робота в реальный момент времени
        /// </summary>
        public class RobotPosition
        {
            double x; // = z
            double y; // = x
            double z; // = y
            double time;
        }
    }
}
