using System;
using GraphTheoryFinalOne.Handlers;
using GraphTheoryFinalOne.Helpers;

namespace GraphTheoryFinalOne
{
    class Program
    {
        private const string ADJACENCY_LIST_FILE_PATH = @".\Sources\input.txt";

        static void Main(string[] args)
        {
            var adjLists = Helper.InitAdjacencyList(ADJACENCY_LIST_FILE_PATH);
            foreach(var adjLst in adjLists)
            {
                var isEmptyGraph = GraphBiz.IsEmptyGraph(adjLst) ? $"k = {adjLst.N}" : "Khong";
                Console.WriteLine($"1. Do thi trong: {isEmptyGraph}");
                var isCycleGraph = GraphBiz.IsCycleGrap(adjLst) ? $"k = {adjLst.N}" : "Khong";
                Console.WriteLine($"2. Do thi vong: {isEmptyGraph}");
                Console.WriteLine($"3. Do thi hinh con buom: Khong");
                Console.WriteLine($"4. Do thi hinh con ngai: Khong");
                Console.WriteLine($"5. Do thi hinh sao: Khong");
                Console.WriteLine($"6. Do thi banh xe: Khong");
                Console.WriteLine($"7. Do thi Barbell: Khong");
                Console.WriteLine($"8. Do thi tinh ban: Khong");
                Console.WriteLine($"9. Do thi k-phan (k > 1): Khong");


                Console.WriteLine();
                Console.WriteLine("\t*****");
                Console.WriteLine();
            }
        }
    }
}
