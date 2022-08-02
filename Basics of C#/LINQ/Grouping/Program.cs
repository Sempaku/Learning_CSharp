using System;
using System.Linq;

namespace Группировка
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Для группировки данных по определенным параметрам применяется оператор group by
            //и метод GroupBy().

            //Group by

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam" , "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person ( "Alice", "Microsoft")
            };
            var companies = from person in people
                            group person by person.Company;

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var person in company)
                    Console.WriteLine(person.Name);
                Console.WriteLine();
            }

            tire();
            //_________________________________________________________________________
            //GroupBy

            var comps = people.GroupBy(p => p.Company);

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var person in company)
                    Console.WriteLine(person.Name);
                Console.WriteLine();
            }

            tire();
            //______________________________________________________________________
            //Создание нового объекта при группировке

            var comp2 = from person in people
                        group person by person.Company into g
                        select new { Name = g.Key, Count = g.Count() };

            foreach (var company in comp2)
            {
                Console.WriteLine($"{company.Name}  {company.Count}");
            }
            //Аналогичная операция с помощью метода GroupBy():

            var comp3 = people
                        .GroupBy(p => p.Company)
                        .Select(g => new { Name = g.Key, Count = g.Count() });

            tire();

            //_______________________________________________
            //Вложенные запросы

            var c1 = from person in people
                     group person by person.Company into g
                     select new
                     {
                         Name = g.Key,
                         Count = g.Count(),
                         Employees = from p in g select p
                     };
            //or
            var c2 = people.GroupBy(p => p.Company).Select(g => new
            {
                Name = g.Key,
                Count = g.Count(),
                Employees = g.Select(p => p)
            });

            foreach (var c in c1)
            {
                Console.WriteLine($"{c.Name}  :  {c.Count}");
                foreach (var p in c.Employees)
                    Console.WriteLine(p.Name);
                Console.WriteLine();
            }
        }

        private static void tire() => Console.WriteLine("________________________________________________");
    }

    internal class Person
    {
        public string Name { get; set; }
        public string Company { get; set; }

        public Person(string name, string company)
        {
            Name = name;
            Company = company;
        }
    }
}