using System;
using System.Collections;
using System.Linq;

//Ряд методов в LINQ позволяют получить часть коллекции, в частности,
//такие методы как Skip, Take, SkipWhile, TakeWhile.

namespace Методы_Skip_и_Take
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Skip
            //Метод Skip() пропускает определенное количество элементов
            string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };
            var res1 = people.Skip(2); //bob mike kate
            print(res1);
            tire();

            //Если необходимо пропустить определенное количество элементов с конца коллекции,
            //то применяется метод SkipLast():
            var res2 = people.SkipLast(2);
            print(res2); // tom sam bob
            tire();

            //_________________________________________________________
            //SkipWhile
            //Метод SkipWhile() пропускает цепочку элементов,
            //начиная с первого элемента, пока они удовлетворяют определенному условию

            var res3 = people.SkipWhile(p => p.Length == 3);
            print(res3); //Mike Kate
            tire();

            //_________________________________________________________________
            //Take
            //Метод Take() извлекает определенное число элементов.
            var res4 = people.Take(3); //tom sam bob
            print(res4);

            tire();

            //Метод TakeLast() извлекает определенное количество элементов с конце коллекции:

            var res5 = people.TakeLast(3);
            print(res5); // bob mike kate

            tire();

            //_____________________________________________________________________
            //TakeWhile
            //Метод TakeWhile() выбирает цепочку элементов, начиная с первого элемента,
            //пока они удовлетворяют определенному условию
            var res6 = people.TakeWhile(p => p.Length == 3);
            print(res6); // tom sam bob

            tire();

            //________________________________________________________________________
            //Постраничный вывод

            //Совмещая оба метода - Take и Skip,
            //мы можем выбрать определенное количество элементов начиная с определенного элемента.
            //Например, выберем два элемента, начиная со четвертого
            //(то есть пропустим 3 первых элемента)

            string[] NEWpeople = { "Tom", "Sam", "Mike", "Kate", "Bob", "Alice" };
            var resNewPeople = NEWpeople.Skip(3).Take(2);
            print(resNewPeople); //kate bob
        }

        private static void print(IEnumerable s)
        {
            foreach (var x in s)
                Console.WriteLine(x);
        }

        private static void tire() => Console.WriteLine("_________________");
    }
}