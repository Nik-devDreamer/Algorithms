using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Individual_Task_Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int inf = int.MaxValue;

            int[,] cost = {
                { inf,  9,    12,   5,    inf,   10,   inf,   10,   inf },
                { 9,    inf,  inf,  inf,  11,    inf,  inf,   inf,  inf },
                { 12,   inf,  inf,  inf,  inf,   inf,  inf,   inf,  11 },
                { 5,    inf,  inf,  inf,  inf,   4,    inf,   inf,  inf },
                { inf,  11,   inf,  inf,  inf,   6,    15,    inf,  inf },
                { 10,   inf,  inf,  4,    6,     inf,  7,     inf,  inf },
                { inf,  inf,  inf,  inf,  15,    7,    inf,   13,   inf },
                { 10,   inf,  inf,  inf,  inf,   inf,  13,    inf,  10 },
                { inf,  inf,  11,   inf,  inf,   inf,  inf,   10,   inf },
            };

            Console.WriteLine("Алгоритм Краскала: ");
            Kruskal.KruskalAlgorithm(cost);

            Console.WriteLine("Алгоритм Прима: ");
            Prim.PrimAlgorithm(cost);

            Console.ReadKey();
        }
    }
}
