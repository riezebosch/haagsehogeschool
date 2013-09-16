using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace HHSDemo1
{
    [TestClass]
    public class ReflectionDemo
    {
        class MySecret
        {
            private readonly int _code = 123;

            public MySecret()
            {
                _code = DateTime.Now.Millisecond;
            }

            public void Print()
            {
                Console.WriteLine(_code);
            }
        }

        [TestMethod]
        public void SetMySecret()
        {
            var target = new MySecret();
            target.GetType().GetField("_code", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(target, 1234);

            target.Print();
        }

        [MyCustom]
        public void Print([ReadOnly(true)] string location)
        {
            Console.WriteLine(location);
        }

        [Key]
        [XmlElement("Name")]
        public int Id { get; set; }

        class MyCustomAttribute : Attribute
        {

        }
    }
}
