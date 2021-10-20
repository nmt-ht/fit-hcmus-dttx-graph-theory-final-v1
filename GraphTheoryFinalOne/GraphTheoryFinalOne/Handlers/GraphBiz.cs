using GraphTheoryFinalOne.Models;

namespace GraphTheoryFinalOne.Handlers
{
    public static class GraphBiz
    {
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

        public static bool IsCycleGrap(AdjacencyList adjacencyList)
        {
            if (adjacencyList == null || adjacencyList.N < 3) // || !IsRegularGraph() || (this.DegreeArray.Length > 0 && this.DegreeArray[0] != 2))
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

        private static bool IsCyclicUtil(AdjacencyList adjacencyList, int v, bool[] visited, int parent)
        {
            visited[v] = true;

            foreach (int i in adjacencyList.AdjacentVertices[v])
            {
                if (!visited[i])
                {
                    if (IsCyclicUtil(adjacencyList,i, visited, v))
                        return true;
                }
                else if (i != parent)
                    return true;
            }
            return false;
        }

    }
}
