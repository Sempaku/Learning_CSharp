using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Асинхронные_методы_async_и_await
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await PrintAsync(); // вызов асинхронного метода
            Console.WriteLine("Некоторые действия в Main"); 

            void Print()
            {
                Thread.Sleep(3000); // иммитация продолжительной работы
                Console.WriteLine("Hello PRINT()");
            }

            async Task PrintAsync() // определение асинхронного метода
            {
                Console.WriteLine("Начало метода PrintAsync"); // Выполняется синхронно
                await Task.Run(() => Print()); // Выполняется асинхронно
                Console.WriteLine("Конец метода PrintAsync");
            }

            //_________________________________________________
            void Tire() => Console.WriteLine("___________________");
            //__________________________________________________
            
            //Задержка асинхронной операции и Task.Delay
            
            Tire();

            await PrintAsync2();

            async Task PrintAsync2()
            {
                await Task.Delay(3000);
                // or await Task.Delay(TimeSpan.FromMilliseconds(3000));
                Console.WriteLine("Hello2 PrintAsynch()");
            }

            //_______________________________________________________________
            // Преимущества асинхронности
            Tire();

            PrintName("Sem"); // 3sec
            PrintName("Tmr"); // 3sec
            PrintName("Maks");// 3sec
            void PrintName(string name) // Sum: 9 sec
            {
                Thread.Sleep(3000);
                Console.WriteLine(name) ;
            }

            // async

            var tomTask = PrintNameAsync("Tom");
            var kaylTask = PrintNameAsync("Kayl");
            var gregTask = PrintNameAsync("Gregory");

            await tomTask; 
            await kaylTask;
            await gregTask;
            async Task PrintNameAsync(string name) // 3sec < TIME < 9sec
            {
                await Task.Delay(3000);
                Console.WriteLine(name);
            }

            //__________________________________________________________
            //Опеределение асинхронного лямбда-выражения
            Tire();
            Func<string, Task> printer = async (message) =>
             {
                 await Task.Delay(1000);
                 Console.WriteLine(message);
             };

            await printer("Hello world");
            await printer("Lambda");
        }
    }
}
