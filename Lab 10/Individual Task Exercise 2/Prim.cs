using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_Task_Exercise_2
{
    class Prim
    {
        // Алгоритм Прима
        // Поиск вершины с минимальным значением из набора вершин
        static int V = 9;
        static int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        // Находит MST (минимальное остовое дерево) с помощью алгоритма Прима
        public static void PrimAlgorithm(int[,] graph)
        {
            int[] parent = new int[V];  // Массив для хранения построенного MST
            int[] key = new int[V]; // Значения для выбора ребра минимальной длины
            bool[] mstSet = new bool[V];
            int minLength = 0;

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, mstSet); // Выбрать минимальную ключевую вершину из набора вершин, еще не включенных в MST
                mstSet[u] = true; // Добавили выбранную вершину в набор MST

                for (int v = 0; v < V; v++)
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }
            
            for (int i = 1; i < V; i++)
                minLength += graph[i, parent[i]];

            // Вывод на экран
            for (int i = 1; i < V; i++)
                Console.Write("Ребро {0}: ({1}, {2}), длина: {3} \n", i, parent[i], i, graph[i, parent[i]]);
            Console.WriteLine("Минимальная длина = {0} \n", minLength);
        }
    }
}
