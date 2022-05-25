using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask3
{
    public class Dinic
    {
        List<VertexNeighborInfo> graphList;
        List<int> layer, pointer;

        public Dinic(int[,] adjacencyMatrix) 
            : this(adjacencyMatrix.GetLength(0) == adjacencyMatrix.GetLength(1) ? adjacencyMatrix.GetLength(0)  : -1)
        {
            if (graphList == null) return;
            for (int i = default; i < adjacencyMatrix.GetLength(0); i++)
                for (int j = default; j < adjacencyMatrix.GetLength(0); j++)
                    if (adjacencyMatrix[i, j] > 0)
                        if (!AddEdge(i, j, adjacencyMatrix[i, j])) return;
        }
        public Dinic(int size)
        {
            if (size < 0) return;
            
            graphList = new List<VertexNeighborInfo>();
            layer = new List<int>();
            pointer = new List<int>();
            for (int i = default; i < size; ++i)
            {
                graphList.Add(new VertexNeighborInfo());
                layer.Add(default);
                pointer.Add(default);
            }
        }

        public bool AddEdge(int from, int to, int cap)
        {
            if (graphList.Count <= from || graphList.Count <= to) return false;
            graphList[from].Add(new OrEdge(to, cap, graphList[to].NumberOfNeighbors));
            graphList[to].Add(new OrEdge(from, default, graphList[from].NumberOfNeighbors - 1));
            return true;
        }

        public int MaxFlow(int source, int sink)
        {
            if (graphList == null || 
                source >= graphList.Count || source < 0 ||
                sink >= graphList.Count || sink < 0)
                return -1;

            int maxFlow = default;
            while (true)
            {
                BFS(source);
                if (layer[sink] < 0)
                {
                    return maxFlow;
                }

                pointer = Enumerable.Repeat((int)default, graphList.Count).ToList();
                
                int dfsResult = DFS(source, sink, int.MaxValue);
                while (dfsResult > 0) 
                {
                    maxFlow += dfsResult;
                    dfsResult = DFS(source, sink, int.MaxValue);
                }
            }
        }
        public void BFS(int start)
        {

            layer = Enumerable.Repeat( -1, graphList.Count).ToList();
                
            layer[start] = default;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count != default)
            {
                int v = queue.Dequeue();
                for (int i = default; i < graphList[v].NumberOfNeighbors; i++)
                {
                    OrEdge edge = graphList[v][i];
                    if (edge.Capacity > 0 && layer[edge.To] < 0)
                    {
                        layer[edge.To] = layer[v] + 1;
                        queue.Enqueue(edge.To);
                    }

                }

            }

        }
        public int DFS(int v, int t, int f)
        {
            if (v == t) return f;

            for (int i = pointer[v]; i < graphList[v].NumberOfNeighbors; i++)
            {
                pointer[v] = i;
                OrEdge edge = graphList[v][i];
                if (edge.Capacity > 0 && layer[v] < layer[edge.To])
                {
                    int dfsResult = DFS(edge.To, t, Math.Min(f, edge.Capacity));
                    if (dfsResult > 0)
                    {
                        edge.Capacity -= dfsResult;
                        graphList[edge.To][edge.Opposite].Capacity += dfsResult;
                        return dfsResult;
                    }
                }
            }
            return default;
        }
    }

}
