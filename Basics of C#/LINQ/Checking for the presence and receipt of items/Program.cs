using System;
using System.Collections.Generic;
using System.Linq;

//Ряд методов в LINQ позволяют проверить наличие элементов в коллекции и получить их.
namespace Проверка_наличия_и_получение_элементов
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //All
            //Метод All() проверяет, соответствуют ли все элементы условию.
            //Если все элементы соответствуют условию, то возвращается true.
            string[] people = { "Tom", "Tim", "Bob", "Sam" };

            //// проверяем, все ли элементы имеют длину в 3 символа
            bool allHas3Chars = people.All(p => p.Length == 3);
            Console.WriteLine(allHas3Chars);

            // проверяем, все ли строки начинаются на T
            bool allStartWithT = people.All(s => s.StartsWith('T'));
            Console.WriteLine(allStartWithT);

            tire();

            //___________________________________________________________
            //Any
            //Метод Any() действует подобным образом, только возвращает true,
            //если хотя бы один элемент коллекции определенному условию:

            // проверяем, все ли элементы имеют длину больше 3 символов
            bool allHasMore3Chars = people.Any(s => s.Length > 3);     // false
            Console.WriteLine(allHasMore3Chars);

            // проверяем, все ли строки начинаются на T
            bool allStartsWithT = people.Any(s => s.StartsWith("T"));   // true
            Console.WriteLine(allStartsWithT);

            tire();

            //_____________________________________________________________
            //Contains
            //Метод Contains() возвращает true, если коллекция содержит определенный элемент.

            bool hasTom = people.Contains("Tom");
            Console.WriteLine(hasTom); //true

            bool hasMike = people.Contains("Mile");
            Console.WriteLine(hasMike); //false

            //Стоит отметить, что для сравнения объектов применяется реализация метода Equals.
            //Соответственно если мы работаем с объектами своих типов,
            //то мы можем реализовать данный метод
            tire();
            Person[] peoples2 = { new Person("Tom"), new Person("Sam"), new Person("Bob") };

            var tom = new Person("Tom");
            var mike = new Person("Mike");

            string[] pp = { "tim", "Tom", "bOb" };

            bool hasTomInPeople = peoples2.Contains(tom); // true
            Console.WriteLine(hasTomInPeople);

            bool hasMikeInPerson = peoples2.Contains(mike); //false
            Console.WriteLine(hasMikeInPerson);

            bool hasBob = pp.Contains("Bob"); //false
            Console.WriteLine(hasBob);
            //then -->
            bool hasBob2 = pp.Contains("Bob", new CustomStringComparer()); //true
            Console.WriteLine(hasBob2);

            tire();
            //_______________________________________________________________________
            //First/FirstOrdefault / Last и LastOrDefault
            //Метод First() возвращает первый элемент последовательности:

            string[] people2 = { "Tome", "Sam", "Bob" };
            var firstWith4Char = people2.First(p => p.Length == 4);
            Console.WriteLine(firstWith4Char);

            tire();

            //FirstOrDefault
            //Метод FirstOrDefault() также возвращает первый элемент и также может принимать условие,
            //только если коллекция пуста или в коллекции не окажется элементов,
            //которые соответствуют условию, то метод возвращает значение по умолчанию

            var first = people2.FirstOrDefault(); //tome
            Console.WriteLine(first);

            var firstwith4chars = people2.FirstOrDefault(s => s.Length == 3);
            Console.WriteLine(firstwith4chars);

            string? lastWithError = people2.LastOrDefault(p => p.Length == 3);
        }

        private static void tire() => Console.WriteLine("_________________________");
    }

    internal class Person
    {
        public string Name { get; set; }

        public Person(string name) => Name = name;

        public override bool Equals(object? obj)
        {
            if (obj is Person person) return Name == person.Name;
            return false;
        }

        public override int GetHashCode() => Name.GetHashCode();
    }

    internal class CustomStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x is null || y is null) return false;
            return x.ToLower() == y.ToLower();
        }

        public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
    }
}