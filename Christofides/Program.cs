using System;

namespace Christofides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Graph graph = new Graph();
            graph.AddUndirectedEdge(1, 2, 30);
            graph.AddUndirectedEdge(2, 3, 40);
            graph.AddUndirectedEdge(3, 1, 3);
            graph.AddUndirectedEdge(2, 12, 1);
            graph.AddUndirectedEdge(2, 5, 3);
            graph.SortByWeight();
            graph.Print();
            // Fill graph with data

            // Find minimum spanning tree T

            // Find minimum matching M for the odd-degree vertices in T

            // Add M to T

            // Find a Euler tour

            // Cut short

            Console.ReadKey();
        }

        // Find a minimum spanning tree using Prim's algorithm
        Graph PrimMST(Graph graph)
        {
            if (graph == null || graph.Size() <= 2)
            {
                return graph;
            }
            return graph;
        }

        
    }
}
