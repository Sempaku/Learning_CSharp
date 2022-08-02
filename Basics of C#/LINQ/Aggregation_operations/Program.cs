using System;
using System.Linq;

// К агрегатным операциям относят различные операции над выборкой, например, получение числа
// элементов, получение минимального, максимального и среднего значения в выборке, а также
// суммирование значений.
namespace Агрегатные_операции
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Метод Aggregate
            int[] numbers = { 1, 2, 3, 4, 5 };
            int query = numbers.Aggregate((x, y) => x - y);
            Console.WriteLine(query);
            tire();
            // цепь агрегатных операций
            string[] words = { "Hell", "Heaven", "Sabbath", "CNN" };
            var sentence = words.Aggregate("Text:", (first, next) => $"{first} {next}");
            Console.WriteLine(sentence);

            tire();
            //___________________________________________________________________________
            // Получение размера выборки. Метод Count
            int[] numbers2 = { 1, 2, 5, 5, 23, 74, 88, 12, 43, 444 };
            int sizeNumbers2 = numbers2.Count();
            Console.WriteLine(sizeNumbers2);

            tire();

            int sizeEven = numbers2.Count(i => i % 2 == 0 && i > 10);
            Console.WriteLine(sizeEven);

            tire();

            //_____________________________________________________________________________
            // Получение суммы
            int sumNumbers = numbers.Sum();
            Console.WriteLine(sumNumbers);

            tire();

            //Метод Sum() имеет ряд перегрузок. В частности, если у нас набор сложных объектов,
            //как в примере выше, то мы можем указать свойство, значения которого будут суммироваться

            Person[] people = { new Person("Jake", 22), new Person("Tim", 100) };
            int ageSum = people.Sum(p => p.Age);
            Console.WriteLine(ageSum);

            tire();

            //_______________________________________________________________________________________
            //Максимальное, минимальное и среднее значения

            int minimum = numbers2.Min();
            int maximum = numbers2.Max();
            double average = numbers2.Average();

            Console.WriteLine($"MIN:{minimum}  MAX:{maximum} AVERAGE:{average}");
        }

        private static void tire() => Console.WriteLine("_____________________");
    }

    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
    }
}