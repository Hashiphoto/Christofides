using System;
using System.Collections.Generic;

namespace Christofides
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Hello World!");

            Graph graph = new Graph();

            // Fill graph with data
            graph.AddUndirectedEdge(0, 1, 6);
            graph.AddUndirectedEdge(0, 2, 3);
            graph.AddUndirectedEdge(0, 4, 7);
            graph.AddUndirectedEdge(1, 2, 4);
            graph.AddUndirectedEdge(1, 3, 2);
            graph.AddUndirectedEdge(1, 5, 5);
            graph.AddUndirectedEdge(2, 3, 3);
            graph.AddUndirectedEdge(2, 4, 8);
            graph.AddUndirectedEdge(3, 5, 2);
            graph.SortByWeight();
            graph.Print();
            Console.WriteLine("Size: " + graph.Size());

            // Find minimum spanning tree T
            graph = p.PrimMST(graph);
            graph.Print();

            // Find minimum matching M for the odd-degree vertices in T

            // Add M to T

            // Find a Euler tour

            // Cut short

            Console.ReadKey();
        }

        // A utility function to find  
        // the vertex with minimum key 
        // value, from the set of vertices  
        // not yet included in MST 
        static int minKey(int[] key, bool[] mstSet, int size)
        {
            // Initialize min value 
            int min = int.MaxValue, min_index = -1;

            for (int i = 0; i < size; i++)
                if (mstSet[i] == false && key[i] < min)
                {
                    min = key[i];
                    min_index = i;
                }

            return min_index;
        }

        // Find a minimum spanning tree using Prim's algorithm
        Graph PrimMST(Graph graph)
        {
            if (graph == null || graph.Size() <= 2)
            {
                return graph;
            }

            int size = graph.Size();
            int[] parent = new int[size];
            int[] key = new int[size];
            bool[] mstSet = new bool[size];
            for (int i = 0; i < size; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;
            
            for (int count = 0; count < size - 1; count++)
            {
                int u = minKey(key, mstSet, size);
                mstSet[u] = true;
                for (int v = 0; v < size; v++)
                    if (graph.GetWeight(u,v) != 0 
                        && mstSet[v] == false
                        && graph.GetWeight(u,v) < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph.GetWeight(u,v);
                    }
            }

            Graph mst = new Graph();
            for(int i = 0; i < size; i++)
            {
                mst.AddUndirectedEdge(i, parent[i], graph.GetWeight(i, parent[i]));
            }
            return mst;
        }

        Graph KruskalMST(Graph graph)
        {
            graph.SortByWeight();
            List<Edge> edges = graph.GetEdges();
            Graph mst = new Graph();
            bool[] visited = new bool[graph.Size()];

            foreach(Edge e in edges)
            {
                Console.WriteLine(e.weight);
            }

            return graph;
        }
    }
}
