using System;
using System.Threading.Tasks;

//Следует учитывать, что если асинхронный метод имеет тип void,
//то в этом случае исключение во вне не передается, соответственно
//мы не сможем обработать исключение при вызове метода

namespace Обработка_ошибок_в_асинхронных_методах
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //Для обработки ошибок выражение await помещается в блок try:
            try
            {
                await PrintAsync("Hello world");
                await PrintAsync("ma");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            async Task PrintAsync(string message)
            {
                if (message.Length < 3)
                    throw new ArgumentException($"Invalid string length: {message}");

                await Task.Delay(100);
                Console.WriteLine(message);
            }

            //________________________________________________________________________________
            void Tire() => Console.WriteLine("________________________________");
            Tire();
            //Исследование исключения:
            //При возникновении ошибки у объекта Task, представляющего асинхронную задачу,
            //в которой произошла ошибка, свойство IsFaulted имеет значение true. Кроме того,
            //свойство Exception объекта Task содержит всю информацию об ошибке

            var task = PrintAsync("j");
            try
            {
                await task;
            }
            catch
            {
                Console.WriteLine(task?.Exception.InnerException?.Message);
                Console.WriteLine($"IsFaulted: {task.IsFaulted}");
                Console.WriteLine($"Status: {task.Status}");
            }

            //_____________________________________________________________
            //Если мы ожидаем выполнения сразу нескольких задач, например, с помощью Task.WhenAll,
            //Обработка нескольких исключений. WhenAll
            //то мы можем получить сразу несколько исключений одномоментно для каждой выполняемой задачи.
            //В этом случае мы можем получить все исключения из свойства Exception.InnerExceptions
            Tire();
            var task1 = PrintAsync("H");
            var task2 = PrintAsync("hi");
            var allTasks = Task.WhenAll(task1, task2);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"IsFauted: {allTasks.IsFaulted}");
                if (!(allTasks.Exception is null))
                {
                    foreach (var exception in allTasks.Exception.InnerExceptions)
                    {
                        Console.WriteLine($"InnerException: {exception.Message}");
                    }
                }
            }
        }
    }
}