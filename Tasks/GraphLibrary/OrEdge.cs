using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class OrEdge
    {
        public int To;
        public int From;
        public int Opposite;
        public int FlowValue;
        public int Capacity;

        public OrEdge(int to, int cap, int opposite)
        {
            To = to;
            Capacity = cap;
            Opposite = opposite;
        }
        public OrEdge(int from, int to, int cap, int flow)
        {
            From = from;
            To = to;
            Capacity = cap;
            FlowValue = flow;
        }

    }
}
