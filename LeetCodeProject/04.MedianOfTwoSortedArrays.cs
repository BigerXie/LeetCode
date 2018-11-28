using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeProject
{
    [TestClass]
    public class MedianOfTwoSortedArraysUnitTest
    {
        private int[] numsA;
        private int[] numsB;

        [TestInitialize]
        public void Initialize()
        {
            this.numsA = new int[4] { 2, 3, 4, 5 };
            this.numsB = new int[5] { 3, 4, 5, 6, 7 };
        }

        [TestMethod]
        public void MedianOfTwoSortedArraysTest()
        {


        }

        /// <summary>
        /// My Solution
        /// </summary>
        private double FindMedianSortedArrays_MySolution(int[] numsA, int[] numsB)
        {
            double result = 0;

            return result;
        }
    }
}
