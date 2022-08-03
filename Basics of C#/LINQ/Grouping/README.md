# Группировка
Для группировки данных по определенным параметрам применяется оператор group by и метод GroupBy().


## Оператор group by
Допустим, у нас есть набор из объектов следующего типа:

```C#
record class Person(string Name, string Company);
```

Данный класс представляет пользователя и имеет два свойства: Name (имя пользователя) и Company (компания, где работает пользователь). Сгруппируем набор пользователей по компании:

```C#
Person[] people =
{
    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
};
 
var companies = from person in people
                group person by person.Company;
 
foreach(var company in companies)
{
    Console.WriteLine(company.Key);
 
    foreach(var person in company)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine(); // для разделения между группами
}
 
record class Person(string Name, string Company);
```


# GroupBy
В качестве альтернативы можно использовать метод расширения GroupBy. Он имеет ряд перегрузок, возьмем самую простую из них:

```C#
GroupBy<TSource,TKey> (Func<TSource,TKey> keySelector);
```
Данная версия получает делегат, которые в качестве параметра принимает каждый элемент коллекции и возвращает критерий группировки.

Перепишем предыдущий пример с помощью метода GroupBy:

```C#
Person[] people =
{
    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
};
 
var companies = people.GroupBy(p => p.Company);
 
foreach(var company in companies)
{
    Console.WriteLine(company.Key);
 
    foreach(var person in company)
    {
        Console.WriteLine(person.Name);
    }
    Console.WriteLine(); // для разделения между группами
}
 
record class Person(string Name, string Company);
```

## Создание нового объекта при группировке
Теперь изменим запрос и создадим из группы новый объект:

```C#
Person[] people =
{
    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
};
 
var companies = from person in people
                group person by person.Company into g
                select new { Name = g.Key, Count = g.Count() }; ;
 
foreach(var company in companies)
{
    Console.WriteLine($"{company.Name} : {company.Count}");
}
 
record class Person(string Name, string Company);
```
Аналогичная операция с помощью метода GroupBy():

```C#
var companies = people
                    .GroupBy(p=>p.Company)
                    .Select(g => new { Name = g.Key, Count = g.Count() });
```
