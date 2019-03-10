using System;
using System.Collections.Generic;
using System.Text;

namespace Christofides
{
    class Graph
    {
        private Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
        private int size;

        public void AddUndirectedEdge(int v1, int v2, int weight)
        {
            AddDirectedEdge(v1, v2, weight);
            AddDirectedEdge(v2, v1, weight);
        }

        public void AddDirectedEdge(int source, int dest, int weight)
        {
            Edge newEdge = new Edge(dest, weight);
            if (!graph.ContainsKey(source) || graph[source] == null)
            {
                graph[source] = new List<Edge> { newEdge };
                size++;
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

        public int Size()
        {
            return size;
        }

        public void SortByWeight()
        {
            foreach (KeyValuePair<int, List<Edge>> entry in graph)
            {
                entry.Value.Sort();
            }
        }

        public void Print()
        {
            foreach(KeyValuePair<int, List<Edge>> entry in graph)
            {
                Console.Write(entry.Key + ": ");
                List<Edge> list = entry.Value;
                for(int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i].destination + ", ");
                }
                Console.Write("\n");
            }
        }
    }

    class Edge : IComparable
    {
        public int destination;
        public int weight;

        public Edge(int destination, int weight)
        {
            this.destination = destination;
            this.weight = weight;
        }

        public int CompareTo(object obj)
        {
            if(obj == null)
            {
                return 1;
            }
            Edge otherEdge = obj as Edge;
            if (otherEdge != null)
            {
                return weight.CompareTo(otherEdge.weight);
            }
            else
            {
                throw new ArgumentException("Object is not an Edge");
            }
        }
    }
}
