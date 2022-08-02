using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Сериализация_в_XML_XmlSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cериализация
            Person person = new Person("Sam", 19);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Сериализация_в_XML_XmlSerializer\pers.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, person);

                Console.WriteLine("Object has been serialized");
            }

            //Десериализация

            using (FileStream fs = new FileStream(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Сериализация_в_XML_XmlSerializer\pers.xml", FileMode.OpenOrCreate))
            {
                Person? p = xmlSerializer.Deserialize(fs) as Person;
                Console.WriteLine($"Name: {p.Name} - Age: {p.Age}");
            }

            Console.WriteLine("_____");
            //______________________________________________________________________
            //Сериализация и десериализация коллекций



            Person[] people = new Person[]
            {
                new Person("Jack", 11),
                new Person("Heng", 39)
            };

            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Сериализация_в_XML_XmlSerializer\coll.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }

            using (FileStream fs = new FileStream(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Сериализация_в_XML_XmlSerializer\coll.xml", FileMode.OpenOrCreate))
            {
                Person[]? collection = formatter.Deserialize(fs) as Person[];

                if(collection != null)
                {
                    foreach (Person p in collection)
                    {
                        Console.WriteLine($"Name: {p.Name} - Age: {p.Age}");
                    }
                }
            }





        }
    }

    public class Person
    {
        public string Name { get; set; } = "Undefind";
        public int Age { get; set; } = 1;

        public Person() {}

        public Person(string name, int age)
        {
            Name = name; Age = age;
        }

    }
}
