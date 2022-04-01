using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Pyramid : Figure
    {
        public Pyramid(Dot A, Dot B, Dot C)
        {
            this.Vectors = new Vector[3];
            this.Vertex = new Dot[5];
            this.Edges = new Edge[8];

            Vertex[0] = A;
            Vertex[1] = B;

            Vector a = Vector.ByTwoDots(A, B);
            Vectors[0] = a;
            Vector b = Vector.ByTwoDots(A, C);

            Vectors[1] = (a | b) * (1 / (a | b).Length) * a.Length * (1/Math.Sqrt(2));

            Vector N = ((a | b) | a);
            Vectors[2] = N * a.Length * (1 / N.Length);

            Vertex[2] = Vertex[0].SetAside(Vectors[2]);
            Vertex[3] = Vertex[2].SetAside(Vectors[0]);

            Dot mid = Dot.GetMiddle(Vertex[0], Vertex[3]);

            Vertex[4] = mid.SetAside(Vectors[1]);

            Edges[0] = new Edge(Vertex[0], Vertex[1]);
            Edges[1] = new Edge(Vertex[0], Vertex[2]);
            Edges[2] = new Edge(Vertex[2], Vertex[3]);
            Edges[3] = new Edge(Vertex[1], Vertex[3]);
            Edges[4] = new Edge(Vertex[0], Vertex[4]);
            Edges[5] = new Edge(Vertex[1], Vertex[4]);
            Edges[6] = new Edge(Vertex[2], Vertex[4]);
            Edges[7] = new Edge(Vertex[3], Vertex[4]);

            Console.WriteLine();
        }
    }
}
