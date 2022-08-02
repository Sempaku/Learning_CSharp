using System;
using System.Diagnostics;

namespace Процессы
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var process = Process.GetCurrentProcess();
            Console.WriteLine(process.Id);
            Console.WriteLine(process.ProcessName);
            Console.WriteLine(process.VirtualMemorySize64);

            //____________________________________________
            Console.WriteLine("_______________");

            foreach (Process proc in Process.GetProcesses())
            {
                Console.WriteLine($"ID: {proc.Id} // Name: {proc.ProcessName}");
            }

            Console.WriteLine("___________");
            //_______________________________________________________
            //Получим id процессов, который представляют запущенные экземпляры Visual Studio:
            Process[] vsProc = Process.GetProcessesByName("devenv");
            foreach (var i in vsProc)
            {
                Console.WriteLine($"ID: {i.Id}");
            }

            Console.WriteLine("_____________________");
            //___________________________________________________
            //Потоки процесса

            Process procVS = Process.GetProcessesByName("devenv")[0];
            ProcessThreadCollection procThreadVScollection = procVS.Threads;

            foreach (ProcessThread processThread in procThreadVScollection)
            {
                Console.WriteLine($"Thread ID:{processThread.Id}");
            }

            Console.WriteLine("___________________________________");
            //______________________________________________________
            //Модули процесса

            ProcessModuleCollection procModuleVScollection = procVS.Modules;

            foreach (ProcessModule processModule in procModuleVScollection)
            {
                Console.WriteLine($"Name: {processModule.ModuleName} Filename: {processModule.FileName}");
            }

            Console.WriteLine("____________________________________");
            //_________________________________________________________
            //Запуск нового процесса

            Process.Start(@"C:\Users\79172\Desktop\x.png");
        }
    }
}