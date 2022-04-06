using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Generator
    {
        private static int _numbersCount;
        private static Random _random = new Random();

        internal Generator(int numbersCount)
        {
            _numbersCount = numbersCount;
        }

        // Лучший случай, первые элементы не являются прогрессией
        internal int[] BestFilling()
        {
            int[] array = new int[_numbersCount];
            array[0] = 2;
            array[1] = 1;
            array[2] = 0;

            return array;
        }

        // Худший случай, в массиве прогрессия
        internal int[] WorstFilling()
        {
            int[] array = new int[_numbersCount];

            for (int i = 0; i < _numbersCount; i++)
            {
                array[i] = i + 2;
            }

            return array;
        }

        // Средний случай, половина элементов - прогрессия, половина - рандомные
        internal int[] AverageFilling()
        {
            int[] array = new int[_numbersCount];

            for (int i = 0; i < _numbersCount / 2; i++)
            {
                array[i] = i + 2;
            }

            for (int i = _numbersCount / 2; i < _numbersCount; i++)
            {
                array[i] = _random.Next(0, _numbersCount);
            }

            return array;
        }
    }
}
