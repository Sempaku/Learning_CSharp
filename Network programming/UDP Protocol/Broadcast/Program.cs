using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Широковещательная_рассылка
{
    class Program
    {
        static IPAddress remoteAddress;
        static int remotePort = 8001;
        static int localPort = 8001;
        static string userName;
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter username: ");
                userName = Console.ReadLine();
                remoteAddress = IPAddress.Parse("235.5.5.11");
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
            IPEndPoint endPoint = new IPEndPoint(remoteAddress, remotePort);

            try
            {
                while (true)
                {
                    string message = Console.ReadLine();
                    message = String.Format("{0}: {1}", userName, message);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data,data.Length,endPoint);
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
            receiver.JoinMulticastGroup(remoteAddress, 50);
            IPEndPoint remoteIp = null;
            string localAddress = LocalIPAddress();
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp);
                    if (remoteIp.Address.ToString().Equals(localAddress))
                        continue;
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine(message);
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

        private static string LocalIPAddress()
        {
            string localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

    }
}
