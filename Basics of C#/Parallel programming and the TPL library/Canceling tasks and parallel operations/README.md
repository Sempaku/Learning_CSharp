# Отмена задач и параллельных операций. CancellationToken

Параллельное выполнение задач может занимать много времени.
И иногда может возникнуть необходимость прервать выполняемую задачу.
Для этого платформа .NET предоставляет структуру **CancellationToken** из пространства имен **System.Threading**.

+ Общий алгоритм отмены задачи обычно предусматривает следующий порядок действий:  
 1. Создание объекта **CancellationTokenSource**, который управляет и посылает уведомление об отмене ***токену***.  
 2. С помощью свойства **CancellationTokenSource.Token** получаем собственно ***токен*** - объект структуры **CancellationToken** и передаем его в задачу, которая может быть отменена.    
 ```C#
 CancellationTokenSource cancelTokenSource = new CancellationTokenSource(); 
 CancellationToken token = cancelTokenSource.Token;
 ```
 Для передачи токена в задачу можно применять один из конструкторов класса Task:
```C#
CancellationTokenSource cancelTokenSource = new CancellationTokenSource(); 
CancellationToken token = cancelTokenSource.Token;
Task task = new Task(() => { выполняемые_действия}, token); 
```  
 3. Определяем в задаче действия на случай ее отмены.  
 4. Вызываем метод **CancellationTokenSource.Cancel()**, который устанавливает для свойства **CancellationToken.IsCancellationRequested** значение ***true***. Стоит понимать, что сам по себе метод **CancellationTokenSource.Cancel()** не отменяет задачу, он лишь посылает уведомление об отмене через установку свойства **CancellationToken**.IsCancellationRequested. Каким образом будет происходить выход из задачи, это решает сам разработчик.  
 5. Класс **CancellationTokenSource** реализует интерфейс *IDisposable*. И когда работа с объектом **CancellationTokenSource** завершена, у него следует вызвать метод *Dispose* для освобождения всех связанных с ним используемых ресурсов (Вместо явного вызова метода *Dispose* можно использовать конструкцию *using*).  

## Мягкий выход из задачи без исключения OperationCanceledException
```C#
CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;
 
// задача вычисляет квадраты чисел
Task task = new Task(() =>
{
    for (int i = 1; i < 10; i++)
    {
        if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
        {
            Console.WriteLine("Операция прервана");
            return;     //  выходим из метода и тем самым завершаем задачу
        }
        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
        Thread.Sleep(200);
    }
}, token);
task.Start();
 
Thread.Sleep(1000);
// после задержки по времени отменяем выполнение задачи
cancelTokenSource.Cancel();
// ожидаем завершения задачи
Thread.Sleep(1000);
//  проверяем статус задачи
Console.WriteLine($"Task Status: {task.Status}");
cancelTokenSource.Dispose(); // освобождаем ресурсы
```  

## Отмена задачи с помощью генерации исключения
Второй способ завершения задачи представляет генерация исключения OperationCanceledException.  
Для этого применяется метод ThrowIfCancellationRequested() объекта CancellationToken:


```C#
CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;
 
Task task = new Task(() =>
{
    for (int i = 1; i < 10; i++)
    {
        if (token.IsCancellationRequested)
            token.ThrowIfCancellationRequested(); // генерируем исключение
 
        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
        Thread.Sleep(200);
    }
}, token);
try
{
    task.Start();
    Thread.Sleep(1000);
    // после задержки по времени отменяем выполнение задачи
    cancelTokenSource.Cancel();
 
    task.Wait(); // ожидаем завершения задачи
}
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        if (e is TaskCanceledException)
            Console.WriteLine("Операция прервана");
        else
            Console.WriteLine(e.Message);
    }
}
finally
{
    cancelTokenSource.Dispose();
}
 
//  проверяем статус задачи
Console.WriteLine($"Task Status: {task.Status}");
```

## Регистрация обработчика отмены задачи
Выше для проверки сигнала отмены применялось свойство IsCancellationRequested. Но есть и другой способ узнать о том, что был послан сигнал отмены задачи.  
Метод Register() позволяет зарегистрировать обработчик отмены задачи в виде делегата Action:  
```C#
CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;
 
// задача вычисляет квадраты чисел
Task task = new Task(() =>
{
    int i = 1;
    token.Register(() => 
    { 
        Console.WriteLine("Операция прервана"); 
        i = 10; 
    });
    for (; i < 10; i++)
    {
        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
        Thread.Sleep(400);
    }
}, token);
task.Start();
 
Thread.Sleep(1000);
// после задержки по времени отменяем выполнение задачи
cancelTokenSource.Cancel();
// ожидаем завершения задачи
Thread.Sleep(1000);
//  проверяем статус задачи
Console.WriteLine($"Task Status: {task.Status}");
cancelTokenSource.Dispose(); // освобождаем ресурсы
```

## Передача токена во внешний метод
Если операция, которая выполняется в задаче, представляет внешний метод, то ему можно передавать в качестве одного из параметров:  

```C#
CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;
 
Task task = new Task(() =>PrintSquares(token), token);
try
{
    task.Start();
    Thread.Sleep(1000);
    // после задержки по времени отменяем выполнение задачи
    cancelTokenSource.Cancel();
 
    // ожидаем завершения задачи
    task.Wait();
}
catch (AggregateException ae)
{
    foreach (Exception e in ae.InnerExceptions)
    {
        if (e is TaskCanceledException)
            Console.WriteLine("Операция прервана");
        else
            Console.WriteLine(e.Message);
    }
}
finally
{
    cancelTokenSource.Dispose();
}
 
//  проверяем статус задачи
Console.WriteLine($"Task Status: {task.Status}");
 
 
void PrintSquares(CancellationToken token)
{
    for (int i = 1; i < 10; i++)
    {
        if (token.IsCancellationRequested)
            token.ThrowIfCancellationRequested(); // генерируем исключение
 
        Console.WriteLine($"Квадрат числа {i} равен {i * i}");
        Thread.Sleep(200);
    }
}
```

## Отмена параллельных операций Parallel
Для отмены выполнения параллельных операций, запущенных с помощью методов Parallel.For() и Parallel.ForEach(), можно использовать перегруженные версии данных методов,  
которые принимают в качестве параметра объект ParallelOptions. Данный объект позволяет установить токен:  
```C#
CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;
 
// в другой задаче посылаем сигнал отмены
new Task(() =>
{
    Thread.Sleep(400);
    cancelTokenSource.Cancel();
}).Start();
 
try
{
    Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5},
                                new ParallelOptions { CancellationToken = token }, Square);
    // или так
    //Parallel.For(1, 5, new ParallelOptions { CancellationToken = token }, Square);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Операция прервана");
}
finally
{
    cancelTokenSource.Dispose();
}
 
void Square(int n)
{
    Thread.Sleep(3000);
    Console.WriteLine($"Квадрат числа {n} равен {n * n}");
}
```
