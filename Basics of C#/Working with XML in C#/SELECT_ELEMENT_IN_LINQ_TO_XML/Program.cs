using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
namespace Выборка_элементов_в_LINQ_to_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Переберем его элементы people.xml
            XDocument xdoc = XDocument.Load(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Выборка_элементов_в_LINQ_to_XML\people.xml");
            XElement? people = xdoc.Element("people");

            if(people != null)
            {
                foreach (XElement person in people.Elements("person"))
                {
                    XAttribute? name = person.Attribute("name");
                    XElement? company = person.Element("company");
                    XElement? age = person.Element("age");

                    Console.WriteLine($"Person: {name?.Value}");
                    Console.WriteLine($"Company: {company?.Value}");
                    Console.WriteLine($"Age: {age?.Value}");

                    Console.WriteLine();
                }
            }

            //___________________________________________________________________________________________________________________________
            Console.WriteLine("_________________");
            //
            //Сочетая операторы Linq и LINQ to XML
            //можно довольно просто извлечь из документа данные и затем обработать их

            var microsoft = xdoc.Element("people")?
                                .Elements("person")
                                .Where(p => p.Element("company")?.Value == "Microsoft")
                                .Select(p => new
                                {
                                    name = p.Attribute("name")?.Value,
                                    company = p.Element("company")?.Value,
                                    age = p.Element("age")?.Value
                                });

            if(microsoft != null)
            {
                foreach (var person in microsoft)
                {
                    Console.WriteLine($"Name: {person.name} - Company: {person.company} - Age: {person.age}");
                }
            }

            Console.WriteLine("_______________________");
            //________________________________________________________________________________
            //Другой пример - выберем элемент person, в котором атрибут name равен "Tom":

            var tom = xdoc.Element("people")
                          .Elements("person")
                          .FirstOrDefault(p => p.Attribute("name").Value == "Tom");

            var tom_name = tom.Attribute("name").Value;
            var tom_company = tom.Element("company").Value;
            var tom_age = tom.Element("age").Value;
            Console.WriteLine($"Name - {tom_name}");
            Console.WriteLine($"Company - {tom_company}");
            Console.WriteLine($"Age - {tom_age}");




        }
    }
}
