using System;
using System.IO;

namespace Работа_с_каталогами
{
    class Program
    {
        static void Main(string[] args)
        {
            //Класс Directory
            //Статический класс Directory предоставляет ряд методов для управления каталогами

            
            //______________________________________________________________________________
            //Класс DirectoryInfo


            //Получение списка файлов и подкаталогов
            string dirName = "C:\\";

            if(Directory.Exists(dirName))
            {
                Console.WriteLine("Subdirs: ");
                string[] subdirs = Directory.GetDirectories(dirName);
                foreach(var dir in subdirs)                
                    Console.WriteLine(dir);

                Console.WriteLine();
                Console.WriteLine("Files: ");
                string[] files = Directory.GetFiles(dirName);
                foreach (var file in files)                
                    Console.WriteLine(file);
            }

            Console.WriteLine("_____________________");
            //_______________________________________
            //Фильтрация папок и файлов

            //Методы получения папок и файлов позволяют выполнять фильтрацию.
            //В качестве фильтра в эти методы передается шаблон,
            //который может содержать два плейсхолдера:
            //* или символ-звездочка (соответствует любому количеству символов)
            //и ? или вопросительный знак (соответствует одному символу)

            var directory = new DirectoryInfo("C:\\");
            FileInfo[] filesSys = directory.GetFiles("*.sys");

            foreach (var f in filesSys)
            {
                Console.WriteLine(f);
            }

            Console.WriteLine("___________________________________");
            //____________________________________________________________________

            //Создание каталога

            string path = @"C:\SomeDir";
            string subPath = "DELETEPLEASE\\pleaseeee";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if(!(dirInfo.Exists))
            {
                dirInfo.Create();
                Console.WriteLine($"Create directory : {dirInfo}");
            }
            dirInfo.CreateSubdirectory(subPath);
            Console.WriteLine($"Create subdirectory : {dirInfo}\\{subPath}");

            Console.WriteLine("____________________________________________");
            //_____________________________________________________________________
            //Получение информации о каталоге

            string directoryInfo = "C:\\Program Files";
            DirectoryInfo d1 = new DirectoryInfo(directoryInfo);

            Console.WriteLine($"Название каталога: {d1.Name}");
            Console.WriteLine($"Полное название каталога: {d1.FullName}");
            Console.WriteLine($"Время создания каталога: {d1.CreationTime}");
            Console.WriteLine($"Корневой каталог: {d1.Root}");

            Console.WriteLine("____________________________________________");

            //_______________________________________________________________________
            //Удаление каталога

            string pathSomeDir = @"C:\SomeDir";

            DirectoryInfo dirInfoDeleteSomeDir = new DirectoryInfo(pathSomeDir);

            if (dirInfoDeleteSomeDir.Exists)
            {
                dirInfoDeleteSomeDir.Delete(true);
                Console.WriteLine($"Directory: {dirInfoDeleteSomeDir.FullName} deleted");
            }
            else
            {
                Console.WriteLine("Directory is not exists");
            }
        }
    }
}
