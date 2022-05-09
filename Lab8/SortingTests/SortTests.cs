using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab8;

namespace SortingTests
{
    [TestClass]
    public class SortTests
    {
        private static int[] unsortedMas = { 5, 2, 1, 9, 7, 3, 8, 6, 1, 12 };
        private static int[] sortedMas = { 1, 1, 2, 3, 5, 6, 7, 8, 9, 12 };
        private static int[] mas;

        // Лабораторная №8
        // Часть 1
        [TestMethod]
        public void Counting_Sort()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Counting_Sort(unsortedMas);

            // Assert
            CollectionAssert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Pigeonhole_Sort()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Pigeonhole_Sort(unsortedMas);

            // Assert
            CollectionAssert.AreEqual(mas, sortedMas);
        }

        // Часть 2
        [TestMethod]
        public void Bucket_Sort()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Bucket_Sort(unsortedMas);

            // Assert
            CollectionAssert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Radix_Sort_LSD()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Radix_Sort_LSD(unsortedMas);

            // Assert
            CollectionAssert.AreEqual(mas, sortedMas);
        }
    }
}
