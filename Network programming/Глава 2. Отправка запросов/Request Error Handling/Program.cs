using System;
using System.Net;
using System.IO;
namespace Обработка_ошибок_при_запросах
{
    class Program
    {
        static void Main(string[] args)
        {
            //Обработка исключения и возможное логгирование ошибок позволит определить природу неполадки,
            //что в дальнейшем поможет найти и исправить ошибку.
            //Например, обратимся к несуществующему ресурсу

            try
            {
                WebRequest request = WebRequest.Create("http://localhost:5374/Home/PostData");
                using (WebResponse responce = request.GetResponse())
                {
                    using(Stream stream = responce.GetResponseStream())
                    {
                        using(StreamReader reader = new StreamReader(stream))
                        {
                            Console.WriteLine(reader.ReadToEnd());
                        }
                    }
                }
            }
            catch(WebException ex)
            {
                WebExceptionStatus status = ex.Status;
                Console.WriteLine("Error : {0}", ex.Message);
                if (status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponce = (HttpWebResponse)ex.Response;
                    Console.WriteLine("Статусный код: {0} - {1}",
                                    (int)httpResponce.StatusCode, httpResponce.StatusCode);
                }
            }


        }
    }
}
