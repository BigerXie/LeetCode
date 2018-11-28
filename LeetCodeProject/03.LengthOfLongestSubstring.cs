using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeProject
{
    [TestClass]
    public class LengthOfLongestSubstringUnitTest
    {

        private string strA;
        private string strB;
        private string strC;
        private string strD;
        private string strE;
        [TestInitialize]
        public void Initialize()
        {
            this.strA = "abcabcbb";
            this.strB = "bbbbb";
            this.strC = "pwwkew";
            this.strD = "abcdefg";
            this.strE = "dvdf";
        }

        [TestMethod]
        public void LengthOfLongestSubstringTest()
        {
            var resultA = this.LengthOfLongestSubstring_MySolutioin(strA);
            var resultB = this.LengthOfLongestSubstring_MySolutioin(strB);
            var resultC = this.LengthOfLongestSubstring_MySolutioin(strC);
            var resultD = this.LengthOfLongestSubstring_MySolutioin(strD);
            var resultE = this.LengthOfLongestSubstring_MySolutioin(strE);

            Assert.AreEqual(3, resultA);
            Assert.AreEqual(1, resultB);
            Assert.AreEqual(3, resultC);
            Assert.AreEqual(7, resultD);
            Assert.AreEqual(3, resultE);
        }

        /// <summary>
        /// My Solution
        /// </summary>
        private int LengthOfLongestSubstring_MySolutioin(string s)
        {
            var result = 0;
            var chars = s.ToCharArray();
            List<char> tempChars = new List<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (tempChars.Contains(chars[i]))
                {
                    if (tempChars.Count > result)
                        result = tempChars.Count;
                    var index = tempChars.IndexOf(chars[i]);
                    tempChars.RemoveRange(0, index + 1);
                }
                tempChars.Add(chars[i]);
            }
            if (tempChars.Count > result)
                result = tempChars.Count;
            return result;
        }
    }
}
