using System;
using System.Linq;

//Есть два способа выполнения запроса LINQ: отложенное (deferred) и немедленное (immediate) выполнение.
namespace Отложенное_и_немедленное_выполнение_LINQ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //deffered
            string[] people = { "Tom", "Sam", "Bob" }; // tom sam bob
            var selectedPeople = people.Where(s => s.Length == 3).OrderBy(p => p); // tom sam gay

            people[2] = "Gay";
            //выполнение linq запроса
            foreach (var s in selectedPeople)
                Console.WriteLine(s);

            Console.WriteLine("____________");

            //immediate
            string[] people2 = { "Tom", "Sam", "Bob" };

            var count = people2.Where(s => s.Length == 3).OrderBy(p => p).Count();

            Console.WriteLine(count); //3
            people2[2] = "Mike";
            Console.WriteLine(count); // Также 3
        }
    }
}