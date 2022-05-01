using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class Sorting
    {
        // Лабораторная №6
        // Замена
        private static void Swap(ref int FirstArg, ref int SecondArg)
        {
            int k = FirstArg;
            FirstArg = SecondArg;
            SecondArg = k;
        }

        // Метод для генерации следующего шага
        private static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }

        // Пузырьковая сортировка
        public static int[] Bubble_Sort(int[] mas)
        {
            for (var i = 0; i < mas.Length; i++)
            {
                for (var j = 0; j < mas.Length - 1 - i; j++)
                {
                    if (mas[j] > mas[j + 1])
                        Swap(ref mas[j], ref mas[j + 1]);
                }
            }
            
            return mas;
        }

        // Шейкерная сортировка
        public static int[] Shaker_Sort(int[] mas)
        {
            for (var i = 0; i < mas.Length / 2; i++)
            {
                var flag = false;
                
                // Проход слева направо
                for (var j = i; j < mas.Length - i - 1; j++)
                {
                    if (mas[j] > mas[j + 1])
                    {
                        Swap(ref mas[j], ref mas[j + 1]);
                        flag = true;
                    }
                }

                // Проход справа налево
                for (var j = mas.Length - 2 - i; j > i; j--)
                {
                    if (mas[j - 1] > mas[j])
                    {
                        Swap(ref mas[j - 1], ref mas[j]);
                        flag = true;
                    }
                }
                
                // Если нет обменов
                if (!flag)
                    break;
            }
            
            return mas;
        }

        // Сортировка расчёской
        public static int[] Comb_Sort(int[] mas)
        {
            var length = mas.Length;
            var currentStep = length - 1;
        
            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < mas.Length; i++)
                {
                    if (mas[i] > mas[i + currentStep])
                        Swap(ref mas[i], ref mas[i + currentStep]);
                }

                currentStep = GetNextStep(currentStep);
            }
            
            return Bubble_Sort(mas);
        }

        // Сортировка выбором
        public static int[] Pick_Sort(int[] mas)
        {
            int indexMin = 0, indexMax = 0;

            for (int i = 0; i < mas.Length / 2; i++)
            {
                var min = int.MaxValue;
                var max = 0;
                var tmp = 0;

                for (int j = i; j < mas.Length - i; j++)
                {
                    if (min > mas[j])
                    {
                        min = mas[j];
                        indexMin = j;
                    }
                    if (mas[j] > max)
                    {
                        max = mas[j];
                        indexMax = j;
                    }
                }

                tmp = mas[i];
                if (i == indexMax)
                {
                    indexMax = indexMin;
                }

                mas[i] = min;
                mas[indexMin] = tmp;

                tmp = mas[mas.Length - i - 1];
                mas[mas.Length - i - 1] = max;
                mas[indexMax] = tmp;
            }

            return mas;
        }
        
        // Сортировка вставками
        public static int[] Insert_Sort(int[] mas)
        {
            for (var i = 1; i < mas.Length; i++)
            {
                var key = mas[i];
                var j = i;
                while ((j > 1) && (mas[j - 1] > key))
                {
                    Swap(ref mas[j - 1], ref mas[j]);
                    j--;
                }

                mas[j] = key;
            }

            return mas;
        }

        // Сортировка Шелла
        public static int[] Shell_Sort(int[] mas)
        {
            var step = mas.Length / 2;
            while (step >= 1)
            {
                for (var i = step; i < mas.Length; i++)
                {
                    var j = i;
                    while ((j >= step) && (mas[j - step] > mas[j]))
                    {
                        Swap(ref mas[j], ref mas[j - step]);
                        j = j - step;
                    }
                }

                step = step / 2;
            }

            return mas;
        }

        // Гномья сортировка
        public static int[] Gnome_Sort(int[] mas)
        {
            int i = 1, j = 2;

            while (i < mas.Length)
            {
                if (mas[i - 1] < mas[i])
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(ref mas[i - 1], ref mas[i]);
                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }

            return mas;
        }







        // Лабораторная №7
        // Быстрая сортировка
        public static int[] Quick_Sort(int[] mas)
        {
            return Quick_Sort(mas, 0, mas.Length - 1);
        }

        private static int[] Quick_Sort(int[] mas, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return mas;

            int bearingIndex = BearingIndex(mas, minIndex, maxIndex);

            Quick_Sort(mas, minIndex, bearingIndex - 1);
            Quick_Sort(mas, bearingIndex + 1, maxIndex);

            return mas;
        }

        // Получение индекса элемента bearing
        private static int BearingIndex(int[] mas, int minIndex, int maxIndex)
        {
            int bearingIndex = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (mas[i] < mas[maxIndex])
                {
                    bearingIndex++;
                    Swap(ref mas[bearingIndex], ref mas[i]);
                }
            }

            bearingIndex++;
            Swap(ref mas[bearingIndex], ref mas[maxIndex]);

            return bearingIndex;
        }

        // Сортировка слиянием
        public static int[] Merge_Sort(int[] mas)
        {
            return Merge_Sort(mas, 0, mas.Length - 1);
        }

        private static int[] Merge_Sort(int[] mas, int minIndex, int maxIndex)
        {
            if (minIndex < maxIndex)
            {
                int middleIndex = minIndex + (maxIndex - minIndex) / 2;
                Merge_Sort(mas, minIndex, middleIndex);
                Merge_Sort(mas, middleIndex + 1, maxIndex);
                MergeHalves(mas, minIndex, middleIndex, maxIndex);
            }
            return mas;
        }

        private static void MergeHalves(int[] mas, int minIndex, int middleIndex, int maxIndex)
        {
            var minArrayLength = middleIndex - minIndex + 1;
            var maxArrayLength = maxIndex - middleIndex;
            var minTempArray = new int[minArrayLength];
            var maxTempArray = new int[maxArrayLength];
            int i, j;

            for (i = 0; i < minArrayLength; ++i)
                minTempArray[i] = mas[minIndex + i];

            for (j = 0; j < maxArrayLength; ++j)
                maxTempArray[j] = mas[middleIndex + 1 + j];

            i = 0;
            j = 0;
            int k = minIndex;

            while (i < minArrayLength && j < maxArrayLength)
            {
                if (minTempArray[i] <= maxTempArray[j])
                {
                    mas[k++] = minTempArray[i++];
                }
                else
                {
                    mas[k++] = maxTempArray[j++];
                }
            }

            while (i < minArrayLength)
            {
                mas[k++] = minTempArray[i++];
            }

            while (j < maxArrayLength)
            {
                mas[k++] = maxTempArray[j++];
            }
        }

        // Пирамидальная сортировка
        public static int[] Heap_Sort(int[] mas)
        {
            return Heap_Sort(mas, mas.Length);
        }

        private static int AddHeap(int[] mas, int i, int length)
        {
            int imax;

            if ((2 * i + 2) < length)
            {
                if (mas[2 * i + 1] < mas[2 * i + 2]) 
                    imax = 2 * i + 2;
                else 
                    imax = 2 * i + 1;
            }
            else 
                imax = 2 * i + 1;

            if (imax >= length) 
                return i;

            if (mas[i] < mas[imax])
            {
                Swap(ref mas[i], ref mas[imax]);

                if (imax < length / 2) 
                    i = imax;
            }

            return i;
        }

        private static int[] Heap_Sort(int[] mas, int length)
        {
            for (int i = length / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = AddHeap(mas, i, length);
                if (prev_i != i) ++i;
            }

            for (int k = length - 1; k > 0; --k)
            {
                Swap(ref mas[0], ref mas[k]);
                int i = 0, prev_i = -1;

                while (i != prev_i)
                {
                    prev_i = i;
                    i = AddHeap(mas, i, k);
                }
            }

            return mas;
        }







        // Лабораторная №8
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
                    mas[k] = i;
                    k++;
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
    }
}
