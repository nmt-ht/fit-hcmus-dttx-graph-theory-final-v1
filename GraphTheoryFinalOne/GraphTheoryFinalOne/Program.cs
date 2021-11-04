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
                Console.WriteLine($"2. Do thi vong: {isCycleGraph}");
                var isButterflyGraph = GraphBiz.IsButterflyOrFriendshipGraph(adjLst) && adjLst.N == 5 ? $"Co" : "Khong";
                Console.WriteLine($"3. Do thi hinh con buom: {isButterflyGraph}");
                var isMothGraph = GraphBiz.IsMothGraph(adjLst) ? $"Co" : "Khong";
                Console.WriteLine($"4. Do thi hinh con ngai: {isMothGraph}");
                var isStarGraph = GraphBiz.IsStarGraph(adjLst) ? $"k = {adjLst.N}" : "Khong";
                Console.WriteLine($"5. Do thi hinh sao: {isStarGraph}");
                var isWheelGraph = GraphBiz.IsWheelGraph(adjLst) ? $"k = {adjLst.N}" : "Khong";
                Console.WriteLine($"6. Do thi banh xe: {isWheelGraph}");
                var isBarbellGraph = GraphBiz.IsBarbellGraph(adjLst) ? $"Co (n = {adjLst.N / 2})" : "Khong";
                Console.WriteLine($"7. Do thi Barbell: {isBarbellGraph}");
                var isFriendshipGraph = GraphBiz.IsButterflyOrFriendshipGraph(adjLst) && adjLst.N > 5 ? $"Co" : "Khong";
                Console.WriteLine($"8. Do thi tinh ban: {isFriendshipGraph}");
                var checkKPartiteGraph = GraphBiz.CheckKPartiteGraph(adjLst);
                Console.WriteLine($"9. Do thi k-phan (k > 1): Khong");

                Console.WriteLine();
                Console.WriteLine("\t*****");
                Console.WriteLine();
            }
        }
    }
}
