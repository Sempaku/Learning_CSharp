using System;
using System.IO;

//Для работы непосредственно с текстовыми файлами в пространстве System.IO
//определены специальные классы: StreamReader и StreamWriter.

namespace Ч_и_за_текс_файлов_StreamReader_и_StreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Запись в файл и StreamWriter

            string path1 = @"C:\Users\79172\Desktop\StrWrit.txt";

            string text1 = "We can write text in text files \nThis is nevermind!!!";
            using( StreamWriter sw = new StreamWriter(path1, false))
            {
                sw.Write(text1);
            }
            using( StreamWriter sw = new StreamWriter(path1, true))
            {
                sw.Write("\nEnd append text)))");
            }

            //Чтение из файла и StreamReader

            using(StreamReader sr = new StreamReader(path1))
            {
                string fullText = sr.ReadToEnd();
                Console.WriteLine(fullText);
            }

            using (StreamReader sr = new StreamReader(path1))
            {
                string? line;
                while( (line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

        }
    }
}
