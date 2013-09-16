using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace HHSDemo1
{
    interface IDemo
    {
        void DoDemo();
    }

    class InterfaceImplicit : IDemo
    {

        public void DoDemo()
        {
            
        }
    }

    class ExplicitDemo : IDemo
    {
        void IDemo.DoDemo()
        {
        }
    }

    class NotImplementingIterface
    {
    }

    [TestClass]
    public class InterfaceDemo
    {
        [TestMethod]
        public void TestMethod1()
        {
            var impl = new InterfaceImplicit();
            impl.DoDemo();

            ExplicitDemo expl = new ExplicitDemo();
            ((IDemo)expl).DoDemo();

            IDemo expl2 = new ExplicitDemo();
            expl2.DoDemo();

            // Instantie moet interface implementeren
            //IDemo nii = new NotImplementingIterface();


        }
    }
}
