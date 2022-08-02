using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

//В данном случае предполагается, что по локальному адресу 127.0.0.1 на порту 8888 запущен tcp-сервер.

//Мы ожидаем, что сервер будет передавать строку в кодировке UTF8, и для создания строки определяется
//объект StringBuilder.

//Для считывания данных создаем массив байтов: byte[] data = new byte[256].
//Однако поскольку данные могут иметь больший размер, то считываем их из потока в цикле do..while.
//При этом проверяется значение stream.DataAvailable на наличие данных в потоке.
namespace TCP_клиент_Класс_TcpClient
{
    class Program
    {
        private const int port = 8888;
        private const string server = "127.0.0.1";
        static void Main(string[] args)
        {
            //TCP CLient
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);

                byte[] data = new byte[256];
                StringBuilder responce = new StringBuilder();
                NetworkStream stream = client.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    responce.Append(Encoding.UTF8.GetString(data, 0, bytes));
                } while (stream.DataAvailable);

                Console.WriteLine(responce.ToString());

                // close thread
                stream.Close();
                client.Close();

            }
            catch (SocketException ex)
            {

                Console.WriteLine($"SocketException: {ex}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.WriteLine("Запрос завершен");
            Console.Read();
        }
    }
}
