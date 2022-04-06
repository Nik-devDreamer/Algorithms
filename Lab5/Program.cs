using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab5
{
    class Program
    {
        // Поиск
        public static void Find(int[] array, int numberFind)
        {
            int index;
            double workTime;

            // в неупорядоченном массиве
            // Линейный
            workTime = Stopwatch(Search.LinePoisk, array, numberFind, out index);
            Console.WriteLine("Линейный \tИндекс: \t{0} \tВремя: \t{1}", index, workTime);
                
            // Линейный с барьером
            int[] arrayWithBarrier = Generator.LinearWithBarrier(array, numberFind);
            workTime = Stopwatch(Search.LineWithBarrier, arrayWithBarrier, numberFind, out index);
            Console.WriteLine("C барьером \tИндекс: \t{0} \tВремя: \t{1}", index, workTime);


            // в упорядоченном массиве
            Array.Sort(array); // Сортировка массива

            // Бинарный итерационный
            workTime = Stopwatch(Search.Binary, array, numberFind, out index);
            Console.WriteLine("Бинарный \tИндекс: \t{0} \tВремя: \t{1}", index, workTime);
                
            // Прыжковый
            workTime = Stopwatch(Search.Jump, array, numberFind, out index);
            Console.WriteLine("Прыжковый \tИндекс: \t{0} \tВремя: \t{1}", index, workTime);
        }

        public static double Stopwatch(Func<int[], int, int> method, int[] array, int numberToFind, out int result)
        {
            Stopwatch sw = new Stopwatch();
            double workTime = 0;

            sw.Start();
            result = method(array, numberToFind);
            sw.Stop();
            workTime += sw.ElapsedTicks;

            return workTime;
        }

        static void Main(string[] args)
        {
            List<int> arrayLength = new List<int> { 10000, 20000, 30000, 40000, 50000 };

            foreach (int length in arrayLength)
            {
                int numberFind = 13;
                int[] array; // Неупорядоченный массив
                
                Console.WriteLine("Средний случай: {0} элементов. Найти - {1}", length, numberFind);
                array = Generator.Average(length);
                Find(array, numberFind);

                Console.WriteLine("Худший случай: {0} элементов. Найти - {1}", length, numberFind);
                array = Generator.Worst(length, numberFind);
                Find(array, numberFind);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
