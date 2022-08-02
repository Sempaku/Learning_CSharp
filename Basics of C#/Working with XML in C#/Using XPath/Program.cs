using System;
using System.Xml;

namespace Использование_XPath
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\79172\Desktop\metanit\Работа с XML в C#\Использование_XPath\xp.xml");

            XmlElement xRoot = xDoc.DocumentElement;

            //take all childnotes
            XmlNodeList nodes = xRoot.SelectNodes("*");
            XmlNodeList personNodes = xRoot.SelectNodes("person");
            if(nodes != null)
            {
                foreach(XmlNode node in nodes)
                {
                    Console.WriteLine(node.OuterXml);
                }
                foreach (XmlNode node in personNodes)
                {
                    Console.WriteLine(node.SelectSingleNode("@name")?.Value);
                }
                XmlNode childNode = xRoot.SelectSingleNode("person[@name = 'Tom']");
                if(childNode != null)
                    Console.WriteLine(childNode.OuterXml);

            }


        }
    }
}
