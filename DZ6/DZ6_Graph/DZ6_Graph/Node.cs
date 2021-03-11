using System.Collections.Generic;

namespace DZ6_Graph
{
    public class Node
    {
        public string Name { get; set; }

        public List<Edge> Edges { get; set; }

        public bool IsPassed { get; set; }

        public int WaveNumber { get; set; }

        public Node(string nodeName)
        {
            Name = nodeName;
            Edges = new List<Edge>();
            IsPassed = false;
        }
    }
}
