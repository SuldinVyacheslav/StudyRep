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
        static List<int>[] graph;
        static int[] parentsList;
        static List<OrEdge> edges = new List<OrEdge>();

        public EdmondKarp(int size)
        {
            graph = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                graph[i] = new List<int>();
            }
            parentsList = new int[size];
        }
        public void AddEdge(int from, int to, int flow)
        {
            OrEdge fromEdge = new OrEdge(from, to, flow, 0);
            OrEdge toEdge = new OrEdge(to, from, 0, 0);
            graph[from].Add(edges.Count);
            edges.Add(fromEdge);
            graph[to].Add(edges.Count);
            edges.Add(toEdge);
        }
        public void BFS(int startNode, int endNode)
        {
            parentsList = Enumerable.Repeat((int)-1, graph.Length).ToArray(); 

            Queue<int> queue = new Queue<int>(); 
            queue.Enqueue(startNode);

            while (queue.Count != 0)
            {
                int currentNode = queue.Dequeue();

                for (int i = 0; i < graph[currentNode].Count; i++) 
                {
                    int idx = graph[currentNode][i]; 
                    OrEdge e = edges[idx];  
                    if (parentsList[e.To] == -1 && e.Capacity > e.FlowValue && e.To != startNode)
                    {
                        parentsList[e.To] = idx;
                        if (e.To == endNode) 
                            return;
                        queue.Enqueue(e.To);
                    }
                }
            }
        }

        public int GetMaxFlow(int startNode, int endNode)
        {
            int maxFlow = 0;
            while (true)
            {
                BFS(startNode, endNode); 
                if (parentsList[endNode] == -1)
                {
                    break;
                }
                int flow = int.MaxValue;
                for (int node = parentsList[endNode]; node != -1; node = parentsList[edges[node].From]) 
                {
                    flow = Math.Min(flow, edges[node].Capacity - edges[node].FlowValue);
                }
                maxFlow += flow;
                int currentNode = parentsList[endNode];
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
