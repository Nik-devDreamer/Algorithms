using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab4
{
    static class Program
    {
        static List<int> ListArray = new List<int> { 1000000, 2000000, 3000000, 4000000, 5000000 };
        static Stopwatch sw = new Stopwatch();
        static double timeWork;
        static Random rnd = new Random();
        static bool k = true;
        static int[] mas;

        //Секундомер
        static bool Stopwatch(int[] mas)
        {
            timeWork = 0;
            sw.Reset();
            sw.Start();
            k = Progression(mas);
            sw.Stop();
            timeWork += sw.ElapsedMilliseconds;
            return k;
        }

        //Заполнение массива арифметической прогрессией
        static int[] FillingWorstCase(int count)
        {
            int[] mas = new int[count];
            mas[0] = 1;
            mas[1] = 3;
            for (int i = 1; i < count - 1; i++)
            {
                mas[i + 1] = mas[i] + (mas[1] - mas[0]);
            }
            return mas;
        }

        //Заполнение массива случайными числами
        static int[] FillingRandomValues (int count)
        {
            int[] mas = new int[count];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(0, 5001);
            }
            return mas;
        }

        //Лучший случай
        static bool Best(int arrLength)
        {
            mas = FillingRandomValues(arrLength);
            k = Stopwatch(mas);
            return k;
        }

        //Средний случай
        static bool Average(int arrLength)
        {
            mas = FillingRandomValues(arrLength);
            k = Stopwatch(mas);
            return k;
        }

        //Худший случай
        static bool Worst(int arrLength)
        {
            mas = FillingWorstCase(arrLength);
            k = Stopwatch(mas);
            return k;
        }

        //Проверка на прогрессию
        static bool Progression(int[] mas)
        {
            k = true;
            for (int i = 2; i < mas.Length; i++)
            {
                if ((mas[i] - mas[i - 1]) != (mas[i - 1] - mas[i - 2]))
                {
                    k = false;
                }
            }
            return k;
        }

        static void Main(string[] args)
        {
            foreach (int arrLength in ListArray)
            {
                bool k;
                Console.WriteLine("Количество элементов массива - {0}", arrLength);
                k = Best(arrLength);
                Console.WriteLine("Лучший случай. Прогрессия - {0}. Время: {1}", k, timeWork);

                k = Average(arrLength);
                Console.WriteLine("Средний случай. Прогрессия - {0}. Время: {1}", k, timeWork);

                k = Worst(arrLength);
                Console.WriteLine("Худший случай. Прогрессия - {0}. Время: {1}", k, timeWork);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
