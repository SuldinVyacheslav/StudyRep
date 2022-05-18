using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask3
{
    public class ScalingFlow
    {
        public List<OrEdge>[] GraphList;
        public int Source;
        public int Sink;
        public bool[] Marked;
        public int Delta;

        public ScalingFlow(int vertexes)
        {
            GraphList = new List<OrEdge>[vertexes];
            for (int i = 0; i< GraphList.Length; i++)
            {
                GraphList[i] = new List<OrEdge>();
            }
        }
        public void AddEdge(int from, int to, int cap)
        {
            OrEdge fromEdge = new OrEdge(from, to, cap, 0);
            OrEdge toEdge = new OrEdge(to, from, 0, 0);
            GraphList[from].Add(fromEdge);
            GraphList[to].Add(toEdge);
        }
        public int GetMaxFlow(int s, int t)
        {
            Marked = new bool[GraphList.Length];
            Source = s;
            Sink = t;
            int flow = 0;

            Delta = (int)Math.Pow(2, (int)(Math.Log2(GraphList.Where(z => z.Count != 0).Max(x => x.Max(y => y.Capacity)))));

            for (int f = 0; Delta > 0; Delta /= 2)
            {
                do
                {
                    for (int i = 0; i < Marked.Length; i++)
                    {
                        Marked[i] = false;
                    }
                    f = DFS(Source, int.MaxValue);
                    flow += f;
                }
                while (f != 0);
            }
            return flow;
        }
        public int DFS(int node, int flow)
        {
            if (node == Sink)
            {
                return flow;
            }
            List<OrEdge> edges = GraphList[node];
            Marked[node] = true;

            foreach (OrEdge edge in edges)
            {
                int remainingCapacity = edge.Capacity - edge.FlowValue;
                if (remainingCapacity >= Delta && !Marked[edge.To])
                {
                    int min = DFS(edge.To, Math.Min(flow, remainingCapacity));
                        
                    if (min > 0)
                    {
                        edge.FlowValue += min;
                        return min;
                    }
                }
            }
            return 0;
        }
    }
}
