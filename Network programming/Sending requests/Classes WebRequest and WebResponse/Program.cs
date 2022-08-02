using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Классы_WebRequest_и_WebResponse
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WebRequest request = WebRequest.Create(@"https://mobimg.b-cdn.net/v3/fetch/fc/fc97db329bd4482025eaa1e3961dc80e.jpeg?w=1470&r=0.5625");
            WebResponse responce = request.GetResponse();

            using(Stream stream = responce.GetResponseStream())
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while( (line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            responce.Close();
            Console.WriteLine("Запрос выполнен");
            Console.Read();

            await RequestAsync();
        }
        private static async Task RequestAsync()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://sigame.xyz/api/pack/8300/download");
            HttpWebResponse responce = (HttpWebResponse)await request.GetResponseAsync();
            
            using (Stream stream = responce.GetResponseStream())
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            responce.Close();
        }
    }
}
