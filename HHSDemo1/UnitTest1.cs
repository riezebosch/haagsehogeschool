using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HHSDemo1
{
    class PlaceHolder<T>
    {
        public T Content { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var placeholder = new PlaceHolder<int>();
            placeholder.Content = 3;

            //var dict = new Dictionary<

        }

        [TestMethod]
        public void TestAbstractAndVirtual()
        {
            var target = new MyDerived();
            target.Print(3);
        }

        [TestMethod]
        public void TestDelegate()
        {
            DoSomethingWithADelegate(Convert);
        }

        private static decimal Convert(int input)
        {
            return (decimal)input;
        }

        private static void DoSomethingWithADelegate(MyDelegate methode)
        {
            decimal result = methode(4);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestEvents()
        {
            var target = new EventClass();
            target.Convert += target_Convert;
            
        }

        decimal target_Convert(int input)
        {
            throw new NotImplementedException();
        }
    }

    delegate decimal MyDelegate(int input);

    abstract class MyBase
    {
        public abstract void Print(int input);
    }

    class MyDerived : MyBase
    {
        public override void Print(int input)
        {
            Console.WriteLine(input);
        }
    }

    class EventClass
    {
        public event MyDelegate Convert;
    }
   

}
