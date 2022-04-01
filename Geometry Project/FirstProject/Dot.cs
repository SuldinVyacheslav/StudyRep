using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Dot
    {
        
        public double X;
        public double Y;
        public double Z;

        public Dot(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Dot GetMiddle(Dot dot1, Dot dot2)
        {
            return new Dot((dot1.X+dot2.X)/2, (dot1.Y + dot2.Y) / 2, (dot1.Z + dot2.Z) / 2);
        }

        public Dot SetAside(Vector vect)
        {
            return new Dot(vect.I+ this.X, vect.J + this.Y, vect.K + this.Z);
        }
    }
}
