using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace CVTK
{
    public static class CentroMass
    {
        public static IList<Point> DeterminationOfCentromass(IList<Point> points)
        {
            var result = new List<Point>();
            var massx = points.Average(_ => _.X);
            var massy = points.Average(_ => _.Y);
            result.Add(new Point((int)massx, (int)massy));
            return result;   
        }
    }
}
