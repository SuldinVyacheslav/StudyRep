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
        int graphLenght;

        public bool DFS(int[,] residualNet, int source, int sink, int[] path)
        {
            bool[] visited = Enumerable.Repeat(false, residualNet.GetLength(0)).ToArray();

            Stack<int> vertexStack = new Stack<int>();
            vertexStack.Push(source);

            while (vertexStack.Count > 0)
            {
                int vertex = vertexStack.Pop();

                if (visited[vertex])
                    continue;

                visited[vertex] = true;
                path[source] = -1;
                for (int neighbour = default; neighbour < residualNet.GetLength(0); neighbour++)
                {
                    if (residualNet[vertex, neighbour] > 0 && visited[neighbour] == false)
                    {
                        if (neighbour == sink)
                        {
                            path[neighbour] = vertex;
                            return true;
                        }
                        path[neighbour] = vertex;
                        vertexStack.Push(neighbour);
                    }
                }
            }
            return false;
        }
        public int GetMaxFlow(int[,] graph, int source, int sink)
        {
            if (graph.GetLength(0) != graph.GetLength(1) ||
                source >= graph.GetLength(0) || source < 0 ||
                sink >= graph.GetLength(0) || sink < 0 ) 
                return -1;

            graphLenght = graph.GetLength(default);

            int u, v;
            
            int[,] residualNet = new int[graphLenght, graphLenght];

            for (u = default; u < graphLenght; u++)
                for (v = default; v < graphLenght; v++)
                    residualNet[u, v] = graph[u, v];

            int[] path = new int[graphLenght];

            int maxFlow = default;

            while (DFS(residualNet, source, sink, path))
            {
                int minPathFlow = int.MaxValue;
                for (v = sink; v != source; v = path[v])
                {
                    u = path[v];
                    minPathFlow = Math.Min(minPathFlow, residualNet[u, v]);
                }

                
                for (v = sink; v != source; v = path[v])
                {
                    u = path[v];
                    residualNet[u, v] -= minPathFlow;
                    residualNet[v, u] += minPathFlow;
                }

                maxFlow += minPathFlow;
            }

            return maxFlow;
        }
    }
}
