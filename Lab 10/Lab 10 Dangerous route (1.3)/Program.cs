using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_Dangerous_route__1._3_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество зданий и количество улиц (1 <= N <= 100, 1 <= M <= N(N - 1)/2) (через пробел)");
            string[] temp = Console.ReadLine().Split(' ');
            int N = int.Parse(temp[0]);
            int M = int.Parse(temp[1]);

            Console.WriteLine("Введите номер дома, в котором живёт профессор и номер дома, в котором находится университет соответственно (через пробел)");
            temp = Console.ReadLine().Split(' ');
            string S = temp[0];
            string E = temp[1];

            Console.WriteLine("Введите 3 целых числа si, ei, pi (1 <= si, ei <= N, 0 <= pi <= 100) - здания, в которых начинается и заканчивается дорога и вероятность в процентах быть ограбленным");
            var graph = new Graph();
            for (int i = 1; i <= N; i++)
                graph.AddVertex(i.ToString());

            for (int i = 0; i < M; i++)
            {
                temp = Console.ReadLine().Split(' ');
                graph.AddEdge(temp[0], temp[1], int.Parse(temp[2]));
            }

            var dijkstra = new Dijkstra(graph);
            var path = dijkstra.FindShortestPath(S, E);
            Console.WriteLine($"\nКратчайший путь по алгоритму Дейкстры: {path.Item1}\nМинимальная возможная вероятность быть ограбленным = {path.Item2:0.0##}");

            Console.ReadKey();
        }
    }
}
