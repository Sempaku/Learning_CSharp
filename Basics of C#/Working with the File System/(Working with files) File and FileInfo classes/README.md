# Работа с файлами. Классы File и FileInfo
Подобно паре Directory/DirectoryInfo для работы с файлами предназначена пара классов File и FileInfo. С их помощью мы можем создавать, удалять, перемещать файлы, получать их свойства и многое другое.

## FileInfo
Некоторые полезные методы и свойства класса FileInfo:

- CopyTo(path): копирует файл в новое место по указанному пути path
- Create(): создает файл
- Delete(): удаляет файл
- MoveTo(destFileName): перемещает файл в новое место
- Свойство Directory: получает родительский каталог в виде объекта DirectoryInfo
- Свойство DirectoryName: получает полный путь к родительскому каталогу
- Свойство Exists: указывает, существует ли файл
- Свойство Length: получает размер файла
- Свойство Extension: получает расширение файла
- Свойство Name: получает имя файла
- Свойство FullName: получает полное имя файла

Для создания объекта FileInfo применяется конструктор, который получает в качестве параметра путь к файлу:

```C#
FileInfo fileInf = new FileInfo(@"C:\app\content.txt");
```

## File
Класс File реализует похожую функциональность с помощью статических методов:
- Copy(): копирует файл в новое место
- Create(): создает файл
- Delete(): удаляет файл
- Move: перемещает файл в новое место
- Exists(file): определяет, существует ли файл

## Чтение и запись файлов
В дополнение к вышерассмотренным методам класс File также предоставляет ряд методов для чтения-записи текстовых и бинарных файлов:

- AppendAllLines(String, IEnumerable<String>) / AppendAllLinesAsync(String, IEnumerable<String>, CancellationToken) - добавляют в файл набор строк. Если файл не существует, то он создается

- AppendAllText(String, String) / AppendAllTextAsync(String, String, CancellationToken) - добавляют в файл строку. Если файл не существует, то он создается

- byte[] ReadAllBytes (string path) / Task<byte[]> ReadAllBytesAsync (string path, CancellationToken cancellationToken) - считывают содержимое бинарного файла в массив байтов

- string[] ReadAllLines (string path) / Task<string[]> ReadAllLinesAsync (string path, CancellationToken cancellationToken) - считывают содержимое текстового файла в массив строк

- string ReadAllText (string path) / Task<string> ReadAllTextAsync (string path, CancellationToken cancellationToken) - считывают содержимое текстового файла в строку

- IEnumerable<string> ReadLines (string path) - считывают содержимое текстового файла в коллекцию строк

- void WriteAllBytes (string path, byte[] bytes) / Task WriteAllBytesAsync (string path, byte[] bytes, CancellationToken cancellationToken) - записывают массив байт в бинарный файл. Если файл не существует, он создается. Если существует, то перезаписывается

- void WriteAllLines (string path, string[] contents) / Task WriteAllLinesAsync (string path, IEnumerable<string> contents, CancellationToken cancellationToken) - записывают массив строк в текстовый файл. Если файл не существует, он создается. Если существует, то перезаписывается

- WriteAllText (string path, string? contents) / Task WriteAllTextAsync (string path, string? contents, CancellationToken cancellationToken) - записывают строку в текстовый файл. Если файл не существует, он создается. Если существует, то перезаписывается

Как видно, эти методы покрывают практически все основные сценарии - чтение и запись текстовых и бинарных файлов. Причем в зависимости от задачи можно применять как синхронные методы, так и их асинхронные аналоги.

## Кодировка
В качестве дополнительного параметра методы чтения-записи текстовых файлов позволяют установить кодировку в виде объекта System.Text.Encoding:

```C#
  using System.Text;
 
string path = "/Users/eugene/Documents/app/content.txt";
 
string originalText = "Привет Metanit.com";
// запись строки
await File.WriteAllTextAsync(path, originalText, Encoding.Unicode);
// дозапись в конец файла
await File.AppendAllTextAsync(path, "\nПривет мир", Encoding.Unicode);
 
// чтение файла
string fileText = await File.ReadAllTextAsync(path, Encoding.Unicode);
Console.WriteLine(fileText);
  ```
Для установки кодировки при записи и чтении здесь применяется встроенное значение Encoding.Unicode. Также можно указать название кодировки, единственное следует удостовериться, что текущая операционная система поддерживает выбранную кодировку:

```C#
  using System.Text;
 
string path = @"c:\app\content.txt";
 
string originalText = "Hello Metanit.com";
// запись строки
await File.WriteAllTextAsync(path, originalText, Encoding.GetEncoding("iso-8859-1"));
// дозапись в конец файла
await File.AppendAllTextAsync(path, "\nHello code", Encoding.GetEncoding("iso-8859-1"));
 
// чтение файла
string fileText = await File.ReadAllTextAsync(path, Encoding.GetEncoding("iso-8859-1"));
Console.WriteLine(fileText);
```
