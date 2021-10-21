using GraphTheoryFinalOne.Models;

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
            if (IsEmptyGraph(adjacencyList))
                return false;

            // Get Degree
            DegreeArray = CountDegrees(adjacencyList);

            if (adjacencyList == null || adjacencyList.N < 3 || !IsRegularGraph() || (DegreeArray.Length > 0 && DegreeArray[0] != 2))
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

        public static bool IsButterflyGraph(AdjacencyList adjacencyList)
        {
            if (IsEmptyGraph(adjacencyList) || adjacencyList.N < 5)
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
        #endregion
    }
}
