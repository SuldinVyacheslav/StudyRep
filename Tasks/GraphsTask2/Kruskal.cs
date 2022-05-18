using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask2
{
    public class Kruskal
    {
        public Graph GetSpanningTree(Graph graph)
        {
            Graph spanningTree = new Graph(graph.Vertexes.ToList());


            List<List<Vertex>> components = new List<List<Vertex>>();

            foreach (Vertex vertex in graph.Vertexes)
            {
                components.Add(new List<Vertex> { vertex });
            }

            foreach (Edge edge in graph.Edges)
            {
                if (components.Count == 1) break;

                List<Vertex> first = new List<Vertex>();
                List<Vertex> second = new List<Vertex>();
                for (int i = 0; first.Count == 0 || second.Count == 0; i++)
                {
                    if (components[i].Contains(edge.X))
                    {
                        first = components[i];
                    }
                    if (components[i].Contains(edge.Y))
                    {
                        second = components[i];
                    }
                }

                if (first.Count != 0 || second.Count != 0)
                {
                    components.Remove(first);
                    components.Remove(second);
                    components.Add(first.Concat(second).ToList());
                    spanningTree.AddEdge(edge);
                }
            }
            return spanningTree;
        }
    }
}
