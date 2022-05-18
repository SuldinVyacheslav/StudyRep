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
        List<List<OrEdge>> G;
        int V;
        List<int> level;
        List<int> iter;

        public Dinic(int vertexes)
        {
            V = vertexes;
            G = new List<List<OrEdge>>();
            level = new List<int>();
            iter = new List<int>();
            for (int i = 0; i < V; ++i)
            {
                G.Add(new List<OrEdge>());
                level.Add(0);
                iter.Add(0);
            }
        }

        public void AddEdge(int from, int to, int cap)
        {
            G[from].Add(new OrEdge(to, cap, G[to].Count)); // G[to].Count is index of reverse edge in to list
            G[to].Add(new OrEdge(from, 0, G[from].Count - 1)); // G[from].Count - 1 is index of reverse edge in from list
        }

        public int MaxFlow(int s, int t)
        {
            int flow = 0;
            while (true) // O(V**2 * E)
            {
                BFS(s); // O(E)
                if (level[t] < 0)
                    return flow;
                for (int i = 0; i < V; ++i)
                    iter[i] = 0;
                var f = DFS(s, t, int.MaxValue); // O(V + E)
                while (f > 0) // O(VE)
                {
                    flow += f;
                    f = DFS(s, t, int.MaxValue); // O(E)
                }
            }
        }
        void BFS(int s)
        {
            for (int i = 0; i < V; ++i)
                level[i] = -1;
            level[s] = 0;
            var que = new Queue<int>();
            que.Enqueue(s);

            while (que.Count != 0)
            {
                var v = que.Dequeue();
                for (int i = 0; i < G[v].Count; i++)
                {
                    var e = G[v][i];
                    if (e.Capacity > 0 && level[e.To] < 0)
                    {
                        level[e.To] = level[v] + 1;
                        que.Enqueue(e.To);
                    }

                }

            }

        }
        int DFS(int v, int t, int f)
        {
            if (v == t) return f;
            for (int i = iter[v]; i < G[v].Count; i++)
            {
                iter[v] = i;
                var e = G[v][i];
                if (e.Capacity > 0 && level[v] < level[e.To])
                {
                    var d = DFS(e.To, t, Math.Min(f, e.Capacity));
                    if (d > 0)
                    {
                        e.Capacity -= d;
                        G[e.To][e.Opposite].Capacity += d;
                        return d;
                    }
                }
            }
            return 0;
        }
    }

}
