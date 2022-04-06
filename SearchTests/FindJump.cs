using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5;

namespace FindJump
{
    [TestClass]
    public class FindJumpTests
    {
        public static int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [TestMethod]
        public void Jump_Find0()
        {
            // Act
            int result = Search.Jump(array, 1);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Jump_Find1()
        {
            // Act
            int result = Search.Jump(array, 0);

            // Assert
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void Jump_Find2()
        {
            // Act
            int result = Search.Jump(array, 5);

            // Assert
            Assert.AreEqual(result, 4);
        }
    }
}
