# Фильтрация коллекции
Для выбора элементов из некоторого набора по условию используется метод Where:
```C#
Where<TSource> (Func<TSource,bool> predicate)
```
Этот метод принимает делегат Func<TSource,bool>, который в качестве параметра принимает каждый элемент последовательности и возвращает значение bool. Если элемент соответствует некоторому условию, то возвращается true, и тогда этот элемент передаетсяв коллекцию, которая возвращается из метода Where.

## Выборка сложных объектов
Допустим, у нас есть класс пользователя:

```C#
record class Person(string Name, int Age, List<string> Languages);
```
Создадим набор пользователей и выберем из них тех, которым больше 25 лет:

```C#
var people = new List<Person>
{
    new Person ("Tom", 23, new List<string> {"english", "german"}),
    new Person ("Bob", 27, new List<string> {"english", "french" }),
    new Person ("Sam", 29, new List<string>  { "english", "spanish" }),
    new Person ("Alice", 24, new List<string> {"spanish", "german" })
};
 
var selectedPeople = from p in people
                     where p.Age > 25
                     select p;
 
foreach (Person person in selectedPeople)
    Console.WriteLine($"{person.Name} - {person.Age}");
```
or
```C#
var selectedPeople = people.Where(p=> p.Age > 25);
```

## Сложные фильтры
Теперь рассмотрим более сложные фильтры. Например, в классе пользователя есть список языков, которыми владеет пользователь. Что если нам надо отфильтровать пользователей по языку:

```C#
var selectedPeople = from person in people
                    from lang in person.Languages
                    where person.Age < 28
                    where lang == "english"
                    select person;
```
or
```C#
var selectedPeople = people.SelectMany(u => u.Languages,
                            (u, l) => new { Person = u, Lang = l })
                          .Where(u => u.Lang == "english" && u.Person.Age < 28)
                          .Select(u=>u.Person);
```
Метод SelectMany() в качестве первого параметра принимает последовательность, которую надо проецировать, а в качестве второго параметра - функцию преобразования, которая применяется к каждому элементу. На выходе она возвращает 8 пар "пользователь - язык" (new { Person = u, Lang = l }), к которым потом применяется фильтр с помощью Where.

## Фильтрация по типу данных
Дополнительный метод расширения - OfType() позволяет отфильтровать данные коллекции по определенному типу:

```C#
var people= new List<Person>
{
    new Student("Tom"),
    new Person("Sam"),
    new Student("Bob"),
    new Employee("Mike")
};
 
var students = people.OfType<Student>();
 
foreach (var student in students)
    Console.WriteLine(student.Name);
 
 
record class Person(string Name);
record class Student(string Name): Person(Name);
record class Employee(string Name) : Person(Name);
```
