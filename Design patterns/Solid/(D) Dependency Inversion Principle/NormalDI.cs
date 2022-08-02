using System;
using System.Collections.Generic;
using System.Text;

namespace _D_Dependency_Inversion_Principle
{
    class NormalDI
    {
        public static void Run()
        {
            NormalBook book = new NormalBook(new NormalConsolePrinter());
            book.Print();
            book.Printer = new NormalHtmlPrinter();
            book.Print();
        }
    }

    interface IPrinter
    {
        void Print(string text);
    }
    class NormalBook 
    {
        public string Text { get; set; }
        public IPrinter Printer { get; set; }
        public NormalBook(IPrinter printer)
        {
            Printer = printer;
        }

        public void Print()
        {
            Printer.Print(Text);
        }
    }

    class NormalConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать на консоли");
        }
    }

    class NormalHtmlPrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать в HTML");
        }
    }

}
