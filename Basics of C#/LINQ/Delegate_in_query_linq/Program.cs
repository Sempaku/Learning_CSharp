using System;
using System.Linq;

namespace Делегаты_в_запросах_LINQ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] people = { "Bob", "Sam", "Kate", "George", "Kai" };

            var result = people.Where(LengthIs3);

            foreach (var s in result)
                Console.WriteLine(s);

            bool LengthIs3(string name) => name.Length == 3;

            //___

            int[] numbers = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };
            var res2 = numbers.Where(i => i > 0).Select(Square);
            foreach (int i in res2)
                Console.WriteLine(i);

            int Square(int n) => n * n;
        }
    }
}