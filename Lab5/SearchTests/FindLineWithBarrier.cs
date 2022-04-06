using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5;

namespace FindLineWithBarrier
{
    [TestClass]
    public class FindLineWithBarrierTests
    {
        public static int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0};

        [TestMethod]
        public void LineWithBarrier_Find0()
        {
            // Act
            int result = Search.LineWithBarrier(array, 1);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void LineWithBarrier_Find1()
        {
            // Act
            int result = Search.LineWithBarrier(array, 10);

            // Assert
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void LineWithBarrier_Find2()
        {
            // Act
            int result = Search.LineWithBarrier(array, 5);

            // Assert
            Assert.AreEqual(result, 4);
        }
    }
}
