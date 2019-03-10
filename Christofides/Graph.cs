using System;
using System.Collections.Generic;
using System.Text;

namespace Christofides
{
    class Graph
    {
        Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

        public void AddUndirectedEdge(int v1, int v2, int weight)
        {
            AddDirectedEdge(v1, v2, weight);
            AddDirectedEdge(v2, v1, weight);
        }

        private void AddDirectedEdge(int source, int dest, int weight)
        {
            Edge newEdge = new Edge(dest, weight);
            if (graph[source] == null)
            {
                graph[source] = new List<Edge> { newEdge };
                return;
            }
            graph[source].Add(newEdge);
        }

        // Returns the weight of the edge between v1 and v2
        // If there is no edge, it returns -1
        public int GetWeight(int v1, int v2)
        {
            if (graph[v1] == null)
                return -1;
            for(int i = 0; i < graph[v1].Count; i++)
            {
                if(graph[v1][i].destination == v2)
                {
                    return graph[v1][i].weight;
                }
            }
            return -1;
        }
    }

    class Edge
    {
        public int destination;
        public int weight;

        public Edge(int destination, int weight)
        {
            this.destination = destination;
            this.weight = weight;
        }
    }
}
