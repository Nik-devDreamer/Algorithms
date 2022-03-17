using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lb5
{
    class Program
    {
        static List<int> ListArray = new List<int> { 1000, 2000, 3000, 4000, 5000 };
        static Stopwatch sw = new Stopwatch();
        static Random rnd = new Random();
        static double timeWork;

        static int Stopwatch(int key, int element, int[] mas)
        {
            int k = 0;
            timeWork = 0;
            sw.Reset();
            sw.Start();

            switch(key)
            {
                case 1: k = LinePoisk(element, mas); break;
                case 2: k = BarrierPoisk(element, mas); break;
                case 3: k = BinaryPoisk1(element, mas); break;
                case 4: k = BinaryPoisk2(element, mas, 0, mas.Length - 1); break;
                case 5: k = JumpPoisk(element, mas); break;
            }

            sw.Stop();
            timeWork += sw.ElapsedTicks;
            return k;
        }

        //Неупорядоченное заполнение
        static int[] RandomFilling(int count)
        {
            int[] mas = new int[count];

            for (int i = 0; i < count; i++)
            {
                mas[i] = rnd.Next(0, count + 1);
            }

            return mas;
        }

        //Упорядоченное заполнение
        static int[] SortFilling(int count)
        {
            int[] mas;

            mas = RandomFilling(count);
            Array.Sort(mas);

            return mas;
        }

        // Линейный поиск   
        static int LinePoisk(int element, int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }

        //Линейный поиск с барьером
        static int BarrierPoisk(int element, int[] mas)
        {
            int[] arr = new int[mas.Length];
            Array.Copy(mas, arr, mas.Length);
            int find_el = element;

            if (arr[arr.Length - 1] != find_el)
            {
                arr[arr.Length - 1] = find_el;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] == element)
                    {
                        return i;
                    }
                }
            }

            arr = mas;
            return -1;
        }

        //Бинарный (итерационный и рекурсивный варианты)
        static int BinaryPoisk1(int element, int[] mas)
        {
            int[] arr = new int[mas.Length];
            Array.Copy(mas, arr, mas.Length);
            int left = 0, right = arr.Length - 1;

            while (left < right)
            {
                var middle = (left + right) / 2;

                if (element == arr[middle])
                {
                    return middle;
                }
                else if (element < arr[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }

        static int BinaryPoisk2(int element, int[] mas, int left, int right)
        {
            int[] arr = new int[mas.Length];
            Array.Copy(mas, arr, mas.Length);

            if ((left == 0 && arr[left] != element) || (right == arr.Length - 1 && arr[right] != element))
                return -1;

            int middle = left + (right - left) / 2;

            if (arr[middle] == element)
                return middle;

            else if (arr[middle] > element)
                return BinaryPoisk2(element, arr, left, middle);
            else
                return BinaryPoisk2(element, arr, middle + 1, right);
        }

        //Прыжками
        public static int JumpPoisk(int element, int[] mas)
        {
            int[] arr = new int[mas.Length];
            Array.Copy(mas, arr, mas.Length);

            int Length = arr.Length, jumpStep = (int)Math.Sqrt(arr.Length), previousStep = 0;

            while (arr[Math.Min(jumpStep, Length) - 1] < element)
            {
                previousStep = jumpStep;
                jumpStep += (int)(Math.Sqrt(Length));
                if (previousStep >= Length)
                    return -1;
            }
            while (arr[previousStep] < element)
            {
                previousStep++;
                if (previousStep == Math.Min(jumpStep, Length))
                    return -1;
            }

            if (arr[previousStep] == element)
                return previousStep;
            return -1;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[10];
            arr = SortFilling(arr.Length);
            BarrierPoisk(5, arr);

            foreach (int arrLength in ListArray)
            {
                Console.WriteLine("Количество элементов массива - {0}", arrLength);
                Console.WriteLine("1) В неупорядоченном массиве: ");
                arr = RandomFilling(arr.Length);

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();

                //Console.Write("Введите искомый элемент: ");
                int element = 5;

                Console.WriteLine("а) Линейный: {0}. Время: {1}", Stopwatch(1, element, arr), timeWork);
                Console.WriteLine("б) Быстрый линейный (линейный с барьером): {0}. Время: {1}", Stopwatch(2, element, arr), timeWork);

                Console.WriteLine();
                Console.WriteLine("2) В упорядоченном массиве: ");
                arr = SortFilling(arr.Length);

                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();

                //Console.Write("Введите искомый элемент: ");
                //element = Int32.Parse(Console.ReadLine());

                Console.WriteLine("а) Быстрый линейный (линейный с барьером): {0}. Время: {1}", Stopwatch(2, element, arr), timeWork);
                Console.WriteLine("б) Бинарный (итерационный): {0}. Время: {1}", Stopwatch(3, element, arr), timeWork);
                Console.WriteLine("б) Бинарный (рекурсивный): {0}. Время: {1}", Stopwatch(4, element, arr), timeWork);
                Console.WriteLine("в) Прыжками: {0}. Время: {1}", Stopwatch(5, element, arr), timeWork);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}