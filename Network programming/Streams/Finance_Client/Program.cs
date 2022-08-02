using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Finance_Client
{
    class Program
    {
        const int PORT = 5006;
        const string ADDRESS = "127.0.0.1";
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                Console.WriteLine("Для регистрации счета введите данные!");
                Console.Write("Ваше имя: ");
                string username = Console.ReadLine();

                Console.Write("Введите сумму вклада: ");
                decimal sum = Decimal.Parse(Console.ReadLine());

                Console.Write("Укажите период вклада(в месяцах): ");
                int period = int.Parse(Console.ReadLine());

                client = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = client.GetStream();

                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(username);
                writer.Write(sum);
                writer.Write(period);
                writer.Flush();

                BinaryReader reader = new BinaryReader(stream);
                string accountId = reader.ReadString();
                Console.WriteLine("Ваш номер счета: {0}", accountId);

                reader.Close();
                writer.Close();

                

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
            Console.Read();
        }
    }
}
