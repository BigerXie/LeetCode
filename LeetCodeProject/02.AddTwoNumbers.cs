using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeProject
{
    [TestClass]
    public class AddTwoNumbersUnitTest
    {
        private ListNode listA;
        private ListNode listB;
        private ListNode listLongA;
        private ListNode listLongB;
        [TestInitialize]
        public void Initialize()
        {
            listA = new ListNode(2);
            listA.next = new ListNode(4);
            listA.next.next = new ListNode(3);
            listB = new ListNode(5);
            listB.next = new ListNode(6);
            listB.next.next = new ListNode(4);
            var arrayA = new int[61] { 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 9 };
            listLongA = this.ArrayToListNode(arrayA);
            var arrayB = new int[61] { 5, 6, 4, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 2, 4, 3, 9, 9, 9, 9 };
            listLongB = this.ArrayToListNode(arrayB);
        }

        private ListNode ArrayToListNode(int[] array)
        {
            ListNode result = null;
            ListNode lastNode = null;
            for (int i = 0; i < array.Length; i++)
            {
                var newNode = new ListNode(array[i]);
                if (result == null)
                {
                    result = newNode;
                }
                else
                {
                    lastNode.next = newNode;
                }
                lastNode = newNode;
            }
            return result;
        }

        [TestMethod]
        public void AddTwoNumbersTest()
        {
            //var result = AddTwoNumbers_MyErrorSolution(listA, listB);
            //var result = AddTwoNumbers_MyErrorSolution(listLongA, listLongB);

            var result = AddTwoNumbers_LeetCodeSolution(listLongA, listLongB);

            Assert.AreEqual(7, result.val);
            Assert.AreEqual(0, result.next.val);
            Assert.AreEqual(8, result.next.next.val);
        }

        /// <summary>
        /// My Solution
        /// </summary>
        private ListNode AddTwoNumbers_MySolution(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            ListNode lastNode = null;
            int fact = 0;
            do
            {
                int v1 = l1 == null ? 0 : l1.val;
                int v2 = l2 == null ? 0 : l2.val;
                int sum = v1 + v2 + fact;
                int value = 0;
                if (sum >= 10)
                {
                    fact = 1;
                    value = sum - 10;
                }
                else
                {
                    fact = 0;
                    value = sum;
                }
                var newNode = new ListNode(value);
                if (result == null)
                {
                    result = newNode;
                }
                else
                {
                    lastNode.next = newNode;
                }
                lastNode = newNode;
                l1 = l1?.next;
                l2 = l2?.next;
                //参考LeetCode官方解法后发现，此判断可以移到While循环之外
                if (l1 == null && l2 == null && fact > 0)
                {
                    lastNode.next = new ListNode(fact);
                    //或者可以直接break掉循环了
                }
            } while (l1 != null || l2 != null);
            return result;
        }

        /// <summary>
        /// My Error Solution
        /// 这个方法是先将ListNode转换成数字然后相加，再将结果转换成ListNode
        /// 这个方法的问题就是没有考虑值类型的取值范围，在一些数字超大的情况下long也不能满足
        /// </summary>
        private ListNode AddTwoNumbers_MyErrorSolution(ListNode l1, ListNode l2)
        {
            long num1 = ConvertToNumber(l1);
            long num2 = ConvertToNumber(l2);
            long sum = num1 + num2;
            ListNode result = null;
            ListNode lastNode = null;
            do
            {
                int value = Convert.ToInt32(sum < 10 ? sum : sum % 10);
                var newNode = new ListNode(value);
                if (result == null)
                {
                    result = newNode;
                }
                else
                {
                    lastNode.next = newNode;
                }
                lastNode = newNode;
                sum = sum / 10;

            } while (sum > 0);
            return result;
        }

        private long ConvertToNumber(ListNode listNode)
        {
            long result = listNode.val;
            long fact = 10;
            var next = listNode.next;
            while (next != null)
            {
                result = result + next.val * fact;
                fact = fact * 10;
                next = next.next;
            }
            return result;
        }

        /// <summary>
        /// LeetCode Solution
        /// </summary>
        private ListNode AddTwoNumbers_LeetCodeSolution(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
