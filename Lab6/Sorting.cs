using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class Sorting
    {
        // Замена
        public static void Swap(ref int FirstArg, ref int SecondArg)
        {
            int k = FirstArg;
            FirstArg = SecondArg;
            SecondArg = k;
        }

        // Метод для генерации следующего шага
        public static int GetNextStep(int step)
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
    }
}
