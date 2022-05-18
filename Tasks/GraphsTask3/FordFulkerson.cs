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
        public bool BFS(int[,] residualNet, int s, int t, int[] path)
        {
            bool[] visited = new bool[residualNet.Length];
            for (int i = 0; i < residualNet.Length; ++i)
                visited[i] = false;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            path[s] = -1;

            while (queue.Count != 0)
            {
                int u = queue.Dequeue();

                for (int v = 0; v < GraphLenght; v++)
                {
                    if (visited[v] == false && residualNet[u, v] > 0)
                    {
                        if (v == t)
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
        public int GetMinFlow(int[,] graph, int s, int t)
        {
            GraphLenght = graph.GetLength(0);

            int u, v;
            
            int[,] residualNet = new int[GraphLenght, GraphLenght];

            for (u = 0; u < GraphLenght; u++)
                for (v = 0; v < GraphLenght; v++)
                    residualNet[u, v] = graph[u, v];

            int[] path = new int[GraphLenght];

            int maxFlow = 0;

            while (BFS(residualNet, s, t, path))
            {
                int PathFlow = int.MaxValue;
                for (v = t; v != s; v = path[v])
                {
                    u = path[v];
                    PathFlow = Math.Min(PathFlow, residualNet[u, v]);
                }

                
                for (v = t; v != s; v = path[v])
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
