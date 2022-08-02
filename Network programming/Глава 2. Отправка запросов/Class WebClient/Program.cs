using System;
using System.Net;

namespace Класс_WebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();

            client.DownloadFile(@"https://mobimg.b-cdn.net/v3/fetch/fc/fc97db329bd4482025eaa1e3961dc80e.jpeg?w=1470&r=0.5625",
                                @"C:\Users\79172\Desktop\metanit\Сетевое программирование\Основы работы с сетями C# и .NET\Отправка запросов\Класс_WebClient\cat.jpg");
            Console.WriteLine("File download");
        }
    }
}
