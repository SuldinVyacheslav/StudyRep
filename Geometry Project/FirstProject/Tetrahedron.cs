using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Tetrahedron : Figure
    {
        public Dot Top;
        public Tetrahedron(Dot A, Dot B, Dot C)
        {
            this.Vectors = new Vector[3];
            this.Vertex = new Dot[4];
            this.Edges = new Edge[6];


            Vertex[0] = A;
            Vertex[1] = B;

            Vector a = Vector.ByTwoDots(A, B);
            Vectors[0] = a;
            Vector b = Vector.ByTwoDots(A, C);

            Vector N = ((a | b) | a) * (1 / ((a | b) | a).Length);

            Vectors[1] = N + a * (1 / a.Length) * (Math.Sqrt(3) / 3);

            Vertex[2] = Vertex[0].SetAside(Vectors[1] * a.Length *(1/Vectors[1].Length));

           

            

            Vectors[2] = (a | b) * (1 / (a | b).Length) * a.Length * (Math.Sqrt(6) / 3);


            Dot O = Dot.GetMiddle(A, B).SetAside(N * (Math.Sqrt(3)/2) * (a.Length/3));

            Vertex[3] = O.SetAside(Vectors[2]);


            Edges[0] = new Edge(Vertex[0],Vertex[1]);
            Edges[1] = new Edge(Vertex[1], Vertex[2]);
            Edges[2] = new Edge(Vertex[2], Vertex[3]);
            Edges[3] = new Edge(Vertex[1], Vertex[3]);
            Edges[4] = new Edge(Vertex[0], Vertex[2]);
            Edges[5] = new Edge(Vertex[0], Vertex[3]);

            Console.WriteLine();
        }
    }
}
