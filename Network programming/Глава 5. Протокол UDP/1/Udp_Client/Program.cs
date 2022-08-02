using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Udp_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //UdpClient

            UdpClient udpClient = new UdpClient();
            udpClient.Connect("www.google.com", 8888);

            //Send()

            UdpClient client = new UdpClient(8001);
            string message = "Hello client";
            byte[] data = Encoding.Unicode.GetBytes(message);

            int numberOfSendBytes = client.Send(data, data.Length);
            client.Close();

            //Для получения данных применяется метод Receive().
            //Этот метод принимает один параметр типа System.Net.IPEndPoint с ref

            UdpClient recClient = new UdpClient(8001);
            IPEndPoint ip = null;
            byte[] dataReceive = recClient.Receive(ref ip);
            string recMsg = Encoding.Unicode.GetString(dataReceive);
            recClient.Close();



        
        }
    }
}
