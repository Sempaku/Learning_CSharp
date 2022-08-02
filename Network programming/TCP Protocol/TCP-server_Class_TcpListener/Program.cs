using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace TCP_сервер_Класс_TcpListener
{
    class Program
    {
        const int port = 8888;
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                server.Start();

                while (true)
                {
                    Console.WriteLine("Ожидание подключений...");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Подключен клиент. Выполнение запроса...");

                    // получаем сетевой поток для чтения и записи
                    NetworkStream stream = client.GetStream();

                    string responce = "Hello, I'm a server";
                    byte[] data = Encoding.UTF8.GetBytes(responce);

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"Отправлено сообщение: {responce}");

                    stream.Close();
                    client.Close();
                    

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            finally
            {
                if (server != null)
                {
                    server.Stop();
                }
            }
        }
    }
}
