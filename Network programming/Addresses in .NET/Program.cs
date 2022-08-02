using System;
using System.Net;

namespace Адреса_в_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPHostEntry host1 = Dns.GetHostEntry("www.microsoft.com");
            Console.WriteLine(host1.HostName);

            foreach (IPAddress iPAddress in host1.AddressList)
            {
                Console.WriteLine(iPAddress.ToString());
            }
            Console.WriteLine(  );

            IPHostEntry host2 = Dns.GetHostEntry("google.com");
            Console.WriteLine(host2.HostName);
            foreach (IPAddress ipHost2 in host2.AddressList)
            {
                Console.WriteLine(ipHost2.ToString());
            }



        }
    }
}
