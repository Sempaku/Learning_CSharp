using System;

namespace Атрибуты_в_NET
{
    class Program
    {
        static void Main(string[] args)
        {

            Person anna = new Person("Anna",11);
            Person tom = new Person("Tom", 33);
            bool annaIsValidAge = ValidationUser(anna);
            bool tomIsValidAge = ValidationUser(tom);

            Console.WriteLine(annaIsValidAge); //false
            Console.WriteLine(tomIsValidAge); //true


            bool ValidationUser(Person person)
            {
                Type type = typeof(Person);
                object[] attributes = type.GetCustomAttributes(false);

                foreach (Attribute attr in attributes)
                {
                    if(attr is AgeValidationAttribute ageAttr)
                    {
                        return person.Age >= ageAttr.Age;
                    }
                }
                return false;
            }
        }
    }

    //Создадим свой атрибут, который будет хранить пороговое значение возраста,
    //с которого разрешены некоторые действия
    class AgeValidationAttribute : Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age) => Age = age;
    }

    [AgeValidation(18)]
    public class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name , int age)
        {
            Name = name; Age = age;
        }
    }
}
