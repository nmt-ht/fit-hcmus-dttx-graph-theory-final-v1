using GraphTheoryFinalOne.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace GraphTheoryFinalOne.Helpers
{
    public static class Helper
    {
        public static IList<AdjacencyList> InitAdjacencyList(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                int m = int.Parse(lines[0]); // total of adjacency list
                int n = 0; //index of verties
                int new_n = 1;
                IList<AdjacencyList> adjacencyLists = new List<AdjacencyList>();

                for (int i = 0; i < m; i++)
                {
                    n = int.Parse(lines[new_n]); // number of verties 
                    var al = new AdjacencyList(n);
                    var al_index = 0;

                    for (int j = new_n; j < n + new_n; j++)
                    {
                        string[] items = lines[j + 1].Split(" ");
                        int adjacentVertexCount = int.Parse(items[0]);

                        for (int z = 0; z < adjacentVertexCount; z++)
                        {
                            al.AdjacentVertices[al_index].AddLast(int.Parse(items[z + 1]));
                        }
                        al_index++;
                    }

                    adjacencyLists.Add(al);
                    new_n = new_n + n + 1;
                }

                return adjacencyLists;
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
