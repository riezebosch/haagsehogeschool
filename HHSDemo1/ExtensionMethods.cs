using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HHSDemo1
{
    internal static class StringExt
    {
        public static void Spunge(this string input)
        {

        }

        public static void DoSomething(this IExtensionDemo input)
        {
        }

        public static void Print<T>(this IList<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    interface IExtensionDemo
    {
    }

    [TestClass]
    public class ExtensionMethods
    {
        [TestMethod]
        public void TestMethod1()
        {
            "willekeurige string".Spunge();

            //IExtensionDemo test;
            //test.DoSomething();

            List<int> items = new List<int> { 1, 3, 23, 534, 43, 545 };

            items.Print();
            StringExt.Print(items);
        }
    }
}
