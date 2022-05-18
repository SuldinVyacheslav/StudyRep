using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public class Graph
    {
        static int num = 0;
        public int number;
        public List<Edge> Edges;

        public List<Vertex> Vertexes;
        public Graph(List<Vertex> vertexes)
        {
            num++;
            number = num;
            Edges = new List<Edge>();
            Vertexes = new List<Vertex>(vertexes);
        }

        public Graph(List<Edge> edges)
        {
            num++;
            number = num;
            Edges = new List<Edge>();
            Vertexes = new List<Vertex>();

            foreach (Edge edge in edges)
            {
                AddEdge(edge);
                if (!Vertexes.Contains(edge.X)) Vertexes.Add(edge.X);
                if (!Vertexes.Contains(edge.Y)) Vertexes.Add(edge.Y);
            }

            Edges.Sort((Edge x, Edge y) => (x.Value >= y.Value ? (x.Value > y.Value ? 1 : 0) : -1));
        }
        public void AddEdge(Edge edge)
        {
            Edges.Add(new Edge(edge.Value, edge.X, edge.Y));

            for (int i = Edges.Count - 1; i > 1 && Edges[i].Value < Edges[i-1].Value; i--)
            {
                var temp = Edges[i - 1];
                Edges[i - 1] = Edges[i];
                Edges[i] = temp;
            }

        }
    }
    
}
