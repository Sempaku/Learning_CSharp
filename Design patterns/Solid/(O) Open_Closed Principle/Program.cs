using _O_Open_Closed_Principle_Template;
using System;

namespace _O_Open_Closed_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Run();
            Console.WriteLine("___");
            Kitchen.Run();
            Console.WriteLine("___");
            TemplateKitchen.Run();
        }
    }
}
