using System;
using System.Collections.Generic;
using System.Linq;

//Соединение в LINQ используется для объединения двух разнотипных наборов в один.
//Для соединения используется оператор join или метод Join().
//Как правило, данная операция применяется к двум наборам, которые имеют один общий критерий.

namespace Соединение_коллекций
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Оператор join

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
            };
            Company[] companies =
            {
                new Company("Microsoft", "C#"),
                new Company("Google", "Go"),
                new Company("Oracle", "Java")
            };

            var employees = from p in people
                            join c in companies on p.Company equals c.Title
                            select new { Name = p.Name, Company = c.Title, Language = c.Language };

            foreach (var emp in employees)
                Console.WriteLine($"Name: {emp.Name} Company: {emp.Company} Language: {emp.Language}");

            tire();
            //___________________________________________________________________________________
            // Метод Join
            var emp2 = people.Join(companies,
                                    p => p.Company,
                                    c => c.Title,
                                    (p, c) => new { Name = p.Name, Company = c.Title, Lang = c.Language });
            foreach (var emp in employees)
                Console.WriteLine($"Name: {emp.Name} Company: {emp.Company} Language: {emp.Language}");
            tire();

            //_______________________________________________________________________
            // GroupJoin
            // Метод GroupJoin() кроме соединения последовательностей также выполняет и группировку.

            var personnel = companies.GroupJoin(people,
                                            c => c.Title,
                                            p => p.Company,
                                            (c, emp) => new
                                            {
                                                Title = c.Title,
                                                Employees = emp
                                            });
            foreach (var company in personnel)
            {
                Console.WriteLine(company.Title);
                foreach (var emp in company.Employees)
                {
                    Console.WriteLine(emp.Name);
                }
                Console.WriteLine();
            }
            tire();
            //_______________________________________________________________________
            //Метод Zip
            //Метод Zip() последовательно объединяет соответствующие элементы текущей
            //последовательности со второй последовательностью, которая передается в метод
            //в качестве параметра. То есть первый элемент из первой последовательности
            //объединяется с первым элементом из второй последовательности, второй элемент
            //из первой последовательности соединяется со вторым элементом из второй
            //последовательности и так далее. Результатом метода является коллекция кортежей,
            //где каждый кортеж хранит пару соответствующих элементов из обоих последовательностей

            var courses = new List<Course>() { new Course("C#"), new Course("Java") };
            var students = new List<Student>() { new Student("Semyon"), new Student("Dimon") };

            var enrollment = courses.Zip(students,
                                        (course, student) => new { Name = student.Name, Course = course.Title });

            foreach (var ent in enrollment)
                Console.WriteLine($"{ent.Name} - {ent.Course}");
        }

        private static void tire() => Console.WriteLine("_______________________");
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

    internal class Company
    {
        public string Title { get; set; }
        public string Language { get; set; }

        public Company(string title, string lang)
        {
            Title = title;
            Language = lang;
        }
    }

    internal class Course
    {
        public string Title { get; set; }

        public Course(string title)
        {
            Title = title;
        }
    }

    internal class Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }
    }
}