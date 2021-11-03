using System.Collections.Generic;

namespace GraphTheoryFinalOne.Models
{
    public class AdjacencyList
    {
        public AdjacencyList(int n)
        {
            N = n;
            AdjacentVertices = new LinkedList<int>[n];

            for (int i = 0; i < AdjacentVertices.Length; i++)
            {
                AdjacentVertices[i] = new LinkedList<int>();
            }
        }

        public int N { get; set; }
        public LinkedList<int>[] AdjacentVertices { get; set; }

        public int BridgeVertice { get; set; }
    }
}
