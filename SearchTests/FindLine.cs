using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5;

namespace FindLine
{
    [TestClass]
    public class FinderLineTests
    {
        public static int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        [TestMethod]
        public void Line_Find0()
        {
            // Act
            int result = Search.LinePoisk(array, 1);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Line_Find1()
        {
            // Act
            int result = Search.LinePoisk(array, 0);

            // Assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void Line_Find2()
        {
            // Act
            int result = Search.LinePoisk(array, 100);

            // Assert
            Assert.AreEqual(result, -1);
        }
    }
}
