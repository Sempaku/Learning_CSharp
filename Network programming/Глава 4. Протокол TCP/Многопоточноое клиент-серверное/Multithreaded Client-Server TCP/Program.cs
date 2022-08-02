using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Многопоточное_клиент_серверное_TCP
{
    class Program
    {
        const int port = 8888;
        const string address = "127.0.0.1";

        static void Main(string[] args)
        {
            Console.Write("Enter name: ");
            string userName = Console.ReadLine();
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.WriteLine(userName + ": ");
                    //input message
                    string message = Console.ReadLine();
                    message = String.Format("{0}: {1}", userName, message);

                    byte[] data = Encoding.Unicode.GetBytes(message);

                    //send message
                    stream.Write(data,0,data.Length);

                    //get responce
                    data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (stream.DataAvailable);

                    message = builder.ToString();
                    Console.WriteLine("Server: {0}", message);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                if(client != null)
                    client.Close();
            }
        }
    }
}
