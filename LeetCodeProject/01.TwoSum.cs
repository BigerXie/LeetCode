using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeProject
{
    [TestClass]
    public class TwoSumUnitTest
    {
        private int[] nums;
        private int target;
        [TestInitialize]
        public void Initialize()
        {
            this.nums = new int[4] { 2, 7, 11, 15 };
            this.target = 18;
        }

        [TestMethod]
        public void TwoSumTest()
        {
            var result = this.TwoSum_LeetCodeSolution3(nums, target);

            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        /// <summary>
        /// My Solution
        /// </summary>
        private int[] TwoSum_MySolution(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// LeetCode Solution 1
        /// </summary>
        private int[] TwoSum_LeetCodeSolution1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new ArgumentException("No two sum solution");
        }

        /// <summary>
        /// LeetCode Solution 2
        /// </summary>
        private int[] TwoSum_LeetCodeSolution2(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map.Add(nums[i], i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement) && map[complement] != i)
                {
                    return new int[] { i, map[complement] };
                }
            }
            throw new ArgumentException("No two sum solution");
        }

        /// <summary>
        /// LeetCode Solution 3
        /// </summary>
        private int[] TwoSum_LeetCodeSolution3(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map.Add(nums[i], i);
            }
            throw new ArgumentException("No two sum solution");
        }

    }
}
