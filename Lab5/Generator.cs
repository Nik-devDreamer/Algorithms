using System;

namespace Lab5
{
    static class Generator
    {
        static Random random = new Random();

        // Средний случай, случайные элементы
        public static int[] Average(int numbersCount)
        {
            int[] array = new int[numbersCount];

            for (int i = 0; i < numbersCount; i++)
            {
                array[i] = random.Next(0, numbersCount);
            }

            return array;
        }

        // Худший случай, все элементы отличаются от искомого числа
        public static int[] Worst(int numbersCount, int numberFind)
        {
            int[] array = new int[numbersCount];
            int number = 100 + numberFind;

            for (int i = 0; i < numbersCount; i++)
            {
                array[i] = number;
            }

            return array;
        }

        // Средний случай с барьером
        public static int[] LinearWithBarrier(int[] array, int numberFind)
        {
            int[] arrayWithBarrier = new int[array.Length + 1];
            array.CopyTo(arrayWithBarrier, 0);
            arrayWithBarrier[arrayWithBarrier.Length - 1] = numberFind;

            return arrayWithBarrier;
        }
    }
}