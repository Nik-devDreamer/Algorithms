using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_10_Dream__2._3_
{
    class Program
    {
        static StreamReader In1 = new StreamReader("input1.txt"); // "input1.txt"  "input2.txt"  "input3.txt"
        static StreamWriter Out1 = new StreamWriter("output1.txt"); // "output1.txt"  "output2.txt"  "output3.txt"
        static int startX, startY, R, C;
        static Dictionary<string, int> price = new Dictionary<string, int>();

        static void Open(string key, char[,] labyrinth)
        {
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (labyrinth[i, j] == 'X') continue;
                    if (labyrinth[i, j] == '.') continue;
                    if (labyrinth[i, j] == 'S')
                    {
                        startX = i;
                        startY = j;
                        continue;
                    }
                    if (labyrinth[i, j] == 'E') continue;

                    if (labyrinth[i, j].ToString() == key)
                        labyrinth[i, j] = '.';
                }
            }
        }

        static Queue<int> queue = new Queue<int>();
        static bool end = false;
        static bool Route(char[,] labyrinth)
        {
            if (end)
                return true;
            int i, j;

            while (queue.Count != 0)
            {
                // Извлекаем координаты
                j = queue.Dequeue();
                i = queue.Dequeue();

                // Ищем финиш
                if(j > 0 && labyrinth[j-1,i] == 'E') // Сверху
                    return end = true;

                if (j < R - 1 && labyrinth[j + 1, i] == 'E') // Снизу
                    return end = true;

                if (i > 0 && labyrinth[j, i - 1] == 'E') // Слева
                    return end = true;

                if (i < C - 1 && labyrinth[j, i + 1] == 'E') // Справа
                    return end = true;

                // Финиш не нашли. Следующая точка
                if (j > 0 && labyrinth[j - 1, i] == '.') // Вверх
                {
                    queue.Enqueue(j - 1);
                    queue.Enqueue(i);
                    labyrinth[j - 1, i] = 'X';
                }

                if (j < R - 1 && labyrinth[j + 1, i] == '.') // Вниз
                {
                    queue.Enqueue(j + 1);
                    queue.Enqueue(i);
                    labyrinth[j + 1, i] = 'X';
                }

                if (i > 0 && labyrinth[j, i - 1] == '.') // Влево
                {
                    queue.Enqueue(j);
                    queue.Enqueue(i - 1);
                    labyrinth[j, i - 1] = 'X';
                }

                if (i < C - 1 && labyrinth[j, i + 1] == '.') // Вправо
                {
                    queue.Enqueue(j);
                    queue.Enqueue(i + 1);
                    labyrinth[j, i + 1] = 'X';
                }

                return Route(labyrinth);
            }

            return false;
        }

        static void Main(string[] args)
        {
            string[] temp = In1.ReadLine().Split(" "); // Размер лабиринта
            R = int.Parse(temp[0]);
            C = int.Parse(temp[1]);

            temp = In1.ReadLine().Split(" "); // Стоимость ключей
            price.Add("", 0);
            price.Add("R", int.Parse(temp[0]));
            price.Add("G", int.Parse(temp[1]));
            price.Add("B", int.Parse(temp[2]));
            price.Add("Y", int.Parse(temp[3]));

            int minCost = 5000;
            char[,] labyrinth = new char[R, C];
            char[,] labyrinth1 = new char[R, C];
            for (int i = 0; i < R; i++)
            {
                temp = In1.ReadLine().Split(" ");
                for (int j = 0; j < C; j++)
                    labyrinth[i, j] = char.Parse(temp[j]);
            }

            string[] key = new string[] { "", "R", "G", "B", "Y", "R G", "R B", "R Y", "G B", "G Y", "B Y", "R G B", "R G Y", "R B Y", "G B Y", "R G B Y" }; // Наборы ключей

            for(int k = 0; k < key.Length; k++)
            {
                Array.Copy(labyrinth, labyrinth1, labyrinth.Length);
                temp = key[k].Split(" ");
                for (int h = 0; h < temp.Length; h++)
                    Open(temp[h], labyrinth1);

                while (queue.Count != 0)
                    queue.Dequeue();

                queue.Enqueue(startX);
                queue.Enqueue(startY);
                end = false;

                if(Route(labyrinth1))
                {
                    int cost = 0;
                    for(int i = 0; i < temp.Length; i++)
                        cost += price[temp[i]];

                    if (minCost > cost)
                        minCost = cost;
                }
            }

            if (minCost == 5000)
                Out1.WriteLine("Sleep");
            else
                Out1.WriteLine($"{minCost}");
            Out1.Close();

            Console.ReadKey();
        }
    }
}
