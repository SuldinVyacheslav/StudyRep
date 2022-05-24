using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask2
{
    public class Component
    {
        public List<Vertex> Vertexes = new List<Vertex>();

        public Component()
        {
        }

        public Component(List<Vertex> vertices)
        {
            Vertexes.AddRange(vertices);
        }

        public Component(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
    }

    public class Kruskal
    {
        public Graph GetSpanningTree(Graph graph)
        {
            Graph spanningTree = new Graph(graph.Vertexes.ToList());

            List<Component> components = new List<Component>();

            foreach (Vertex vertex in graph.Vertexes)
            {
                components.Add(new Component(vertex));
            }

            foreach (Edge edge in graph.Edges)
            {
                if (components.Count == 1) break;

                Component first = new Component();
                Component second = new Component();
                for (int i = 0; first.Vertexes.Count == 0 || second.Vertexes.Count == 0; i++)
                {
                    if (components[i].Vertexes.Contains(edge.X))
                    {
                        first = components[i];
                    }
                    if (components[i].Vertexes.Contains(edge.Y))
                    {
                        second = components[i];
                    }
                }

                if (first.Vertexes.Count != 0 || second.Vertexes.Count != 0)
                {
                    components.Remove(first);
                    components.Remove(second);
                    components.Add(new Component(first.Vertexes.Concat(second.Vertexes).ToList()));
                    spanningTree.AddEdge(edge);
                }
            }
            return spanningTree;
        }
    }
}
