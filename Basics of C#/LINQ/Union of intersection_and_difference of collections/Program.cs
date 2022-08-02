using System;
using System.Collections;
using System.Linq;

namespace Объединение_пересечение_и_разность_коллекций
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Разность последовательностей
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            var result = soft.Except(hard); // Google Microsoft

            print(result);

            tire();
            //________________________________________________________
            //Пересечение последовательностей
            var result2 = soft.Intersect(hard);
            print(result2); //Apple

            tire();
            //_________________________________________________________
            // Удаление дубликатов
            string[] dub = { "Microsoft", "Apple", "IBM", "Microsoft", "Apple" };
            var result3 = dub.Distinct();
            print(result3); // Microsoft Apple IBM

            tire();
            //_____________________________________________________________
            //Объединение последовательностей, повторы добавляются 1 раз
            var result4 = soft.Union(hard); //Microsoft Google Apple IBM Samsung
            print(result4);

            //Если же нам нужно простое объединение двух наборов,
            //то мы можем использовать метод Concat:
            tire();
            var result5 = soft.Concat(hard); //Microsoft Google Apple Apple IBM Samsung
            print(result5);

            tire();
            //______________________________________________________________________
            //Работа со сложными объектами

            Person[] students = { new Person("Tom"), new Person("Bob"), new Person("Sam") };
            Person[] employees = { new Person("Tom"), new Person("Bob"), new Person("Mike") };

            // объединение послеовательностей
            var peoples = students.Union(employees);

            foreach (Person person in peoples)
            {
                Console.WriteLine(person.Name);
            }
        }

        private static void print(IEnumerable s)
        {
            foreach (var x in s)
            {
                Console.WriteLine(x);
            }
        }

        private static void tire() => Console.WriteLine("_______________________");
    }

    internal class Person
    {
        public string Name { get; }

        public Person(string name) => Name = name;

        public override bool Equals(object? obj)
        {
            if (obj is Person person) return Name == person.Name;
            return false;
        }

        public override int GetHashCode() => Name.GetHashCode();
    }
}