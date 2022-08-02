using System;
using System.Linq;
using System.Xml.Linq;

namespace Linq_to_Xml_Создание_документа_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            XDocument xdoc = new XDocument();

            XElement tom = new XElement("person");
            XAttribute tomNameAttr = new XAttribute("name", "Tom");

            XElement tomCompanyElem = new XElement("company", "Microsoft");
            XElement tomAgeElem = new XElement("age", 37);

            tom.Add(tomNameAttr);
            tom.Add(tomCompanyElem);
            tom.Add(tomAgeElem);
            ///
            ///
            XElement bob = new XElement("person");
            XAttribute bobNameAttr = new XAttribute("name", "Bob");

            XElement bobCompanyElem = new XElement("company", "Google");
            XElement bobAgeElem = new XElement("age", 11);

            bob.Add(bobNameAttr);
            bob.Add(bobCompanyElem);
            bob.Add(bobAgeElem);

            //create root element
            XElement people = new XElement("people");
            people.Add(tom);
            people.Add(bob);

            xdoc.Add(people);

            xdoc.Save(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Linq_to_Xml_Создание_документа_XML\ll.xml");

            Console.WriteLine("Data saved!");

            //____________________________________________________________




        }
    }
}
