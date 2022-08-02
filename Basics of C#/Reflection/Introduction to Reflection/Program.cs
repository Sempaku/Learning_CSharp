using System;
using System.Reflection;

namespace Введение_в_рефлексию_Класс_SystemType
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Type mytype = typeof(Person);
            Console.WriteLine(mytype);

            //2
            Person tom = new Person("Tom");
            Type typeTom = tom.GetType();
            Console.WriteLine(typeTom);

            //3
            Type? typeTommy = Type.GetType("Person", false, true);
            Console.WriteLine(typeTommy);


            Type? nameSpaceType = Type.GetType("NewSpace.Pers", false, true);
            Console.WriteLine(nameSpaceType);

            //______________________________________________________________
            Type t = typeof(NewSpace.Pers);

            Console.WriteLine($"Name: {t.Name}");
            Console.WriteLine($"FullName: {t.FullName}");
            Console.WriteLine($"Namespace: {t.Namespace}");
            Console.WriteLine($"Is struct: {t.IsValueType}");
            Console.WriteLine($"Is class: {t.IsClass}");

            Console.WriteLine("_____________");
            //__________________________________________________________________
            //Поиск реализованных интерфейсов
            Type manType = typeof(Man);

            Console.WriteLine("Реализованные интерфейсы");
            foreach(var i in manType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }

        }
    }
    public class Man : IEater, IMovable
    {
        public string Name { get; }
        public Man(string name) => Name = name;
        public void Eat() => Console.WriteLine($"{Name} eats");
        public void Move() => Console.WriteLine($"{Name} moves");
    }
    interface IEater
    {
        void Eat();
    }
    interface IMovable
    {
        void Move();
    }

    class Person
    {
        public string Name { get; set; }
        public Person(string name) => Name = name;
    }
}
namespace NewSpace
{
    public class Pers
    {
        public string Name { get; set; }
        public Pers(string name) => Name = name;
    }
}