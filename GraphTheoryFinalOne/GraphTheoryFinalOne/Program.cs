using System;

namespace GraphTheoryFinalOne
{
    class Program
    {
        private const string ADJACENCY_MATRIX_FILE_PATH = @".\input.txt";

        static void Main(string[] args)
        {
            var adjMatrix = Helpers.Helper.InitAdjacencyMatrix(ADJACENCY_MATRIX_FILE_PATH);
            Helpers.Helper.PrintToScreen(adjMatrix);
        }
    }
}
