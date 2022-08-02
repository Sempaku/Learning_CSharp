using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;


namespace Изменение_документа_в_LINQ_to_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Добавление данных
            XDocument xdoc = XDocument.Load(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Изменение_документа_в_LINQ_to_XML\people.xml");
            XElement? root = xdoc.Element("people");

            if(root != null)
            {
                root.Add(new XElement("person",
                                              new XAttribute("name", "Sam"),
                                              new XElement("company", "Jet"),
                                              new XElement("age", 11)));
                xdoc.Save(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Изменение_документа_в_LINQ_to_XML\people.xml");
            }

            Console.WriteLine(root);

            //_______________________________________________________________________
            //Изменение данных

            var tom = xdoc.Element("people")
                          .Elements("person")
                          .FirstOrDefault(p => p.Attribute("name").Value == "Tom");

            if(tom != null)
            {
                var name = tom.Attribute("name");
                if (name != null) name.Value = "Jerry";

                var age = tom.Element("age");
                if (age != null) age.Value = "-1";

                xdoc.Save(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Изменение_документа_в_LINQ_to_XML\people.xml");

            }

            //_____________________________________________________________________________________
            //Удаление данных
            
            if (root != null)
            {
                var sam = root.Elements("person")
                              .FirstOrDefault(p => p.Attribute("name").Value == "Sam");

                if(sam != null)
                {
                    sam.Remove();
                    xdoc.Save(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Изменение_документа_в_LINQ_to_XML\people.xml");

                }
            }


        }
    }
}
