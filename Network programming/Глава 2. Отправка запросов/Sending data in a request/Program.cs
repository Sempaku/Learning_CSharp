using System.IO;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Отправка_данных_в_запросе
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //передадим ресурсу данные
            WebRequest request = WebRequest.Create(@"https://vk.com/");
            request.Method = "POST";
            string dataForSending = "sName=Hello world";
            byte[] byteDataArray = System.Text.Encoding.UTF8.GetBytes(dataForSending);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataArray.Length;

            using(Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteDataArray, 0, byteDataArray.Length);
            }

            WebResponse responce = await request.GetResponseAsync();
            using (Stream stream = responce.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            responce.Close();
            Console.WriteLine("Запрос выполнен");
        }
    }
}