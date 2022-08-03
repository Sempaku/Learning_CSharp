# Возвращение результата из асинхронного метода
В качестве возвращаемого типа в асинхронном методе должны использоваться типы void, Task, Task<T> или ValueTask<T>

## void
При использовании ключевого слова void асинхронный метод ничего не возвращает:
```C#
PrintAsync("Hello World");
PrintAsync("Hello METANIT.COM");
 
Console.WriteLine("Main End");
await Task.Delay(3000); // ждем завершения задач
 
// определение асинхронного метода
async void PrintAsync(string message)
{
    await Task.Delay(1000);     // имитация продолжительной работы
    Console.WriteLine(message);
}   
```
  
  Однако асинхронных void-методов следует избегать и следует использовать только там, 
  где эти подобные методы представляют единственный возможный способ определения асинхронного метода. 
  Прежде всего, мы не можем применить к подобным методам оператор await. 
  Также потому что исключения в таких методах сложно обрабатывать, так как они не могут быть перехвачены вне метода. 
  Кроме того, подобные void-методы сложно тестировать.
  
  Тем не менее есть ситуации, где без подобных методов не обойтись - например, при обработке событий:


  ```C#
Account account = new Account();
account.Added += PrintAsync;
 
account.Put(500);
 
await Task.Delay(2000); // ждем завершения
 
// определение асинхронного метода
async void PrintAsync(object? obj, string message)
{
    await Task.Delay(1000);     // имитация продолжительной работы
    Console.WriteLine(message);
}
 
class Account
{
    int sum = 0;
    public event EventHandler<string>? Added;
    public void Put(int sum)
    {
        this.sum += sum;
        Added?.Invoke(this, $"На счет поступило {sum} $");
    }
}
  ```
  
## Task
Возвращение объекта типа Task:
```C#
  await PrintAsync("Hello Metanit.com");
 
// определение асинхронного метода
async Task PrintAsync(string message)
{
    await Task.Delay(1000);     // имитация продолжительной работы
    Console.WriteLine(message);
}
  ```
Для ожидания завершения асинхронной задачи можно применить оператор await. Причем его необязательно использовать непосредственно при вызове задачи.
Его можно применить лишь там, где нам нужно гарантировано получить результат задачи или удостовериться, что задача завершена.
```C#
  var task = PrintAsync("Hello Metanit.com"); // задача начинает выполняться
Console.WriteLine("Main Works");
 
await task; // ожидаем завершения задачи
 
// определение асинхронного метода
async Task PrintAsync(string message)
{
    await Task.Delay(0);
    Console.WriteLine(message);
}
  ```
## Task<T>
Метод может возвращать некоторое значение. Тогда возвращаемое значение оборачивается в объект Task, а возвращаемым типом является Task<T>:

```C#
  int n1 = await SquareAsync(5);
int n2 = await SquareAsync(6);
Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36
 
async Task<int> SquareAsync(int n)
{
    await Task.Delay(0);
    return n * n;
}
  ```
  
  
  ## ValueTask<T>
Использование типа ValueTask<T> во многом аналогично применению Task<T> за исключением некоторых различий в работе с памятью, поскольку ValueTask - структура, которая содержит большее количество полей. Поэтому применение ValueTask вместо Task приводит к копированию большего количества данны и соответственно создает некоторые дополнительные издержки.

Преимуществом ValueTask перед Task является то, что данный тип позволяет избежать дополнительных выделений памяти в хипе. Например, иногда требуется синхронно возвратить некоторое значение. 
  ```C#
  var result = await AddAsync(4, 5);
Console.WriteLine(result);
 
Task<int> AddAsync(int a, int b)
{
    return Task.FromResult(a + b);
}
  ```
  Здесь метод AddAsync синхронно возвращает некоторое значение - в данном случае сумму двух чисел. С помощью статического метода Task.FromResult можно синхронно возвратить некоторое значение. Однако использование типа Task приведет к выделению дополнительной задачи с сопутствующими выделениями памяти в хипе. ValueTask решает эту задачу:

```C#
  var result = await AddAsync(4, 5);
Console.WriteLine(result);
 
ValueTask<int> AddAsync(int a, int b)
{
    return new ValueTask<int>(a + b);
}
  ```
  
  В данном случае дополнительный объект Task не будет создаваться и соответственно дополнительная память не будет выделяться. Поэтому ValueTask обычно применяется, когда результат асинхронной операции уже имеется.

При необходимости также можно преобразовать ValueTask в объект Task с помощью метода AsTask():

```C#
  var getMessage = GetMessageAsync();
string message = await getMessage.AsTask();
Console.WriteLine(message); // Hello
 
async ValueTask<string> GetMessageAsync()
{
    await Task.Delay(0);
    return "Hello";
}
  ```
