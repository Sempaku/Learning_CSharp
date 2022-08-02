using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Сортировка
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Оператор orderby и метод OrderBy
            int[] numbers = { 6, 2, 8, 1, 4, 5, 5, 4, 7, 86, 1 };
            var orderNumbers = from i in numbers
                               orderby i
                               select i;
            print(orderNumbers);
            Tire();

            var orderNumbers2 = numbers.OrderBy(p => p);
            print(orderNumbers2);

            // Сортировка сложных объектов
            var peopleDiffSort = new List<Person>
            {
                new Person("Sanya", 38),
                new Person("Jenya", 22),
                new Person("Greg", 44),
                new Person("Maks", 19),
                new Person("Egor", 6)
            };
            var sortedPeople1 = from p in peopleDiffSort
                                orderby p.Name
                                select p;
            Person.printPerson(sortedPeople1);
            Tire();
            var sortedPeople2 = peopleDiffSort.OrderBy(p => p.Name);
            Person.printPerson(sortedPeople2);

            Tire();
            //__________________________________________________________
            //Сортировка по возрастанию и убыванию
            //ascending (сортировка по возрастанию)
            //descending (сортировка по убыванию)
            //для оператора orderby
            var orderedNumDescend = from i in numbers
                                    orderby i descending
                                    select i;
            print(orderedNumDescend);
            Tire();

            var orderedNumAscending = numbers.OrderBy(p => p);
            Tire();

            //______________________________________________________________
            //Множественные критерии сортировки
            //отсортировать не по одному, а сразу по нескольким полям
            var sortedPeople3 = from p in peopleDiffSort
                                orderby p.Name, p.Age
                                select p;
            Person.printPerson(sortedPeople3);
            Tire();

            //_______________________________________________________________
            //Переопределение критерия сортировки
            //С помощью реализации IComparer мы можем переопределить критерии сортировки,
            //если они нас не устраивают. Например, строки по умолчанию сортируются
            //в алфавитном порядке. Но что, если мы хотим сортировать строки исходя из их длины?

            string[] people = new[] { "Kate", "Tom", "Sam", "Mike", "Alice" };
            var sortedPeople = people.OrderBy(p => p, new CustomStringComparer());

            print(sortedPeople);
        }

        private static void Tire() => Console.WriteLine("_________________________");

        private static void print(IEnumerable enumer)
        {
            foreach (var x in enumer)
                Console.WriteLine(x);
        }
    }

    internal class CustomStringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            int xLen = x?.Length ?? 0;
            int yLen = y?.Length ?? 0;

            return xLen - yLen;
        }
    }

    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public static void printPerson(IEnumerable person)
        {
            foreach (Person p in person)
                Console.WriteLine($"{p.Name} -- {p.Age}");
        }
    }
}