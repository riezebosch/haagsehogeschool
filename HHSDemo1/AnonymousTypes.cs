using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HHSDemo1
{
    [TestClass]
    public class AnonymousTypes
    {
        [TestMethod]
        public void TestAnonymousClass()
        {
            var persoon = new { Naam = "Manuel Riezebosch", Leeftijd = 31 };

            Console.WriteLine(persoon.Leeftijd);

        }

        class Persoon
        {
            public string Naam { get; set; }
            public int Leeftijd { get; set; }
        }

        [TestMethod]
        public void TestObjectInitializer()
        {
            var persoon = new Persoon 
            { 
                Leeftijd = 31, 
                Naam = "Manuel Riezebosch" 
            };

            
            var persoon2 = new Persoon();
            persoon2.Leeftijd = 31;
            persoon2.Naam = "Manuel Riezebosch";

        }

        [TestMethod]
        public void MyTestMethod()
        {
            var target = Initialiseer();
        }

        private object Initialiseer()
        {
            return new { School = "HHS", Opleiding = "Informatica" };
        }

        [TestMethod]
        public void ShowMeTheLambdas()
        {
            var personen = new List<Persoon>
            {
                new Persoon { Naam = "Manuel Riezebosch", Leeftijd = 31},
                new Persoon { Naam = "Ezra", Leeftijd = 3}
            };

            var result = personen.Where(Filter).Select(Select);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Manuel Riezebosch", result.First());
        }

        private bool Filter(Persoon p)
        {
            return p.Leeftijd > 3;
        }

        private string Select(Persoon p)
        {
            return p.Naam;
        }
    }
}
