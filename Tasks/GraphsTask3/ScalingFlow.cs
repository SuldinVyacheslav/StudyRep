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
        List<VertexNeighborInfo> graphList;
        int source, sink;
        bool[] visited;
        int delta;

        public ScalingFlow(int[,] adjacencyMatrix)
            : this(adjacencyMatrix.GetLength(0) == adjacencyMatrix.GetLength(1) ? adjacencyMatrix.GetLength(0) : -1)
        {
            if (graphList == null) return;
            for (int i = default; i < adjacencyMatrix.GetLength(0); i++)
                for (int j = default; j < adjacencyMatrix.GetLength(0); j++)
                    if (adjacencyMatrix[i, j] > 0)
                        if (!AddEdge(i, j, adjacencyMatrix[i, j])) return;
        }
        public ScalingFlow(int size)
        {
            if (size < 0) return;
            visited = new bool[size];
            graphList = new List<VertexNeighborInfo>();
            for (int i = default; i< size; i++)
            {
                graphList.Add(new VertexNeighborInfo());
            }
        }
        public bool AddEdge(int from, int to, int cap)
        {
            if (graphList.Count <= from || graphList.Count <= to) return false;
            graphList[from].Add(new OrEdge(from, to, cap, default));
            graphList[to].Add(new OrEdge(to, from, default, default));
            return true;
        }
        public int GetMaxFlow(int source, int sink)
        {
            if (graphList == null ||
                source >= graphList.Count || source < 0 ||
                sink >= graphList.Count || sink < 0)
                return -1;

            visited = new bool[graphList.Count];
            this.source = source;
            this.sink = sink;
            int maxFlow = default;

            delta = (int)Math.Pow(2, (int)(Math.Log2(graphList.Where(z => z.NumberOfNeighbors != default).Max(x => x.Neighbors.Max(y => y.Capacity)))));

            for (int flow = default; delta > 0; delta /= 2)
            {
                do
                {
                    
                    visited = Enumerable.Repeat(false, visited.Length).ToArray();
                    flow = DFS(this.source, int.MaxValue);
                    maxFlow += flow;
                }
                while (flow != default);
            }
            return maxFlow;
        }
        public int DFS(int node, int flow)
        {
            if (node == sink)
            {
                return flow;
            }

            visited[node] = true;

            foreach (OrEdge edge in graphList[node].Neighbors)
            {
                int remainingCapacity = edge.Capacity - edge.FlowValue;
                if (remainingCapacity >= delta && !visited[edge.To])
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
