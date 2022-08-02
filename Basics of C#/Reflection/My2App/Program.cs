using System;

namespace My2App
{
    class Program
    {
        static void Main(string[] args)
        {

            var number = 5;
            var result = Square(number);
            Console.WriteLine($"Square {number} = {result}");
        }
        static int Square(int n) => n * n;
    }
}
