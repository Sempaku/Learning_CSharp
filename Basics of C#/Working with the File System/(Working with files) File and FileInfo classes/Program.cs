using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Работа_с_файлам_Классы_File_и_FileInfo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //FileInfo and File

            //Пути к файлам
            //Для работы с файлами можно применять как абсолютные, так и относительные пути

            // абсолютные пути
            string path1 = @"C:\Users\eugene\Documents\content.txt";  // для Windows
            string path2 = "C:\\Users\\eugene\\Documents\\content.txt";  // для Windows
            string path3 = "/Users/eugene/Documents/content.txt";  // для MacOS/Linux

            // относительные пути
            string path4 = "MyDir\\content.txt";  // для Windows
            string path5 = "MyDir/content.txt";  // для MacOS/Linux

            //___________________________________________________________________________________
            //Получение информации о файле

            string path = @"C:\Users\79172\Desktop\mol.png";

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
            }

            Console.WriteLine("_________________________________");

            //______________________________________________________
            //Копирование файла

            string newPathForFile = @"C:\Users\79172\Desktop\mol2.png";
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo(newPathForFile);
                Console.WriteLine($"File : {fileInfo.FullName} created in {newPathForFile}");
            }

            Console.WriteLine("___________________________________");


            //______________________________________________________
            //Удаление файла

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                Console.WriteLine($"File : {fileInfo.FullName} deleted");
            }

            Console.WriteLine("__________________________________");

            //__________________________________________________________
            //Чтение и запись файлов
            //В дополнение к вышерассмотренным методам класс File также предоставляет
            //ряд методов для чтения - записи текстовых и бинарных файлов:

            //Например, запишем и считаем обратно в строку текстовый файл:

            string pathForCreate = @"C:\Users\79172\test.txt";
            string originalText = "Hello bro)";

            File.WriteAllText(pathForCreate, originalText);

            File.AppendAllText(pathForCreate, "\nAppend bro(((");

            string fileReader = File.ReadAllText(pathForCreate);
            Console.WriteLine(fileReader);

            Console.WriteLine("____________________________________________");

            //_______________________________________________________________
            //Кодировка

            //В качестве дополнительного параметра методы чтения-записи текстовых файлов
            //позволяют установить кодировку в виде объекта System.Text.Encoding:

            string pathToCoder = @"C:\Users\79172\test3.txt";

            string textToCoder = "Hello Coder";

            File.WriteAllText(pathToCoder, textToCoder, Encoding.Unicode);
            File.AppendAllText(pathToCoder, "\nSOrry for WAHTT???", Encoding.Unicode);

            string ReaderCoder = File.ReadAllText(pathToCoder, Encoding.Unicode);
            Console.WriteLine(ReaderCoder);




        }
    }
}
