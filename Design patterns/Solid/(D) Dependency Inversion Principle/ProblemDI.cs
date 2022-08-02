using System;
using System.Collections.Generic;
using System.Text;

namespace _D_Dependency_Inversion_Principle
{
    class ProblemDI
    {
    }

    class Book
    {
        public string Text { get; set; }
        public ConsolePrinter Printer { get; set; }
        public void Print()
        {
            Printer.Print(Text);
        }
    }

    class ConsolePrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
