using System;

namespace Individual_Task_Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            for (int i = 0; i <= 8; i++)
                graph.AddVertex(i.ToString());

            graph.AddEdge("1", "2", 14);
            graph.AddEdge("1", "7", 2);
            graph.AddEdge("7", "0", 5);
            graph.AddEdge("2", "0", 7);
            graph.AddEdge("2", "8", 20);
            graph.AddEdge("0", "3", 15);
            graph.AddEdge("0", "6", 9);
            graph.AddEdge("3", "8", 10);
            graph.AddEdge("3", "4", 5);
            graph.AddEdge("4", "8", 7);
            graph.AddEdge("8", "5", 25);
            graph.AddEdge("5", "4", 11);
            graph.AddEdge("6", "4", 8);
            graph.AddEdge("6", "5", 14);

            var dijkstra = new Dijkstra(graph);
            var path = dijkstra.FindShortestPath("1", "8");
            Console.WriteLine($"Кратчайший путь по алгоритму Дейкстры: {path}");

            Console.ReadKey();
        }
    }
}
