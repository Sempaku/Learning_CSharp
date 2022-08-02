using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace Асинхронные_стримы
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await foreach (var num in GetNumberAsync())
            {
                Console.WriteLine(num);
            }

            async IAsyncEnumerable<int> GetNumberAsync()
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(100);
                    yield return i;
                }
            }
        }
        void Tire() => Console.WriteLine("______________________");

        //______________________________________________________________
        //Где можно применять асинхронные стримы?
        //Асинхронные стримы могут применяться для получения данных из какого-нибудь внешнего хранилища

        /*readonly Repository repo = new Repository();
        IAsyncEnumerable<string> data = repo.GetDataAsync();
        await foreach (var name in data)
        {
            Console.WriteLine(name);
        }*/

        class Repository
        {
            string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
            public async IAsyncEnumerable<string> GetDataAsync()
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine($"Получаем {i + 1} элемент");
                    await Task.Delay(500);
                    yield return data[i];
                }
            }
        }

    }
}
