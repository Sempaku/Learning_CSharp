using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Фильтрация_коллекции
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] people = { "Tom", "Alice", "Jimmy", "Timmy", "Timon", "Sam", "Dean", "Kai" };

            var selectedPeople = people.Where(p => p.Length == 3);
            print(selectedPeople);

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 141, 52, 75, 84, 4, 25, 86, };

            var selectedNumbers1 = numbers.Where(num => (num > 10 && num % 2 == 0));
            var selectedNumbers2 = from num in numbers
                                   where num > 10 && num % 2 == 0
                                   select num;
            print(selectedNumbers1);
            Console.WriteLine("___");
            print(selectedNumbers2);

            Tire();
            //____________________________________________________________________________________
            //Выборка сложных объектов

            var peoplePerson = new List<Person>()
            {
                new Person("Tom", 22, new List<string>(){"english", "german"}),
                new Person("Alice", 27, new List<string> {"english", "french"}),
                new Person("Sam", 33 , new List<string> { "spanish", "german"}),
                new Person( "Bob", 54, new List<string> { "french", "german"})
            };

            var selectedPeoplePerson1 = from p in peoplePerson
                                        where p.Age > 26
                                        select p;
            var selectedPeoplePerson2 = peoplePerson.Where(p => p.Age > 21);

            Person.printPerson(selectedPeoplePerson1);
            Person.printPerson(selectedPeoplePerson2);

            Tire();
            //_________________________________________________________________________
            //Сложные фильтры

            var selectedPeoplePerson3 = from person in peoplePerson
                                        from lang in person.Languages
                                        where person.Age > 25
                                        where lang == "german"
                                        select person;
            Person.printPerson(selectedPeoplePerson3);
            //or
            Tire();
            var selectedPeoplePerson4 = peoplePerson.SelectMany(p => p.Languages,
                                                               (p, l) => new { Person = p, Lang = l })
                                                               .Where(p => p.Lang == "german" && p.Person.Age < 28)
                                                               .Select(p => p.Person);
            Person.printPerson(selectedPeoplePerson4);

            //_________________________________________________________________________________
            Tire();
        }

        private static void print(IEnumerable enumer)
        {
            foreach (var e in enumer)
                Console.WriteLine(e);
        }

        private static void Tire() => Console.WriteLine("______________________________");
    }

    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }

        public Person(string name, int age, List<string> lang)
        {
            Name = name;
            Age = age;
            Languages = lang;
        }

        public static void printPerson(IEnumerable person)
        {
            foreach (Person p in person)
                Console.WriteLine($"{p.Name}  -  {p.Age}");
        }
    }
}