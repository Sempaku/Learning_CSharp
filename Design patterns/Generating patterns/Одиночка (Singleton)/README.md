# Одиночка (Singleton)
Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует, что для определенного класса будет создан только один объект, а также предоставит к этому объекту точку доступа.

## Когда использовать?
- Синглтон позволяет создать объект только при его необходимости. Если объект не нужен, то он не будет создан. В этом отличие синглтона от глобальных переменных.

## Синглтон и многопоточность
При применении паттерна синглтон в *многопоточных* программах мы можем столкнуться с проблемой, которую можно описать следующим образом:
```C#
static void Main(string[] args)
{
    (new Thread(() =>
    {
        Computer comp2 = new Computer();
        comp2.OS = OS.getInstance("Windows 10");
        Console.WriteLine(comp2.OS.Name);
 
    })).Start();
 
    Computer comp = new Computer();
    comp.Launch("Windows 8.1");
    Console.WriteLine(comp.OS.Name);
    Console.ReadLine();
}
```
Здесь запускается дополнительный поток, который получает доступ к синглтону. Параллельно выполняется тот код, который идет запуска потока и кторый также обращается к синглтону. Таким образом, и главный, и дополнительный поток пытаются инициализровать синглтон нужным значением - "Windows 10", либо "Windows 8.1". Какое значение сиглтон получит в итоге, пресказать в данном случае невозможно.

## Lazy-реализация
Определение объекта синглтона в виде статического поля класса открывает нам дорогу к созданию **Lazy-реализации** паттерна Синглтон, то есть такой реализации, где данные будут инициализироваться только перед непосредственным использованием. Поскольку статические поля инициализируются перед первым доступом к статическому членам класса и перед вызовом статического конструктора (при его наличии). Однако здесь мы можем столкнуться с двумя трудностями.

Во-первых, класс синглтона может иметь множество статических переменных. Возможно, мы вообще не будем обращаться к объекту синглтона, а будем использовать какие-то другие статические переменные:

```C#
public class Singleton
{
    private static readonly Singleton instance = new Singleton();
    public static string text = "hello";
    public string Date { get; private set; }
         
    private Singleton()
    {
        Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
        Date = System.DateTime.Now.TimeOfDay.ToString();
    }
 
    public static Singleton GetInstance()
    {
        Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
        Thread.Sleep(500);
        return instance;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
        Console.WriteLine(Singleton.text);
        Console.Read();
    }
}
```
В данном случае идет только обращение к переменной text, однако статическое поле instance также будет инициализировано.
В данном случае мы видим, что статическое поле instance инициализировано.

Для решения этой проблемы выделим отдельный внутренний класс в рамках класса синглтона:

```C#
public class Singleton
{
    public string Date { get; private set; }
    public static string text = "hello";
    private Singleton()
    {
        Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
        Date = DateTime.Now.TimeOfDay.ToString();
    }
 
    public static Singleton GetInstance()
    {
        Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
        return Nested.instance;
    }
 
    private class Nested
    {
        internal static readonly Singleton instance = new Singleton();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
        Console.WriteLine(Singleton.text);
        Console.Read();
    }
}
```

## Реализация через класс Lazy<T>
Еще один способ создания синглтона представляет использование класса Lazy<T>:

```C#
  public class Singleton
{
    private static readonly Lazy<Singleton> lazy = 
        new Lazy<Singleton>(() => new Singleton());
 
    public string Name { get; private set; }
         
    private Singleton()
    {
        Name = System.Guid.NewGuid().ToString();
    }
     
    public static Singleton GetInstance()
    {
        return lazy.Value;
    }
}
  ```
