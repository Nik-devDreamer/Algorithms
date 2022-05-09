using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
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

            Sorting.Bubble_Sort(mas);
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
                mas[i] = random.Next(1, count);

            return mas;
        }

        static void Main(string[] args)
        {
            IdleRun();

            foreach(var count in numbersCountList){
                int[] unsortedMas = UnsortedMas(count);
                int[] mas = new int[count];

                Console.WriteLine("Количество элементов: {0}", count);

                Console.WriteLine("---------- Лабораторная №6 ----------");
                Array.Copy(unsortedMas, mas, count);
                double timeWork = Stopwatch(mas, Sorting.Bubble_Sort);
                Console.WriteLine("Пузырьковая: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Shaker_Sort);
                Console.WriteLine("Шейкерная: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Comb_Sort);
                Console.WriteLine("Расческой: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Pick_Sort);
                Console.WriteLine("Выбором: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Insert_Sort);
                Console.WriteLine("Вставками: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Shell_Sort);
                Console.WriteLine("Шелла: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Gnome_Sort);
                Console.WriteLine("Гномья: {0, 2}", timeWork);



                Console.WriteLine("---------- Лабораторная №7 ----------");
                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Quick_Sort);
                Console.WriteLine("Быстрая сортировка: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Merge_Sort);
                Console.WriteLine("Сортировка слиянием: {0, 2}", timeWork);

                Array.Copy(unsortedMas, mas, count);
                timeWork = Stopwatch(mas, Sorting.Heap_Sort);
                Console.WriteLine("Пирамидальная сортировка: {0, 2}", timeWork);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
