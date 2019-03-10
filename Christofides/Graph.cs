using System;
using System.Collections.Generic;
using System.Text;

namespace Christofides
{
    class Graph
    {
        private Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
        private List<Edge> edges = new List<Edge>();
        private List<int> vertices = new List<int>();
        private int size;

        public void AddUndirectedEdge(int v1, int v2, int weight)
        {
            edges.Add(AddDirectedEdge(v1, v2, weight));
            AddDirectedEdge(v2, v1, weight);
        }

        public Edge AddDirectedEdge(int source, int dest, int weight)
        {
            Edge newEdge = new Edge(source, dest, weight);
            if (!graph.ContainsKey(source) || graph[source] == null)
            {
                vertices.Add(source);
                graph[source] = new List<Edge> { newEdge };
                size++;
            }
            else
            {
                graph[source].Add(newEdge);
            }
            return newEdge;
        }

        // Returns the weight of the edge between v1 and v2
        public int GetWeight(int v1, int v2)
        {
            if (!graph.ContainsKey(v1))
                throw new ArgumentException("Vertex " + v1 + " does not exist");
            foreach(var edge in graph[v1])
            {
                if(edge.destination == v2)
                {
                    return edge.weight;
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
            edges.Sort();
        }

        public List<Edge> GetEdges()
        {
            return edges;
        }

        public List<int> GetVertices()
        {
            return vertices;
        }

        public void Print()
        {
            foreach(KeyValuePair<int, List<Edge>> entry in graph)
            {
                Console.Write(entry.Key + ": ");
                List<Edge> list = entry.Value;
                for(int i = 0; i < list.Count; i++)
                {
                    Console.Write("(" + list[i].destination + ", " + list[i].weight + "), ");
                }
                Console.Write("\n");
            }
        }
    }

    class Edge : IComparable
    {
        public int source;
        public int destination;
        public int weight;

        public Edge(int source, int destination, int weight)
        {
            this.source = source;
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
