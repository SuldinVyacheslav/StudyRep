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
            if (graph.Vertexes == null) return null;

            Graph spanningTree = new Graph(graph.Vertexes.ToList());
            if (graph.Vertexes.Count == 0 || graph.Edges.Count == 0) return spanningTree;

            List<Component> components = new List<Component>();

            foreach (Vertex vertex in graph.Vertexes)
            {
                components.Add(new Component(vertex));
            }

            graph.Edges.Sort((Edge x, Edge y) => x.Value >= y.Value ? (x.Value > y.Value ? 1 : 0) : -1);

            foreach (Edge edge in graph.Edges)
            {
                if (components.Count == 1) break;

                Component first = new Component();
                Component second = new Component();
                for (int i = 0; i < components.Count && (first.Vertexes.Count == 0 || second.Vertexes.Count == 0); i++)
                {
                    if (components[i].Vertexes.Contains(edge.X))
                    {
                        first = components[i];
                        continue;
                    }
                    if (components[i].Vertexes.Contains(edge.Y))
                    {
                        second = components[i];
                        continue;
                    }
                }

                if (first.Vertexes.Count != 0 && second.Vertexes.Count != 0)
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
