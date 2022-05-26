using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;

namespace GraphsTask3
{

    public class EdmondKarp
    {
        List<int>[] graph;
        int[] parentsList;
        List<OrEdge> edges = new List<OrEdge>();

        public EdmondKarp(int[,] adjacencyMatrix)
            : this(adjacencyMatrix.GetLength(0) == adjacencyMatrix.GetLength(1) ? adjacencyMatrix.GetLength(0) : -1)
        {
            if (graph == null) return;
            for (int i = default; i < adjacencyMatrix.GetLength(0); i++)
                for (int j = default; j < adjacencyMatrix.GetLength(0); j++)
                    if (adjacencyMatrix[i, j] > 0)
                        if (!AddEdge(i, j, adjacencyMatrix[i, j])) return;
        }

        public EdmondKarp(int size)
        {
            if (size < 0) return;

            graph = new List<int>[size];
            for (int i = default; i < size; i++)
            {
                graph[i] = new List<int>();
            }
            parentsList = new int[size];
        }
        public bool AddEdge(int from, int to, int flow)
        {
            if (graph.Length <= from || graph.Length <= to) return false;
            graph[from].Add(edges.Count);
            edges.Add(new OrEdge(from, to, flow, default));
            graph[to].Add(edges.Count);
            edges.Add(new OrEdge(to, from, default, default));
            return true;
        }
        public void BFS(int startNode, int endNode)
        {
            parentsList = Enumerable.Repeat(-1, graph.Length).ToArray(); 

            Queue<int> queue = new Queue<int>(); 
            queue.Enqueue(startNode);

            while (queue.Count != default)
            {
                int currentNode = queue.Dequeue();

                for (int i = default; i < graph[currentNode].Count; i++) 
                {
                    int idx = graph[currentNode][i]; 
                    OrEdge edge = edges[idx];  
                    if (parentsList[edge.To] == -1 && edge.Capacity > edge.FlowValue && edge.To != startNode)
                    {
                        parentsList[edge.To] = idx;

                        if (edge.To == endNode) return;

                        queue.Enqueue(edge.To);
                    }
                }
            }
        }

        public int GetMaxFlow(int source, int sink)
        {
            if (graph == null ||
                source >= graph.Length || source < 0 ||
                sink >= graph.Length || sink < 0)
                return -1;

            int maxFlow = default;
            while (true)
            {
                BFS(source, sink); 
                if (parentsList[sink] == -1)
                {
                    break;
                }
                int flow = int.MaxValue;
                for (int node = parentsList[sink]; node != -1; node = parentsList[edges[node].From]) 
                {
                    flow = Math.Min(flow, edges[node].Capacity - edges[node].FlowValue);
                }
                maxFlow += flow;
                int currentNode = parentsList[sink];
                while (currentNode != -1)
                {
                    edges[currentNode].FlowValue += flow;
                    edges[currentNode ^ 1].FlowValue -= flow;
                    currentNode = parentsList[edges[currentNode].From];
                }
            }
            return maxFlow;
        }

    }
}
