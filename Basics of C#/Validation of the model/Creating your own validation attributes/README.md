# Создание своих атрибутов валидации
Несмотря на то, что .NET предоставляет нам большой набор встроенных атрибутов валидации, может потребоваться более изощренные в плане логики атрибуты. И в этом случае мы можем определить свои классы атрибутов.

Для создания атрибута нам надо унаследовать свой класс от класса ValidationAttribute и реализовать его метод IsValid():

При создании атрибута надо понимать, к чему именно он будет применяться - к свойству модели или ко всей модели в целом. Рассмотрим обе ситуации.

## Атрибут уровня свойства
```C#
public class UserNameAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string userName)
        {
            if (userName != "admin")    // если имя не равно admin
                return true;
            else
                ErrorMessage = "Некорректное имя: admin";
        }
        return false;
    }
}
```

Класс атрибута наследуется от класса ValidationAttribute и реалует его метод IsValid(). В данный метод передается значение, которое валидируется.

Данный атрибут будет применяться к строковому свойству, поэтому в метод IsValid(object? value) в качестве value будет передаваться строка. 

Применим данный атрибут к свойству класса:

```C#
using System.ComponentModel.DataAnnotations;
 
Validate(new User("Bob", 41));
Validate(new User("admin", 37));
 
void Validate(User user)
{
    var results = new List<ValidationResult>();
    var context = new ValidationContext(user);
    if (!Validator.TryValidateObject(user, context, results, true))
    {
        foreach (var error in results)
        {
            Console.WriteLine(error.ErrorMessage);
        }
    }
    else
        Console.WriteLine("Пользователь прошел валидацию");
    Console.WriteLine();
}
 
public class User
{
    [UserName]
    public string Name { get; set; }
 
    public int Age { get; set; }
 
    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

## Атрибуты валидации уровня класса
Определим еще один атрибут, который будет применяться ко всему классу User в целом:


```C#
public class UserValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if(value is User user)
        {
            if (user.Name == "Tom" && user.Age == 37)
            {
                ErrorMessage = "Имя не должно быть Tom и возраст одновременно не должен быть равен 37";
                return false;
            }
            return true;
        }
        return false;
    }
}
```
Поскольку атрибут будет применяться ко всей модели, то в метод IsValid в качестве параметра value будет передаваться объект User. Как правило, атрибуты, которые применяются ко всей модели, валидируют сразу комбинацию свойств класса. В данном случае смотрим, чтобы имя и возраст одновременно не были равны "Tom" и 37.

Теперь применим этот атрибут:

```C#
using System.ComponentModel.DataAnnotations;
 
Validate(new User("Bob", 41));
Validate(new User("Tom", 37));
 
void Validate(User user)
{
    var results = new List<ValidationResult>();
    var context = new ValidationContext(user);
    if (!Validator.TryValidateObject(user, context, results, true))
    {
        foreach (var error in results)
        {
            Console.WriteLine(error.ErrorMessage);
        }
    }
    else
        Console.WriteLine("Пользователь прошел валидацию");
    Console.WriteLine();
}
 
[UserValidation]
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
Поскольку атрибут UserValidation должен применяться ко всему классу User, то он указывается непосредственно перед определением класса:

## Передача в атрибут значений

Выше оба атрибута сравнивали валидируемое значение с некоторым жестко заданным в коде набором значений. Однако мы можем определить через конструктор механизм передачи в атрибут значений из вне. Например, изменим атрибут UserValidation:

```C#
public class UserValidationAttribute : ValidationAttribute
{
    public string InvalidName { get; set; }
    public int InvalidAge { get; set; }
    public UserValidationAttribute(string name, int age)
    {
        InvalidName = name;
        InvalidAge = age;
    }
    public override bool IsValid(object? value)
    {
        if(value is User user)
        {
            if (user.Name == InvalidName && user.Age == InvalidAge)
            {
                ErrorMessage = $"Имя не должно быть равно {InvalidName} и возраст одновременно не должен быть равен {InvalidAge}";
                return false;
            }
            return true;
        }
        return false;
    }
}
```
В данном случае значения, относительно которых будет проводиться валидация, передаются через конструктор и сохраняются в свойствах InvalidAge и InvalidName.
При применении атрибута теперь надо указать значения для параметров конструктора UserValidation:

```C#
[UserValidation("Bob", 41)]
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

