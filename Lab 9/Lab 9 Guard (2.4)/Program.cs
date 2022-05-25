using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_9_Guard__2._4_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество сторожей N >= 2 \nN = ");
            int N = Int16.Parse(Console.ReadLine());

            Dictionary<double, double> Guard = new Dictionary<double, double>(N);
            Dictionary<double, double> Protected = new Dictionary<double, double>(N);
            Console.WriteLine("\nВведите действительные числа [a b] (через пробел) - время прихода и время ухода сторожа (0 <= a,b <= 24)");
            for (int i = 1; i <= N; i++)
            {
                string temp = Console.ReadLine();
                Guard.Add(double.Parse(temp.Split(" ")[0]), double.Parse(temp.Split(" ")[1]));
            }
            Guard.Add(24, 24);
            Guard = Guard.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            double gone = 0;
            foreach (KeyValuePair<double, double> keyValue in Guard)
            {
                if(keyValue.Key - gone > 0 && Guard.Count != 1)
                {
                    Protected.Add(gone, keyValue.Key);
                    gone = keyValue.Value;
                    Guard.Remove(keyValue.Key);
                }
                else if(Guard.Count == 1 && 24 - gone > 0)
                {
                    Protected.Add(gone, 24);
                }
                else
                {
                    gone = keyValue.Value;
                    Guard.Remove(keyValue.Key);
                }
            }

            Console.WriteLine("\nПромежутки времени, в течение которых галерея остается без охраны:");
            if (Protected.Count > 0)
            {
                foreach (KeyValuePair<double, double> keyValue in Protected)
                    Console.WriteLine("{0:0.00} - {1:0.00}", keyValue.Key, keyValue.Value);
            }    
            else
                Console.WriteLine("Охраняется всегда");

            Console.ReadKey();
        }
    }
}
