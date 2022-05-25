using Microsoft.Collections.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_9_Problem_solving__1._3_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество задач (1 <= N <= 100) \nN = ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Введите исходное умение (1 <= A <= 100) \nA = ");
            int A = int.Parse(Console.ReadLine());

            MultiValueDictionary<int, int> Task_Skill = new MultiValueDictionary<int, int>(N);
            Console.WriteLine("Введите сколько умения нужно для решения задачи и сколько умения прибавится после ее решения (через пробел)");
            for (int i = 0; i < N; i++)
            {
                string temp = Console.ReadLine();
                Task_Skill.Add(int.Parse(temp.Split(" ")[0]), int.Parse(temp.Split(" ")[1]));
            }

            int count = 0;
            foreach (KeyValuePair<int, IReadOnlyCollection<int>> key in Task_Skill.OrderBy(key => key.Key))
            {
                if (A >= key.Key)
                {
                    foreach (int value in key.Value)
                    {
                        A += value;
                        count++;
                    }
                }
                else
                    break;
            }

            Console.WriteLine("Максимальное количество задач, которое можно решить = {0}", count);
            Console.ReadKey();
        }
    }
}