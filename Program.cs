using System;
using System.Linq;

namespace LinqQuery
{
    public class Program
    {
        class famousPeople
        {
            public string Name { get; set; }
            public int? BirthYear { get; set; } = null;
            public int? DeathYear { get; set; } = null;
        }

        static void Main(string[] args)
        {

            IList<famousPeople> stemPeople = new List<famousPeople>() {
                new famousPeople() { Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                new famousPeople() { Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                new famousPeople() { Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
                new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                new famousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
                new famousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
                new famousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                new famousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
                new famousPeople() {Name = "Terence Tao", BirthYear=1975 },
                new famousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                new famousPeople() {Name = "George Washington Carver", DeathYear=1943 },
                new famousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                new famousPeople() {Name = "Bill Gates", BirthYear=1955 }
            };

            var over1900 = from s in stemPeople
                           where s.BirthYear > 1900
                           select s;
            Console.WriteLine("These famous people were born after 1900:");
            foreach (famousPeople f in over1900) 
            {
                Console.WriteLine(f.Name);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            var lowerL = from s in stemPeople
                         where s.Name.Contains("ll")
                         select s;
            Console.WriteLine("These famous people have two lowercase L's in their name:");
            foreach (famousPeople f in lowerL)
            { 
                Console.WriteLine(f.Name); 
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            
            var ageOver50 = stemPeople.Count(s => s.BirthYear>1950);
            Console.WriteLine("There are " + ageOver50 + " famous people born after 1950!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            var birthBetween = from s in stemPeople
                               where s.BirthYear > 1920
                               where s.BirthYear < 2000
                               select s;
            var birthCount = birthBetween.Count();
            Console.WriteLine("There are " + birthCount + " famous people that were born between 1920 and 2000. Here are their names: ");
            foreach(famousPeople f in birthBetween) 
            { 
                Console.WriteLine(f.Name); 
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            var orderedBirth = from s in stemPeople
                               orderby s.BirthYear
                               select s;
            Console.WriteLine("Here is the list of famous people sorted by birth year:");
            foreach(famousPeople f in orderedBirth)
            {
                Console.WriteLine(f.Name);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            var orderedDeath = from s in stemPeople
                               where s.DeathYear > 1960
                               where s.DeathYear < 2015
                               orderby s.Name
                               select s;
            Console.WriteLine("These famous people died between 1960 and 2015:");
            foreach (famousPeople f in orderedDeath)
            {
                Console.WriteLine(f.Name);
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}