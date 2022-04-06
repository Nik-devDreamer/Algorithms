using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Lab4
{
    static class Program
    {
        //Секундомер
        static double Stopwatch(int[] array, out bool result)
        {
            double timeWork = 0;
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            result = Progression(array);
            sw.Stop();
            timeWork += sw.ElapsedTicks;

            return timeWork;
        }

        //Проверка на прогрессию
        static bool Progression(int[] mas)
        {
            for (int i = 2; i < mas.Length; i++)
            {
                if ((mas[i] - mas[i - 1]) != (mas[i - 1] - mas[i - 2]))
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            List<int> numbersCountList = new List<int> { 10000, 20000, 30000, 40000, 50000 };

            Generator generator = new Generator(10000); // Холостой прогон
            generator.WorstFilling();

            foreach (int numbersCount in numbersCountList)
            {
                generator = new Generator(numbersCount);
                double timeWorkBest = 0;
                double timeWorkAverage = 0;
                double timeWorkWorst = 0;
                int[] array;
                bool result;

                for (int i = 1; i <= 5; i++) // 5 запусков
                {
                    array = generator.BestFilling(); // Лучший случай
                    timeWorkBest = Stopwatch(array, out result);

                    array = generator.AverageFilling(); // Средний случай
                    timeWorkAverage = Stopwatch(array, out result);

                    array = generator.WorstFilling(); // Худший случай
                    timeWorkWorst = Stopwatch(array, out result);
                }

                Console.WriteLine("Количество элементов массива - {0}", numbersCount);

                Console.WriteLine("Лучший случай: {0}", timeWorkBest / 5);
                Console.WriteLine("Средний случай: {0}", timeWorkAverage / 5);
                Console.WriteLine("Худший случай: {0}", timeWorkWorst / 5);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}