using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Самовалидация_модели
{
    class Program
    {
        static void Main(string[] args)
        {
            // Мы можем применить к классу интерфейс IValidatableObject и реализовать его метод Validate()
            Validate(new User("Bobby", -1));
        }
        static void Validate(User user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);

            if (!Validator.TryValidateObject(user, context, results,true))
            {
                foreach(var error in results)
                    Console.WriteLine(error.ErrorMessage);
                Console.WriteLine("User not valid");
            }
            Console.WriteLine("User valid");
        }
    }

    class User : IValidatableObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string name, int age)
        {
            Name = name; Age = age;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(new ValidationResult("Не указано имя."));
            }
            if (Name.Length < 1 || Name.Length > 40)
            {
                errors.Add(new ValidationResult("Некорректная длина имени"));
            }
            if(this.Age < 1 || this.Age > 100)
            {
                errors.Add(new ValidationResult("Недопустимый возраст"));
            }

            return errors;
        }
    }
}
