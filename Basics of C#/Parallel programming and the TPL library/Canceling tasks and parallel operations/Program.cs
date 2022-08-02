using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

//Параллельное выполнение задач может занимать много времени.
//И иногда может возникнуть необходимость прервать выполняемую задачу.
//Для этого платформа .NET предоставляет структуру CancellationToken из пространства имен System.Threading.

/*Общий алгоритм отмены задачи обычно предусматривает следующий порядок действий:
 1 - Создание объекта CancellationTokenSource, который управляет и посылает уведомление об отмене токену.
 2 - С помощью свойства CancellationTokenSource.Token получаем собственно токен - объект структуры CancellationToken
 и передаем его в задачу, которая может быть отменена.
 3 - Определяем в задаче действия на случай ее отмены.
 4 - Вызываем метод CancellationTokenSource.Cancel(),
 который устанавливает для свойства CancellationToken.IsCancellationRequested значение true.
 Стоит понимать, что сам по себе метод CancellationTokenSource.Cancel() не отменяет задачу,
 он лишь посылает уведомление об отмене через установку свойства CancellationToken.IsCancellationRequested.
 Каким образом будет происходить выход из задачи, это решает сам разработчик.
 5 - Класс CancellationTokenSource реализует интерфейс IDisposable.
 И когда работа с объектом CancellationTokenSource завершена,
 у него следует вызвать метод Dispose для освобождения всех связанных с ним используемых ресурсов.
 (Вместо явного вызова метода Dispose можно использовать конструкцию using).
*/

namespace Отмена_задач_и_параллельных_операций
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Мягкий выход из задачи без исключения OperationCanceledException
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested) // Если получаем сигнал об отмене операции
                    {
                        Console.WriteLine("Операция прервана!");
                        return; // выход из задачи
                    }
                    Console.WriteLine($"Square {i} = {i * i}");
                    Thread.Sleep(200);
                }
            }, token); //token
            task.Start();

            Thread.Sleep(1000);
            cancelTokenSource.Cancel(); // выражение token.IsCancellationRequested возвращает true.
            Thread.Sleep(1000);

            Console.WriteLine($"Status task: {task.Status}");

            cancelTokenSource.Dispose(); // Освобождаем ресурсы
            void Tire() => Console.WriteLine("___________________________");

            //_____________________________________________________________
            //Отмена задачи с помощью генерации исключения
            //Второй способ завершения задачи представляет генерация исключения OperationCanceledException.
            //Для этого применяется метод ThrowIfCancellationRequested() объекта CancellationToken:
            Tire();
            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();
            CancellationToken token2 = cancellationTokenSource2.Token;

            Task task2 = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token2.IsCancellationRequested)
                        token2.ThrowIfCancellationRequested();
                    Console.WriteLine($"Square {i} = {i * i}");
                    Thread.Sleep(400);
                }
            }, token2);

            try
            {
                task2.Start();
                Thread.Sleep(500);
                cancellationTokenSource2.Cancel();
                task2.Wait();
            }
            catch (AggregateException ae)
            {
                for (int i = 0; i < ae.InnerExceptions.Count; i++)
                {
                    var e = ae.InnerExceptions[i];
                    if (e is TaskCanceledException)
                        Console.WriteLine("Operation canceled!");
                    else
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            finally
            {
                cancellationTokenSource2.Dispose();
            }

            Console.WriteLine(task2.Status);

            //_____________________________________________________________
            //Регистрация обработчика отмены задачи
            Tire();
            //Метод Register() позволяет зарегистрировать обработчик отмены задачи в виде делегата Action
            CancellationTokenSource cancelTokenSource3 = new CancellationTokenSource();
            CancellationToken token3 = cancelTokenSource3.Token;

            Task task3 = new Task(() =>
            {
                int i = 1;
                token3.Register(() =>
                {
                    Console.WriteLine("Операци прервана(token register)");
                    i = 10;
                });
                for (; i < 10; i++)
                {
                    Console.WriteLine($"Квадрат числа {i} = {i * i}");
                    Thread.Sleep(400);
                }
            }, token3);

            task3.Start();
            Thread.Sleep(1000);
            cancelTokenSource3.Cancel();
            Thread.Sleep(1000);
            Console.WriteLine(task3.Status);
            cancelTokenSource3.Dispose();

            //_______________________________________________________________________
            // Передача токена во внешний метод
            Tire();
            CancellationTokenSource cancelTokenSource4 = new CancellationTokenSource();
            CancellationToken token4 = cancelTokenSource4.Token;

            Task task4 = new Task(() => PrintSquare(token4), token4);

            try
            {
                task4.Start();
                Thread.Sleep(1000);
                cancelTokenSource4.Cancel();

                task4.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Operation cancelled");
                    else
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cancelTokenSource4.Dispose();
                Console.WriteLine(task4.Status);
            }

            void PrintSquare(CancellationToken token)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();

                    Console.WriteLine("Sq4r3 {0} = {1}", i, i * i);
                    Thread.Sleep(200);
                }
            }

            //_____________________________________________________
            //Отмена параллельных операций Parallel
            Tire();
            //Для отмены выполнения параллельных операций, запущенных с помощью методов
            //Parallel.For() и Parallel.ForEach(), можно использовать перегруженные версии данных методов,
            //которые принимают в качестве параметра объект ParallelOptions

            CancellationTokenSource cancelTokenSource5 = new CancellationTokenSource();
            CancellationToken token5 = cancelTokenSource5.Token;

            new Task(() =>
           {
               Thread.Sleep(400);
               cancelTokenSource5.Cancel();
           }).Start();

            try
            {
                Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5 },
                    new ParallelOptions { CancellationToken = token5 },
                    Sq);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Op canc");
            }
            finally
            {
                cancelTokenSource5.Dispose();
            }

            void Sq(int n)
            {
                Thread.Sleep(3000);
                Console.WriteLine("Sq {0} === {1}", n, n * n);
            }
        }
    }
}