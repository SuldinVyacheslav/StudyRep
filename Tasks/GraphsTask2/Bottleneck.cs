using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask2
{
    public class Bottleneck
    {
        public Graph GetSpanningTree(Graph graph)
        {
            if (graph.Vertexes.Count == 0) return new Graph(new List<Edge>());
            if (graph.Vertexes.Count == 1) return new Graph(new List<Vertex>() { graph.Vertexes.First() });
            List<Edge> resulting = new List<Edge>();
            List<Edge> less = new List<Edge>();
            List<Edge> more = new List<Edge>();
            Graph copy = new Graph(graph.Edges);

            while (resulting.Count != graph.Vertexes.Count - 1)
            {

                double median = (double)copy.Edges.Select(x => x.Value).ToArray().Sum() / copy.Edges.Count;

                less = new List<Edge>(copy.Edges.Where(x => x.Value < median));
                more = new List<Edge>(copy.Edges.Where(x => x.Value >= median));

                if (less.Count == 0)
                {
                    less = new List<Edge>(more.SkipLast(more.Count/2));
                    more = new List<Edge>(more.TakeLast(more.Count/2));
                }

                if (less.Select(x => x.Y).Concat(less.Select(x => x.X)).Distinct().Count() == copy.Vertexes.Count && copy.Edges.Count != 1)
                {
                    copy = new Graph(less);
                }
                else
                {
                    resulting.AddRange(less);
                    copy = new Graph(more);
                }
            }
            return new Graph(resulting);
        }
    }
}
