using System;
using System.Reflection;

//При запуске приложения, написанного на C#, операционная система создает процесс,
//а среда CLR создает внутри этого процесса логический контейнер,
//который называется доменом приложения и внутри которого работает запущенное приложение.

//Для управления домена платформа .NET предоставляет класс AppDomain

namespace Домены_приложений
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CurrentDomain;

            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }
        }
    }
}