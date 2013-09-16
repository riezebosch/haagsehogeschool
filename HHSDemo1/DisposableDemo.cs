using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HHSDemo1
{
    [TestClass]
    public class DisposableDemo
    {
        class MyDisposable : IDisposable
        {
            public FileStream MyStream { get; set; }
            public void Dispose()
            {

                MyStream.Dispose();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            MyDisposable target = null;
            try
            {
                target = new MyDisposable();
            }
            finally
            {
                if (target != null)
                {
                    target.Dispose();
                }
            }

            using (MyDisposable target2 = new MyDisposable())
            {
            }

        }
    }
}
