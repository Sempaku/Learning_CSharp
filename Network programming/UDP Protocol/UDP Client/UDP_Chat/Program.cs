using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPChat
{
    class Program
    {
        static string remoteAddress;
        static int remotePort;
        static int localPort;

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter remote port for listing: ");
                remotePort = int.Parse(Console.ReadLine());
                Console.Write("Enter remote address: ");
                remoteAddress = Console.ReadLine();
                Console.Write("Enter your port for listening: ");
                localPort = int.Parse(Console.ReadLine());

                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                SendMessage();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }

        }
        private static void SendMessage()
        {
            UdpClient sender = new UdpClient();
            try
            {
                while (true)
                {
                    string message = Console.ReadLine();
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, remoteAddress, remotePort);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                sender.Close();
            }
        }

        private static void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(localPort);
            IPEndPoint remoteIp = null;
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine("Собеседник: {0} ", message);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }
    }
}
