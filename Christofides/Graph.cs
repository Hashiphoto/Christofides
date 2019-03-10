using System;
using System.Collections.Generic;
using System.Text;

namespace Christofides
{
    class Graph
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        public void AddEdge(int v1, int v2)
        {
            if(graph[v1] == null)
            {
                graph[v1] = new List<int> { v2 };
                return;
            }
            graph[v1].Add(v2);
        }

        public bool Connected(int v1, int v2)
        {
            return graph[v1] == null || graph[v1].Contains(v2);
        }
    }
}
