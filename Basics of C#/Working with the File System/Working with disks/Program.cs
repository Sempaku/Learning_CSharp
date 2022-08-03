using System;
using System.IO;

namespace Работа_с_дисками
{
    class Program
    {
        static void Main(string[] args)
        {
            //Работа с дисками

            //Получим имена и свойства всех дисков на компьютере:
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Title: {drive.Name}");
                Console.WriteLine($"Type: {drive.DriveType}");

                if (drive.IsReady)
                {
                    Console.WriteLine($"Total space: {drive.TotalSize}");
                    Console.WriteLine($"Free space: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Disk Label: {drive.VolumeLabel}");
                }
            }
            Console.WriteLine();
            


        }
    }
}
