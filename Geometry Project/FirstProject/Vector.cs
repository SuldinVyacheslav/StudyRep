using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Vector
    {
        public double I;
        public double J;
        public double K;

        public double Length;
        public Vector(double i, double j, double k)
        {
            I = i;
            J = j;
            K = k;
            Length = Math.Sqrt(I * I + J * J + K * K);
        }


        public static Vector ByTwoDots(Dot from, Dot to)
        {
            return new Vector(to.X - from.X, to.Y - from.Y, to.Z - from.Z);
        }

        public static double operator *(Vector v1, Vector v2) //scalar
        {
            return v1.I * v2.I + v1.J * v2.J + v1.K * v2.K;
        }

        public static Vector operator *(Vector v, double lambda) 
        {
            return new Vector( v.I * lambda, v.J * lambda, v.K * lambda);
        }

        public static Vector operator |(Vector v1, Vector v2) //vector
        {
            double i = v1.J * v2.K - v2.J * v1.K;
            double j = - (v1.I * v2.K - v2.I * v1.K);
            double k = v1.I * v2.J - v2.I * v1.J;
            return new Vector(i, j, k);
        }
        public static Vector operator +(Vector v1, Vector v2) 
        {
            return new Vector(v1.I + v2.I, v1.J + v2.J, v1.K + v2.K);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.I - v2.I, v1.J - v2.J, v1.K - v2.K);
        }
        public static bool operator ==(Vector v1, Vector v2)
        {
            return (v1.I == v2.I && v1.J == v2.J && v1.K == v2.K);
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }
    }

}
