using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HHSDemo1
{
    delegate bool Check<T>(T input);
    static class FilterExt
    {
        public static T[] Filter<T>(this T[] items, Check<T> check)
        {
            var result = new List<T>();
            foreach (var item in items)
            {
                if (check(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }
    }

    [TestClass]
    public class FilterDemo
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] items = { 1, 4, 23, 54, 34, 64534, 2344, 23, 234 };
            var result = items.Filter(IsEven);

            CollectionAssert.DoesNotContain(result, 1);
        }

        [TestMethod]
        public void TestFilteringWithLinq()
        {
            int[] items = { 1, 4, 23, 54, 34, 64534, 2344, 23, 234 };
            var result = items.Where(IsEven);


            CollectionAssert.DoesNotContain(result.ToList(), 1);
        }

        private bool IsEven(int input)
        {
            return input % 2 == 0;
        }
    }
}
