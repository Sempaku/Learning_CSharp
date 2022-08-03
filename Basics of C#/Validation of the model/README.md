# Валидация модели
Большую роль в приложении играет валидация модели или проверка вводимых данных на корректность. Например, у нас есть класс пользователя, в котором определено свойство для хранения возраста. И нам было бы нежелательно, чтобы пользователь вводил какое-либо отрицательное число или заведомо невозможный возвраст, например, миллион лет.

```C#
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
 
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```
В программе мы можем проверять вводимые данные с помощью условных конструкций:

```C#
CreateUser("Tom", 37);
CreateUser("b", -4);
CreateUser("", 130);
 
void CreateUser(string name, int age)
{
    User user = new User(name, age);
    // проверяем корректность значения свойства Name
    // если его длина в диапазоне от 3 до 50, то оно корректно
    if (user.Name.Length >= 3 && user.Name.Length <= 50)
        Console.WriteLine($"Name: {user.Name}");
    else
        Console.WriteLine("Incorrect name!");
 
    // проверяем корректность значения свойства Age
    // если оно в диапазоне от 1 до 100, то оно корректно
    if (age >= 1 && age <= 100)
        Console.WriteLine($"Age: {user.Age}\n");
    else
        Console.WriteLine("Incorrect age!\n");
 
}
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
 
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

Здесь предполагается, что имя должно иметь больше 1 символа, а возраст должен быть в диапазоне от 1 до 100. Однако в классе может быть гораздо больше свойств, для которых надо осуществлять проверки. А это привет к тому, что увеличится значительно код программы за счет проверок. К тому же задача валидации данных довольно часто встречается в приложениях. Поэтому фреймворк .NET предлагает гораздо более удобный функционал в виде атрибутов из пространства имен System.ComponentModel.DataAnnotations.

