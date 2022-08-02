using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person tom = new Person("Tom");
            Console.WriteLine($"Hola, {tom.Name}");
        }
    }
    class Person
    {
        public string Name { get; set; }
        public Person(string name) => Name = name;
    }
}
