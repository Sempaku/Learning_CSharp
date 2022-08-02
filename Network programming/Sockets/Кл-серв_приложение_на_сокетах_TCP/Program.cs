using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Кл_серв_приложение_на_сокетах_TCP
{
    class Program
    {
        static int port = 8005; //порт для приема входящих запросов
        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создадим сокет
            Socket listingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listingSocket.Bind(ipPoint);

                // начинаем прослушивание
                listingSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидаем подключений...");

                while (true)
                {
                    Socket handler = listingSocket.Accept();
                    // получаем сообщения

                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // кол-во полученных байтов
                    byte[] data = new byte[256]; // буфер для полученных байтов

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortDateString() + ": " + builder.ToString());

                    //отправляем ответ
                    string message = "ваше сообщение доставлено";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);

                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();


                }
                

            }
            catch(Exception ex)
            {
                Console.WriteLine(  ex.Message);
            }
        }
    }
}
