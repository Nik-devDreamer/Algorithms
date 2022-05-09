using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public static class Sorting
    {
        // Лабораторная №8
        // Часть 1
        // Сортировка подсчетом
        public static int[] Counting_Sort(int[] mas)
        {
            return Counting_Sort(mas, mas.Min(), mas.Max());
        }

        private static int[] Counting_Sort(int[] mas, int min, int max)
        {
            int[] count = new int[max - min + 1];
            int k = 0;

            for (int i = 0; i < mas.Length; i++)
                count[mas[i] - min]++;

            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    mas[k++] = i;
                }
            }
            return mas;
        }

        // Голубиная сортировка
        public static int[] Pigeonhole_Sort(int[] mas)
        {
            Dictionary<int, int> mas_dictionary = new Dictionary<int, int>();

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas_dictionary.ContainsKey(mas[i]))
                    mas_dictionary[mas[i]]++;
                else
                    mas_dictionary.Add(mas[i], 1);
            }

            int k = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas_dictionary.ContainsKey(i))
                {
                    for (int j = 0; j < mas_dictionary[i]; j++)
                        mas[k++] = i;
                }
            }

            return mas;
        }

        // Часть 2
        // Блочная сортировка
        public static int[] Bucket_Sort(int[] mas)
        {
            int min = mas.Min(), max = mas.Max(), count = 0;
            List<int>[] bucket = new List<int>[max - min + 1];

            // Создаем блоки
            for (int i = 0; i < bucket.Length; i++)
                bucket[i] = new List<int>();

            // Распределяем элементы по блокам
            for (int i = 0; i < mas.Length; i++)
                bucket[mas[i] - min].Add(mas[i]);

            // Собираем элементы блоков в исходный массив
            for (int i = 0; i < bucket.Length; i++)
                for (int j = 0; j < bucket[i].Count; j++)
                    mas[count++] = bucket[i][j];

            return mas;
        }

        // Поразрядная сортировка. LSD radix sort
        public static int[] Radix_Sort_LSD(int[] mas)
        {
            return Radix_Sort_LSD(mas, 10, (int)Math.Log10(mas.Max()) + 1);
        }

        private static int[] Radix_Sort_LSD(int[] mas, int range, int lengthNumber)
        {
            List<int>[] bucket = new List<int>[range];

            // Создаем блоки
            for (int i = 0; i < bucket.Length; i++)
                bucket[i] = new List<int>();

            for (int i = 0; i < lengthNumber; i++)
            {
                // Распределяем элементы по блокам
                for (int j = 0; j < mas.Length; j++)
                    bucket[(mas[j] % (int)Math.Pow(range, i + 1)) / (int)Math.Pow(range, i)].Add(mas[j]);

                // Собираем элементы блоков в исходный массив
                int count = 0;
                for (int m = 0; m < bucket.Length; m++)
                    for (int n = 0; n < bucket[m].Count; n++)
                        mas[count++] = bucket[m][n];

                for (int k = 0; k < bucket.Length; k++)
                    bucket[k].Clear();
            }

            return mas;
        }
    }
}
