using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask2
{
    public class Prim
    {
        public Graph GetSpanningTree(Graph core)
        {
            if (core.Vertexes == null) return null;

            if (core.Vertexes.Count == 0 || core.Edges.Count == 0) return new Graph(core.Vertexes);

            List<Vertex> U = new List<Vertex>() { core.Vertexes.First() };
            List<Edge> T = new List<Edge>();

            while (U.Count != core.Vertexes.Count)
            {
                Edge minEdge = new Edge(int.MaxValue,null,null);
                foreach (Edge edge in core.Edges)
                {
                    if ((U.Contains(edge.X) ^ U.Contains(edge.Y))  && !T.Contains(edge) && minEdge.Value > edge.Value)
                    {
                        minEdge = edge;
                    }
                }
                if (minEdge.X == null)
                {
                    U.Add(core.Vertexes.Where(x => !U.Contains(x)).First());
                    continue;
                }
                T.Add(minEdge);
                if (U.Contains(minEdge.X))
                {
                    U.Add(minEdge.Y);
                }
                else
                {
                    U.Add(minEdge.X);
                }

            }
            return new Graph(T);
        }
    }
}
