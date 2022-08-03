# Сортировка
## Оператор orderby и метод OrderBy
Для сортировки набора данных в LINQ можно применять оператор orderby:

```C#
int[] numbers = { 3, 12, 4, 10};
var orderedNumbers = from i in numbers
                     orderby i
                     select i;
foreach (int i in orderedNumbers)
    Console.WriteLine(i);
```

## Сортировка сложных объектов

Возьмем посложнее пример. Допустим, надо отсортировать выборку сложных объектов. Тогда в качестве критерия мы можем указать свойство класса объекта:

```C#
var people = new List<Person>
{
    new Person("Tom", 37),
    new Person("Sam", 28),
    new Person("Tom", 22),
    new Person("Bob", 41),
};
// с помощью оператора orderby
var sortedPeople1 = from p in people
                  orderby p.Name
                  select p;
 
foreach (var p in sortedPeople1)
    Console.WriteLine($"{p.Name} - {p.Age}");
 
// с помощью метода OrderBy
var sortedPeople2 = people.OrderBy(p => p.Name);
 
foreach (var p in sortedPeople2)
    Console.WriteLine($"{p.Name} - {p.Age}");
 
record class Person(string Name, int Age);
```

## Сортировка по возрастанию и убыванию
По умолчанию оператор orderby и метод OrderBy производят сортировку по возрастанию. С помощью ключевых слов ascending (сортировка по возрастанию) и descending (сортировка по убыванию) для оператора orderby можно явным образом указать направление сортировки. Например, отсортируем массив чисел по убыванию:

```C#
int[] numbers = { 3, 12, 4, 10 };
var orderedNumbers = numbers.OrderByDescending(n => n);
foreach (int i in orderedNumbers)
    Console.WriteLine(i);   // 12 10 4 3
```

## Множественные критерии сортировки
В наборах сложных объектов иногда встает ситуация, когда надо отсортировать не по одному, а сразу по нескольким полям. Для этого в запросе LINQ все критерии указываются в порядке приоритета через запятую:

```C#
var people = new List<Person>
{
    new Person("Tom", 37),
    new Person("Sam", 28),
    new Person("Tom", 22),
    new Person("Bob", 41),
};
// с помощью оператора orderby
var sortedPeople1 = from p in people
                  orderby p.Name, p.Age
                  select p;
 
foreach (var p in sortedPeople1)
    Console.WriteLine($"{p.Name} - {p.Age}");
```

## Переопределение критерия сортировки
С помощью реализации IComparer мы можем переопределить критерии сортировки, если они нас не устраивают. Например, строки по умолчанию сортируются в алфавитном порядке. Но что, если мы хотим сортировать строки исходя из их длины? Решим данную задачу:

```C#
string[] people = new[]{"Kate", "Tom", "Sam", "Mike", "Alice"};
var sortedPeople = people.OrderBy(p => p, new CustomStringComparer());
 
foreach (var p in sortedPeople)
    Console.WriteLine(p);
 
// сравнение по длине строки
class CustomStringComparer : IComparer<String>
{
    public int Compare(string? x, string? y)
    {
        int xLength = x?.Length ?? 0; // если x равно null, то длина 0
        int yLength = y?.Length ?? 0;
        return xLength - yLength;
    }
}
```
Интерфейс IComparer типизируется типов сортируемых данных (в данном случае типом String). Для реализации этого интерфейса необходимо определить метод Compare. Он возвращает число: если первый параметр больше второго, то число больше 0, если меньше - то число меньше 0. Если оба параметра равны, то возвращается 0.

В данном случае, если параметр равен null, будем считать что длина строки равна 0. И с помощью разницы длин строк из обоих параметров определяем, какой из них больше.

