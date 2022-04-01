using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Plane
    {
        public double A;
        public double C;
        public double B;
        public double D;

        public Vector N; 
        public Plane(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            N = new Vector(A,B,C);
        }

        public static Plane ByThreeDots(Dot d1, Dot d2, Dot d3)
        {

            double a = (d2.Y - d1.Y) * (d3.Z - d1.Z) - (d2.Z - d1.Z) * (d3.Y - d1.Y);
            double b = - ((d2.X - d1.X) * (d3.Z - d1.Z) - (d2.Z - d1.Z) * (d3.X - d1.X));
            double c = (d2.X - d1.X) * (d3.Y - d1.Y) - (d2.Y - d1.Y) * (d3.X - d1.X);
            double d = -(d1.X * a + d1.Y * b + d1.Z * c);
            return new Plane(a,b,c,d);
        }
    }
}
