using System;
using System.Collections.Generic;
using System.Linq;

//Существует несколько разновидностей LINQ:

/*
LINQ to Objects: применяется для работы с массивами и коллекциями
LINQ to Entities: используется при обращении к базам данных через технологию Entity Framework
LINQ to XML: применяется при работе с файлами XML
LINQ to DataSet: применяется при работе с объектом DataSet
Parallel LINQ (PLINQ): используется для выполнения параллельных запросов
*/

namespace Основы_LINQ
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // БЕЗ LINQ
            string[] names = { "Tommy", "Jimmy", "Huge", "Tik", "Samyel" };

            List<string> selectedPeople = new List<String>();

            foreach (string perosn in names)
            {
                if (perosn.ToUpper().StartsWith("T"))
                    selectedPeople.Add(perosn);
            }

            selectedPeople.Sort();

            foreach (var person in selectedPeople)
                Console.WriteLine(person);

            //_______________________________________________________________
            void Tire() => Console.WriteLine("_______________________________");
            Tire();
            //Операторы запросов LINQ
            var selectedPeopleForLinqRequest = from p in names //передаем каждый элемен из names в p
                                               where p.ToUpper().StartsWith("T") // фильтрация
                                               orderby p // сортируем по возрастанию
                                               select p; // выбираем объект в коллекцию
            foreach (string name in selectedPeopleForLinqRequest)
                Console.WriteLine(name);

            //________________________________________________________________
            //Методы расширения LINQ
            Tire();
            string[] nonames = { "XAN ZAMAY", "Ricky F", "OxyDimon", "Slava CPCP", "XanaxBoy" };
            var selectedNoNames = nonames.Where(p => p.ToUpper().StartsWith("X")).OrderBy(p => p);
            foreach (var noname in selectedNoNames)
                Console.WriteLine(noname);
        }
    }
}