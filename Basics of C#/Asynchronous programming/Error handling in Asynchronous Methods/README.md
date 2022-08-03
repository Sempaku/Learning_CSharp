# Обработка ошибок в асинхронных методах
Обработка ошибок в асинхронных методах, использующих ключевые слова async и await, имеет свои особенности.

Для обработки ошибок выражение await помещается в блок try

Следует учитывать, что если асинхронный метод имеет тип void, то в этом случае исключение во вне не передается, соответственно мы не сможем обработать исключение при вызове метода

## Исследование исключения
При возникновении ошибки у объекта Task, представляющего асинхронную задачу, в которой произошла ошибка, свойство IsFaulted имеет значение true. Кроме того, свойство Exception объекта Task содержит всю информацию об ошибке. Проинспектируем данное свойство:

```C#
var task = PrintAsync("Hi");
try
{
    await task;
}
catch
{
    Console.WriteLine(task.Exception?.InnerException?.Message); // Invalid string length: 2
    Console.WriteLine($"IsFaulted: {task.IsFaulted}");  // IsFaulted: True
    Console.WriteLine($"Status: {task.Status}");        // Status: Faulted
}
 
async Task PrintAsync(string message)
{
    // если длина строки меньше 3 символов, генерируем исключение
    if (message.Length < 3)
        throw new ArgumentException($"Invalid string length: {message.Length}");
    await Task.Delay(1000);     // имитация продолжительной операции
    Console.WriteLine(message);
}
```  
И если мы передадим в метод строку с длиной меньше 3 символов, то task.IsFaulted будет равно true.  

## Обработка нескольких исключений. WhenAll
Если мы ожидаем выполнения сразу нескольких задач, например, с помощью Task.WhenAll, то мы можем получить сразу несколько исключений одномоментно для каждой выполняемой задачи. В этом случае мы можем получить все исключения из свойства Exception.InnerExceptions:

```C#
// определяем и запускаем задачи
var task1 = PrintAsync("H");
var task2 = PrintAsync("Hi");
var allTasks = Task.WhenAll(task1, task2);
try
{
    await allTasks;
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
    Console.WriteLine($"IsFaulted: {allTasks.IsFaulted}");
    if(allTasks.Exception is not null)
    {
        foreach (var exception in allTasks.Exception.InnerExceptions)
        {
            Console.WriteLine($"InnerException: {exception.Message}");
        }
    }
}
 
async Task PrintAsync(string message)
{
    // если длина строки меньше 3 символов, генерируем исключение
    if (message.Length < 3)
        throw new ArgumentException($"Invalid string: {message}");
    await Task.Delay(1000);     // имитация продолжительной операции
    Console.WriteLine(message);
}
```


