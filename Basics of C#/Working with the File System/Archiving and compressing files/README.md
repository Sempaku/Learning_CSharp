# Архивация и сжатие файлов
Кроме классов чтения-записи .NET предоставляет классы, которые позволяют сжимать файлы, а также затем восстанавливать их в исходное состояние.

Это классы ZipFile, DeflateStream и GZipStream, которые находятся в пространстве имен System.IO.Compression и представляют реализацию одного из алгоритмов сжатия Deflate или GZip.

## GZipStream и DeflateStream
Для создания объекта GZipStream можно использовать один из его конструкторов:
- GZipStream(Stream stream, CompressionLevel level): stream представляет данные, а level задает уровень сжатия
- GZipStream(Stream stream, CompressionMode mode): mode указывает, будут ли данные сжиматься или, наоборот, восстанавливаться и может принимать два значения:
    +  CompressionMode.Compress: данные сжимаются
    +  CompressionMode.Decompress: данные восстанавливаются
- GZipStream(Stream stream, CompressionLevel level, bool leaveMode): параметр leaveMode указывает, надо ли оставить открытым поток stream после удаления объекта GZipStream. Если значение true, то поток остается открытым
- GZipStream(Stream stream, CompressionMode mode, bool leaveMode)
Для управления сжатием/восстанавлением данных GZipStream предоставляет ряд методов. Основые из них:

- void CopyTo(Stream destination): копирует все данные в поток destination
- Task CopyToAsync(Stream destination): асинхронная версия метода CopyTo
- void Flush(): очищает буфер, записывая все его данные в файл
- Task FlushAsync(): асинхронная версия метода Flush
- int Read(byte[] array, int offset, int count): считывает данные из файла в массив байтов и возвращает количество успешно считанных байтов. Принимает три параметра:
    + array - массив байтов, куда будут помещены считываемые из файла данные
    + offset представляет смещение в байтах в массиве array, в который считанные байты будут помещены
    + count - максимальное число байтов, предназначенных для чтения. Если в файле находится меньшее количество байтов, то все они будут считаны.
- int Read(byte[] array, int offset, int count): считывает данные из файла в массив байтов и возвращает количество успешно считанных байтов. Принимает три параметра:   
  + array - массив байтов, куда будут помещены считываемые из файла данные
  + offset представляет смещение в байтах в массиве array, в который считанные байты будут помещены
  + count - максимальное число байтов, предназначенных для чтения. Если в файле находится меньшее количество байтов, то все они будут считаны.
  + Task<int> ReadAsync(byte[] array, int offset, int count): асинхронная версия метода Read
- long Seek(long offset, SeekOrigin origin): устанавливает позицию в потоке со смещением на количество байт, указанных в параметре offset.
- void Write(byte[] array, int offset, int count): записывает в файл данные из массива байтов. Принимает три параметра:
    + array - массив байтов, откуда данные будут записываться в файл
    + offset - смещение в байтах в массиве array, откуда начинается запись байтов в поток
    + count - максимальное число байтов, предназначенных для записи
- Task WriteAsync(byte[] array, int offset, int count): асинхронная версия метода Write

## ZipFile
Статический класс ZipFile из простанства имен System.IO.Compression предоставляет дополнительные возможности для создания архивов. Он позволяет создавать архив из каталогов. Его основные методы:
- void CreateFromDirectory(string sourceDirectoryName, string destinationFileName): архивирует папку по пути sourceDirectoryName в файл с названием destinationFileName
- void ExtractToDirectory(string sourceFileName, string destinationDirectoryName): извлекает все файлы из zip-файла sourceFileName в каталог destinationDirectoryName




