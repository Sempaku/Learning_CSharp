using System;
using System.Threading.Tasks;

namespace Последовательное_и_параллельное_выполнение
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var task1 = PrintAsync("Hello world");
            var task2 = PrintAsync("MEtallica");
            var task3 = PrintAsync("Sabbath");

            await task1;
            await task2;
            await task3;

            async Task PrintAsync(string message)
            {
                await Task.Delay(2000);
                Console.WriteLine(message);
            }
            
            void Tire() => Console.WriteLine("__________________");
            Tire();
            //Однако .NET позволяет упростить отслеживание выполнения набора задач с помощью метода Task.WhenAll.
            //Этот метод принимает набор асинхронных задач и ожидает завершения всех этих задач

            var task4 = PrintAsync("Hello world");
            var task5 = PrintAsync("MEtallica");
            var task6 = PrintAsync("Sabbath");

            await Task.WhenAll(task4, task5, task6);

            //Если нам надо дождаться, когда будет выполнена хотя бы одна задача из некоторого набора задач,
            //то можно применять метод Task.WhenAny().
            //Это аналог метода Task.WaitAny() - он завершает выполнение,
            //когда завершается хотя бы одна задача. Но для ожидания выполнения к Task.WhenAny()
            //применяется оператор await:
            Tire();
            var task7 = PrintAsync2("Hello world");
            var task8 = PrintAsync2("MEtallica");
            var task9 = PrintAsync2("Sabbath");

            await Task.WhenAny(task7, task8, task9);

            async Task PrintAsync2(string message)
            {
                await Task.Delay(new Random().Next(1000, 5000));
                Console.WriteLine(message);
            }

            //______________________________________________________
            //Получение результата
            Tire();

            var t1 = SquareAsync(5);
            var t2 = SquareAsync(10);
            var t3 = SquareAsync(100);

            Console.WriteLine(t1.Result);
            int[] results = await Task.WhenAll(t1, t2, t3);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            async Task<int> SquareAsync(int n)
            {
                await Task.Delay(1000);
                return n * n;
            }
        }
    }
}
