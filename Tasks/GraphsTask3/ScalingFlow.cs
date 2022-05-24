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
        public List<VertexNeighborInfo> GraphList;
        public int Source, Sink;
        public bool[] Visited;
        public int Delta;

        public ScalingFlow(int vertexes)
        {
            GraphList = new List<VertexNeighborInfo>();
            for (int i = default; i< vertexes; i++)
            {
                GraphList.Add(new VertexNeighborInfo());
            }
        }
        public bool AddEdge(int from, int to, int cap)
        {
            if (GraphList.Count <= from || GraphList.Count <= to) return false;
            GraphList[from].Add(new OrEdge(from, to, cap, default));
            GraphList[to].Add(new OrEdge(to, from, default, default));
            return true;
        }
        public int GetMaxFlow(int source, int sink)
        {
            Visited = new bool[GraphList.Count];
            Source = source;
            Sink = sink;
            int maxFlow = default;

            Delta = (int)Math.Pow(2, (int)(Math.Log2(GraphList.Where(z => z.NumberOfNeighbors != default).Max(x => x.Neighbors.Max(y => y.Capacity)))));

            for (int flow = default; Delta > 0; Delta /= 2)
            {
                do
                {
                    for (int i = default; i < Visited.Length; i++)
                    {
                        Visited[i] = false;
                    }
                    flow = DFS(Source, int.MaxValue);
                    maxFlow += flow;
                }
                while (flow != default);
            }
            return maxFlow;
        }
        public int DFS(int node, int flow)
        {
            if (node == Sink)
            {
                return flow;
            }

            Visited[node] = true;

            foreach (OrEdge edge in GraphList[node].Neighbors)
            {
                int remainingCapacity = edge.Capacity - edge.FlowValue;
                if (remainingCapacity >= Delta && !Visited[edge.To])
                {
                    int min = DFS(edge.To, Math.Min(flow, remainingCapacity));
                        
                    if (min > 0)
                    {
                        edge.FlowValue += min;
                        return min;
                    }
                }
            }
            return default;
        }
    }
}
