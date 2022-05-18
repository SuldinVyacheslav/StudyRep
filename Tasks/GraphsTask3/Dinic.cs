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
        public List<List<OrEdge>> GraphList;
        public int VertexNum;
        public List<int> Level, Iteration;

        public Dinic(int vertexes)
        {
            VertexNum = vertexes;
            GraphList = new List<List<OrEdge>>();
            Level = new List<int>();
            Iteration = new List<int>();
            for (int i = 0; i < VertexNum; ++i)
            {
                GraphList.Add(new List<OrEdge>());
                Level.Add(0);
                Iteration.Add(0);
            }
        }

        public void AddEdge(int from, int to, int cap)
        {
            GraphList[from].Add(new OrEdge(to, cap, GraphList[to].Count));
            GraphList[to].Add(new OrEdge(from, 0, GraphList[from].Count - 1));
        }

        public int MaxFlow(int s, int t)
        {
            int flow = 0;
            while (true)
            {
                BFS(s);
                if (Level[t] < 0)
                {
                    return flow;
                }
                for (int i = 0; i < VertexNum; ++i)
                {
                    Iteration[i] = 0;
                }
                var f = DFS(s, t, int.MaxValue);
                while (f > 0) 
                {
                    flow += f;
                    f = DFS(s, t, int.MaxValue);
                }
            }
        }
        void BFS(int s)
        {
            for (int i = 0; i < VertexNum; ++i)
            {
                Level[i] = -1;
            }
                
            Level[s] = 0;
            var que = new Queue<int>();
            que.Enqueue(s);

            while (que.Count != 0)
            {
                var v = que.Dequeue();
                for (int i = 0; i < GraphList[v].Count; i++)
                {
                    var e = GraphList[v][i];
                    if (e.Capacity > 0 && Level[e.To] < 0)
                    {
                        Level[e.To] = Level[v] + 1;
                        que.Enqueue(e.To);
                    }

                }

            }

        }
        int DFS(int v, int t, int f)
        {
            if (v == t) 
            {
                return f;
            }
            for (int i = Iteration[v]; i < GraphList[v].Count; i++)
            {
                Iteration[v] = i;
                var e = GraphList[v][i];
                if (e.Capacity > 0 && Level[v] < Level[e.To])
                {
                    var d = DFS(e.To, t, Math.Min(f, e.Capacity));
                    if (d > 0)
                    {
                        e.Capacity -= d;
                        GraphList[e.To][e.Opposite].Capacity += d;
                        return d;
                    }
                }
            }
            return 0;
        }
    }

}
