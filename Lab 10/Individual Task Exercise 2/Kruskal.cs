using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_Task_Exercise_2
{
    class Kruskal
    {
        // Алгоритм Краскала
        static int V = 9;
        static int[] parent = new int[V];
        static int inf = int.MaxValue;

        // Вершины
        static int Find(int i)
        {
            while (parent[i] != i)
                i = parent[i];
            return i;
        }

        // Объединение i и j. Возвращает false, если i и j уже находятся в одном наборе
        static void Union(int i, int j)
        {
            int a = Find(i);
            int b = Find(j);
            parent[a] = b;
        }

        // Находит MST (минимальное остовое дерево) с помощью алгоритма Краскала
        public static void KruskalAlgorithm(int[,] cost)
        {
            int minLength = 0, edge_count = 0;

            for (int i = 0; i < V; i++)
                parent[i] = i;

            while (edge_count < V - 1)
            {
                int min = inf, a = -1, b = -1;
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (Find(i) != Find(j) && cost[i, j] < min)
                        {
                            min = cost[i, j];
                            a = i;
                            b = j;
                        }
                    }
                }

                Union(a, b);
                Console.Write("Ребро {0}: ({1}, {2}), длина: {3} \n", ++edge_count, a, b, min);
                minLength += min;
            }
            Console.WriteLine("Минимальная длина = {0} \n", minLength);
        }
    }
}
