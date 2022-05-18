using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask2
{
    public class Dijkstra
    {
        public Dictionary<Vertex, int>  GetMinPath(Graph graph, Vertex vertex)
        {
            if (!graph.Vertexes.Contains(vertex)) return null;

            List<Vertex> marked = new List<Vertex>() {};

            Dictionary<Vertex, int> dict = new Dictionary<Vertex, int>();

            foreach (var vert in graph.Vertexes)
            {
                dict.Add(vert, int.MaxValue);
            }

            Vertex key = vertex;
            dict[key] = 0;

            while (marked.Count != graph.Vertexes.Count)
            {
                Edge minEdge = new Edge(int.MaxValue, null, null);
                foreach (var edge in graph.Edges.Where(x => (x.X == key && !marked.Contains(x.Y) 
                || (x.Y == key && !marked.Contains(x.X) ))))
                {
                    if (edge.Value < minEdge.Value) minEdge = edge;

                    if (edge.Y == key)
                    {
                        dict[edge.X] = Math.Min(edge.Value + dict[edge.Y], dict[edge.X]);
                    }
                    else
                    {
                        dict[edge.Y] = Math.Min(edge.Value + dict[edge.X], dict[edge.Y]);
                    }

                }
                marked.Add(key);
                key = minEdge.X == key? minEdge.Y : minEdge.X;
            }

            return dict;
        }
    }
}
