using GraphTheoryFinalOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTheoryFinalOne.Handlers
{
    public static class GraphBiz
    {
        public static int[] DegreeArray { get; set; }
        public static bool IsEmptyGraph(AdjacencyList adjacencyList)
        {
            for (int i = 0; i < adjacencyList.AdjacentVertices.Length; i++)
            {
                foreach (var item in adjacencyList.AdjacentVertices[i])
                {
                    if (item > 0)
                        return false;
                }
            }

            return true;
        }
        public static bool IsCycleGrap(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList) && IsCompletedGraph(adjacencyList))
                return false;

            // Get Degree
            DegreeArray = CountDegrees(adjacencyList);

            //check degree on each vertice 
            for (int i = 0; i < DegreeArray.Length; i++)
            {
                if (DegreeArray[i] > 2)
                    return false;
            }

            if (adjacencyList == null || adjacencyList.N < 3 || !IsRegularGraph())
                return false;

            bool[] visited = new bool[adjacencyList.N];
            for (int i = 0; i < adjacencyList.N; i++)
                visited[i] = false;

            for (int u = 0; u < adjacencyList.N; u++)
            {
                if (!visited[u])
                    if (IsCyclicUtil(adjacencyList, u, visited, -1))
                        return true;
            }

            return false;

        }

        public static bool IsButterflyOrFriendshipGraph(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList) || adjacencyList.N < 5 || adjacencyList.N % 2 == 0)
                return false;

            int vertexD2 = 0;
            int vertexDn_1 = 0;

            for (int i = 0; i < adjacencyList.N; i++)
            {
                int degreeI = 0;
                degreeI = adjacencyList.AdjacentVertices[i].Count;

                if (degreeI == 2)
                    vertexD2++;
                else if (degreeI == adjacencyList.N - 1)
                    vertexDn_1++;
            }

            return vertexD2 == (adjacencyList.N - 1) && vertexDn_1 == 1;
        }

        public static bool IsWheelGraph(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList) || adjacencyList.N < 4)
                return false;

            int vertexD3 = 0;
            int vertexDn_1 = 0;

            for (int i = 0; i < adjacencyList.N; i++)
            {
                int degreeI = 0;
                degreeI = adjacencyList.AdjacentVertices[i].Count;

                if (degreeI == 3)
                    vertexD3++;
                else if (degreeI == adjacencyList.N - 1)
                    vertexDn_1++;
            }

            return vertexD3 == (adjacencyList.N - 1) && vertexDn_1 == 1;
        }

        public static bool IsStarGraph(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList))
                return false;

            int size = adjacencyList.N;
            int vertexD1 = 0;
            int vertexDn_1 = 0;

            //S1
            if (size == 1)
                return adjacencyList.AdjacentVertices[0].First.Value == 0;

            //S2
            if (size == 2)
                return adjacencyList.AdjacentVertices[0].First.Value == 1 && adjacencyList.AdjacentVertices[1].First.Value == 1;

            //Sn (n>2)
            for (int i = 0; i < size; i++)
            {
                int degreeI = 0;
                degreeI = adjacencyList.AdjacentVertices[i].Count;

                if (degreeI == 1)
                    vertexD1++;
                else if (degreeI == size - 1)
                    vertexDn_1++;
            }

            return vertexD1 == (size - 1) && vertexDn_1 == 1;

        }

        public static bool IsMothGraph(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList) || adjacencyList.N < 6)
                return false;

            int vertex1 = 0;
            int vertex5 = 0;
            int vertex3 = 0;
            int vertex2 = 0;

            for (int i = 0; i < adjacencyList.N; i++)
            {
                int degreeI = 0;
                degreeI = adjacencyList.AdjacentVertices[i].Count;

                if (degreeI == 1)
                    vertex1++;

                if (degreeI == 1)
                    vertex2++;

                if (degreeI == 3)
                    vertex3++;

                if (degreeI == 5)
                    vertex5++;
            }

            return vertex1 == 2 && vertex2 == 2 && vertex3 == 1 && vertex5 == 1;
        }

        public static bool IsBarbellGraph(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList) || adjacencyList.N < 6 || (adjacencyList.N > 6 && adjacencyList.N % 2 != 0))
                return false;

            int nMaxDegree = adjacencyList.N / 2;
            AdjacencyList list1 = new AdjacencyList(nMaxDegree);
            AdjacencyList list2 = new AdjacencyList(nMaxDegree);

            var count = 0;
            int el = 0;
            var max = 0;
            max = adjacencyList.AdjacentVertices[0].Count;
            list1.BridgeVertice = el;

            foreach (var adj in adjacencyList.AdjacentVertices)
            {
                count++;
                if (count <= nMaxDegree)
                {
                    list1.AdjacentVertices[el] = adj;
                    if (adj.Count > max)
                    {
                        max = adj.Count;
                        list1.BridgeVertice = el;
                    }
                }
                else
                {
                    el = nMaxDegree == count - 1 ? 0 : el;
                    list2.AdjacentVertices[el] = adj;
                    if (adj.Count >= max)
                    {
                        max = adj.Count;
                        list2.BridgeVertice = el + nMaxDegree;
                    }
                }
                el++;
            }

            return IsCompletedGraph(list1) && IsCompletedGraph(list2) && HasBridgeEdge(list1, list2);
        }

        public static string CheckKPartiteGraph(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList))
                return "Khong";

            List<KPartiteGraph> kPartiteGraphs = new List<KPartiteGraph>();
            int el = 0;

            //Get potential for a vertice which can connect to another verice
            foreach (var vertice in adjacencyList.AdjacentVertices)
            {
                if (vertice.Count == adjacencyList.N - 1)
                    kPartiteGraphs.Add(new KPartiteGraph { StartVertice = el });
                else
                {
                    for (int i = 0; i < vertice.Count; i++){

                    }
                }
                el++;
            }

            return kPartiteGraphs.Count > 1 ? "Co" : "Khong";
        }

        #region Support Function
        public static bool IsUndirectedGraph(AdjacencyList adjacencyList)
        {
            bool result = true;

            for (int i = 0; i < adjacencyList.AdjacentVertices.Length; i++)
            {
                var list = adjacencyList.AdjacentVertices[i];

                if (list.Count == 0)
                    return false;

                foreach (var item in list)
                {
                    if (!(adjacencyList.AdjacentVertices[item].Count > 0 && adjacencyList.AdjacentVertices[item].Find(i) != null))
                        return false;
                }
            }

            return result;
        }
        private static bool IsCyclicUtil(AdjacencyList adjacencyList, int v, bool[] visited, int parent)
        {
            visited[v] = true;

            foreach (int i in adjacencyList.AdjacentVertices[v])
            {
                if (!visited[i])
                {
                    if (IsCyclicUtil(adjacencyList, i, visited, v))
                        return true;
                }
                else if (i != parent)
                    return true;
            }
            return false;
        }
        private static bool IsRegularGraph()
        {
            var result = true;

            if (DegreeArray == null)
                return false;

            for (int i = 0; i < DegreeArray.Length; i++)
            {
                for (int j = i + 1; j < DegreeArray.Length; j++)
                {
                    if (DegreeArray[i] != DegreeArray[j])
                        return false;
                }
            }

            return result;
        }

        private static int[] CountDegrees(AdjacencyList adjacencyList)
        {
            int[] degrees = new int[adjacencyList.N];
            for (int i = 0; i < adjacencyList.N; i++)
            {
                for (int j = 0; j < adjacencyList.N; j++)
                {
                    var item = adjacencyList.AdjacentVertices[j];
                    if (item.Count > 0)
                        degrees[i] = item.Count;
                }
            }

            return degrees;
        }

        private static int TotalOfEdges(AdjacencyList adjacencyList)
        {
            return adjacencyList.N * (adjacencyList.N - 1) / 2;
        }

        private static bool IsCompletedGraph(AdjacencyList adjacencyList)
        {
            var degrees = CountDegrees(adjacencyList);

            if (degrees.Length == 0)
                return false;

            var totalEdges = TotalOfEdges(adjacencyList);

            var totalDegree = 0;
            for (int i = 0; i < degrees.Length; i++)
                totalDegree += degrees[i];

            return totalDegree / 2 == totalEdges;
        }

        private static bool HasBridgeEdge(AdjacencyList graph1, AdjacencyList graph2)
        {
            return (graph1.AdjacentVertices[0].Count == graph2.AdjacentVertices[0].Count) &&
                        (graph1.AdjacentVertices[0].Contains(graph2.BridgeVertice) &&
                                        graph2.AdjacentVertices[0].Contains(graph1.BridgeVertice));
        }
        #endregion
    }
}

public class KPartiteGraph 
{
    public int StartVertice { get; set; }
    public int EndVertice { get; set; }
}
