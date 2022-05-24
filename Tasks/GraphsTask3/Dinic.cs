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
        public List<VertexNeighborInfo> GraphList;
        public List<int> Level, Iteration;

        public Dinic(int vertexes)
        {
            GraphList = new List<VertexNeighborInfo>();
            Level = new List<int>();
            Iteration = new List<int>();
            for (int i = default; i < vertexes; ++i)
            {
                GraphList.Add(new VertexNeighborInfo());
                Level.Add(default);
                Iteration.Add(default);
            }
        }

        public bool AddEdge(int from, int to, int cap)
        {
            if (GraphList.Count <= from || GraphList.Count <= to) return false;
            GraphList[from].Add(new OrEdge(to, cap, GraphList[to].NumberOfNeighbors));
            GraphList[to].Add(new OrEdge(from, default, GraphList[from].NumberOfNeighbors - 1));
            return true;
        }

        public int MaxFlow(int source, int sink)
        {
            int maxFlow = default;
            while (true)
            {
                BFS(source);
                if (Level[sink] < 0)
                {
                    return maxFlow;
                }
                for (int i = default; i < GraphList.Count; ++i)
                {
                    Iteration[i] = default;
                }
                int dfsResult = DFS(source, sink, int.MaxValue);
                while (dfsResult > 0) 
                {
                    maxFlow += dfsResult;
                    dfsResult = DFS(source, sink, int.MaxValue);
                }
            }
        }
        void BFS(int start)
        {
            for (int i = default; i < GraphList.Count; ++i)
            {
                Level[i] = -1;
            }
                
            Level[start] = default;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count != default)
            {
                int v = queue.Dequeue();
                for (int i = default; i < GraphList[v].NumberOfNeighbors; i++)
                {
                    OrEdge edge = GraphList[v][i];
                    if (edge.Capacity > 0 && Level[edge.To] < 0)
                    {
                        Level[edge.To] = Level[v] + 1;
                        queue.Enqueue(edge.To);
                    }

                }

            }

        }
        int DFS(int v, int t, int f)
        {
            if (v == t) return f;

            for (int i = Iteration[v]; i < GraphList[v].NumberOfNeighbors; i++)
            {
                Iteration[v] = i;
                OrEdge edge = GraphList[v][i];
                if (edge.Capacity > 0 && Level[v] < Level[edge.To])
                {
                    int dfsResult = DFS(edge.To, t, Math.Min(f, edge.Capacity));
                    if (dfsResult > 0)
                    {
                        edge.Capacity -= dfsResult;
                        GraphList[edge.To][edge.Opposite].Capacity += dfsResult;
                        return dfsResult;
                    }
                }
            }
            return default;
        }
    }

}
