using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Server
{
    class Program
    {
        const int PORT = 5006;
        static TcpListener listener;

        static void Main(string[] args)
        {

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
                listener.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);

                    Task clientTask = new Task(clientObject.Process);
                    clientTask.Start();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}
