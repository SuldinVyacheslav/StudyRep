using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class VertexNeighborInfo
    {
        public readonly List<OrEdge> Neighbors;
        public int NumberOfNeighbors => Neighbors.Count;
        public VertexNeighborInfo()
        {
            Neighbors = new List<OrEdge>();
        }

        public OrEdge this[int index] { get => Neighbors[index]; set => Neighbors[index] = value; }

        public bool Add(OrEdge orEdge)
        {
            if (!Neighbors.Contains(orEdge))
            {
                Neighbors.Add(orEdge);
                return true;
            }
            return false;
        }
    }
}
