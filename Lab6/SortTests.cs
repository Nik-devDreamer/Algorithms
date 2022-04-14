using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6;

namespace SortingTests
{
    [TestClass]
    public class SortTests
    {
        private static int[] unsortedMas = { 5, 2, 1, 9, 7, 3, 8, 6, 1, 12 };
        private static int[] sortedMas = { 1, 1, 2, 3, 5, 6, 7, 8, 9, 12 };
        private static int[] mas;

        [TestMethod]
        public void Bubble_Sort_Test()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Bubble_Sort(unsortedMas);

            // Assert
            Assert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Shaker_Sort_Test()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Shaker_Sort(unsortedMas);

            // Assert
            Assert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Comb_Sort_Test()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Comb_Sort(unsortedMas);

            // Assert
            Assert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Pick_Sort_Test()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Pick_Sort(unsortedMas);

            // Assert
            Assert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Insert_Sort_Test()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Insert_Sort(unsortedMas);

            // Assert
            Assert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Shell_Sort_Test()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Shell_Sort(unsortedMas);

            // Assert
            Assert.AreEqual(mas, sortedMas);
        }

        [TestMethod]
        public void Gnome_Sort_Test()
        {
            // Act
            mas = new int[10];
            mas = Sorting.Gnome_Sort(unsortedMas);

            // Assert
            Assert.AreEqual(mas, sortedMas);
        }
    }
}
