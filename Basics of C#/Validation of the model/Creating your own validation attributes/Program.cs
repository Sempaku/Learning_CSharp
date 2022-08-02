using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Создание_своих_атрибутов_валидации
{
    class Program
    {
        static void Main(string[] args)
        {
            //Атрибут уровня свойства
            Validate(new User("admin", 31));
            Validate(new User("John", 31));

            //___________________________________
            Console.WriteLine("_____________");
            //___________________________________
            //Атрибуты валидации уровня класса
            Validate(new User("Sam", 19));

            //___________________________________
            Console.WriteLine("_____________");
            //___________________________________
            //Передача в атрибут значений
            Validate1(new User1("Diman", 20));

        }
        static void Validate1(User1 user)
        {
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach(var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("User is valid");
            }
        }
        static void Validate(User user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if(!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Пользователь прошел валидацию");
            }
            Console.WriteLine();
        }
    }
    public class UserValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is User user)
            {
                if (user.Name == "Sam" && user.Age == 19)
                {
                    ErrorMessage = $"Пользователь не должен иметь имя Sam и его возраст не должен быть 19";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
    public class UserNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string userName)
            {
                if (userName == "admin")
                {
                    return true;
                }
                else
                {
                    ErrorMessage = $"Некорректное имя: {value.ToString()}";
                }
            }
            return false;
        }
    }
    [UserValidation]
    class User
    {
        //[UserName]
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string name, int age)
        {
            Name = name; Age = age;
        }
    }

    [User1Validation("Diman", 20)]
    class User1
    {
        
        public string Name { get; set; }
        public int Age { get; set; }
        public User1(string name, int age)
        {
            Name = name; Age = age;
        }
    }

    public class User1ValidationAttribute : ValidationAttribute
    {
        public string InvalidName { get; set; }
        public int InvalidAge { get; set; }
        public User1ValidationAttribute(string name, int age)
        {
            InvalidName = name; InvalidAge = age;
        }
        public override bool IsValid(object value)
        {
            if (value is User1 user)
            {
                if(user.Name == InvalidName && user.Age == InvalidAge)
                {
                    ErrorMessage = $"Имя не должно быть {InvalidName}; Возраст не должен быть {InvalidAge}";
                    return false;
                }
                return true;
            }
            return false;
        }

    }


}
