using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

//Класс Parallel также является частью TPL и предназначен для упрощения параллельного выполнения кода.
//Parallel имеет ряд методов, которые позволяют распараллелить задачу.

namespace Класс_Parallel
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // метод Parallel.Invoke выполняет три метода
            Parallel.Invoke(
            Print,
            () =>
            {
                Console.WriteLine($"Выполняется задача(in Parallel.Invoke) {Task.CurrentId}");
                Thread.Sleep(3000);
            },
            () => Square(5)
            );

            void Print()
            {
                Console.WriteLine($"Выполняется задача (Print){Task.CurrentId}");
                Thread.Sleep(3000);
            }
            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача(Square) {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Результат {n * n}");
            }

            //____________________________________________________________________
            // Parallel.For
            //Метод Parallel.For позволяет выполнять итерации цикла параллельно. Он имеет следующее определение:
            //For(int,int,Action<int>)
            Console.WriteLine("_________________________");
            Parallel.For(1, 5, Square);

            //________________________________________________________________________
            // Parallel.ForEach
            // Метод Parallel.ForEach осуществляет итерацию по коллекции, реализующей интерфейс IEnumerable,
            // подобно циклу foreach, только осуществляет параллельное выполнение перебора.
            // Он имеет следующее определение:
            // ParallelLoopResult ForEach<TSourse>(IEnumerable<TSourse> sourse, Action<TSourse> body)
            Console.WriteLine("_________________________");
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 }, Square);

            //________________________________________________________________________________________
            // Выход из цикла
            // В стандартных циклах for и foreach предусмотрен преждевременный выход из цикла
            // с помощью оператора break. В методах Parallel.ForEach и Parallel.For мы также можем,
            // не дожидаясь окончания цикла, выйти из него:

            Console.WriteLine("______________________________________");
            ParallelLoopResult result2 = Parallel.For(1, 10, SquareWithBreak);
            if (!result2.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {result2.LowestBreakIteration}");

            void SquareWithBreak(int n, ParallelLoopState pls)
            {
                if (n == 5) pls.Break(); // Если передано 5, то выходим из цикла

                Console.WriteLine($"кВАДРАТ ЧИСЛА {n} = {n * n}");
                Thread.Sleep(2000);
            }
        }
    }
}