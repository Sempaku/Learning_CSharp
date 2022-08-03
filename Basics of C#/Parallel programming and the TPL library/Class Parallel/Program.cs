using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
            Console.WriteLine("_________________________");
            Parallel.For(1, 5, Square);

            //________________________________________________________________________
            Console.WriteLine("_________________________");
            ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 1, 3, 5, 8 }, Square);

            //________________________________________________________________________________________            

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
