using System;
using System.IO;
using System.Text;

//Класс FileStream представляет возможности по считыванию из файла и записи в файл.
//Он позволяет работать как с текстовыми файлами, так и с бинарными.
namespace FileStream_Чтение_и_запись_файла
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание FileStream и Закрытие потока

            FileStream? fs = null;
            try
            {
                fs = new FileStream("text.txt", FileMode.OpenOrCreate);
                //...................
            }
            catch (Exception ex) { }
            finally
            {
                fs?.Close();
            }

            //or 
            using (FileStream? fsWithUsing = new FileStream("test.txt", FileMode.OpenOrCreate))
            {
                //...................
            }

            //__________________________________________________________________________________

            string path = @"C:\Users\79172\Desktop\note.txt";
            string text = "Hello METAnit(";

            using(FileStream f = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                f.Write(buffer);
                Console.WriteLine("Text is written!");
            }

            using(FileStream f = File.OpenRead(path))
            {
                byte[] buffer = new byte[f.Length];
                f.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine(textFromFile);
            }

            //_____________________________________________________________________________
            //Произвольный доступ к файлам
            //Нередко бинарные файлы представляют определенную структуру.
            //И, зная эту структуру, мы можем взять из файла нужную порцию информации
            //или наоброт записать в определенном месте файла определенный набор байтов.
            //Например, в wav-файлах непосредственно звуковые данные начинаются с 44 байта,
            //а до 44 байта идут различные метаданные - количество каналов аудио,
            //частота дискретизации и т.д.

            //С помощью метода Seek() мы можем управлять положением курсора потока,
            //начиная с которого производится считывание или запись в файл.
            //Этот метод принимает два параметра: offset(смещение) и позиция в файле.

            string nPath = "note.dat";
            string nText = "123 hw 321";

            using (FileStream f = new FileStream(nPath, FileMode.OpenOrCreate))
            {
                byte[] inputs = Encoding.Default.GetBytes(nText);
                f.Write(inputs, 0, inputs.Length);
                Console.WriteLine("Text is written!");
            }

            using (FileStream f = new FileStream(nPath, FileMode.OpenOrCreate))
            {
                f.Seek(-3, SeekOrigin.End);


                byte[] outputs = new byte[3];
                f.Read(outputs, 0, outputs.Length);

                string textFromOitputs = Encoding.Default.GetString(outputs);
                Console.WriteLine(textFromOitputs);
            }
           
                

        }
    }
}
