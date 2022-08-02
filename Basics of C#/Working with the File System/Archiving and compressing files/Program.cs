using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Архивация_и_сжатие_файлов
{
    class Program
    {
        async static Task Main(string[] args)
        {
            //GZipStream и DeflateStream
            string sourceFile = @"C:\Users\79172\Desktop\x.png";
            string compressedFile = @"C:\Users\79172\Desktop\x.gz";
            string targetFile = @"C:\Users\79172\Desktop\new_x.png";
                                                                                                        
            await CompressAsync(sourceFile, compressedFile);
            await DecompressAsync(compressedFile, targetFile);

            //__________________________________________________
            //____________________________________________________________________________________________________

            // ZipFile
            // Статический класс ZipFile из простанства имен System.IO.Compression
            // предоставляет дополнительные возможности для создания архивов.
            // Он позволяет создавать архив из каталогов

            string zipSourceFolder = @"C:\Users\79172\Desktop\forzip";
            string zipFile = @"C:\Users\79172\Desktop\zip_forzip.zip";
            string zipTarget = @"C:\Users\79172\Desktop\zip_folder";

            ZipFile.CreateFromDirectory(zipSourceFolder, zipFile);
            Console.WriteLine($"Folder {zipSourceFolder} --> in {zipFile}");
            ZipFile.ExtractToDirectory(zipFile, zipTarget);
            Console.WriteLine($"File {zipFile} extract to {zipTarget}");
        }

        async static Task CompressAsync(string source, string compress)
        {
            //thread for read source file
            using FileStream sourceStream = new FileStream(source, FileMode.OpenOrCreate);
            //thread for write compress file
            using FileStream targetStream = File.Create(compress);

            //thread archive 
            using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            await sourceStream.CopyToAsync(compressionStream); //Copy bytes --> source

            Console.WriteLine($"Compression file {source} finish.");
            Console.WriteLine($"Sourse size: {sourceStream.Length} -> compressed size: {targetStream.Length}");


        }

        async static Task DecompressAsync(string compress, string target)
        {
            //thread for reading on compressed file
            using FileStream sourceSource = new FileStream(compress, FileMode.OpenOrCreate);
            //thread for writing decompressed file
            using FileStream targetSource = File.Create(target);

            //thread decompression
            using GZipStream decompressionStream = new GZipStream(sourceSource, CompressionMode.Decompress);
            await decompressionStream.CopyToAsync(targetSource);
            Console.WriteLine($"Decompressed file: {target}");

        }

        


    }
}
