using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HHSDemo1
{
    delegate void Print();
    delegate void Print<T>(T param1);
    delegate void Print<T1, T2>(T1 param1, T2 param2);
    delegate TResult Print<TResult, T1, T2>(T1 param1, T2 param2);

    [TestClass]
    public class DelegateTest : HHSDemo1.IDelegateTest
    {
        private decimal _salary;

        [TestMethod]
        public void TestMethod1()
        {
            var target = new ExternalUsingDelegate();
            target.Execute(this);
        }

        public void MethodMatchingPrintDelegate()
        {
            Console.WriteLine(_salary);
        }
    }

    class ExternalUsingDelegate
    {
        private int _age;

        public void Execute(IDelegateTest p)
        {
            p.MethodMatchingPrintDelegate();
        }
    }
}
