using System;
using System.Collections.Generic;
using System.Xml;

namespace XML_документы
{
    class Program
    {
        static void Main(string[] args)
        {
            var empl = new List<Person>
            {
                new Person("Tom", 31, "Microsoft"),
                new Person("Dima", 20, "Gradus")
            };

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\XML-документы\XMLFile1.xml");

            XmlElement xRoot = xDoc.DocumentElement;
            if(xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    Console.WriteLine(attr?.Value);

                    foreach (XmlNode childnote in xnode.ChildNodes)
                    {
                        if (childnote.Name == "company" )
                            Console.WriteLine($"Company: {childnote.InnerText}");
                        if (childnote.Name == "age")
                            Console.WriteLine($"Age: {childnote.InnerText}");

                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("____________________________");

            //_________________________________________________________________________
            //Изменение XML-документа

            XmlElement personElem = xDoc.CreateElement("person");
            XmlAttribute nameAttr = xDoc.CreateAttribute("name");

            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("age");

            XmlText nameText = xDoc.CreateTextNode("Mark");
            XmlText companyText = xDoc.CreateTextNode("Facebook");
            XmlText ageText = xDoc.CreateTextNode("30");

            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);

            personElem.Attributes.Append(nameAttr);
            personElem.AppendChild(companyElem);
            personElem.AppendChild(ageElem);

            xRoot?.AppendChild(personElem);

            xDoc.Save(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\XML-документы\XMLFile1.xml");









        }
    }

    class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public string Company { get; set; }
        public Person(string name, int age, string company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
    }
}
