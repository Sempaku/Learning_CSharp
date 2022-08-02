using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
// В качестве возвращаемого типа в асинхронном методе должны использоваться типы
// void, Task, Task<T> или ValueTask<T>


namespace Возвращение_результата_из_асинхронного_метода
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //VOID
            PrintAsync("HW"); //мы не можем применить к подобным методам оператор await
            PrintAsync("HW people!");

            Console.WriteLine("Main End");
            await Task.Delay(3000);


            async void PrintAsync(string msg) //асинхронных void-методов следует избегать
            {
                await Task.Delay(3000);
                Console.WriteLine(msg);
            }

            //Варианты где без void методов не обойтись
            void Tire() => Console.WriteLine("_________________");
            Tire();
            Account account = new Account();
            account.Added += PrintAsyncAccountBalance;

            account.Put(500);

            await Task.Delay(5000);

            async void PrintAsyncAccountBalance(object? obj, string msg)
            {
                await Task.Delay(2000);
                Console.WriteLine(msg);
            }

            //____________________________________________________________
            //TASK
            Tire();

            var task = PrintAsyncTask("Java (((");
            Console.WriteLine("Main works");

            await task;

            async Task PrintAsyncTask(string message)
            {
                await Task.Delay(0);
                Console.WriteLine(message);
            }

            //____________________________________________________________
            //TASK<T>
            Tire();

            int n1 = await SquareAsync(5);
            int n2 = await SquareAsync(6);
            Console.WriteLine($"n1 = {n1}, n2 = {n2}");

            async Task<int> SquareAsync(int n)
            {
                await Task.Delay(0);
                return n * n;
            }
            //OR
            Person person = await GetPersonAsync("Lexa");
            Console.WriteLine(person.Name);

            async Task<Person> GetPersonAsync(string name)
            {
                await Task.Delay(100);
                return new Person(name);
            }

            //____________________________________________________
            //ValueTask<T>
            Tire();

            var result = await AddAsync(5, 5);
            Console.WriteLine(result);

            Task<int> AddAsync(int a, int b)
            {
                return Task.FromResult(a + b);
            }
            //использование типа Task приведет к выделению дополнительной задачи с
            //сопутствующими выделениями памяти в хипе.
            //ValueTask решает эту задачу

            var result2 = await AddSync2(5, 10);
            ValueTask<int> AddSync2(int a,int b)
            {
                return new ValueTask<int>(a + b);
            }

            //OR
            var getMessage = GetMessageAsync();
            string message = await getMessage.AsTask();
            Console.WriteLine(message);

            async ValueTask<string> GetMessageAsync()
            {
                await Task.Delay(0);
                return "hello";
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
    }
    class Account
    {
        int sum = 0;
        public event EventHandler<string>? Added;
        public void Put(int sum)
        {
            this.sum += sum;
            Added?.Invoke(this, $"На счет поступило {sum}$");
        }
    }
}
