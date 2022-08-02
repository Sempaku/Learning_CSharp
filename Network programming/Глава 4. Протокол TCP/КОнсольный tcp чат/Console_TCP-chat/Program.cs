using System;
using System.Threading;

namespace ChatServer
{
    class Program
    {
        static ServerObject server;
        static Thread listenThread; // thread for listening 
        static void Main(string[] args)
        {
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start();
            }
            catch (Exception ex )
            {

                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
