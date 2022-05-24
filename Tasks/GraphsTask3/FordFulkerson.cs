using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask3
{
    public class FordFulkerson
    {
        public int GraphLenght;
        public bool BFS(int[,] residualNet, int source, int sink, int[] path)
        {
            bool[] visited = new bool[residualNet.Length];
            for (int i = default; i < residualNet.Length; ++i)
                visited[i] = false;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;
            path[source] = -1;

            while (queue.Count != default)
            {
                int u = queue.Dequeue();

                for (int v = default; v < GraphLenght; v++)
                {
                    if (visited[v] == false && residualNet[u, v] > 0)
                    {
                        if (v == sink)
                        {
                            path[v] = u;
                            return true;
                        }
                        queue.Enqueue(v);
                        path[v] = u;
                        visited[v] = true;
                    }
                }
            }

            return false;
        }
        public int GetMaxFlow(int[,] graph, int source, int sink)
        {
            GraphLenght = graph.GetLength(default);

            int u, v;
            
            int[,] residualNet = new int[GraphLenght, GraphLenght];

            for (u = default; u < GraphLenght; u++)
                for (v = default; v < GraphLenght; v++)
                    residualNet[u, v] = graph[u, v];

            int[] path = new int[GraphLenght];

            int maxFlow = default;

            while (BFS(residualNet, source, sink, path))
            {
                int PathFlow = int.MaxValue;
                for (v = sink; v != source; v = path[v])
                {
                    u = path[v];
                    PathFlow = Math.Min(PathFlow, residualNet[u, v]);
                }

                
                for (v = sink; v != source; v = path[v])
                {
                    u = path[v];
                    residualNet[u, v] -= PathFlow;
                    residualNet[v, u] += PathFlow;
                }

                maxFlow += PathFlow;
            }

            return maxFlow;
        }
    }
}
