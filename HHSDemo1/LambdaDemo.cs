using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace HHSDemo1
{
    [TestClass]
    public class LambdaDemo
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] items = { 2, 4, 23, 5, 3, 4, 323, 423, 4 };
            var result = items.Where(Filter);

            var result2 = items.Where(delegate(int i)
            {
                return i % 2 == 0;
            });

            var result3 = items.Where(i => i % 2 == 0);
            var result4 = items.Where((int i) => i % 2 == 0);
            var result5 = items.Where((int i) => { return i % 2 == 0; });
        }

        private bool Filter(int item)
        {
            return item % 2 == 0;
        }

        class Persoon
        {
            public string Voornaam { get; set; }
            public string Achternaam { get; set; }
            public string Tussenvoegsel { get; set; }
        }

        [TestMethod]
        public void TestSelect()
        {
            var personen = new List<Persoon>
            {
                new Persoon { Voornaam = "Manuel", Achternaam = "Riezebosch"},
                new Persoon { Voornaam = "Alex", Achternaam = "Weet ik niet" } 
            };

            var result = personen
                .Where(p => p.Tussenvoegsel != null)
                .Select(p => new { Naam = p.Voornaam + " " + p.Achternaam });

            Assert.AreEqual("Manuel Riezebosch", result.First().Naam);
        }

        [TestMethod]
        public void TestFrom()
        {
            var query = from i in new[] { 3, 2, 45, 2, 34, 1, 8, 3 }
                        where i % 2 == 0
                        select i * 2;

            CollectionAssert.DoesNotContain(query.ToList(), 3);
        }

        [TestMethod]
        public void LinqOefening()
        {
            var plaatsnamen = new List<string>
            { 
                "Amsterdam", "Arnhem", "Amersfoort",
                "Assen", "Amstelveen", "Alphen"
            };

            var query = from p in plaatsnamen
                        where p.Length < 8
                        orderby p.Length, p
                        select p;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            var query2 = plaatsnamen
                .Where(p => p.Length < 8)
                .OrderBy(p => p.Length)
                .ThenBy(p => p);

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }


            /* Opdracht 1;
             * Schrijf één LINQ-query (gebruikmakend van comprehension syntax / query syntax) 
             * die alle korte plaatsnamen (minder dan 8 letters), in volgorde van lengte, en 
             * bij gelijke lengte alfabetisch, oplevert.

             * Opdracht 2. 
             * Schrijf één LINQ-query (gebruikmakend van extension methods / fluent syntax) 
             * die de som bepaalt van de lengtes van alle plaatsnamen die eindigen 
             * op een ‘m’. 
             * (Met één LINQ-query wordt hier een aaneengesloten reeks van extension methods / query operators bedoeld.)

            
             * Opdracht 3. 
             * Bepaal met behulp van LINQ de meest voorkomende eindletter 
             * van de plaatsnamen. Het antwoord is een lijstje dat bestaat uit één element 
             * als er precies één eindletter het vaakst voorkomt, en bestaat uit meerdere 
             * letters als er meerdere eindletters een eerste plaats delen. 
             * Je oplossing mag bestaan uit meerdere queries en/of LINQ-expressies.
             */
        }
    }
}
