using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Cube : Figure
    {
        public Cube(Dot A, Dot B, Dot C)
        {
            this.Vectors = new Vector[3];
            this.Vertex = new Dot[8];
            this.Edges = new Edge[12];

            Vertex[0] = A;
            Vertex[1] = B;
            

            Vector a = Vector.ByTwoDots(A, B);
            Vectors[0] = a;
            Vector b = Vector.ByTwoDots(A, C);

            Vectors[1] = (a | b) * a.Length * (1 / (a | b).Length);
            Vertex[2] = A.SetAside(Vectors[1]);

            Vector N = ((a | b) | a);

            Vectors[2] = N * a.Length * (1 / N.Length);
            Vertex[3] = Vertex[2].SetAside(Vectors[2]);
            Vertex[4] = Vertex[2].SetAside(Vectors[0]);
            Vertex[5] = Vertex[0].SetAside(Vectors[2]);
            Vertex[6] = Vertex[5].SetAside(Vectors[0]);
            Vertex[7] = Vertex[6].SetAside(Vectors[1]);

            Edges[0] = new Edge(Vertex[0], Vertex[1]);
            Edges[1] = new Edge(Vertex[0], Vertex[2]);
            Edges[2] = new Edge(Vertex[0], Vertex[5]);
            Edges[3] = new Edge(Vertex[2], Vertex[4]);
            Edges[4] = new Edge(Vertex[2], Vertex[3]);
            Edges[5] = new Edge(Vertex[1], Vertex[4]);
            Edges[6] = new Edge(Vertex[1], Vertex[6]);
            Edges[7] = new Edge(Vertex[5], Vertex[3]);
            Edges[8] = new Edge(Vertex[5], Vertex[6]);
            Edges[9] = new Edge(Vertex[7], Vertex[4]);
            Edges[10] = new Edge(Vertex[7], Vertex[6]);
            Edges[11] = new Edge(Vertex[7], Vertex[3]);


            Console.WriteLine();
        }
    }
}
