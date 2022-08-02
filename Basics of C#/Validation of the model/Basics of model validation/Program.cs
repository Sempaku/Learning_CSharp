using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Основы_валидации_модели
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateUser("Dima", 20);
            CreateUser("Artur", 999);
            CreateUser("a", 11);
            CreateUserPhone("+7777-666-5554");
            CreateUserPhone("+++321");
        }

        static void CreateUser(string name, int age)
        {
            User user = new User(name, age);
            var context = new ValidationContext(user);
            var result = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user, context, result,true))
            {
                Console.WriteLine("Не удалось создать объект user");
                foreach (var error in result)
                    Console.WriteLine(error.ErrorMessage);
                Console.WriteLine();
            }
            else
                Console.WriteLine($"Объект user был успешно создан. Name: {user.Name}");

        }

        static void CreateUserPhone(string phone)
        {
            UserPhone userPhone = new UserPhone(phone);
            var context = new ValidationContext(userPhone);
            var result = new List<ValidationResult>();
            if (Validator.TryValidateObject(userPhone, context, result, true))
            {
                Console.WriteLine("Этот номер валидный");
            }
            else
                Console.WriteLine("Данный номер невалиден");
        }
    }

    public class UserPhone
    {
        [Required]
        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }
        public UserPhone(string number)
        {
            PhoneNumber = number;
        }
    }
    public class User
    {
        [Required(ErrorMessage ="Говно имя")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="И длинна говно")]
        public string Name { get; set; }

        [Range(1,100)]
        public int Age { get; set; }
        public User(string name, int age)
        {
            Name = name; Age = age;
        }
    }
}
