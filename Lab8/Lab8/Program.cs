using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Program
    {
        private static List<int> numbersCountList = new List<int> { 1000, 2000, 3000, 4000, 5000 };
        private static Random random = new Random();
        private delegate int[] Sort(int[] mas);

        // Холостой прогон
        private static void IdleRun()
        {
            int[] mas = new int[10000];

            for (var i = 0; i < mas.Length; i++)
                mas[i] = random.Next(1, 1000);

            Sorting.Counting_Sort(mas);
        }

        // Время
        private static double Stopwatch(int[] mas, Sort sort)
        {
            Stopwatch sw = new Stopwatch();
            
            sw.Start();
            sort(mas);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

        private static int[] UnsortedMas(int count)
        {
            int[] mas = new int[count];

            for (var i = 0; i < mas.Length; i++)
                mas[i] = random.Next(100, 1000);

            return mas;
        }

        static void Main(string[] args)
        {
            IdleRun();

            foreach(var count in numbersCountList){
                int[] unsortedMas = UnsortedMas(count);
                int[] mas = new int[count];

                Console.WriteLine("Количество элементов: {0}", count);

                Console.WriteLine("---------- Лабораторная №8 ----------");
                Array.Copy(unsortedMas, mas, count);
                double timeWork = Stopwatch(mas, Sorting.Counting_Sort);
                Console.WriteLine("Сортировка подсчетом: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Pigeonhole_Sort);
                Console.WriteLine("Голубиная сортировка: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Bucket_Sort);
                Console.WriteLine("Блочная сортировка: {0, 2}", timeWork);
                
                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Radix_Sort_LSD);
                Console.WriteLine("Поразрядная сортировка (LSD): {0, 2}", timeWork);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
