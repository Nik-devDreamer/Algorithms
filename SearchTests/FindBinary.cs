using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5;

namespace FindBinary
{
    [TestClass]
    public class FindBinaryTests
    {
        public static int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [TestMethod]
        public void Binary_Find0()
        {
            // Act
            int result = Search.Binary(array, 1);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Binary_Find1()
        {
            // Act
            int result = Search.Binary(array, 1000);

            // Assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void Binary_Find2()
        {
            // Act
            int result = Search.Binary(array, 10);

            // Assert
            Assert.AreEqual(result, 9);
        }
    }
}
