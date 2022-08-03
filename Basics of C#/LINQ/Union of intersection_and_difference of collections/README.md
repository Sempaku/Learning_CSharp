# Объединение, пересечение и разность коллекций
LINQ предоставляет несколько методов для работы с коллекциями как с множествами, а именно находить их разность, объединение и пересечение.

## Разность последовательностей
С помощью метода Except() можно получить разность двух последовательностей:

```C#
string[] soft = { "Microsoft", "Google", "Apple"};
string[] hard = { "Apple", "IBM", "Samsung"};
 
// разность последовательностей
var result = soft.Except(hard);
 
foreach (string s in result)
    Console.WriteLine(s);
```

## Пересечение последовательностей
Для получения пересечения последовательностей, то есть общих для обоих наборов элементов, применяется метод Intersect():
```C#
string[] soft = { "Microsoft", "Google", "Apple"};
string[] hard = { "Apple", "IBM", "Samsung"};
 
// пересечение последовательностей
var result = soft.Intersect(hard);
 
foreach (string s in result)
    Console.WriteLine(s);
```

## Удаление дубликатов
Для удаления дублей в наборе используется метод Distinct():
```C#
string[] soft = { "Microsoft", "Google", "Apple", "Microsoft", "Google" };
 
// удаление дублей
var result = soft.Distinct();
 
foreach (string s in result)
    Console.WriteLine(s);
```
## Объединение последовательностей
Для объединения двух последовательностей используется метод Union(). Его результатом является новый набор, в котором имеются элементы, как из первой, так и из второй последовательности. Повторяющиеся элементы добавляются в результат только один раз:
```C#
string[] soft = { "Microsoft", "Google", "Apple"};
string[] hard = { "Apple", "IBM", "Samsung"};
 
// объединение последовательностей
var result = soft.Union(hard);
 
foreach (string s in result)
    Console.WriteLine(s);
```
## Работа со сложными объектами
Для сравнения объектов в последовательностях применяются реализации методов GetHeshCode() и Equals(). Поэтому если мы хотим работать с последовательностями, которые содержат объекты своих классов и структур, то нам необходимо определить для них подобные методы:

```C#
Person[] students = { new Person("Tom"), new Person("Bob"), new Person("Sam") };
Person[] employees = { new Person("Tom"), new Person("Bob"), new Person("Mike") };
 
// объединение последовательностей
var people = students.Union(employees);
 
foreach (Person person in people)
    Console.WriteLine(person.Name);
 
 
class Person
{
    public string Name { get;}
    public Person(string name) => Name = name;
 
    public override bool Equals(object? obj)
    {
        if (obj is Person person) return Name == person.Name;
        return false;
    }
    public override int GetHashCode() => Name.GetHashCode();
}
```


