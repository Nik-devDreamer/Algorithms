using System;

namespace Lab5
{
    public static class Search
    {
        // Линейный поиск
        public static int LinePoisk(int[] mas, int numberFind)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == numberFind)
                {
                    return i;
                }
            }
            return -1;
        }

        // Линейный поиск с барьером
        public static int LineWithBarrier(int[] mas, int numberFind)
        {
            int i = 0;

            while (mas[i] != numberFind)
            {
                i++;
            }

            if (i == mas.Length - 1)
            {
                return -1;
            }

            return i;
        }

        // Бинарный итерационный поиск
        public static int Binary(int[] mas, int numberFind)
        {
            int left = 0;
            int right = mas.Length - 1;
            int k = -1;

            while (left <= right)
            {
                int middle = (right + left) / 2;

                if (numberFind <= mas[middle])
                {
                    if (numberFind == mas[middle])
                    {
                        k = middle;
                    }

                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return k;
        }

        //Прыжками
        public static int Jump(int[] mas, int numberFind)
        {
            int[] arr = new int[mas.Length];
            Array.Copy(mas, arr, mas.Length);

            int Length = arr.Length, jumpStep = (int)Math.Sqrt(arr.Length), previousStep = 0;

            while (arr[Math.Min(jumpStep, Length) - 1] < numberFind)
            {
                previousStep = jumpStep;
                jumpStep += (int)(Math.Sqrt(Length));
                if (previousStep >= Length)
                    return -1;
            }
            while (arr[previousStep] < numberFind)
            {
                previousStep++;
                if (previousStep == Math.Min(jumpStep, Length))
                    return -1;
            }

            if (arr[previousStep] == numberFind)
                return previousStep;
            return -1;
        }
    }
}