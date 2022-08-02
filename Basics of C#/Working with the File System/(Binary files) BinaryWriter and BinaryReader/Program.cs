using System;
using System.Collections.Generic;
using System.IO;


namespace Бинарные_файлы_BinaryWriter_и_BinaryReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinaryWriter
            string path = @"C:\Users\79172\Desktop\binwrt.dat";

            using (BinaryWriter bw = new BinaryWriter(File.Open(path,FileMode.OpenOrCreate)))
            {
                bw.Write("Sam");
                bw.Write(11);
                Console.WriteLine("File has been written!");
            }

            //or
            string path2 = @"C:\Users\79172\Desktop\people.dat";

            Person[] people = { new Person("Tom", 31), new Person("Dima", 19), new Person("Andrew", 20) };
            using (BinaryWriter bw = new BinaryWriter(File.Open(path2, FileMode.OpenOrCreate)))
            {
                foreach(Person person in people)
                {
                    bw.Write(person.Name);
                    bw.Write(person.Age);
                }
                Console.WriteLine("end...");
            }

            //_______________________________________________
            //BinaryReader

            using(BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                string name = br.ReadString();
                int age = br.ReadInt32();
                Console.WriteLine($"{name} - {age}");
            }

            //or 

            List<Person> persons = new List<Person>();

            using(BinaryReader br = new BinaryReader(File.Open(path2, FileMode.Open)))
            {
                while(br.PeekChar() > -1)
                {
                    string name = br.ReadString();
                    int age = br.ReadInt32();
                    persons.Add(new Person(name, age));
                }
            }

            foreach(var p in persons)
            {
                Console.WriteLine($"{p.Name} {p.Age}");
            }

        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
    }
}
