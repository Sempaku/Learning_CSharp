using System;
using System.Reflection;


namespace Применение_рефлексии_и_исследование_типов
{
    class Program
    {
        static void Main(string[] args)
        {
            //Получение всех компонентов типа
            Type myType = typeof(Person);
            foreach(MemberInfo member in myType.GetMembers())
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");

            //____________________________________________________________________________
            Console.WriteLine("________________");

            //BindingFlags


            foreach (MemberInfo member in myType.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance
                                                | BindingFlags.NonPublic | BindingFlags.Public))
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");

            //_________________________________________________________________________________
            Console.WriteLine("_________________");

            //Получение одного компонента по имени
            MemberInfo[] print = myType.GetMember("Print", BindingFlags.Instance | BindingFlags.Public);
            foreach(MemberInfo member in print)
                Console.WriteLine($"{member.MemberType} {member.Name}");

        }
    }

    class Person
    {
        string name;
        public int Age { get; set; }
        public Person(string name, int age)
        {
            this.name = name;
            this.Age = age;
        }
        public void Print() => Console.WriteLine($"Name : {name} Age:{Age}");
    }
}
