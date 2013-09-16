using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Linq;
using System.Data.Entity;

namespace HHSDemo1
{
    /// <summary>
    /// Summary description for EFDemo
    /// </summary>
    [TestClass]
    public class EFDemo
    {
        public EFDemo()
        {
            using (var entities = new NorthwindEntities())
            {
                // Where did my extension methods go... :S
                //var result = entities.Customers.Where(c => c.ContactName == "Manuel");
            }
        }

    }
}
