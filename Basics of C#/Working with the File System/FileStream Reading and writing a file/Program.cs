using System;
using System.IO;
using System.Text;

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
