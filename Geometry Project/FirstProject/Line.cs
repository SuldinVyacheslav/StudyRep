using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Line  
    {
        public double[] X = new double[2];
        public double[] Y = new double[2];
        public double[] Z = new double[2];

        public Line(Dot d1, Dot d2)
        {
            X[0] = d1.X;
            X[1] = d2.X - d1.X;
            Y[0] = d1.Y;
            Y[1] = d2.Y - d1.Y;
            Z[0] = d1.Z;
            Z[1] = d2.Z - d1.Z;
        }
        public Line(Plane p1, Plane p2)
        {
        }
        public Line(Vector v, Dot d)
        {
        }

        public static bool IsOnOneLine(Dot A, Dot B, Dot C)
        {
            Vector AB = Vector.ByTwoDots(A, B);
            Vector AC = Vector.ByTwoDots(A, C);

            if ( (AB | AC) == new Vector(0,0,0))
            {
                return true;
            }
            else return false;
        }
    }
}
