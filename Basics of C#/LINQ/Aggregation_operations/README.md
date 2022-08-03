# Агрегатные операции
К агрегатным операциям относят различные операции над выборкой, например, получение числа элементов, получение минимального, максимального и среднего значения в выборке, а также суммирование значений.

## Метод Aggregate()
Метод Aggregate выполняет общую агрегацию элементов коллекции в зависимости от указанного выражения. Например:

```C#
int[] numbers = { 1, 2, 3, 4, 5};
 
int query = numbers.Aggregate((x,y)=> x - y);
Console.WriteLine(query);   // -13
```

## Получение размера выборки. Метод Count()
Для получения числа элементов в выборке используется метод Count():

```C#
int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
int size = numbers.Count();  // 10
Console.WriteLine(size);
```
Метод Count() в одной из версий также может принимать лямбда-выражение, которое устанавливает условие выборки. Поэтому мы можем в данном случае не использовать выражение Where:

```C#
int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
//  количество четных чисел, которые больше 10
int size = numbers.Count(i => i % 2 == 0 && i > 10);
Console.WriteLine(size);    // 3
```

## Получение суммы
Для получения суммы значений применяется метод **Sum()**

Метод Sum() имеет ряд перегрузок. В частности, если у нас набор сложных объектов, как в примере выше, то мы можем указать свойство, значения которого будут суммироваться:
```C#
Person[] people = { new Person("Tom", 37), new Person("Sam", 28), new Person("Bob", 41) };
 
int ageSum = people.Sum(p => p.Age);
Console.WriteLine(ageSum);     // 106
 
record class Person(string Name, int Age);
```
## Максимальное, минимальное и среднее значения
Для нахождения минимального значения применяется метод Min(), для получения максимального - метод Max(), а для нахождения среднего значения - метод Average(). Их действие похоже на методы Sum() и Count()

Если мы работаем со сложными объектами, то в эти методы передается делегат, который принимает свойство, применяемое в вычислениях:
```C#
Person[] people = { new Person("Tom", 37), new Person("Sam", 28), new Person("Bob", 41) };
 
int minAge = people.Min(p => p.Age); // минимальный возраст
int maxAge = people.Max(p => p.Age); // максимальный возраст
double averageAge = people.Average(p => p.Age); //средний возраст
 
Console.WriteLine($"Min Age: {minAge}");           // Min Age: 28
Console.WriteLine($"Max Age: {maxAge}");           // Max Age: 41
Console.WriteLine($"Average Age: {averageAge}");   // Average Age: 35,33
 
record class Person(string Name, int Age);
```

