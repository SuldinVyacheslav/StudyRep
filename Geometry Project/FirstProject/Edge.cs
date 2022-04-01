using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class Edge
    {
        public Dot Fr;
        public Dot Sc;

        public Edge(Dot fr, Dot sc)
        {
            this.Fr = fr;
            this.Sc = sc;
        }
    }
}
