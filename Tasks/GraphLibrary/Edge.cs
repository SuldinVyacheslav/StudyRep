using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class Edge
    {
        public Vertex X;
        public Vertex Y;

        public int Value;

        public Edge(int value, Vertex x, Vertex y)
        {
            X = x; Y = y;
            Value = value;
        }
    }
}
