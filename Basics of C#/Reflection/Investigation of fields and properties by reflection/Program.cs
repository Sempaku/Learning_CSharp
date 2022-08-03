using System;
using System.Reflection;


namespace Исследование_полей_и_свойств_с_помощью_рефлексии
{
    class Program
    {
        static void Main(string[] args)
        {
            //Получение информации о полях

            Type myType = typeof(PersonWithFields);
            Console.WriteLine("Fields: ");

            foreach(FieldInfo field in myType.GetFields(BindingFlags.Instance |
                                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string mod = "";

                if (field.IsPublic) mod += "public ";
                else if (field.IsPrivate) mod += "private ";
                else if (field.IsAssembly) mod += "internal ";
                else if (field.IsFamily) mod += "protected ";
                else if (field.IsFamilyAndAssembly) mod += "private protected ";
                else if (field.IsFamilyOrAssembly) mod += "protected internal ";

                if (field.IsStatic) mod += "static ";

                Console.WriteLine($"{mod} {field.FieldType.Name} {field.Name}");                  
            }

            Console.WriteLine("________________");
            //___________________________________________________________________
            // Получение и изменение значения поля

            Type personType = typeof(PersonWithFields);
            PersonWithFields tom = new PersonWithFields("Tom", 32);

            var name = personType.GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);

            var value = name?.GetValue(tom);
            Console.WriteLine(value); // Tom

            name?.SetValue(tom, "Semyon");
            tom.Print();

            Console.WriteLine("__________________________");
            //________________________________________________________________________________________
            //Свойства


            Type person2Type = typeof(PersonWithProperties);
            foreach(PropertyInfo prop in person2Type.GetProperties(BindingFlags.Instance |
                               BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                Console.Write($"{prop.PropertyType} {prop.Name} {{");

                if (prop.CanRead) Console.Write("get; ");
                if (prop.CanWrite) Console.Write("set; ");
                Console.WriteLine("}");
            }

            PersonWithProperties sam = new PersonWithProperties("Sam", 2);
            var ageProp = person2Type.GetProperty("Age");
            var age = ageProp?.GetValue(sam);
            Console.WriteLine(age) ;

            ageProp?.SetValue(sam, 1000);
            sam.Print();




        }
    }
    class PersonWithProperties
    {
        public string Name { get; }
        public int Age { get; set; }
        public PersonWithProperties(string name, int age)
        {
            Name = name; Age = age;
        }
        public void Print() => Console.WriteLine($"{Name} - {Age}");
    }
    class PersonWithFields
    {
        static int minAge = 0;
        string name;
        int age;
        public PersonWithFields(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void Print() => Console.WriteLine($"{name} - {age}");
    }
}
