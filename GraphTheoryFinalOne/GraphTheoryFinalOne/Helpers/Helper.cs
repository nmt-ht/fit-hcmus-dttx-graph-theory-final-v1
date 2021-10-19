using GraphTheoryFinalOne.Models;
using System;
using System.IO;

namespace GraphTheoryFinalOne.Helpers
{
    public static class Helper
    {
        public static AdjacencyList InitAdjacencyList(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);

                int n = int.Parse(lines[0]);
                var al = new AdjacencyList(n);

                for (int i = 0; i < n; i++)
                {
                    string[] items = lines[i + 1].Split(" ");
                    int adjacentVertexCount = int.Parse(items[0]);

                    for (int j = 0; j < adjacentVertexCount; j++)
                    {
                        al.AdjacentVertices[i].AddLast(int.Parse(items[j + 1]));
                    }
                }

                return al;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message.ToString());
                Console.ReadLine();
            }

            return null;
        }

        public static void PrintToScreen(AdjacencyList adjacencyList)
        {
            Console.WriteLine(adjacencyList.N);

            for (int i = 0; i < adjacencyList.AdjacentVertices.Length; i++)
            {
                Console.Write(adjacencyList.AdjacentVertices[i].Count);
                Console.Write(" ");

                foreach (var item in adjacencyList.AdjacentVertices[i])
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
