namespace GraphTheoryFinalOne.Models
{
    public class AdjacencyMatrix
    {
        public AdjacencyMatrix(int n, int[,] amArray)
        {
            N = n;
            Array = amArray;
        }

        public int N { get; set; }
        public int[,] Array { get; set; }
    }
}
